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
    public partial class CP_BulkAttributes : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        public int varFormFlag = 0;
        public CP_BulkAttributes()
        {
            InitializeComponent();
        }
        public void udfnHideGrids() {
            try {
                grdLoction.Visible = false;
                grdMSQ.Visible = false;
                grdStock.Visible = false;
                grdShelfLife.Visible = false;
                grdBatch.Visible = false;
                grdWeight.Visible = false;
                grdBrand.Visible = false;
                grdHSN.Visible = false;
                grdName.Visible = false;
                tsbLocation.BackColor = SystemColors.MenuBar;
                tsbMSQ.BackColor = SystemColors.MenuBar;
                tsbStock.BackColor = SystemColors.MenuBar;
                tsbShelflife.BackColor = SystemColors.MenuBar;
                tsbBatch.BackColor = SystemColors.MenuBar;
                tsbWeight.BackColor = SystemColors.MenuBar;
                tsbBrand.BackColor = SystemColors.MenuBar;
                tsbHsn.BackColor = SystemColors.MenuBar;
                tsbName.BackColor = SystemColors.MenuBar;
            }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadLocation() {
            try
            {
                udfnHideGrids();
                grdLoction.Visible = true;
                tspHeader.Text = "Product Attributes Bulk Update : Stock location, Rack & MSQ";
                tsbLocation.BackColor = Color.SkyBlue;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (varFormFlag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        udfnLoadLocation();
                    }
                }
                else
                {
                    udfnLoadLocation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                varFormFlag = 0;
            }
        }

        private void TsbMSQ_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnHideGrids();
                    grdMSQ.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Minsales Qty & Barcode";
                    tsbMSQ.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbStock_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnHideGrids();
                    grdStock.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Min, Max stock & Reorder Qty";
                    tsbStock.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbShelflife_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnHideGrids();
                    grdShelfLife.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Bulk Unit, UPP & Shelf Life";
                    tsbShelflife.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbBatch_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnHideGrids();
                    grdBatch.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Product Category, RM Flag & Batch";
                    tsbBatch.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbWeight_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnHideGrids();
                    grdWeight.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Net & Gross Weight";
                    tsbWeight.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbBrand_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnHideGrids();
                    grdBrand.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Group, Subgroup & Brand";
                    tsbBrand.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbHsn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnHideGrids();
                    grdHSN.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : HSN Name";
                    tsbHsn.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbName_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnHideGrids();
                    grdName.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Pro. Code, Name & Unit";
                    tsbName.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_BulkAttributes_Load(object sender, EventArgs e)
        {
            try
            {
                varFormFlag = 1;
                TsbLocation_Click(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_BulkAttributeVerify = new CP_BulkAttributeVerify();
                MainForm.objCP_BulkAttributeVerify.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
    }
}
