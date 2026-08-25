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
using Excel = Microsoft.Office.Interop.Excel;
namespace ROMS
{
    public partial class CP_AddressBookList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        MainForm objMainForm = new MainForm();
        Boolean BlnSearchImageYN = false;
        public string varSupplierIds = "0",pbAddressBookIds="0";
        ToolTip tpSupplier = new ToolTip();
        public string varUserID = "";
        public int varActiveCount = 0, varInactiveCount = 0, varTotalCount = 0, Varflag = 0, varNotDefinedCount = 0, varDeleteFlag = 0, pbDetailFlag = 0,pbPrintFlag = 0;
        DataTable dtDefaultGrid = new DataTable();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int MenuCode = 0;
        string privilege = "";
        public List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>(); 
        public CP_AddressBookList()
        {
            InitializeComponent();
            windowControl.Initialize(tsSupplierList, this);
            
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objCP_AddressBook = new CP_AddressBook();
                    MainForm.objCP_AddressBook.MdiParent = this.ParentForm;
                    //objMainForm.CenterEntryForm(this, MainForm.objCP_AddressBook);
                    MainForm main = (MainForm)this.MdiParent;
                    main.IsEntryFormOpen = true;
                    main.CurrentEntryForm = MainForm.objCP_AddressBook;
                    main.CurrentParentListForm = this;
                    MainForm.objCP_AddressBook.Show();
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
                MenuCode = 1314;
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("(SELECT  CASE WHEN  MSTID=565 THEN -2 ELSE MSTID END  AS ID,MST_DisplayText AS [Value] FROM DEF_Master WHERE  MSTID  IN (565,0) UNION ALL SELECT CONGID AS ID,CONG_EName AS [Value] FROM MR_ContactGroup WHERE CONGID NOT IN (-1,0)) AS DIV"
                   , "1=1", "ID, Value", cmbType, "", "Value", "ID");
                objDataBind.BindComboBoxListSelected("(SELECT STSID,STS_Name,STS_ModuleID FROM DEF_Status WHERE STS_ModuleID IN(0, 1) AND STSID<>-1  )AS DIV", "1=1", "STSID, STS_Name", cmbStatus, "", "STS_Name", "STSID");
                this.ActiveControl = cmbType;
                objDataBind = null; 
                cmbStatus.SelectedValue = 0;
                udfnList();
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    udfnFieldAccess();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdAddressBookList.ClearSelection();
            }
        }
        public void udfnFieldAccess()
        {
            try
            {
                var result = UserAccessHelper.LoadUserAccess(MenuCode);
                privilege = result.PrivilegeCode;
                SpecialPermissions = result.SpecialPermissions;
                tsbNew.Visible = privilege.Contains("2");
                tssNew.Visible = privilege.Contains("2");
                tsbEdit.Visible = privilege.Contains("3");
                tssEdit.Visible = privilege.Contains("3");
                tsbDelete.Visible = privilege.Contains("4");  
                btnExport.Visible = privilege.Contains("6");
                tsbEnvelopPrint.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 7 && sp.EditAccess.Split(',').Contains("9")); 
                udfnGridAccess();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridAccess()
        {
            try
            {
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    grdAddressBookList.Columns["clmCheck"].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 7 && sp.EditAccess.Split(',').Contains("9"));
                    DGV_SearchGrid.Columns[0].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 7 && sp.EditAccess.Split(',').Contains("9"));   
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfndelete()
        {
            if (Convert.ToInt16(grdAddressBookList.SelectedRows[0].Cells["IsEditable"].Value) == 1)
            {
                if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
                {
                    try
                    {
                        if (grdAddressBookList.SelectedRows.Count > 0)
                        {
                            string varResult = "";
                            DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dialogResult == DialogResult.Yes)
                            {
                                int id = 0;
                                id = Convert.ToInt16(grdAddressBookList.SelectedRows[0].Cells["ID"].Value);
                                    SPDataService objspdservice = new SPDataService();
                                SPDataService objspservice = new SPDataService();
                                DataSet objDS;
                                MR_AddressBook objMR_AddressBook = new MR_AddressBook();
                                objMR_AddressBook.ViewType = 2;
                                objMR_AddressBook.paraABID = id;
                                varResult = objspservice.udfnAddressBook(objMR_AddressBook);
                                objspservice.CloseConnection();

                                string[] varvalue = varResult.Split('~');
                                objspdservice.CloseConnection();
                                if (varResult.Split('~')[0] == "3")
                                {
                                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MainForm.objCP_AddressBookList.udfnList();
                                }
                                else { MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

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

        private void udfnEdit()
        {
            if(Convert.ToInt16(grdAddressBookList.SelectedRows[0].Cells["IsEditable"].Value)==1)
            {
                if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
                {
                    try
                    {
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        if (grdAddressBookList.SelectedRows.Count > 0)
                        {
                            MainForm.objCP_AddressBook = new CP_AddressBook();
                            MainForm.objCP_AddressBook.MdiParent = this.ParentForm;
                            MainForm.objCP_AddressBook.btnSave.Text = "Update";
                            MainForm.objCP_AddressBook.pbABID = Convert.ToInt16(grdAddressBookList.SelectedRows[0].Cells["ID"].Value.ToString());
                            MainForm main = (MainForm)this.MdiParent;
                            main.IsEntryFormOpen = true;
                            main.CurrentEntryForm = MainForm.objCP_AddressBook;
                            main.CurrentParentListForm = this;
                            MainForm.objCP_AddressBook.Show();
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
            }
        }

        public void udfnList()
        {
            try
            { 
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                Varflag = 0;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                ep_Supplierlist.Clear();
                grdAddressBookList.DataSource = null;
                DataSet objDs = new DataSet(); 
                MR_AddressBook objAddressBook = new MR_AddressBook();
                objAddressBook.ViewType = 0; 
                objAddressBook.paraType = Convert.ToInt16(cmbType.SelectedValue); 
                objAddressBook.paraStatusID = Convert.ToInt16(cmbStatus.SelectedValue); 
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnAddressBookList(objAddressBook);
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
                            grdAddressBookList.DataSource = objDs.Tables[0];
                            grdAddressBookList.Columns["S.No"].Width = 50;
                            grdAddressBookList.Columns["Name"].Width = 300;
                            grdAddressBookList.Columns["Type"].Width = 100;
                            grdAddressBookList.Columns["Contact"].Width = 100;
                            grdAddressBookList.Columns["Address"].Width = 350;
                            grdAddressBookList.Columns["CreatedDate"].Width = 150;
                            grdAddressBookList.Columns["UpdatedDate"].Width = 150;
                            grdAddressBookList.Columns["S.No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                            grdAddressBookList.Columns["Contact"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                            grdAddressBookList.Columns["CreatedDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                            grdAddressBookList.Columns["UpdatedDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdAddressBookList.Columns["IsEditable"].Visible = false;
                            grdAddressBookList.Columns["STSID"].Visible = false;
                            grdAddressBookList.Columns["CONGID"].Visible = false;
                            grdAddressBookList.Columns["ID"].Visible = false;

                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                         
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
                udfnSearchGridHead();
                grdAddressBookList.Columns[0].ReadOnly = false;
                if (lblNoRecordsFound.Visible == true)
                {
                    dtDefaultGrid = objDs.Tables[0];
                    udfnDefaultSearchGrid();
                }
                else { DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; }
               
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
                grdAddressBookList.ClearSelection(); 

            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                    //MainForm.objStart = new DEF_Start();
                    //MainForm.objStart.MdiParent = this.ParentForm;
                    //MainForm.objStart.Show();
                    //this.Close();
                    windowControl?.TriggerClose();
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
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdAddressBookList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdAddressBookList.Columns)
                    {
                        DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    //DGV_SearchGrid.Columns[0].DefaultCellStyle.NullValue = null;
                    DGV_SearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                    DGV_SearchGrid.Columns[2].DefaultCellStyle.NullValue = null;
                    for (int i = 1; i < visibleColumns.Count; i++)
                    {
                        DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    DGV_SearchGrid.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
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
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
          
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                //LV_Supplier.Visible = false;
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

        //private void TxtSupplier_Enter(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtSupplier.BackColor = Color.LemonChiffon;
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}

        //private void TxtSupplier_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtSupplier.BackColor = Color.White;
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}

        //private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            cmbStatus.Focus();
        //        }
        //        if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
        //        {
        //            if (LV_Supplier.Items.Count == 0 || txtSupplier.Text == "")
        //            {
        //                txtSupplier.Focus();
        //                LV_Supplier.Visible = false;
        //            }
        //            else
        //            {
        //                LV_Supplier.Focus();
        //            }
        //            if (LV_Supplier.Items.Count > 0)
        //            {
        //                LV_Supplier.Items[0].Selected = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }

        //}

        //private void TxtSupplier_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LV_Supplier.Items.Clear();
        //        if (txtSupplier.Text.Length > 0)
        //        {
        //            MR_Supplier objMR_Supplier = new MR_Supplier();
        //            objMR_Supplier.ViewType = 15;
        //            objMR_Supplier.paraSupplierName = txtSupplier.Text;
        //            DataSet objDs = new DataSet();
        //            SPDataService objspdservice = new SPDataService();
        //            objDs = objspdservice.udfnSupplierList(objMR_Supplier);
        //            objspdservice.CloseConnection();
        //            if (objDs != null)
        //            {
        //                if (objDs.Tables.Count != 0)
        //                {
        //                    if (objDs.Tables[0].Rows.Count != 0)
        //                    {
        //                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
        //                        {
        //                            string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString() };
        //                            ListViewItem objList = new ListViewItem(row);
        //                            LV_Supplier.Items.Add(objList);
        //                        }
        //                        LV_Supplier.Visible = true;
        //                        LV_Supplier.BringToFront();
        //                        LV_Supplier.Columns[1].Width = 0;
        //                        LV_Supplier.Columns[2].Width = 0;
        //                        LV_Supplier.Columns[0].Width = 300;
        //                    }
        //                }
        //            }
        //            objspdservice.CloseConnection();
        //        }
        //        else
        //        {
        //            LV_Supplier.Visible = false;
        //            LV_Supplier.Items.Clear();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //    finally
        //    {
        //    }
        //}

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
                for (int i = 0; i < grdAddressBookList.Rows.Count; i++)
                {
                    
                    if (Convert.ToString(grdAddressBookList.Rows[i].Cells["STSID"].Value) == "1"  )
                    {
                        grdAddressBookList.Rows[i].Cells["Schedule Status"].Style.BackColor = Color.LimeGreen;
                        grdAddressBookList.Rows[i].Cells["Schedule Status"].Style.ForeColor = Color.White; 
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
                grdAddressBookList.ClearSelection(); 
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
                grdAddressBookList.ClearSelection();
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
                //if (txtSupplier.Text == "")
                //{
                //    lblSupplierCode.Text = "0";
                //    cmbsuppleirid = 0;
                //}
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
                //if (txtSupplier.Text != "")
                //{
                //    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                //    txtSupplier.Text = selectedItem.SubItems[0].Text;
                //    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                //    lblschedule.Text = selectedItem.SubItems[2].Text;
                //}
                cmbStatus.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //LV_Supplier.Visible = false;
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
                grdAddressBookList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdAddressBookList);
                objDser.CloseConnection();
                grdAddressBookList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
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


        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdAddressBookList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdAddressBookList.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdAddressBookList.SortOrder == SortOrder.Ascending)
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
                grdAddressBookList.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_SearchGrid.HorizontalScrollingOffset = grdAddressBookList.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdAddressBookList.ColumnCount > 0)
                {
                    grdAddressBookList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdAddressBookList.HorizontalScrollingOffset;
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
                if ((grdAddressBookList.Rows.Count > 0))
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
                    foreach (DataGridViewColumn col in grdAddressBookList.Columns)
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
                    foreach (DataGridViewColumn col in grdAddressBookList.Columns)
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
                            foreach (DataGridViewRow rowa in grdAddressBookList.Rows)
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
                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 8;
                            }
                            else if (col.Name == "City" || col.Name == "Supplier Type" || col.Name == "GSTIN" || col.Name == "Order Type" || col.Name == "Days" || col.Name == "Payment Term" || col.Name == "Ret. Policy" || col.Name == "Ret.Condition" || col.Name == "T.Pro.Count" || col.Name == "Schedule Status")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 30;
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
        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdAddressBookList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdAddressBookList);
                objDser.CloseConnection();
                grdAddressBookList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdAddressBookList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdAddressBookList.Width > grdAddressBookList.HorizontalScrollingOffset && grdAddressBookList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                }
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
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdAddressBookList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdAddressBookList.Width > grdAddressBookList.HorizontalScrollingOffset && grdAddressBookList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdAddressBookList);
                }
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
                grdAddressBookList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdAddressBookList);
                objDser.CloseConnection();
                grdAddressBookList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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

        private void GrdSupplierList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (grdAddressBookList.Columns[e.ColumnIndex].Name != "clmCheck")
                {
                    e.Cancel = true; // Block editing
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdAddressBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int emptyprint = grdAddressBookList.Rows.Cast<DataGridViewRow>().Count(r => Convert.ToBoolean(r.Cells[0].Value) &&
               Convert.ToInt32(r.Cells["IsEditable"].Value) == 0) > 0 ? 1 : 0;
                pbPrintFlag = grdAddressBookList.Rows.Cast<DataGridViewRow>().Count(r => Convert.ToBoolean(r.Cells[0].Value) &&
                Convert.ToInt32(r.Cells["IsEditable"].Value) == 1) ;
                if (emptyprint == 0)
                { 
                    tsbEmpty.Visible = true; 
                    tsbFilled.Visible = true;  
                }
                else
                {
                    tsbEmpty.Visible = false;
                    tsbFilled.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsSupplierList_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void tsbFilled_Click(object sender, EventArgs e)
            {
            try
            {
                int varCount = 0;
                if (grdAddressBookList.Rows.Count > 0)
                {
                    varSupplierIds = "0"; int TypeFlag = 0; //0-from supplier 1- from address book
                    for (int i = 0; i < grdAddressBookList.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdAddressBookList.Rows[i].Cells[0].Value) == true)
                        { 
                            if (pbAddressBookIds == "0")
                            {
                                pbAddressBookIds = Convert.ToString(grdAddressBookList.Rows[i].Cells["ID"].Value);
                            }
                            else
                            {
                                pbAddressBookIds = pbAddressBookIds + ',' + Convert.ToString(grdAddressBookList.Rows[i].Cells["ID"].Value);
                            } 
                            varCount++;
                        }
                    }
                }
                else
                {
                    return;
                }
                if (varCount == 0)
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MainForm.objLabelCount = new LabelCount();
                MainForm.objLabelCount.varSupplierIds = varSupplierIds;
                MainForm.objLabelCount.varAddressBookIds = pbAddressBookIds;
                MainForm.objLabelCount.varDetailFlag = 0;
                MainForm.objLabelCount.varFlag = 4;
                MainForm.objLabelCount.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grbFilterBySupplier_Enter(object sender, EventArgs e)
        {

        }

        private void cmbType_Enter(object sender, EventArgs e)
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

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbType_Leave(object sender, EventArgs e)
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

        private void tsbEmpty_Click(object sender, EventArgs e)
        {
            try
            { 
                MainForm.objLabelCount = new LabelCount(); 
                MainForm.objLabelCount.varAddressBookIds = "";
                MainForm.objLabelCount.varDetailFlag = 1;
                MainForm.objLabelCount.varFlag = 4;
                MainForm.objLabelCount.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbEnvelopPrint_Click(object sender, EventArgs e)
        {
            try
            { 
                int varCount = 0;
                if (grdAddressBookList.Rows.Count > 0)
                {
                    varSupplierIds = "0"; pbAddressBookIds = "0"; int TypeFlag = 0; //0-from supplier 1- from address book
                    for (int i = 0; i < grdAddressBookList.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdAddressBookList.Rows[i].Cells[0].Value) == true)
                        {
                            TypeFlag = Convert.ToInt16(grdAddressBookList.Rows[i].Cells["IsEditable"].Value);
                            if (TypeFlag == 0)
                            {
                                if (varSupplierIds == "0")
                                {
                                    varSupplierIds = Convert.ToString(grdAddressBookList.Rows[i].Cells["ID"].Value);
                                }
                                else
                                {
                                    varSupplierIds = varSupplierIds + ',' + Convert.ToString(grdAddressBookList.Rows[i].Cells["ID"].Value);
                                }
                            }
                            else
                            {
                                if (pbAddressBookIds == "0")
                                {
                                    pbAddressBookIds = Convert.ToString(grdAddressBookList.Rows[i].Cells["ID"].Value);
                                }
                                else
                                {
                                    pbAddressBookIds = pbAddressBookIds + ',' + Convert.ToString(grdAddressBookList.Rows[i].Cells["ID"].Value);
                                }
                            }
                            varCount++;
                        }
                    }
                }
                else
                {
                    return;
                }
                if (varCount == 0)
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(pbPrintFlag!=0)
                {
                    MainForm.objPrintDetails = new PrintDetails();
                    MainForm.objPrintDetails.ShowDialog();
                }
                MainForm.objLabelCount = new LabelCount();
                MainForm.objLabelCount.varSupplierIds = varSupplierIds;
                MainForm.objLabelCount.varAddressBookIds = pbAddressBookIds;
                MainForm.objLabelCount.varDetailFlag = pbDetailFlag;
                MainForm.objLabelCount.varFlag = 3;
                MainForm.objLabelCount.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdAddressBookList.CurrentCell is DataGridViewCheckBoxCell)
                {
                    grdAddressBookList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
          

        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            { 
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
