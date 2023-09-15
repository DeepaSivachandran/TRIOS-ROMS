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
    public partial class PUR_POScheduledaywise : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public PUR_POScheduledaywise()
        {
            InitializeComponent();
            MainForm.objPUR_SupplierScheduleList.picLoader.Visible = false;
        }

        private void PUR_POScheduledaywise_Load(object sender, EventArgs e)
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
                grdHeaderview.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService(); 
                objDs = objdserv.udfnSupplierList(9, 0, 0, 0, 0, "", 0,0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    { 
                        if (objDs.Tables[0].Rows.Count != 0)
                        { 
                            grdHeaderview.DataSource = objDs.Tables[0];
                            foreach (DataGridViewColumn column in grdHeaderview.Columns)
                            {
                                if (column.Index > 1)  
                                {
                                    column.Width = 200;
                                }
                            }

                        }

                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            grdPOSchedule.DataSource = objDs.Tables[1];
                            grdPOSchedule.Columns["DYID"].Visible = false;
                            grdPOSchedule.Columns["S.No."].Width = 50;
                            grdPOSchedule.Columns["Order Day"].Width = 100;
                            foreach (DataGridViewColumn column in grdPOSchedule.Columns)
                            {
                                if (column.Index > 1)
                                {
                                    column.Width = 100;
                                }
                                string[] parts = column.HeaderText.Split('-');
                                 
                                if (parts.Length > 1)
                                { 
                                    column.HeaderText = parts[parts.Length - 1];
                                }
                            } 
                            if (grdPOSchedule.Rows.Count > 0) // Check if there are any rows
                            {
                                grdPOSchedule.Rows[grdPOSchedule.Rows.Count - 1].Cells[1].Value = null;
                            }
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

        private void BtnPrintdaywise_Enter(object sender, EventArgs e)
        {
            try
            {
                btnPrintdaywise.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPrintdaywise_Leave(object sender, EventArgs e)
        {
            try
            {
                btnPrintdaywise.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void BtnPrintdaywise_Click(object sender, EventArgs e)
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

        private void PUR_POScheduledaywise_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
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
    }
}
