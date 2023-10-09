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
        public string varbrandcode;
        public DataTable dtMappedProduct;
        public string pbFormStatus;
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

        private void PUR_POMappedProducts_Load(object sender, EventArgs e)
        {
            try
            {

                dtMappedProduct = new DataTable();
                dtMappedProduct.Columns.Add("", typeof(Boolean));
                dtMappedProduct.Columns.Add("S.No.", typeof(string));
                dtMappedProduct.Columns.Add("P.I Code", typeof(string));
                dtMappedProduct.Columns.Add("Product Name", typeof(string));
                dtMappedProduct.Columns.Add("Unit", typeof(string));
                dtMappedProduct.Columns.Add("R.Sales Rate", typeof(float));
                dtMappedProduct.Columns.Add("MSQ", typeof(float));
                dtMappedProduct.Columns.Add("Stock", typeof(float));
                dtMappedProduct.Columns.Add("Reorder Qty", typeof(float));
                dtMappedProduct.Columns.Add("Product ID", typeof(int));
                if (Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text) != 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnproductmasterlist(33, 0, 0, 0, 0, "", "", "", 0, 0, 0, 0, 0, 0, "", Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text));
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
                                        objDs.Tables[0].Rows[i]["Reorder"], objDs.Tables[0].Rows[i]["Productid"]);
                                }
                                grdPurchaseOrder.DataSource = dtMappedProduct;
                                grdPurchaseOrder.Columns[0].HeaderText = "";
                                grdPurchaseOrder.Columns[0].Width = 30;
                                grdPurchaseOrder.Columns["S.No."].Width = 50;
                                grdPurchaseOrder.Columns["P.I Code"].Width = 100; 
                                grdPurchaseOrder.Columns["Product Name"].Width = 200; 
                                grdPurchaseOrder.Columns["Unit"].Width = 70; 
                                grdPurchaseOrder.Columns["SalesRate"].Width = 100; 
                                grdPurchaseOrder.Columns["MSQ"].Width = 100; 
                                grdPurchaseOrder.Columns["Productid"].Visible = false;
                                grdPurchaseOrder.Columns["SalesRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                    }
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
