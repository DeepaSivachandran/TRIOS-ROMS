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
    public partial class PUR_Purchase_GRNDetails : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbranGRNode="", varGRNQRCode = "",varGRNID="";
        public int QRFlag=0 ;
       DataTable dtPurchaseGRN = new DataTable();
        public string pbFormStatus;
        public PUR_Purchase_GRNDetails()
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                udfnAddGRN();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public  void udfnlist()
        {
            try
            {
                dtPurchaseGRN = new DataTable();
                dtPurchaseGRN.Columns.Add("", typeof(Boolean));
                dtPurchaseGRN.Columns.Add("S.No.", typeof(string));
                dtPurchaseGRN.Columns.Add("GRN No.", typeof(string));
                dtPurchaseGRN.Columns.Add("GRN Date", typeof(string));
                dtPurchaseGRN.Columns.Add("Total Products", typeof(string));
                dtPurchaseGRN.Columns.Add("GRNID", typeof(string));
                dtPurchaseGRN.Columns.Add("QRCode", typeof(string));
                dtPurchaseGRN.Columns.Add("CompleteFlag", typeof(string));
                int supplierid = 0, scheduleid = 0;
                string GRNNo = "0";
                supplierid = Convert.ToInt32(MainForm.objCP_Purchase.lblSupplierCode.Text);
                scheduleid = Convert.ToInt32(MainForm.objCP_Purchase.lblschedule.Text);
                GRNNo = MainForm.objCP_Purchase.pbGRNNo;
                varGRNID = MainForm.objCP_Purchase.pbGRNNo;
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnGrnListLoad(6, supplierid, scheduleid, 0, 0, "", "", 0, 0, 0, "", "", 0, 0, GRNNo, "", "", 0, 0, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                            grdGRNDetails.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                lblNoRecordsFound.Visible = false;
                                dtPurchaseGRN.Rows.Add(false, dtPurchaseGRN.Rows.Count + 1, Convert.ToString(objDs.Tables[0].Rows[i]["GRNNo"]), Convert.ToString(objDs.Tables[0].Rows[i]["GRNDate"]),
                                Convert.ToString(objDs.Tables[0].Rows[i]["T.PRO"]), Convert.ToString(objDs.Tables[0].Rows[i]["ID"]), Convert.ToString(objDs.Tables[0].Rows[i]["QRCode"]), Convert.ToString(objDs.Tables[0].Rows[i]["CompleteFlag"]));
                            }
                            grdGRNDetails.DataSource = dtPurchaseGRN;
                            grdGRNDetails.Columns[0].HeaderText = "";
                            grdGRNDetails.Columns[0].Width = 30;
                            grdGRNDetails.Columns[0].ReadOnly = false;
                            grdGRNDetails.Columns["S.No."].ReadOnly = true;
                            grdGRNDetails.Columns["GRN No."].ReadOnly = true;
                            grdGRNDetails.Columns["GRN Date"].ReadOnly = true;
                            grdGRNDetails.Columns["Total Products"].ReadOnly = true;
                            grdGRNDetails.Columns["S.No."].Width = 50;
                            grdGRNDetails.Columns["GRN No."].Width = 100;
                            grdGRNDetails.Columns["GRN Date"].Width = 100;
                            grdGRNDetails.Columns["Total Products"].Width = 100;
                            grdGRNDetails.Columns["GRNID"].Visible = false;
                            grdGRNDetails.Columns["QRCode"].Visible = false;
                            grdGRNDetails.Columns["CompleteFlag"].Visible = false;
                            grdGRNDetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGRNDetails.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            // udfnGRNCheckTrue();
                            udfnCheckEnable();
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            grdGRNDetails.DataSource = null;
                        }
                }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdGRNDetails.ClearSelection();
            }
        }
        private void PUR_GRNDeatils_Load(object sender, EventArgs e)
        {
            try
            {
                udfnlist();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }
        public void udfnGRNCheckTrue()
        {
            try
            {
                string[] varGRN = varGRNID.Split(',');
                for (int i = 0; i < varGRN.Length; i++)
                {
                    for (int j = 0; j < grdGRNDetails.Rows.Count; j++)
                    {
                        if (Convert.ToInt16(grdGRNDetails.Rows[j].Cells["GRNID"].Value) ==  Convert.ToInt16(varGRN[i]))
                        {
                            grdGRNDetails.Rows[j].Cells[0].Value = true;
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
        public void udfnCheckEnable()
        {
            try
            {
                for (int j = 0; j < grdGRNDetails.Rows.Count; j++)
                {
                    if (Convert.ToString(grdGRNDetails.Rows[j].Cells["CompleteFlag"].Value) == "0")
                    {
                        grdGRNDetails.Rows[j].Cells[0].Value = false;
                        grdGRNDetails.Rows[j].Cells[0].ReadOnly = true;
                        grdGRNDetails.Rows[j].ReadOnly = true;
                        grdGRNDetails.Rows[j].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAddGRN()
        {
            try
            {
                //{
                int VARFLAG = 0;
                string GRNno = "0", varGRNQRCode="" , varProCount="0";
                MainForm.objCP_Purchase.pbGRNNo = "0";
                //if(QRFlag==1)
                //{
                //    udfnGRNCheckTrue();
                //}
                //MainForm.objPUR_GRNEntry.grdReurnGRN.Rows.Clear();
                for (int i = 0; i < grdGRNDetails.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdGRNDetails.Rows[i].Cells[0].Value) == true)
                    {
                        VARFLAG = 1;
                        if (GRNno == "0")
                        {
                            GRNno = Convert.ToString(grdGRNDetails.Rows[i].Cells["GRNID"].Value);
                        }
                        else
                        {
                            GRNno = GRNno + ',' + Convert.ToString(grdGRNDetails.Rows[i].Cells["GRNID"].Value);
                        }
                        varGRNQRCode= Convert.ToString(grdGRNDetails.Rows[i].Cells["QRCode"].Value);
                        varProCount = Convert.ToString(grdGRNDetails.Rows[i].Cells["Total Products"].Value);
                    }
                }
                if (VARFLAG != 0)
                { 
                    MainForm.objCP_Purchase.pbGRNNo = GRNno;
                    MainForm.objCP_Purchase.pbQRCode = varGRNQRCode;
                    MainForm.objCP_Purchase.varGRNProCount = varProCount;
                    MainForm.objCP_Purchase.lbltotProduct.Text = varProCount;
                    MainForm.objCP_Purchase.lblRemainProduct.Text = varProCount;
                    MainForm.objCP_Purchase.varEntryTypeViewFlag= 1;
                    this.Close();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    if (grdGRNDetails.Rows.Count > 0)
                    {
                        string varMessage = objDServ.udfnGetMessages(105);
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
        private void BtnSave_Enter(object sender, EventArgs e)
        {
            try { btnSave.BackColor = Color.LemonChiffon; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSave_Leave(object sender, EventArgs e)
        {
            try { btnSave.BackColor = Color.Transparent; }
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

        private void GrdGRNDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {   //for check box as radio button function
                if (grdGRNDetails.CurrentCell.ColumnIndex == 0)
                {
                    for (int i = 0; i < grdGRNDetails.Rows.Count; i++)
                    {
                        //if (i != dataGridView1.CurrentCell.RowIndex)
                        grdGRNDetails.Rows[i].Cells[0].Value = false;

                    }
                    grdGRNDetails.Rows[grdGRNDetails.CurrentCell.RowIndex].Cells[0].Value = true;
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
