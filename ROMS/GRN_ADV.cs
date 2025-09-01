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
    public partial class GRN_ADV : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtAdvance = new DataTable();
        DataTable dtCheckAdv = new DataTable();
        public string AdvID = ""; public string varEditAdv = "";
        public string varAdvancePayAmnt = "";
        public int VARFLAG = 0,pbSupplierID=0 , pbADID=0, pbPayType=0;
        public GRN_ADV()
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
                bool varCheck = false;  
                TRN_Advance objTRN_Advance = new TRN_Advance();
                objTRN_Advance.ViewType = 4; 
                objTRN_Advance.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRN_Advance.paraIPAddress = MainForm.pbIpAddress;
                objTRN_Advance.paraSupplierId = pbSupplierID;
                objTRN_Advance.paraAdvanceId = pbADID;
                objTRN_Advance.paraAmountType = pbPayType;
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
                            grdAdvance.DataSource = objDs.Tables[0];
                            for (int i = 0; i < grdAdvance.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(grdAdvance.Rows[i].Cells["ID"].Value) ==pbADID)
                                {
                                    grdAdvance.Rows[i].Cells[0].Value = true;
                                }
                                else
                                {
                                    grdAdvance.Rows[i].Cells[0].Value = false;
                                } 
                            }   
                            grdAdvance.Columns["S.No."].Width = 50;
                            grdAdvance.Columns["Advance Date"].Width = 120; 
                            grdAdvance.Columns["Advance Amount"].Width = 120;
                            grdAdvance.Columns["Receipt No"].Width = 100;
                            grdAdvance.Columns["Receipt No"].ReadOnly = true;
                            grdAdvance.Columns["Advance Date"].ReadOnly = true;  
                            grdAdvance.Columns["ID"].Visible = false;  
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
                VARFLAG = 0;
                AdvID = "0";  
                var ADID = grdAdvance.Rows.Cast<DataGridViewRow>()
                .Where(r => (r.Cells[0].Value as bool?) == true
                         && r.Cells["ID"].Value != null
                         && r.Cells["ID"].Value != DBNull.Value)
                .Select(r => Convert.ToInt32(r.Cells["ID"].Value))
                .ToList();
                pbADID = ADID[0];
                if (pbADID != 0)
                {
                    MainForm.objPUR_GRNEntry.pbAdvanceID = pbADID;
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

        private void GrdAdvance_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {   //for check box as radio button function
                if (grdAdvance.CurrentCell.ColumnIndex == 0)
                {
                    for (int i = 0; i < grdAdvance.Rows.Count; i++)
                    {
                        //if (i != dataGridView1.CurrentCell.RowIndex)
                        grdAdvance.Rows[i].Cells[0].Value = false; 
                    }
                    grdAdvance.Rows[grdAdvance.CurrentCell.RowIndex].Cells[0].Value = true;
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
