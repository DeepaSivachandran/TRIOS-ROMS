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
    public partial class CP_Area : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpCancel = new ToolTip();
        public string varSupplierIds;
        public CP_Area()
        {
            InitializeComponent();
        }
        private void CP_Area_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Area_Leave(object sender, EventArgs e)
        {
            try
            {
                tpCancel.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Area_Load(object sender, EventArgs e)
        {

        }
    }
}
