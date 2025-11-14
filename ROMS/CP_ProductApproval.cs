using DocumentFormat.OpenXml.VariantTypes;
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
    public partial class CP_ProductApproval : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtProductHSN = new DataTable();
        DataTable dtPurHSN = new DataTable();
        DataTable dtSalesHSN = new DataTable();
        public int varUnitid = 0, varComId = 0, varproductcode = 0, varPURSLID = 0, varPURRKID = 0, varHsnId = 0, varSubGroupId = 0, varSALESLID = 0, varSALERKID = 0, varflag = 0, varGroupId = 0, varPurHSNID = 0, varSalesHSNID = 0, varPurEffectiveFromErr = 0, varSalesEffectiveFromErr = 0, varUpDownKeyPurLocation = 0, varUpDownKeySalesLocation = 0;
        public string varSubgroupCode = "", varPurLocationCode = "", varPurRackCode = "", varBrand = "", varSalesRackCode = "", varSalesLocationCode = "", varHsnCode = "", varCategoryId = "", varPurHSNCode = "", varPurGST = "", varSalesHSNCode = "", varSalesGST = "";
        private ToolTip tpplno = new ToolTip();
        private ToolTip tpprd = new ToolTip();
        private ToolTip tpgst = new ToolTip();
        private ToolTip tpprdSG = new ToolTip();
        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpbrand = new ToolTip();
        private ToolTip tppurchaselocation = new ToolTip();
        private ToolTip tppurchaserack = new ToolTip();
        private ToolTip tpengname = new ToolTip();
        private ToolTip tptamname = new ToolTip();
        private ToolTip tpHsnCode = new ToolTip();
        private ToolTip tpshelflifevalue= new ToolTip();
        private ToolTip tpsalesrack = new ToolTip();
        private ToolTip tpSalelocation = new ToolTip();
        private ToolTip tpunit = new ToolTip();
        private ToolTip tpPicode = new ToolTip();
        private ToolTip tpPurHSN = new ToolTip();
        private ToolTip tpSalesHSN = new ToolTip();

        public CP_ProductApproval()
        {
            InitializeComponent();
            MainForm.objCP_ProductApprovalList.picLoader.Visible = false;
        }
       
        public void udfntooltiphide()
        {
            try
            {
                tpplno.Active = false;
                tpprd.Active = false;
                tpgst.Active = false;
                tpprdSG.Active = false;
                tpcompanyname.Active = false;
                tpbrand.Active = false;
                tppurchaselocation.Active = false;
                tppurchaserack.Active = false;
                tpengname.Active = false;
                tptamname.Active = false;
                tpHsnCode.Active = false;
                tpshelflifevalue.Active = false;
                tpsalesrack.Active = false;
                tpSalelocation.Active = false;
                tpunit.Active = false;

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
                DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                DialogResult dialogResult = MessageBox.Show("Do you want to discard changes ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        //private void BtnClose_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    udfnclose();
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    objError = new DataError();
        //    //    objError.WriteFile(ex);
        //    //}

        //}

        private void CP_ProductApproval_Load(object sender, EventArgs e)
        {

            try
            {
                dtProductHSN.Columns.Add("HSN_Type", typeof(int));
                dtProductHSN.Columns.Add("HSNID", typeof(int));
                dtProductHSN.Columns.Add("HSN_EffectiveFrom", typeof(string));
                dtProductHSN.Columns.Add("HSN_EffectiveTo", typeof(string));
                dtProductHSN.Columns.Add("PRHSN_ChangedDate", typeof(string));
                dtProductHSN.Columns.Add("PRHSN_MakerID", typeof(int));


                dtPurHSN.Columns.Add("HSN_Type", typeof(int));
                dtPurHSN.Columns.Add("HSNID", typeof(int));
                dtPurHSN.Columns.Add("HSN_EffectiveFrom", typeof(string));
                dtPurHSN.Columns.Add("HSN_EffectiveTo", typeof(string));
                dtPurHSN.Columns.Add("PRHSN_ChangedDate", typeof(string));
                dtPurHSN.Columns.Add("PRHSN_MakerID", typeof(int));


                dtSalesHSN.Columns.Add("HSN_Type", typeof(int));
                dtSalesHSN.Columns.Add("HSNID", typeof(int));
                dtSalesHSN.Columns.Add("HSN_EffectiveFrom", typeof(string));
                dtSalesHSN.Columns.Add("HSN_EffectiveTo", typeof(string));
                dtSalesHSN.Columns.Add("PRHSN_ChangedDate", typeof(string));
                dtSalesHSN.Columns.Add("PRHSN_MakerID", typeof(int));

                //BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                //if (btnSave.Text == "Save")
                //{
                //    this.ActiveControl = txtpicode;
                //}
                //else
                //{
                //    this.ActiveControl = txtPICode;
                //}
                this.ActiveControl = txtpicode;
                //udfnDropDownload();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (5,0) AND MSTID NOT IN (0,369)", "MST_DisplayText,MSTID", cmbProductCategory, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (6,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbPeriod, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (25,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbBatchno, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (26,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbBatchGen, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (26,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbBatchNoGeneration, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("MR_QtyUnit", " QUT_STSID =1", "QUT_Symbol,QUTID", cmbUnit, "", "QUT_Symbol", "QUTID");
                objDataBind.BindComboBoxListSelected("DEF_GST", " GSTID  not in (0)", "GST_Text,GSTID", cmbGst, "", "GST_Text", "GSTID");
                objDataBind = null;
                //cmbConcern.SelectedValue = -1;
                //varComId = MainForm.pbDefaultComId;
                //cmbHSNName.SelectedValue = -1;
                //cmbUnit.SelectedValue = -1;
                //cmbBulkUnit.SelectedValue = -1;
                cmbProductCategory.SelectedValue = -1;
                cmbPeriod.SelectedValue = -1;
                cmbBatchno.SelectedValue = 72;
                cmbBatchGen.SelectedValue = -1;

                //cmbBatchNoGeneration.SelectedValue = -1;
                udfnUnitLoad();
                udfnEdit();
                udfnLoadGrid(0);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 16;
                objMR_Master.paraID = Convert.ToInt32(cmbProductCategory.SelectedValue);
                BeginInvoke(new Action(() => cmbProductCategory.Select(int.MaxValue, 0)));
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbBatchno.SelectedValue = objDT.Tables[0].Rows[0]["MSBT_BatchNo"].ToString();
                            cmbBatchGen.SelectedValue = objDT.Tables[0].Rows[0]["MSBT_BatchNoGeneration"].ToString();
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
        public void udfnUnitLoad()
        {
            try
            {
                //if (btnSave.Text == "Save")
                //{
                //    varViewType = 1;
                //}
                DataSet objDT = new DataSet();
                //DataSet objDTBulkUnit = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDT = objdserv.udfnUnitList(1, varUnitid, 0);
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        //public void udfnUnitLoad()
        //{
        //    try
        //    {
        //        //if (btnSave.Text == "Save")
        //        //{
        //        //    varViewType = 1;
        //        //}
        //        DataSet objDT = new DataSet();
        //        //DataSet objDTBulkUnit = new DataSet();
        //        SPDataService objdserv = new SPDataService();
        //        objDT = objdserv.udfnMaster(1, varUnitid, 0);
        //        objdserv.CloseConnection();
        //        cmbUnit.DataSource = null;
        //        if (objDT != null)
        //        {
        //            if (objDT.Tables.Count > 0)
        //            {
        //                if (objDT.Tables[0].Rows.Count > 0)
        //                {
        //                    cmbUnit.ValueMember = "UTID";
        //                    cmbUnit.DisplayMember = "UT_Symbol";
        //                    cmbUnit.DataSource = objDT.Tables[0];
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}

        private void Txtpicode_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                txtpicode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtpicode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtpicode.Text == "")
                {
                    epProductApproval.SetError(txtpicode, "Please enter PICode");
                    txtpicode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter PICode", txtpicode, 5000);
                }
                else
                {
                    txtpicode.BackColor = Color.White;
                    epProductApproval.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductEname_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                txtProductEname.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductEname_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductEname.Text == "")
                {
                    txtProductEname.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductApproval.SetError(txtProductEname, "Please enter product name in english");
                }
                else
                {
                    txtProductEname.BackColor = Color.White;
                    epProductApproval.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductTname_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                txtProductTname.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductTname_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductTname.Text == "")
                {
                    txtProductTname.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductApproval.SetError(txtProductTname, "Please enter product name in tamil");
                }
                else
                {
                    txtProductTname.BackColor = Color.White;
                    epProductApproval.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                cmbProductCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbProductCategory.SelectedValue) == "" || Convert.ToString(cmbProductCategory.SelectedValue) == "-1")
                {
                    epProductApproval.SetError(cmbProductCategory, "Please select product category");
                    cmbProductCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpprd.ShowAlways = true;
                    tpprd.Show("Please select product category", cmbProductCategory, 5000);
                }
                else
                {
                    epProductApproval.Clear();
                    cmbProductCategory.BackColor = Color.White;
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSubgroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductCategory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtSubgroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                //lvSubGroup.Visible = false;
                txtSubgroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSubgroup_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSubgroup.Text == "")
                {
                    txtSubgroup.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductApproval.SetError(txtSubgroup, "Please enter subgroup");
                    //txtGroup.Text = "";
                    //lblGroupCode.Text = "0";
                    txtBrand.Text = "";
                    varBrand = "0";
                }
                else 
                {
                    /*
                    // Check product sub group is valid or not
                    string varId_SubGroup = "0";
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubgroup.Text.Trim(), 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varSubgroupCode = Convert.ToString(varId_SubGroup);
                    if (varId_SubGroup == "0" || varId_SubGroup == "-1")
                    {
                        epProductApproval.SetError(txtSubgroup, "Please select valid subgroup");
                        txtSubgroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpprdSG.ShowAlways = true;
                        tpprdSG.Show("Please select valid subgroup", txtSubgroup, 5000);
                    }
                    else
                    {
                        epProductApproval.Clear();
                    }
                    */
                    txtSubgroup.BackColor = Color.White;
                }
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSubgroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSubgroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(8, 0, "", 0, 0, txtSubgroup.Text.Trim(), 0, 0, 0, 0, 0);

                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), objDs.Tables[0].Rows[i]["PRSG_SLID"].ToString(), objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString(), objDs.Tables[0].Rows[i]["RackName"].ToString(), "", "", "", "" };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvSubGroup.Items.Add(objList);
                                }
                                lvSubGroup.Visible = true;
                                lvSubGroup.BringToFront();
                            }
                        }
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
        }

        private void TxtBrand_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void LvSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSubGroupAutocomplete();
                    txtBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnBrandAutocomplete();
                    cmbUnit.Focus();
                }
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
                udfnSubGroupAutocomplete();
                txtBrand.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void LvBrand_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnBrandAutocomplete();
                cmbUnit.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (varUpDownKeyPurLocation == 0)
                {
                    if (txtPurLocation.Text.Length > 0)
                    {
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 10;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(varComId);
                        objMR_Location.paraLocationName = txtPurLocation.Text.Trim();
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterPurLocation.Visible = true;
                                    DGV_FilterPurLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterPurLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterPurLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterPurLocation.Columns["SL_EName"].HeaderText = "Location E Name";
                                    DGV_FilterPurLocation.Columns["SL_TName"].HeaderText = "Location T Name";
                                    DGV_FilterPurLocation.Columns["SL_EName"].Width = 180;
                                    DGV_FilterPurLocation.Columns["SL_TName"].Width = 180;
                                    DGV_FilterPurLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterPurLocation.Columns["SL_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterPurLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterPurLocation.Visible = false;
                                    DGV_FilterPurLocation.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterPurLocation.Visible = false;
                                DGV_FilterPurLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterPurLocation.Visible = false;
                            DGV_FilterPurLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterPurLocation.Visible = false;
                        DGV_FilterPurLocation.DataSource = null;
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
                txtPurLocation.Focus();
            }
        }

        private void TxtPurRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvPurRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtPurRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(7, 0, 0, Convert.ToInt32(varPurLocationCode), 0, txtPurRack.Text.Trim(), 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RK_Description"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvPurRack.Items.Add(objList);
                                }
                                lvPurRack.BringToFront();
                                lvPurRack.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvPurRack.Visible = false;
                    lvPurRack.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (varUpDownKeySalesLocation == 0)
                {
                    if (txtSalesLocation.Text.Length > 0)
                    {
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 10;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(varComId);
                        objMR_Location.paraLocationName = txtSalesLocation.Text.Trim();
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(10, Convert.ToInt32(varComId), 0, 0, txtSalesLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterSalesLocation.Visible = true;
                                    DGV_FilterSalesLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterSalesLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterSalesLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterSalesLocation.Columns["SL_EName"].HeaderText = "Location E Name";
                                    DGV_FilterSalesLocation.Columns["SL_TName"].HeaderText = "Location T Name";
                                    DGV_FilterSalesLocation.Columns["SL_EName"].Width = 180;
                                    DGV_FilterSalesLocation.Columns["SL_TName"].Width = 180;
                                    DGV_FilterSalesLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterSalesLocation.Columns["SL_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterSalesLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSalesLocation.DataSource = null;
                                    DGV_FilterSalesLocation.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterSalesLocation.DataSource = null;
                                DGV_FilterSalesLocation.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterSalesLocation.DataSource = null;
                            DGV_FilterSalesLocation.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterSalesLocation.DataSource = null;
                        DGV_FilterSalesLocation.Visible = false;
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
                txtSalesLocation.Focus();
            }
        }

        private void TxtSalesRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSalesRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSalesRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(7, 0, 0, Convert.ToInt32(varSalesLocationCode), 0, txtSalesRack.Text.Trim(), 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RK_Description"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSalesRack.Items.Add(objList);
                                }
                                lvSalesRack.BringToFront();
                                lvSalesRack.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvSalesRack.Visible = false;
                    lvSalesRack.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnSubGroupAutocomplete()
        {
            try
            {
                if (txtSubgroup.Text != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    txtSubgroup.Text = selectedItem.SubItems[0].Text;
                    varSubgroupCode = selectedItem.SubItems[2].Text;
                    //txtGroup.Text = selectedItem.SubItems[4].Text;
                    //varGroupCode = Convert.ToInt32(selectedItem.SubItems[5].Text);
                    txtPurLocation.Text = selectedItem.SubItems[4].Text;
                    varPurLocationCode = selectedItem.SubItems[3].Text;
                    varPurRackCode = selectedItem.SubItems[5].Text;
                    txtPurRack.Text = selectedItem.SubItems[6].Text;
                    string varbatchenable = selectedItem.SubItems[3].Text;
                    //txtRackDescription.Text = selectedItem.SubItems[10].Text;
                    txtBrand.Text = "";
                    varBrand = "0";
                    //txtGroup.Focus();
                    lvSubGroup.Visible = false;
                    DGV_FilterPurLocation.DataSource = null;
                    DGV_FilterPurLocation.Visible = false;
                    lvPurRack.Visible = false;
                    txtSubgroup.BackColor = Color.White;
                    if (varbatchenable == "72")
                    {
                        cmbBatchno.SelectedValue = 72;
                    }
                    else
                    {
                        cmbBatchno.SelectedValue = 73;
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
                lvSubGroup.Visible = false;
            }
        }
        public void udfnBrandAutocomplete()
        {
            try
            {
                if (txtBrand.Text != "")
                {
                    ListViewItem selectedItem = lvBrand.SelectedItems[0];
                    txtBrand.Text = selectedItem.SubItems[0].Text;
                    varBrand = selectedItem.SubItems[2].Text;
                    //lvBrand.Visible = false;
                    txtBrand.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                cmbUnit.Focus();
                lvBrand.Visible = false;
            }
        }

        private void LvPurRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnPurRackAutocomplete();
                    txtSalesLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSubGroup.Items.Count == 0 || txtSubgroup.Text == "")
                    {
                        txtSubgroup.Focus();
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
                    txtBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBrand_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvBrand.Items.Count == 0 || txtBrand.Text == "")
                    {
                        txtBrand.Focus();
                        lvBrand.Visible = false;
                    }
                    else
                    {
                        lvBrand.Focus();
                    }
                    if (lvBrand.Items.Count > 0)
                    {
                        lvBrand.Items[0].Selected = true;
                    }
                }
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

        private void TxtPurLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyPurLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterPurLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterPurLocation.Visible == false)
                {
                    if (txtPurRack.Enabled == true)
                    {
                        txtPurRack.Focus();
                    }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterPurLocation.Focus();
                }
                if (DGV_FilterPurLocation.CurrentCell == null && DGV_FilterPurLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterPurLocation.Focus();
                    int RowIndex = DGV_FilterPurLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterPurLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyPurLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyPurLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterPurLocation.CurrentCell = DGV_FilterPurLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtPurLocation.Text = DGV_FilterPurLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtPurLocation.Focus();
                            txtPurLocation.SelectionStart = txtPurLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterPurLocation.Rows.Count) DGV_FilterPurLocation.CurrentCell = DGV_FilterPurLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterPurLocation.Rows.Count))
                            {
                                txtPurLocation.Text = DGV_FilterPurLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtPurLocation.Focus();
                            txtPurLocation.SelectionStart = txtPurLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterPurLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyPurLocation = 1;
                                    udfnPurLocationAutocomplete();
                                    DGV_FilterPurLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtPurLocation.Focus();
                    //txtPurLocation.SelectionStart = txtPurLocation.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtPurRack.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvPurRack.Items.Count == 0 || txtPurRack.Text == "")
                    {
                        txtPurRack.Focus();
                        lvPurRack.Visible = false;
                    }
                    else
                    {
                        lvPurRack.Focus();
                    }
                    if (lvPurRack.Items.Count > 0)
                    {
                        lvPurRack.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtSalesLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeySalesLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSalesLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSalesLocation.Visible == false)
                {
                    txtSalesRack.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSalesLocation.Focus();
                }
                if (DGV_FilterSalesLocation.CurrentCell == null && DGV_FilterSalesLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSalesLocation.Focus();
                    int RowIndex = DGV_FilterSalesLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSalesLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySalesLocation = 1;
                    }
                    else
                    {
                        varUpDownKeySalesLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSalesLocation.CurrentCell = DGV_FilterSalesLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSalesLocation.Text = DGV_FilterSalesLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtSalesLocation.Focus();
                            txtSalesLocation.SelectionStart = txtSalesLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSalesLocation.Rows.Count) DGV_FilterSalesLocation.CurrentCell = DGV_FilterSalesLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSalesLocation.Rows.Count))
                            {
                                txtSalesLocation.Text = DGV_FilterSalesLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtSalesLocation.Focus();
                            txtSalesLocation.SelectionStart = txtSalesLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSalesLocation.Rows.Count > 0)
                                {
                                    varUpDownKeySalesLocation = 1;
                                    udfnSaleLocationAutocomplete();
                                    DGV_FilterSalesLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSalesLocation.Focus();
                    //txtSalesLocation.SelectionStart = txtSalesLocation.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtSalesRack.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSalesRack.Items.Count == 0 || txtSalesRack.Text == "")
                    {
                        txtSalesRack.Focus();
                        lvSalesRack.Visible = false;
                    }
                    else
                    {
                        lvSalesRack.Focus();
                    }
                    if (lvSalesRack.Items.Count > 0)
                    {
                        lvSalesRack.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBatchno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsncode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvHsnCode.Items.Count == 0 || txtHsncode.Text == "")
                    {
                        txtHsncode.Focus();
                        lvHsnCode.Visible = false;
                    }
                    else
                    {
                        lvHsnCode.Focus();
                    }
                    if (lvHsnCode.Items.Count > 0)
                    {
                        lvHsnCode.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    chkMrp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSalesRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSaleRackAutocomplete();
                    cmbBatchno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSalesRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                udfnSaleRackAutocomplete();
                cmbBatchno.Focus();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbShelflife_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbShelflife.Checked == true)
                {
                    cmbPeriod.Visible = true;
                    txtSelfLife.Visible = true;
                }
                else
                {
                    cmbPeriod.Visible = false;
                    txtSelfLife.Visible = false;

                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbShelflife_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //   txtDay.Focus();
                    if (cmbPeriod.Visible == true)
                    {
                        txtSelfLife.Focus();
                    }
                    else
                    {
                        if (pnlStatus.Enabled == true)
                        {
                            if (rbActive.Checked == true)
                            {
                                rbActive.Focus();
                            }
                            else
                            {
                                rbInactive.Focus();
                            }
                        }
                        else
                        {
                            txtPURHSNName.Focus();
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

        private void CbShelflife_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                cbShelflife.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbShelflife_Leave(object sender, EventArgs e)
        {
            try
            {
                cbShelflife.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelfLife_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (cmbPeriod.Visible == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        cmbPeriod.Focus();
                    }
                }


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelfLife_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                txtSelfLife.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelfLife_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSelfLife.Text == "")
                {
                    txtSelfLife.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductApproval.SetError(txtSelfLife, "Please enter shelf life");
                }
                else
                {
                    if (Convert.ToInt32(txtSelfLife.Text) == 0)
                    {
                        txtSelfLife.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductApproval.SetError(txtSelfLife, "Please enter valid shelf life");
                    }
                    else
                    {
                        txtSelfLife.BackColor = Color.White;
                        epProductApproval.Clear();
                    }
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelfLife_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPeriod_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                cmbPeriod.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInactive.Focus();
                        }
                    }
                    else
                    {
                        txtPURHSNName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPeriod_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPeriod_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbPeriod.SelectedValue) == "" || Convert.ToString(cmbPeriod.SelectedValue) == "-1")
                {
                    epProductApproval.SetError(cmbPeriod, "Please select shelflife");
                    cmbPeriod.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select shelflife", cmbPeriod, 5000);
                }
                else
                {
                    epProductApproval.Clear();
                    cmbPeriod.BackColor = Color.White;
                }
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

                if (Convert.ToString(cmbUnit.SelectedValue) == "-1")
                {
                    //txtUPPvalue.Text = "";
                }
                else
                {
                    //txtUPPvalue.Text = cmbUnit.Text;
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

        private void CmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPurLocation.Focus();
                }
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

        private void LvPurRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnPurRackAutocomplete();
                txtSalesLocation.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    udfnUpdate();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void LvSaleLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSaleLocationAutocomplete();
                    txtSalesRack.Focus();
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
            try
            {
                udfnLoadGrid(1);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                varPurEffectiveFromErr = 0;
                varSalesEffectiveFromErr = 0;
                SPDataService objDataService = new SPDataService();
                if (grdPurHSN.Rows.Count < 1)
                {
                    string varMessage = objDataService.udfnGetMessages(149);
                    objDataService.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                /*
                if (grdSalesHSN.Rows.Count < 1)
                {
                    string varMessage = objDataService.udfnGetMessages(149);
                    objDataService.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                */
                dtProductHSN.Rows.Clear();
                foreach (DataRow row in dtPurHSN.Rows)
                {
                    dtProductHSN.ImportRow(row);
                }
                foreach (DataRow row in dtSalesHSN.Rows)
                {
                    dtProductHSN.ImportRow(row);
                }
                if (grdPurHSN.Rows.Count > 0 || grdSalesHSN.Rows.Count > 0)
                {
                    udfnEffectiveDateValidation();
                }
                epProductApproval.Clear();
                if (varPurEffectiveFromErr == 0 && varSalesEffectiveFromErr == 0)
                {
                    udfnUpdate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEffectiveDateValidation()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 26;
                objMR_Master.ParaProduct_HSN = dtProductHSN;
                objDT = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            string result = objDT.Tables[0].Rows[0][0].ToString();
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "4")
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                varPurEffectiveFromErr = 1;
                                varSalesEffectiveFromErr = 1;
                            }
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
        private void BtnClose_Click_1(object sender, EventArgs e)
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

        private void Txtpicode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductEname.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductEname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductTname.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductTname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbProductCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                //lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                txtBrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBrand_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBrand.Text == "")
                {
                    txtBrand.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductApproval.SetError(txtBrand, "Please enter brand");
                }
                else 
                {
                    /*
                    // Check product brand is valid or not
                    string varId_Brand = "0";
                    DataSet objDsBrand = new DataSet();
                    SPDataService objDServ2 = new SPDataService();
                    objDsBrand = objDServ2.udfnBrandList(9, "", 0, Convert.ToInt32(varSubgroupCode), 0, txtBrand.Text.Trim(), 0);
                    objDServ2.CloseConnection();
                    if (objDsBrand != null)
                    {
                        if (objDsBrand.Tables.Count > 0)
                        {
                            if (objDsBrand.Tables[0].Rows.Count > 0)
                            {
                                varId_Brand = Convert.ToString(objDsBrand.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varBrand = Convert.ToString(varId_Brand);
                    if (varId_Brand == "0" || varId_Brand == "-1")
                    {
                        epProductApproval.SetError(txtBrand, "Please select valid brand");
                        txtBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpbrand.ShowAlways = true;
                        tpbrand.Show("Please select valid brand", txtBrand, 5000);
                    }
                    else
                    {
                        txtBrand.BackColor = Color.White;
                        epProductApproval.Clear();
                    }
                    */
                    txtBrand.BackColor = Color.White;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                txtPurLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPurLocation.Text == "")
                {
                    txtPurLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductApproval.SetError(txtPurLocation, "Please enter purchase location");
                    txtPurRack.Text = "";
                    varPurRackCode = "0";
                    txtPurRack.Text = "";
                }

                /* Check purchase location is valid or not*/
                else 
                {
                    /*
                    string varId_PurLocation = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(varComId), 0, 0, txtPurLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                    //  objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtPurLocation.Text.Trim(),0,0,0);
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
                    varPurLocationCode = Convert.ToString(varId_PurLocation);
                    if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                    {
                        epProductApproval.SetError(txtPurLocation, "Please select valid purchase stock location");
                        txtPurLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppurchaselocation.ShowAlways = true;
                        tppurchaselocation.Show("Please select valid purchase stock location", txtPurLocation, 5000);
                    }
                    else
                    {
                        txtPurLocation.BackColor = Color.White;
                        epProductApproval.Clear();
                    }
                    */
                    txtPurLocation.BackColor = Color.White;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurRack_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPurRack.BackColor = Color.LemonChiffon;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                //lvPurRack.Visible = false;
                lvSalesRack.Visible = false;
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvHsnCode.Visible = false;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtPurRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPurRack.Text == "")
                {
                    txtPurRack.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductApproval.SetError(txtPurRack, "Please enter rack");
                }
                else
                {
                    /*
                    string varId_PurRack = "0";
                    DataSet objDsPurRack = new DataSet();
                    SPDataService objDServ4 = new SPDataService();
                    objDsPurRack = objDServ4.udfnRackList(9, 0, 0, 0, 0, txtPurRack.Text.Trim(), 0, 0);
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
                    varPurRackCode = Convert.ToString(varId_PurRack);
                    if (varId_PurRack == "0" || varId_PurRack == "-1")
                    {
                        epProductApproval.SetError(txtPurRack, "Please select valid rack");
                        txtPurRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        //grdViewSupplierMapping.DataSource = null;
                        //dtViewSupplierMapping.Rows.Clear();
                    }
                    else
                    {
                        txtPurRack.BackColor = Color.White;
                        epProductApproval.Clear();
                    }
                    */
                    txtPurRack.BackColor = Color.White;
                }
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesLocation_Enter(object sender, EventArgs e)
        {

            try
            {
                txtSalesLocation.BackColor = Color.LemonChiffon;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                //lvSaleLocation.Visible = false;
                lvPurRack.Visible = false;
                lvSalesRack.Visible = false;
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvHsnCode.Visible = false;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesRack_Enter(object sender, EventArgs e)
        {

            try
            {
                txtSalesRack.BackColor = Color.LemonChiffon;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvPurRack.Visible = false;
                //lvSalesRack.Visible = false;
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvHsnCode.Visible = false;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchno_Enter(object sender, EventArgs e)
        {

            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                cmbBatchno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbBatchno.SelectedValue) == "" || Convert.ToString(cmbBatchno.SelectedValue) == "-1")
                {
                    epProductApproval.SetError(cmbBatchno, "Please select Batch No.");
                    cmbBatchno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales Batch No.", cmbBatchno, 5000);
                }
                else
                {
                    epProductApproval.Clear();
                    cmbBatchno.BackColor = Color.White;
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbBatchno.Select(int.MaxValue, 0)));
                if (Convert.ToString(cmbBatchno.SelectedValue) == "72")
                {
                    cmbBatchGen.Enabled = true;
                }
                else
                {
                    cmbBatchGen.SelectedValue = -1;
                    cmbBatchGen.Enabled = false;
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGst_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                cmbGst.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGst_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbGst.SelectedValue) == "" || Convert.ToString(cmbGst.SelectedValue) == "-1")
                {
                    epProductApproval.SetError(cmbGst, "Please select GST%");
                    cmbGst.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpgst.ShowAlways = true;
                    tpgst.Show("Please select GST%", cmbProductCategory, 5000);
                }
                else
                {
                    epProductApproval.Clear();
                    cmbGst.BackColor = Color.White;
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsncode_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                //lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                txtHsncode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsncode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtHsncode.Text == "")
                {
                    epProductApproval.SetError(txtHsncode, "Please enter HSN Code");
                    txtHsncode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpHsnCode.ShowAlways = true;
                    tpHsnCode.Show("Please enter HSN Code", txtHsncode, 5000);
                }
                else
                {
                    /* Check product HSN is valid or not*/
                    string varId_HSN = "0";
                    DataSet objDsHSN = new DataSet();
                    SPDataService objDs = new SPDataService();
                    objDsHSN = objDs.udfnHsnList(12, 0, Convert.ToInt32(cmbGst.SelectedValue), 0, "", txtHsncode.Text.Trim());
                    objDs.CloseConnection();
                    if (objDsHSN != null)
                    {
                        if (objDsHSN.Tables.Count > 0)
                        {
                            if (objDsHSN.Tables[0].Rows.Count > 0)
                            {
                                varId_HSN = Convert.ToString(objDsHSN.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varHsnCode = Convert.ToString(varId_HSN);
                    if (Convert.ToString(varHsnCode) == "" || Convert.ToString(varHsnCode) == "0" || Convert.ToString(varHsnCode) == "-1")
                    {
                        epProductApproval.SetError(txtHsncode, "Please enter valid HSN code");
                        txtHsncode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpHsnCode.ShowAlways = true;
                        tpHsnCode.Show("Please enter valid HSN code", txtHsncode, 5000);
                        txtHsnname.Text = "";
                    }
                    else
                    {
                        epProductApproval.Clear();
                        txtHsncode.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                rbActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                rbInactive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUpdate_Enter(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.BackColor = Color.LemonChiffon;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvPurRack.Visible = false;
                lvSalesRack.Visible = false;
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvHsnCode.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUpdate_Leave(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.BackColor = Color.Transparent;
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
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvPurRack.Visible = false;
                lvSalesRack.Visible = false;
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvHsnCode.Visible = false;
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

        private void CmbUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                cmbUnit.BackColor = Color.LemonChiffon;
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

        private void CmbBatchno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(cmbBatchGen.Enabled==true)
                    {
                        cmbBatchGen.Focus();
                    }
                    else
                    {
                        chkMrp.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesLocation.Text == "")
                {
                    txtSalesLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductApproval.SetError(txtSalesLocation, "Please enter sales location");
                }
                else
                {
                    /*
                    string varId_SalesLocation = "0";
                    DataSet objDsSalesLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsSalesLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(varComId), 0, 0, txtSalesLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                    objDServ3.CloseConnection();
                    if (objDsSalesLoc != null)
                    {
                        if (objDsSalesLoc.Tables.Count > 0)
                        {
                            if (objDsSalesLoc.Tables[0].Rows.Count > 0)
                            {
                                varId_SalesLocation = Convert.ToString(objDsSalesLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varSalesLocationCode = Convert.ToString(varId_SalesLocation);
                    if (varId_SalesLocation == "0" || varId_SalesLocation == "-1")
                    {
                        epProductApproval.SetError(txtSalesLocation, "Please select valid sales stock location");
                        txtSalesLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSalelocation.ShowAlways = true;
                        tpSalelocation.Show("Please select valid sales stock location", txtSalesLocation, 5000);
                    }
                    else
                    {
                        txtSalesLocation.BackColor = Color.White;
                        epProductApproval.Clear();
                    }
                    */
                    txtSalesLocation.BackColor = Color.White;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesRack.Text == "")
                {
                    txtSalesRack.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductApproval.SetError(txtSalesRack, "Please enter sales rack");
                }
                else 
                {
                    /*
                    string varId_PurRack = "0";
                    DataSet objDsPurRack = new DataSet();
                    SPDataService objDServ4 = new SPDataService();
                    objDsPurRack = objDServ4.udfnRackList(9, 0, 0, 0, 0, txtSalesRack.Text.Trim(), 0, 0);
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
                    varSalesRackCode = Convert.ToString(varId_PurRack);
                    if (varId_PurRack == "0" || varId_PurRack == "-1")
                    {
                        epProductApproval.SetError(txtSalesRack, "Please select valid rack");
                        txtSalesRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        //grdViewSupplierMapping.DataSource = null;
                        //dtViewSupplierMapping.Rows.Clear();
                    }
                    else
                    {
                        txtSalesRack.BackColor = Color.White;
                        epProductApproval.Clear();
                    }
                    */
                    txtSalesRack.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGst_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtHsncode.Enabled == true)
                    {
                        txtHsncode.Focus();
                    }
                    else
                    {
                        if (pnlStatus.Enabled == true)
                        {
                            if (rbActive.Checked == true)
                            {
                                rbActive.Focus();
                            }
                            else
                            {
                                rbInactive.Focus();
                            }
                        }
                        else
                        {
                            btnUpdate.Focus();
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

        private void CmbGst_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbBatchno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void RbInactive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPURHSNName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPURHSNName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvPurRack.Visible = false;
                lvSalesRack.Visible = false;
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvHsnCode.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSubgroup_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvPurRack.Visible = false;
                lvSalesRack.Visible = false;
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvHsnCode.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvPurRack.Visible = false;
                lvSalesRack.Visible = false;
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvHsnCode.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PnlStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvPurRack.Visible = false;
                lvSalesRack.Visible = false;
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvHsnCode.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBrand_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdBrand.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSubgroup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdSubgroup.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbGst.Select(int.MaxValue, 0)));
                if (txtHsnname.Text != "")
                {
                    string varId_HSN = "0"; string varId_HSNGST = "0";
                    DataSet objDsHSN = new DataSet();
                    DataSet objDsHSNGst = new DataSet();
                    SPDataService objDs = new SPDataService();
                    objDsHSN = objDs.udfnHsnList(7, 0, 0, 0, txtHsnname.Text.Trim(), "");
                    objDsHSNGst = objDs.udfnHsnList(8, 0, Convert.ToInt32(cmbGst.SelectedValue), 0, "", "");
                    objDs.CloseConnection();
                    if (objDsHSN != null)
                    {
                        if (objDsHSN.Tables.Count > 0)
                        {
                            if (objDsHSN.Tables[0].Rows.Count > 0)
                            {
                                varId_HSN = Convert.ToString(objDsHSN.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (objDsHSNGst != null)
                    {
                        if (objDsHSNGst.Tables.Count > 0)
                        {
                            if (objDsHSNGst.Tables[0].Rows.Count > 0)
                            {
                                varId_HSNGST = Convert.ToString(objDsHSNGst.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (varId_HSN != varId_HSNGST)
                    {
                        txtHsnname.Text = "";
                        txtHsncode.Text = "";
                    }

                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_ProductApproval_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    lvBrand.Visible = false;
                    DGV_FilterSalesLocation.DataSource = null;
                    DGV_FilterSalesLocation.Visible = false;
                    lvPurRack.Visible = false;
                    DGV_FilterPurLocation.DataSource = null;
                    DGV_FilterPurLocation.Visible = false;
                    lvHsnCode.Visible = false;
                    lvSubGroup.Visible = false;
                    lvSalesRack.Visible = false;
                    udfntooltiphide();
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    udfnUpdate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdCategory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdCategory.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchGen_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                cmbBatchGen.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchGen_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBatchGen.BackColor = Color.White;
                epProductApproval.Clear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchGen_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbBatchGen_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    chkMrp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkMrp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        cbShelflife.Focus();
                    }
                    //if (pnlStatus.Enabled == true)
                    //{
                    //    if (rbActive.Checked == true)
                    //    {
                    //        rbActive.Focus();
                    //    }
                    //    else
                    //    {
                    //        rbInactive.Focus();
                    //    }
                    //}
                    //else
                    //{
                    //    btnUpdate.Focus();
                    //}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkMrp_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                chkMrp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkMrp_Leave(object sender, EventArgs e)
        {
            try
            {
                chkMrp.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsnname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvHsnCode.Items.Count == 0 || txtHsnname.Text == "")
                    {
                        txtHsnname.Focus();
                        lvHsnCode.Visible = false;
                    }
                    else
                    {
                        lvHsnCode.Focus();
                    }
                    if (lvHsnCode.Items.Count > 0)
                    {
                        lvHsnCode.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnUpdate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsnname_Enter(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Visible = false;
                //lvHsnCode.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                lvSubGroup.Visible = false;
                txtHsnname.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsnname_Leave(object sender, EventArgs e)
        {
            try
            {
                txtHsnname.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                udfnLoadGrid(2);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                udfnLoadGrid(3);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPURHSNName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPURHSNName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPURHSNName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPURHSNName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesHSNName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSalesHSNName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesHSNName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalesHSNName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPURHSNName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvPURHSNCode.Items.Count == 0 || txtPURHSNName.Text == "")
                    {
                        txtPURHSNName.Focus();
                        lvPURHSNCode.Visible = false;
                    }
                    else
                    {
                        lvPURHSNCode.Focus();
                    }
                    if (lvPURHSNCode.Items.Count > 0)
                    {
                        lvPURHSNCode.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    dpPurEffectiveFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesHSNName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSalesHSNCode.Items.Count == 0 || txtSalesHSNName.Text == "")
                    {
                        txtSalesHSNName.Focus();
                        lvSalesHSNCode.Visible = false;
                    }
                    else
                    {
                        lvSalesHSNCode.Focus();
                    }
                    if (lvSalesHSNCode.Items.Count > 0)
                    {
                        lvSalesHSNCode.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    dpSalesEffectiveFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpPurEffectiveFrom_Enter(object sender, EventArgs e)
        {
            try
            {
                lvPURHSNCode.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpSalesEffectiveFrom_Enter(object sender, EventArgs e)
        {
            try
            {
                lvSalesHSNCode.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesHSNName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                varSalesHSNID = 0;
                lvSalesHSNCode.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSalesHSNName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnHsnList(6, 0, 0, 0, txtSalesHSNName.Text.Trim(), "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["HSN_Name"].ToString(), objDs.Tables[0].Rows[i]["HSN_Code"].ToString(), objDs.Tables[0].Rows[i]["HSNID"].ToString(), objDs.Tables[0].Rows[i]["HSN_GSTID"].ToString(), objDs.Tables[0].Rows[i]["GST_Text"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSalesHSNCode.Items.Add(objList);
                                }
                                lvSalesHSNCode.Visible = true;
                                lvSalesHSNCode.BringToFront();
                                lvSalesHSNCode.Columns[0].Width = 180;
                                lvSalesHSNCode.Columns[1].Width = 100;
                                lvSalesHSNCode.Columns[2].Width = 0;
                                lvSalesHSNCode.Columns[3].Width = 0;
                                lvSalesHSNCode.Columns[4].Width = 0;
                            }
                        }
                    }
                }
                else
                {
                    lvSalesHSNCode.Visible = false;
                    lvSalesHSNCode.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPURHSNName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                varPurHSNID = 0;
                lvPURHSNCode.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtPURHSNName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnHsnList(6, 0, 0, 0, txtPURHSNName.Text.Trim(), "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["HSN_Name"].ToString(), objDs.Tables[0].Rows[i]["HSN_Code"].ToString(), objDs.Tables[0].Rows[i]["HSNID"].ToString(), objDs.Tables[0].Rows[i]["HSN_GSTID"].ToString(), objDs.Tables[0].Rows[i]["GST_Text"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvPURHSNCode.Items.Add(objList);
                                }
                                lvPURHSNCode.Visible = true;
                                lvPURHSNCode.BringToFront();
                                lvPURHSNCode.Columns[0].Width = 180;
                                lvPURHSNCode.Columns[1].Width = 100;
                                lvPURHSNCode.Columns[2].Width = 0;
                                lvPURHSNCode.Columns[3].Width = 0;
                                lvPURHSNCode.Columns[4].Width = 0;
                            }
                        }
                    }
                }
                else
                {
                    lvPURHSNCode.Visible = false;
                    lvPURHSNCode.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvPURHSNCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnPURHSNAutocomplete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPURHSNAutocomplete()
        {
            try
            {
                if (txtPURHSNName.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvPURHSNCode.SelectedItems[0];
                    varPurHSNCode = selectedItem.SubItems[1].Text;
                    varPurGST = selectedItem.SubItems[4].Text;
                    txtPURHSNName.Text = selectedItem.SubItems[0].Text;
                    varPurHSNID = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    dpPurEffectiveFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvPURHSNCode.Visible = false;
            }
        }
        private void LvPURHSNCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnPURHSNAutocomplete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSalesHSNCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSalesHSNAutocomplete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSalesHSNAutocomplete()
        {
            try
            {
                if (txtSalesHSNName.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvSalesHSNCode.SelectedItems[0];
                    varSalesHSNCode = selectedItem.SubItems[1].Text;
                    varSalesGST = selectedItem.SubItems[4].Text;
                    txtSalesHSNName.Text = selectedItem.SubItems[0].Text;
                    varSalesHSNID = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    dpSalesEffectiveFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSalesHSNCode.Visible = false;
            }
        }
        private void LvSalesHSNCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSalesHSNAutocomplete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurHSN_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                udfnPurHideRemove();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnPurHideRemove()
        {
            try
            {
                for (int i = 0; i < grdPurHSN.Rows.Count; i++)
                {
                    var addFlag = Convert.ToString(grdPurHSN.Rows[i].Cells["clmPurAddFlag"].Value);
                    var editFlag = Convert.ToString(grdPurHSN.Rows[i].Cells["clmPurEditFlag"].Value);
                    var removeCell = grdPurHSN.Rows[i].Cells["clmPurRemove"];

                    if (addFlag == "0" && editFlag == "0")
                    {
                        removeCell.Value = global::ROMS.Properties.Resources.remove;
                        removeCell.ReadOnly = false;
                    }
                    else
                    {
                        removeCell.Value = new Bitmap(1, 1);
                        removeCell.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdPurHSN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPurHSN.Columns[e.ColumnIndex].Name)
                    {
                        case "clmPurRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                int varProductID = Convert.ToInt32(grdPurHSN.CurrentRow.Cells["clmPurHSNID"].Value);
                                string varEffectiveFrom = Convert.ToString(grdPurHSN.CurrentRow.Cells["clmPurEffectiveFrom"].Value);

                                var rowsToDelete = dtPurHSN.AsEnumerable().Where(row => row.Field<int>("HSNID") == varProductID && row.Field<string>("HSN_EffectiveFrom") == varEffectiveFrom).ToList();
                                foreach (var row in rowsToDelete)
                                {
                                    dtPurHSN.Rows.Remove(row);
                                }
                                grdPurHSN.Rows.RemoveAt(this.grdPurHSN.CurrentRow.Index);
                                udfnUpdateRemovableFlags();
                                udfnPurHideRemove();
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

        private void GrdSalesHSN_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                udfnSalesHideRemove();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterPurLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyPurLocation = 1;
                udfnPurLocationAutocomplete();
                if (txtPurRack.Enabled == true)
                {
                    txtPurRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterPurLocation_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterPurLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterPurLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyPurLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyPurLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterPurLocation.CurrentCell = DGV_FilterPurLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtPurLocation.Text = DGV_FilterPurLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtPurLocation.Focus();
                            txtPurLocation.SelectionStart = txtPurLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterPurLocation.Rows.Count) DGV_FilterPurLocation.CurrentCell = DGV_FilterPurLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterPurLocation.Rows.Count))
                            {
                                txtPurLocation.Text = DGV_FilterPurLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtPurLocation.Focus();
                            txtPurLocation.SelectionStart = txtPurLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterPurLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyPurLocation = 1;
                                    udfnPurLocationAutocomplete();
                                    DGV_FilterPurLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtPurRack.Enabled == true)
                        {
                            txtPurRack.Focus();
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

        private void DGV_FilterSalesLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySalesLocation = 1;
                udfnSaleLocationAutocomplete();
                if (txtSalesRack.Enabled == true)
                {
                    txtSalesRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterSalesLocation_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterSalesLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSalesLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySalesLocation = 1;
                    }
                    else
                    {
                        varUpDownKeySalesLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSalesLocation.CurrentCell = DGV_FilterSalesLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtSalesLocation.Text = DGV_FilterSalesLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtSalesLocation.Focus();
                            txtSalesLocation.SelectionStart = txtSalesLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSalesLocation.Rows.Count) DGV_FilterSalesLocation.CurrentCell = DGV_FilterSalesLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSalesLocation.Rows.Count))
                            {
                                txtSalesLocation.Text = DGV_FilterSalesLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtSalesLocation.Focus();
                            txtSalesLocation.SelectionStart = txtSalesLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSalesLocation.Rows.Count > 0)
                                {
                                    varUpDownKeySalesLocation = 1;
                                    udfnSaleLocationAutocomplete();
                                    DGV_FilterSalesLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtSalesRack.Enabled == true)
                        {
                            txtSalesRack.Focus();
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

        private void udfnSalesHideRemove()
        {
            try
            {
                for (int i = 0; i < grdSalesHSN.Rows.Count; i++)
                {
                    var addFlag = Convert.ToString(grdSalesHSN.Rows[i].Cells["clmSalesAddFlag"].Value);
                    var editFlag = Convert.ToString(grdSalesHSN.Rows[i].Cells["clmSalesEditFlag"].Value);
                    var removeCell = grdSalesHSN.Rows[i].Cells["clmSalesRemove"];

                    if (addFlag == "0" && editFlag == "0")
                    {
                        removeCell.Value = global::ROMS.Properties.Resources.remove;
                        removeCell.ReadOnly = false;
                    }
                    else
                    {
                        removeCell.Value = new Bitmap(1, 1);
                        removeCell.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnUpdateRemovableFlags()
        {
            try
            {
                foreach (DataGridViewRow row in grdPurHSN.Rows)
                {
                    row.Cells["clmPurAddFlag"].Value = "1";
                }
                if (grdPurHSN.Rows.Count > 0)
                {
                    var lastRow = grdPurHSN.Rows[grdPurHSN.Rows.Count - 1];
                    lastRow.Cells["clmPurAddFlag"].Value = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdSalesHSN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdSalesHSN.Columns[e.ColumnIndex].Name)
                    {
                        case "clmSalesRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                int varProductID = Convert.ToInt32(grdSalesHSN.CurrentRow.Cells["clmSalesHSNID"].Value);
                                string varEffectiveFrom = Convert.ToString(grdSalesHSN.CurrentRow.Cells["clmSalesEffectiveFrom"].Value);

                                var rowsToDelete = dtSalesHSN.AsEnumerable().Where(row => row.Field<int>("HSNID") == varProductID && row.Field<string>("HSN_EffectiveFrom") == varEffectiveFrom).ToList();
                                foreach (var row in rowsToDelete)
                                {
                                    dtSalesHSN.Rows.Remove(row);
                                }
                                grdSalesHSN.Rows.RemoveAt(this.grdSalesHSN.CurrentRow.Index);
                                udfnUpdateSalesRemovableFlags();
                                udfnSalesHideRemove();
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
        private void udfnUpdateSalesRemovableFlags()
        {
            try
            {
                foreach (DataGridViewRow row in grdSalesHSN.Rows)
                {
                    row.Cells["clmSalesAddFlag"].Value = "1";
                }
                if (grdSalesHSN.Rows.Count > 0)
                {
                    var lastRow = grdSalesHSN.Rows[grdSalesHSN.Rows.Count - 1];
                    lastRow.Cells["clmSalesAddFlag"].Value = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpPurEffectiveFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnPURHSN.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpSalesEffectiveFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSalesHSN.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPURHSN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPURHSNName.Text.Trim() == "")
                {
                    epProductApproval.SetError(txtPURHSNName, "Please enter purchase hsn name.");
                    txtPURHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPurHSN.ShowAlways = true;
                    tpPurHSN.Show("Please enter purchase hsn name.", txtPURHSNName, 5000);
                    return;
                }
                else
                {
                    if (varPurHSNID == 0)
                    {
                        epProductApproval.SetError(txtPURHSNName, "Please enter valid purchase hsn name.");
                        txtPURHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpPurHSN.ShowAlways = true;
                        tpPurHSN.Show("Please enter valid purchase hsn name.", txtPURHSNName, 5000);
                        return;
                    }
                }
                varPurEffectiveFromErr = 0;
                udfnPurMinDateValidation();
                epProductApproval.Clear();
                if (varPurEffectiveFromErr == 0)
                {
                    foreach (DataGridViewRow row in grdPurHSN.Rows)
                    {
                        row.Cells["clmPurAddFlag"].Value = 1;
                    }
                    grdPurHSN.Rows.Add(txtPURHSNName.Text.Trim(), varPurHSNCode, varPurGST, dpPurEffectiveFrom.Text, "", varPurHSNID, 0, 0);
                    dtPurHSN.Rows.Add(1, varPurHSNID, dpPurEffectiveFrom.Text, "");
                    grdPurHSN.Columns["clmPurGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdPurHSN.ClearSelection();
                    udfnPurHideRemove();
                    txtPURHSNName.Text = "";
                    varPurHSNCode = "";
                    varPurGST = "";
                    varPurHSNID = 0;
                    txtPURHSNName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurMinDateValidation()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 26;
                objMR_Master.ParaProduct_HSN = dtPurHSN;
                objMR_Master.paraDate = dpPurEffectiveFrom.Text;
                objDT = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            string result = objDT.Tables[0].Rows[0][0].ToString();
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "4")
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                varPurEffectiveFromErr = 1;
                            }
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
        
        private void BtnSalesHSN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesHSNName.Text.Trim() == "")
                {
                    epProductApproval.SetError(txtSalesHSNName, "Please enter sales hsn name.");
                    txtSalesHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSalesHSN.ShowAlways = true;
                    tpSalesHSN.Show("Please enter sales hsn name.", txtSalesHSNName, 5000);
                    return;
                }
                else
                {
                    if (varSalesHSNID == 0)
                    {
                        epProductApproval.SetError(txtSalesHSNName, "Please enter valid sales hsn name.");
                        txtSalesHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSalesHSN.ShowAlways = true;
                        tpSalesHSN.Show("Please enter valid sales hsn name.", txtSalesHSNName, 5000);
                        return;
                    }
                }
                varSalesEffectiveFromErr = 0;
                udfnSalesMinDateValidation();
                epProductApproval.Clear();
                if (varSalesEffectiveFromErr == 0)
                {
                    foreach (DataGridViewRow row in grdSalesHSN.Rows)
                    {
                        row.Cells["clmSalesAddFlag"].Value = 1;
                    }
                    grdSalesHSN.Rows.Add(txtSalesHSNName.Text.Trim(), varSalesHSNCode, varSalesGST, dpSalesEffectiveFrom.Text, "", varSalesHSNID, 0, 0);
                    dtSalesHSN.Rows.Add(2, varSalesHSNID, dpSalesEffectiveFrom.Text, "");
                    grdSalesHSN.Columns["clmSalesGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdSalesHSN.ClearSelection();
                    udfnSalesHideRemove();
                    txtSalesHSNName.Text = "";
                    varSalesHSNCode = "";
                    varSalesGST = "";
                    varSalesHSNID = 0;
                    txtSalesHSNName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSalesMinDateValidation()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 26;
                objMR_Master.ParaProduct_HSN = dtSalesHSN;
                objMR_Master.paraDate = dpSalesEffectiveFrom.Text;
                objDT = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            string result = objDT.Tables[0].Rows[0][0].ToString();
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "4")
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                varSalesEffectiveFromErr = 1;
                            }
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
        
        private void TxtHsncode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvHsnCode.Items.Clear();
                //txtHsnname.Text = "";
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtHsncode.Text.Length > 0)
                {
                    objDs = objspdservice.udfnHsnList(6, 0, Convert.ToInt32(cmbGst.SelectedValue), 0, txtHsncode.Text.Trim(), "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["HSN_Code"].ToString(), objDs.Tables[0].Rows[i]["HSN_Name"].ToString(), objDs.Tables[0].Rows[i]["HSNID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvHsnCode.Items.Add(objList);
                                    lvHsnCode.Columns[0].Width = 90;
                                    lvHsnCode.Columns[1].Width = 160;
                                    lvHsnCode.Columns[2].Width = 0;
                                }
                                lvHsnCode.Visible = true;
                                lvHsnCode.BringToFront();
                            }
                        }
                    }
                }
                else
                {
                    lvHsnCode.Visible = false;
                    lvHsnCode.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvHsnCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnHSNAutocomplete();
                    if (pnlStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInactive.Focus();
                        }
                    }
                    else
                    {
                        btnUpdate.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvHsnCode_DoubleClick(object sender, EventArgs e)
        {
            try { udfnHSNAutocomplete(); }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsnname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvHsnCode.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtHsnname.Text.Length > 0)
                {
                    objDs = objspdservice.udfnHsnList(6, 0, 0, 0, txtHsnname.Text.Trim(), "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["HSN_Name"].ToString(), objDs.Tables[0].Rows[i]["HSN_Code"].ToString(), objDs.Tables[0].Rows[i]["HSNID"].ToString(), objDs.Tables[0].Rows[i]["HSN_GSTID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvHsnCode.Items.Add(objList);
                                }
                                lvHsnCode.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvHsnCode.Visible = false;
                    lvHsnCode.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnHSNAutocomplete()
        {
            try
            {
                if (txtHsnname.Text != "")
                {
                    ListViewItem selectedItem = lvHsnCode.SelectedItems[0];
                    cmbGst.SelectedValue = Convert.ToInt32(selectedItem.SubItems[3].Text);
                    txtHsncode.Text = selectedItem.SubItems[1].Text;
                    varHsnCode = selectedItem.SubItems[2].Text;
                    txtHsnname.Text = selectedItem.SubItems[0].Text;
                    btnUpdate.Focus();
                    //txtHsncode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvHsnCode.Visible = false;
            }
        }

        private void LvSaleLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSaleLocationAutocomplete();
                txtSalesRack.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnPurLocationAutocomplete()
        {
            try
            {
                if (txtPurLocation.Text != "")
                {
                    varPurLocationCode = DGV_FilterPurLocation.SelectedRows[0].Cells["SLID"].Value.ToString();
                    txtPurLocation.Text = DGV_FilterPurLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                    txtPurRack.Text = "";
                    varPurRackCode = "0";
                    //txtRackDescription.Text = "";
                    txtPurLocation.BackColor = Color.White;
                    udfnPLocationWiseRack();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPLocationWiseRack()
        {
            try
            {
                /*check location have a rack or not*/
                string varId_PurchaseRack = "0";
                DataSet objDsPurchaseRack = new DataSet();
                SPDataService objDServ6 = new SPDataService();
                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varPurLocationCode), 0, txtPurRack.Text.Trim(), 0, 0);
                objDServ6.CloseConnection();
                if (txtPurRack.Text.Trim() != "")
                {
                    if (varPurLocationCode != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        varPurRackCode = Convert.ToString(varId_PurchaseRack);
                        if (varId_PurchaseRack == "0" || varId_PurchaseRack == "-1")
                        {
                            epProductApproval.SetError(txtPurRack, "Please select valid purchase rack");
                            txtPurRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tppurchaserack.ShowAlways = true;
                            tppurchaserack.Show("Please select valid purchase rack", txtPurRack, 5000);
                        }
                    }
                }
                else
                {
                    if (varPurLocationCode != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                }
                            }
                        }
                        //lblPurRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (varId_PurchaseRack == "0")
                        {
                            txtPurRack.Text = "None";
                            txtPurRack.BackColor = Color.White;
                            txtPurRack.Enabled = false;
                            txtSalesLocation.Focus();
                        }
                        else
                        {
                            txtPurRack.Text = "";
                            txtPurRack.BackColor = Color.LemonChiffon;
                            txtPurRack.Enabled = true;
                            txtPurRack.Focus();
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
        public void udfnPurRackAutocomplete()
        {
            try
            {
                if (txtPurRack.Text != "")
                {
                    ListViewItem selectedItem = lvPurRack.SelectedItems[0];
                    txtPurRack.Text = selectedItem.SubItems[0].Text;
                    varPurRackCode = selectedItem.SubItems[2].Text;
                    //txtRackDescription.Text = selectedItem.SubItems[1].Text;
                    lvPurRack.Visible = false;
                    txtPurRack.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvPurRack.Visible = false;
            }
        }

        public void udfnSaleLocationAutocomplete()
        {
            try
            {
                if (txtSalesLocation.Text != "")
                {
                    varSalesLocationCode = DGV_FilterSalesLocation.SelectedRows[0].Cells["SLID"].Value.ToString();
                    txtSalesLocation.Text = DGV_FilterSalesLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                    txtSalesRack.Text = "";
                    //txtRackDescriptionSales.Text = "";
                    varSalesRackCode = "0";
                    txtSalesLocation.BackColor = Color.White;
                    udfnSLocationWiseRack();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSLocationWiseRack()
        {
            try
            {
                /*check location have a rack or not*/
                string varId_PurchaseRack = "0";
                DataSet objDsPurchaseRack = new DataSet();
                SPDataService objDServ6 = new SPDataService();
                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varSalesLocationCode), 0, txtSalesRack.Text.Trim(), 0, 0);
                objDServ6.CloseConnection();
                if (txtSalesRack.Text.Trim() != "")
                {
                    if (varSalesLocationCode != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        varSalesLocationCode = Convert.ToString(varId_PurchaseRack);
                        if (varId_PurchaseRack == "0" || varId_PurchaseRack == "-1")
                        {
                            epProductApproval.SetError(txtSalesRack, "Please select valid sales rack");
                            txtSalesRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpsalesrack.ShowAlways = true;
                            tpsalesrack.Show("Please select valid sales rack", txtSalesRack, 5000);
                        }
                    }
                }
                else
                {
                    if (varSalesLocationCode != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                }
                            }
                        }
                        //lblPurRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (varId_PurchaseRack == "0")
                        {
                            txtSalesRack.Text = "None";
                            txtSalesRack.BackColor = Color.White;
                            txtSalesRack.Enabled = false;
                            cmbBatchno.Focus();
                        }
                        else
                        {
                            txtSalesRack.Text = "";
                            txtSalesRack.BackColor = Color.LemonChiffon;
                            txtSalesRack.Enabled = true;
                            txtSalesRack.Focus();
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
        public void udfnSaleRackAutocomplete()
        {
            try
            {
                if (txtSalesRack.Text != "")
                {
                    ListViewItem selectedItem = lvSalesRack.SelectedItems[0];
                    txtSalesRack.Text = selectedItem.SubItems[0].Text;
                    varSalesRackCode = selectedItem.SubItems[2].Text;
                    //txtRackDescriptionSales.Text = selectedItem.SubItems[1].Text;
                    lvSalesRack.Visible = false;
                    txtSalesRack.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvPurRack.Visible = false;
            }
        }
        private void TxtBrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSubgroup.Text != "")
                {
                    if (txtBrand.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnBrandList(6, "0", 0, Convert.ToInt32(varSubgroupCode), 0, txtBrand.Text.Trim(), 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["BD_EName"].ToString(), objDs.Tables[0].Rows[i]["BD_TName"].ToString(), objDs.Tables[0].Rows[i]["BDID"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        objList.UseItemStyleForSubItems = false;
                                        objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        lvBrand.Items.Add(objList);
                                    }
                                    lvBrand.Visible = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        lvBrand.Visible = false;
                        lvBrand.Items.Clear();
                    }
                }
                else
                {
                    //if (txtGroup.Text == "")
                    //{
                    //    lvGroup.Items.Clear();
                    //    lvGroup.Visible = false;
                    //    txtGroup.Text = "";
                    //    lblGroupCode.Text = "0";
                    //    txtGroup.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    //    errItems.SetError(txtSubGroup, "Please select subgroup");
                    //    txtBrand.Text = "";
                    //    lblBrand.Text = "0";
                    //}
                    ////else
                    ////{
                    ////    txtSubGroup.BackColor = Color.White;
                    ////    errItems.Clear();
                    ////}
                    //if (txtSubGroup.Text == "")
                    //{
                    //    txtSubGroup.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    //    errItems.SetError(txtSubGroup, "Please select subgroup");
                    //    lvSubGroup.Items.Clear();
                    //    lvSubGroup.Visible = false;
                    //    txtSubGroup.Text = "";
                    //    lblSubGroupCode.Text = "0";
                    //    txtBrand.Text = "";
                    //    lblBrand.Text = "0";
                    //}
                    //else
                    //{
                    //    txtSubGroup.BackColor = Color.White;
                    //    errItems.Clear();
                    //}
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
        public void udfnEdit()
        {
            try
            {
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                if (varproductcode != 0)
                {
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 1;
                    objMR_Product.ParaProductCode = varproductcode;
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    DataService objdservice = new DataService();
                    objDS = objdserv.udfnproductmasterlist(objMR_Product);
                    objdserv.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varComId = Convert.ToInt32(objDS.Tables[0].Rows[0]["COMPANY"]);
                            //cmbConcern.Enabled = false;
                            txtpicode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["PICODE"].ToString().Replace("''", "'"));
                            txtProductEname.Text = Convert.ToString(objDS.Tables[0].Rows[0]["ENAME"].ToString().Replace("''", "'"));
                            txtProductTname.Text = Convert.ToString(objDS.Tables[0].Rows[0]["TNAME"].ToString().Replace("''", "'"));
                            cmbProductCategory.SelectedValue = objDS.Tables[0].Rows[0]["PRODUCTCATEGORY"].ToString();
                            varCategoryId = objDS.Tables[0].Rows[0]["PRODUCTCATEGORY"].ToString();
                            varSubgroupCode = objDS.Tables[0].Rows[0]["SUBGROUP"].ToString();
                            txtSubgroup.Text = objDS.Tables[0].Rows[0]["SubGroup Name"].ToString();
                            //CmbSubgroup_SelectedIndexChanged(cmbSubGroup, EventArgs.Empty);
                            varBrand = objDS.Tables[0].Rows[0]["BRAND"].ToString();
                            txtBrand.Text = objDS.Tables[0].Rows[0]["BRAND Name"].ToString();
                            cmbUnit.SelectedValue = objDS.Tables[0].Rows[0]["UNIT"].ToString();
                            varPurLocationCode = Convert.ToString(objDS.Tables[0].Rows[0]["LOCATION PURCHASE"]);
                            txtPurLocation.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LOCATION PURCHASE Name"]);
                            varSalesLocationCode = Convert.ToString(objDS.Tables[0].Rows[0]["LOCATION SALES"]);
                            txtSalesLocation.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LOCATION SALES Name"]);
                            varPurRackCode = objDS.Tables[0].Rows[0]["RACK LOCATION"].ToString();
                            txtPurRack.Text = objDS.Tables[0].Rows[0]["RACK LOCATION Name"].ToString();
                            varSalesRackCode = objDS.Tables[0].Rows[0]["RACK SALES"].ToString();
                            txtSalesRack.Text = objDS.Tables[0].Rows[0]["RACK SALES Name"].ToString();
                            cmbBatchno.SelectedValue = objDS.Tables[0].Rows[0]["BATCHNO"].ToString();
                            cmbBatchGen.SelectedValue = objDS.Tables[0].Rows[0]["BARCODE GENERATION"].ToString();
                            cmbPeriod.SelectedValue = objDS.Tables[0].Rows[0]["SHELF LIFE TYPE"].ToString();
                            txtSelfLife.Text = Convert.ToString(objDS.Tables[0].Rows[0]["SHELFLIFE VALUE"].ToString().Replace("''", "'"));
                            cmbGst.SelectedValue = objDS.Tables[0].Rows[0]["GSTID"].ToString();
                            varHsnCode = objDS.Tables[0].Rows[0]["HSN"].ToString();
                            txtHsnname.Text = Convert.ToString(objDS.Tables[0].Rows[0]["HSN_Name"].ToString().Replace("''", "'"));
                            txtHsncode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["HSN_Code"].ToString().Replace("''", "'"));
                            lvHsnCode.Visible = false;

                            if (Convert.ToString(objDS.Tables[0].Rows[0]["SHELFLIFE"]) == "1") { cbShelflife.Checked = true; } else { cbShelflife.Checked = false; }
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["PR_MRPflag"]) == "1") { chkMrp.Checked = true; } else { chkMrp.Checked = false; }
                            //if (Convert.ToString(objDS.Tables[0].Rows[0]["RM PRODUCTION"]) == "1") { cbRMFromProduction.Checked = true; } else { cbRMFromProduction.Checked = false; }
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "1") { rbActive.Checked = true; } else { rbInactive.Checked = true; }

                            //objDS = objdservice.GetDataset("SELECT HSN_Code,GST_Value FROM MR_HSN INNER JOIN DEF_GST ON HSN_GSTID=GSTID WHERE HSNID  IN ('" + Convert.ToInt32(objDS.Tables[0].Rows[0]["HSN"].ToString()) + "') AND GSTID  NOT IN (0,-1)");
                            //objdservice.CloseConnection();
                            //if (objDS != null)
                            //{
                            //    if (objDS.Tables.Count > 0)
                            //    {
                            //        if (objDS.Tables[0].Rows.Count > 0)
                            //        {
                            //            txtHSNCode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["HSN_Code"]);
                            //            txtGST.Text = Convert.ToString(objDS.Tables[0].Rows[0]["GST_Value"]);
                            //        }
                            //    }
                            //}

                            btnUpdate.Text = "Update";
                            pnlStatus.Enabled = true;
                        }
                        if (objDS.Tables[1] != null)
                        {
                            if (objDS.Tables.Count > 1 && objDS.Tables[1].Rows.Count > 0)
                            {
                                grdPurHSN.Rows.Clear();
                                grdSalesHSN.Rows.Clear();
                                dtPurHSN.Rows.Clear();
                                dtSalesHSN.Rows.Clear();
                                DataTable dtHSN = objDS.Tables[1];
                                foreach (DataRow dr in dtHSN.Rows)
                                {
                                    int varHsnType = Convert.ToInt32(dr["PRHSN_Type"]);
                                    string varHsnName = dr["HSN_Name"]?.ToString().Trim();
                                    string varHsnCode = dr["HSN_Code"]?.ToString().Trim();
                                    string varGstText = dr["GST_Text"]?.ToString().Trim();
                                    string varEffectiveFrom = dr["PRHSN_EffectiveFrom"]?.ToString().Trim();
                                    string varEffectiveTo = dr["PRHSN_EffectiveTo"]?.ToString().Trim();
                                    int varHSNID = Convert.ToInt32(dr["PRHSN_HSNID"]);
                                    int varAddFlag = Convert.ToInt32(dr["AddFlag"]);
                                    int varEditFlag = Convert.ToInt32(dr["EditFlag"]);
                                    string changedDate = DateTime.TryParse(dr["PRHSN_ChangedDate"]?.ToString(), out DateTime dt) ? dt.ToString("yyyy-MM-dd HH:mm:ss.fff") : string.Empty;
                                    int userID = Convert.ToInt32(dr["PRHSN_MakerID"]);

                                    // Add row to Purchase Grid (Type = 1)
                                    if (varHsnType == 1)
                                    {
                                        grdPurHSN.Rows.Add(varHsnName, varHsnCode, varGstText, varEffectiveFrom, varEffectiveTo, varHSNID, varAddFlag, varEditFlag, changedDate, userID);
                                        dtPurHSN.Rows.Add(1, varHSNID, varEffectiveFrom, varEffectiveTo, changedDate, userID);
                                    }
                                    // Add row to Sales Grid (Type = 2)
                                    else if (varHsnType == 2)
                                    {
                                        grdSalesHSN.Rows.Add(varHsnName, varHsnCode, varGstText, varEffectiveFrom, varEffectiveTo, varHSNID, varAddFlag, varEditFlag, changedDate, userID);
                                        dtSalesHSN.Rows.Add(2, varHSNID, varEffectiveFrom, varEffectiveTo, changedDate, userID);
                                    }
                                }
                                grdPurHSN.ClearSelection();
                                grdSalesHSN.ClearSelection();

                                grdPurHSN.Columns["clmPurGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSalesHSN.Columns["clmSalesGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                //Reset flag and Hide Remove Icon For Purchase HSN
                                udfnUpdateRemovableFlags();
                                udfnPurHideRemove();
                                //Reset flag and Hide Remove Icon For Sales HSN
                                udfnUpdateSalesRemovableFlags();
                                udfnSalesHideRemove();
                            }
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
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                //lvGroup.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSalesRack.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
            }
        }
        public void udfnUpdate()
        {
            try
            {
                bool blnErrorFlag = false;
                string result = "", varStatus = "";
                int varshelflife = 0, shelflife = 0, varMRPflag = 0;
                if (cbShelflife.Checked == true)
                {
                    varshelflife = 1;
                }
                else
                {
                    varshelflife = 0;
                }
                if (chkMrp.Checked == true)
                {
                    varMRPflag = 1;
                }
                else
                {
                    varMRPflag = 0;
                }
                if (txtSelfLife.Text == "")
                {
                    shelflife = 0;
                }
                else
                {
                    shelflife = Convert.ToInt32(txtSelfLife.Text);
                }
                if (rbActive.Checked == true)
                {
                    varStatus = "1";
                }
                else
                {
                    varStatus = "71";// If the status is set to Inactive multiple times, it will be marked as Pending instead

                }
                if (Convert.ToString(txtpicode.Text).Trim() == "")
                {
                    epProductApproval.SetError(txtpicode, "Please enter picode");
                    txtpicode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPicode.ShowAlways = true;
                    tpPicode.Show("Please enter picode", txtpicode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtProductEname.Text).Trim() == "")
                {
                    epProductApproval.SetError(txtProductEname, "Please enter product name in english");
                    txtProductEname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpengname.ShowAlways = true;
                    tpplno.Show("Please enter product name in english", txtProductEname, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtProductTname.Text).Trim() == "")
                {
                    epProductApproval.SetError(txtProductTname, "Please enter product name in tamil");
                    txtProductTname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tptamname.ShowAlways = true;
                    tptamname.Show("Please enter product name in tamil", txtProductTname, 5000);
                    blnErrorFlag = true;
                }
                if (txtBrand.Text == "")
                {
                    txtBrand.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductApproval.SetError(txtBrand, "Please select brand");
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbProductCategory.SelectedValue) == "" || Convert.ToString(cmbProductCategory.SelectedValue) == "-1")
                {
                    epProductApproval.SetError(cmbProductCategory, "Please select product category");
                    cmbProductCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpprd.ShowAlways = true;
                    tpprd.Show("Please select product category", cmbProductCategory, 5000);
                    blnErrorFlag = true;
                }
                if (txtPurLocation.Text == "")
                {
                    txtPurLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    tppurchaselocation.ShowAlways = true;
                    tppurchaselocation.Show("Please select valid purchase stock location", txtPurLocation, 5000);
                    txtPurRack.Text = "";
                    varPurRackCode = "0";
                    blnErrorFlag = true;
                }
                if (txtSalesLocation.Text == "")
                {
                    txtSalesLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    tpSalelocation.ShowAlways = true;
                    tpSalelocation.Show("Please select valid sales rack", txtSalesLocation, 5000);
                    txtSalesRack.Text = "";
                    varSalesRackCode = "0";
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbUnit.SelectedValue) == "" || Convert.ToString(cmbUnit.SelectedValue) == "-1")
                {
                    epProductApproval.SetError(cmbUnit, "Please select unit");
                    cmbUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpunit.ShowAlways = true;
                    tpunit.Show("Please select unit", cmbUnit, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbBatchno.SelectedValue) == "" || Convert.ToString(cmbBatchno.SelectedValue) == "-1")
                {
                    epProductApproval.SetError(cmbBatchno, "Please select Batch No.");
                    cmbBatchno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales Batch No.", cmbBatchno, 5000);
                    blnErrorFlag = true;
                }
                //if (Convert.ToString(cmbGst.SelectedValue) == "" || Convert.ToString(cmbGst.SelectedValue) == "-1")
                //{
                //    epProductApproval.SetError(cmbGst, "Please select GST%");
                //    cmbGst.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpgst.ShowAlways = true;
                //    tpgst.Show("Please select GST%", cmbGst, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToInt32(cmbBatchno.SelectedValue) == 72)
                {
                    if (Convert.ToString(cmbBatchGen.SelectedValue) == "" || Convert.ToString(cmbBatchGen.SelectedValue) == "-1")
                    {
                        epProductApproval.SetError(cmbBatchGen, "Please select Batch No. generation");
                        cmbBatchGen.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpcompanyname.ShowAlways = true;
                        tpcompanyname.Show("Please select sales Batch No. generation", cmbBatchGen, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToInt32(cmbBatchno.SelectedValue) == 72 && Convert.ToInt32(cmbBatchGen.SelectedValue) == -1)
                {
                    epProductApproval.SetError(cmbBatchGen, "Please select batcn no. generation");
                    cmbBatchGen.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales batcn no. generation", cmbBatchGen, 5000);
                    blnErrorFlag = true;
                }
                //if (Convert.ToString(txtHsncode.Text).Trim() == "")
                //{
                //    epProductApproval.SetError(txtHsncode, "Please enter HSN code");
                //    txtHsncode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpHsnCode.ShowAlways = true;
                //    tpHsnCode.Show("Please enter HSN code", txtHsncode, 5000);
                //    blnErrorFlag = true;
                //}
                if (cbShelflife.Checked == true)
                {
                    epProductApproval.Clear();
                    if (Convert.ToInt32(cmbPeriod.SelectedValue) == -1)
                    {
                        epProductApproval.SetError(cmbPeriod, "Please select shelflife");
                        cmbPeriod.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpcompanyname.ShowAlways = true;
                        tpcompanyname.Show("Please select shelflife", cmbPeriod, 5000);
                        blnErrorFlag = true;
                    }
                    if (txtSelfLife.Text == "")
                    {
                        epProductApproval.SetError(txtSelfLife, "Please enter shelflife");
                        txtSelfLife.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpplno.ShowAlways = true;
                        tpplno.Show("Please enter shelflife", txtSelfLife, 5000);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        if (Convert.ToInt32(txtSelfLife.Text) == 0)
                        {
                            epProductApproval.SetError(txtSelfLife, "Please enter valid shelflife");
                            txtSelfLife.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpshelflifevalue.ShowAlways = true;
                            tpshelflifevalue.Show("Please enter valid shelflife", txtSelfLife, 5000);
                            blnErrorFlag = true;
                        }
                    }
                }
                /* Check product sub group is valid or not*/
                string varId_SubGroup = "0";
                DataSet objDssubgroup = new DataSet();
                SPDataService objDserv = new SPDataService();
                objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubgroup.Text.Trim(), 0, 0, 0, 0, 0);
                objDserv.CloseConnection();
                if (objDssubgroup != null)
                {
                    if (objDssubgroup.Tables.Count > 0)
                    {
                        if (objDssubgroup.Tables[0].Rows.Count > 0)
                        {
                            varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                        }
                    }
                }
                varSubgroupCode = Convert.ToString(varId_SubGroup);
                if (varId_SubGroup == "0" || varId_SubGroup == "-1")
                {
                    epProductApproval.SetError(txtSubgroup, "Please select valid subgroup");
                    txtSubgroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpprdSG.ShowAlways = true;
                    tpprdSG.Show("Please select valid subgroup", txtSubgroup, 5000);
                    blnErrorFlag = true;
                }
                else
                {
                    // Subgroup Depend Group Load
                    DataSet objDsGroupCode = new DataSet();
                    objDsGroupCode = objDserv.udfnSubGroupList(16, Convert.ToInt32(varSubgroupCode), "", 0, 0, "", 0, 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDsGroupCode != null)
                    {
                        if (objDsGroupCode.Tables.Count > 0)
                        {
                            if (objDsGroupCode.Tables[0].Rows.Count > 0)
                            {
                                varGroupId = Convert.ToInt32(objDsGroupCode.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (txtBrand.Text != "")
                {
                    /* Check product brand is valid or not*/
                    string varId_Brand = "0";
                    DataSet objDsBrand = new DataSet();
                    SPDataService objDServ2 = new SPDataService();
                    objDsBrand = objDServ2.udfnBrandList(9, "", 0, Convert.ToInt32(varSubgroupCode), 0, txtBrand.Text.Trim(), 0);
                    objDServ2.CloseConnection();
                    if (objDsBrand != null)
                    {
                        if (objDsBrand.Tables.Count > 0)
                        {
                            if (objDsBrand.Tables[0].Rows.Count > 0)
                            {
                                varId_Brand = Convert.ToString(objDsBrand.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varBrand = Convert.ToString(varId_Brand);
                    if (varId_Brand == "0" || varId_Brand == "-1")
                    {
                        epProductApproval.SetError(txtBrand, "Please select valid brand");
                        txtBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpbrand.ShowAlways = true;
                        tpbrand.Show("Please select valid brand", txtBrand, 5000);
                        blnErrorFlag = true;
                    }
                }
                /* 
                  //Check product HSN is valid or not
                string varId_HSN = "0";
                DataSet objDsHSN = new DataSet();
                SPDataService objDs = new SPDataService();
                objDsHSN = objDs.udfnHsnList(9, 0, Convert.ToInt32(cmbGst.SelectedValue), 0, txtHsnname.Text.Trim(), txtHsncode.Text.Trim());
                objDs.CloseConnection();
                if (objDsHSN != null)
                {
                    if (objDsHSN.Tables.Count > 0)
                    {
                        if (objDsHSN.Tables[0].Rows.Count > 0)
                        {
                            varId_HSN = Convert.ToString(objDsHSN.Tables[0].Rows[0][0]);
                        }
                    }
                }
                varHsnCode = Convert.ToString(varId_HSN);
                if (Convert.ToString(varHsnCode) == "" || Convert.ToString(varHsnCode) == "0" || Convert.ToString(varHsnCode) == "-1")
                {
                    epProductApproval.SetError(txtHsncode, "Please enter valid HSN code");
                    txtHsncode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpHsnCode.ShowAlways = true;
                    tpHsnCode.Show("Please enter valid HSN code", txtHsncode, 5000);
                    blnErrorFlag = true;
                    txtHsnname.Text = "";
                }
                */
                /* Check purchase location is valid or not*/
                if (txtPurLocation.Text != "")
                {
                    string varId_PurLocation = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 14;
                    objMR_Location.ParaCompanycode = Convert.ToInt32(varComId);
                    objMR_Location.paraLocationName = txtPurLocation.Text.Trim();
                    objDsPurLoc = objDServ3.udfnStockLocationList(objMR_Location);
                    objDServ3.CloseConnection();

                    //objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(varComId), 0, 0, txtPurLocation.Text.Trim(), 0, 0, 0, "", "",0);
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
                    varPurLocationCode = Convert.ToString(varId_PurLocation);
                    if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                    {
                        epProductApproval.SetError(txtPurLocation, "Please select valid purchase stock location");
                        txtPurLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppurchaselocation.ShowAlways = true;
                        tppurchaselocation.Show("Please select valid purchase stock location", txtPurLocation, 5000);
                        blnErrorFlag = true;
                    }
                }

                if (txtPurLocation.Text.Trim() != "")
                {
                    string varId_PurchaseRack = "0";
                    string varPurchaseRackCount = "0";
                    DataSet objDsPurchaseRack = new DataSet();
                    SPDataService objDServ6 = new SPDataService();
                    objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varPurLocationCode), 0, txtPurRack.Text.Trim(), 0, 0);
                    objDServ6.CloseConnection();
                    if (objDsPurchaseRack != null)
                    {
                        if (objDsPurchaseRack.Tables.Count > 0)
                        {
                            if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                            {
                                varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                            }
                            if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                            {
                                varPurchaseRackCount = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                            }
                            if (varId_PurchaseRack == "-1" && varPurchaseRackCount != "0")
                            {
                                epProductApproval.SetError(txtPurRack, "Please select valid purchase rack");
                                txtPurRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tppurchaserack.ShowAlways = true;
                                tppurchaserack.Show("Please select valid purchase rack", txtPurRack, 5000);
                                blnErrorFlag = true;
                            }
                        }
                    }
                }

                /*
                if (Convert.ToString(txtPurRack.Text.Trim()) != "" && Convert.ToString(txtPurRack.Text.Trim()) != "None")
                {
                    //check location have a rack or not
                    string varId_PurchaseRack = "0";
                    DataSet objDsPurchaseRack = new DataSet();
                    SPDataService objDServ6 = new SPDataService();
                    objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varPurLocationCode), 0, txtPurRack.Text.Trim(), 0, 0);
                    objDServ6.CloseConnection();
                    if (txtPurRack.Text.Trim() != "")
                    {
                        if (varPurLocationCode != "0")
                        {
                            if (objDsPurchaseRack != null)
                            {
                                if (objDsPurchaseRack.Tables.Count > 0)
                                {
                                    if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                    {
                                        varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                    }
                                }
                            }
                            varPurRackCode = Convert.ToString(varId_PurchaseRack);
                            if (varId_PurchaseRack == "0" || varId_PurchaseRack == "-1")
                            {
                                epProductApproval.SetError(txtPurRack, "Please select valid purchase rack");
                                txtPurRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tppurchaserack.ShowAlways = true;
                                tppurchaserack.Show("Please select valid purchase rack", txtPurRack, 5000);
                                blnErrorFlag = true;
                            }
                        }
                    }
                    else
                    {
                        if (varPurLocationCode != "0")
                        {

                            if (objDsPurchaseRack != null)
                            {
                                if (objDsPurchaseRack.Tables.Count > 0)
                                {
                                    if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                    {
                                        varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                    }
                                }
                            }
                            varPurRackCode = Convert.ToString(varId_PurchaseRack);
                            if (varId_PurchaseRack != "0")
                            {
                                epProductApproval.SetError(txtPurRack, "Please enter rack");
                                txtPurRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tppurchaserack.ShowAlways = true;
                                tppurchaserack.Show("Please enter rack", txtPurRack, 5000);
                                blnErrorFlag = true;
                            }
                        }
                    }
                }
                */
                /* Check sales stock location is valid or not*/
                if (txtSalesLocation.Text != "")
                {
                    string varId_SalesLocation = "0";
                    DataSet objDsSalesLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 14;
                    objMR_Location.ParaCompanycode = Convert.ToInt32(varComId);
                    objMR_Location.paraLocationName = txtSalesLocation.Text.Trim();
                    objDsSalesLoc = objDServ3.udfnStockLocationList(objMR_Location);
                    objDServ3.CloseConnection();

                    //objDsSalesLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(varComId), 0, 0, txtSalesLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                    if (objDsSalesLoc != null)
                    {
                        if (objDsSalesLoc.Tables.Count > 0)
                        {
                            if (objDsSalesLoc.Tables[0].Rows.Count > 0)
                            {
                                varId_SalesLocation = Convert.ToString(objDsSalesLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varSalesLocationCode = Convert.ToString(varId_SalesLocation);
                    if (varId_SalesLocation == "0" || varId_SalesLocation == "-1")
                    {
                        epProductApproval.SetError(txtSalesLocation, "Please select valid sales stock location");
                        txtSalesLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSalelocation.ShowAlways = true;
                        tpSalelocation.Show("Please select valid sales stock location", txtSalesLocation, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (txtSalesLocation.Text.Trim() != "")
                {
                    string varId_SalesRack = "0";
                    string varSalesRackCount = "0";
                    DataSet objDsSalesRack = new DataSet();
                    SPDataService objDServ6 = new SPDataService();
                    objDsSalesRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varSalesLocationCode), 0, txtSalesRack.Text.Trim(), 0, 0);
                    objDServ6.CloseConnection();
                    if (objDsSalesRack != null)
                    {
                        if (objDsSalesRack.Tables.Count > 0)
                        {
                            if (objDsSalesRack.Tables[0].Rows.Count > 0)
                            {
                                varId_SalesRack = Convert.ToString(objDsSalesRack.Tables[0].Rows[0][0]);
                            }
                            if (objDsSalesRack.Tables[1].Rows.Count > 0)
                            {
                                varSalesRackCount = Convert.ToString(objDsSalesRack.Tables[1].Rows[0][0]);
                            }
                            if (varId_SalesRack == "-1" && varSalesRackCount != "0")
                            {
                                epProductApproval.SetError(txtSalesRack, "Please select valid sales rack");
                                txtSalesRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpsalesrack.ShowAlways = true;
                                tpsalesrack.Show("Please select valid sales rack", txtSalesRack, 5000);
                                blnErrorFlag = true;
                            }
                        }
                    }
                }
                /*
                if (Convert.ToString(txtSalesRack.Text.Trim()) != "" || Convert.ToString(txtSalesRack.Text.Trim()) == "None")
                {
                    //check location have a rack or not
                    string varId_SalesRack = "0";
                    DataSet objDsSalesRack = new DataSet();
                    SPDataService objDServ6 = new SPDataService();
                    objDsSalesRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varSalesLocationCode), 0, txtSalesRack.Text.Trim(), 0, 0);
                    objDServ6.CloseConnection();
                    if (txtSalesRack.Text.Trim() == "" || txtSalesRack.Text.Trim() == "None")
                    {
                        if (varSalesLocationCode != "0")
                        {
                            if (objDsSalesRack != null)
                            {
                                if (objDsSalesRack.Tables.Count > 0)
                                {
                                    if (objDsSalesRack.Tables[0].Rows.Count > 0)
                                    {
                                        varId_SalesRack = Convert.ToString(objDsSalesRack.Tables[0].Rows[0][0]);
                                    }
                                }
                            }
                            varSalesRackCode = Convert.ToString(varId_SalesRack);
                            if (Convert.ToString(objDsSalesRack.Tables[1].Rows[0][0]) != "0" && txtSalesRack.Text.Trim() == "None")
                            {
                                if (varId_SalesRack == "0" || varId_SalesRack == "-1")
                                {
                                    epProductApproval.SetError(txtSalesRack, "Please select valid sales rack");
                                    txtSalesRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tpsalesrack.ShowAlways = true;
                                    tpsalesrack.Show("Please select valid sales rack", txtSalesRack, 5000);
                                    blnErrorFlag = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (varSalesLocationCode != "0")
                        {
                            if (objDsSalesRack != null)
                            {
                                if (objDsSalesRack.Tables.Count > 0)
                                {
                                    if (objDsSalesRack.Tables[1].Rows.Count > 0)
                                    {
                                        varId_SalesRack = Convert.ToString(objDsSalesRack.Tables[1].Rows[0][0]);
                                    }
                                }
                            }
                            varSalesRackCode = Convert.ToString(varId_SalesRack);
                            if (varId_SalesRack != "0")
                            {
                                epProductApproval.SetError(txtSalesRack, "Please enter rack");
                                txtSalesRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpsalesrack.ShowAlways = true;
                                tpsalesrack.Show("Please enter rack", txtSalesRack, 5000);
                                blnErrorFlag = true;
                            }
                        }
                    }
                }
                */
                if(txtPurRack.Text.Trim()=="")
                {
                    varPurRackCode = "0";
                }
                if (txtSalesRack.Text.Trim() == "")
                {
                    varSalesRackCode = "0";
                }
                if (blnErrorFlag == false)
                {
                    udfnClear();
                    SPDataService objspdservice = new SPDataService();
                    string varorignator = "Product approval update";
                    result = objspdservice.udfnProductMaster(14, varproductcode, txtProductEname.Text, txtProductTname.Text, txtpicode.Text.Trim().ToUpper(),
                    0, Convert.ToInt32(cmbProductCategory.SelectedValue), Convert.ToInt32(varGroupId), Convert.ToInt32(varSubgroupCode), Convert.ToInt32(varBrand),
                    Convert.ToInt32(cmbUnit.SelectedValue), 0, "", Convert.ToInt32(varPurLocationCode), Convert.ToInt32(varSalesLocationCode)
                    , Convert.ToInt32(varPurRackCode), Convert.ToInt32(varSalesRackCode), 0, Convert.ToInt32(cmbBatchno.SelectedValue), Convert.ToInt32(cmbBatchGen.SelectedValue)
                    , varshelflife, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", Convert.ToInt32(varHsnCode), 0, shelflife,
                    Convert.ToInt32(cmbPeriod.SelectedValue), varStatus, MainForm.pbUserID, MainForm.pbIpAddress, varorignator, 0, null, 0, "", 0, 0, 0, 0, varMRPflag, dtProductHSN, "", "","",0,"", "");

                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnUpdate.Enabled = true;
                        if (btnUpdate.Text == "Update")
                        {
                            this.Close();
                        }
                        MainForm.objCP_ProductApprovalList.udfnList();
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnUpdate.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClear()
        {
            try
            {
                epProductApproval.Clear();
                txtProductEname.BackColor = Color.White;
                txtProductTname.BackColor = Color.White;
                txtBrand.BackColor = Color.White;
                cmbProductCategory.BackColor = Color.White;
                txtPurLocation.BackColor = Color.White;
                txtSalesLocation.BackColor = Color.White;
                txtPurRack.BackColor = Color.White;
                txtSalesRack.BackColor = Color.White;
                cmbUnit.BackColor = Color.White;
                cmbBatchno.BackColor = Color.White;
                cmbGst.BackColor = Color.White;
                txtHsncode.BackColor = Color.White;
                cmbPeriod.BackColor = Color.White;
                txtSelfLife.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadGrid( int varFlag)
        {
            try
            {
                if (varFlag == 0)
                {
                    grdBrand.DataSource = null;
                    grdCategory.DataSource = null;
                    grdSubgroup.DataSource = null;
                }
                else if (varFlag == 1)  { grdBrand.DataSource = null; }
                else if (varFlag == 2)  { grdSubgroup.DataSource = null; }
                else if (varFlag == 3)  { grdCategory.DataSource = null; }
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 50;
                objMR_Product.ParaProductCode = varproductcode;
                objMR_Product.paraProductCategory = Convert.ToInt32(varCategoryId);
                objMR_Product.paraSubgroup = varSubGroupId;
                objMR_Product.ParaCompanycode = varComId;
                objMR_Product.paraBrandID = Convert.ToInt32(varBrand);
                DataSet objDS =new DataSet();
                SPDataService objdserv = new SPDataService();
                objDS = objdserv.udfnproductmasterlist(objMR_Product);
                objdserv.CloseConnection();
                if (objDS != null)
                {
                    if (varFlag == 0 || varFlag == 1)
                    {
                        if (objDS.Tables[0].Rows.Count != 0)
                        {
                            grdBrand.DataSource = objDS.Tables[0];
                            grdBrand.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdBrand.Columns["Product Name in Tamil"].Width = 300;
                            grdBrand.Columns["Product Name in English"].Width = 300;
                            grdBrand.Columns["Unit"].Width = 60;
                            grdBrand.Columns["Purchase Stock Location"].Width = 150;
                            grdBrand.Columns["Sales Stock Location"].Width = 150;
                            grdBrand.Columns["Category"].Width = 80;
                            grdBrand.Columns["HSN_Name"].Width = 150;
                        }
                    }
                    if (varFlag == 0 || varFlag == 2)
                    {
                        if (objDS.Tables[1].Rows.Count != 0)
                        {
                            grdSubgroup.DataSource = objDS.Tables[1];
                            grdSubgroup.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdSubgroup.Columns["Product Name in Tamil"].Width = 300;
                            grdSubgroup.Columns["Product Name in English"].Width = 300;
                            grdSubgroup.Columns["Unit"].Width = 60;
                            grdSubgroup.Columns["Purchase Stock Location"].Width = 150;
                            grdSubgroup.Columns["Sales Stock Location"].Width = 150;
                            grdSubgroup.Columns["Category"].Width = 80;
                            grdSubgroup.Columns["HSN_Name"].Width = 150;
                        }
                    }
                    if (varFlag == 0 || varFlag == 3)
                    {
                        if (objDS.Tables[2].Rows.Count != 0)
                        {
                            grdCategory.DataSource = objDS.Tables[2];
                            grdCategory.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdCategory.Columns["Product Name in Tamil"].Width = 300;
                            grdCategory.Columns["Product Name in English"].Width = 300;
                            grdCategory.Columns["Unit"].Width = 60;
                            grdCategory.Columns["Purchase Stock Location"].Width = 150;
                            grdCategory.Columns["Sales Stock Location"].Width = 150;
                            grdCategory.Columns["Category"].Width = 80;
                            grdCategory.Columns["HSN_Name"].Width = 150;
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





