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
    public partial class PUR_GRNDetailsList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public PUR_GRNDetailsList()
        {
            InitializeComponent();
        }

        private void TsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_GRNEntry = new PUR_GRNEntry();
                MainForm.objPUR_GRNEntry.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void TsBrandList_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PUR_GRNDetailsList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    TsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                   // TsbEdit_Click(sender, e);
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

        private void TsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_GRNDetails = new PUR_GRNDetails();
                MainForm.objPUR_GRNDetails.MdiParent = this.ParentForm;
                MainForm.objPUR_GRNDetails.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void PUR_GRNDetailsList_Load(object sender, EventArgs e)
        {
            try
            {


                grdPurchaseApproval.Rows.Add(1, "GNM", "02/08/2023", "GRN001", "", "02/08/2023","I001","50,000","", "", "Venkat", "02/08/2023");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdPurchaseApproval_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex != -1)
                {
                    switch (grdPurchaseApproval.Columns[e.ColumnIndex].Name)
                    {
                        case "ClmEdit":
                            MainForm.objPUR_GRNEntry = new PUR_GRNEntry();
                            MainForm.objPUR_GRNEntry.btnSave.Text = "Update && Print";
                            MainForm.objPUR_GRNEntry.ShowDialog();
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdPurchaseApproval_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_GRNDetails = new PUR_GRNDetails();
                MainForm.objPUR_GRNDetails.MdiParent = this.ParentForm;
                MainForm.objPUR_GRNDetails.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
    }
}
