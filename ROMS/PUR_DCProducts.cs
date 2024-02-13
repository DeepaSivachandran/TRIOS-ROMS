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
    public partial class PUR_DCProducts : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus,pbSupplierCode="0",pbScheduleCode="0",pbDCid="0";
        public PUR_DCProducts()
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

            //try
            //{
            //    for (int i = 0; i < grdDC.Rows.Count; i++)
            //    {

            //        DataGridView dataGridView = (DataGridView)sender;
            //        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmStatus"];

            //        if (Convert.ToString(grdDC.Rows[i].Cells["STSID"].Value) == "10")
            //        {
            //            cell.Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
            //            cell.Style.ForeColor = Color.White;// Set the background color to the default background color
            //        }
            //        else
            //        {
            //            cell.Style.BackColor = Color.RoyalBlue;
            //            cell.Style.ForeColor = Color.White;// Set the background color to the default background color 
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
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
                GrdPurchaseOrder_DataBindingComplete(grdDC, args);
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
                DataSet objDs = new DataSet();
                SPDataService objspdservice = new SPDataService();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 10;
                objTRN_PurchaseEntry.paraSupplierID = Convert.ToInt32(pbSupplierCode);
                objTRN_PurchaseEntry.paraScheduleID = Convert.ToInt32(pbScheduleCode);
                objTRN_PurchaseEntry.ParaIds = Convert.ToString(pbDCid);
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                if (objDs.Tables[0].Rows.Count > 0)
                { 
                    grdDC.Rows.Clear();
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        lblNoRecordsFound.Visible = false;
                        grdDC.Rows.Add(grdDC.Rows.Count + 1, objDs.Tables[0].Rows[i]["PR_PICode"].ToString(),
                        objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(),
                        objDs.Tables[0].Rows[i]["DC Quantity"].ToString(), objDs.Tables[0].Rows[i]["DCID"].ToString(), objDs.Tables[0].Rows[i]["ProStatus"].ToString()); 
                    }
                    txtDCNo.Text = objDs.Tables[0].Rows[0]["DC No."].ToString();
                    txtDCDate.Text = objDs.Tables[0].Rows[0]["DC_Date"].ToString();
                    txtUserData.Text = objDs.Tables[0].Rows[0]["Maker Details"].ToString();
                    txtDCSts.Text = objDs.Tables[0].Rows[0]["Status"].ToString();
                    grdDC.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    grdDC.Rows.Clear();
                }
                 
                grdDC.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }  
    }
}
