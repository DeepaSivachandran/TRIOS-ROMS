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
    public partial class INV_GRNPODamaged : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        DataTable dtPendingPO = new DataTable();
        public string varbrandcode, varMasterType="0";
        public string pbFormStatus;
        public INV_GRNPODamaged()
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
        private void INV_GRNPODamaged_Load(object sender, EventArgs e)
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

        private void udfnList()
        {
            try
            {
                Application.DoEvents();
                //********** To display a data in a grid  ****************** 

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                int varSupplierid = 0, varScheduleid = 0, varcompanyid = 0;
                    string varDcid="0";

                if (varMasterType == "1")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_GRNDetails.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_GRNDetails.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_GRNDetails.cmbConcern.SelectedValue);
                    varDcid = Convert.ToString(MainForm.objPUR_GRNDetails.dcid);
                }
                else if (varMasterType == "2")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_GRNEntry.cmbConcern.SelectedValue);
                    varDcid = Convert.ToString(MainForm.objPUR_GRNEntry.dcid); 
                }
                 
                dtPendingPO = new DataTable();
                dtPendingPO.Columns.Add("", typeof(Boolean));
                dtPendingPO.Columns.Add("S.No.", typeof(string));
                dtPendingPO.Columns.Add("DC Date", typeof(string));
                dtPendingPO.Columns.Add("DC No.", typeof(string));
                dtPendingPO.Columns.Add("Reason", typeof(string));
                dtPendingPO.Columns.Add("Total Products", typeof(string));
                dtPendingPO.Columns.Add("Total value", typeof(string));
                dtPendingPO.Columns.Add("ID", typeof(string)); 
              //  objDs = objdserv.udfnReturnDC(0, varSupplierid, varScheduleid, varcompanyid, varDcid, 0, 0, 0, 0);
                TRN_ReturnDC objTRN_PurchaseReturnDC = new TRN_ReturnDC();
                objTRN_PurchaseReturnDC.paraViewType = 0;
                objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                objTRN_PurchaseReturnDC.ParaSupplierId = Convert.ToInt32(varSupplierid);
                objTRN_PurchaseReturnDC.ParaScheduleID = Convert.ToInt32(varScheduleid);
                objTRN_PurchaseReturnDC.paraCompanyId = Convert.ToInt32(varcompanyid);
                objTRN_PurchaseReturnDC.paraDCIDs = Convert.ToString(varDcid);
                objDs = objdserv.udfnReturnDC(objTRN_PurchaseReturnDC);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdGRNPODamaged.DataSource = null;
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                dtPendingPO.Rows.Add(false,dtPendingPO.Rows.Count + 1, objDs.Tables[0].Rows[i]["DCDATE"], objDs.Tables[0].Rows[i]["DCNO"], objDs.Tables[0].Rows[i]["REASON"], objDs.Tables[0].Rows[i]["prcount"], objDs.Tables[0].Rows[i]["DCVALUE"], objDs.Tables[0].Rows[i]["ID"]);
                            }
                            grdGRNPODamaged.DataSource=dtPendingPO;
                            grdGRNPODamaged.Columns[0].HeaderText = ""; 
                            grdGRNPODamaged.Columns[0].Width = 30; 
                            grdGRNPODamaged.Columns["S.No."].Width = 70; 
                            grdGRNPODamaged.Columns["Reason"].Width = 200;
                            grdGRNPODamaged.Columns["S.No."].ReadOnly = true;
                            grdGRNPODamaged.Columns["DC Date"].ReadOnly = true;
                            grdGRNPODamaged.Columns["DC No."].ReadOnly = true;
                            grdGRNPODamaged.Columns["Reason"].ReadOnly = true;
                            grdGRNPODamaged.Columns["Total Products"].ReadOnly = true;
                            grdGRNPODamaged.Columns["Total value"].ReadOnly = true;
                            grdGRNPODamaged.Columns["ID"].Visible = false; 
                            grdGRNPODamaged.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGRNPODamaged.Columns["Total value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

        private void GrdGRNPODamaged_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex != -1)
            //    {
            //        switch (grdGRNPODamaged.Columns[e.ColumnIndex].Name)
            //        {
            //            case "DC No.":
            //                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            //                {
            //                    string cellPOValue = Convert.ToString(grdGRNPODamaged.Rows[e.RowIndex].Cells["ID"].Value);

            //                    MainForm.objPUR_PurchaseOrderDamage = new PUR_PurchaseOrderDamage();
            //                    MainForm.objPUR_PurchaseOrderDamage.varMasterType = "3";
            //                    MainForm.objPUR_PurchaseOrderDamage.varDcCode = Convert.ToInt32(cellPOValue);
            //                    MainForm.objPUR_PurchaseOrderDamage.ShowDialog();
            //                }
            //                break;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);

            //}
        }

        private void BtnOk_Click(object sender, EventArgs e)
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
                if (varMasterType == "1")
                {
                    MainForm.objPUR_GRNDetails.grdReurnDC.Rows.Clear();
                    for (int i = 0; i < grdGRNPODamaged.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdGRNPODamaged.Rows[i].Cells[0].Value) == true)
                        {
                            MainForm.objPUR_GRNDetails.grdReurnDC.Rows.Add(grdGRNPODamaged.Rows[i].Cells["DC Date"].Value, grdGRNPODamaged.Rows[i].Cells["DC No."].Value, grdGRNPODamaged.Rows[i].Cells["Total Products"].Value, grdGRNPODamaged.Rows[i].Cells["Total value"].Value, grdGRNPODamaged.Rows[i].Cells["id"].Value);
                            VARFLAG = 1;
                        }
                    }
                    if (VARFLAG != 0)
                    {
                        MainForm.objPUR_GRNDetails.grdReurnDC.Sort(MainForm.objPUR_GRNDetails.grdReurnDC.Columns["DCDate"], ListSortDirection.Descending);
                        this.Close();
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        if (grdGRNPODamaged.Rows.Count > 0)
                        {
                            string varMessage = objDServ.udfnGetMessages(84);
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
                if (varMasterType == "2")
                {
                    //MainForm.objPUR_GRNEntry.grdReurnDC.Rows.Clear();
                    for (int i = 0; i < grdGRNPODamaged.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdGRNPODamaged.Rows[i].Cells[0].Value) == true)
                        {
                            MainForm.objPUR_GRNEntry.grdReurnDC.Rows.Add(grdGRNPODamaged.Rows[i].Cells["DC Date"].Value, grdGRNPODamaged.Rows[i].Cells["DC No."].Value, grdGRNPODamaged.Rows[i].Cells["Total Products"].Value, grdGRNPODamaged.Rows[i].Cells["Total value"].Value, grdGRNPODamaged.Rows[i].Cells["id"].Value);
                            VARFLAG = 1;
                        }
                    }
                    if (VARFLAG != 0)
                    {
                        MainForm.objPUR_GRNEntry.grdReurnDC.Sort(MainForm.objPUR_GRNEntry.grdReurnDC.Columns["DCDate"], ListSortDirection.Descending);
                        this.Close();
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        if (grdGRNPODamaged.Rows.Count > 0)
                        {
                            string varMessage = objDServ.udfnGetMessages(84);
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

        private void INV_GRNPODamaged_KeyDown(object sender, KeyEventArgs e)
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

        private void Btnselectall_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in grdGRNPODamaged.Rows)
                {
                    row.Cells[0].Value = true;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGRNPODamaged_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdGRNPODamaged.Columns[e.ColumnIndex].Name)
                    {
                        case "DC No.":
                            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                            {
                                string cellPOValue = Convert.ToString(grdGRNPODamaged.Rows[e.RowIndex].Cells["ID"].Value);
                                MainForm.objPUR_PurchaseOrderDamage = new PUR_PurchaseOrderDamage();
                                MainForm.objPUR_PurchaseOrderDamage.varMasterType = "2";
                                MainForm.objPUR_PurchaseOrderDamage.varDcCode = Convert.ToString(cellPOValue);
                                MainForm.objPUR_PurchaseOrderDamage.ShowDialog();
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

        private void Btnunselectall_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in grdGRNPODamaged.Rows)
                {
                    row.Cells[0].Value = false;
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
