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
{   //Created By:-Sathish
    //Created On:-17/09/2023
    public partial class CP_LocationList : Form
    {
        DataError objError;
        public CP_LocationList()
        {
            InitializeComponent();
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Location = new CP_Location();
                MainForm.objCP_Location.FormBorderStyle = FormBorderStyle.FixedSingle;
                MainForm.objCP_Location.ShowDialog();
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
        private void CP_LocationList_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Company", "COM_STSID=1 and COMID !=-1 Order by COMID", "COM_ShortName,COMID", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind = null;
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
                SPDataService objspservice = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objspservice.udfnStockLocationList(0,(Convert.ToInt16(cmbConcern.SelectedValue)));
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdGodownList.DataSource = objDs.Tables[0];

                            grdGodownList.Columns["ID"].Visible = false;
                            grdGodownList.Columns["ConcernID"].Visible = false;
                            grdGodownList.Columns["LocationTypeID"].Visible = false;
                            grdGodownList.Columns["StockApplicableID"].Visible = false;
                            grdGodownList.Columns["GodownTypeID"].Visible = false;
                            grdGodownList.Columns["StatusID"].Visible = false;
                            grdGodownList.Columns["S.No."].Width = 50;
                            grdGodownList.Columns["Location Name in English"].Width = 250;
                            grdGodownList.Columns["Location Name in Tamil"].Width = 250;
                            grdGodownList.Columns["Short Name"].Width = 100;
                            grdGodownList.Columns["Stock Applicable"].Width = 120;
                            grdGodownList.Columns["Status"].Width = 80;
                            grdGodownList.Columns["Godown Type"].Width = 150;
                            grdGodownList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGodownList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGodownList.Columns["Godown Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                    objspservice.CloseConnection();
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
        public void udfndelete()
        {
            try
            {
                if (grdGodownList.SelectedRows.Count > 0)
                {
                    string varResult = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {

                        SPDataService objspservice = new SPDataService();
                        varResult = "";
                        varResult = objspservice.udfnStockLocation(2,Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["ID"].Value),0,0,"","","",0,0,0,"Stock Delete");


                        if (varResult.Split('~')[0] == "3")
                        {
                            MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            udfnList();
                        }
                        else
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
                if (grdGodownList.SelectedRows.Count > 0)
                {
                    MainForm.objCP_Location = new CP_Location();
                    MainForm.objCP_Location.btnSave.Text = "Update";
                    MainForm.objCP_Location.varlocationcode = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_Location.PbConcernID = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["ConcernID"].Value);
                    MainForm.objCP_Location.PbLocationTypeID = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["LocationTypeID"].Value);
                    MainForm.objCP_Location.PbStockApplicableID = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["StockApplicableID"].Value);
                    MainForm.objCP_Location.PbLocationEName = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Location Name in English"].Value);
                    MainForm.objCP_Location.PbLocationTName = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Location Name in Tamil"].Value);
                    MainForm.objCP_Location.PbLocationSName = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Short Name"].Value);
                    MainForm.objCP_Location.PbConcern = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Concern"].Value);
                    MainForm.objCP_Location.PbLocationType = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Location Type"].Value);
                    MainForm.objCP_Location.PbStockApplicable = Convert.ToString(grdGodownList.SelectedRows[0].Cells["Stock Applicable"].Value);
                    MainForm.objCP_Location.PbStatus = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["StatusID"].Value);
                    MainForm.objCP_Location.PbGodownTypeStatus = Convert.ToInt32(grdGodownList.SelectedRows[0].Cells["GodownTypeID"].Value);
                    MainForm.objCP_Location.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_LocationList_KeyDown(object sender, KeyEventArgs e)
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
        public void grdLocationList_DoubleClick(object sender, EventArgs e)
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
        public void grdLocationList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) {
                    udfnEdit();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void grdLocationList_SelectionChanged(object sender, EventArgs e)
        {
            try {
                if (Convert.ToString(grdGodownList.Rows[grdGodownList.CurrentCell.RowIndex].Cells["LocationCode"].Value) == "1") { tsbDelete.Visible = false; tsbEdit.Visible = false;tssNew.Visible = false; }
                else { tsbDelete.Visible = true; tsbEdit.Visible = true; tssNew.Visible = true; }
            }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdGodownList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdGodownList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdGodownList.Rows[i].Cells["StatusID"].Value) == "1")
                    {
                        grdGodownList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdGodownList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdGodownList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdGodownList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    grdGodownList.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }            
        }
        private void GrdGodownList_DoubleClick(object sender, EventArgs e)
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
        private void GrdGodownList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                udfnEdit();
            }
        }
        private void CmbConcern_Enter(object sender, EventArgs e)
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
        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbConcern_Leave(object sender, EventArgs e)
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
        private void BtnView_Click(object sender, EventArgs e)
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
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if ((grdGodownList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Stock Location List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdGodownList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;
                    ExcelSheet.Cells[1, 1].Value = "Stock Location List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;
                    foreach (DataGridViewColumn col in grdGodownList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";
                            if (cIndex == 1)
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 25;
                            }
                            if (col.Name == "clmQty" || col.Name == "clmTotal")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdGodownList.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 4, cIndex] = rowa.Cells[col.Index].Value;
                            }
                        }
                    }
                    //   ExcelSheet.Protect(System.Configuration.ConfigurationManager.AppSettings["ExcelPassword"]);
                    ExcelObj.Visible = true;
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
