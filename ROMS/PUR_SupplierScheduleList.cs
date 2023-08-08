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
    public partial class PUR_SupplierScheduleList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public PUR_SupplierScheduleList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {

                MainForm.objCP_Supplier = new CP_Supplier();
                MainForm.objCP_Supplier.MdiParent = this.ParentForm;
                MainForm.objCP_Supplier.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
      
        private void BtnSchedulePopup_Click(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                MainForm.objPUR_POScheduledaywise = new PUR_POScheduledaywise();
                MainForm.objPUR_POScheduledaywise.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
            finally
            {
                //picLoader.Visible = false;
            }
        }

        private void PUR_SupplierScheduleList_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                   // tsbEdit_Click(sender, e);
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

        private void DgvSupplierScheduleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                MainForm.objCP_Supplier = new CP_Supplier();
                MainForm.objCP_Supplier.MdiParent = this.ParentForm;
                MainForm.objCP_Supplier.btnSave.Text = "Update";
                MainForm.objCP_Supplier.Show();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_SupplierScheduleList_Load(object sender, EventArgs e)
        {
            try
            {

                cmbStatus.SelectedIndex = 0;

                dgvSupplierScheduleList.Rows.Add(1, "Shiva Softwares Solutions", "Virudhunagar", "22AAAAA0000A1Z5", "", "", "Mobile", "Friday","48");

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
