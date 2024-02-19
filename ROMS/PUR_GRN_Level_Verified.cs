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
using System.Globalization;

namespace ROMS
{
    public partial class PUR_GRN_Level_Verified : Form
    {

        private SecurityController _security;
        DataValidation objValidation = new DataValidation();
        DataError objError;


        private ToolTip tpVerified1 = new ToolTip();
        private ToolTip tpVerified2 = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varUserId = "";
        public string pbGRNId = "";
        public string varPasskey = "";
        public int flag = 0;
        public PUR_GRN_Level_Verified()
        {

            InitializeComponent();
            _security = new SecurityController();
        }
        public string GenerateMD5(string HashString)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(HashString)).Select(s => s.ToString("x2")));
        }
        private void btnAuthorise_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToInt32(cmbVerified1.SelectedValue) == -1 && Convert.ToInt32(cmbVerified2.SelectedValue) == -1)
                {
                    errVerified.SetError(cmbVerified1, "Please select verified by 1");
                    errVerified.SetError(cmbVerified2, "Please select verified by 2");
                    cmbVerified1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    cmbVerified2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerified1.ShowAlways = true;
                    tpVerified2.ShowAlways = true;
                    tpVerified1.Show("Please select verified by 1", cmbVerified1, 5000);
                    tpVerified2.Show("Please select verified by 2", cmbVerified2, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToInt32(cmbVerified1.SelectedValue) == -1 && Convert.ToInt32(cmbVerified2.SelectedValue) != -1)
                {
                    errVerified.SetError(cmbVerified1, "Please select verified by 1");
                    cmbVerified1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerified1.ShowAlways = true;
                    tpVerified1.Show("Please select verified by 1", cmbVerified1, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    errVerified.Clear();
                    udfnSave(sender, e);
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
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                int V1_EMPID = 0, V2_EMPID = 0;
                if (Convert.ToInt32(cmbVerified1.SelectedValue) != -1)
                {
                    V1_EMPID = Convert.ToInt32(cmbVerified1.SelectedValue);
                }
                if (Convert.ToInt32(cmbVerified2.SelectedValue) != -1)
                {
                    V2_EMPID = Convert.ToInt32(cmbVerified2.SelectedValue);
                }
                SPDataService objDser = new SPDataService();
                string result = "", Originator = "";
                if (Convert.ToInt32(cmbVerified1.SelectedValue) != -1)
                {
                    Originator = "GRN Verifed1";
                }
                else
                {
                    Originator = "GRN Verifed2";
                }
                Model.TRN_GRN objTRNS_GRN = new Model.TRN_GRN();
                objTRNS_GRN.ViewType = 2;
                objTRNS_GRN.ParaGRNID = Convert.ToInt32(pbGRNId);
                objTRNS_GRN.ParaVerify1 = Convert.ToInt32(V1_EMPID);
                objTRNS_GRN.ParaVerify2 = Convert.ToInt32(V2_EMPID);
                if (Convert.ToInt32(cmbVerified1.SelectedValue) != -1)
                {
                    objTRNS_GRN.ParaVerifyDate1 = Convert.ToString(dpVerified1.Text);
                }
                if (Convert.ToInt32(cmbVerified2.SelectedValue) != -1)
                {
                    objTRNS_GRN.ParaVerifyDate2 = Convert.ToString(dpVerified2.Text);
                }
                objTRNS_GRN.paraOriginator = Originator;
                result = objDser.udfnGRNEntry(objTRNS_GRN);
                objDser.CloseConnection();
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objPUR_GRNDetails.PbVerified = 1;
                    this.Close();
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

        private void CmbVerified1_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbVerified1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbVerified1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpVerified1.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbVerified1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbVerified1_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbVerified1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbVerified2_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbVerified2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbVerified2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpVerified2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbVerified2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbVerified2_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbVerified2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpVerified2_KeyDown(object sender, KeyEventArgs e)
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

        private void DpVerified1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbVerified2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_GRN_Level_Verified_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbVerified1Load();
                udfnCmbVerified2Load();
                udfnDateLoad();
                dpVerified1.MinDate = MainForm.pbFYStartDate;
                //dpVerified1.MaxDate = MainForm.pbCurrentDate;
                dpVerified2.MinDate = MainForm.pbFYStartDate;
                //dpVerified2.MaxDate = MainForm.pbCurrentDate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbVerified1Load()
        {
            try
            {
                //cmbConcern.Focus();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varViewType = 3, varConcernId = 0;
                objDT = objdserv.udfnEmployeeList(10, "", 0, "", 1, 0, 0);
                objdserv.CloseConnection();
                cmbVerified1.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbVerified1.ValueMember = "EMPID";
                            cmbVerified1.DisplayMember = "EMP_Name";
                            cmbVerified1.DataSource = objDT.Tables[0];
                        }
                    }
                    cmbVerified1.SelectedValue = -1;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbVerified2Load()
        {
            try
            {
                //cmbConcern.Focus();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varViewType = 3, varConcernId = 0;
                objDT = objdserv.udfnEmployeeList(10, "", 0, "", 1, 0, 0);
                objdserv.CloseConnection();
                cmbVerified2.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbVerified2.ValueMember = "EMPID";
                            cmbVerified2.DisplayMember = "EMP_Name";
                            cmbVerified2.DataSource = objDT.Tables[0];
                        }
                    }
                    cmbVerified2.SelectedValue = -1;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDateLoad()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objdserv.udfnGrnListLoad(9, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, "", "", 0, 0, "0", "");
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            dpVerified1.Text = objDs.Tables[0].Rows[0]["GRN1_VerfiedOn"].ToString();
                            dpVerified2.Text = objDs.Tables[0].Rows[0]["GRN2_VerfiedOn"].ToString();
                            cmbVerified1.SelectedValue= Convert.ToInt32(objDs.Tables[0].Rows[0]["Verifiedby1"].ToString());
                            cmbVerified2.SelectedValue= Convert.ToInt32(objDs.Tables[0].Rows[0]["Verifiedby2"].ToString());
                            DateTime varmaxdate = DateTime.ParseExact(objDs.Tables[0].Rows[0]["MAXDATE"].ToString(), "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                            dpVerified1.MaxDate = varmaxdate;
                            dpVerified2.MaxDate = varmaxdate;
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
        private void DpVerified1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dpVerified2.MinDate = Convert.ToDateTime(dpVerified1.Text);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
