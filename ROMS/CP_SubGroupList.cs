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
                udfnList();
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
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtProductSubGroup.Text.Trim());
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
                    //if (varCount == "0") { varSubGroupId = -1; }
                    //else
                    //{
                    //    varSubGroupId = Convert.ToInt32(lblSubGroupId.Text);
                    //}
                }
                objDs = objdserv.udfnSubGroupList(0, varSubGroupId, "",0,0,"");
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
                            grdSubGroupList.Columns["Stock Location"].Width = 150;
                            grdSubGroupList.Columns["Rack"].Width = 100;
                            grdSubGroupList.Columns["Batch No"].Width = 100;
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
                        string varResult = objDser.udfnSubGroup(2, Convert.ToInt16(grdSubGroupList.SelectedRows[0].Cells["ID"].Value.ToString()), 0, "", "", 0, 0, 0, 0, "Product Sub Group Deletion");
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
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); MessageBox.Show("Something went wrong,Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                    MainForm.objCP_SubGroup.varBatchNo = Convert.ToString(grdSubGroupList.SelectedRows[0].Cells["Batch No"].Value);
                    MainForm.objCP_SubGroup.varBatchId = Convert.ToInt32(grdSubGroupList.SelectedRows[0].Cells["Batch No Id"].Value);
                    MainForm.objCP_SubGroup.varStockLocationName = Convert.ToString(grdSubGroupList.SelectedRows[0].Cells["Stock Location"].Value);
                    MainForm.objCP_SubGroup.varLocationCode = Convert.ToInt32(grdSubGroupList.SelectedRows[0].Cells["StockLocation ID"].Value);
                    MainForm.objCP_SubGroup.varRackName = Convert.ToString(grdSubGroupList.SelectedRows[0].Cells["Rack"].Value);
                    MainForm.objCP_SubGroup.varRackCode = Convert.ToInt32(grdSubGroupList.SelectedRows[0].Cells["Rack ID"].Value);
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
        private void GrdSubGroupList_DoubleClick(object sender, EventArgs e)
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

                            if (col.Name == "S.No." || col.Name == "Status" || col.Name == "Batch No")
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
                            if (col.Name == "Total Products" || col.Name == "Batch No")
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

        private void TxtProductSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(9, 0, "", 0, 0, txtProductSubGroup.Text);
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
    }
}
