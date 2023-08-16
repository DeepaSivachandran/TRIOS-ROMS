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
            }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbLocation_Click(object sender, EventArgs e)
        {
            try
            {
                udfnHideGrids();
                grdLoction.Visible = true;
                tspHeader.Text = "Product Attributes Bulk Update : Stock location, Rack & MSQ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbMSQ_Click(object sender, EventArgs e)
        {
            try
            {
                udfnHideGrids();
                grdMSQ.Visible = true;
                tspHeader.Text = "Product Attributes Bulk Update : Minsales Qty & Barcode";
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
                udfnHideGrids();
                grdStock.Visible = true;
                tspHeader.Text = "Product Attributes Bulk Update : Min, Max stock & Reorder Qty";
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
                udfnHideGrids();
                grdShelfLife.Visible = true;
                tspHeader.Text = "Product Attributes Bulk Update : Bulk Unit, UPP & Shelf Life";
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
                udfnHideGrids();
                grdBatch.Visible = true;
                tspHeader.Text = "Product Attributes Bulk Update : Product Category, RM Flag & Batch";
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
                udfnHideGrids();
                grdWeight.Visible = true;
                tspHeader.Text = "Product Attributes Bulk Update : Net & Gross Weight";
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
                udfnHideGrids();
                grdBrand.Visible = true;
                tspHeader.Text = "Product Attributes Bulk Update : Group, Subgroup & Brand";
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
                udfnHideGrids();
                grdHSN.Visible = true;
                tspHeader.Text = "Product Attributes Bulk Update : HSN Name";
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
                udfnHideGrids();
                grdName.Visible = true;
                tspHeader.Text = "Product Attributes Bulk Update : Pro. Code, Name & Unit";
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
                TsbLocation_Click(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
