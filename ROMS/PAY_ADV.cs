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
    public partial class PAY_ADV : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtAdvance = new DataTable();

        public PAY_ADV()
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
        public void udfnList()
        {
            try
            {
                Application.DoEvents();
                //********** To display a data in a grid  ****************** 
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                int varSupplierid = 0, varScheduleid = 0, varcompanyid = 0;
                bool varCheck = false;
                varSupplierid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.lblSupplierCode.Text);
                varScheduleid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.lblschedule.Text);
                varcompanyid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.cmbConcern.SelectedValue);

                dtAdvance = new DataTable();
                dtAdvance.Columns.Add("", typeof(Boolean));
                dtAdvance.Columns.Add("S.No.", typeof(string));
                dtAdvance.Columns.Add("Advance Date", typeof(string));
                dtAdvance.Columns.Add("Advance Amount", typeof(float));
                dtAdvance.Columns.Add("ADID", typeof(string));
                dtAdvance.Columns.Add("PAYID", typeof(int));
                TRN_Advance objTRN_Advance = new TRN_Advance();
                objTRN_Advance.ViewType = 2;
                objTRN_Advance.paraPAYID = MainForm.objPAY_SupplierPayment.varSupplierPaymentID;
                objTRN_Advance.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRN_Advance.paraIPAddress = MainForm.pbIpAddress;
                objTRN_Advance.paraSupplierId = Convert.ToInt32(varSupplierid);
                objTRN_Advance.paraScheduleId = Convert.ToInt32(varScheduleid);
                objTRN_Advance.ParaCompanycode = Convert.ToInt32(varcompanyid);
                objDs = objdserv.udfnAdvanceList(objTRN_Advance);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdAdvance.DataSource = null;
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                if (Convert.ToInt32(objDs.Tables[0].Rows[i]["PAYID"]) != 0)
                                {
                                    varCheck = true;
                                }
                                else
                                {
                                    varCheck = false;
                                }
                                dtAdvance.Rows.Add(varCheck, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["Advance Date"], objDs.Tables[0].Rows[i]["Advance Amount"], objDs.Tables[0].Rows[i]["ADID"], objDs.Tables[0].Rows[i]["PAYID"]);                               
                            }
                            grdAdvance.DataSource = dtAdvance;
                            grdAdvance.Columns[0].HeaderText = "";
                            grdAdvance.Columns[0].Width = 30;
                            grdAdvance.Columns["S.No."].Width = 50;
                            grdAdvance.Columns["Advance Date"].Width = 120;
                            grdAdvance.Columns["Advance Amount"].Width = 120;
                            grdAdvance.Columns["S.No."].ReadOnly = true;
                            grdAdvance.Columns["Advance Date"].ReadOnly = true;
                            grdAdvance.Columns["Advance Amount"].ReadOnly = true;
                            grdAdvance.Columns["ADID"].ReadOnly = true;
                            grdAdvance.Columns["PAYID"].ReadOnly = true;
                            grdAdvance.Columns["ADID"].Visible = false;
                            grdAdvance.Columns["PAYID"].Visible = false;
                            grdAdvance.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdAdvance.Columns["Advance Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdAdvance.Columns["Advance Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                udfnAdvanceAdd();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            } 
        }
        public void udfnAdvanceAdd()
        {
            try
            {
                int VARFLAG = 0;
                string AdvID = "0";
                decimal varGrandTotal = 0;
                decimal varAdvanceAmnt = 0;
                MainForm.objPAY_SupplierPayment.varAdvanceID = "0";
                MainForm.objPAY_SupplierPayment.lblAdvance.Text = "0";
                for (int i = 0; i < grdAdvance.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdAdvance.Rows[i].Cells[0].Value) == true)
                    {
                        VARFLAG = 1;
                        if (AdvID == "0")
                        {
                            AdvID = Convert.ToString(grdAdvance.Rows[i].Cells["ADID"].Value);
                            varAdvanceAmnt = Convert.ToDecimal(grdAdvance.Rows[i].Cells["Advance Amount"].Value);
                        }
                        else
                        {
                            AdvID = AdvID + ',' + Convert.ToString(grdAdvance.Rows[i].Cells["ADID"].Value);
                            varAdvanceAmnt = varAdvanceAmnt + Convert.ToDecimal(grdAdvance.Rows[i].Cells["Advance Amount"].Value);
                        }
                    }
                }
                if (VARFLAG != 0)
                {
                    MainForm.objPAY_SupplierPayment.varAdvanceID = AdvID;
                    MainForm.objPAY_SupplierPayment.lblAdvance.Text = Convert.ToString(varAdvanceAmnt);
                    varGrandTotal = Convert.ToDecimal(MainForm.objPAY_SupplierPayment.lblSubtotal.Text) - Convert.ToDecimal(MainForm.objPAY_SupplierPayment.lblAdvance.Text);
                    MainForm.objPAY_SupplierPayment.lblGrandTotal.Text = Convert.ToString(varGrandTotal);
                    this.Close();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    if (grdAdvance.Rows.Count > 0)
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

                foreach (DataGridViewRow row in grdAdvance.Rows)
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

        private void Btnunselectall_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in grdAdvance.Rows)
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

        private void PAY_ADV_Load(object sender, EventArgs e)
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
    }
}
