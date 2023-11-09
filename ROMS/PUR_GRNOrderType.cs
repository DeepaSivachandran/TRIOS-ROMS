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
    public partial class PUR_GRNOrderType : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public DataTable dtPendingPO;
        public PUR_GRNOrderType()
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

        private void PUR_GRNOrderType_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MainForm.objPUR_GRNEntry.lblSupplierCode.Text) != 0)
                {

                    dtPendingPO = new DataTable();
                    dtPendingPO.Columns.Add("", typeof(Boolean));
                    dtPendingPO.Columns.Add("S.No.", typeof(string));
                    dtPendingPO.Columns.Add("PO.No", typeof(string));
                    dtPendingPO.Columns.Add("PO Date", typeof(string));
                    dtPendingPO.Columns.Add("Total Products", typeof(string));
                    dtPendingPO.Columns.Add("poid", typeof(string));
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnPOEntry(4, Convert.ToInt32(MainForm.objPUR_GRNEntry.lblSupplierCode.Text), Convert.ToInt32(MainForm.objPUR_GRNEntry.lblschedule.Text), 0, 0, 0, 0, 0, 0, "", "", 0, 0, MainForm.objPUR_GRNEntry.pbPONO);
                    objspdservice.CloseConnection();
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        grdPurchaseOrder.Rows.Clear();
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            lblFinishedNoRecord.Visible = false;
                            dtPendingPO.Rows.Add(false, Convert.ToString(objDs.Tables[0].Rows[i]["SINO"].ToString()), Convert.ToString(objDs.Tables[0].Rows[i]["PO_No"]),
                             Convert.ToString(objDs.Tables[0].Rows[i]["PO_Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["QTY"]), Convert.ToString(objDs.Tables[0].Rows[i]["POID"])
                            );
                        }
                        grdPurchaseOrder.DataSource = dtPendingPO;
                        grdPurchaseOrder.Columns[0].HeaderText = "";
                        grdPurchaseOrder.Columns[0].Width = 30;
                        grdPurchaseOrder.ReadOnly= false;
                        grdPurchaseOrder.Columns["S.No."].Width = 50;
                        grdPurchaseOrder.Columns["PO.No"].Width = 100;
                        grdPurchaseOrder.Columns["PO Date"].Width = 100;
                        grdPurchaseOrder.Columns["Total Products"].Width = 100;
                        grdPurchaseOrder.Columns["poid"].Visible = false;
                        grdPurchaseOrder.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdPurchaseOrder.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else
                    {
                        lblFinishedNoRecord.Visible = true;
                        grdPurchaseOrder.DataSource = null;
                    }
                }
                else
                {
                    lblFinishedNoRecord.Visible = true;
                    grdPurchaseOrder.DataSource = null;
                }
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            { 
                udfnAddPrevPending();
                 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAddPrevPending()
        {
            try
            {
               int VARFLAG = 0;
                for (int i = 0; i < grdPurchaseOrder.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdPurchaseOrder.Rows[i].Cells[0].Value) == true)
                    {
                        MainForm.objPUR_GRNEntry.grdPODetails.Rows.Add(grdPurchaseOrder.Rows[i].Cells["PO.No"].Value, grdPurchaseOrder.Rows[i].Cells["PO Date"].Value, grdPurchaseOrder.Rows[i].Cells["Total Products"].Value, grdPurchaseOrder.Rows[i].Cells["poid"].Value);
                       VARFLAG = 1;
                    }
                }
                if (VARFLAG != 0)
                {
                    if (MainForm.objPUR_GRNEntry.grdPODetails.Rows.Count > 0)
                    {
                        MainForm.objPUR_GRNEntry.lblFinishedNoRecord.Visible = false;
                    }
                    else
                    {
                        MainForm.objPUR_GRNEntry.lblFinishedNoRecord.Visible = false;
                    }
                    MainForm.objPUR_GRNEntry.grdPODetails.Sort(MainForm.objPUR_GRNEntry.grdPODetails.Columns["clmPODate"], ListSortDirection.Descending);
                    this.Close();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    if (grdPurchaseOrder.Rows.Count > 0)
                    { 
                        string varMessage = objDServ.udfnGetMessages(81);
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
    }
}
