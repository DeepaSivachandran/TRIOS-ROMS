using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpMRP = new ToolTip();
        private ToolTip tpLocation = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tpExpiryDate = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpStockQty = new ToolTip();
        private ToolTip tpQuantity = new ToolTip();
        private ToolTip tpSupplierName = new ToolTip();
        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpReason = new ToolTip();
        public bool VarSearchFlag = true;
        public string varProductName = "";
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
        public string varErrQty = "0";
        public int varID = 0,varQueid = 0;
        int varCheckFlag = 0, varUncheckFlag = 0;
        public int varStatusID = 0;
        public string varTempDay = "";
        public string varTempMonth = "";
        public string varTempYear = "";
        public string varEmployeeId = "";
        public string varUserID = "";
        public string DmUpdatevalue = "";
        //public int varUpdate = 0;
        public int varModifiedFlag = 0;
        public int varDecimal = 0, fromQueueFlag = 0, varcomID = 0,varTotalProd = 0;
        public int varCloseFlag = 0, varClose = 0, varDateChange = 0, varUpDownKey = 0;
        public string varBlockedSupplier = "0", varBlockedReason = "";
        Boolean BlnSearchImageYN = false;
        bool varVoucherSkip = false;
        byte[] varobjBarCodeByte;
        DataTable dtDamage = new DataTable();
        DataTable dtEmployee = new DataTable();
        DataTable dtChecker = new DataTable();
        int varDMFromOther = 0, expirydateFlag = 0, varBatchNoGeneration = 0, varMRPFlag = 0;
        public INV_DamageEntry()
        {
            InitializeComponent();
        }
        public void udfnAdd()
        {
            try
            {
                if (varDMFromOther == 0 ||  fromQueueFlag == 1)
                {
                    varExpiryDate = txtExpiryDate.Text;
                }
                else
                {
                    if (txtDay.Text.Trim() != "" && txtMonth.Text.Trim() != "" && txtYear.Text.Trim() != "")
                    {
                        varExpiryDate = txtDay.Text.Trim() + "/" + txtMonth.Text.Trim() + "/20" + txtYear.Text.Trim();
                    }
                }
                if (varExpiryDate != "")
                {
                    if (varDMFromOther == 0 ||  fromQueueFlag == 1)
                    {
                        string varExpiryDate = "";
                        varExpiryDate = txtExpiryDate.Text.Trim();
                        string[] DMY = varExpiryDate.Split('/');
                        varTempDay = DMY[0];
                        varTempMonth = DMY[1];
                        varTempYear = DMY[2];
                    }
                    else
                    {
                        varTempDay = txtDay.Text.Trim();
                        varTempMonth = txtMonth.Text.Trim();
                        varTempYear = txtYear.Text.Trim();
                    }
                }
                else
                {
                    varTempDay = "0";
                    varTempMonth = "0";
                    varTempYear = "0";
                }

                string mrp = "0";
                if (Convert.ToString(txtMrp.Text.Trim()) != "")
                { mrp = txtMrp.Text.Trim(); }
                grdDamageEntry.Rows.Add(grdDamageEntry.Rows.Count + 1, varPICode, varProductName, txtLocation.Text.Trim(), txtRack.Text.Trim(), mrp, varExpiryDate, txtBatchNo.Text.Trim(), (txtStockQty.Text).Trim(), txtQuantity.Text.Trim(), varUnitSymbol, cmbReason.Text.Trim(), cmbSupplier.Text.Trim(), varTempDay, varTempMonth, varTempYear, (lblProduct.Text).Trim(), varSLID, varRKID, varUTID, (lblSupplierCode.Text).Trim(), (lblScheduleCode.Text).Trim(), varDecimal, varBlockedReason, varBlockedSupplier);
                ((DataGridViewTextBoxColumn)grdDamageEntry.Columns["clmQuantity"]).MaxInputLength = 8;
                grdDamageEntry.Columns["clmDay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmMonth"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmYear"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmBatchNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmStockQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmexpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDamage.Rows.Add(Convert.ToInt32((lblProduct.Text).Trim()), Convert.ToInt32(varSLID), Convert.ToInt32(varRKID), string.Format("{0:G29}", decimal.Parse(mrp)), Convert.ToInt32(varTempDay), Convert.ToInt32(varTempMonth), Convert.ToInt32(varTempYear), varExpiryDate, txtBatchNo.Text.Trim(), txtQuantity.Text.Trim(), varUTID, 20, lblSupplierCode.Text.Trim(), lblScheduleCode.Text.Trim(), Convert.ToInt32(cmbReason.SelectedValue));
                txttotalitem.Text = Convert.ToString(grdDamageEntry.Rows.Count);
                varModifiedFlag = 1;
                epDamageEntry.Clear();
                grdDamageEntry.ClearSelection();
                udfnProductClear();
                txtProductName.Focus();
                lblUnit.Text = "";
                int Rowcount = grdDamageEntry.Rows.Count - 1;
                if (varBlockedSupplier == "98")
                {
                    grdDamageEntry.Rows[Rowcount].Cells["clmSupplier"].Style.BackColor = Color.LightPink;
                }
                //if (fromQueueFlag == 1)
                //{
                //    grdDamageEntry.Columns["clmQuantity"].ReadOnly = true;
                //    grdDamageEntry.Columns["clmQuantity"].DefaultCellStyle.BackColor = Color.White;
                //}

                int totalQueueValue = Convert.ToInt32(tsttotalValue.Text);
                tstaddedvalue.Text = Convert.ToString(grdDamageEntry.Rows.Count);
                tsbRemainingValue.Text = Convert.ToString(totalQueueValue - grdDamageEntry.Rows.Count);
            }
            catch (Exception ex)
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
            cmbReason.Text = "-Select-";
            cmbSupplier.Text = "-Select-";
            txtYear.Text = "";
            txtMonth.Text = "";
            txtDay.Text = "";
        }
        public void udfnClear()
        {
            try
            {
                txtProductName.Text = "";
                txtMrp.Text = "";
                txtBatchNo.Text = "";
                txtQuantity.Text = "";
                cmbSupplier.Text = "";
                cmbReason.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbConcernLoad()
        {
            try
            {
                //cmbConcern.Focus();
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
                MainForm objMainForm = new MainForm();
                objMainForm.udfnGetDefaultCompany();
                udfnCmbConcernLoad();
                if (varID == 0)
                {
                    cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                }
                dpEntryDate.MinDate = MainForm.pbFYStartDate;
                dpEntryDate.MaxDate = MainForm.pbCurrentDate;
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_MASTER", "MST_TransactionID IN (0,52) AND MSTID !=0", "MST_DisplayText,MSTID", cmbReason, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                    cmbReason.SelectedValue = -1;
                    dtDamage.TableName = "TRN_DM_Product_AutoComplete";
                    dtDamage.Columns.Add("DM_PRID", typeof(int));
                    dtDamage.Columns.Add("DM_SLID", typeof(int));
                    dtDamage.Columns.Add("DM_RKID", typeof(int));
                    dtDamage.Columns.Add("DM_MRP", typeof(decimal));
                    dtDamage.Columns.Add("DM_DD", typeof(int));
                    dtDamage.Columns.Add("DM_MM", typeof(int));
                    dtDamage.Columns.Add("DM_YYYY", typeof(int));
                    dtDamage.Columns.Add("DM_ExpiryDate", typeof(string));
                    dtDamage.Columns.Add("DM_BatchNo", typeof(string));
                    dtDamage.Columns.Add("DM_Qty", typeof(decimal));
                    dtDamage.Columns.Add("DM_UTID", typeof(string));
                    dtDamage.Columns.Add("DM_STSID", typeof(string));
                    dtDamage.Columns.Add("DM_SPID", typeof(string));
                    dtDamage.Columns.Add("DM_SPSCID", typeof(string));
                    dtDamage.Columns.Add("DM_REASON", typeof(string));

                    dtEmployee.Columns.Add("", typeof(Boolean));
                    dtEmployee.Columns.Add("S.No.", typeof(string));
                    dtEmployee.Columns.Add("Emp. Code", typeof(string));
                    dtEmployee.Columns.Add("Employee Name", typeof(string));
                    dtEmployee.Columns.Add("Employee Category", typeof(string));
                    dtEmployee.Columns.Add("EMPID", typeof(int));
                    dtEmployee.Columns.Add("CT_SINO", typeof(int));

                    dtChecker.Columns.Add("", typeof(Boolean));
                    dtChecker.Columns.Add("S.No.", typeof(string));
                    dtChecker.Columns.Add("Emp. Code", typeof(string));
                    dtChecker.Columns.Add("Employee Name", typeof(string));
                    dtChecker.Columns.Add("Employee Category", typeof(string));
                    dtChecker.Columns.Add("EMPID", typeof(int));
                    dtChecker.Columns.Add("CT_SINO", typeof(int));
                    udfnemployeeload();
                    udfnCheckerload();
                    if (varID == 0)
                    {
                        cmbConcern.Enabled = true;
                        dpEntryDate.Enabled = true;
                        this.ActiveControl = txtProductName;
                        if (fromQueueFlag == 1)
                        {
                            cmbConcern.SelectedValue = varcomID;
                            grbgodown.Enabled = false;
                            chkStatus.Enabled = false;
                            chkStatus.Checked = true; 
                            tps1.Visible = true;
                            tps2.Visible = true;
                            tps3.Visible = true;
                            tst1.Visible = true;
                            tsttotal.Visible = true;
                            tsttotalValue.Visible = true;
                            tstadded.Visible = true;
                            tstaddedvalue.Visible = true;
                            tsbRemaining.Visible = true;
                            tsbRemainingValue.Visible = true;
                            tsttotalValue.Text = Convert.ToString(varTotalProd);
                            tsbRemainingValue.Text = Convert.ToString(varTotalProd);
                            tstaddedvalue.Text = "0";                         }
                        else
                        {
                            grbgodown.Enabled = true;
                            chkStatus.Enabled = true;
                            chkStatus.Checked = false; 
                            tps1.Visible = false;
                            tps2.Visible = false;
                            tps3.Visible = false;
                            tst1.Visible = false;
                            tsttotal.Visible = false;
                            tsttotalValue.Visible = false;
                            tstadded.Visible = false;
                            tstaddedvalue.Visible = false;
                            tsbRemaining.Visible = false;
                            tsbRemainingValue.Visible = false;
                            tsttotalValue.Text = "0";
                            tsbRemainingValue.Text = "0";
                            tstaddedvalue.Text = "0";
                        }
                    }
                    else
                    {
                        cmbConcern.Enabled = false;
                        dpEntryDate.Enabled = false;
                        udfnEdit();
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
            }
        }
        public void udfnemployeeload()
        {
            try
            {
                dtEmployee.Rows.Clear();
                Application.DoEvents();
                grdEmployee.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnEmployeeList(9, "", 0, "", 1, 0, 0);
                objdserv.CloseConnection();
                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtEmployee.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["Employee Code"], objDs.Tables[0].Rows[i]["Employee Name"],
                           objDs.Tables[0].Rows[i]["Employee Category"], objDs.Tables[0].Rows[i]["EMPID"], objDs.Tables[0].Rows[i]["CT_SINO"]);
                    }
                }
                //if (objDs.Tables[0].Rows.Count != 0)
                //{
                //    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                //    {
                //        grdEmployee.Rows.Add(false,Convert.ToString(objDs.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDs.Tables[0].Rows[i]["EMPID"]), Convert.ToString(objDs.Tables[0].Rows[i]["CT_SINO"]),
                //          Convert.ToString(objDs.Tables[0].Rows[i]["Employee Code"]), Convert.ToString(objDs.Tables[0].Rows[i]["Employee Name"]), Convert.ToString(objDs.Tables[0].Rows[i]["Employee Category"]));
                //    }
                //}
                grdEmployee.DataSource = null;
                grdEmployee.DataSource = dtEmployee;
                grdEmployee.Columns[0].HeaderText = "";
                grdEmployee.Columns[0].Width = 30;
                grdEmployee.Columns["S.No."].Width = 40;
                grdEmployee.Columns["S.No."].Visible = false;
                grdEmployee.Columns["Emp. Code"].Width = 75;
                grdEmployee.Columns["Employee Name"].Width = 150;
                grdEmployee.Columns["Employee Category"].Width = 120;
                grdEmployee.Columns["EMPID"].Visible = false;
                grdEmployee.Columns["CT_SINO"].Visible = false;
                grdEmployee.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                grdEmployee.Columns["S.No."].ReadOnly = true;
                grdEmployee.Columns["Emp. Code"].ReadOnly = true;
                grdEmployee.Columns["Employee Name"].ReadOnly = true;
                grdEmployee.Columns["Employee Category"].ReadOnly = true;

                udfnSearchGridHead();


                //for (int i = 1; i < DGV_SearchGridLeft.ColumnCount; i++)
                //{
                //    DGV_SearchGridLeft.Rows[0].Cells[0].Value = "";
                //}
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
        public void udfnCheckerload()
        {
            try
            {
                dtChecker.Rows.Clear();
                Application.DoEvents();
                grdChecker.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnEmployeeList(9, "", 0, "", 1, 0, 0);
                objdserv.CloseConnection();
                if (objDs.Tables[1].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                    {
                        dtChecker.Rows.Add(false, objDs.Tables[1].Rows[i]["S.No."], objDs.Tables[1].Rows[i]["Employee Code"], objDs.Tables[1].Rows[i]["Employee Name"],
                           objDs.Tables[1].Rows[i]["Employee Category"], objDs.Tables[1].Rows[i]["EMPID"], objDs.Tables[1].Rows[i]["CT_SINO"]);
                    }
                }
                //if (objDs.Tables[0].Rows.Count != 0)
                //{
                //    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                //    {
                //        grdEmployee.Rows.Add(false,Convert.ToString(objDs.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDs.Tables[0].Rows[i]["EMPID"]), Convert.ToString(objDs.Tables[0].Rows[i]["CT_SINO"]),
                //          Convert.ToString(objDs.Tables[0].Rows[i]["Employee Code"]), Convert.ToString(objDs.Tables[0].Rows[i]["Employee Name"]), Convert.ToString(objDs.Tables[0].Rows[i]["Employee Category"]));
                //    }
                //}
                grdChecker.DataSource = null;
                grdChecker.DataSource = dtChecker;

                grdChecker.Columns[0].HeaderText = "";
                grdChecker.Columns[0].Width = 30;
                grdChecker.Columns["S.No."].Width = 40;
                grdChecker.Columns["S.No."].Visible = false;
                grdChecker.Columns["Emp. Code"].Width = 75;
                grdChecker.Columns["Employee Name"].Width = 150;
                grdChecker.Columns["Employee Category"].Width = 120;
                grdChecker.Columns["EMPID"].Visible = false;
                grdChecker.Columns["CT_SINO"].Visible = false;
                grdChecker.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                grdChecker.Columns["S.No."].ReadOnly = true;
                grdChecker.Columns["Emp. Code"].ReadOnly = true;
                grdChecker.Columns["Employee Name"].ReadOnly = true;
                grdChecker.Columns["Employee Category"].ReadOnly = true;

                udfnsearchgridhead();
                //for (int i = 1; i < DGV_SearchGridLeft.ColumnCount; i++)
                //{
                //    DGV_SearchGridLeft.Rows[0].Cells[0].Value = "";
                //}
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
        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdEmployee, DGV_SearchGridLeft);
                DGV_SearchGridLeft.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdEmployee.Columns)
                {
                    DGV_SearchGridLeft.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_SearchGridLeft.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_SearchGridLeft.Rows.Clear();
                    DGV_SearchGridLeft.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_SearchGridLeft.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_SearchGridLeft.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_SearchGridLeft.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnsearchgridhead()
        {
            try
            {
                udfngridsearchheading(grdChecker, DGV_SearchGridRight);
                DGV_SearchGridRight.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdChecker.Columns)
                {
                    DGV_SearchGridRight.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_SearchGridRight.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_SearchGridRight.Rows.Clear();
                    DGV_SearchGridRight.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_SearchGridRight.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_SearchGridRight.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_SearchGridRight.Columns[0].ReadOnly = true;
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
        private void udfngridsearchheading(DataGridView dgv1, DataGridView dgv2)
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
        public void udfnclose()
        {
            try
            {
                if (varClose == 0)
                {
                    if (varModifiedFlag == 1)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
                            MainForm.objINV_DamageEntryList.udfnTransList();
                        }
                        else
                        { btnSave.Focus(); }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
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
        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
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
                varDateChange = 0;
                udfnTransferNo();
                grdDamageEntry.Rows.Clear();
                dtDamage.Rows.Clear();
                txttotalitem.Text = "";
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTransferNo()
        {
            if (varID == 0)
            {
                if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                {
                    string vardate = "", varResult = "";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    DataService objDservice = new DataService();
                    vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpEntryDate.Text + "',103)");
                    varResult = objspdservice.udfngetVoucherNo("45", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                    objspdservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    string value = varvalue[0];
                    string[] EntryNo = value.Split('/');
                    if (varResult != "")
                    {
                        txtEntryNo.Text = value;
                    }
                    else
                    {
                        varVoucherSkip = false;
                        if (varDateChange == 0)
                        {
                            udfnvoucheradd();
                        }
                    }
                }
                else
                {
                    txtEntryNo.Text = "";
                }
            }
        }
        public void udfnvoucheradd()
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(75);
                objDServ.CloseConnection();
                txtEntryNo.Text = "";
                DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    varVoucherSkip = true;
                    varClose = 1;
                    udfnclose();
                    MainForm.objCP_Settings = new CP_Settings();
                    //MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                    //MainForm.objCP_Settings.varValues = Convert.ToString(44);
                    MainForm.objCP_Settings.MdiParent = this.ParentForm;
                    MainForm.objCP_Settings.Show();
                    varCloseFlag = 1;
                }
                else { varVoucherSkip = true; }
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
                udfnGridNull((Control)sender);
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
                txtProductName.BackColor = Color.White;
                epDamageEntry.Clear();
                /*
                if (txtProductName.Text == "")
                {
                    epDamageEntry.SetError(txtProductName, "Please enter product name or P.I Code");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name or P.I Code", txtProductName, 5000);
                }
                else
                {
                    txtProductName.BackColor = Color.White;
                    epDamageEntry.Clear();
                }
                */
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
                udfnGridNull((Control)sender);
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
                    udfnBatchDetails();
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
                udfnGridNull((Control)sender);
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
            //try
            //{
            //    varUpDownKey = 0;
            //    /*
            //    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
            //    {
            //        if (lvProduct.Items.Count == 0 || txtProductName.Text == "")
            //        {
            //            txtProductName.Focus();
            //            lvProduct.Visible = false;
            //        }
            //        else
            //        {
            //            lvProduct.Focus();
            //        }
            //        if (lvProduct.Items.Count > 0)
            //        {
            //            lvProduct.Items[0].Selected = true;
            //        }
            //    }
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        txtQuantity.Focus();
            //    }
            //    */
            //    if (e.KeyCode == Keys.F11)
            //    {
            //        if (VarSearchFlag == false)
            //        {
            //            VarSearchFlag = true;
            //            lblProductName.Text = "Search by P.I Code (F11)";
            //            txtProductName.CharacterCasing = CharacterCasing.Upper;
            //        }
            //        else
            //        {
            //            VarSearchFlag = false;
            //            lblProductName.Text = "Search by Product Name (F11)";
            //            txtProductName.CharacterCasing = CharacterCasing.Normal;
            //        }
            //    }
            //    if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
            //    {
            //        txtQuantity.Focus();
            //    }
            //    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
            //    {
            //        DGV_FilterProduct.Focus();
            //    }
            //    if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        DGV_FilterProduct.Focus();
            //        int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
            //        int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
            //        if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            //        {
            //            varUpDownKey = 1;
            //        }
            //        else
            //        {
            //            varUpDownKey = 0;
            //        }
            //        switch (e.KeyCode)
            //        {
            //            case Keys.Up:
            //                RowIndex--;
            //                if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

            //                if (RowIndex != (-1))
            //                {
            //                    if (VarSearchFlag == true)
            //                    {
            //                        txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
            //                    }
            //                    else
            //                    {
            //                        txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
            //                    }
            //                }

            //                txtProductName.Focus();
            //                txtProductName.SelectionStart = txtProductName.Text.Length;
            //                e.Handled = true;
            //                break;
            //            case Keys.Down:
            //                RowIndex++;
            //                if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

            //                if (RowIndex != (DGV_FilterProduct.Rows.Count))
            //                {
            //                    if (VarSearchFlag == true)
            //                    {
            //                        txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
            //                    }
            //                    else
            //                    {
            //                        txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
            //                    }
            //                }

            //                txtProductName.Focus();
            //                txtProductName.SelectionStart = txtProductName.Text.Length;
            //                e.Handled = true;
            //                break;
            //            case Keys.Enter:
            //                {
            //                    if (DGV_FilterProduct.Rows.Count > 0)
            //                    {
            //                        varUpDownKey = 1;
            //                        udfnProductEvent();
            //                        if (varDMFromOther == 0 && fromQueueFlag == 0)
            //                        {
            //                            txtQuantity.Focus();
            //                        }
            //                        else if (fromQueueFlag == 1)
            //                        {
            //                            cmbReason.Focus();
            //                        }
            //                        else
            //                        {
            //                            if (txtMrp.Enabled == true)
            //                            { txtMrp.Focus(); }
            //                            else if (txtBatchNo.Enabled == true)
            //                            { txtBatchNo.Focus(); }
            //                            else { txtQuantity.Focus(); }
            //                        }
            //                        DGV_FilterProduct.Visible = false;
            //                    }
            //                    e.Handled = e.SuppressKeyPress = true;
            //                    break;
            //                }
            //        }
            //        //txtProductName.Focus();
            //        //txtProductName.SelectionStart = txtProductName.Text.Length;
            //        e.Handled = true;
            //        if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
            //        {
            //            //txtProductName.SelectedText = true;
            //            TextBox txtProductName = sender as TextBox;
            //            txtProductName.SelectAll();
            //            e.Handled = true;
            //        }
            //        if (e.KeyCode == Keys.Enter)
            //        {
            //            if (varDMFromOther == 0 && fromQueueFlag == 0)
            //            {
            //                txtQuantity.Focus();
            //            }
            //            else if (fromQueueFlag == 1)
            //            {
            //                cmbReason.Focus();
            //            }
            //            else
            //            {
            //                if (txtMrp.Enabled == true)
            //                { txtMrp.Focus(); }
            //                else if (txtBatchNo.Enabled == true)
            //                { txtBatchNo.Focus(); }
            //                else { txtQuantity.Focus(); }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}



            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                   
                    DGV_FilterProduct.Focus();

                } 
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblProductName.Text = "Search by P.I Code (F11)";
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblProductName.Text = "Search by Product Name (F11)";
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    if (varDMFromOther == 0 && fromQueueFlag == 0)
                    {
                        txtQuantity.Focus();
                    }
                    else if (fromQueueFlag == 1)
                    {
                        cmbSupplier.Focus();
                    }
                    else
                    {
                        if (txtMrp.Enabled == true)
                        { txtMrp.Focus(); }
                        else if (txtBatchNo.Enabled == true)
                        { txtBatchNo.Focus(); }
                        else { txtQuantity.Focus(); }
                    }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterProduct.Focus();
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnProductEvent();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
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
                        if (varDMFromOther == 0 && fromQueueFlag == 0)
                        {
                            txtQuantity.Focus();
                        }
                        else if (fromQueueFlag == 1)
                        {
                            cmbSupplier.Focus();
                        }
                        else
                        {
                            if (txtMrp.Enabled == true)
                            { txtMrp.Focus(); }
                            else if (txtBatchNo.Enabled == true)
                            { txtBatchNo.Focus(); }
                            else { txtQuantity.Focus(); }
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

        private void TxtDay_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtDay.BackColor = Color.LemonChiffon;
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
                txtDay.BackColor = Color.White;
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
                udfnGridNull((Control)sender);
                txtMonth.BackColor = Color.LemonChiffon;
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
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epDamageEntry.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epDamageEntry.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if (txtMonth.Text != "")
                {
                    if (Convert.ToInt32(txtMonth.Text.Trim()) > 12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epDamageEntry.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epDamageEntry.Clear();
                    }
                }
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
                    txtMonth.Focus();
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
                    if (varDMFromOther == 1)
                    {
                        if (expirydateFlag == 1)
                        { txtDay.Focus(); }
                    }
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
                    txtYear.Focus();
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
                udfnGridNull((Control)sender);
                txtYear.BackColor = Color.LemonChiffon;
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
                    if (txtBatchNo.Enabled == true)
                    {
                        txtBatchNo.Focus();
                    }
                    else
                    {
                        txtQuantity.Focus();
                    }
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
                if (expirydateFlag == 1)
                {
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epDamageEntry.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epDamageEntry.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Trim() == "00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epDamageEntry.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epDamageEntry.Clear();
                    }
                }
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
                udfnGridNull((Control)sender);
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
                udfnGridNull((Control)sender);
                varUpDownKey = 0;
                lvProduct.Visible = false;
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
                    string Qty = objValidation.udfnDecimal((txtQuantity.Text).Trim(), varDecimal);
                    txtQuantity.Text = Qty;
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
                    cmbReason.Focus();
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
                udfnGridNull((Control)sender);
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
        public void udfnGridNull(Control skipControl)
        {
            try
            {
                if (skipControl != txtProductName)
                {
                    varUpDownKey = 0;
                    DGV_FilterProduct.DataSource = null;
                    DGV_FilterProduct.Visible = false;
                }
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
                int varflag = 0; string varBlockedSTS = "0";
                if (txtProductName.Text == "")
                {
                    epDamageEntry.SetError(txtProductName, "Please enter product name or P.I Code.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name or P.I Code.", txtProductName, 5000);
                    blnErrorFlag = true;
                }
                if (txtLocation.Text == "")
                {
                    epDamageEntry.SetError(txtLocation, "Invalid location");
                    txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocation.ShowAlways = true;
                    tpLocation.Show("Invalid location", txtLocation, 5000);
                    blnErrorFlag = true;
                }
                if (txtRack.Text == "")
                {
                    epDamageEntry.SetError(txtRack, "Invalid rack");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Invalid rack", txtRack, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbSupplier.Text) == "-Select-")
                {
                    epDamageEntry.SetError(cmbSupplier, "Please select supplier");
                    cmbSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSupplierName.ShowAlways = true;
                    tpSupplierName.Show("Please select supplier", cmbSupplier, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToInt32(cmbReason.SelectedValue) == -1)
                {
                    epDamageEntry.SetError(cmbReason, "Please select reason");
                    cmbReason.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpReason.ShowAlways = true;
                    tpReason.Show("Please select reason", cmbReason, 5000);
                    blnErrorFlag = true;
                }
                //if (txtMrp.Text == "")
                //{
                //    epDamageEntry.SetError(txtMrp, "Invalid mrp");
                //    txtMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpMRP.ShowAlways = true;
                //    tpMRP.Show("Invalid mrp", txtMrp, 5000);
                //    blnErrorFlag = true;
                //}
                //if (txtExpiryDate.Text == "")
                //{
                //    epDamageEntry.SetError(txtExpiryDate, "Invalid expiry date");
                //    txtExpiryDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpExpiryDate.ShowAlways = true;
                //    tpExpiryDate.Show("Invalid expiry date", txtExpiryDate, 5000);
                //    blnErrorFlag = true;
                //}
                //if (txtBatchNo.Text == "")
                //{
                //    epDamageEntry.SetError(txtBatchNo, "Invalid batch no.");
                //    txtBatchNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpBatchNo.ShowAlways = true;
                //    tpBatchNo.Show("Invalid batch no.", txtBatchNo, 5000);
                //    blnErrorFlag = true;
                //}
                if (varDMFromOther == 1)
                {
                    if (expirydateFlag == 1)
                    {
                        if (txtMonth.Text.Trim() == "")
                        {
                            txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            epDamageEntry.SetError(txtMonth, "Please enter month.");
                            blnErrorFlag = true;
                        }
                        if (txtYear.Text.Trim() == "")
                        {
                            txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            epDamageEntry.SetError(txtYear, "Please enter year.");
                            blnErrorFlag = true;
                        }
                    }
                    if (varBatchNoGeneration == 75)
                    {
                        if (txtBatchNo.Text.Trim() == "")
                        {
                            txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            epDamageEntry.SetError(txtBatchNo, "Please enter BatchNo.");
                            tpBatchNo.ShowAlways = true;
                            tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                            blnErrorFlag = true;
                        }
                    }
                    if (varMRPFlag == 1 && (txtMrp.Text.Trim() == "" || Convert.ToDecimal(txtMrp.Text) == 0))
                    {
                        txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epDamageEntry.SetError(txtMrp, "Please enter MRP.");
                        blnErrorFlag = true;
                    }
                }
                if (varDMFromOther == 0 && fromQueueFlag == 0 )
                {
                    if (txtStockQty.Text.Trim() == "" || Convert.ToDecimal(txtStockQty.Text.Trim()) == 0)
                    {
                        epDamageEntry.SetError(txtStockQty, "Invalid stock qty");
                        txtStockQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStockQty.ShowAlways = true;
                        tpStockQty.Show("Invalid stock qty", txtStockQty, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtQuantity.Text).Trim() != "")
                {
                    if (varDMFromOther == 0 && fromQueueFlag == 0 )
                    {
                        if (Convert.ToDecimal(txtStockQty.Text.Trim()) >= Convert.ToDecimal(txtQuantity.Text.Trim()))
                        {
                            epDamageEntry.Clear();
                            txtQuantity.BackColor = Color.White;
                        }
                        else
                        {
                            epDamageEntry.SetError(txtQuantity, "Please enter valid quantity");
                            txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpQuantity.ShowAlways = true;
                            tpQuantity.Show("Please enter valid quantity", txtQuantity, 5000);
                            blnErrorFlag = true;
                        }
                    }
                }
                else
                {
                    epDamageEntry.SetError(txtQuantity, "Please enter quantity");
                    txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quantity", txtQuantity, 5000);
                    blnErrorFlag = true;
                }
                if (cmbSupplier.Text != "-Select-")
                {
                    string varSupplier = Convert.ToString(cmbSupplier.SelectedValue);
                    string[] Result = varSupplier.Split('-');
                    lblSupplierCode.Text = Result[0];
                    lblScheduleCode.Text = Result[1];
                }
                if (cmbSupplier.Text != "-Select-")
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 40;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblScheduleCode.Text);
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(objMR_Supplier);
                    objDserv.CloseConnection();
                    if (objDsSupplierId != null)
                    {
                        if (objDsSupplierId.Tables.Count > 0)
                        {
                            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                            {
                                varBlockedReason = Convert.ToString(objDsSupplierId.Tables[0].Rows[0]["Reason"].ToString());
                                varBlockedSupplier = Convert.ToString(objDsSupplierId.Tables[0].Rows[0]["STSID"].ToString());
                            }
                        }
                    }
                }
                if (blnErrorFlag == false)
                {
                    lvProduct.Visible = false;
                    /////IF add any additional column in the grdDamageEntry then Change the upcoming row.cells value[] /////
                    foreach (DataGridViewRow row in grdDamageEntry.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                        {
                            string gridValue1 = row.Cells[16].Value.ToString();     //PRID
                            string gridValue2 = row.Cells[17].Value.ToString();     //SLID
                            string gridValue3 = row.Cells[18].Value.ToString();     //RKID
                            string gridValue4 = row.Cells[5].Value.ToString();      //MRP
                            string gridValue5 = row.Cells[6].Value.ToString();      //EXPIRYDATE
                            string gridValue6 = row.Cells[7].Value.ToString();      //BATCHNO
                            string gridValue7 = row.Cells[20].Value.ToString();     //SUPPLIERID
                            string gridValue8 = row.Cells[11].Value.ToString();     //SUPPLIERID

                            if (gridValue1.ToUpper() == (lblProduct.Text).Trim().ToUpper() && gridValue2.ToUpper() == (varSLID).Trim().ToUpper() && gridValue3.ToUpper() == (varRKID).Trim().ToUpper() && gridValue4.ToUpper() == (txtMrp.Text).Trim().ToUpper() && gridValue5.ToUpper() == (txtExpiryDate.Text).Trim().ToUpper() && gridValue6.ToUpper() == (txtBatchNo.Text).Trim().ToUpper() && gridValue7.ToUpper() == (lblSupplierCode.Text).Trim().ToUpper() && gridValue8.ToUpper() == (cmbReason.Text).Trim().ToUpper())
                            {
                                varflag = 1;
                            }
                        }
                    }
                    if (varflag == 0)
                    {
                        if (txtQuantity.Text != "")
                        {
                            string Qty = objValidation.udfnDecimal((txtQuantity.Text).Trim(), varDecimal);
                            txtQuantity.Text = Qty;
                        }
                        udfnAdd();
                        if (fromQueueFlag == 1)
                        {
                            grdDamageEntry.Columns["clmQuantity"].ReadOnly = true;
                            grdDamageEntry.Columns["clmQuantity"].DefaultCellStyle.BackColor = Color.White;
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
                if (grdDamageEntry.Rows.Count > 0)
                {
                    cmbConcern.Enabled = false;
                    chkDamageOtherLoc.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                    chkDamageOtherLoc.Enabled = true;
                }
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
                    objDS = objspservice.udfnproductDamage(2, varID, 0, 0, 0, 0, "", "", "", 0, "", 0);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["ConcernID"].ToString();
                            dpEntryDate.Text = objDS.Tables[0].Rows[0]["Transfer Date"].ToString().Replace("''", "'");
                            txtEntryNo.Text = objDS.Tables[0].Rows[0]["Transfer No."].ToString().Replace("''", "'");
                            txtRemark.Text = objDS.Tables[0].Rows[0]["Remarks"].ToString().Replace("''", "'");
                            varSLID = objDS.Tables[0].Rows[0]["SLID"].ToString().Replace("''", "'");
                            varRKID = objDS.Tables[0].Rows[0]["RKID"].ToString().Replace("''", "'");
                            varSPID = objDS.Tables[0].Rows[0]["Supplier ID"].ToString().Replace("''", "'");
                            lblProduct.Text = objDS.Tables[0].Rows[0]["PRID"].ToString().Replace("''", "'");
                            varDMFromOther = Convert.ToInt32(objDS.Tables[0].Rows[0]["DM_FromOtherLoc"]);
                        }
                        if (varDMFromOther == 0 && fromQueueFlag == 0)
                        { chkDamageOtherLoc.Checked = false; chkDamageOtherLoc.Enabled = false; }
                        else { chkDamageOtherLoc.Checked = true; chkDamageOtherLoc.Enabled = false; }
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                            {
                                //grdDamageEntry.Rows.Add(grdDamageEntry.Rows.Count + 1, varPICode, txtProductName.Text.Trim(), txtMrp.Text.Trim(), txtExpiryDate.Text.Trim(), txtBatchNo.Text.Trim(), txtQuantity.Text.Trim(), varUnitSymbol, txtsuppliername.Text.Trim(), Day, Month, Year, (lblProduct.Text).Trim(), varSLID, varRKID, varUTID, (lblSupplierCode.Text).Trim(), (lblScheduleCode.Text).Trim());
                                grdDamageEntry.Rows.Add(Convert.ToString(objDS.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[0].Rows[i]["PICode"]), Convert.ToString(objDS.Tables[0].Rows[i]["Product"]), Convert.ToString(objDS.Tables[0].Rows[i]["Location"]), Convert.ToString(objDS.Tables[0].Rows[i]["Rack"]),
                                 Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDS.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDS.Tables[0].Rows[i]["Batch No"]), Convert.ToDecimal(objDS.Tables[0].Rows[i]["Stock Qty"]), Convert.ToDecimal(objDS.Tables[0].Rows[i]["QTY"]), Convert.ToString(objDS.Tables[0].Rows[i]["Unit"]), Convert.ToString(objDS.Tables[0].Rows[i]["REASON"]),
                                 Convert.ToString(objDS.Tables[0].Rows[i]["Supplier"]), Convert.ToString(objDS.Tables[0].Rows[i]["Day"]), Convert.ToString(objDS.Tables[0].Rows[i]["Month"]), Convert.ToString(objDS.Tables[0].Rows[i]["Year"]), Convert.ToString(objDS.Tables[0].Rows[i]["PRID"]), Convert.ToString(objDS.Tables[0].Rows[i]["SLID"]), Convert.ToString(objDS.Tables[0].Rows[i]["RKID"]),
                                 Convert.ToString(objDS.Tables[0].Rows[i]["UnitID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Supplier ID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Schedule ID"]), Convert.ToString(objDS.Tables[0].Rows[i]["UT_Decimal"]), Convert.ToString(objDS.Tables[0].Rows[i]["BlockedReason"]), Convert.ToString(objDS.Tables[0].Rows[i]["STSID"]));

                                dtDamage.Rows.Add(Convert.ToInt32(objDS.Tables[0].Rows[i]["PRID"]), Convert.ToString(objDS.Tables[0].Rows[i]["SLID"]), Convert.ToString(objDS.Tables[0].Rows[i]["RKID"]), Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDS.Tables[0].Rows[i]["Day"]), Convert.ToString(objDS.Tables[0].Rows[i]["Month"]), Convert.ToString(objDS.Tables[0].Rows[i]["Year"]), Convert.ToString(objDS.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDS.Tables[0].Rows[i]["Batch No"]), Convert.ToDecimal(objDS.Tables[0].Rows[i]["QTY"]), Convert.ToString(objDS.Tables[0].Rows[i]["UnitID"]), 20, Convert.ToString(objDS.Tables[0].Rows[i]["Supplier ID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Schedule ID"]), Convert.ToString(objDS.Tables[0].Rows[i]["ReasonID"]));

                                //dtDamage.Rows.Add(Convert.ToInt32((lblProduct.Text).Trim()), Convert.ToInt32(varSLID), Convert.ToInt32(varRKID), Convert.ToDouble(txtMrp.Text.Trim()), Convert.ToInt32(Day), Convert.ToInt32(Month), Convert.ToInt32(Year), txtExpiryDate.Text.Trim(), txtBatchNo.Text.Trim(), txtQuantity.Text.Trim(), varUTID, 20, lblSupplierCode.Text.Trim(), lblScheduleCode.Text.Trim());

                                grdDamageEntry.Columns["clmdsno"].Width = 50;

                                if (Convert.ToString(objDS.Tables[0].Rows[i]["STSID"]) == "98")
                                {
                                    grdDamageEntry.Rows[i].Cells["clmSupplier"].Style.BackColor = Color.LightPink;
                                }
                            }
                            for (int i = 0; i < grdEmployee.Rows.Count; i++)
                            {
                                for (int j = 0; j < objDS.Tables[1].Rows.Count; j++)
                                {
                                    if (Convert.ToString(grdEmployee.Rows[i].Cells["EMPID"].Value) == Convert.ToString(objDS.Tables[1].Rows[j]["EMPID"]))
                                    {
                                        grdEmployee.Rows[i].Cells[0].Value = true;
                                    }
                                }
                            }
                            for (int i = 0; i < grdChecker.Rows.Count; i++)
                            {
                                for (int j = 0; j < objDS.Tables[2].Rows.Count; j++)
                                {
                                    if (Convert.ToString(grdChecker.Rows[i].Cells["EMPID"].Value) == Convert.ToString(objDS.Tables[2].Rows[j]["EMPID"]))
                                    {
                                        grdChecker.Rows[i].Cells[0].Value = true;
                                    }
                                }
                            }
                        }
                        ((DataGridViewTextBoxColumn)grdDamageEntry.Columns["clmQuantity"]).MaxInputLength = 8;
                    }
                    if (varStatusID != 6)
                    {
                        grdDamageEntry.ReadOnly = true;
                        grdDamageEntry.Columns["clmremove"].Visible = false;
                        grdEmployee.ReadOnly = true;
                        grdChecker.ReadOnly = true;
                        btnSave.Enabled = false;
                        chkStatus.Checked = true; chkStatus.Enabled = false;
                        txtProductName.Enabled = false;
                        txtQuantity.Enabled = false;
                        txtQuantity.Enabled = false;
                        btnAdd.Enabled = false;
                        txtRemark.Enabled = false;
                        this.ActiveControl = btnClose;
                        DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                        GrdDamageEntry_DataBindingComplete(grdDamageEntry, args);
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
                grdEmployee.ClearSelection();
                grdDamageEntry.ClearSelection();
                grdChecker.ClearSelection();
                this.grdEmployee.Sort(this.grdEmployee.Columns[0], ListSortDirection.Descending);
                this.grdChecker.Sort(this.grdChecker.Columns[0], ListSortDirection.Descending);
            }
        }
        private void GrdDamageEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int PRID = 0, SLID = 0;
                string ExpiryDate = "", BatchNo = "", SPID = "", RKID = "", MRP = "";
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
                                MRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdDamageEntry.SelectedRows[0].Cells["clmmrp"].Value)));
                                ExpiryDate = Convert.ToString(grdDamageEntry.SelectedRows[0].Cells["clmexpirydate"].Value);
                                BatchNo = Convert.ToString(grdDamageEntry.SelectedRows[0].Cells["clmBatchNo"].Value);
                                SPID = Convert.ToString(grdDamageEntry.SelectedRows[0].Cells["clmSPID"].Value);
                                grdDamageEntry.Rows.RemoveAt(this.grdDamageEntry.SelectedRows[0].Index);
                                for (int i = 0; i < grdDamageEntry.RowCount; i++)
                                {
                                    grdDamageEntry.Rows[i].Cells["clmdsno"].Value = i + 1;
                                }
                                varModifiedFlag = 1;
                                for (int i = 0; i < dtDamage.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtDamage.Rows[i]["DM_PRID"]) == Convert.ToInt32(PRID) && Convert.ToInt32(dtDamage.Rows[i]["DM_SLID"]) == SLID && Convert.ToString(dtDamage.Rows[i]["DM_RKID"]) == RKID && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtDamage.Rows[i]["DM_MRP"]))) == MRP && Convert.ToString(dtDamage.Rows[i]["DM_ExpiryDate"]) == ExpiryDate && Convert.ToString(dtDamage.Rows[i]["DM_BatchNo"]) == BatchNo && Convert.ToString(dtDamage.Rows[i]["DM_SPID"]) == SPID)
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
                if (grdDamageEntry.Rows.Count > 0)
                {
                    cmbConcern.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                }
            }
        }
        private void TxtRemark_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
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
                    chkStatus.Focus();
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
                udfnGridNull((Control)sender);
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
                varEmployeeId = "";
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
                for (int i = 0; i < grdDamageEntry.Rows.Count; i++)
                {
                    if (Convert.ToString(grdDamageEntry.Rows[i].Cells["clmQuantity"].Value) == "" || Convert.ToDecimal(grdDamageEntry.Rows[i].Cells["clmQuantity"].Value) == 0)
                    {
                        blnErrorFlag = true; varErrQty = "1";
                        grdDamageEntry.Rows[i].Cells["clmQuantity"].Style.BackColor = Color.LightPink;
                    }
                    else
                    {
                        grdDamageEntry.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                        if (fromQueueFlag == 1)
                        {
                            grdDamageEntry.Rows[i].Cells["clmQuantity"].Style.BackColor = Color.White;
                        }
                        else
                        {
                            grdDamageEntry.Rows[i].Cells["clmQuantity"].Style.BackColor = Color.PaleGreen;
                        }
                    }
                    if (Convert.ToString(grdDamageEntry.Rows[i].Cells["clmBlockedSupplier"].Value) == "98")
                    {
                        varBlockedSupplier = "98";
                    }
                }
                if (grdDamageEntry.Rows.Count < 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if (varErrQty == "1")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                string varTeller = "0", varChecker = "0";
                if (grdEmployee.Rows.Count > 0)
                {
                    grdEmployee.DataSource = dtEmployee;
                    for (int i = 0; i < grdEmployee.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdEmployee.Rows[i].Cells[0].Value) == true)
                        {
                            varTeller = "1";
                            if (varEmployeeId == "")
                            {
                                varEmployeeId = Convert.ToString(grdEmployee.Rows[i].Cells["EMPID"].Value) + '~' + "1";
                            }
                            else
                            {
                                varEmployeeId = varEmployeeId + ',' + Convert.ToString(grdEmployee.Rows[i].Cells["EMPID"].Value) + '~' + "1";
                            }
                        }
                    }
                }
                if (grdChecker.Rows.Count > 0)
                {
                    grdChecker.DataSource = dtChecker;
                    for (int i = 0; i < grdChecker.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdChecker.Rows[i].Cells[0].Value) == true)
                        {
                            varChecker = "2";
                            varEmployeeId = varEmployeeId + ',' + Convert.ToString(grdChecker.Rows[i].Cells["EMPID"].Value) + '~' + "2";
                        }
                    }
                }
                if (chkStatus.Checked == true)
                {
                    if (varTeller == "0")
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(101);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnErrorFlag = true;
                    }
                    if (varChecker == "0")
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(103);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnErrorFlag = true;
                    }
                }
                //if (varEmployeeId=="")
                //{
                //    SPDataService objDServ = new SPDataService();
                //    string varMessage = objDServ.udfnGetMessages(101);
                //    objDServ.CloseConnection();
                //    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    blnErrorFlag = true;
                //}
                if (varBlockedSupplier == "98")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(134);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToInt32(tsbRemainingValue.Text) != 0 && fromQueueFlag == 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(194);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    epDamageEntry.Clear();
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
                btnSave.Enabled = false;
                if (chkStatus.Checked == true)
                {
                    MainForm.objCP_Verify = new CP_Verify();
                    MainForm.objCP_Verify.ShowDialog();
                    varUserID = MainForm.objCP_Verify.varUserId;
                }
                else
                {
                    varUserID = "3";
                }
                if (varUserID != "")
                {
                    SPDataService objspservice = new SPDataService();
                    string varResult = "",
                    varoriginator = ""; int varType = 0;
                    if (btnSave.Text == "Save as Draft")
                    {
                        varoriginator = "Damage Entry Creation";
                        varType = 0;
                    }
                    else
                    {
                        varoriginator = "Damage Entry Updation";
                        varType = 0;
                    }
                    int varStatus = 0;
                    if (chkStatus.Checked == true)
                    {
                        varStatus = 20;
                    }
                    else
                    {
                        varStatus = 6;
                    }
                    if (fromQueueFlag == 1) {

                        varoriginator = "Damage Entry Creation Against Outward";
                        varType = 0;
                    }

                    TRN_Damage objTRN_Damage = new TRN_Damage();
                    objTRN_Damage.ViewType = varType;
                    objTRN_Damage.paraDamageEntryID = varID;
                    objTRN_Damage.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_Damage.paraTransferDate = dpEntryDate.Text;
                    objTRN_Damage.paraLocationID = Convert.ToInt32(varSLID);
                    objTRN_Damage.paraRemarks = txtRemark.Text.Trim();
                    objTRN_Damage.paraStatusId = varStatus;
                    objTRN_Damage.paraOriginator = varoriginator;
                    objTRN_Damage.paraDamageEntry = dtDamage;
                    objTRN_Damage.paraEmployeeId = varEmployeeId;
                    objTRN_Damage.paraDMFromOtherLoc = varDMFromOther;
                    objTRN_Damage.paraQueid = varQueid;
                    varResult = objspservice.udfnDamageEntry(objTRN_Damage);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnClear();
                        varModifiedFlag = 0;
                        try
                        {
                            string DMID = "0";
                            if (varID == 0)
                            {
                                DMID = varvalue[2];
                                DmUpdatevalue = varvalue[2];
                                string varQrcode = varvalue[3];
                                var varImgMemoryStream = new MemoryStream();
                                QrcodeImg.Text = varQrcode;
                                QrcodeImg.Image.Save(varImgMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
                                varobjBarCodeByte = varImgMemoryStream.GetBuffer();
                                objTRN_Damage.ViewType = 3;
                                objTRN_Damage.paraDamageEntryID = Convert.ToInt32(DmUpdatevalue);
                                objTRN_Damage.paraQrimg = (varobjBarCodeByte);
                                varResult = objspservice.udfnDamageEntry(objTRN_Damage);
                                objspservice.CloseConnection();
                                if(fromQueueFlag == 1)
                                {
                                    MainForm.objINV_DamageEntryQueue.udfnList();
                                }
                            }
                            else
                            {
                                DMID = Convert.ToString(varID);
                            }
                            DialogResult result1;
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(87);
                            objDServ.CloseConnection();
                            result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.Yes)
                            {
                                string varHeader = "";
                                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_Damage_Supplier.rpt");
                                varHeader = "Transaction Wise Damage Products List";

                                objBillreport.SetParameterValue("paraDamageEntryID", Convert.ToInt32(DMID));
                                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                                objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                                objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                                objValidation.CrySqlConnection(objBillreport);

                                MainForm.objReportLoad = new ReportLoad();
                                MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                MainForm.objReportLoad.Text = varHeader;
                                MainForm.objReportLoad.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        {
                            objError = new DataError();
                            objError.WriteFile(ex);
                        }
                        MainForm.objINV_DamageEntryList.udfnTransList();
                        this.Close();
                    }
                    else
                    {
                        epDamageEntry.Clear();
                        txtProductName.BackColor = Color.White;
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
                                string varRack = varSecondList[4];
                                for (int j = 0; j < grdDamageEntry.RowCount; j++)
                                {
                                    if (Convert.ToString(grdDamageEntry.Rows[j].Cells["clmPRID"].Value) == varPRID && Convert.ToString(grdDamageEntry.Rows[j].Cells["clmmrp"].Value) == varMRP && Convert.ToString(grdDamageEntry.Rows[j].Cells["clmExpirydate"].Value) == varExpiryDate && Convert.ToString(grdDamageEntry.Rows[j].Cells["clmbatchno"].Value) == varBatchNo && Convert.ToString(grdDamageEntry.Rows[j].Cells["clmRKID"].Value) == varRack)
                                    {
                                        grdDamageEntry.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
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
                btnSave.Enabled = true;
            }
        }
        private void BtnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
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
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose.Focus();
                    udfnclose();
                }
                if (btnSave.Enabled == true)
                {
                    if (e.KeyCode == Keys.F5)
                    {
                        btnSave.Focus();
                        BtnSave_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
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

        }
        private void TxtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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
                if (varUpDownKey == 0)
                {
                    txtLocation.Text = "";
                    txtRack.Text = "";
                    txtMrp.Text = "";
                    txtExpiryDate.Text = "";
                    txtBatchNo.Text = "";
                    txtStockQty.Text = "";
                    txtQuantity.Text = "";
                    cmbSupplier.Text = "-Select-"; cmbSupplier.DataSource = null;
                    cmbReason.Text = "-Select-";
                    int varViewType = 0;
                    if (varDMFromOther == 0 && fromQueueFlag == 0)
                    { varViewType = 38; }
                    else { varViewType = 85; }

                    if (fromQueueFlag == 1) {
                        varViewType = 90;
                    }

                    //lvProduct.Items.Clear();
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = varViewType;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        if (fromQueueFlag == 1)
                        {
                            objMR_Product.paraId = varQueid;
                        }
                        else
                        {
                            objMR_Product.paraId = varID;
                        }
                            objMR_Product.paraDamageEntry = dtDamage;
                        objMR_Product.paraUserLocations = MainForm.pbUserMappedLocationIds;
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        if (VarSearchFlag == true)
                        {
                            objMR_Product.paraPicode = txtProductName.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraProductName = txtProductName.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {   /*
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["Product"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["SL_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["STK_MRP"].ToString(), objDs.Tables[0].Rows[i]["STK_ExpiryDate"].ToString(), objDs.Tables[0].Rows[i]["STK_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["QTY"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString(), objDs.Tables[0].Rows[i]["PR_UTID"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["STK_RKID"].ToString(), objDs.Tables[0].Rows[i]["UT_Decimal"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        objList.UseItemStyleForSubItems = false;
                                        objList.SubItems[3].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        lvProduct.Items.Add(objList);
                                    }
                                    lvProduct.Visible = true;
                                    lvProduct.BringToFront();
                                    lvProduct.Columns[0].Width = 150;
                                    lvProduct.Columns[1].Width = 0;
                                    lvProduct.Columns[2].Width = 0;
                                    lvProduct.Columns[3].Width = 0;
                                    lvProduct.Columns[4].Width = 80;
                                    lvProduct.Columns[5].Width = 80;
                                    lvProduct.Columns[6].Width = 70;
                                    lvProduct.Columns[7].Width = 90;
                                    lvProduct.Columns[8].Width = 60;
                                    lvProduct.Columns[9].Width = 80;
                                    lvProduct.Columns[10].Width = 0;
                                    lvProduct.Columns[11].Width = 0;
                                    lvProduct.Columns[12].Width = 0;
                                    lvProduct.Columns[13].Width = 80;
                                    lvProduct.Columns[14].Width = 0;
                                    lvProduct.Columns[15].Width = 0;
                                    if (VarSearchFlag == false)
                                    {
                                        lvProduct.Columns[2].Width = 320;
                                        lvProduct.Columns[3].Width = 0;
                                    }
                                    else
                                    {
                                        lvProduct.Columns[2].Width = 0;
                                        lvProduct.Columns[3].Width = 320;
                                    } 
                                    */
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    if (varDMFromOther == 0 ||  fromQueueFlag == 1  )
                                    {
                                        DGV_FilterProduct.Columns["STK_RKID"].Visible = false;
                                        DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                        DGV_FilterProduct.Columns["STK_SLID"].Visible = false;
                                        DGV_FilterProduct.Columns["STK_Qty"].Visible = false;
                                        DGV_FilterProduct.Columns["SLID"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                        DGV_FilterProduct.Columns["SL_ShortName"].DisplayIndex = 3;
                                        DGV_FilterProduct.Columns["RK_ShortName"].DisplayIndex = 4;
                                        DGV_FilterProduct.Columns["STK_MRP"].DisplayIndex = 5;
                                        DGV_FilterProduct.Columns["STK_ExpiryDate"].DisplayIndex = 6;
                                        DGV_FilterProduct.Columns["Shelf Life"].DisplayIndex = 7;
                                        DGV_FilterProduct.Columns["MFD Date"].DisplayIndex = 8;
                                        DGV_FilterProduct.Columns["STK_BatchNo"].DisplayIndex = 9;
                                        DGV_FilterProduct.Columns["QTY"].DisplayIndex = 10;
                                        DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 11;
                                        DGV_FilterProduct.Columns["Retail Rate"].DisplayIndex = 12;
                                        DGV_FilterProduct.Columns["UPP"].DisplayIndex = 13;
                                        DGV_FilterProduct.Columns["RK_ShortName"].HeaderText = "Rack";
                                        DGV_FilterProduct.Columns["STK_MRP"].HeaderText = "MRP";
                                        DGV_FilterProduct.Columns["STK_ExpiryDate"].HeaderText = "Expiry Date";
                                        DGV_FilterProduct.Columns["STK_BatchNo"].HeaderText = "Batch No.";
                                        DGV_FilterProduct.Columns["QTY"].HeaderText = "Quantity";
                                        DGV_FilterProduct.Columns["SL_ShortName"].HeaderText = "Location";
                                        DGV_FilterProduct.Columns["MFD Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        DGV_FilterProduct.Columns["Retail Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    }
                                    if (fromQueueFlag == 1)
                                    {
                                        DGV_FilterProduct.Columns["DamageReason"].Visible = false;
                                    }

                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_UTID"].Visible = false;
                                    DGV_FilterProduct.Columns["Product"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                                    if (VarSearchFlag == false)
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 2;
                                    }
                                    else
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 2;
                                    }
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                    //lvProduct.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                                //lvProduct.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                            //lvProduct.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
                        //lvProduct.Visible = false;
                        //lvProduct.Items.Clear();
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

            }
        }

        private void DpEntryDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    chkDamageOtherLoc.Focus();
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
                    /*
                    ListViewItem selectedItem = lvProduct.SelectedItems[0];
                    varPICode = selectedItem.SubItems[0].Text;
                    txtProductName.Text = selectedItem.SubItems[2].Text;
                    varProductName = selectedItem.SubItems[3].Text;
                    txtLocation.Text = selectedItem.SubItems[4].Text;
                    txtRack.Text = selectedItem.SubItems[5].Text;
                    txtMrp.Text = selectedItem.SubItems[6].Text;
                    txtExpiryDate.Text = selectedItem.SubItems[7].Text;
                    txtBatchNo.Text = selectedItem.SubItems[8].Text;
                    txtStockQty.Text = selectedItem.SubItems[9].Text;
                    lblProduct.Text = selectedItem.SubItems[10].Text;
                    varSLID = selectedItem.SubItems[11].Text;
                    varUTID = selectedItem.SubItems[12].Text;
                    lblUnit.Text = selectedItem.SubItems[13].Text;
                    varUnitSymbol = selectedItem.SubItems[13].Text;
                    varMRP = selectedItem.SubItems[6].Text;
                    varExpiryDate = selectedItem.SubItems[7].Text;
                    varBatchNo = selectedItem.SubItems[8].Text;
                    varProductCode = selectedItem.SubItems[10].Text;
                    varRKID = selectedItem.SubItems[14].Text;
                    varDecimal =Convert.ToInt32(selectedItem.SubItems[15].Text);
                    */
                    txtQuantity.Enabled = true;
                    if (varDMFromOther == 0 && fromQueueFlag == 0)
                    {
                        varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                        varProductName = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                        txtLocation.Text = DGV_FilterProduct.SelectedRows[0].Cells["SL_ShortName"].Value.ToString();
                        txtRack.Text = DGV_FilterProduct.SelectedRows[0].Cells["RK_ShortName"].Value.ToString();
                        txtMrp.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                        txtExpiryDate.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                        txtBatchNo.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_BatchNo"].Value.ToString();
                        txtStockQty.Text = DGV_FilterProduct.SelectedRows[0].Cells["QTY"].Value.ToString();
                        lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                        varSLID = DGV_FilterProduct.SelectedRows[0].Cells["STK_SLID"].Value.ToString();
                        varUTID = DGV_FilterProduct.SelectedRows[0].Cells["PR_UTID"].Value.ToString();
                        lblUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                        varUnitSymbol = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                        varMRP = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                        varExpiryDate = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                        varBatchNo = DGV_FilterProduct.SelectedRows[0].Cells["STK_BatchNo"].Value.ToString();
                        varProductCode = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                        varRKID = DGV_FilterProduct.SelectedRows[0].Cells["STK_RKID"].Value.ToString();
                        varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                        txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    }
                    else if (fromQueueFlag == 1) {

                        varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                        varProductName = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                        txtLocation.Text = DGV_FilterProduct.SelectedRows[0].Cells["SL_ShortName"].Value.ToString();
                        txtRack.Text = DGV_FilterProduct.SelectedRows[0].Cells["RK_ShortName"].Value.ToString();
                        txtMrp.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                        txtExpiryDate.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                        txtBatchNo.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_BatchNo"].Value.ToString();
                        txtStockQty.Text = "0";
                        lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                        varSLID = DGV_FilterProduct.SelectedRows[0].Cells["STK_SLID"].Value.ToString();
                        varUTID = DGV_FilterProduct.SelectedRows[0].Cells["PR_UTID"].Value.ToString();
                        lblUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                        varUnitSymbol = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                        varMRP = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                        varExpiryDate = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                        varBatchNo = DGV_FilterProduct.SelectedRows[0].Cells["STK_BatchNo"].Value.ToString();
                        varProductCode = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                        varRKID = DGV_FilterProduct.SelectedRows[0].Cells["STK_RKID"].Value.ToString();
                        varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                        txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                        txtQuantity.Text = DGV_FilterProduct.SelectedRows[0].Cells["QTY"].Value.ToString();
                        cmbReason.SelectedValue= Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["DamageReason"].Value.ToString());
                        cmbReason.Enabled = false;
                        txtQuantity.Enabled = false;
                    }
                    else
                    {
                        varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                        varProductName = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();

                        txtLocation.Text = "None"; txtRack.Text = "None";
                        txtMrp.Text = ""; txtExpiryDate.Text = ""; txtBatchNo.Text = ""; txtStockQty.Text = "";
                        varMRP = ""; varExpiryDate = ""; varBatchNo = ""; varSLID = "0";

                        lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                        varUTID = DGV_FilterProduct.SelectedRows[0].Cells["PR_UTID"].Value.ToString();
                        lblUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                        varUnitSymbol = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();

                        varProductCode = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                        varRKID = "0";
                        txtStockQty.Text = "0";
                        //varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                        txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                        udfnProductWiseDetails();
                    }
                    udfnSupplierLoad();
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
                txtLocation.BackColor = SystemColors.Control;
                txtRack.BackColor = SystemColors.Control;
                txtMrp.BackColor = SystemColors.Control;
                txtExpiryDate.BackColor = SystemColors.Control;
                txtBatchNo.BackColor = SystemColors.Control;
                txtStockQty.BackColor = SystemColors.Control;
                txtQuantity.BackColor = Color.White;
                cmbSupplier.BackColor = Color.White;
            }
        }
        public void udfnBatchDetails()
        {
            try
            {
                decimal varMRP = 0; string varExpiryDate = ""; int ExpiryDateFlag = 0; int AutoBatchFlag = 0;
                if (Convert.ToString(txtMrp.Text) != "")
                {
                    varMRP = Convert.ToDecimal(txtMrp.Text);
                }
                if (varDMFromOther == 0 ||  fromQueueFlag == 1)
                {
                    varExpiryDate = txtExpiryDate.Text;
                    ExpiryDateFlag = 1;
                }
                else
                {
                    if (txtDay.Text.Trim() != "" && txtMonth.Text.Trim() != "" && txtYear.Text.Trim() != "")
                    {
                        varExpiryDate = txtDay.Text.Trim() + "/" + txtMonth.Text.Trim() + "/20" + txtYear.Text.Trim();
                        ExpiryDateFlag = 1;
                    }
                }
                if (expirydateFlag == 1 && varBatchNoGeneration == 74 && varMRPFlag == 1)
                {
                    AutoBatchFlag = 1;
                }
                if (AutoBatchFlag == 1)
                {
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 31;
                    objMR_Master.paraMRP = varMRP;
                    objMR_Master.ParaExpiryDate = varExpiryDate;
                    objMR_Master.paraProductId = Convert.ToInt32(lblProduct.Text);
                    DataSet objDs = new DataSet();
                    SPDataService objdserv = new SPDataService();
                    objDs = objdserv.udfnMaster(objMR_Master);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                txtBatchNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["BatchNo"]);
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
        public void udfnProductWiseDetails()
        {
            try
            {
                string varRMProduction = "0", varPrcategory = "0", varBatchNoFlag = "0";
                varBatchNoGeneration = 0; expirydateFlag = 0; varMRPFlag = 0;
                int varRMProductionFlag = 0, varShelflife = 0;
                if (lblProduct.Text != "0")
                {
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 1;
                    objMR_Product.ParaProductCode = Convert.ToInt32(lblProduct.Text);
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objspservice.udfnproductmasterlist(objMR_Product);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varBatchNoFlag = Convert.ToString(objDS.Tables[0].Rows[0]["BATCHNO"].ToString());
                            varBatchNoGeneration = Convert.ToInt32(objDS.Tables[0].Rows[0]["BARCODE GENERATION"].ToString());
                            varRMProduction = Convert.ToString(objDS.Tables[0].Rows[0]["RM PRODUCTION"].ToString());
                            varPrcategory = Convert.ToString(objDS.Tables[0].Rows[0]["PRODUCTCATEGORY"].ToString());
                            varShelflife = Convert.ToInt32(objDS.Tables[0].Rows[0]["SHELFLIFE"].ToString());
                            expirydateFlag = Convert.ToInt32(objDS.Tables[0].Rows[0]["SHELFLIFE"].ToString());
                            varMRPFlag = Convert.ToInt32(objDS.Tables[0].Rows[0]["PR_MRPflag"].ToString());
                            // Shelflife = Convert.ToString(objDS.Tables[0].Rows[0]["PRODUCT EXPIRY"].ToString());
                            // ProductShelflifeValue = Convert.ToString(objDS.Tables[0].Rows[0]["SHELFLIFE VALUE"].ToString());
                            //ProductShelflifeType = Convert.ToString(objDS.Tables[0].Rows[0]["SHELF LIFE TYPE"].ToString());
                            // varDecimal = Convert.ToInt32(objDS.Tables[0].Rows[0]["UT_Decimal"].ToString());
                            //txtunit.Text = Convert.ToString(objDS.Tables[0].Rows[0]["UT_Symbol"].ToString());
                            if (Convert.ToInt32(varBatchNoFlag) == 73)  //disabled
                            {
                                txtBatchNo.Text = "";
                                txtBatchNo.Enabled = false;
                                //  txtBatchNo.ReadOnly = true;
                            }
                            else if (Convert.ToInt32(varBatchNoFlag) == 72) //enabled
                            {
                                if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                                {
                                    txtBatchNo.Enabled = true;
                                    //txtBatchNo.ReadOnly = false;
                                }
                                else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                                {
                                    MR_Master objMR_Master = new MR_Master();
                                    objMR_Master.ViewType = 14;
                                    SPDataService objspdservice = new SPDataService();
                                    DataSet objDs = new DataSet();
                                    objDs = objspdservice.udfnMaster(objMR_Master);
                                    objspdservice.CloseConnection();
                                    if (objDs.Tables[0] != null)
                                    {
                                        if (objDs.Tables[0].Rows.Count != 0)
                                        {
                                            txtBatchNo.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                            txtBatchNo.Enabled = false;
                                        }
                                    }
                                }
                                udfnBatchDetails();
                            }
                            if (varShelflife == 1)
                            {
                                txtDay.ReadOnly = false;
                                txtMonth.ReadOnly = false;
                                txtYear.ReadOnly = false;
                                txtDay.Enabled = true;
                                txtMonth.Enabled = true;
                                txtYear.Enabled = true;
                            }
                            else
                            {
                                txtDay.ReadOnly = true;
                                txtMonth.ReadOnly = true;
                                txtYear.ReadOnly = true;
                                txtDay.Enabled = false;
                                txtMonth.Enabled = false;
                                txtYear.Enabled = false;
                            }
                            if (varMRPFlag == 1)
                            {
                                txtMrp.Enabled = true;
                                txtMrp.ReadOnly = false;
                            }
                            else
                            {
                                txtMrp.Enabled = false;
                                txtMrp.ReadOnly = true;
                            }
                            if (Convert.ToInt32(varPrcategory) == 16 && varShelflife == 1)
                            {
                                if (Convert.ToInt32(varRMProduction) == 1)
                                {
                                    varRMProductionFlag = 1;
                                    MR_Master objMR_Master = new MR_Master();
                                    objMR_Master.ViewType = 15;
                                    objMR_Master.paraDate = dpEntryDate.Text;
                                    objMR_Master.paraProductId = Convert.ToInt32(lblProduct.Text);
                                    SPDataService objspdservice = new SPDataService();
                                    DataSet objDs = new DataSet();
                                    objDs = objspdservice.udfnMaster(objMR_Master);
                                    objspdservice.CloseConnection();
                                    if (objDs.Tables[0] != null)
                                    {
                                        if (objDs.Tables[0].Rows.Count != 0)
                                        {
                                            txtDay.Text = objDs.Tables[0].Rows[0][0].ToString();
                                            txtMonth.Text = objDs.Tables[0].Rows[1][0].ToString();
                                            txtYear.Text = objDs.Tables[0].Rows[2][0].ToString();
                                        }
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
            }
        }
        public void udfnProductDetailsFromOther()
        {
            try
            {
                udfnSupplierLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSupplierLoad()
        {
            try
            {
                DataSet objDT = new DataSet();
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 32;
                objMR_Supplier.paraProducts = lblProduct.Text;
                SPDataService objdserv = new SPDataService();
                objDT = objdserv.udfnSupplierList(objMR_Supplier);
                objdserv.CloseConnection();
                cmbSupplier.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbSupplier.Enabled = true;
                            cmbSupplier.ValueMember = "SUPPLIER";
                            cmbSupplier.DisplayMember = "SP_NAME";
                            cmbSupplier.DataSource = objDT.Tables[0];
                        }
                        else
                        {
                            cmbSupplier.Text = "None";
                            cmbSupplier.Enabled = false;
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
        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

                TextBox textBox = (TextBox)sender;
                if (varDecimal == 0)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                    {
                        e.Handled = true;
                    }
                }
                if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = false;
                }
                if (varDecimal == 0)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
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

        private void DpEntryDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                varDateChange = 1;
                udfnTransferNo();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdDamageEntry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal TransferQty = Convert.ToDecimal(grdDamageEntry.CurrentRow.Cells["clmQuantity"].Value);
                decimal StockQty = Convert.ToDecimal(grdDamageEntry.CurrentRow.Cells["clmStockQty"].Value);

                if (Convert.ToDecimal(TransferQty) > Convert.ToDecimal(StockQty))
                {
                    grdDamageEntry.Rows[e.RowIndex].Cells["clmQuantity"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    varErrQty = "1";
                }
                else if (Convert.ToDecimal(TransferQty) == 0 || Convert.ToString(TransferQty) == "")
                {
                    grdDamageEntry.Rows[e.RowIndex].Cells["clmQuantity"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrQty = "1";
                }
                else
                {
                    if (fromQueueFlag == 1)
                    {
                        grdDamageEntry.CurrentRow.Cells["clmQuantity"].Style.BackColor = Color.White;
                    }
                    else {

                        grdDamageEntry.CurrentRow.Cells["clmQuantity"].Style.BackColor = Color.PaleGreen;
                    }
                    varErrQty = "0";
                }
                int varDecimal = Convert.ToInt32(grdDamageEntry.CurrentRow.Cells["clmUTDecimal"].Value);

                string Qty = objValidation.udfnDecimal(Convert.ToString(grdDamageEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                grdDamageEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;

                object varEditQty = grdDamageEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                // Update the same column value in the DataTable
                dtDamage.Rows[e.RowIndex]["DM_Qty"] = varEditQty;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                chkStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkStatus_KeyDown(object sender, KeyEventArgs e)
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

        private void ChkStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                chkStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkStatus_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkStatus.Checked == true)
                {
                    btnSave.Text = "Save";
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

        private void CmbSupplier_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbSupplier.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSupplier_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSupplier.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSupplier_KeyPress(object sender, KeyPressEventArgs e)
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

        private void DGV_SearchGridLeft_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdEmployee.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridLeft, grdEmployee);
                objDser.CloseConnection();
                grdEmployee.HorizontalScrollingOffset = DGV_SearchGridLeft.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridLeft_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGridLeft.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }

        private void DGV_SearchGridLeft_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGridLeft.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGridLeft.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }

            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridLeft_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdEmployee.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdEmployee.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdEmployee.SortOrder == SortOrder.Ascending)
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
                    grdEmployee.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_SearchGridLeft.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_SearchGridLeft.HorizontalScrollingOffset = grdEmployee.HorizontalScrollingOffset;
                    DGV_SearchGridLeft.FirstDisplayedScrollingRowIndex = 0;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridLeft_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdEmployee.ColumnCount > 0)
                {
                    grdEmployee.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGridLeft.HorizontalScrollingOffset = grdEmployee.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridLeft_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGridLeft.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGridLeft.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdEmployee.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridLeft, grdEmployee);
                objDser.CloseConnection();
                grdEmployee.HorizontalScrollingOffset = DGV_SearchGridLeft.HorizontalScrollingOffset;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridLeft_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdEmployee.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridLeft.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdEmployee.Width > grdEmployee.HorizontalScrollingOffset && grdEmployee.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridLeft.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridLeft.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void GridCheckLoop()
        {
            try
            {
                if (varCheckFlag == 1)
                {
                    string EmpID = grdEmployee.SelectedRows[0].Cells["EMPID"].Value.ToString();
                    for (int i = 0; i < grdChecker.Rows.Count; i++)
                    {
                        if (EmpID == grdChecker.Rows[i].Cells["EMPID"].Value.ToString())
                        {
                            if (varUncheckFlag == 1)
                            {
                                grdChecker.Rows[i].ReadOnly = true;
                                grdChecker.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                                break;
                            }
                            else
                            {
                                grdChecker.Rows[i].ReadOnly = false;
                                grdChecker.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    string EmpID = grdChecker.SelectedRows[0].Cells["EMPID"].Value.ToString();
                    for (int i = 0; i < grdEmployee.Rows.Count; i++)
                    {
                        if (EmpID == grdEmployee.Rows[i].Cells["EMPID"].Value.ToString())
                        {
                            if (varUncheckFlag == 1)
                            {
                                grdEmployee.Rows[i].ReadOnly = true;
                                grdEmployee.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                                break;
                            }
                            else
                            {
                                grdEmployee.Rows[i].ReadOnly = false;
                                grdEmployee.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                break;
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
        //public void udfnCheckerGridViewDisable()
        //{
        //    try
        //    {

        //        if (varCheckFlag == 1)
        //        {
        //            if (Convert.ToBoolean(grdEmployee.SelectedRows[0].Cells[0].Value) == true)
        //            {
        //                varUncheckFlag = 1;
        //                GridCheckLoop();
        //            }
        //            else 
        //            {
        //                varUncheckFlag = 0;
        //                GridCheckLoop();
        //            }
        //        }
        //        else
        //        {
        //            if (Convert.ToBoolean(grdChecker.SelectedRows[0].Cells[0].Value) == true)
        //            {
        //                varUncheckFlag = 1;
        //                GridCheckLoop();
        //            }
        //            else
        //            {
        //                varUncheckFlag = 0;
        //                GridCheckLoop();
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}
        private void GrdEmployee_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdEmployee.IsCurrentCellDirty)
                {
                    grdEmployee.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    varCheckFlag = 1;
                    //udfnCheckerGridViewDisable();
                    if (Convert.ToBoolean(grdEmployee.SelectedRows[0].Cells[0].Value) == true)
                    {
                        varUncheckFlag = 1;
                        GridCheckLoop();
                    }
                    else
                    {
                        varUncheckFlag = 0;
                        GridCheckLoop();
                    }
                }
                //else
                //{
                //    varCheckFlag = 0;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdEmployee_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdEmployee.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridLeft.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdEmployee.Width > grdEmployee.HorizontalScrollingOffset && grdEmployee.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridLeft.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridLeft.Invalidate();
                udfnscrollVisible(DGV_SearchGridLeft, grdEmployee);
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
                var vScrollbar = grdEmployee.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGridLeft.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGridLeft.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGridLeft.Rows[rowIndex].Cells[i].Value = "";
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
        private void udfnscrollvisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdChecker.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGridRight.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGridRight.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGridRight.Rows[rowIndex].Cells[i].Value = "";
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
        private void GrdDamageEntry_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdDamageEntry.ClearSelection();
                for (int i = 0; i < grdDamageEntry.Rows.Count; i++)
                {
                    if (varStatusID == 20)
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmQuantity"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        if (fromQueueFlag == 1)
                        { 
                            DataGridView dataGridView = (DataGridView)sender;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmQuantity"];
                            cell.Style.BackColor = Color.White;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = true;
                        }
                        else
                        {
                            DataGridView dataGridView = (DataGridView)sender;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmQuantity"];
                            cell.Style.BackColor = Color.PaleGreen;
                            cell.Style.ForeColor = Color.Black;
                            cell.ReadOnly = false;
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
                grdDamageEntry.ClearSelection();
            }
        }

        private void GrdDamageEntry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdDamageEntry.CurrentCell.OwningColumn.Name == "clmQuantity")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdDamageEntry.CurrentCell.OwningColumn.Name == "clmQuantity")
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
        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int varDecimal = Convert.ToInt32(grdDamageEntry.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdDamageEntry.CurrentCell.OwningColumn.Name == "clmQuantity")
                {
                    //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    //{
                    //    e.Handled = true;  // Disallow the character
                    //}
                    TextBox textBox = (TextBox)sender;
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                        {
                            e.Handled = true;
                        }
                    }
                    if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
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
        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdDamageEntry.CurrentCell.OwningColumn.Name == "clmQuantity")
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
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

        private void CmbReason_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbReason.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReason_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbSupplier.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReason_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbReason_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReason.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridRight_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdChecker.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridRight, grdChecker);
                objDser.CloseConnection();
                grdChecker.HorizontalScrollingOffset = DGV_SearchGridRight.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridRight_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGridRight.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }

        private void DGV_SearchGridRight_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGridRight.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGridRight.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }

            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridRight_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdChecker.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdChecker.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdChecker.SortOrder == SortOrder.Ascending)
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
                    grdChecker.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_SearchGridRight.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_SearchGridRight.HorizontalScrollingOffset = grdChecker.HorizontalScrollingOffset;
                    DGV_SearchGridRight.FirstDisplayedScrollingRowIndex = 0;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridRight_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdChecker.ColumnCount > 0)
                {
                    grdChecker.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGridRight.HorizontalScrollingOffset = grdChecker.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGridRight_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGridRight.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGridRight.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdChecker.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridRight, grdChecker);
                objDser.CloseConnection();
                grdChecker.HorizontalScrollingOffset = DGV_SearchGridRight.HorizontalScrollingOffset;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridRight_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdChecker.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridRight.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdChecker.Width > grdChecker.HorizontalScrollingOffset && grdChecker.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridRight.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridRight.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdChecker_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdChecker.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridRight.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdChecker.Width > grdChecker.HorizontalScrollingOffset && grdChecker.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridRight.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridRight.Invalidate();
                udfnscrollvisible(DGV_SearchGridRight, grdChecker);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdDamageEntry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grdDamageEntry.Columns["clmSupplier"].Index)
                {
                    var cell = grdDamageEntry.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdDamageEntry.Rows[e.RowIndex].Cells["clmBlockedReason"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chkDamageOtherLoc_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                chkDamageOtherLoc.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chkDamageOtherLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                chkDamageOtherLoc.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEntryNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkDamageOtherLoc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDamageOtherLoc.Checked == true)
                {
                    varDMFromOther = 1;
                    txtYear.Visible = true;
                    txtDay.Visible = true;
                    txtMonth.Visible = true;
                    txtExpiryDate.Visible = false;
                }
                else
                {
                    varDMFromOther = 0;
                    txtYear.Visible = false;
                    txtDay.Visible = false;
                    txtMonth.Visible = false;
                    txtExpiryDate.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chkDamageOtherLoc_KeyDown(object sender, KeyEventArgs e)
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

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDay_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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
        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnProductEvent();
                if (varDMFromOther == 0 && fromQueueFlag == 0)
                {
                    txtQuantity.Focus();
                }
                else if (fromQueueFlag == 1)
                {
                    cmbSupplier.Focus();
                }
                else
                {
                    if (txtMrp.Enabled == true)
                    { txtMrp.Focus(); }
                    else if (txtBatchNo.Enabled == true)
                    { txtBatchNo.Focus(); }
                    else { txtQuantity.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
                {
                    return;
                }
                else
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (-1))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnProductEvent(); 
                                    DGV_FilterProduct.Visible = false;
                                    if (varDMFromOther == 0 && fromQueueFlag == 0)
                                    {
                                        txtQuantity.Focus();
                                    }
                                    else if (fromQueueFlag == 1)
                                    {
                                        cmbSupplier.Focus();
                                    }
                                    else
                                    {
                                        if (txtMrp.Enabled == true)
                                        { txtMrp.Focus(); }
                                        else if (txtBatchNo.Enabled == true)
                                        { txtBatchNo.Focus(); }
                                        else { txtQuantity.Focus(); }
                                    }
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (txtProductName.Text.Length == 1)
                    {
                        DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[0].Cells[0];
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (varDMFromOther == 0 && fromQueueFlag == 0)
                        {   
                            txtQuantity.Focus();
                        }
                        else if (fromQueueFlag == 1)
                        {
                            cmbSupplier.Focus();
                        }
                        else
                        {
                            if (txtMrp.Enabled == true)
                            { txtMrp.Focus(); }
                            else if (txtBatchNo.Enabled == true)
                            { txtBatchNo.Focus(); }
                            else { txtQuantity.Focus(); }
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

        private void GrdChecker_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdChecker.IsCurrentCellDirty)
                {
                    grdChecker.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    varCheckFlag = 0;
                    //udfnCheckerGridViewDisable();
                    if (Convert.ToBoolean(grdChecker.SelectedRows[0].Cells[0].Value) == true)
                    {
                        varUncheckFlag = 1;
                        GridCheckLoop();
                    }
                    else
                    {
                        varUncheckFlag = 0;
                        GridCheckLoop();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdEmployee_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //grdEmployee.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdChecker_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //grdChecker.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
