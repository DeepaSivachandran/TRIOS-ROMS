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
    }
}
