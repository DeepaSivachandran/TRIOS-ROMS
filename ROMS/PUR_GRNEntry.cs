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
    public partial class PUR_GRNEntry : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public int varCloseFlag = 0;
        public PUR_GRNEntry()
        {
            InitializeComponent();
        }

         

        private void TxtEUnitName_KeyPress(object sender, KeyPressEventArgs e)
        {

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
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    varCloseFlag = 1;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_GRNEntry_Load(object sender, EventArgs e)
        {
            try
            {

                grdPODetails.Rows.Add(1,"07/08/2023","10");


                grdUnitList.Rows.Add("Bag","");
                grdUnitList.Rows.Add("Tin","");
                grdUnitList.Rows.Add("Box","");
                grdUnitList.Rows.Add("Excess", "3");
                grdUnitList.Rows.Add("Total", "");
                grdUnitList.Rows[grdUnitList.RowCount - 1].DefaultCellStyle.BackColor = Color.SlateGray;
                grdUnitList.Rows[grdUnitList.RowCount - 1].DefaultCellStyle.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_GRNEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
                {
                    udfnclose();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbOrderType.SelectedItem == "Against PO")
                {

                    MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                    MainForm.objPUR_GRNOrderType.ShowDialog();
                }
                else
                {
                    MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                    MainForm.objPUR_GRNOrderType.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdPODetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

               // grdPODetails.Rows.Add(1, "GNM", "02/08/2023", "GRN001", "", "02/08/2023", "I001", "50,000", "", "", "Venkat", "02/08/2023");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdPODetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MainForm.objPUR_POProducts = new PUR_POProducts();
                MainForm.objPUR_POProducts.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdUnitList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int targetRowIndex = 3; // Replace with the desired row index
            int targetColumnIndex = 1; // Replace with the desired column index
             
            if (e.RowIndex == targetRowIndex && e.ColumnIndex == targetColumnIndex)
            {
                // grdUnitList.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                grdUnitList.Rows[e.RowIndex].ReadOnly = true;
                grdUnitList.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                grdUnitList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                //e.CellStyle.BackColor = System.Drawing.Color.LightGray;
                //e.CellStyle.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void BtnDamage_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PODamagedView = new PUR_PODamagedView();
                MainForm.objPUR_PODamagedView.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PODamaged = new PUR_PODamaged();
                MainForm.objPUR_PODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
    }
}
