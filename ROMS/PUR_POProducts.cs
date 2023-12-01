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
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objspdservice.udfnSupplierList(16, Convert.ToInt32(pbSupplierCode), Convert.ToInt32(pbScheduleCode), 0, 0, "", 0, 0, 0,"",0,0,0,0,0, Convert.ToInt32(pbPoid),"");
                objspdservice.CloseConnection();
                if (objDs.Tables[6].Rows.Count > 0)
                { 
                    grdPurchaseOrder.Rows.Clear();
                    for (int i = 0; i < objDs.Tables[6].Rows.Count; i++)
                    {
                        lblNoRecordsFound.Visible = false;
                        grdPurchaseOrder.Rows.Add(grdPurchaseOrder.Rows.Count + 1, objDs.Tables[6].Rows[i]["PR_PICode"].ToString(),
                        objDs.Tables[6].Rows[i]["PR_TName"].ToString(), objDs.Tables[6].Rows[i]["UT_Symbol"].ToString(),
                        objDs.Tables[6].Rows[i]["POPR_OrderQty"].ToString(), objDs.Tables[6].Rows[i]["RECEIVED"].ToString(),
                        objDs.Tables[6].Rows[i]["POPR_RemainingQty"].ToString()); 
                    }
                    txtPONo.Text = objDs.Tables[6].Rows[0]["PO_No"].ToString();
                    txtPODate.Text = objDs.Tables[6].Rows[0]["PO_Date"].ToString();
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
