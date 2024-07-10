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
using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;

namespace ROMS
{
    public partial class PUR_Purchase_Level_Verified : Form
    {

        private SecurityController _security;
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpVerified1 = new ToolTip();
        private ToolTip tpVerified2 = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varUserId = "";
        public string varVerifiedName = "";
        public string pbPurID = "", pbstsId = "";
        public string varPasskey = "",varEditFlag="0";
        public int flag = 0, verified1 = 0, verified2 = 0;
        public PUR_Purchase_Level_Verified()
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
                bool blnErrorFlag = false; errVerified.Clear();
                //string CurrentTime = DateTime.Now.ToString("h:mm");
                //string[] varCurrentTime = CurrentTime.Split(':');
                //string CurrentTimeFormat = DateTime.Now.ToString("h:mm tt");
                //string[] CurrentTimeFormat1 = CurrentTimeFormat.Split(' ');
                if (Convert.ToString(txtVerified.Text.Trim()) == "")
                {
                    errVerified.SetError(txtVerified, "Please select verified by 1");
                    txtVerified.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerified1.ShowAlways = true;
                    tpVerified1.Show("Please select verified by", txtVerified, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtVerified.Text.Trim()) == "")
                {
                    errVerified.SetError(txtVerified, "Please select verified by 1");
                    txtVerified.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerified1.ShowAlways = true;
                    tpVerified1.Show("Please select verified by", txtVerified, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtVerified.Text.Trim()) != "")
                {
                    string[] varTime = mtbTime.Text.Split(':');
                    int Hour = varTime[0].Trim().Length;
                    int Min = varTime[1].Trim().Length;
                    if (varTime[0].Trim() == "" || Convert.ToInt32(varTime[0]) > 12 || Hour == 1 || varTime[0].Trim() == "0" || varTime[0].Trim() == "00")
                    {
                        errVerified.SetError(mtbTime, "Please enter valid hour");
                        mtbTime.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        blnErrorFlag = true;
                    }
                    if (varTime[1].Trim() == "" || Convert.ToInt32(varTime[1]) > 59 || Min == 1 || varTime[1].Trim() == "0")
                    {
                        errVerified.SetError(mtbTime, "Please enter valid minute");
                        mtbTime.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        blnErrorFlag = true;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 21;
                    objMR_Master.paraDate = dpVerified.Text;
                    objMR_Master.paraTime = mtbTime.Text;
                    objMR_Master.paraTimeFormat = cmbFormat.Text;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(objMR_Master);
                    if (objd.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(objd.Tables[0].Rows[0]["TimeFlag"]) == 0)
                        {
                            errVerified.SetError(mtbTime, "Please enter valid Time");
                            mtbTime.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            errVerified.SetError(cmbFormat, "Please enter valid Format");
                            cmbFormat.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            blnErrorFlag = true;
                        }
                    }
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
                MainForm.objCP_Purchase.pbVerifiedBy = Convert.ToInt32(lblVerified1.Text);
                MainForm.objCP_Purchase.pbVerifiedOn = Convert.ToString(dpVerified.Text);
                MainForm.objCP_Purchase.pbVerifiedTime = Convert.ToString(mtbTime.Text);
                MainForm.objCP_Purchase.pbVerifiedFormat = Convert.ToString(cmbFormat.Text);
                MainForm.objCP_Purchase.pbVerifiedName = Convert.ToString(txtVerified.Text);
                MainForm.objCP_Purchase.PbVerified = 1;
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadDetails()
        {
            try
            {
                lblVerified1.Text =Convert.ToString(MainForm.objCP_Purchase.pbVerifiedBy);
                dpVerified.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedOn);
                mtbTime.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedTime);
                cmbFormat.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedFormat);
                txtVerified.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedName);
            }
            catch(Exception ex)
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


        private void DpVerified1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    mtbTime.Focus();
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
                if (txtVerified.Text.Trim() == "")
                { cmbFormat.SelectedIndex = 0; }
                dpVerified.MinDate = MainForm.pbFYStartDate;
                dpVerified.MaxDate = MainForm.pbCurrentDate;
                udfnEditload();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEditload()
        {
            try
            {
                lblVerified1.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedBy);
                txtVerified.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedName);
                dpVerified.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedOn);
                mtbTime.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedTime);
                cmbFormat.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedFormat);
                varEditFlag = Convert.ToString(MainForm.objCP_Purchase.varPurVerifyFlag);
                lvVerified.Visible = false;
                if(varEditFlag=="1")
                {
                    txtVerified.Enabled = false;
                    mtbTime.Enabled = false;
                    cmbFormat.Enabled = false;
                    dpVerified.Enabled = false;
                    lvVerified.Visible = false;
                    btnAuthorise.Enabled = false;
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
                DateTime varmindate = DateTime.ParseExact(dpVerified.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtVerified1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtVerified.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtVerified1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvVerified.Items.Count == 0 || txtVerified.Text == "")
                    {
                        lvVerified.Visible = false;
                    }
                    else
                    {
                        lvVerified.Focus();
                    }
                    if (lvVerified.Items.Count > 0)
                    {
                        lvVerified.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    dpVerified.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtVerified1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtVerified.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtVerified1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVerified.Text.Length > 0)
                {
                    lvVerified.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(14, txtVerified.Text.Trim(), 0, "", 1, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["EMP_Name"].ToString(), objDs.Tables[0].Rows[i]["EMPID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvVerified.Columns[1].Width = 0;
                                    lvVerified.Items.Add(objList);
                                }
                                lvVerified.BringToFront();
                                lvVerified.Visible = true;
                            }
                            else
                            {
                                lvVerified.Visible = false;
                            }
                        }
                        else
                        {
                            lvVerified.Visible = false;
                        }
                    }
                    else
                    {
                        lvVerified.Visible = false;
                    }
                }
                else
                {
                    lvVerified.Visible = false;
                    lvVerified.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvVerified1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnVerified1();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void MtbTime1_Enter(object sender, EventArgs e)
        {
            try
            {
                mtbTime.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void MtbTime1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbFormat.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void MtbTime1_Leave(object sender, EventArgs e)
        {
            try
            {
                int error = 0;
                if (txtVerified.Text.Trim() != "")
                {
                    string[] varTime = mtbTime.Text.Split(':');
                    int Hour = varTime[0].Trim().Length;
                    int Min = varTime[1].Trim().Length;
                    if (varTime[0].Trim() == "" || Convert.ToInt32(varTime[0]) > 12 || Hour == 1 || varTime[0].Trim() == "0" || varTime[0].Trim() == "00")
                    {
                        errVerified.SetError(mtbTime, "Please enter valid hour");
                        mtbTime.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                    if (varTime[1].Trim() == "" || Convert.ToInt32(varTime[1]) > 59 || Min == 1 || varTime[1].Trim() == "0")
                    {
                        errVerified.SetError(mtbTime, "Please enter valid minute");
                        mtbTime.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 21;
                    objMR_Master.paraDate = dpVerified.Text;
                    objMR_Master.paraTime = mtbTime.Text;
                    objMR_Master.paraTimeFormat = cmbFormat.Text;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(objMR_Master);
                    if (Convert.ToInt32(objd.Tables[0].Rows[0]["TimeFlag"]) == 0)
                    {
                        errVerified.SetError(mtbTime, "Please enter valid Time");
                        mtbTime.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        errVerified.SetError(cmbFormat, "Please enter valid Format");
                        cmbFormat.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                }
                if (error == 0)
                {
                    errVerified.Clear();
                    mtbTime.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbFormat1_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbFormat.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbFormat1_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbFormat.BackColor = Color.White;
                if (mtbTime.Text != "")
                {
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 21;
                    objMR_Master.paraDate = dpVerified.Text;
                    objMR_Master.paraTime = mtbTime.Text;
                    objMR_Master.paraTimeFormat = cmbFormat.Text;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(objMR_Master);
                    if (Convert.ToInt32(objd.Tables[0].Rows[0]["TimeFlag"]) == 0)
                    {
                        errVerified.SetError(mtbTime, "Please enter valid Time");
                        mtbTime.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        errVerified.SetError(cmbFormat, "Please enter valid Format");
                        cmbFormat.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbFormat1_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbFormat1_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbFormat2_KeyDown(object sender, KeyEventArgs e)
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
        private void PUR_GRN_Level_Verified_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    btnAuthorise_Click(sender, e);
                }
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
        public void udfnVerified1()
        {
            try
            {
                if (txtVerified.Text != "")
                {
                    ListViewItem selectedItem = lvVerified.SelectedItems[0];
                    txtVerified.Text = selectedItem.SubItems[0].Text;
                    lblVerified1.Text = selectedItem.SubItems[1].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvVerified.Visible = false;
                dpVerified.Focus();
            }
        }
        private void LvVerified1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnVerified1();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
