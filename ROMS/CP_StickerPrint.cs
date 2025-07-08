using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.Shared;
using ROMS.Model;

namespace ROMS
{
    //Author : Sathish
    //Created On : 20-02-2025
    public partial class CP_StickerPrint : Form
    {

        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public DataTable dtPMGroup, dtSubgroup, dtProduct, dtGroup, dtRawMaterial, dtFinishedGoods;
        public static string varFGCode;
        public int varStickerType;
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpType = new ToolTip();
        private ToolTip tpLabelSize = new ToolTip();
        private ToolTip tpLabelCount = new ToolTip();
        public string varProductCodes, varRMCodes, varFGCodes = "0";
        List<string> varSubgroupCodes = new List<string>();
        List<string> varGroupCodes = new List<string>();
        private int varsno;

        public CP_StickerPrint()
        {
            InitializeComponent();
        }

        private void PROD_LabelPrinting_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
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
        private void Btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                udfnPreview();
                udfnReportView("Print");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnReportView(string varType)
        {
            try
            {
                picLoader4.Visible = true;
                errRack.Clear();
                RPTViewer.ReportSource = null;
                int varPrint = 0;
                SPDataService objSPdataservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 65;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.ParaProductsCode = varProductCodes;
                objMR_Product.paraLabelCount = Convert.ToInt32(txtLabelCount.Text);
                objMR_Product.paraType = Convert.ToInt32(cmbProductName.SelectedValue);
                objDs = objSPdataservice.udfnproductmasterlist(objMR_Product);
                objSPdataservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 268)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Product_50x60.rpt");
                    }
                    else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Product_100x70.rpt");
                    }
                    objBillreport.SetParameterValue("paraLabelCount", Convert.ToInt32(txtLabelCount.Text));
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraType", Convert.ToInt32(cmbProductName.SelectedValue));
                    objBillreport.SetParameterValue("ParaProductsCode", varProductCodes);
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
                    picLoader4.Visible = false;
                    lblNoRecordsFound.Visible = false;
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader4.Visible = false;
            }
        }

        private void PROD_Rack_StickerPrint_Load(object sender, EventArgs e)
        {
            try
            {
                picLoader1.Visible = false;
                picLoader2.Visible = false;
                picLoader3.Visible = false;
                picLoader4.Visible = false;

                dtProduct = new DataTable();
                dtProduct.Columns.Add("", typeof(Boolean));
                dtProduct.Columns.Add("Product Name", typeof(string));
                dtProduct.Columns.Add("PRID", typeof(int));
                dtProduct.Columns.Add("GroupID", typeof(int));
                dtProduct.Columns.Add("SubgroupID", typeof(int));

                dtGroup = new DataTable();
                dtGroup.Columns.Add("", typeof(Boolean));
                dtGroup.Columns.Add("Group Name", typeof(string));
                dtGroup.Columns.Add("GroupID", typeof(int));

                dtSubgroup = new DataTable();
                dtSubgroup.Columns.Add("", typeof(Boolean));
                dtSubgroup.Columns.Add("Subgroup Name", typeof(string));
                dtSubgroup.Columns.Add("SubgroupID", typeof(int));
                dtSubgroup.Columns.Add("GroupID", typeof(int));

                udfnConcernLoad();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,79) AND MSTID<>0 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbLabelsize, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=80 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbProductName, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbLabelsize.SelectedValue = -1;
                cmbProductName.SelectedValue = 270;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnConcernLoad()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(2, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDataBind()
        {
            try
            {
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 64;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                SPDataService objspdservice = new SPDataService();
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                objspdservice.CloseConnection();
                dtProduct = null;
                dtGroup = null;
                dtSubgroup = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            dtProduct = objDs.Tables[0];
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            dtGroup = objDs.Tables[1];
                        }
                        if (objDs.Tables[2].Rows.Count != 0)
                        {
                            dtSubgroup = objDs.Tables[2];
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

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbConcern.SelectedValue) == -1)
                {
                    errRack.SetError(cmbConcern, "Please select concern.");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter concern", cmbConcern, 5000);
                    cmbConcern.Focus();
                    return;
                }
                errRack.Clear();
                udfnDataBind();
                grdGroup.DataSource = null;
                grdSubgroup.DataSource = null;
                grdProduct.DataSource = null;
                txtProduct.Text = "";
                txtGroup.Text = "";
                txtSubgroup.Text = "";
                if (dtGroup != null)
                {
                    picLoader2.Visible = true;
                    grdGroup.DataSource = dtGroup.Copy();
                    grdGroup.Columns[0].HeaderText = "";
                    grdGroup.Columns[0].Width = 50;
                    grdGroup.Columns[1].Width = 200;
                    grdGroup.Columns[1].ReadOnly = true;
                    grdGroup.Columns[2].Visible = false;
                    picLoader2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objStart = new DEF_Start();
                MainForm.objStart.MdiParent = this.ParentForm;
                MainForm.objStart.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbLabelsize_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLabelCount.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCompany_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cmbLabelsize_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cmbLabelsize_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbLabelsize.BackColor = Color.White;
                //udfnPrinterNameLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPrinterNameLoad()
        {
            try
            {
                string paths = Application.StartupPath + "\\Printer Settings\\printersettings.txt";
                if (File.Exists(paths))
                {
                    varsno = 0;
                    string line;
                    StreamReader file = new StreamReader(paths);
                    while ((line = file.ReadLine()) != null)
                    {
                        varsno = varsno + 1;
                        if (line != null & line != "")
                        {
                            string[] words = line.Split(',');
                            if (words[0] == Convert.ToString(cmbLabelsize.Text))
                            {
                                txtPrinterName.Text = words[1];
                            }
                        }
                    }
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbLabelsize_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbLabelsize.BackColor = Color.LemonChiffon;
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

        private void TxtGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void CmbCompany_Enter(object sender, EventArgs e)
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

        private void CmbCompany_Leave(object sender, EventArgs e)
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

        private void CmbCompany_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
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

        public void udfnFilterRefresh()
        {
            try
            {
                grdProduct.DataSource = null;
                grdGroup.DataSource = null;
                grdSubgroup.DataSource = null;
                RPTViewer.ReportSource = null;
                txtProduct.Text = "";
                txtGroup.Text = "";
                txtSubgroup.Text = "";
                cmbLabelsize.SelectedValue = 1;
                txtLabelCount.Text = "";
                txtPrinterName.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Btnpreview_Click(object sender, EventArgs e)
        {
            try
            {
                udfnPreview();
                udfnReportView("Preview");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
        public void udfnPreview()
        {
            try
            {
                if (Convert.ToInt32(cmbConcern.SelectedValue) == -1)
                {
                    errRack.SetError(cmbConcern, "Please select concern.");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    cmbConcern.Focus();
                    return;
                }
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) == -1)
                {
                    errRack.SetError(cmbLabelsize, "Please select label size.");
                    cmbLabelsize.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLabelSize.ShowAlways = true;
                    tpLabelSize.Show("Please select label size", cmbLabelsize, 5000);
                    //cmbLabelsize.Focus();
                    return;
                }
                if (Convert.ToString(txtLabelCount.Text.Trim()) == "")
                {
                    errRack.SetError(txtLabelCount, "Please enter label count.");
                    txtLabelCount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLabelCount.ShowAlways = true;
                    tpLabelCount.Show("Please enter label count", txtLabelCount, 5000);
                    //txtLabelCount.Focus();
                    return;
                }
                List<string> varSelectedProductCodes = new List<string>();
                int varCount = 0;
                varProductCodes = "0";
                for (int i = 0; i < grdProduct.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdProduct.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        string varProductCode = grdProduct.Rows[i].Cells["PRID"].Value.ToString();
                        varSelectedProductCodes.Add(varProductCode);
                        varCount++;
                    }
                }
                if (varCount == 0)
                {
                    MessageBox.Show("Please select atleast one product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                varProductCodes = string.Join(",", varSelectedProductCodes);
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
                txtSubgroup.BackColor = Color.LemonChiffon;
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

        private void TxtSubgroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSubgroup.BackColor = Color.White;
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
                txtProduct.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLabelCount_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLabelCount.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLabelCount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLabelCount_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLabelCount.BackColor = Color.White;
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

        private void BtnGroupSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdProduct.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdProduct.Rows.Count; i++)
                    {
                        grdProduct.Rows[i].Cells[0].Value = true;
                    }
                    txtProduct.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnGroupUnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdProduct.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdProduct.Rows.Count; i++)
                    {
                        grdProduct.Rows[i].Cells[0].Value = false;
                    }
                    txtProduct.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubgroupSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdGroup.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdGroup.Rows.Count; i++)
                    {
                        grdGroup.Rows[i].Cells[0].Value = true;
                    }
                    txtSubgroup.Text = "";
                    txtProduct.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubgroupUnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdGroup.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdGroup.Rows.Count; i++)
                    {
                        grdGroup.Rows[i].Cells[0].Value = false;
                    }
                    txtSubgroup.Text = "";
                    txtProduct.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdSubgroup.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdSubgroup.Rows.Count; i++)
                    {
                        grdSubgroup.Rows[i].Cells[0].Value = true;
                    }
                    txtProduct.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductUnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdSubgroup.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdSubgroup.Rows.Count; i++)
                    {
                        grdSubgroup.Rows[i].Cells[0].Value = false;
                    }
                    txtProduct.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLabelCount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtSubgroup_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbLabelsize.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btnpreview_Enter(object sender, EventArgs e)
        {
            try
            {
                btnpreview.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btnpreview_Leave(object sender, EventArgs e)
        {
            try
            {
                btnpreview.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                btnPrint.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPrint_Leave(object sender, EventArgs e)
        {
            try
            {
                btnPrint.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PROD_Rack_StickerPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                tpConcern.Active = false;
                tpType.Active = false;
                tpLabelSize.Active = false;
                tpLabelCount.Active = false;
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

        private void CmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                udfnFilterRefresh();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void GrdGroup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    picLoader3.Visible = true;
                    udfnSubgroupBind();
                    picLoader3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnProductBind()
        {
            try
            {
                grdProduct.DataSource = null;
                txtProduct.Text = "";
                List<string> varSelectedGroupCodes = new List<string>();

                for (int i = 0; i < grdSubgroup.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSubgroup.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        string varGroupCode = grdSubgroup.Rows[i].Cells["SubgroupID"].Value.ToString();
                        varSelectedGroupCodes.Add(varGroupCode);
                    }
                }
                varSubgroupCodes = varSelectedGroupCodes;
                DataTable filteredProduct = dtProduct.Clone();

                foreach (DataRow row in dtProduct.Rows)
                {
                    if (varSelectedGroupCodes.Contains(row["SubgroupID"].ToString()))
                    {
                        filteredProduct.ImportRow(row);
                    }
                }

                grdProduct.DataSource = filteredProduct;
                grdProduct.Columns[0].HeaderText = "";
                grdProduct.Columns[0].Width = 50;
                grdProduct.Columns[1].Width = 400;
                grdProduct.Columns[1].ReadOnly = true;
                grdProduct.Columns[2].Visible = false;
                grdProduct.Columns[3].Visible = false;
                grdProduct.Columns[4].Visible = false;
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
                (grdProduct.DataSource as DataTable).DefaultView.RowFilter = "([Product Name]) LIKE '%" + txtProduct.Text + "%'";
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
                (grdGroup.DataSource as DataTable).DefaultView.RowFilter = "([Group Name]) LIKE '%" + txtGroup.Text + "%'";
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
                (grdSubgroup.DataSource as DataTable).DefaultView.RowFilter = "([Subgroup Name]) LIKE '%" + txtSubgroup.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSubgroup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    picLoader1.Visible = true;
                    udfnProductBind();
                    picLoader1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSubgroup_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdSubgroup.CurrentCell is DataGridViewCheckBoxCell)
                {
                    grdSubgroup.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnpreview.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProductName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnSubgroupBind()
        {
            try
            {
                txtSubgroup.Text = "";
                txtProduct.Text = "";
                grdProduct.DataSource = null;
                grdSubgroup.DataSource = null;
                List<string> varSelectedGroupCodes = new List<string>();

                for (int i = 0; i < grdGroup.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdGroup.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        string varGroupCode = grdGroup.Rows[i].Cells["GroupID"].Value.ToString();
                        varSelectedGroupCodes.Add(varGroupCode);
                    }
                }
                varGroupCodes = varSelectedGroupCodes;
                DataTable filteredSubgroup = dtSubgroup.Clone();

                foreach (DataRow row in dtSubgroup.Rows)
                {
                    if (varSelectedGroupCodes.Contains(row["GroupID"].ToString()))
                    {
                        filteredSubgroup.ImportRow(row);
                    }
                }

                grdSubgroup.DataSource = filteredSubgroup;
                grdSubgroup.Columns[0].HeaderText = "";
                grdSubgroup.Columns[0].Width = 50;
                grdSubgroup.Columns[1].Width = 185;
                grdSubgroup.Columns[1].ReadOnly = true;
                grdSubgroup.Columns[2].Visible = false;
                grdSubgroup.Columns[3].Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdProduct_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            
        }

        private void GrdGroup_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (grdGroup.CurrentCell is DataGridViewCheckBoxCell)
                {
                    grdGroup.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
        public void udfnPrinterSetting()
        {
            try
            {
                string Strprintername = "";
                string paths = Application.StartupPath + "\\Printer Settings\\printersettings.txt";
                if (File.Exists(paths))
                {
                    varsno = 0;
                    string line;
                    StreamReader file = new StreamReader(paths);
                    while ((line = file.ReadLine()) != null)
                    {
                        varsno = varsno + 1;
                        if (line != null & line != "")
                        {
                            string[] words = line.Split(',');
                            if (words[0] == Convert.ToString(cmbLabelsize.Text))
                            {
                                Strprintername = words[1];
                            }
                        }
                    }
                    file.Close();
                }
                txtPrinterName.Text = Strprintername;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbLabelsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbLabelsize.Select(int.MaxValue, 0)));
                //udfnPrinterSetting();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
