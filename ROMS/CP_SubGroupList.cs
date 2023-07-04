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
using ClosedXML.Excel;
namespace ROMS
{
    public partial class CP_SubGroupList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        DataSet objDs = new DataSet();
        DataTable objDtExcel = new DataTable();
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("VIEW_GroupType", "grouptypecode<>-1 and 1=1 Order by grouptypecode", "grouptypename,grouptypecode", cmbGroupType, "", "grouptypename", "grouptypecode");
                objDataBind = null;
                udfnList();
                loadnoofgroup();
                DataService objDserv = new DataService();
                lblGC.Text = objDserv.displaydata("SELECT count(*)from CP_GROUP");
                objDserv.CloseConnection();
                loadnoofgroup();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void loadnoofgroup()
        {
            try
            {
                string condition = "1=1";
                if(Convert.ToInt16(cmbGroupType.SelectedValue)==0)
                {
                    condition = "1=1";
                }
                else
                {
                    condition = "a.GroupTypeCode=" + Convert.ToInt16(cmbGroupType.SelectedValue);
                }
                DataService objDserv = new DataService();
                lblGC.Text = objDserv.displaydata("SELECT count(*) from CP_GROUP as a inner join DEF_GROUPTYPE as b on a.GroupTypeCode=b.GroupTypeCode where "+ condition);
                objDserv.CloseConnection();

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
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdGroupList.DataSource = null; 
                //**** To call the function from SP ***************

                if (cmbGroupType.Text == "")
                {
                    cmbGroupType.SelectedValue = 0;
                }

                SPDataService objdserv = new SPDataService();
            //    objDs = objdserv.udfnSPGroupList("List", "0",cmbGroupType.SelectedValue.ToString(), MainForm.pbUserID, MainForm.pbIpAddress);
                objdserv.CloseConnection();
                objDtExcel = objDs.Tables[0].Copy();
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
                            grdGroupList.Columns["SI.No."].Width = 60;
                            grdGroupList.Columns["Group Type"].Width = 200;
                            grdGroupList.Columns["Group Name in Tamil"].Width = 350;
                            grdGroupList.Columns["Group Name in English"].Width = 350;
                            grdGroupList.Columns["Total No.of RM"].Width = 100;
                            grdGroupList.Columns["Total No.of FG"].Width = 100; 
                            //grdGroupList.Columns["Label Name in English"].Width = 220;
                            //grdGroupList.Columns["Label Name in Tamil"].Width = 220;
                            grdGroupList.Columns["Group Order"].Width = 100;                           
                            grdGroupList.Columns["Group Order"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGroupList.Columns["SI.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGroupList.Columns["Total No.of RM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGroupList.Columns["Total No.of FG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGroupList.Columns["GroupCode"].Visible = false;
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
                grdGroupList.ClearSelection();
                picLoader.Visible = false;
            }
        }

        public void udfndelete()
        {
            try
            {
                if (grdGroupList.SelectedRows.Count > 0)
                {
                    string result = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {

                        SPDataService objspdservice = new SPDataService();
                     //   result = objspdservice.udfnSPGroupMaster("Delete", grdGroupList.SelectedRows[0].Cells["GroupCode"].Value.ToString(),"","","", "", "","", MainForm.pbUserID, MainForm.pbIpAddress, "Group Delete");

                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            udfnList();
                            loadnoofgroup();

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

                if (grdGroupList.SelectedRows.Count > 0)
                {
                    MainForm.objCP_Group = new CP_Group();
                    //MainForm.objCP_Group.MdiParent = this.ParentForm;
                    MainForm.objCP_Group.vargroupcode = grdGroupList.SelectedRows[0].Cells["GroupCode"].Value.ToString();
                    MainForm.objCP_Group.ShowDialog();

                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void cmbGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList();
                loadnoofgroup();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        public void grdGroupList_DoubleClick(object sender, EventArgs e)
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

        public void grdGroupList_KeyDown(object sender, KeyEventArgs e)
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            try {
                if (grdGroupList.Rows.Count > 0)
                {
                    //Microsoft.Office.Interop.Excel._Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();
                    //// creating new WorkBook within Excel application  
                    //Microsoft.Office.Interop.Excel._Workbook ExcelBook = ExcelObj.Workbooks.Add(Type.Missing);
                    //// creating new Excelsheet in workbook  
                    //Microsoft.Office.Interop.Excel._Worksheet ExcelSheet = null;
                    //// see the excel sheet behind the program  
                    //ExcelObj.Visible = true;
                    //ExcelSheet = ExcelBook.Sheets["Sheet1"];
                    //ExcelSheet = ExcelBook.ActiveSheet;
                    //ExcelSheet.Name = "Group Master List";
                    //int count = 0;
                    //foreach (DataGridViewColumn col in grdGroupList.Columns)
                    //{
                    //    if (col.Visible)
                    //    {
                    //        count++;
                    //    }

                    //}
                    //ExcelSheet.Cells[1, 1].Value = "Group Master List";
                    //ExcelSheet.Columns.AutoFit();
                    //ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    //ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    //ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                    //ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 15;
                    //ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    //ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    //ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Excel.XlRgbColor.rgbSlateGray;
                    //int cIndex = 0;
                    //foreach (DataGridViewColumn col in grdGroupList.Columns)
                    //{
                    //    if (col.Visible)
                    //    {
                    //        if (col.HeaderText != "Remove")
                    //        {
                    //            cIndex++;
                    //            ExcelSheet.Cells[2, cIndex] = col.HeaderText;

                    //            foreach (DataGridViewRow rowa in grdGroupList.Rows)
                    //            {
                    //                ExcelSheet.Columns[cIndex].NumberFormat = "@";
                    //                ExcelSheet.Cells[(rowa.Index + 3), cIndex] = rowa.Cells[col.Index].Value.ToString();
                    //                ExcelSheet.Cells[(rowa.Index +3), cIndex].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                    //            }
                    //        }
                    //    }
                    //}
                    ////ExcelObj.Visible = true;
                    //ExcelObj.GetSaveAsFilename();
                    DataTable objDt = new DataTable();
                    objDt = objDtExcel.Copy();
                    objDt.Columns.Remove("GroupCode");
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "Execl files (*.xls)|*.xls";
                        sv.FilterIndex = 0;
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            var sheet = wb.Worksheets.Add("Group List");
                            //sheet.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            //sheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.White;
                            //sheet.Cell(1, 1).Style.Font.Bold = true;
                            //sheet.Cell(1, 1).Style.Font.FontSize = 15; 

                            sheet.Cell(1, 1).InsertTable(objDt);

                         //   sheet.Cell(objDt.Rows.Count + 4, 1).InsertData(objDt.Rows);
                            sheet.Tables.FirstOrDefault().ShowAutoFilter = false;
                            wb.SaveAs(sv.FileName);
                            MessageBox.Show("Successfully Downloaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void grdGroupList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //udfnscrollVisible();
            //int IntVScrollBarWidth = 0;
            //DataService objDser = new DataService();
            //IntVScrollBarWidth = objDser.udfnVscrollBarWidth(grdGroupList);
            //objDser.CloseConnection();
            //if (IntVScrollBarWidth != 0)
            //{
            //    //List<int> visibleColumns = new List<int>();
            //    //foreach (DataGridViewColumn col in grdGroupList.Columns)
            //    //{
            //    //    DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
            //    //    visibleColumns.Add(col.Index);
            //    //}
            //    //int rowIndex = 1;
            //    //DGV_SearchGrid.Rows.Add();
            //    //for (int i = 0; i < visibleColumns.Count; i++)
            //    //{
            //    //    DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
            //    //}
            //}
        }
        
    }
}
