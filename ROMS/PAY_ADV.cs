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
        DataTable dtCheckAdv = new DataTable();
        public string AdvID = ""; public string varEditAdv = "";
        public string varAdvancePayAmnt = "";
        public int VARFLAG = 0;
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
        //public void udfnUncheck()
        //{
        //    try
        //    {
        //        grdAdvance.Columns[0] = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}
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
                dtAdvance.Columns.Add("Current Balance", typeof(decimal));
                dtAdvance.Columns.Add("ADID", typeof(string));
                dtAdvance.Columns.Add("PAYID", typeof(int));
                dtAdvance.Columns.Add("Advance Amount", typeof(decimal));

                //dtCheckAdv = new DataTable();
                //dtCheckAdv.Columns.Add("Advance Amount", typeof(decimal));
                //dtCheckAdv.Columns.Add("ADID", typeof(string));
                //dtCheckAdv.Columns.Add("PURID", typeof(int));
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
                                dtAdvance.Rows.Add(varCheck, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["Advance Date"], Convert.ToDecimal(objDs.Tables[0].Rows[i]["Current Balance"]), objDs.Tables[0].Rows[i]["ADID"], objDs.Tables[0].Rows[i]["PAYID"], Convert.ToDecimal(objDs.Tables[0].Rows[i]["Advance Amount"]));
                                MainForm.objPAY_SupplierPayment.dtCheckAdv.Rows.Add(Convert.ToDecimal(objDs.Tables[0].Rows[i]["Advance Amount"]), objDs.Tables[0].Rows[i]["ADID"], Convert.ToDecimal(objDs.Tables[0].Rows[i]["Current Balance"]));
                                //if(Convert.ToString(AdvID)== Convert.ToString(objDs.Tables[0].Rows[i]["ADID"]))
                                //{
                                //    objDs.Tables[0].Rows[i][0] = true;
                                //}
                            }
                            grdAdvance.DataSource = dtAdvance;
                            grdAdvance.Columns[0].HeaderText = "";
                            grdAdvance.Columns[0].Width = 30;
                            grdAdvance.Columns["S.No."].Width = 50;
                            grdAdvance.Columns["Advance Date"].Width = 120;
                            grdAdvance.Columns["Current Balance"].Width = 120;
                            grdAdvance.Columns["Advance Amount"].Width = 120;
                            grdAdvance.Columns["S.No."].ReadOnly = true;
                            grdAdvance.Columns["Advance Date"].ReadOnly = true;
                            grdAdvance.Columns["Current Balance"].ReadOnly = true;
                            grdAdvance.Columns["ADID"].ReadOnly = true;
                            grdAdvance.Columns["PAYID"].ReadOnly = true;
                            grdAdvance.Columns["ADID"].Visible = false;
                            grdAdvance.Columns["PAYID"].Visible = false;
                            grdAdvance.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdAdvance.Columns["Current Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdAdvance.Columns["Advance Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdAdvance.Columns["Advance Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdAdvance.Columns["Advance Amount"].DisplayIndex = 3;   // Moves Advance Amount column before current balance columnn
                            grdAdvance.Columns["Current Balance"].DefaultCellStyle.BackColor = Color.Green;
                            grdAdvance.Columns["Current Balance"].DefaultCellStyle.ForeColor = Color.White;
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
                udfnEditAdvance();                            
                string[] tokens = MainForm.objPAY_SupplierPayment.varAdvanceID.Split(',');
                for (int i = 0; i < tokens.Count(); i++)
                {
                    for (int j = 0; j < grdAdvance.Rows.Count; j++)
                    {
                        if (Convert.ToString(tokens[i]) == Convert.ToString(grdAdvance.Rows[j].Cells["ADID"].Value))
                        {
                            dtAdvance.Rows[j][0] = true;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if(MainForm.objPAY_SupplierPayment.varPaymentStatus==77)
                {
                    btnOk.Enabled = false;
                    grdAdvance.Enabled = false;
                    grdAdvance.ReadOnly = true;
                }
            }
        }
        public void udfnEditAdvance()
        {
            try
            {
                decimal CurrentBalance = 0, AdvanceAmount = 0;
                for (int i = 0; i < grdAdvance.Rows.Count; i++)
                {
                   
                    if (MainForm.objPAY_SupplierPayment.clearClick == 1 && MainForm.objPAY_SupplierPayment.varCreatemodeFlag == 1)
                    {
                        //grdAdvance.Rows[i].Cells["Current Balance"].Value = grdAdvance.Rows[i].Cells["Advance Amount"].Value;
                        dtAdvance.Rows[i]["Current Balance"] = dtAdvance.Rows[i]["Advance Amount"];
                        grdAdvance.Rows[i].Cells[0].Value = false;
                    }
                    if (MainForm.objPAY_SupplierPayment.clearClick == 2)
                    {
                        //dtAdvance.Rows[i]["Current Balance"] = MainForm.objPAY_SupplierPayment.dtAdvance.Rows[i]["Current Balance"];
                        //decimal varCurrentBalance = Convert.ToDecimal(dtAdvance.Rows[i]["Current Balance"]);
                        //decimal varAdvance = Convert.ToDecimal(dtAdvance.Rows[i]["Advance Amount"]);
                        //if (varCurrentBalance == varAdvance)
                        //{
                        //    dtAdvance.Rows[i][0] = false;
                        //}
                    }
                }
                //if (MainForm.objPAY_SupplierPayment.clearClick == 2 && MainForm.objPAY_SupplierPayment.varCreatemodeFlag == 1)
                //{
                //    var sumOfAdvance = (from r in MainForm.objPAY_SupplierPayment.dtAdvance.AsEnumerable()
                //                        group r by r["ADID"] into g
                //                        select new
                //                        {
                //                            ADID = g.Key,
                //                            TotalAdvanceAmnt = g.Sum(x => x.Field<decimal>("Current Balance"))
                //                        }).ToList();
                //    for (int j = 0; j < sumOfAdvance.Count(); j++)
                //    {
                //        for (int i = 0; i < grdAdvance.Rows.Count; i++)
                //        {
                //            CurrentBalance = Convert.ToDecimal(grdAdvance.Rows[i].Cells["Current Balance"].Value);
                //            AdvanceAmount = Convert.ToDecimal(grdAdvance.Rows[i].Cells["Advance Amount"].Value);
                //            var key = sumOfAdvance[j];
                //            var ID = key.ADID;
                //            if (Convert.ToString(ID) == Convert.ToString(grdAdvance.Rows[i].Cells["ADID"].Value))
                //            {
                //                dtAdvance.Rows[i]["Current Balance"] = key.TotalAdvanceAmnt;
                //                if (CurrentBalance == AdvanceAmount)
                //                {
                //                    dtAdvance.Rows[i][0] = false;
                //                    grdAdvance.ReadOnly = false;
                //                }
                //                else
                //                {
                //                    grdAdvance.ReadOnly = true;
                //                }
                //            }
                //        }
                //    }
                //}
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
                MainForm.objPAY_SupplierPayment.varApplyFlag = 0;
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
                VARFLAG = 0;
                AdvID = "0";
                decimal varGrandTotal = 0;
                decimal varAdvanceAmnt = 0;
                MainForm.objPAY_SupplierPayment.varAdvanceID = "0";
                MainForm.objPAY_SupplierPayment.lblAdvance.Text = "0.00";
                MainForm.objPAY_SupplierPayment.dtCheckAdv.Clear();
                for (int i = 0; i < grdAdvance.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdAdvance.Rows[i].Cells[0].Value) == true)
                    {
                        VARFLAG = 1;
                        if (AdvID == "0")
                        {
                            AdvID = Convert.ToString(grdAdvance.Rows[i].Cells["ADID"].Value);
                            varAdvanceAmnt = Convert.ToDecimal(grdAdvance.Rows[i].Cells["Current Balance"].Value);
                            varAdvancePayAmnt = Convert.ToString(grdAdvance.Rows[i].Cells["Current Balance"].Value);
                            //dtCheckAdv.Rows.Add(Convert.ToDecimal(grdAdvance.Rows[i].Cells["Current Balance"].Value), Convert.ToInt32(grdAdvance.Rows[i].Cells["ADID"].Value),0);
                        }
                        else
                        {
                            AdvID = AdvID + ',' + Convert.ToString(grdAdvance.Rows[i].Cells["ADID"].Value);
                            varAdvanceAmnt = varAdvanceAmnt + Convert.ToDecimal(grdAdvance.Rows[i].Cells["Current Balance"].Value);
                            varAdvancePayAmnt = varAdvancePayAmnt + ',' + Convert.ToString(grdAdvance.Rows[i].Cells["Current Balance"].Value);
                        }
                        MainForm.objPAY_SupplierPayment.dtCheckAdv.Rows.Add(Convert.ToDecimal(grdAdvance.Rows[i].Cells["Current Balance"].Value), Convert.ToInt32(grdAdvance.Rows[i].Cells["ADID"].Value), grdAdvance.Rows[i].Cells["Current Balance"].Value);
                    }

                }
                if (VARFLAG != 0)
                {
                    MainForm.objPAY_SupplierPayment.varAdvanceID = AdvID;
                    //MainForm.objPAY_SupplierPayment.lblAdvance.Text = Convert.ToString(varAdvanceAmnt);
                    varGrandTotal = Convert.ToDecimal(MainForm.objPAY_SupplierPayment.lblSubtotal.Text) - Convert.ToDecimal(MainForm.objPAY_SupplierPayment.lblAdvance.Text);
                    MainForm.objPAY_SupplierPayment.lblGrandTotal.Text =varGrandTotal.ToString("#,##0.00");
                    MainForm.objPAY_SupplierPayment.varAdvance = varAdvancePayAmnt;
                    MainForm.objPAY_SupplierPayment.btnApply.Enabled = true;
                    MainForm.objPAY_SupplierPayment.btnClear.Enabled = true;
                    //MainForm.objPAY_SupplierPayment.clearClick = 0;
                    this.Close();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    if (grdAdvance.Rows.Count > 0)
                    {
                        string varMessage = objDServ.udfnGetMessages(140);
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
        public void udfndvidSplit()
        {
            try
            {
                //string[] tokens = AdvID.Split(',');
                //for (int i=0;i<grdAdvance.Rows.Count;i++)
                //{
                //    if (tokens[i]==Convert.ToString(grdAdvance.Rows[i].Cells["ADID"].Value))
                //    {
                //        this.grdAdvance.Rows[i].Cells[]
                //    }
                //}
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

        public void Btnunselectall_Click(object sender, EventArgs e)
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

        private void GrdAdvance_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                int varCount = 0;
                for(int i=0;i<grdAdvance.Rows.Count;i++)
                {
                    if(Convert.ToBoolean(grdAdvance.Rows[i].Cells[0].Value)==true)
                    {
                        varCount++;
                    }
                }
                if(MainForm.objPAY_SupplierPayment.varPaymentStatus==76 && MainForm.objPAY_SupplierPayment.clearClick!=1 && varCount != 0)
                {
                    grdAdvance.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdAdvance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // To commit checkbox change immediately
                if (grdAdvance.Columns[e.ColumnIndex].Name == "Column1")
                {
                    grdAdvance.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdAdvance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdAdvance.Columns[e.ColumnIndex].Name == "Column1")
                {
                    udfnCalcCurrentBalance();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnCalcCurrentBalance()
        {
            decimal totalBalance = 0;

            foreach (DataGridViewRow row in grdAdvance.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Column1"].Value);

                if (isChecked)
                {
                    decimal currentBalance = 0;
                    decimal.TryParse(row.Cells["Current Balance"].Value?.ToString(), out currentBalance);

                    totalBalance += currentBalance;
                }
            }

            lblCurrentBalance.Text = totalBalance.ToString("N2"); // "N2" -> number format with commas and 2 decimals
        }
    }
}
