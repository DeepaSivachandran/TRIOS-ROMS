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
    public partial class PUR_PODamagedView : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public PUR_PODamagedView()
        {
            InitializeComponent();
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
        private void udfnList()
        { 
            try
            {
                Application.DoEvents();
                //********** To display a data in a grid  ****************** 

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnReturnDC(0, Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text), Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblschedule.Text), Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue),0,0,0,0,0);
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
                                grdGRNPODamaged.Rows.Add(objDs.Tables[0].Rows[i]["SINO"], objDs.Tables[0].Rows[i]["DCDATE"], objDs.Tables[0].Rows[i]["DCNO"], objDs.Tables[0].Rows[i]["REASON"], objDs.Tables[0].Rows[i]["prcount"], objDs.Tables[0].Rows[i]["DCVALUE"], objDs.Tables[0].Rows[i]["ID"]);
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

        private void PUR_PODamagedView_Load(object sender, EventArgs e)
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

        private void GrdGRNPODamaged_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PurchaseOrderDamage = new PUR_PurchaseOrderDamage();
                MainForm.objPUR_PurchaseOrderDamage.varDcCode = Convert.ToInt32(grdGRNPODamaged.SelectedRows[0].Cells["ID"].Value.ToString());
                MainForm.objPUR_PurchaseOrderDamage.ShowDialog();  
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void PUR_PODamagedView_KeyDown(object sender, KeyEventArgs e)
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
