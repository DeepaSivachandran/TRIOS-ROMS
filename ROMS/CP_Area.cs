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
        private ToolTip tpEAreaName = new ToolTip();
        private ToolTip tpTAreaName = new ToolTip();
        private ToolTip tpRouteName = new ToolTip();
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
                tpEAreaName.Active = false;
                tpTAreaName.Active = false;
                tpRouteName.Active = false;
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
        public void udfnSave(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtREName.Text).Trim() == "")
                {
                    errArea.SetError(txtREName, "Please enter area english name.");
                    txtREName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEAreaName.ShowAlways = true;
                    tpEAreaName.Show("Please enter area english name.", txtREName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtRTName.Text).Trim() == "")
                {
                    errArea.SetError(txtRTName, "Please enter area tamil name.");
                    txtRTName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTAreaName.ShowAlways = true;
                    tpTAreaName.Show("Please enter area tamil name.", txtRTName, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    errArea.Clear();
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
