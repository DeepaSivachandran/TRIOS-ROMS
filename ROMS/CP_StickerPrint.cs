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
        public DataTable dtPMGroup, dtSubgroup, dtProduct, dtGroup, dtRack, dtRackgroup;
        public static string varFGCode;
        public int varStickerType;
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpType = new ToolTip();
        private ToolTip tpLabelSize = new ToolTip();
        private ToolTip tpLabelCount = new ToolTip();
        public string varProductCodes, varSubgroupCodes, varGroupCodes, varRackCodes, varRackGroupCodes = "0";
        private int varsno;
        List<string> varListSubgroupCodes = new List<string>();
        List<string> varListGroupCodes = new List<string>();

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
                //udfnReportView("Print");
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
                int viewType = 0; string varCodes = "0";
                if (Convert.ToInt32(cmbType.SelectedIndex) == 1)
                {
                    viewType = 67;
                    varCodes = varGroupCodes;
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 2)
                {
                    viewType = 66;
                    varCodes = varSubgroupCodes;
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 3)
                {
                    viewType = 65;
                    varCodes = varProductCodes;
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 4)
                {
                    viewType = 69;
                    varCodes = varRackCodes;
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 5)
                {
                    viewType = 72;
                    varCodes = varRackGroupCodes;
                }
                picLoader4.Visible = true;
                errRack.Clear();
                RPTViewer.ReportSource = null;
                int varPrint = 0;
                SPDataService objSPdataservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = viewType;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.ParaProductsCode = varCodes;
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
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 1)
                    {
                        if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 268)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Group_50x60.rpt");
                        }
                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Group_100x70.rpt");
                        }
                    }
                    else if (Convert.ToInt32(cmbType.SelectedIndex) == 2)
                    {
                        if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 268)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Subgroup_50x60.rpt");
                        }
                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Subgroup_100x70.rpt");
                        }
                    }
                    else if (Convert.ToInt32(cmbType.SelectedIndex) == 3)
                    {
                        if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 268)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Product_50x60.rpt");
                        }
                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Product_100x70.rpt");
                        }
                        objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    }
                    else if (Convert.ToInt32(cmbType.SelectedIndex) == 4)
                    {
                        if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 268)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Rack_50x60.rpt");
                        }
                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Rack_100x70.rpt");
                        }
                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 301)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Rack_50x25.rpt");
                        }
                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 302)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_Rack_50x35.rpt");
                        }
                    }
                    else if (Convert.ToInt32(cmbType.SelectedIndex) == 5)
                    {
                        if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 268)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_RackGroup_50x60.rpt");
                        }
                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_RackGroup_100x70.rpt");
                        }
                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 301)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_RackGroup_50x25.rpt");
                        }
                        else if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 302)
                        {
                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Sticker_Print_RackGroup_50x35.rpt");
                        }
                    }
                    if (Convert.ToInt32(cmbType.SelectedIndex) != 4 && Convert.ToInt32(cmbType.SelectedIndex) != 5)
                    {
                        objBillreport.SetParameterValue("paraType", Convert.ToInt32(cmbProductName.SelectedValue));
                    }
                    objBillreport.SetParameterValue("paraLabelCount", Convert.ToInt32(txtLabelCount.Text));
                    objBillreport.SetParameterValue("ParaProductsCode", varCodes);
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
                dtProduct.Columns.Add("PR_EName", typeof(string));
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

                dtRack = new DataTable();
                dtRack.Columns.Add("", typeof(Boolean));
                dtRack.Columns.Add("Rack Name", typeof(string));
                dtRack.Columns.Add("RackID", typeof(int));

                dtRackgroup = new DataTable();
                dtRackgroup.Columns.Add("", typeof(Boolean));
                dtRackgroup.Columns.Add("RackGroup Name", typeof(string));
                dtRackgroup.Columns.Add("RackGroupID", typeof(int));

                udfnConcernLoad();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,79) AND MSTID NOT IN (0,301,302) ORDER BY ISNULL(MST_OrderID,0) ASC", "MST_DisplayText,MSTID", cmbLabelsize, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=80 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbProductName, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbLabelsize.SelectedValue = -1;
                cmbProductName.SelectedValue = 270;
                cmbType.SelectedIndex = 0;
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
                dtRack = null;
                dtRackgroup = null;
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
                        if (objDs.Tables[3].Rows.Count != 0)
                        {
                            dtRack = objDs.Tables[3];
                        }
                        if (objDs.Tables[4].Rows.Count != 0)
                        {
                            dtRackgroup = objDs.Tables[4];
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
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    cmbConcern.Focus();
                    return;
                }
                if (Convert.ToInt32(cmbType.SelectedIndex) == 0)
                {
                    errRack.SetError(cmbType, "Please select type.");
                    cmbType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpType.ShowAlways = true;
                    tpType.Show("Please select type", cmbType, 5000);
                    cmbType.Focus();
                    return;
                }
                errRack.Clear();
                udfnDataBind();

                grdGroup.DataSource = null;
                grdSubgroup.DataSource = null;
                grdProduct.DataSource = null;
                grdRack.DataSource = null;
                grdRackGroup.DataSource = null;
                RPTViewer.ReportSource = null;

                txtProduct.Text = "";
                txtUnit.Text = "";
                txtGroup.Text = "";
                txtSubgroup.Text = "";
                if (Convert.ToInt32(cmbType.SelectedIndex) == 1 || Convert.ToInt32(cmbType.SelectedIndex) == 2 || Convert.ToInt32(cmbType.SelectedIndex) == 3)
                {
                    if (dtGroup != null)
                    {
                        picLoader2.Visible = true;
                        grdGroup.DataSource = dtGroup.Copy();
                        grdRack.SendToBack();
                        grdRackGroup.SendToBack();
                        grdGroup.BringToFront();
                        grdGroup.Columns[0].HeaderText = "";
                        grdGroup.Columns[0].Width = 50;
                        grdGroup.Columns[1].Width = 115;
                        grdGroup.Columns[1].ReadOnly = true;
                        grdGroup.Columns[2].Visible = false;
                        picLoader2.Visible = false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 4)
                    {
                        if (dtRack != null)
                        {
                            picLoader2.Visible = true;
                            grdRack.DataSource = dtRack.Copy();
                            grdGroup.SendToBack();
                            grdRackGroup.SendToBack();
                            grdRack.BringToFront();
                            grdRack.Columns[0].HeaderText = "";
                            grdRack.Columns[0].Width = 50;
                            grdRack.Columns[1].Width = 115;
                            grdRack.Columns[1].ReadOnly = true;
                            grdRack.Columns[2].Visible = false;
                            picLoader2.Visible = false;
                        }
                    }
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 5)
                    {
                        if (dtRackgroup != null)
                        {
                            picLoader2.Visible = true;
                            grdRackGroup.DataSource = dtRackgroup.Copy();
                            grdGroup.SendToBack();
                            grdRack.SendToBack();
                            grdRackGroup.BringToFront();
                            grdRackGroup.Columns[0].HeaderText = "";
                            grdRackGroup.Columns[0].Width = 50;
                            grdRackGroup.Columns[1].Width = 115;
                            grdRackGroup.Columns[1].ReadOnly = true;
                            grdRackGroup.Columns[2].Visible = false;
                            picLoader2.Visible = false;
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

        public void udfnFilterRefresh()
        {
            try
            {
                txtLabelCount.Text = "";
                grdProduct.DataSource = null;
                grdGroup.DataSource = null;
                grdSubgroup.DataSource = null;
                RPTViewer.ReportSource = null;
                txtProduct.Text = "";
                txtUnit.Text = "";
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
                RPTViewer.ReportSource = null;
                udfnPreview();
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
                bool blnErrFlag = false;
                if (Convert.ToInt32(cmbConcern.SelectedValue) == -1)
                {
                    errRack.SetError(cmbConcern, "Please select concern.");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToInt32(cmbType.SelectedIndex) == 0)
                {
                    errRack.SetError(cmbType, "Please select type.");
                    cmbType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpType.ShowAlways = true;
                    tpType.Show("Please select type", cmbType, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) == -1)
                {
                    errRack.SetError(cmbLabelsize, "Please select label size.");
                    cmbLabelsize.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLabelSize.ShowAlways = true;
                    tpLabelSize.Show("Please select label size", cmbLabelsize, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToString(txtLabelCount.Text.Trim()) == "")
                {
                    errRack.SetError(txtLabelCount, "Please enter label count.");
                    txtLabelCount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLabelCount.ShowAlways = true;
                    tpLabelCount.Show("Please enter label count", txtLabelCount, 5000);
                    blnErrFlag = true;
                }

                SPDataService objDataService = new SPDataService();
                if (Convert.ToInt32(cmbType.SelectedIndex) == 1)
                {
                    List<string> varSelectedGroupCodes = new List<string>();
                    int varCount = 0;
                    varGroupCodes = "0";
                    if (grdGroup.Rows.Count > 0)
                    {
                        for (int i = 0; i < grdGroup.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(grdGroup.Rows[i].Cells[0].EditedFormattedValue) == true)
                            {
                                string varGroupCode = grdGroup.Rows[i].Cells["GroupID"].Value.ToString();
                                varSelectedGroupCodes.Add(varGroupCode);
                                varCount++;
                            }
                        }
                        varGroupCodes = string.Join(",", varSelectedGroupCodes);
                    }
                    if (varCount == 0)
                    {
                        string varMessage = objDataService.udfnGetMessages(151);
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        objDataService.CloseConnection();
                        blnErrFlag = true;
                    }
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 2)
                {
                    List<string> varSelectedSubgroupCodes = new List<string>();
                    int varCount = 0;
                    varSubgroupCodes = "0";
                    if (grdSubgroup.Rows.Count > 0)
                    {
                        for (int i = 0; i < grdSubgroup.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(grdSubgroup.Rows[i].Cells[0].EditedFormattedValue) == true)
                            {
                                string varSubgroupCode = grdSubgroup.Rows[i].Cells["SubgroupID"].Value.ToString();
                                varSelectedSubgroupCodes.Add(varSubgroupCode);
                                varCount++;
                            }
                        }
                        varSubgroupCodes = string.Join(",", varSelectedSubgroupCodes);
                    }
                    if (varCount == 0)
                    {
                        string varMessage = objDataService.udfnGetMessages(44);
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        objDataService.CloseConnection();
                        blnErrFlag = true;
                    }
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 3)
                {
                    List<string> varSelectedProductCodes = new List<string>();
                    int varCount = 0;
                    varProductCodes = "0";
                    if (grdProduct.Rows.Count > 0)
                    {
                        for (int i = 0; i < grdProduct.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(grdProduct.Rows[i].Cells[0].EditedFormattedValue) == true)
                            {
                                string varProductCode = grdProduct.Rows[i].Cells["PRID"].Value.ToString();
                                varSelectedProductCodes.Add(varProductCode);
                                varCount++;
                            }
                        }
                        varProductCodes = string.Join(",", varSelectedProductCodes);
                    }
                    if (varCount == 0)
                    {
                        string varMessage = objDataService.udfnGetMessages(80);
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        objDataService.CloseConnection();
                        blnErrFlag = true;
                    }
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 4)
                {
                    List<string> varSelectedRackCodes = new List<string>();
                    int varCount = 0;
                    varRackCodes = "0";
                    if (grdRack.Rows.Count > 0)
                    {
                        for (int i = 0; i < grdRack.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(grdRack.Rows[i].Cells[0].EditedFormattedValue) == true)
                            {
                                string varRackCode = grdRack.Rows[i].Cells["RackID"].Value.ToString();
                                varSelectedRackCodes.Add(varRackCode);
                                varCount++;
                            }
                        }
                        varRackCodes = string.Join(",", varSelectedRackCodes);
                    }
                    if (varCount == 0)
                    {
                        string varMessage = objDataService.udfnGetMessages(60);
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        objDataService.CloseConnection();
                        blnErrFlag = true;
                    }
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 5)
                {
                    List<string> varSelectedRackGroupCodes = new List<string>();
                    int varCount = 0;
                    varRackGroupCodes = "0";
                    if (grdRackGroup.Rows.Count > 0)
                    {
                        for (int i = 0; i < grdRackGroup.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(grdRackGroup.Rows[i].Cells[0].EditedFormattedValue) == true)
                            {
                                string varRackGroupCode = grdRackGroup.Rows[i].Cells["RackGroupID"].Value.ToString();
                                varSelectedRackGroupCodes.Add(varRackGroupCode);
                                varCount++;
                            }
                        }
                        varRackGroupCodes = string.Join(",", varSelectedRackGroupCodes);
                    }
                    if (varCount == 0)
                    {
                        string varMessage = objDataService.udfnGetMessages(60);
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        objDataService.CloseConnection();
                        blnErrFlag = true;
                    }
                }
                if (blnErrFlag == false)
                {
                    errRack.Clear();
                    udfnReportView("Preview");
                }
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
                if (Convert.ToInt32(cmbType.SelectedIndex) != 4 && Convert.ToInt32(cmbType.SelectedIndex) != 5)
                {
                    if (Convert.ToInt32(grdGroup.Rows.Count) > 0)
                    {
                        for (int i = 0; i < grdGroup.Rows.Count; i++)
                        {
                            grdGroup.Rows[i].Cells[0].Value = true;
                        }
                        txtSubgroup.Text = "";
                        txtProduct.Text = "";
                        txtUnit.Text = "";
                    }
                }
                else
                {
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 4)
                    {
                        if (Convert.ToInt32(grdRack.Rows.Count) > 0)
                        {
                            for (int i = 0; i < grdRack.Rows.Count; i++)
                            {
                                grdRack.Rows[i].Cells[0].Value = true;
                            }
                            txtSubgroup.Text = "";
                            txtProduct.Text = "";
                            txtUnit.Text = "";
                        }
                    }
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 5)
                    {
                        if (Convert.ToInt32(grdRackGroup.Rows.Count) > 0)
                        {
                            for (int i = 0; i < grdRackGroup.Rows.Count; i++)
                            {
                                grdRackGroup.Rows[i].Cells[0].Value = true;
                            }
                            txtSubgroup.Text = "";
                            txtProduct.Text = "";
                            txtUnit.Text = "";
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

        private void BtnGroupUnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbType.SelectedIndex) != 4 && Convert.ToInt32(cmbType.SelectedIndex) != 5)
                {
                    if (Convert.ToInt32(grdGroup.Rows.Count) > 0)
                    {
                        for (int i = 0; i < grdGroup.Rows.Count; i++)
                        {
                            grdGroup.Rows[i].Cells[0].Value = false;
                        }
                        txtSubgroup.Text = "";
                        txtProduct.Text = "";
                        txtUnit.Text = "";
                    }
                }
                else
                {
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 4)
                    {
                        if (Convert.ToInt32(grdRack.Rows.Count) > 0)
                        {
                            for (int i = 0; i < grdRack.Rows.Count; i++)
                            {
                                grdRack.Rows[i].Cells[0].Value = false;
                            }
                            txtSubgroup.Text = "";
                            txtProduct.Text = "";
                            txtUnit.Text = "";
                        }
                    }
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 5)
                    {
                        if (Convert.ToInt32(grdRackGroup.Rows.Count) > 0)
                        {
                            for (int i = 0; i < grdRackGroup.Rows.Count; i++)
                            {
                                grdRackGroup.Rows[i].Cells[0].Value = false;
                            }
                            txtSubgroup.Text = "";
                            txtProduct.Text = "";
                            txtUnit.Text = "";
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

        private void BtnSubgroupSelect_Click(object sender, EventArgs e)
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
                    txtUnit.Text = "";
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
                if (Convert.ToInt32(grdSubgroup.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdSubgroup.Rows.Count; i++)
                    {
                        grdSubgroup.Rows[i].Cells[0].Value = false;
                    }
                    txtProduct.Text = "";
                    txtUnit.Text = "";
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
                if (Convert.ToInt32(grdProduct.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdProduct.Rows.Count; i++)
                    {
                        grdProduct.Rows[i].Cells[0].Value = true;
                    }
                    txtProduct.Text = "";
                    txtUnit.Text = "";
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
                if (Convert.ToInt32(grdProduct.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdProduct.Rows.Count; i++)
                    {
                        grdProduct.Rows[i].Cells[0].Value = false;
                    }
                    txtProduct.Text = "";
                    txtUnit.Text = "";
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
                    txtUnit.Focus();
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
        private void GrdGroup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    if (Convert.ToInt32(cmbType.SelectedIndex) != 1)
                    {
                        picLoader3.Visible = true;
                        udfnSubgroupBind();
                        picLoader3.Visible = false;
                    }
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
                txtUnit.Text = "";
                List<string> varSelectedGroupCodes = new List<string>();

                for (int i = 0; i < grdSubgroup.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSubgroup.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        string varGroupCode = grdSubgroup.Rows[i].Cells["SubgroupID"].Value.ToString();
                        varSelectedGroupCodes.Add(varGroupCode);
                    }
                }
                varListSubgroupCodes = varSelectedGroupCodes;
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
                grdProduct.Columns["PI Code"].Width = 100;
                grdProduct.Columns["Product Name"].Width = 300;
                grdProduct.Columns["Product Name"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                //grdProduct.Columns[2].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                grdProduct.Columns["Unit"].Width = 80;
                grdProduct.Columns["PI Code"].ReadOnly = true;
                grdProduct.Columns["Product Name"].ReadOnly = true;
                grdProduct.Columns["Unit"].ReadOnly = true;
                grdProduct.Columns["PR_EName"].Visible = false;
                grdProduct.Columns["PRID"].Visible = false;
                grdProduct.Columns["GroupID"].Visible = false;
                grdProduct.Columns["SubgroupID"].Visible = false;
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
                if (grdProduct?.DataSource != null)
                {
                    (grdProduct.DataSource as DataTable).DefaultView.RowFilter = "([PR_EName]) LIKE '%" + txtProduct.Text + "%'";
                }
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
                if (Convert.ToInt32(cmbType.SelectedIndex) != 4 && Convert.ToInt32(cmbType.SelectedIndex) != 5)
                {
                    if (grdGroup?.DataSource != null)
                    {
                        (grdGroup?.DataSource as DataTable).DefaultView.RowFilter = "([Group Name]) LIKE '%" + txtGroup.Text + "%'";
                    }
                }
                else
                {
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 4)
                    {
                        if (grdRack?.DataSource != null)
                        {
                            (grdRack?.DataSource as DataTable).DefaultView.RowFilter = "([Rack Name]) LIKE '%" + txtGroup.Text + "%'";
                        }
                    }
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 5)
                    {
                        if (grdRackGroup?.DataSource != null)
                        {
                            (grdRackGroup?.DataSource as DataTable).DefaultView.RowFilter = "([RackGroup Name]) LIKE '%" + txtGroup.Text + "%'";
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

        private void TxtSubgroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdSubgroup?.DataSource != null)
                {
                    (grdSubgroup.DataSource as DataTable).DefaultView.RowFilter = "([Subgroup Name]) LIKE '%" + txtSubgroup.Text + "%'";
                }
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
                    if (Convert.ToInt16(cmbType.SelectedIndex) != 1 && Convert.ToInt16(cmbType.SelectedIndex) != 2)
                    {
                        picLoader1.Visible = true;
                        udfnProductBind();
                        picLoader1.Visible = false;
                    }
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

        private void CmbType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbType_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtLabelCount.Text = "";
                txtGroup.Text = "";
                txtSubgroup.Text = "";
                txtProduct.Text = "";
                txtUnit.Text = "";
                cmbProductName.Enabled = true;
                if (Convert.ToInt32(cmbType.SelectedIndex) == 1)
                {
                    lblGroup.Text = "Group";
                    lblProductName.Text = "Group Name";
                    grdSubgroup.Visible = false;
                    txtSubgroup.Visible = false;
                    lblSubgroup.Visible = false;
                    btnSubgroupSelect.Visible = false;
                    btnSubgroupUnSelect.Visible = false;

                    grdProduct.Visible = false;
                    txtProduct.Visible = false;
                    txtUnit.Visible = false;
                    lblProduct.Visible = false;
                    lblUnitName.Visible = false;
                    btnProductSelect.Visible = false;
                    btnProductUnSelect.Visible = false;
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 2)
                {
                    lblProductName.Text = "Subgroup Name";
                    grdSubgroup.Visible = true;
                    txtSubgroup.Visible = true;
                    lblSubgroup.Visible = true;
                    btnSubgroupSelect.Visible = true;
                    btnSubgroupUnSelect.Visible = true;

                    grdProduct.Visible = false;
                    txtProduct.Visible = false;
                    txtUnit.Visible = false;
                    lblProduct.Visible = false;
                    lblUnitName.Visible = false;
                    btnProductSelect.Visible = false;
                    btnProductUnSelect.Visible = false;
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 0 || Convert.ToInt32(cmbType.SelectedIndex) == 3)
                {
                    lblProductName.Text = "Product Name";
                    grdSubgroup.Visible = true;
                    txtSubgroup.Visible = true;
                    lblSubgroup.Visible = true;
                    btnSubgroupSelect.Visible = true;
                    btnSubgroupUnSelect.Visible = true;

                    grdProduct.Visible = true;
                    txtProduct.Visible = true;
                    txtUnit.Visible = true;
                    lblProduct.Visible = true;
                    lblUnitName.Visible = true;
                    btnProductSelect.Visible = true;
                    btnProductUnSelect.Visible = true;
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 4)
                {
                    lblProductName.Text = "";
                    cmbProductName.SelectedValue = 270;
                    cmbProductName.Enabled = false;
                    grdSubgroup.Visible = false;
                    txtSubgroup.Visible = false;
                    lblSubgroup.Visible = false;
                    btnSubgroupSelect.Visible = false;
                    btnSubgroupUnSelect.Visible = false;

                    grdProduct.Visible = false;
                    txtProduct.Visible = false;
                    txtUnit.Visible = false;
                    lblProduct.Visible = false;
                    lblUnitName.Visible = false;
                    btnProductSelect.Visible = false;
                    btnProductUnSelect.Visible = false;
                }
                else if (Convert.ToInt32(cmbType.SelectedIndex) == 5)
                {
                    lblProductName.Text = "";
                    cmbProductName.SelectedValue = 270;
                    cmbProductName.Enabled = false;
                    grdSubgroup.Visible = false;
                    txtSubgroup.Visible = false;
                    lblSubgroup.Visible = false;
                    btnSubgroupSelect.Visible = false;
                    btnSubgroupUnSelect.Visible = false;

                    grdProduct.Visible = false;
                    txtProduct.Visible = false;
                    txtUnit.Visible = false;
                    lblProduct.Visible = false;
                    lblUnitName.Visible = false;
                    btnProductSelect.Visible = false;
                    btnProductUnSelect.Visible = false;
                }
                if (Convert.ToInt32(cmbType.SelectedIndex) == 1 || Convert.ToInt32(cmbType.SelectedIndex) == 2 || Convert.ToInt32(cmbType.SelectedIndex) == 3)
                {
                    lblGroup.Text = "Group";
                }
                else
                {
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 4)
                    {
                        lblGroup.Text = "Rack";
                    }
                    if (Convert.ToInt32(cmbType.SelectedIndex) == 5)
                    {
                        lblGroup.Text = "RackGroup";
                    }
                }
                grdGroup.DataSource = null;
                grdSubgroup.DataSource = null;
                grdProduct.DataSource = null;
                grdRack.DataSource = null;
                grdRackGroup.DataSource = null;
                RPTViewer.ReportSource = null;
                DataBind objDataBind = new DataBind();
                if (Convert.ToInt32(cmbType.SelectedIndex) != 4 && Convert.ToInt32(cmbType.SelectedIndex) != 5)
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,79) AND MSTID NOT IN (0,301,302) ORDER BY ISNULL(MST_OrderID,0) ASC", "MST_DisplayText,MSTID", cmbLabelsize, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                }
                else
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,79) AND MSTID<>0 ORDER BY ISNULL(MST_OrderID,0) ASC", "MST_DisplayText,MSTID", cmbLabelsize, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                }
                cmbLabelsize.SelectedValue = -1;
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
                txtUnit.Text = "";
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
                varListGroupCodes = varSelectedGroupCodes;
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

        private void GrdRackGroup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    //if (Convert.ToInt32(cmbType.SelectedIndex) != 1 && Convert.ToInt32(cmbType.SelectedIndex) != 4)
                    //{
                    //    picLoader3.Visible = true;
                    //    udfnSubgroupBind();
                    //    picLoader3.Visible = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUnit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUnit_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                txtUnit.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdProduct?.DataSource != null)
                {
                    (grdProduct.DataSource as DataTable).DefaultView.RowFilter = "([Unit]) LIKE '%" + txtUnit.Text + "%'";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRackGroup_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdRackGroup.CurrentCell is DataGridViewCheckBoxCell)
                {
                    grdRackGroup.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRack_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdRack.CurrentCell is DataGridViewCheckBoxCell)
                {
                    grdRack.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRack_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    //if (Convert.ToInt32(cmbType.SelectedIndex) != 1 && Convert.ToInt32(cmbType.SelectedIndex) != 4)
                    //{
                    //    picLoader3.Visible = true;
                    //    udfnSubgroupBind();
                    //    picLoader3.Visible = false;
                    //}
                }
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
