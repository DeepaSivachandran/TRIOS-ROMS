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
    public partial class PO_Details : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        public string PbvarGRNID="";
        public string varProducts = "";
        public PO_Details()
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
        private void PUR_DCDeatils_Load(object sender, EventArgs e)
        {
            try
            {
                udfnLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }
        public void udfnLoad()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 59;
                objMR_Product.paraId = 1;
                objMR_Product.ParaGRNID =Convert.ToInt32(PbvarGRNID);
                objMR_Product.ParaProductsCode = varProducts;
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                objspdservice.CloseConnection();

                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdPODetails.BringToFront();
                            grdPODetails.DataSource = objDs.Tables[0];
                            grdPODetails.Columns["PRID"].Visible = false;
                            grdPODetails.Columns["Product Name"].Width = 320;
                            grdPODetails.Columns["PI Code"].Width = 120;
                            grdPODetails.Columns["Unit"].Width = 60;
                            grdPODetails.Columns["S.No."].Width = 60;
                            grdPODetails.Columns["S.No."].DisplayIndex = 1;
                            grdPODetails.Columns["PI Code"].DisplayIndex = 2;
                            grdPODetails.Columns["Unit"].DisplayIndex = 4;
                            grdPODetails.Columns["Product Name"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdPODetails.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPODetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPODetails.ClearSelection();
                            grdPODetails.ReadOnly = true;
                        }
                        else
                        {
                            grdPODetails.Visible = false;
                            grdPODetails.DataSource = null;
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        grdPODetails.Visible = false;
                        grdPODetails.DataSource = null;
                    }
                }
                else
                {
                    grdPODetails.Visible = false;
                    grdPODetails.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnClose_Enter(object sender, EventArgs e)
        {
            try { btnClose.BackColor = Color.LemonChiffon; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnClose_Leave(object sender, EventArgs e)
        {
            try { btnClose.BackColor = Color.Transparent; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PO_Details_KeyDown(object sender, KeyEventArgs e)
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
    }
}
