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
    public partial class PUR_PurchaseApproval : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public PUR_PurchaseApproval()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            { 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void PUR_PurchaseApprovalList_Load(object sender, EventArgs e)
        {
            try
            { 
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }

        }

        private void BtnRemarks_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            udfnclose();
        }
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnRemars_Click(object sender, EventArgs e)
        {
            try
            {

                MainForm.objPUR_RemarksHistory = new PUR_RemarksHistory();
                MainForm.objPUR_RemarksHistory.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGRNList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (GrdGRNList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmInvoiceMRP":
                            if (e.Button == MouseButtons.Right)
                            {
                                GrdGRNList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                                ContextMenu cm = new ContextMenu();
                                cm.MenuItems.Add(new MenuItem("Error"));
                                cm.Show(GrdGRNList, GrdGRNList.PointToClient(Cursor.Position));
                            }
                            break;
                        case "clmExpiryDate":
                            if (e.Button == MouseButtons.Right)
                            {
                                GrdGRNList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                                ContextMenu cm = new ContextMenu();
                                cm.MenuItems.Add(new MenuItem("Error"));
                                cm.Show(GrdGRNList, GrdGRNList.PointToClient(Cursor.Position));
                            }
                            break;
                        case "clmBatch":
                            if (e.Button == MouseButtons.Right)
                            {
                                GrdGRNList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                                ContextMenu cm = new ContextMenu();
                                cm.MenuItems.Add(new MenuItem("Error"));
                                cm.Show(GrdGRNList, GrdGRNList.PointToClient(Cursor.Position));
                            }
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { GrdGRNList.ClearSelection(); }
        }

        private void GrdPurchaseList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPurchaseList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmHSN":
                            if (e.Button == MouseButtons.Right)
                            {
                                grdPurchaseList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                                ContextMenu cm = new ContextMenu();
                                cm.MenuItems.Add(new MenuItem("Error"));
                                cm.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                            }
                            break;
                        case "clmPurchaseRate":
                            if (e.Button == MouseButtons.Right)
                            {
                                grdPurchaseList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                                ContextMenu cm = new ContextMenu();
                                cm.MenuItems.Add(new MenuItem("Error"));
                                cm.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                            }
                            break;
                        case "clmInvoiceQty":
                            if (e.Button == MouseButtons.Right)
                            {
                                grdPurchaseList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                                ContextMenu cm = new ContextMenu();
                                cm.MenuItems.Add(new MenuItem("Error"));
                                cm.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                            }
                            break;
                        case "clmReceivedQty":
                            if (e.Button == MouseButtons.Right)
                            {
                                grdPurchaseList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                                ContextMenu cm = new ContextMenu();
                                cm.MenuItems.Add(new MenuItem("Error"));
                                cm.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                            }
                            break;
                        case "clmFreeQty":
                            if (e.Button == MouseButtons.Right)
                            {
                                grdPurchaseList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                                ContextMenu cm = new ContextMenu();
                                cm.MenuItems.Add(new MenuItem("Error"));
                                cm.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                            }
                            break;
                        case "clmDiscAmnt":
                            if (e.Button == MouseButtons.Right)
                            {
                                grdPurchaseList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                                ContextMenu cm = new ContextMenu();
                                cm.MenuItems.Add(new MenuItem("Error"));
                                cm.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                            }
                            break;
                        case "clmDiscPer":
                            if (e.Button == MouseButtons.Right)
                            {
                                grdPurchaseList.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                                ContextMenu cm = new ContextMenu();
                                cm.MenuItems.Add(new MenuItem("Error"));
                                cm.Show(grdPurchaseList, grdPurchaseList.PointToClient(Cursor.Position));
                            }
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

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
