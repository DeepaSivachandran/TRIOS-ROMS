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
    public partial class PUR_GRNVerify : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus, pbGRNId="0";
        public string varUserId = "";
        public string varPasskey = "";
        public int flag = 0, varVerifyType=0;
        private SecurityController _security;
        public PUR_GRNVerify()
        {
            InitializeComponent();
            _security = new SecurityController();
        }
         

        private void TxtEUnitName_Enter(object sender, EventArgs e)
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

        private void TxtEUnitName_Leave(object sender, EventArgs e)
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnSave() {
            try
            {
                DataSet objDs = new DataSet();
                if (txtPassKey.TextLength != 0)
                {
                    SPDataService objDser = new SPDataService();
                    int count = 0;
                    string result = "", Originator="";
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
                                if (varVerifyType == 1)
                                {
                                    flag = 1;
                                    Originator = "GRN Verifed1";
                                }
                                else
                                {
                                    flag = 2;
                                    Originator = "GRN Verifed2";
                                }
                                varUserId = Convert.ToString(objDs.Tables[2].Rows[0]["ID"]); 

                                TRN_GRN objTRNS_GRN = new TRN_GRN();
                                objTRNS_GRN.ViewType = 2;
                                objTRNS_GRN.ParaGRNID = Convert.ToInt32(pbGRNId);
                                objTRNS_GRN.ParaVerify = Convert.ToInt32(varUserId);
                                objTRNS_GRN.paraflag = Convert.ToInt32(flag);
                                objTRNS_GRN.paraOriginator = Originator;
                                result = objDser.udfnGRNEntry(objTRNS_GRN);
                                objDser.CloseConnection();
                                string[] varvalue = result.Split('~');
                                if (varvalue[0] == "3")
                                {
                                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MainForm.objPUR_GRNDetails.varenablefalg = Convert.ToString(flag);
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            //DialogResult response = MessageBox.Show(Convert.ToString(objDs.Tables[1].Rows[0]["MessageText"]), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
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
