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
    public partial class PUR_POProducts : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus,pbSupplierCode="0",pbScheduleCode="0",pbPoid="0";
        public PUR_POProducts()
        {
            InitializeComponent();
        }

        private void PUR_POProducts_KeyDown(object sender, KeyEventArgs e)
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

        private void GrdPurchaseOrder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            try
            {
                for (int i = 0; i < grdPurchaseOrder.Rows.Count; i++)
                {

                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cell = dataGridView.Rows[i].Cells["clmStatus"];

                    if (Convert.ToString(grdPurchaseOrder.Rows[i].Cells["STSID"].Value) == "10")
                    {
                        cell.Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    else
                    {
                        cell.Style.BackColor = Color.RoyalBlue;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color 
                    }
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
               this.Close(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_POProducts_Load(object sender, EventArgs e)
        {
            try
            {
                udfnList();

                DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                GrdPurchaseOrder_DataBindingComplete(grdPurchaseOrder, args);
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
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 16;
                objMR_Supplier.paraSupplierid = Convert.ToInt32(pbSupplierCode);
                objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(pbScheduleCode);
                objMR_Supplier.ParaPOID = Convert.ToInt32(pbPoid);
                DataSet objDs = new DataSet();
                SPDataService objspdservice = new SPDataService();
                objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                objspdservice.CloseConnection();
                if (objDs.Tables[6].Rows.Count > 0)
                { 
                    grdPurchaseOrder.Rows.Clear();
                    for (int i = 0; i < objDs.Tables[6].Rows.Count; i++)
                    {
                        lblNoRecordsFound.Visible = false;
                        grdPurchaseOrder.Rows.Add(grdPurchaseOrder.Rows.Count + 1, objDs.Tables[6].Rows[i]["PR_PICode"].ToString(),
                        objDs.Tables[6].Rows[i]["PR_TName"].ToString(), objDs.Tables[6].Rows[i]["UT_Symbol"].ToString(),
                         objDs.Tables[6].Rows[i]["Unit Per box"].ToString(),
                        objDs.Tables[6].Rows[i]["POPR_OrderQty"].ToString(), objDs.Tables[6].Rows[i]["OrderQtyUnit"].ToString(), 
                        objDs.Tables[6].Rows[i]["RECEIVED"].ToString(), 
                        objDs.Tables[6].Rows[i]["POPR_RemainingQty"].ToString(), objDs.Tables[6].Rows[i]["STATUS"].ToString(), objDs.Tables[6].Rows[i]["STSID"].ToString()); 
                    }
                    txtPONo.Text = objDs.Tables[6].Rows[0]["PO_No"].ToString();
                    txtPODate.Text = objDs.Tables[6].Rows[0]["PO_Date"].ToString();
                    txtUserData.Text = objDs.Tables[6].Rows[0]["MakerDetails"].ToString();
                    txtPOSts.Text = objDs.Tables[6].Rows[0]["PO Status"].ToString();
                    grdPurchaseOrder.Columns["clmProduct"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    grdPurchaseOrder.Rows.Clear();
                }
                grdPurchaseOrder.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }  
    }
}
