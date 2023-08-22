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
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
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

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbType.SelectedIndex.ToString() == "0") { // GRN
                    txtQRCode.ReadOnly = false;  
                    dpInvoiceDate.Enabled = false;
                    txtInvoiceNo.ReadOnly = true;
                    grdPODetails.Visible = true;
                    grdDCDetails.Visible = false;
                }
                if (cmbType.SelectedIndex.ToString() == "1") // PO
                {
                    MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                    MainForm.objPUR_GRNOrderType.ShowDialog();
                    txtQRCode.ReadOnly = true;
                    txtQRCode.Enabled = false;
                    dpInvoiceDate.Enabled = true;
                    txtInvoiceNo.ReadOnly = false;
                    grdPODetails.Visible = true;
                    grdDCDetails.Visible = false;
                }
                if (cmbType.SelectedIndex.ToString() == "2") // Direct
                {
                    txtQRCode.ReadOnly = true;
                    txtQRCode.Enabled = false;
                    dpInvoiceDate.Enabled = true;
                    txtInvoiceNo.ReadOnly = false;
                    grdPODetails.Visible = true;
                    grdDCDetails.Visible = false;
                }
                if (cmbType.SelectedIndex.ToString() == "3") // Direct DC
                {
                    MainForm.objPUR_DCDeatils = new PUR_DCDeatils();
                    MainForm.objPUR_DCDeatils.ShowDialog();
                    grdPODetails.Visible = false;
                    grdDCDetails.Visible = true;
                }
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
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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

        private void BtnDamage_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_POReturns = new PUR_POReturns();
                MainForm.objPUR_POReturns.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnRemarks_Click(object sender, EventArgs e)
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

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {

                MainForm.objCP_Items = new  CP_Product();
                MainForm.objCP_Items.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Purchase_Load(object sender, EventArgs e)
        {
            try
            {
                cmbType.Items.Insert(0, "Against GRN");
                cmbType.Items.Insert(1, "Against PO");
                cmbType.Items.Insert(2, "Direct");
                cmbType.Items.Insert(3, "Against Purchase DC");
                cmbType.SelectedIndex = 0;
                cmbPurchaseType.SelectedIndex = 0;
                dpInvoiceDate.Enabled = true;
               // this.tbDetails.DrawMode = TabDrawMode.OwnerDrawFixed;
              //  this.tbDetails.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TbDetails_DrawItem);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Purchase_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_GSTIN = new PUR_GSTIN();
                MainForm.objPUR_GSTIN.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCompleted.Checked) { btnSave.Text = "Save"; } else { btnSave.Text = "Draft"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TbDetails_SelectedIndexChanged(object sender, EventArgs e)
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
        private Color[] TColors = { Color.Salmon, Color.White, Color.LightBlue };
        private void TbDetails_DrawItem(object sender, DrawItemEventArgs e)
        {
            //// get ref to this page
            //TabPage tp = ((TabControl)sender).TabPages[e.Index];

            //using (Brush br = new SolidBrush(TColors[e.Index]))
            //{
            //    Rectangle rect = e.Bounds;
            //    e.Graphics.FillRectangle(br, e.Bounds);

            //    rect.Offset(1, 1);
            //    TextRenderer.DrawText(e.Graphics, tp.Text,
            //           tp.Font, rect, tp.ForeColor);

            //    // draw the border
            //    rect = e.Bounds;
            //    rect.Offset(0, 1);
            //    rect.Inflate(0, -1);

            //    // ControlDark looks right for the border
            //    using (Pen p = new Pen(SystemColors.ControlDark))
            //    {
            //        e.Graphics.DrawRectangle(p, rect);
            //    }

            //    if (e.State == DrawItemState.Selected) e.DrawFocusRectangle();
            //}
        }
    }
}
