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
    public partial class PUR_GSTIN : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        private ToolTip tpgst = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public PUR_GSTIN()
        {
            InitializeComponent();
        }  
        private void TxtEUnitName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGstin.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEUnitName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGstin.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEUnitName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
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
                if (txtGstin.Text != "")
                {
                    if (txtGstin.Text.Length < 15)
                    {
                        txtGstin.Focus();
                        errUnit.SetError(txtGstin, "Please enter valid supplier GSTIN");
                        txtGstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpgst.ShowAlways = true;
                        tpgst.Show("Please enter valid supplier GSTIN.", txtGstin, 5000); 
                    }
                    else
                    {
                        errUnit.Clear();
                        MainForm.objCP_Purchase.txtGstin.Text = txtGstin.Text;
                        this.Close();
                    }
                }
                else
                { 
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

        private void BtnSave_Leave(object sender, EventArgs e)
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
