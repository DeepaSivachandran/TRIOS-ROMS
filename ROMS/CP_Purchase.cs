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
    public partial class CP_Purchase : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_Purchase()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Purchase = new CP_Purchase();
                MainForm.objCP_Purchase.MdiParent = this;
                MainForm.objCP_Purchase.Show();
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
                cmbType.Items.Add("Direct");
                cmbType.Items.Add("Against PO");
                cmbType.Items.Add("Against Godown Entry");
                cmbType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        
        private void CP_BrandList_KeyDown(object sender, KeyEventArgs e)
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

        private void grdBrandList_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void grdBrandList_DoubleClick(object sender, EventArgs e)
        {

        }

        private void grdBrandList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
