using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ROMS
{
    public partial class CP_SL_Verify : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public int flag = 0;
        public CP_SL_Verify()
        {
            InitializeComponent();
        }
        public string GenerateMD5(string HashString)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(HashString)).Select(s => s.ToString("x2")));
        }
        private void btnAuthorise_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet objDs = new DataSet();
                if (txtPassKey.TextLength != 0)
                {
                    SPDataService objDser = new SPDataService();
                    int count = 0;
                    objDs = objDser.udfnUserList(0, "", MainForm.pbUserName, GenerateMD5(txtPassKey.Text), 0);
                    objDser.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            count = Convert.ToInt32(objDs.Tables[0].Rows[0]["countvalue"]);
                            if (count != 0)
                            {
                                flag = 1;
                                this.Close();
                            }
                            else if (count == 0)
                            {
                                //DialogResult response = MessageBox.Show(Convert.ToString(objDs.Tables[1].Rows[0]["MessageText"]), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                SPDataService objDServ = new SPDataService();
                                string varMessage = objDServ.udfnGetMessages(62);
                                objDServ.CloseConnection();
                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassKey.Text = "";
                                txtPassKey.Focus();
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
        private void TxtPassKey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAuthorise.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAuthorise_Enter(object sender, EventArgs e)
        {
            try
            {
                btnAuthorise.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAuthorise_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAuthorise.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPassKey_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPassKey.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPassKey_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPassKey.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAuthorise_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAuthorise_Click(sender, e);
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
