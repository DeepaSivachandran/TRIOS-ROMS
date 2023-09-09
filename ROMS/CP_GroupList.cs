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
    public partial class CP_GroupList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        DataSet objDs = new DataSet();
        DataTable objDtExcel = new DataTable();
        public int varGroupCode = 0;
        public int varGroupId = 0;
        public CP_GroupList()
        {
            InitializeComponent();
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Group = new CP_Group();
                MainForm.objCP_Group.ShowDialog();
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
        public void udfnList()
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdGroupList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();

                int varGroupId = 0;
                if (txtProductGroup.Text == "")
                {
                    varGroupId = 0;
                }
                else
                {
                    DataService objDServ = new DataService();
                    string varId_Group = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_ProductGroup WHERE PRG_EName = '" + txtProductGroup.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT PRGID FROM MR_ProductGroup WHERE PRG_EName = '" + txtProductGroup.Text.Trim() + "') END AS PRGID ");
                    objDServ.CloseConnection();
                    varGroupId = Convert.ToInt32(varId_Group);
                }
                objDs = objdserv.udfnGroupList(0, varGroupId, 0,"");
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
                            grdGroupList.DataSource = objDs.Tables[0];
                            grdGroupList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGroupList.Columns["Total Sub Groups"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGroupList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                           
                            grdGroupList.Columns["S.No."].Width = 50;
                            grdGroupList.Columns["Product Group Name in English"].Width = 200;
                            grdGroupList.Columns["Product Group Name in Tamil"].Width = 200;
                            grdGroupList.Columns["Total Sub Groups"].Width = 200;
                            grdGroupList.Columns["Total Products"].Width = 100;
                            grdGroupList.Columns["Status"].Width = 80;
                            grdGroupList.Columns["ID"].Visible = false;
                            grdGroupList.Columns["Status ID"].Visible = false;

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
                lblNoOfPrGroup.Text = Convert.ToString(grdGroupList.Rows.Count);
                varGroupCode = Convert.ToInt32(varGroupId);
            }
        }
        public void udfndelete()
        {
            try
            {
                if (grdGroupList.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SPDataService objDser = new SPDataService();
                        string varResult = objDser.udfnGroup(2, Convert.ToInt16(grdGroupList.SelectedRows[0].Cells["ID"].Value.ToString()),"", "", 0, "Product Group Deletion");
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
            }
        }
        private void udfnEdit()
        {
            try
            {
                if(grdGroupList.SelectedRows.Count != 0)
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objCP_Group = new CP_Group();
                    MainForm.objCP_Group.btnSave.Text = "Update";
                    MainForm.objCP_Group.varId = Convert.ToInt32(grdGroupList.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_Group.varGroupNameinEnglish = Convert.ToString(grdGroupList.SelectedRows[0].Cells["Product Group Name in English"].Value);
                    MainForm.objCP_Group.varGroupNameinTamil = Convert.ToString(grdGroupList.SelectedRows[0].Cells["Product Group Name in Tamil"].Value);
                    MainForm.objCP_Group.varStatus = Convert.ToInt32(grdGroupList.SelectedRows[0].Cells["Status ID"].Value);
                    picLoader.Visible = false;
                    picLoader.SendToBack();
                    MainForm.objCP_Group.ShowDialog();
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
                lvGroup.Visible = false;
                btnView.BackColor = Color.LemonChiffon;
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
        private void CP_GroupList_KeyDown(object sender, KeyEventArgs e)
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
        private void CP_GroupList_Load(object sender, EventArgs e)
        {
            try
            {
                //BeginInvoke(new Action(() => cmbProductGroup.Select(int.MaxValue, 0)));
                this.ActiveControl = txtProductGroup;
                //udfnLoadCmbProductGroup();
                udfnList();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdGroupList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdGroupList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdGroupList.Rows[i].Cells["Status ID"].Value) == "1")
                    {
                        grdGroupList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdGroupList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdGroupList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdGroupList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
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
                grdGroupList.ClearSelection();
            }
        }
        private void GrdGroupList_DoubleClick(object sender, EventArgs e)
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
        private void GrdGroupList_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbProductGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                //cmbProductGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbProductGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                //cmbProductGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //BeginInvoke(new Action(() => cmbProductGroup.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbProductGroup_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbProductGroup_KeyDown(object sender, KeyEventArgs e)
        {

        }
        public void udfnLoadCmbProductGroup()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varViewType = 3;
                objDT = objdserv.udfnGroupList(varViewType, 0,0,"");
                objdserv.CloseConnection();
                //cmbProductGroup.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            //cmbProductGroup.ValueMember = "PRGID";
                            //cmbProductGroup.DisplayMember = "PRG_EName";
                            //cmbProductGroup.DataSource = objDT.Tables[0];
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
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                btnView.Enabled=true;
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnView.Enabled= true;
                btnView.Focus();
            }
        }
        private void BtnExport_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                BtnExport_Click(sender, e);
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
                btnExport.Enabled=false;
                if ((grdGroupList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Product Group List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdGroupList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;
                    ExcelSheet.Cells[1, 1].Value = "Product Group List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;
                    foreach (DataGridViewColumn col in grdGroupList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "S.No." || col.Name == "Status"  )
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            else if (col.Name == "Total Sub Groups" || col.Name == "Total Products")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 50;
                            }

                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Total Sub Groups"  || col.Name == "Total Products")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdGroupList.Rows)
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
                btnExport.Enabled=true;
                btnExport.Focus();
            }
        }

        private void GrbFilterBy_Enter(object sender, EventArgs e)
        {

        }

        private void GrpSearch_Enter(object sender, EventArgs e)
        {

        }

        private void Pnlgroup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdGroupList.DataSource as DataTable).DefaultView.RowFilter = "([Product Group Name in English]) LIKE '%" + txtSearchProduct.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblNoOfPrGroup.Text = Convert.ToString(grdGroupList.Rows.Count);
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

        private void TxtProductGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    txtProductGroup.BackColor = Color.White;
                    if (txtProductGroup.Text.Trim() == "") { varGroupId = 0; }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
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
                if (txtProductGroup.Text.Length > 2)
                {
                    objDs = objspdservice.udfnGroupList(8, 0, 0, txtProductGroup.Text);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvGroup.Items.Add(objList);
                                }
                                lvGroup.Visible = true;
                            }
                        }
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

        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
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
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvGroup()
        {
            try
            {
                if (txtProductGroup.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvGroup.SelectedItems[0];
                    txtProductGroup.Text = selectedItem.SubItems[0].Text;
                    varGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvGroup.Visible = false;
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
                udfnLvGroup();
                btnView.Focus();
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
                    udfnLvGroup();
                    btnView.Focus();
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
