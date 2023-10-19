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
    public partial class PUR_PODamaged : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public PUR_PODamaged()
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
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdPurchaseOrder.DataSource = null;

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnproductDamage(0, Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text), Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblschedule.Text), Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue));
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
                                grdPurchaseOrder.Rows.Add(objDs.Tables[0].Rows[i]["SINO"], objDs.Tables[0].Rows[i]["PICODE"], objDs.Tables[0].Rows[i]["PRODUCTNAME"], objDs.Tables[0].Rows[i]["QTY"], objDs.Tables[0].Rows[i]["UNIT"], objDs.Tables[0].Rows[i]["MRP"], objDs.Tables[0].Rows[i]["LASTPURCHASE"], objDs.Tables[0].Rows[i]["EXPIRY"], objDs.Tables[0].Rows[i]["BATCH"]);
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
