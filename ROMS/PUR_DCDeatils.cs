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
    public partial class PUR_DCDeatils : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        DataTable dtReturnDC = new DataTable();
        public string pbFormStatus;
        public string varDCID="";
        public PUR_DCDeatils()
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
                udfnAddDC();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDCCheckTrue()
        {
            try
            {
                string[] varDC = varDCID.Split(',');
                for (int i = 0; i < varDC.Length; i++)
                {
                    for (int j = 0; j < grdDCDetails.Rows.Count; j++)
                    {
                        if (Convert.ToInt16(grdDCDetails.Rows[j].Cells["DCID"].Value) == Convert.ToInt16(varDC[i]))
                        {
                            grdDCDetails.Rows[j].Cells[0].Value = true;
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
        private void PUR_DCDeatils_Load(object sender, EventArgs e)
        {
            try
            {
                dtReturnDC = new DataTable();
                dtReturnDC.Columns.Add("", typeof(Boolean));
                dtReturnDC.Columns.Add("S.No.", typeof(string));
                dtReturnDC.Columns.Add("DC No.", typeof(string));
                dtReturnDC.Columns.Add("DC Date", typeof(string));
                dtReturnDC.Columns.Add("Total Products", typeof(string));
                dtReturnDC.Columns.Add("DCID", typeof(string));
                int supplierid = 0, scheduleid = 0;
                string DCNo= "0"; 
                supplierid = Convert.ToInt32(MainForm.objCP_Purchase.lblSupplierCode.Text);
                scheduleid = Convert.ToInt32(MainForm.objCP_Purchase.lblschedule.Text);
                DCNo = MainForm.objCP_Purchase.pbDCNo;
                varDCID = MainForm.objCP_Purchase.pbDCNo;
                if (supplierid != 0 && scheduleid != 0)
                {
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_Purchase_DC objTRNG_Purchase_DC = new TRN_Purchase_DC();
                    objTRNG_Purchase_DC.ViewType = 2;
                    objTRNG_Purchase_DC.paraDCIDS = DCNo;
                    objTRNG_Purchase_DC.paraSupplierID = supplierid;
                    objTRNG_Purchase_DC.paraScheduleID = scheduleid;
                    objDs = objdserv.udfnPurchaseDCList(objTRNG_Purchase_DC);
                    objdserv.CloseConnection();
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        grdDCDetails.Rows.Clear();
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            lblNoRecordsFound.Visible = false;
                            dtReturnDC.Rows.Add(false, dtReturnDC.Rows.Count + 1, Convert.ToString(objDs.Tables[0].Rows[i]["DCNo"]),
                                Convert.ToString(objDs.Tables[0].Rows[i]["DCDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["T.PRO"]), Convert.ToString(objDs.Tables[0].Rows[i]["ID"])
                            );
                        }
                        grdDCDetails.DataSource = dtReturnDC;
                        grdDCDetails.Columns[0].HeaderText = "";
                        grdDCDetails.Columns[0].Width = 30;
                        grdDCDetails.Columns[0].ReadOnly = false;
                        grdDCDetails.Columns["S.No."].ReadOnly = true;
                        grdDCDetails.Columns["DC No."].ReadOnly = true;
                        grdDCDetails.Columns["DC Date"].ReadOnly = true;
                        grdDCDetails.Columns["Total Products"].ReadOnly = true;
                        grdDCDetails.Columns["S.No."].Width = 50;
                        grdDCDetails.Columns["DC No."].Width = 100;
                        grdDCDetails.Columns["DC Date"].Width = 100;
                        grdDCDetails.Columns["Total Products"].Width = 100;
                        grdDCDetails.Columns["DCID"].Visible = false;
                        grdDCDetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdDCDetails.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        udfnDCCheckTrue();
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        grdDCDetails.DataSource = null;
                    }
                } 
                else
                {
                    lblNoRecordsFound.Visible = true;
                    grdDCDetails.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }


        public void udfnAddDC()
        {
            try
            {
                int VARFLAG = 0;
                string dcno = "0";
                MainForm.objCP_Purchase.pbDCNo = "0";
                //MainForm.objPUR_GRNEntry.grdReurnDC.Rows.Clear();
                for (int i = 0; i < grdDCDetails.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdDCDetails.Rows[i].Cells[0].Value) == true)
                    {
                        MainForm.objCP_Purchase.grdReurnDC.Rows.Add(grdDCDetails.Rows[i].Cells["DC Date"].Value, grdDCDetails.Rows[i].Cells["DC No."].Value, grdDCDetails.Rows[i].Cells["Total Products"].Value, grdDCDetails.Rows[i].Cells["DCID"].Value);
                        VARFLAG = 1;
                        if (dcno == "0")
                        {
                            dcno = Convert.ToString(grdDCDetails.Rows[i].Cells["DCID"].Value);
                        }
                        else
                        {
                            dcno = dcno + ',' + Convert.ToString(grdDCDetails.Rows[i].Cells["DCID"].Value);
                        }
                    }
                }
                if (VARFLAG != 0)
                {
                    MainForm.objCP_Purchase.grdReurnDC.Sort(MainForm.objCP_Purchase.grdReurnDC.Columns["DCDate"], ListSortDirection.Descending);
                    MainForm.objCP_Purchase.pbDCNo = dcno;
                    this.Close();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    if (grdDCDetails.Rows.Count > 0)
                    {
                        string varMessage = objDServ.udfnGetMessages(106);
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
         
    }
}
