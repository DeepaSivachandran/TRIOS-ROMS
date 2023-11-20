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
    public partial class PUR_POMappedProducts : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode, DefProductsCode="";
        public DataTable dtMappedProduct;
        public string pbFormStatus;
        public int VARFLAG = 0;
        public PUR_POMappedProducts()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
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

        private void PUR_POMappedProducts_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text) != 0)
                {
                    lblNoRecordsFound.Visible = false;
                    this.ActiveControl = txtSearchByProduct2;
                    this.Text = MainForm.objPUR_PurchaseOrder.txtSupplier.Text;
                    dtMappedProduct = new DataTable();
                    dtMappedProduct.Columns.Add("", typeof(Boolean));
                    dtMappedProduct.Columns.Add("S.No.", typeof(string));
                    dtMappedProduct.Columns.Add("P.I Code", typeof(string));
                    dtMappedProduct.Columns.Add("Product Name", typeof(string));
                    dtMappedProduct.Columns.Add("Unit", typeof(string));
                    dtMappedProduct.Columns.Add("R.Sales Rate", typeof(string));
                    dtMappedProduct.Columns.Add("MSQ", typeof(string));
                    dtMappedProduct.Columns.Add("Stock", typeof(float));
                    dtMappedProduct.Columns.Add("Reorder Qty", typeof(string));
                    dtMappedProduct.Columns.Add("Product ID", typeof(int));
                    dtMappedProduct.Columns.Add("GST_Text", typeof(string));
                    dtMappedProduct.Columns.Add("PREVIOUS", typeof(string));
                    dtMappedProduct.Columns.Add("PARTIAL", typeof(string));
                    dtMappedProduct.Columns.Add("ordervalue", typeof(string));
                    if (Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text) != 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnproductmasterlist(33, 0, 0, 0, 0, "", "", "", Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue), 0, 0, Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblschedule.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, "", Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text), MainForm.objPUR_PurchaseOrder.pbProductsCode,null);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                       dtMappedProduct.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name"]
                                        , objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["SalesRate"], objDs.Tables[0].Rows[i]["MSQ"], objDs.Tables[0].Rows[i]["Stock"],
                                        objDs.Tables[0].Rows[i]["Reorder"], objDs.Tables[0].Rows[i]["Productid"], objDs.Tables[0].Rows[i]["GST_Text"],
                                        objDs.Tables[0].Rows[i]["PREVIOUS"], objDs.Tables[0].Rows[i]["PARTIAL"], objDs.Tables[0].Rows[i]["ordervalue"]);
                                    }
                                    grdPurchaseOrder.DataSource = dtMappedProduct;
                                    grdPurchaseOrder.Columns[0].HeaderText = "";
                                    grdPurchaseOrder.Columns[0].Width = 30;
                                    grdPurchaseOrder.Columns["S.No."].Width = 50;
                                    grdPurchaseOrder.Columns[0].ReadOnly = false;
                                    grdPurchaseOrder.Columns[0].Frozen = true;
                                    grdPurchaseOrder.Columns["P.I Code"].Width = 100;
                                    grdPurchaseOrder.Columns["Product Name"].Width = 300;
                                    grdPurchaseOrder.Columns["Product Name"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    grdPurchaseOrder.Columns["Unit"].Width = 70;
                                    grdPurchaseOrder.Columns["R.Sales Rate"].Width = 100;
                                    grdPurchaseOrder.Columns["MSQ"].Width = 70;
                                    grdPurchaseOrder.Columns["Stock"].Width = 80;
                                    grdPurchaseOrder.Columns["Product id"].Visible = false;
                                    grdPurchaseOrder.Columns["GST_Text"].Visible = false;
                                    grdPurchaseOrder.Columns["PREVIOUS"].Visible = false;
                                    grdPurchaseOrder.Columns["PARTIAL"].Visible = false;
                                    grdPurchaseOrder.Columns["R.Sales Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["Reorder Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["MSQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdPurchaseOrder.Columns["S.No."].ReadOnly = true;
                                    grdPurchaseOrder.Columns["P.I Code"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["Product Name"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["Unit"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["R.Sales Rate"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["MSQ"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["Stock"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["Reorder Qty"].ReadOnly = true;
                                    grdPurchaseOrder.Columns["ordervalue"].Visible = false;


                                }
                                else { lblNoRecordsFound.Visible = true; }
                            }
                            else { lblNoRecordsFound.Visible = true; }
                        }
                        else { lblNoRecordsFound.Visible = true; }
                    }
                    else { lblNoRecordsFound.Visible = true; }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdPurchaseOrder.ClearSelection(); 
                lblPC.Text = grdPurchaseOrder.Rows.Count.ToString();
            }
        }

        private void TxtSearchByProduct2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdPurchaseOrder.DataSource as DataTable).DefaultView.RowFilter = "([Product Name]) LIKE '%" + txtSearchByProduct2.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurchaseOrder_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPurchaseOrder.IsCurrentCellDirty)
                {
                    grdPurchaseOrder.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
            try
            {
                udfnAddProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAddProduct()
        {
            try
            {
                DefProductsCode = "";
                for (int i = 0; i < grdPurchaseOrder.Rows.Count; i++)
                {
                    if (DefProductsCode == "")
                    {
                        DefProductsCode = Convert.ToString(grdPurchaseOrder.Rows[i].Cells["Product ID"].Value);
                    }
                    else
                    {
                        DefProductsCode = DefProductsCode + ',' + Convert.ToString(grdPurchaseOrder.Rows[i].Cells["Product ID"].Value);
                    }
                }

                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet(); 
                objDs = objspdservice.udfnSupplierList(28, Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text), Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblschedule.Text), 0, 0, "", 0, 0, Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue), "", 0, 0, 0, 0, 0, 0,DefProductsCode);
                objspdservice.CloseConnection();

                for (int i = 0; i < grdPurchaseOrder.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdPurchaseOrder.Rows[i].Cells[0].Value) == true)
                    {
                        string defflag = "0";
                        if (objDs != null)
                        {
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString( objDs.Tables[0].Rows[i]["prid"])== Convert.ToString((grdPurchaseOrder.Rows[i].Cells["Product ID"].Value)))
                                {
                                    defflag = Convert.ToString(objDs.Tables[0].Rows[i]["flag"]);
                                }
                                else
                                {
                                    defflag = "4";
                                }
                            }
                        }
                        MainForm.objPUR_PurchaseOrder.grdsupplieradd.Rows.Add(MainForm.objPUR_PurchaseOrder.grdsupplieradd.Rows.Count + 1,
                        grdPurchaseOrder.Rows[i].Cells["P.I Code"].Value,grdPurchaseOrder.Rows[i].Cells["Product Name"].Value,grdPurchaseOrder.Rows[i].Cells["Unit"].Value, grdPurchaseOrder.Rows[i].Cells["GST_Text"].Value, (grdPurchaseOrder.Rows[i].Cells["MSQ"].Value),
                        (grdPurchaseOrder.Rows[i].Cells["Stock"].Value),grdPurchaseOrder.Rows[i].Cells["PREVIOUS"].Value,grdPurchaseOrder.Rows[i].Cells["PARTIAL"].Value, (grdPurchaseOrder.Rows[i].Cells["Reorder Qty"].Value),
                        grdPurchaseOrder.Rows[i].Cells["ordervalue"].Value, (grdPurchaseOrder.Rows[i].Cells["Product ID"].Value), defflag, 1);
                        VARFLAG = 1;
                    }
                }

                if(VARFLAG != 0)
                { 
                    MainForm.objPUR_PurchaseOrder.grdsupplieradd.Sort(MainForm.objPUR_PurchaseOrder.grdsupplieradd.Columns[1], ListSortDirection.Ascending);
                    for (int i = 0; i < MainForm.objPUR_PurchaseOrder.grdsupplieradd.RowCount; i++)
                    {
                        MainForm.objPUR_PurchaseOrder.grdsupplieradd.Rows[i].Cells["clmsno"].Value = i + 1;
                    }
                    this.Close();
                }
                 else
                {
                    SPDataService objDServ = new SPDataService();
                    if (grdPurchaseOrder.Rows.Count > 0)
                    {
                        string varMessage = objDServ.udfnGetMessages(80);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    { 
                        string varMessage = objDServ.udfnGetMessages(41);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_POMappedProducts_KeyDown(object sender, KeyEventArgs e)
        {
            try
            { 
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_POMappedProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (VARFLAG == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_Leave(object sender, EventArgs e)
        {
            try { txtSearchByProduct2.BackColor = Color.White; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSave_Leave(object sender, EventArgs e)
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

        private void BtnSave_Enter(object sender, EventArgs e)
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

        private void BtnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btnselectall_Click(object sender, EventArgs e)
        {
            try
            { 

                foreach (DataGridViewRow row in grdPurchaseOrder.Rows)
                {
                    row.Cells[0].Value = true;
                } 

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btnunselectall_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in grdPurchaseOrder.Rows)
                {
                    row.Cells[0].Value = false;
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
