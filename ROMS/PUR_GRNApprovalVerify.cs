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
    public partial class PUR_GRNApprovalVerify : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string varUserId = "";
        public string varPasskey = "";
        public int flag = 0, varVerifyType = 0,varTrnType=0;
        private SecurityController _security;
        public string pbFormStatus;
        public PUR_GRNApprovalVerify()
        {
            InitializeComponent();
            _security = new SecurityController();
        } 
        private void btnAuthorise_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSave();
                this.Close();
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

        private void TxtPassKey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)
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

        public void udfnSave()
        {
            try
            {
                DataSet objDs = new DataSet();
                if (txtPassKey.TextLength != 0)
                {
                    SPDataService objDser = new SPDataService();
                    int count = 0; 
                    varPasskey = _security.Encrypt("passkey", (txtPassKey.Text).Trim());
                    objDs = objDser.udfnUserList(10, "", MainForm.pbUserName, "", 0, 0, varPasskey);
                    objDser.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[2].Rows.Count > 0)
                        {
                            count = Convert.ToInt32(objDs.Tables[2].Rows[0]["countvalue"]);
                            if (count != 0)
                            {
                                flag = 1;
                                varUserId = Convert.ToString(objDs.Tables[2].Rows[0]["ID"]);
                                if (varTrnType == 1)
                                {
                                    MainForm.objPUR_GRNDetails.varUserID = varUserId;
                                    MainForm.objPUR_GRNDetails.varflag = Convert.ToString(flag);
                                } 
                                if (varTrnType == 2)
                                {
                                    MainForm.objPUR_GRNEntry.varUserID = varUserId;
                                    MainForm.objPUR_GRNEntry.varflag = Convert.ToString(flag);
                                }
                                this.Close();
                            }
                        }
                        else
                        {
                             SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(66);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassKey.Text = "";
                            txtPassKey.Focus();
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
    }
}
