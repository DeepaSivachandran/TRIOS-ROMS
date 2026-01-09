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
        public int varMasterType = 0, varTotProCount = 0;
        public string varPOID = "";
        
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
                dtPendingPO = new DataTable();
                dtPendingPO.Columns.Add("", typeof(Boolean));
                dtPendingPO.Columns.Add("S.No.", typeof(string));
                dtPendingPO.Columns.Add("PO.No", typeof(string));
                dtPendingPO.Columns.Add("PO Date", typeof(string));
                dtPendingPO.Columns.Add("Total Products", typeof(string));
                dtPendingPO.Columns.Add("poid", typeof(string));
                int supplierid = 0, scheduleid = 0;
                    string pono = "0";
                if (varMasterType == 1)
                {
                    supplierid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblSupplierCode.Text);
                    scheduleid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblschedule.Text);
                    pono = MainForm.objPUR_GRNEntry.pbPONO;
                    varPOID = MainForm.objPUR_GRNEntry.pbPONO;
                }
                if (varMasterType == 2)
                {
                    supplierid = Convert.ToInt32(MainForm.objCP_Purchase.lblSupplierCode.Text);
                    scheduleid = Convert.ToInt32(MainForm.objCP_Purchase.lblschedule.Text);
                    pono = MainForm.objCP_Purchase.pbPONO;
                    varPOID = MainForm.objCP_Purchase.pbPONO;
                }
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objspdservice.udfnPOEntry(4, supplierid, scheduleid, 0, 0, 0, 0, 0, 0, "", "", 0, 0, pono, 0,0, 0, 0, 0, 0,0,0);
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
                    grdPurchaseOrder.Columns[0].ReadOnly = false;
                    grdPurchaseOrder.Columns["S.No."].ReadOnly = true;
                    grdPurchaseOrder.Columns["PO.No"].ReadOnly = true;
                    grdPurchaseOrder.Columns["PO Date"].ReadOnly = true;
                    grdPurchaseOrder.Columns["Total Products"].ReadOnly = true;
                    grdPurchaseOrder.Columns["S.No."].Width = 50;
                    grdPurchaseOrder.Columns["PO.No"].Width = 100;
                    grdPurchaseOrder.Columns["PO Date"].Width = 100;
                    grdPurchaseOrder.Columns["Total Products"].Width = 100;
                    grdPurchaseOrder.Columns["poid"].Visible = false;
                    grdPurchaseOrder.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdPurchaseOrder.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                   // udfnPOCheckTrue();
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
        public void udfnPOCheckTrue()
        {
            try
            {
                string[] varPO = varPOID.Split(',');
                for (int i = 0; i < varPO.Length; i++)
                {
                    for (int j = 0; j < grdPurchaseOrder.Rows.Count; j++)
                    {
                        if (Convert.ToInt16(grdPurchaseOrder.Rows[j].Cells["POID"].Value) == Convert.ToInt16(varPO[i]))
                        {
                            grdPurchaseOrder.Rows[j].Cells[0].Value = true;
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
                if (varMasterType == 1) //---Grn screen Po add---\\
                {
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
                if (varMasterType == 2) //---purchase screen Po add---\\
                {
                    string pono = "0";
                    MainForm.objCP_Purchase.pbPONO = "0"; varTotProCount = 0;
                    for (int i = 0; i < grdPurchaseOrder.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdPurchaseOrder.Rows[i].Cells[0].Value) == true)
                        {
                            MainForm.objCP_Purchase.grdPODetails.Rows.Add(grdPurchaseOrder.Rows[i].Cells["PO.No"].Value, grdPurchaseOrder.Rows[i].Cells["PO Date"].Value, grdPurchaseOrder.Rows[i].Cells["Total Products"].Value, grdPurchaseOrder.Rows[i].Cells["poid"].Value);
                            VARFLAG = 1;
                            if (pono == "0")
                            {
                                pono = Convert.ToString(grdPurchaseOrder.Rows[i].Cells["poid"].Value);
                            }
                            else
                            {
                                pono = pono + ',' + Convert.ToString(grdPurchaseOrder.Rows[i].Cells["poid"].Value);
                            }
                            varTotProCount = varTotProCount + Convert.ToInt16(grdPurchaseOrder.Rows[i].Cells["Total Products"].Value);
                        }
                    }
                    if (VARFLAG != 0)
                    {
                        if (MainForm.objCP_Purchase.grdPODetails.Rows.Count > 0)
                        {
                            MainForm.objCP_Purchase.lblFinishedNoRecord.Visible = false;
                            MainForm.objCP_Purchase.lblPOnorecord.Visible = false;
                        }
                        else
                        {
                            MainForm.objCP_Purchase.lblFinishedNoRecord.Visible = false;
                        }
                        MainForm.objCP_Purchase.grdPODetails.Sort(MainForm.objCP_Purchase.grdPODetails.Columns["clmPODate"], ListSortDirection.Descending); 
                        MainForm.objCP_Purchase.pbPONO = pono;
                        MainForm.objCP_Purchase.lbltotProduct.Text = Convert.ToString(varTotProCount);
                        MainForm.objCP_Purchase.lblRemainProduct.Text = Convert.ToString(varTotProCount);
                        MainForm.objCP_Purchase.varEntryTypeViewFlag = 1;
                        udfnclose();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_GRNOrderType_KeyDown(object sender, KeyEventArgs e)
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

        private void GrdPurchaseOrder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    string supplierid = "0", scheduleid = "0";
                    supplierid = Convert.ToString(MainForm.objPUR_GRNEntry.lblSupplierCode.Text);
                    scheduleid = Convert.ToString(MainForm.objPUR_GRNEntry.lblschedule.Text);
                    switch (grdPurchaseOrder.Columns[e.ColumnIndex].Name)
                    {
                        case "PO.No":
                            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                            {
                                string cellPOValue = Convert.ToString(grdPurchaseOrder.Rows[e.RowIndex].Cells["poid"].Value);
                                MainForm.objPUR_POProducts = new PUR_POProducts();
                                MainForm.objPUR_POProducts.pbPoid = cellPOValue;
                                MainForm.objPUR_POProducts.pbSupplierCode = supplierid;
                                MainForm.objPUR_POProducts.pbScheduleCode = scheduleid;
                                MainForm.objPUR_POProducts.ShowDialog();
                            }
                            break;
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
