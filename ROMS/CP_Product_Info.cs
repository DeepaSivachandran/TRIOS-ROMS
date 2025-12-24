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
    public partial class CP_Product_Info : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int varProductId = 0;
        public CP_Product_Info()
        {
            InitializeComponent();
        }
        private void CP_Product_Info_Leave(object sender, EventArgs e)
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

        private void CP_Product_Info_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Product_Info_Load(object sender, EventArgs e)
        {
            try
            {
                lblPICode.Text = "";
                lblPREName.Text = "";
                lblPRTName.Text = "";
                lblProductCategory.Text = "";
                lblProductType.Text = "";
                lblUnit.Text = "";
                lblUPP.Text = "";
                lblGroup.Text = "";
                lblSubgroup.Text = "";
                lblBrand.Text = "";
                lblPurLocation.Text = "";
                lblPurRack.Text = "";
                lblSalesLocation.Text = "";
                lblSalesRack.Text = "";
                if (varProductId != 0)
                {
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 89;
                    objMR_Product.ParaProductCode = varProductId;
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objdserv.udfnproductmasterlist(objMR_Product);
                    objdserv.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            lblPICode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["PR_PICode"].ToString());
                            lblPREName.Text = Convert.ToString(objDS.Tables[0].Rows[0]["PR_EName"].ToString());
                            lblPRTName.Text = Convert.ToString(objDS.Tables[0].Rows[0]["PR_TName"].ToString());
                            lblProductCategory.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Category"].ToString());
                            lblProductType.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Product Type"].ToString());
                            lblUnit.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Unit"].ToString());
                            lblUPP.Text = Convert.ToString(objDS.Tables[0].Rows[0]["UPP"].ToString());
                            lblGroup.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Group"].ToString());
                            lblSubgroup.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Subgroup"].ToString());
                            lblBrand.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Brand"].ToString());
                            lblPurLocation.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Pur_Location"].ToString());
                            lblPurRack.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Pur_Rack"].ToString());
                            lblSalesLocation.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Sales_Location"].ToString());
                            lblSalesRack.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Sales_Rack"].ToString());
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

        private void btnClose_Click(object sender, EventArgs e)
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
        private void btnClose_Enter(object sender, EventArgs e)
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
        private void btnClose_Leave(object sender, EventArgs e)
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
    }
}
