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
    public partial class CP_SubGroupList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        DataSet objDs = new DataSet();
        DataTable objDtExcel = new DataTable();

        public int varSubGroupCode = 0;
        public CP_SubGroupList()
        {
            InitializeComponent();
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_SubGroup = new CP_SubGroup();
                MainForm.objCP_SubGroup.ShowDialog();
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
        private void CP_SubGroupList_Load(object sender, EventArgs e)
        {
            try
            {
                udfnBindCombobox();
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBindCombobox() {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (25,0) AND MSTID<>-1", "MST_DisplayText,MSTID", cmbBatchNoEntry, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STSID=0 OR STS_ModuleID = 1", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnList()
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdSubGroupList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();

                int varSubGroupId = 0;
                if (txtProductSubGroup.Text == "")
                {
                    varSubGroupId = 0;
                }
                else
                {
                    string varId_SubGroup = "0";
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtProductSubGroup.Text.Trim(), 0, 0, 0, 0);
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
                    varSubGroupId = Convert.ToInt32(varId_SubGroup);
                }
                string varId_Group = "0";
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
                            varId_Group = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                        }
                    }
                }
                lblGroupCode.Text = Convert.ToString(varId_Group);
                if (txtStockLocation.Text.Trim() == "") { lblSLCode.Text = "0"; }
                else
                {
                    string varId_PurLocation = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtStockLocation.Text.Trim(),0,0);
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
                    lblSLCode.Text = Convert.ToString(varId_PurLocation);
                }
                if (txtSaleRack.Text.Trim() == "") { lblRkCode.Text = "0"; }
                else
                {
                    string varId_PurRack = "0";
                    DataSet objDsPurRack = new DataSet();
                    SPDataService objDServ4 = new SPDataService();
                    objDsPurRack = objDServ4.udfnRackList(9, 0, 0, 0, 0, txtSaleRack.Text.Trim(),0);
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
                    lblRkCode.Text = Convert.ToString(varId_PurRack);
                }
                objDs = objdserv.udfnSubGroupList(0, varSubGroupId,"",Convert.ToInt32(lblGroupCode.Text),0,"",Convert.ToInt32(cmbStatus.SelectedValue),Convert.ToInt32(cmbBatchNoEntry.SelectedValue),Convert.ToInt32(lblSLCode.Text),Convert.ToInt32(lblRkCode.Text));
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
                            grdSubGroupList.DataSource = objDs.Tables[0];
                            grdSubGroupList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdSubGroupList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                           // grdSubGroupList.Columns["Batch No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            grdSubGroupList.Columns["S.No."].Width = 50;
                            grdSubGroupList.Columns["Product Group Name"].Width = 200;
                            grdSubGroupList.Columns["Product Sub Group Name in English"].Width = 250;
                            grdSubGroupList.Columns["Product Sub Group Name in Tamil"].Width = 250;
                            grdSubGroupList.Columns["Product Sub Group Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                            grdSubGroupList.Columns["Stock Location"].Width = 150;
                            grdSubGroupList.Columns["Rack"].Width = 100;
                            grdSubGroupList.Columns["Batch No."].Width = 100;
                            grdSubGroupList.Columns["Total Products"].Width = 100;
                            grdSubGroupList.Columns["Status"].Width = 80;

                            grdSubGroupList.Columns["ID"].Visible = false;
                            grdSubGroupList.Columns["Status ID"].Visible = false;
                            grdSubGroupList.Columns["Batch No Id"].Visible = false;
                            grdSubGroupList.Columns["StockLocation ID"].Visible = false;
                            grdSubGroupList.Columns["Rack ID"].Visible = false;
                            grdSubGroupList.Columns["Product Group Id"].Visible = false;
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
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
                // udfnSearchGridHead();
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
                lblNoOfPrSubGroup.Text = Convert.ToString(grdSubGroupList.Rows.Count);
                //varSubGroupCode = Convert.ToInt32(cmbProductSubGroup.SelectedValue);
            }
        }

        public void udfndelete()
        {
            try
            {
                if (grdSubGroupList.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SPDataService objDser = new SPDataService();
                        string varResult = objDser.udfnSubGroup(2, Convert.ToInt16(grdSubGroupList.SelectedRows[0].Cells["ID"].Value.ToString()), 0, "", "", 0, 0, 0, 0, "Product Sub Group Deletion","");
                        objDser.CloseConnection();
                        if (varResult.Split('~')[0] == "3")
                        {
                            MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            udfnList();
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
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void udfnEdit()
        {
            try
            {
                if (grdSubGroupList.SelectedRows.Count != 0)
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objCP_SubGroup = new CP_SubGroup();
                    MainForm.objCP_SubGroup.btnSave.Text = "Update";

                    MainForm.objCP_SubGroup.varId = Convert.ToInt32(grdSubGroupList.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_SubGroup.varGroupName = Convert.ToString(grdSubGroupList.SelectedRows[0].Cells["Product Group Name"].Value);
                    MainForm.objCP_SubGroup.varGroupCode = Convert.ToInt32(grdSubGroupList.SelectedRows[0].Cells["Product Group Id"].Value);
                    MainForm.objCP_SubGroup.varSubGroupNameinEnglish = Convert.ToString(grdSubGroupList.SelectedRows[0].Cells["Product Sub Group Name in English"].Value);
                    MainForm.objCP_SubGroup.varSubGroupNameinTamil = Convert.ToString(grdSubGroupList.SelectedRows[0].Cells["Product Sub Group Name in Tamil"].Value);
                    MainForm.objCP_SubGroup.varBatchNo = Convert.ToString(grdSubGroupList.SelectedRows[0].Cells["Batch No."].Value);
                    MainForm.objCP_SubGroup.varBatchId = Convert.ToInt32(grdSubGroupList.SelectedRows[0].Cells["Batch No Id"].Value);
                    MainForm.objCP_SubGroup.varStockLocationName = Convert.ToString(grdSubGroupList.SelectedRows[0].Cells["Stock Location"].Value);
                    MainForm.objCP_SubGroup.varLocationCode = Convert.ToInt32(grdSubGroupList.SelectedRows[0].Cells["StockLocation ID"].Value);
                    MainForm.objCP_SubGroup.varRackName = Convert.ToString(grdSubGroupList.SelectedRows[0].Cells["Rack"].Value);
                    MainForm.objCP_SubGroup.varRackCodes = Convert.ToString(grdSubGroupList.SelectedRows[0].Cells["Rack ID"].Value);
                    MainForm.objCP_SubGroup.varStatus = Convert.ToInt32(grdSubGroupList.SelectedRows[0].Cells["Status ID"].Value);
                    picLoader.Visible = false;
                    picLoader.SendToBack();
                    MainForm.objCP_SubGroup.ShowDialog();
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
                btnView.Enabled = false;
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnView.Enabled = true;
                btnView.Focus();

            }
        }

        private void CP_SubGroupList_KeyDown(object sender, KeyEventArgs e)
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
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.D))
                {
                    tsbDelete_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
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

   
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
                lvSubGroup.Visible = false;
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


        private void CmbProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                //cmbProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductSubGroup_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbProductSubGroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                //cmbProductSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //BeginInvoke(new Action(() => cmbProductSubGroup.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSubGroupList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdSubGroupList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdSubGroupList.Rows[i].Cells["Status ID"].Value) == "1")
                    {
                        grdSubGroupList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdSubGroupList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdSubGroupList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdSubGroupList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
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
                grdSubGroupList.ClearSelection();
            }
        }
        private void GrdSubGroupList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEdit();
                }
                if (e.KeyCode == Keys.Delete)
                {
                    udfndelete();
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
                    btnView_Click(sender, e);
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
                btnExport.Enabled = false;
                if ((grdSubGroupList.Rows.Count > 0))
                {
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
                    ExcelSheet.Name = "Product Sub Group List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdSubGroupList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Product Sub Group List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;

                   
                    foreach (DataGridViewColumn col in grdSubGroupList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "S.No." || col.Name == "Status" || col.Name == "Batch No.")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            else if (col.Name == "Stock Location" || col.Name == "Rack" || col.Name == "Total Products")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 50;
                            }
                            if (col.Name == "Total Products" || col.Name == "Batch No.")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdSubGroupList.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                            }
                        }
                    }
                    //   ExcelSheet.Protect(System.Configuration.ConfigurationManager.AppSettings["ExcelPassword"]);
                    ExcelObj.Visible = true;
                }
                else
                {
                    MessageBox.Show("No Record Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void BtnExport_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnExport_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSubGroupList.DataSource as DataTable).DefaultView.RowFilter = "([Product Sub Group Name in English]) LIKE '%" + txtSearchProduct.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblNoOfPrSubGroup.Text = Convert.ToString(grdSubGroupList.Rows.Count);
            }
        }

        private void TxtSearchProduct_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchProduct.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchProduct_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchProduct.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
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
                if(e.KeyCode==Keys.Enter)
                {
                    txtStockLocation.Focus();
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

        private void TxtProductSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblGroupCode.Text), 0, txtProductSubGroup.Text, 0, 0, 0, 0);
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
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 10.75F);
                                    lvSubGroup.Columns[2].Width = 200;
                                    lvSubGroup.Columns[0].Width = 200;
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
        public void udfnSubGroupevent()
        {
            try
            {
                if (txtProductSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    lblSubGroupId.Text = selectedItem.SubItems[1].Text;
                    txtProductSubGroup.Text = selectedItem.SubItems[0].Text;
                    txtStockLocation.Focus();
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

        private void TxtStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSaleRack_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSaleRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchNoEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbBatchNoEntry.Select(int.MaxValue, 0)));
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

        private void CmbBatchNoEntry_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBatchNoEntry.BackColor = Color.LemonChiffon;
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSaleRack_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSaleRack.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchNoEntry_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBatchNoEntry.BackColor = Color.White;
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

        private void TxtStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvStockLocation.Items.Count == 0 || txtStockLocation.Text == "")
                    {
                        txtStockLocation.Focus();
                        lvStockLocation.Visible = false;
                    }
                    else
                    {
                        lvStockLocation.Focus();
                    }
                    if (lvStockLocation.Items.Count > 0)
                    {
                        lvStockLocation.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtSaleRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSaleRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvSaleRack.Items.Count == 0 || txtSaleRack.Text == "")
                    {
                        txtSaleRack.Focus();
                        lvSaleRack.Visible = false;
                    }
                    else
                    {
                        lvSaleRack.Focus();
                    }
                    if (lvSaleRack.Items.Count > 0)
                    {
                        lvSaleRack.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBatchNoEntry.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchNoEntry_KeyDown(object sender, KeyEventArgs e)
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
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 10.75F);
                                    lvGroup.Columns[0].Width = 200;
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
        }

        private void LvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnBindProductGroup();
                    txtProductSubGroup.Focus();
                }
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
                udfnBindProductGroup();
                txtProductSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnBindProductGroup()
        {
            try
            {
                if (txtProductGroup.Text != "")
                {
                    ListViewItem selectedItem = lvGroup.SelectedItems[0];
                    lblGroupCode.Text = selectedItem.SubItems[1].Text;
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

        private void TxtStockLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0)
                {
                    objDs = objspdservice.udfnStockLocationList(13, 0, 0, 0, txtStockLocation.Text.Trim(), 0,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SL_TName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 10.75F);
                                    lvStockLocation.Columns[0].Width = 200;
                                    lvStockLocation.Columns[1].Width = 200;
                                    lvStockLocation.Items.Add(objList);
                                }
                                lvStockLocation.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvStockLocation.Visible = false;
                    lvStockLocation.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnBindLocation();
                    txtSaleRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStockLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnBindLocation();
                txtSaleRack.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnBindLocation()
        {
            try
            {
                if (txtStockLocation.Text != "")
                {
                    ListViewItem selectedItem = lvStockLocation.SelectedItems[0];
                    txtStockLocation.Text = selectedItem.SubItems[0].Text;
                    lblSLCode.Text = selectedItem.SubItems[2].Text;
                    lvStockLocation.Visible = false;
                    txtSaleRack.Text = "";
                    lblRkCode.Text = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvStockLocation.Visible = false;
            }
        }

        private void TxtSaleRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSaleRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSaleRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(8, 0, 0, Convert.ToInt32(lblSLCode.Text), 0, txtSaleRack.Text.Trim(), 0);
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
                                    lvSaleRack.Items.Add(objList);
                                }
                                lvSaleRack.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvSaleRack.Visible = false;
                    lvSaleRack.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSaleRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnBindRack();
                    cmbBatchNoEntry.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSaleRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnBindRack();
                cmbBatchNoEntry.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBindRack()
        {
            try
            {
                if (txtSaleRack.Text != "")
                {
                    ListViewItem selectedItem = lvSaleRack.SelectedItems[0];
                    txtSaleRack.Text = selectedItem.SubItems[0].Text;
                    lblRkCode.Text = selectedItem.SubItems[2].Text;
                    lvSaleRack.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSaleRack.Visible = false;
            }
        }

        private void GrdSubGroupList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
