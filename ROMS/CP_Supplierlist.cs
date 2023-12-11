using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace ROMS
{
    public partial class CP_Supplierlist : Form
    {
        ToolTip tpSupplier = new ToolTip();
        public string varUserID = "";
        public int varActiveCount = 0, varInactiveCount = 0, varTotalCount = 0, Varflag = 0, varNotDefinedCount = 0;

        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_Supplierlist()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                MainForm.objCP_Supplier = new CP_Supplier();
                MainForm.objCP_Supplier.MdiParent = this.ParentForm;
                MainForm.objCP_Supplier.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
            finally
            {
                picLoader.Visible = false;
            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                udfndelete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Supplierlist_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (-1)", "DY_Name,DYID", cmbDay, "", "DY_Name", "DYID");
                objDataBind.BindComboBoxListSelected("(SELECT STSID,STS_Name,STS_ModuleID FROM DEF_Status WHERE STS_ModuleID IN(0, 1) AND STSID<>-1 UNION ALL  SELECT -2, 'Not defined',1)AS DIV", "1=1", "STSID, STS_Name", cmbStatus, "", "STS_Name", "STSID");
                this.ActiveControl = txtSupplier;
                objDataBind = null;
                cmbDay.SelectedValue = 0;
                cmbStatus.SelectedValue = 0;
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdSupplierList.ClearSelection();
            }
        }


        public void udfndelete()
        {
            try
            {
                if (grdSupplierList.SelectedRows.Count > 0)
                {
                    string varResult = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        int varordertype = 0, vardayide = 0, varscheduleid = 0;
                        if (Convert.ToString(grdSupplierList.SelectedRows[0].Cells["ORDERTYPE"].Value.ToString()) == "")
                        {
                            varordertype = 0;
                        }
                        else
                        {
                            varordertype = Convert.ToInt32(grdSupplierList.SelectedRows[0].Cells["ORDERTYPE"].Value.ToString());
                        }
                        if (Convert.ToString(grdSupplierList.SelectedRows[0].Cells["DYID"].Value.ToString()) == "")
                        {
                            vardayide = 0;
                        }
                        else
                        {
                            vardayide = Convert.ToInt32(grdSupplierList.SelectedRows[0].Cells["DYID"].Value.ToString());
                        }
                        if (Convert.ToString(grdSupplierList.SelectedRows[0].Cells["Scheduleid"].Value.ToString()) == "")
                        {
                            varscheduleid = 0;
                        }
                        else
                        {
                            varscheduleid = Convert.ToInt32(grdSupplierList.SelectedRows[0].Cells["Scheduleid"].Value.ToString());
                        }
                        SPDataService objspdservice = new SPDataService();
                        varResult = objspdservice.udfnSupplierMaster(2, Convert.ToInt32(grdSupplierList.SelectedRows[0].Cells["SupplierID"].Value.ToString()), "", "", "", 0, "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", varUserID, MainForm.pbIpAddress, "Delete Supplier", 0, "", 0, vardayide, 0, 0, 0, "", "", "", "", 0, "", varscheduleid, varordertype, "", "", "", "", "", "", "", "", "", 0, "", 0);
                        string[] varvalue = varResult.Split('~');
                        objspdservice.CloseConnection();
                        if (varvalue[0] == "3")
                        {
                            if (varResult.Split('~')[1] == "1")
                            {
                                MainForm.objCP_Verify = new CP_Verify();
                                MainForm.objCP_Verify.ShowDialog();
                                varUserID = MainForm.objCP_Verify.varUserId;
                                if (MainForm.objCP_Verify.flag == 1)
                                {
                                    objspdservice = new SPDataService();
                                    varResult = objspdservice.udfnSupplierMaster(2, Convert.ToInt32(grdSupplierList.SelectedRows[0].Cells["SupplierID"].Value.ToString()), "", "", "", 0, "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", varUserID, MainForm.pbIpAddress, "Delete Supplier", 0, "", 0, vardayide, 0, 0, 0, "", "", "", "", 0, "", varscheduleid, varordertype, "", "", "", "", "", "", "", "", "", 1, "", 0);
                                    objspdservice.CloseConnection();
                                    if (varResult.Split('~')[0] == "3")
                                    {
                                        MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        MainForm.objCP_Supplierlist.udfnList();
                                    }
                                    else { MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void udfnEdit()
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                if (grdSupplierList.SelectedRows.Count > 0)
                {
                    MainForm.objCP_Supplier = new CP_Supplier();
                    MainForm.objCP_Supplier.MdiParent = this.ParentForm;
                    MainForm.objCP_Supplier.btnSave.Text = "Update";
                    MainForm.objCP_Supplier.pbSupplierid = Convert.ToString(grdSupplierList.SelectedRows[0].Cells["SupplierID"].Value.ToString());
                    MainForm.objCP_Supplier.Show();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
            }
        }

        public void udfnList()
        {
            try
            {
                Varflag = 0;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                ep_Supplierlist.Clear();
                grdSupplierList.DataSource = null;
                DataSet objDs = new DataSet();
                string varSupplierId = "0";
                //**** To call the function from SP ********* 
                if (txtSupplier.Text == "")
                {
                    varSupplierId = "0";
                    lblschedule.Text = "0";
                }
                else
                {
                    string[] values = new string[0];
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(31, 0, Convert.ToInt32(lblschedule.Text), 0, 0, txtSupplier.Text.Trim(), 0, 0, 0, "", 0, 0, 0, 0, 0, 0, "","","",0);
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
                        ep_Supplierlist.SetError(txtSupplier, "Invalid supplier.");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplier.ShowAlways = true;
                        tpSupplier.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        Varflag = 1;
                    }
                    else
                    {
                        ep_Supplierlist.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedule.Text = values[1];
                        txtSupplier.BackColor = Color.White;

                    }
                    //VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                }

                if (Varflag == 0)
                {
                    SPDataService objdserv = new SPDataService();
                    objDs = objdserv.udfnSupplierList(1, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), Convert.ToInt32(cmbDay.SelectedValue), 0, "", 0, Convert.ToInt32(cmbStatus.SelectedValue), 0, "", 0, 0, 0, 0, 0, 0, "","","",0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                lblNoRecordsFound.Visible = false;
                                lblNoRecordsFound.SendToBack();
                                grdSupplierList.DataSource = objDs.Tables[0];
                                grdSupplierList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdSupplierList.Columns["Ret. Policy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdSupplierList.Columns["T.Pro.Count"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                //grdSupplierList.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                                grdSupplierList.Columns["S.No."].Width = 50;
                                grdSupplierList.Columns["Supplier"].Width = 350;
                                // grdSupplierList.Columns["Schedule Name"].Width = 150;
                                grdSupplierList.Columns["GSTIN"].Width = 130;
                                grdSupplierList.Columns["Schedule Status"].Width = 110;
                                grdSupplierList.Columns["Days"].Width = 90;
                                grdSupplierList.Columns["Scheduleid"].Visible = false;
                                grdSupplierList.Columns["SupplierID"].Visible = false;
                                grdSupplierList.Columns["STS"].Visible = false;
                                grdSupplierList.Columns["DYID"].Visible = false;
                                grdSupplierList.Columns["ORDERTYPE"].Visible = false;
                                grdSupplierList.Columns["rownum"].Visible = false;
                                grdSupplierList.Columns["SP_ReturnApplicable"].Visible = false;
                                grdSupplierList.Columns["SPSC_OrderType"].Visible = false;
                            }
                            else
                            {
                                lblNoRecordsFound.Visible = true;
                                lblNoRecordsFound.BringToFront();
                            }
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            grdDaywiseProduct.DataSource = null;
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                grdDaywiseProduct.DataSource = objDs.Tables[1];

                                grdDaywiseProduct.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdDaywiseProduct.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdDaywiseProduct.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdDaywiseProduct.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdDaywiseProduct.Columns["Total Suppliers"].Width = 100;
                                grdDaywiseProduct.Columns["Mobile App"].Width = 100;
                                grdDaywiseProduct.Columns["Phone"].Width = 100;
                                grdDaywiseProduct.Columns["Visit"].Width = 80;

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
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    grdSupplierList.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //  grdreplist.ClearSelection();
                picLoader.Visible = false;
                picLoader.SendToBack();
            }
        }
        private void CP_Supplierlist_KeyDown(object sender, KeyEventArgs e)
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
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.D))
                {
                    tsbDelete_Click(sender, e);
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
                udfnGridSearchHeading(grdSupplierList, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdSupplierList.Columns)
                {
                    DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                int rowIndex = 0;
                DGV_SearchGrid.Rows.Clear();
                DGV_SearchGrid.Rows.Add();
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                }
                DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
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
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    dgv2.Rows[rowIndex].Cells[i].Value = "";
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void CmbDay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    grdDaywiseProduct.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDay_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbDay_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbDay.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbDay_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDay.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbDay.Select(int.MaxValue, 0)));
                udfnList();
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
                LV_Supplier.Visible = false;
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

        private void BtnExport_Enter(object sender, EventArgs e)
        {
            try
            {
                btnExport.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExport_Leave(object sender, EventArgs e)
        {
            try
            {
                btnExport.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (LV_Supplier.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtSupplier.Focus();
                        LV_Supplier.Visible = false;
                    }
                    else
                    {
                        LV_Supplier.Focus();
                    }
                    if (LV_Supplier.Items.Count > 0)
                    {
                        LV_Supplier.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSupplier.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(15, 0, 0, 0, 0, txtSupplier.Text, 0, 0, 0,"",0,0,0,0,0,0,"","","",0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.BringToFront();
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    LV_Supplier.Visible = false;
                    LV_Supplier.Items.Clear();
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

        private void GrdSupplierList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEdit();
                }
                if (e.KeyCode == Keys.Delete)
                {
                    tsbDelete_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                varActiveCount = 0; varInactiveCount = 0; varTotalCount = 0; varNotDefinedCount = 0;
                for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                {
                    varTotalCount++;
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["STS"].Value) == "1" && Convert.ToString(grdSupplierList.Rows[i].Cells["Schedule Status"].Value) != "")
                    {
                        grdSupplierList.Rows[i].Cells["Schedule Status"].Style.BackColor = Color.LimeGreen;
                        grdSupplierList.Rows[i].Cells["Schedule Status"].Style.ForeColor = Color.White;
                        varActiveCount++;
                    }
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["STS"].Value) == "0" && Convert.ToString(grdSupplierList.Rows[i].Cells["Schedule Status"].Value) != "")
                    {
                        grdSupplierList.Rows[i].Cells["Schedule Status"].Style.BackColor = Color.SteelBlue;
                        grdSupplierList.Rows[i].Cells["Schedule Status"].Style.ForeColor = Color.White;
                        varNotDefinedCount++;
                    }
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["STS"].Value) == "2" && Convert.ToString(grdSupplierList.Rows[i].Cells["Schedule Status"].Value) != "")
                    {
                        grdSupplierList.Rows[i].Cells["Schedule Status"].Style.BackColor = Color.Tomato;
                        grdSupplierList.Rows[i].Cells["Schedule Status"].Style.ForeColor = Color.White;
                        varInactiveCount++;
                    }

                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["SP_ReturnApplicable"].Value) == "-1") // Not Defined
                    {
                        grdSupplierList.Rows[i].Cells["Ret. Policy"].Style.BackColor = Color.SteelBlue;
                        grdSupplierList.Rows[i].Cells["Ret. Policy"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["SPSC_OrderType"].Value) == "144") // Unscheduled order type
                    {
                        grdSupplierList.Rows[i].Cells["Order Type"].Style.BackColor = Color.MediumSpringGreen;
                    }
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["Order Type"].Value) == "Not Defined") // Unscheduled supplier order type
                    {
                        grdSupplierList.Rows[i].Cells["Order Type"].Style.BackColor = Color.SteelBlue;
                        grdSupplierList.Rows[i].Cells["Order Type"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["Days"].Value) == "Unscheduled") // Unscheduled order type
                    {
                        grdSupplierList.Rows[i].Cells["Days"].Style.BackColor = Color.Purple;
                        grdSupplierList.Rows[i].Cells["Days"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["Days"].Value) == "Not Defined") // Not defined days
                    {
                        grdSupplierList.Rows[i].Cells["Days"].Style.BackColor = Color.SteelBlue;
                        grdSupplierList.Rows[i].Cells["Days"].Style.ForeColor = Color.White;
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
                grdSupplierList.ClearSelection();
                lblActiveCount.Text = Convert.ToString(varActiveCount);
                lblInactiveCount.Text = Convert.ToString(varInactiveCount);
                lblTotal.Text = Convert.ToString(varTotalCount);
                //lblNotDefinedCount.Text = Convert.ToString(varNotDefinedCount);
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                RPTViewer.Visible = false;
                RPTViewer.SendToBack();
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdSupplierList.ClearSelection();
            }
        }


        public void cmbschedulebind()
        {
            try
            {
                //if (Convert.ToString(txtSupplier.Text) != "")
                //{
                //    string varsuppliername = "0";
                //    DataService objDserv = new DataService();
                //    varsuppliername = objDserv.displaydata("SELECT COUNT(*) FROM MR_Supplier WHERE SP_Name='" + txtSupplier.Text.Split('-')[0].Trim() + "'");
                //    if (varsuppliername == "0")
                //    {
                //        lblSupplierCode.Text = "0";
                //        ep_Supplierlist.SetError(txtSupplier, "Invalid supplier");
                //        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpSupplier.ShowAlways = true;
                //        tpSupplier.Show("Invalid supplier", txtSupplier, 5000);
                //    }
                //    else
                //    {
                //        ep_Supplierlist.Clear();
                //        txtSupplier.BackColor = Color.White;
                //    }
                //}
                //if (Convert.ToString(txtSupplier.Text) != "")
                //{
                //    string varsuppliername = "0";
                //    DataService objDserv = new DataService();
                //    varsuppliername = objDserv.displaydata("SELECT COUNT(*) FROM MR_Supplier WHERE SP_Name='" + txtSupplier.Text.Split('-')[0].Trim() + "'");
                //    if (varsuppliername == "0")
                //    {
                //        lblSupplierCode.Text = "0";
                //        ep_Supplierlist.SetError(txtSupplier, "Invalid supplier");
                //        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpSupplier.ShowAlways = true;
                //        tpSupplier.Show("Invalid supplier", txtSupplier, 5000);
                //    }
                //    else
                //    {
                //        ep_Supplierlist.Clear();
                //        txtSupplier.BackColor = Color.White;
                //    }
                //}

                int cmbsuppleirid = 0;
                if (lblSupplierCode.Text == "0")
                {
                    cmbsuppleirid = 0;
                }
                else
                {
                    cmbsuppleirid = Convert.ToInt32(lblSupplierCode.Text);
                }
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    cmbsuppleirid = 0;
                }
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Supplier_Schedule", "SPSC_SPID='" + cmbsuppleirid + "' or SPSCID=0", "SPSC_Name,SPSCID", cmbStatus, "", "SPSC_Name", "SPSCID");
                objDataBind = null;


            }

            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                //TxtSupplier_Leave(sender, e);
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
                if (txtSupplier.Text != "")
                {
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                }
                cmbStatus.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                LV_Supplier.Visible = false;
            }
        }
        private void LV_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                    //TxtSupplier_Leave(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdSupplierList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSupplierList);
                objDser.CloseConnection();
                grdSupplierList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
                if (!(e.ColumnIndex == 0)) /*If not our desired columns*/
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
            DataGridViewColumn newColumn = grdSupplierList.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = grdSupplierList.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    grdSupplierList.SortOrder == SortOrder.Ascending)
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
            grdSupplierList.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;

            DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
            DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

            DGV_SearchGrid.HorizontalScrollingOffset = grdSupplierList.HorizontalScrollingOffset;
            DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdSupplierList.ColumnCount > 0)
                {
                    grdSupplierList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdSupplierList.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                RPTViewer.Visible = false;
                RPTViewer.SendToBack();
                udfnImport();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnImport()
        {
            try
            {
                if ((grdSupplierList.Rows.Count > 0))
                {
                    btnExport.Enabled = false;
                    lblStatus.Focus();
                    Excel._Application ExcelObj = new Excel.Application();
                    // creating new WorkBook within Excel application  
                    Excel._Workbook ExcelBook = ExcelObj.Workbooks.Add(Type.Missing);
                    // creating new Excelsheet in workbook  
                    Excel._Worksheet ExcelSheet = null;
                    // see the excel sheet behind the program  
                    ExcelObj.Visible = true;
                    ExcelSheet = ExcelBook.Sheets["Sheet1"];
                    ExcelSheet = ExcelBook.ActiveSheet;
                    // changing the name of active sheet  
                    ExcelSheet.Name = "Supplier List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdSupplierList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }

                    ExcelSheet.Cells[1, 1].Value = "Supplier List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    foreach (DataGridViewColumn col in grdSupplierList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";
                            ExcelSheet.Cells[2, cIndex].Interior.Color = Color.LightSlateGray;
                            Excel.Range cell = ExcelSheet.Cells[2, cIndex];
                            cell.Font.Color = Excel.XlRgbColor.rgbWhite;

                            int varSLno = 1;
                            foreach (DataGridViewRow rowa in grdSupplierList.Rows)
                            {
                                if (cIndex == 1)
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex] = varSLno;
                                    varSLno++;
                                }
                                else
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                                }
                            }
                        }
                    }
                    ExcelObj.Visible = true;
                }

                else
                {
                    MessageBox.Show("No Records found!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnExport.Enabled = true;
                btnExport.Focus();
            }
        }

        private void GrdDaywiseProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdDaywiseProduct.ClearSelection();
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
                grdSupplierList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSupplierList);
                objDser.CloseConnection();
                grdSupplierList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdSupplierList.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdSupplierList.Width > grdSupplierList.HorizontalScrollingOffset && grdSupplierList.HorizontalScrollingOffset > 0)
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

        private void GrdSupplierList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdSupplierList.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdSupplierList.Width > grdSupplierList.HorizontalScrollingOffset && grdSupplierList.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdSupplierList);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnscrollVisible(DataGridView DGV, DataGridView grdGroupList)
        {
            try
            {
                var vScrollbar = grdGroupList.Controls.OfType<VScrollBar>().First();
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
                grdSupplierList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSupplierList);
                objDser.CloseConnection();
                grdSupplierList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbStatus.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
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

        private void BtnView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnView_Click(sender, e);
                }
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
                btnPrint.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int varSupplierId = 0;
                if (txtSupplier.Text == "")
                {
                    varSupplierId = 0;
                    lblschedule.Text = "0";
                }
                else
                {
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    string varSuppName = "", varScheduleName = ""; ;
                    if (txtSupplier.Text != "")
                    {
                        varSuppName = txtSupplier.Text.Split('-')[0].Trim();
                        int varCount = txtSupplier.Text.Split('-').Count();
                        if (varCount > 1)
                        {
                            varScheduleName = txtSupplier.Text.Split('-')[1].Trim();
                        }
                    }
                    objDsSupplierId = objDserv.udfnSupplierList(11, 0, 0, 0, 0, varSuppName, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, "","","",0);
                    objDserv.CloseConnection();
                    if (objDsSupplierId != null)
                    {
                        if (objDsSupplierId.Tables.Count > 0)
                        {
                            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                            {
                                varSupplierId = Convert.ToInt32(objDsSupplierId.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (varScheduleName == "") { lblschedule.Text = "0"; }
                }
                btnPrint.Enabled = false;
                lblStatus.Focus();
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                // objDs = objdserv.udfnSupplierList(1, varSupplierId, Convert.ToInt32(lblschedule.Text), Convert.ToInt32(cmbDay.SelectedValue), 0, "", 0, Convert.ToInt32(cmbStatus.SelectedValue), 0, "", 0, 0, 0, 0, 0, 0, "");
                objDs = objdserv.udfnSupplierList(1, varSupplierId, Convert.ToInt32(lblschedule.Text), Convert.ToInt32(cmbDay.SelectedValue), 0, "", 0, Convert.ToInt32(cmbStatus.SelectedValue), 0, "", 0, 0, 0, 0, 0, 0, "","","",0);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_CP_Supplier_List.rpt");
                    objBillreport.SetParameterValue("paraSupplierid ", varSupplierId);
                    objBillreport.SetParameterValue("paraSupplierScheduleid ", Convert.ToInt32(lblschedule.Text));
                    objBillreport.SetParameterValue("paraOrderId ", Convert.ToInt32(0));
                    objBillreport.SetParameterValue("paraStatusId", Convert.ToInt32(cmbStatus.SelectedValue));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
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
            finally
            {
                picLoader.Visible = false;
                picLoader.SendToBack();
                btnPrint.Enabled = true;
                btnPrint.Focus();
                GC.Collect();
            }
        }

        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbStatus.BackColor = Color.LemonChiffon;

                cmbschedulebind();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSummary_Click(object sender, EventArgs e)
        {
            try
            {
                // picLoader.Visible = true;
                // picLoader.BringToFront();
                MainForm.objCP_SupplierPopup = new CP_SupplierPopup();
                MainForm.objCP_SupplierPopup.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
            finally
            {
                // picLoader.Visible = false;
            }
        }
    }
}
