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
    public partial class PUR_PurchaseOrderList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public PUR_PurchaseOrderList()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                MainForm.objPUR_PurchaseOrder = new PUR_PurchaseOrder();
                MainForm.objPUR_PurchaseOrder.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void TsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PurchaseOrder = new PUR_PurchaseOrder(); 
                //MainForm.objPUR_PurchaseOrder.StartPosition = FormStartPosition.Manual;
                //int dialogX = this.Location.X + (this.Width - MainForm.objPUR_PurchaseOrder.Width) / 2;
                //int dialogY = this.Location.Y + (this.Height - MainForm.objPUR_PurchaseOrder.Height + 100) / 2;
               // MainForm.objPUR_PurchaseOrder.Location = new Point(dialogX, dialogY);

                MainForm.objPUR_PurchaseOrder.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseOrder.Show(); 
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
                MainForm.objPUR_PurchaseOrder = new PUR_PurchaseOrder();
                //MainForm.objPUR_PurchaseOrder.StartPosition = FormStartPosition.Manual;
                //int dialogX = this.Location.X + (this.Width - MainForm.objPUR_PurchaseOrder.Width) / 2;
                //int dialogY = this.Location.Y + (this.Height - MainForm.objPUR_PurchaseOrder.Height + 100) / 2;
                // MainForm.objPUR_PurchaseOrder.Location = new Point(dialogX, dialogY);

                MainForm.objPUR_PurchaseOrder.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseOrder.gpissued.Enabled = true;
                MainForm.objPUR_PurchaseOrder.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void PUR_PurchaseOrderList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    TsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    TsbEdit_Click(sender, e);
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

        private void GrdPurchaseorderlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 
                if (e.RowIndex != -1)
                {
                    switch (grdPurchaseorderlist.Columns[e.ColumnIndex].Name)
                    {
                        case "clmView":
                            MainForm.objPUR_POIssuedDetails = new PUR_POIssuedDetails();
                            MainForm.objPUR_POIssuedDetails.ShowDialog();
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

        private void PUR_PurchaseOrderList_Load(object sender, EventArgs e)
        {
            try
            {
                cmbShow.SelectedItem = 0;
                grdPurchaseorderlist.Rows.Add(1, "GNM","PO001","02/08/2023","",19,"15.000","","Venkat","02/08/2023","","","","");

               //this.grdPurchaseorderlist.Dock = DockStyle.Fill;
               // this.grdPurchaseorderlist.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; 

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdPurchaseorderlist_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PurchaseOrder = new PUR_PurchaseOrder();
                MainForm.objPUR_PurchaseOrder.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseOrder.gpissued.Enabled = true;
                MainForm.objPUR_PurchaseOrder.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnViewProducts_Click(object sender, EventArgs e)
        {


            try
            {
                if (cmbShow.SelectedIndex == 0)
                {
                    grpProFilter.Visible = false;
                    grdProDetails.Visible = false;
                    grdPurchaseorderlist.Visible = true;
                    DGV_SearchGrid.Visible = true;
                }
                else
                {
                    grpProFilter.Visible = true;
                    grdProDetails.Visible = true; 
                    grdPurchaseorderlist.Visible = false;
                    DGV_SearchGrid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }

        }

        private void CmbShow_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BtnView_Click(object sender, EventArgs e)
        {

        }
    }
}
