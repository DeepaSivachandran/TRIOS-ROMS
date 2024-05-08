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
    public partial class PUR_RemainingProductList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        public string PbvarGRNID="";
        public string varProducts = "",pbPOid="0",pbDCid="0";
        public int varFlag = 0,pbGRNid=0;
        public PUR_RemainingProductList()
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
                if(varFlag==0)//po
                { this.Text = "PO - Remaing Products"; }
                else if (varFlag == 1)//GRN
                { this.Text = "GRN - Remaing Products"; }
                else if (varFlag == 2)//DC
                { this.Text = "DC - Remaing Products"; }
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
                objMR_Product.paraViewType = 60;
                objMR_Product.paraId = 1;
                objMR_Product.paraFlag = varFlag;
                objMR_Product.ParaGRNID = pbGRNid;
                objMR_Product.ParaPOID = pbPOid;
                objMR_Product.ParaDCID = pbDCid;
                objMR_Product.ParaProductsCode = varProducts;
                objMR_Product.paraPurchaseAutoComplete = MainForm.objCP_Purchase.dtPurchaseAutoComplete;
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
                            if (varFlag != 0)
                            {
                                grdPODetails.Columns["ID"].Visible = false;
                            }
                            grdPODetails.Columns["Product Name"].Width = 400;
                            grdPODetails.Columns["PI Code"].Width = 150;
                            grdPODetails.Columns["Unit"].Width = 60;
                            grdPODetails.Columns["S.No."].Width = 50;
                            grdPODetails.Columns["PI Code"].DisplayIndex = 2;
                            grdPODetails.Columns["Unit"].DisplayIndex = 4;
                            grdPODetails.Columns["Product Name"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdPODetails.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdPODetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            if (varFlag != 0)
                            {
                                grdPODetails.Columns["Product Name"].Width = 250;
                                grdPODetails.Columns["PI Code"].Width = 120;
                                grdPODetails.Columns["MRP"].Width = 80;
                                grdPODetails.Columns["MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPODetails.Columns["Expiry Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            if (varFlag == 1)
                            {
                                grdPODetails.Columns["Product Name"].Width = 350;
                                grdPODetails.Columns["Location"].Visible = false;
                                grdPODetails.Columns["Rack"].Visible = false;
                            }
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
