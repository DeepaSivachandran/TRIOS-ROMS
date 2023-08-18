using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_BrandList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_BrandList()
        {
            InitializeComponent();
        }

        public void udfnCmbLoad()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_ProductGroup", "PRGID not in (0)", "PRG_EName,PRGID", cmbProductgroup, "", "PRG_EName", "PRGID");
                objDataBind.BindComboBoxListSelected("MR_ProductSubGroup", "PRSGID not in (0)", "PRSG_EName, PRSGID", cmbProductSubGroup, "", "PRSG_EName", "PRSGID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Brand = new CP_Brand();
                MainForm.objCP_Brand.MdiParent = ParentForm;
                MainForm.objCP_Brand.Show();
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

        private void CP_BrandList_Load(object sender, EventArgs e)
        {
            try
            {
                udfnList();
                udfnCmbLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfndelete()
        {
            try
            {
                if (grdBrandList.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SPDataService objDser = new SPDataService();
                        
                        string varResult = objDser.udfnBrand(2, Convert.ToInt16(grdBrandList.SelectedRows[0].Cells["ID"].Value.ToString()),"","", 0, "", "Deletion");
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
                if (grdBrandList.SelectedRows.Count > 0)
                {
                    MainForm.objCP_Brand = new CP_Brand();
                    MainForm.objCP_Brand.MdiParent = ParentForm;
                    MainForm.objCP_Brand.btnSave.Text = "Update";
                    MainForm.objCP_Brand.Show();
               
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        public void udfnList()
        {

            picLoader.Visible = true;
            Application.DoEvents();
            //********** To display a data in a grid  ******************
            grdBrandList.DataSource = null;
            DataSet objDs = new DataSet();
            //**** To call the function from SP ***************
            SPDataService objdserv = new SPDataService();
            objDs = objdserv.udfnBrandList(0, 0);
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
                        grdBrandList.DataSource = objDs.Tables[0];
                        //grdBrandList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        //grdBrandList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                     

                        //grdBrandList.Columns["S.No."].Width = 50;
                      
                        //grdBrandList.Columns["Brand Name in English"].Width = 250;
                        //grdBrandList.Columns["Brand Name in Tamil"].Width = 250;
                        //grdBrandList.Columns["Total Products"].Width = 100;
                        //grdBrandList.Columns["Status"].Width = 80;

                        //grdBrandList.Columns["ID"].Visible = false;
                        //grdBrandList.Columns["Status ID"].Visible = false;
                       
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


        public void grdBrandList_DoubleClick(object sender, EventArgs e)
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

        public void grdBrandList_KeyDown(object sender, KeyEventArgs e)
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
        

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 || e.ColumnIndex == 1))   /*If not our desired columns*/
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
      
    

        private void CmbProductgroup_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProductgroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductgroup_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProductgroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbProductSubGroup.Focus();
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductgroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbProductgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbProductgroup.Select(int.MaxValue, 0)));
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
                cmbProductSubGroup.BackColor = Color.LemonChiffon;
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
                cmbProductSubGroup.BackColor = Color.White;
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

        private void CmbProductSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbProductSubGroup.Select(int.MaxValue, 0)));
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
    }
}
