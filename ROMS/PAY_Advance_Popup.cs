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
    public partial class PAY_Advance_Popup : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtAdvance = new DataTable();

        public PAY_Advance_Popup()
        {
            InitializeComponent();
        }

        private void BtnClo_Click(object sender, EventArgs e)
        {
            try
            {

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

        private void PAY_Advance_Popup_Load(object sender, EventArgs e)
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
                varSupplierid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.lblSupplierCode.Text);
                varScheduleid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.lblschedule.Text);
                varcompanyid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.cmbConcern.SelectedValue);

                dtAdvance = new DataTable();
                dtAdvance.Columns.Add("", typeof(Boolean));
                dtAdvance.Columns.Add("S.No.", typeof(string));
                dtAdvance.Columns.Add("Advance Date", typeof(string));
                dtAdvance.Columns.Add("Advance Amount", typeof(float));
                TRN_Advance objTRN_Advance = new TRN_Advance();
                objTRN_Advance.ViewType = 2;
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
                        lblNoRecordFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdAdvance.DataSource = null;
                            lblNoRecordFound.Visible = false;
                            lblNoRecordFound.SendToBack();
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                dtAdvance.Rows.Add(false,  objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["Advance Date"], objDs.Tables[0].Rows[i]["Advance Amount"]);
                            }
                            grdAdvance.DataSource = dtAdvance;
                            grdAdvance.Columns[0].HeaderText = "";
                            grdAdvance.Columns[0].Width = 30;
                            grdAdvance.Columns["S.No."].Width = 70;
                            grdAdvance.Columns["Advance Date"].Width = 120;
                            grdAdvance.Columns["Advance Amount"].Width = 120;
                            grdAdvance.Columns["S.No."].ReadOnly = true;
                            grdAdvance.Columns["Advance Date"].ReadOnly = true;
                            grdAdvance.Columns["Advance Amount"].ReadOnly = true;
                            grdAdvance.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdAdvance.Columns["Advance Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdAdvance.Columns["Advance Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        else
                        {
                            lblNoRecordFound.Visible = true;
                            lblNoRecordFound.BringToFront();
                        }
                    }
                    else
                    {
                        lblNoRecordFound.Visible = true;
                        lblNoRecordFound.BringToFront();
                    }
                }
                else
                {
                    lblNoRecordFound.Visible = true;
                    lblNoRecordFound.BringToFront();
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