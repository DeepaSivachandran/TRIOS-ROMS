using ROMS.Model;
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
    public partial class INV_GoodsOutward_AutoConversion : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varParentId, varMasterType = "0";
        public string pbFormStatus;
        public INV_GoodsOutward_AutoConversion()
        {
            InitializeComponent();
        }
        public void udfnclose()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_PODamaged_Load(object sender, EventArgs e)
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
                btnSave.Focus();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdGoodsOutward.DataSource = null;

                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 82;
                objMR_Product.ParaProductCode = Convert.ToInt32(varParentId);
                SPDataService objdserv = new SPDataService();
                DataSet objDs;
                objDs = objdserv.udfnproductmasterlist(objMR_Product);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();

                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdGoodsOutward.Rows.Add(objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name"], objDs.Tables[0].Rows[i]["Batch Details"], objDs.Tables[0].Rows[i]["MRP"], objDs.Tables[0].Rows[i]["Expiry Date"], objDs.Tables[0].Rows[i]["Batch No."], objDs.Tables[0].Rows[i]["Location"], objDs.Tables[0].Rows[i]["Rack"], objDs.Tables[0].Rows[i]["UPP"],objDs.Tables[0].Rows[i]["UPPValue"], objDs.Tables[0].Rows[i]["Quantity"], objDs.Tables[0].Rows[i]["Unit"], "", "", objDs.Tables[0].Rows[i]["Bulk Unit"], objDs.Tables[0].Rows[i]["PRID"], objDs.Tables[0].Rows[i]["SLID"], objDs.Tables[0].Rows[i]["RKID"]);
                            }
                            grdGoodsOutward.ClearSelection();
                            grdGoodsOutward.Columns["clmProduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdGoodsOutward.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGoodsOutward.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGoodsOutward.Columns["clmConversionQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGoodsOutward.Columns["clmActualQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGoodsOutward.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGoodsOutward.Columns["clmUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGoodsOutward.Columns["clmChildUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGoodsOutward.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_PODamaged_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
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
        private void BrnPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BrnPrint_Leave(object sender, EventArgs e)
        {

            try
            {
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BrnPrint_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdGoodsOutward_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdGoodsOutward.IsCurrentCellDirty)
                {
                    grdGoodsOutward.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdGoodsOutward_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdGoodsOutward.CurrentCell.OwningColumn.Name == "clmConversionQty")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdGoodsOutward.CurrentCell.OwningColumn.Name == "clmConversionQty")
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                    {
                        e.Handled = true;
                    }
                    //only allow one decimal point
                    //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    //{
                    //    e.Handled = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private void grdGoodsOutward_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varQuantity = Convert.ToInt32(grdGoodsOutward.CurrentRow.Cells["clmQuantity"].Value);
                int varUPP = Convert.ToInt32(grdGoodsOutward.CurrentRow.Cells["clmUPPValue"].Value);
                int varTransferQuantity = 0;
                if (grdGoodsOutward.CurrentRow.Cells["clmConversionQty"].Value.ToString().Trim() != "")
                {
                    varTransferQuantity = Convert.ToInt32(grdGoodsOutward.CurrentRow.Cells["clmConversionQty"].Value);
                }
                if (varQuantity < varTransferQuantity)
                {
                    grdGoodsOutward.Rows[e.RowIndex].Cells["clmConversionQty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (grdGoodsOutward.CurrentRow.Cells["clmConversionQty"].Value.ToString().Trim() != "")
                {
                    grdGoodsOutward.CurrentRow.Cells["clmActualQty"].Value = Convert.ToString(varUPP * varTransferQuantity);
                    CalculateTotalTransferQty();
                }
                else { grdGoodsOutward.CurrentRow.Cells["clmActualQty"].Value = ""; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CalculateTotalTransferQty()
        {
            try
            {
                decimal totalTransferValue = 0;

                foreach (DataGridViewRow row in grdGoodsOutward.Rows)
                {
                    // Skip new rows or empty rows
                    if (row.IsNewRow) continue;

                    // Safe parse UPP
                    decimal upp = 0;
                    if (row.Cells["clmUPPValue"].Value != null &&
                        decimal.TryParse(row.Cells["clmUPPValue"].Value.ToString(), out decimal parsedUPP))
                    {
                        upp = parsedUPP;
                    }

                    // Safe parse TransferQty
                    decimal transferQty = 0;
                    if (row.Cells["clmConversionQty"].Value != null &&
                        decimal.TryParse(row.Cells["clmConversionQty"].Value.ToString(), out decimal parsedTransfer))
                    {
                        transferQty = parsedTransfer;
                    }

                    totalTransferValue += upp * transferQty;
                }

                lblTransferQty.Text = totalTransferValue.ToString("0.##");
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
    }
}
