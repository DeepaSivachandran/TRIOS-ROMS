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
        public int grid_flag = 0;
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
                grdGOConversion.DataSource = null;

                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 82;
                objMR_Product.ParaProductCode = Convert.ToInt32(varParentId);
                objMR_Product.paraStockTransfer = MainForm.objINV_GodownOutward.dtStock;
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
                                int rowIndex = grdGOConversion.Rows.Add(objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name"], objDs.Tables[0].Rows[i]["Batch Details"], objDs.Tables[0].Rows[i]["MRP"], objDs.Tables[0].Rows[i]["Expiry Date"], objDs.Tables[0].Rows[i]["Batch No."], objDs.Tables[0].Rows[i]["Location"], objDs.Tables[0].Rows[i]["Rack"], objDs.Tables[0].Rows[i]["UPP"], objDs.Tables[0].Rows[i]["UPPValue"], objDs.Tables[0].Rows[i]["Quantity"], objDs.Tables[0].Rows[i]["Unit"], "", "", objDs.Tables[0].Rows[i]["Bulk Unit"], "", objDs.Tables[0].Rows[i]["PRID"], objDs.Tables[0].Rows[i]["SLID"], objDs.Tables[0].Rows[i]["RKID"], objDs.Tables[0].Rows[i]["UTID"]);

                                grdGOConversion.Rows[rowIndex].Cells["clmTransferQty"].ReadOnly = true;
                                grdGOConversion.Rows[rowIndex].Cells["clmTransferQty"].Style.BackColor = Color.LightGray;
                            }
                            grdGOConversion.ClearSelection();
                            if (grdGOConversion.Rows.Count > 0)
                            {
                                grdGOConversion.ClearSelection();
                                grdGOConversion.CurrentCell = grdGOConversion.Rows[0].Cells["clmConversionQty"];
                                grdGOConversion.Rows[0].Selected = true;
                                grdGOConversion.Focus();
                            }
                            grdGOConversion.Columns["clmProduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdGOConversion.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGOConversion.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGOConversion.Columns["clmConversionQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGOConversion.Columns["clmTransferQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGOConversion.Columns["clmActualQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGOConversion.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGOConversion.Columns["clmUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGOConversion.Columns["clmChildUnit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGOConversion.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                if (grdGOConversion.IsCurrentCellDirty)
                {
                    grdGOConversion.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
                if (grdGOConversion.CurrentCell.OwningColumn.Name == "clmConversionQty"|| grdGOConversion.CurrentCell.OwningColumn.Name == "clmTransferQty")
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
                if (grdGOConversion.CurrentCell.OwningColumn.Name == "clmConversionQty" || grdGOConversion.CurrentCell.OwningColumn.Name == "clmTransferQty")
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                    {
                        e.Handled = true;
                    }
                    //only allow one decimal point
                    //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    if ((e.KeyChar == '.'))
                    {
                        e.Handled = true;
                    }
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
                bool blnErrFlag = false;
                bool qtyErrorFlag = false;

                decimal varRequiredQty = 0;
                decimal varTransferQty = 0;
                decimal.TryParse(lblRequiredQty.Text, out varRequiredQty);
                decimal.TryParse(lblTransferQty.Text, out varTransferQty);

                //Upp Wise Stock Maximum Transfer Allow Logic
                /*
                decimal minUPP = decimal.MaxValue;
                foreach (DataGridViewRow row in grdGOConversion.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["clmUPPValue"]?.Value != null &&
                        decimal.TryParse(row.Cells["clmUPPValue"].Value.ToString(), out decimal uppVal))
                    {
                        if (uppVal < minUPP)
                            minUPP = uppVal;
                    }
                }
                if (minUPP == decimal.MaxValue)
                    minUPP = 0;

                decimal varAllowedLimit = varRequiredQty + (minUPP > 0 ? (minUPP - 1) : 0);

                if (varTransferQty < varRequiredQty)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(113);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrFlag = true;
                }
                else if (varTransferQty > varAllowedLimit)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(113);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrFlag = true;
                }
                */
                if (varTransferQty != varRequiredQty)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(113);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrFlag = true;
                }
                if (!blnErrFlag)
                {
                    bool allRowsInvalid = true;

                    foreach (DataGridViewRow row in grdGOConversion.Rows)
                    {
                        if (row.IsNewRow) continue;

                        decimal stockQty = 0;
                        decimal conversionQty = 0;

                        decimal actualQty = 0;
                        decimal transferQty = 0;

                        if (row.Cells["clmQuantity"].Value != null)
                            decimal.TryParse(row.Cells["clmQuantity"].Value.ToString(), out stockQty);

                        if (row.Cells["clmConversionQty"].Value != null)
                            decimal.TryParse(row.Cells["clmConversionQty"].Value.ToString(), out conversionQty);

                        if (row.Cells["clmActualQty"].Value != null)
                            decimal.TryParse(row.Cells["clmActualQty"].Value.ToString(), out actualQty);

                        if (row.Cells["clmTransferQty"].Value != null)
                            decimal.TryParse(row.Cells["clmTransferQty"].Value.ToString(), out transferQty);

                        if (actualQty > 0 || transferQty > 0)
                        {
                            allRowsInvalid = false;
                        }
                        // Check if stockQty < conversionQty
                        if (stockQty < conversionQty)
                        {
                            row.Cells["clmConversionQty"].Style.BackColor = Color.LightPink;
                            qtyErrorFlag = true;
                            blnErrFlag = true;
                        }
                        else
                        {
                            row.Cells["clmConversionQty"].Style.BackColor = Color.PaleGreen;
                        }

                        // Check if actualQty < transferQty
                        if (actualQty < transferQty)
                        {
                            row.Cells["clmTransferQty"].Style.BackColor = Color.LightPink;
                            qtyErrorFlag = true;
                            blnErrFlag = true;
                        }
                        else
                        {
                            row.Cells["clmTransferQty"].Style.BackColor = Color.PaleGreen;
                        }

                        //ConversionQty filled but TransferQty empty or zero ---
                        if (conversionQty > 0 && transferQty <= 0)
                        {
                            row.Cells["clmTransferQty"].Style.BackColor = Color.LightPink;
                            allRowsInvalid = true;
                            blnErrFlag = true;
                        }

                        // ===== New Validation: UPP vs Consumed Qty =====
                        if (row.Cells["clmUPPValue"]?.Value != null &&
                            row.Cells["clmConversionQty"]?.Value != null &&
                            row.Cells["clmTransferQty"]?.Value != null)
                        {
                            decimal uppValue = 0, convertParentQty = 0, consumedParentQty = 0;
                            decimal.TryParse(row.Cells["clmUPPValue"].Value.ToString(), out uppValue);
                            decimal.TryParse(row.Cells["clmConversionQty"].Value.ToString(), out convertParentQty);
                            decimal.TryParse(row.Cells["clmTransferQty"].Value.ToString(), out consumedParentQty);


                            if (uppValue > 0 && convertParentQty > 0)
                            {
                                decimal minAllowed = (convertParentQty - 1) * uppValue;

                                if (consumedParentQty < minAllowed)
                                {
                                    row.Cells["clmTransferQty"].Style.BackColor = Color.LightPink;
                                    qtyErrorFlag = true;
                                    blnErrFlag = true;
                                }
                                else
                                {
                                    row.Cells["clmTransferQty"].Style.BackColor = Color.PaleGreen;
                                }
                            }
                        }
                    }

                    if (allRowsInvalid)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnErrFlag = true;
                    }
                    if (qtyErrorFlag)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(113);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnErrFlag = true;
                    }
                }

                if (!blnErrFlag)
                {
                    udfnConvert();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnConvert()
        {
            try
            {
                // Reference to the parent form
                var objOutward = MainForm.objINV_GodownOutward;

                // Loop through all child product rows
                foreach (DataGridViewRow row in grdGOConversion.Rows)
                {
                    if (row.IsNewRow) continue; // skip the blank row

                    // Get child quantities
                    var conversionQtyObj = row.Cells["clmActualQty"].Value;
                    var transferQtyObj = row.Cells["clmTransferQty"].Value;

                    // Skip row if either quantity is null or empty
                    if (conversionQtyObj == null || string.IsNullOrWhiteSpace(conversionQtyObj.ToString()) ||
                        transferQtyObj == null || string.IsNullOrWhiteSpace(transferQtyObj.ToString()))
                    {
                        continue; // skip this row
                    }

                    decimal conversionQty = 0;
                    decimal transferQty = 0;

                    // Safe parsing
                    decimal.TryParse(conversionQtyObj.ToString(), out conversionQty);
                    decimal.TryParse(transferQtyObj.ToString(), out transferQty);

                    // Skip row if either quantity is <= 0
                    if (conversionQty <= 0 || transferQty <= 0)
                    {
                        continue;
                    }

                    // Calculate parentMRP
                    decimal mrp = 0;
                    decimal uppValue = 0;
                    decimal.TryParse(row.Cells["clmMRP"].Value?.ToString(), out mrp);
                    decimal.TryParse(row.Cells["clmUPPValue"].Value?.ToString(), out uppValue);

                    decimal parentMRP = 0;
                    if (uppValue > 0) parentMRP = mrp / uppValue;

                    // Add to parent grid
                    objOutward.grdGoodsOutward.Rows.Add(
                        objOutward.grdGoodsOutward.Rows.Count + 1,
                        objOutward.varPRID,
                        objOutward.varPICode,
                        objOutward.varTamilname,
                        row.Cells["clmRKID"].Value,
                        row.Cells["clmRack"].Value,
                        string.Format("{0:F2}", decimal.Parse(Convert.ToString(parentMRP))), // MRP
                        row.Cells["clmExpiryDate"].Value,
                        row.Cells["clmBatchNo"].Value,
                        conversionQty, // Stock Quantity
                        0,
                        transferQty,   // Outward Quantity
                        objOutward.varUnit,
                        objOutward.varUTID,
                        objOutward.varDecimal
                    );

                    // dtStock
                    objOutward.dtStock.Rows.Add(
                        objOutward.varPRID,
                        string.Format("{0:F2}", decimal.Parse(Convert.ToString(parentMRP))),  // MRP
                        row.Cells["clmExpiryDate"].Value,
                        row.Cells["clmBatchNo"].Value,
                        objOutward.varUTID,
                        transferQty,           // Outward Qty
                        row.Cells["clmRKID"].Value,
                        row.Cells["clmSLID"].Value,
                        objOutward.varDestRKID,
                        conversionQty           // Stock Qty
                    );

                    // Add to child stock dtStockChild
                    objOutward.dtStockChild.Rows.Add(
                        row.Cells["clmPRID"].Value,          // STK_PRID
                        row.Cells["clmMRP"].Value,           // STK_MRP
                        row.Cells["clmExpiryDate"].Value,    // STK_ExpiryDate
                        row.Cells["clmBatchNo"].Value,       // STK_BatchNo
                        row.Cells["clmUTID"].Value,          // STK_UTID
                        row.Cells["clmConversionQty"].Value, // STK_QTY
                        row.Cells["clmRKID"].Value,          // STK_Source_RKID
                        row.Cells["clmSLID"].Value,          // STK_Dest_SLID
                        0,                                   // STK_Dest_RKID
                        0,                                   // STK_ProType
                        0                                    // STK_Status
                    );

                    // Add row to dtConvertedProduct
                    objOutward.dtConvertedProduct.Rows.Add(
                        objOutward.varPRID,                    // STKCONPR_PRID
                        string.Format("{0:F2}", decimal.Parse(Convert.ToString(parentMRP))), // STKCONPR_MRP
                        row.Cells["clmExpiryDate"].Value,      // STKCONPR_ExpiryDate
                        row.Cells["clmBatchNo"].Value,         // STKCONPR_BatchNo
                        conversionQty,                         // STKCONPR_TranactionQty (Outward Qty)
                        row.Cells["clmRKID"].Value,            // STKCONPR_RKID
                        row.Cells["clmSLID"].Value             // STKCONPR_SLID
                    );
                }

                objOutward.txtTotalItem.Text = objOutward.grdGoodsOutward.Rows.Count.ToString();

                var cols = objOutward.grdGoodsOutward.Columns;
                cols["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cols["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cols["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cols["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                cols["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                cols["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                int varQty = 0;
                varQty = Convert.ToInt32(lblParentQty.Text) - Convert.ToInt32(lblRequiredQty.Text);

                objOutward.txtOutwardQuantity.Text = Convert.ToString(varQty);
                objOutward.udfnAdd();
                // Clear product details
                //objOutward.udfnProductClear();
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void grdGOConversion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    e.Handled = true;

                //    DataGridView dgv = (DataGridView)sender;
                //    int colIndex = dgv.CurrentCell.ColumnIndex;
                //    int rowIndex = dgv.CurrentCell.RowIndex;

                //    // Check if current column is "clmConversionQty"
                //    if (dgv.Columns[colIndex].Name == "clmConversionQty")
                //    {
                //        // Find the "clmTransferQty" column
                //        int targetColIndex = dgv.Columns["clmTransferQty"].Index;

                //        // Check if the target cell is NOT read-only
                //        if (!dgv.Rows[rowIndex].Cells[targetColIndex].ReadOnly)
                //        {
                //            dgv.CurrentCell = dgv.Rows[rowIndex].Cells[targetColIndex];
                //            e.Handled = true;
                //            return;
                //        }
                //    }

                //    int nextRow = rowIndex + 1;
                //    if (nextRow < dgv.Rows.Count)
                //    {
                //        dgv.CurrentCell = dgv.Rows[nextRow].Cells[colIndex];
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (grdGOConversion.Focused)
                    grid_flag = 1;

                if (grid_flag == 1)
                {
                    if (keyData == Keys.Enter || keyData == Keys.Right || keyData == Keys.Tab)
                    {
                        if (grdGOConversion.CurrentCell == null)
                            return base.ProcessCmdKey(ref msg, keyData);

                        string currentColumn = grdGOConversion.Columns[grdGOConversion.CurrentCell.ColumnIndex].Name;
                        if (currentColumn != "clmConversionQty" && currentColumn != "clmTransferQty")
                            return base.ProcessCmdKey(ref msg, keyData);

                        int icolumn = grdGOConversion.CurrentCell.ColumnIndex;
                        int irow = grdGOConversion.CurrentCell.RowIndex;
                        int i = irow;
                        int intsection = grdGOConversion.Columns.Count - 1;
                        int intlvariant = grdGOConversion.Columns.Count - 9;

                        if (intsection == icolumn)
                        {
                            grdGOConversion.CurrentCell = grdGOConversion[intsection, irow + 1];
                            icolumn = grdGOConversion.Columns.Count - 1;
                            irow = grdGOConversion.CurrentCell.RowIndex;
                        }
                        else if (intlvariant == icolumn)
                        {
                        A:
                            if (icolumn == grdGOConversion.Columns.Count - 9)
                            {
                                if (irow < grdGOConversion.Rows.Count - 1)
                                {
                                    grdGOConversion.CurrentCell = grdGOConversion[3, irow + 1];
                                    icolumn = grdGOConversion.CurrentCell.ColumnIndex;
                                    irow = grdGOConversion.CurrentCell.RowIndex;
                                }
                                else
                                {
                                    grdGOConversion.CurrentCell = grdGOConversion[icolumn + 1, irow];
                                    if (grdGOConversion.CurrentCell.ReadOnly)
                                    {
                                        icolumn++;
                                        goto A;
                                    }
                                }
                            }
                            else
                            {
                                grdGOConversion.CurrentCell = grdGOConversion[icolumn + 1, irow];
                                if (grdGOConversion.CurrentCell.ReadOnly)
                                {
                                    icolumn++;
                                    goto A;
                                }
                            }
                        }
                        else
                        {
                        A:
                            if (icolumn == grdGOConversion.Columns.Count - 1)
                            {
                                if (irow < grdGOConversion.Rows.Count - 1)
                                {
                                    grdGOConversion.CurrentCell = grdGOConversion[13, irow + 1];
                                    icolumn = grdGOConversion.CurrentCell.ColumnIndex;
                                    irow = grdGOConversion.CurrentCell.RowIndex;
                                }
                                else
                                {
                                    grdGOConversion.ClearSelection();
                                }
                            }
                            else
                            {
                                if (!grdGOConversion[icolumn + 1, irow].Visible)
                                {
                                    icolumn++;
                                    goto A;
                                }
                                else
                                {
                                    grdGOConversion.CurrentCell = grdGOConversion[icolumn + 1, irow];
                                    if (grdGOConversion.CurrentCell.ReadOnly)
                                    {
                                        icolumn++;
                                        goto A;
                                    }
                                }
                            }
                        }

                        grid_flag = 0;
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void grdGoodsOutward_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;
                SPDataService objDServ = new SPDataService();
                var currentCell = grdGOConversion.Columns[e.ColumnIndex];
                var currentRow = grdGOConversion.Rows[e.RowIndex];

                int varErrFlag = 0;
                int varQuantity = Convert.ToInt32(currentRow.Cells["clmQuantity"].Value ?? 0);
                int varUPP = Convert.ToInt32(currentRow.Cells["clmUPPValue"].Value ?? 0);

                // --- Handle clmConversionQty edits ---
                if (currentCell.Name == "clmConversionQty")
                {
                    string strConversion = Convert.ToString(currentRow.Cells["clmConversionQty"].Value)?.Trim();
                    int varConversionQty = string.IsNullOrEmpty(strConversion) ? 0 : Convert.ToInt32(strConversion);

                    // If empty or zero → disable and clear TransferQty
                    if (varConversionQty <= 0)
                    {
                        currentRow.Cells["clmTransferQty"].ReadOnly = true;
                        currentRow.Cells["clmTransferQty"].Style.BackColor = Color.LightGray;
                        currentRow.Cells["clmTransferQty"].Value = "";
                        currentRow.Cells["clmActualQty"].Value = "";
                        CalculateTotalTransferQty();
                        return;
                    }

                    // If entered ConversionQty > available Quantity → show warning
                    if (varQuantity < varConversionQty)
                    {
                        currentRow.Cells["clmConversionQty"].Style.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrFlag = 1;
                    }
                    else
                    {
                        currentRow.Cells["clmConversionQty"].Style.BackColor = Color.PaleGreen;
                    }

                    // If no error → enable TransferQty
                    if (varErrFlag == 0)
                    {
                        currentRow.Cells["clmTransferQty"].ReadOnly = false;
                        currentRow.Cells["clmTransferQty"].Style.BackColor = Color.PaleGreen;
                    }
                    else
                    {
                        currentRow.Cells["clmTransferQty"].ReadOnly = true;
                        currentRow.Cells["clmTransferQty"].Style.BackColor = Color.LightGray;
                        currentRow.Cells["clmTransferQty"].Value = "";
                        currentRow.Cells["clmActualQty"].Value = "";
                    }

                    // Update ActualQty only if no errors
                    if (varErrFlag == 0 && varConversionQty > 0)
                    {
                        currentRow.Cells["clmActualQty"].Value = (varUPP * varConversionQty).ToString();
                        //CalculateTotalTransferQty();
                    }
                    else
                    {
                        currentRow.Cells["clmActualQty"].Value = "";
                    }
                }

                // --- Handle clmTransferQty edits ---
                else if (currentCell.Name == "clmTransferQty")
                {
                    string strTransfer = Convert.ToString(currentRow.Cells["clmTransferQty"].Value)?.Trim();
                    int varTransferQty = string.IsNullOrEmpty(strTransfer) ? 0 : Convert.ToInt32(strTransfer);

                    int varActualQty = Convert.ToInt32(currentRow.Cells["clmActualQty"].Value ?? 0);
                    int varConversionQty = Convert.ToInt32(currentRow.Cells["clmConversionQty"].Value ?? 0);

                    // Validation: ActualQty < TransferQty → highlight and warn
                    if (varActualQty < varTransferQty)
                    {
                        currentRow.Cells["clmTransferQty"].Style.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        currentRow.Cells["clmTransferQty"].Value = "";
                        varErrFlag = 1;
                    }
                    else
                    {
                        currentRow.Cells["clmTransferQty"].Style.BackColor = Color.PaleGreen;
                    }
                    CalculateTotalTransferQty();
                }
                //int requiredQty = Convert.ToInt32(lblRequiredQty.Text);
                //bool isValid = ValidateActualQtyForChildren(grdGOConversion, requiredQty);

                //if (!isValid)
                //{
                //    currentRow.Cells["clmConversionQty"].Value = "";
                //    currentRow.Cells["clmActualQty"].Value = "";
                //    CalculateTotalTransferQty();
                //    currentRow.Cells["clmTransferQty"].ReadOnly = true;
                //    currentRow.Cells["clmTransferQty"].Style.BackColor = Color.LightGray;
                //}
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

                /*
                foreach (DataGridViewRow row in grdGOConversion.Rows)
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
                */
                if (grdGOConversion != null && grdGOConversion.Columns.Contains("clmTransferQty"))
                {
                    foreach (DataGridViewRow row in grdGOConversion.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (row.Cells["clmTransferQty"]?.Value != null &&
                            decimal.TryParse(row.Cells["clmTransferQty"].Value.ToString(), out decimal qty))
                        {
                            totalTransferValue += qty;
                        }
                    }
                }
                lblTransferQty.Text = totalTransferValue.ToString("0.##");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private bool ValidateActualQtyForChildren(DataGridView grid, int requiredQty)
        {
            try
            {
                int varTotalActualQty = 0;
                int varChildCount = 0;

                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells["clmActualQty"].Value != null && int.TryParse(row.Cells["clmActualQty"].Value.ToString(), out int actualQty))
                    {
                        if (actualQty > 0)
                        {
                            varChildCount++;
                            varTotalActualQty += actualQty;
                        }
                    }
                }

                if (varChildCount == 1)
                    return true;
                if (varTotalActualQty > requiredQty)
                {
                    string message = $"Total Actual Quantity ({varTotalActualQty}) exceeds Required Quantity ({requiredQty}) for multiple children.";
                    MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return true;
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
