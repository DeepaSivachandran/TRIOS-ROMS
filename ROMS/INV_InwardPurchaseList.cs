using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class INV_InwardPurchaseList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        string varUserID = "0";
        public INV_InwardPurchaseList()
        {
            InitializeComponent();
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objINV_InwardPurchase = new INV_InwardPurchase();
                MainForm.objINV_InwardPurchase.MdiParent = this.ParentForm;
                //MainForm.objINV_Inward.StartPosition = FormStartPosition.Manual;
                //int dialogX = this.Location.X + (this.Width - MainForm.objINV_Inward.Width) / 2;
                //int dialogY = this.Location.Y + (this.Height - MainForm.objINV_Inward.Height + 100) / 2;
                //MainForm.objINV_Inward.Location = new Point(dialogX, dialogY);
                MainForm.objINV_InwardPurchase.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_InwardPurchaseList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    tsbEdit_Click(sender, e);
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
        private void INV_InwardPurchaseList_Load(object sender, EventArgs e)
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
        private void TsbQue_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objINV_InwardQueueList = new INV_InwardQueueList();
                MainForm.objINV_InwardQueueList.MdiParent = this.ParentForm;
                MainForm.objINV_InwardQueueList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpFromDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpToDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpToDate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtStockLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvSLocation.Items.Count == 0 || txtStockLocation.Text == "")
                    {
                        txtProductName.Focus();
                        lvSLocation.Visible = false;
                    }
                    else
                    {
                        lvSLocation.Focus();
                    }
                    if (lvSLocation.Items.Count > 0)
                    {
                        lvSLocation.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvProduct.Items.Count == 0 || txtProductName.Text == "")
                    {
                        txtProductName.Focus();
                        lvProduct.Visible = false;
                    }
                    else
                    {
                        lvProduct.Focus();
                    }
                    if (lvProduct.Items.Count > 0)
                    {
                        lvProduct.Items[0].Selected = true;
                    }
                }
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
        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
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
        public void udfnList()
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
        private void DpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                udfnDelete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDelete()
        {
            try
            {
                if (grdInwardList.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //SPDataService objDser = new SPDataService();
                        //string varResult = objDser.udfnHsn(2, Convert.ToInt16(grdInwardList.SelectedRows[0].Cells["ID"].Value.ToString()), 0, "", "", 0, "HSN Deletion", varUserID, 0);
                        //objDser.CloseConnection();
                        //if (varResult.Split('~')[0] == "3")
                        //{
                        //    if (varResult.Split('~')[1] == "1")
                        //    {
                        //        MainForm.objCP_Verify = new CP_Verify();
                        //        MainForm.objCP_Verify.ShowDialog();
                        //        varUserID = MainForm.objCP_Verify.varUserId;
                        //        if (MainForm.objCP_Verify.flag == 1)
                        //        {
                        //            objDser = new SPDataService();
                        //            varResult = objDser.udfnHsn(2, Convert.ToInt16(grdInwardList.SelectedRows[0].Cells["ID"].Value.ToString()), 0, "", "", 0, "HSN Deletion", varUserID, 1);
                        //            objDser.CloseConnection();
                        //            if (varResult.Split('~')[0] == "3")
                        //            {
                        //                MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //              //  udfnList();
                        //            }
                        //            else { MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        //        }
                        //    }
                        //}
                        //else if (varResult.Split('~')[0] == "4")
                        //{
                        //    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void GrdInwardList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tsbEdit_Click(sender, e);
            }
            if (e.KeyCode == Keys.Delete)
            {
                TsbDelete_Click(sender, e);
            }
        }
        private void GrdInwardList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                tsbEdit_Click(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                    BtnView_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
