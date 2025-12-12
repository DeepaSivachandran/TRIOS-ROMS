using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Globalization;
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
        public string varUserId = "",varVoucherDate="";
        public string varVerifiedName = "";
        public string pbPurID = "", pbstsId = "";
        public string varPasskey = "", varEditFlag = "0", varEditFlag2 = "0";
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
                if (Convert.ToString(txtVerified1.Text.Trim()) == "" && Convert.ToString(txtVerified2.Text.Trim()) == "")
                {
                    errVerified.SetError(txtVerified1, "Please select verified by 1");
                    errVerified.SetError(txtVerified2, "Please select verified by 2");
                    txtVerified1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtVerified2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerified1.ShowAlways = true;
                    tpVerified2.ShowAlways = true;
                    tpVerified1.Show("Please select verified by 1", txtVerified1, 5000);
                    tpVerified2.Show("Please select verified by 2", txtVerified2, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtVerified1.Text.Trim()) == "" && Convert.ToString(txtVerified2.Text.Trim()) != "")
                {
                    errVerified.SetError(txtVerified1, "Please select verified by 1");
                    txtVerified1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerified1.ShowAlways = true;
                    tpVerified1.Show("Please select verified by 1", txtVerified1, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtVerified1.Text.Trim()) != "")
                {
                    string[] varTime = mtbTime1.Text.Split(':');
                    int Hour = varTime[0].Trim().Length;
                    int Min = varTime[1].Trim().Length;
                    if (varTime[0].Trim() == "" || Convert.ToInt32(varTime[0]) > 12 || Hour == 1 || varTime[0].Trim() == "0" || varTime[0].Trim() == "00")
                    {
                        errVerified.SetError(mtbTime1, "Please enter valid hour");
                        mtbTime1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        blnErrorFlag = true;
                    }
                    if (varTime[1].Trim() == "" || Convert.ToInt32(varTime[1]) > 59 || Min == 1 || varTime[1].Trim() == "0")
                    {
                        errVerified.SetError(mtbTime1, "Please enter valid minute");
                        mtbTime1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        blnErrorFlag = true;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 21;
                    objMR_Master.paraDate = dpVerified1.Text;
                    objMR_Master.paraTime = mtbTime1.Text;
                    objMR_Master.paraTimeFormat = cmbFormat1.Text;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(objMR_Master);
                    if (objd.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(objd.Tables[0].Rows[0]["TimeFlag"]) == 0)
                        {
                            errVerified.SetError(mtbTime1, "Please enter valid Time");
                            mtbTime1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            errVerified.SetError(cmbFormat1, "Please enter valid Format");
                            cmbFormat1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            blnErrorFlag = true;
                        }
                    }
                    if (lblVerified1.Text.Trim() == "" || lblVerified1.Text.Trim() == "0" || lblVerified1.Text.Trim() == "-1")
                    {
                        errVerified.SetError(txtVerified1, "Please enter valid verification detail.");
                        txtVerified1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpVerified1.ShowAlways = true;
                        tpVerified1.Show("Please enter valid verification detail.", txtVerified1, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtVerified2.Text.Trim()) != "")
                {
                    string[] varTime = mtbTime2.Text.Split(':');
                    int Hour = varTime[0].Trim().Length;
                    int Min = varTime[1].Trim().Length;
                    if (varTime[0].Trim() == "" || Convert.ToInt32(varTime[0]) > 12 || Hour == 1 || varTime[0].Trim() == "0" || varTime[0].Trim() == "00")
                    {
                        errVerified.SetError(mtbTime2, "Please enter valid hour");
                        mtbTime2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        blnErrorFlag = true;
                    }
                    if (varTime[1].Trim() == "" || Convert.ToInt32(varTime[1]) > 59 || Min == 1 || varTime[1].Trim() == "0")
                    {
                        errVerified.SetError(mtbTime2, "Please enter valid minute");
                        mtbTime2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        blnErrorFlag = true;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 21;
                    objMR_Master.paraDate = dpVerified2.Text;
                    objMR_Master.paraTime = mtbTime2.Text;
                    objMR_Master.paraTimeFormat = cmbFormat2.Text;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(objMR_Master);
                    if (objd.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(objd.Tables[0].Rows[0]["TimeFlag"]) == 0)
                        {
                            errVerified.SetError(mtbTime2, "Please enter valid Time");
                            mtbTime2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            errVerified.SetError(cmbFormat2, "Please enter valid Format");
                            cmbFormat2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            blnErrorFlag = true;
                        }
                    }
                    if (lblVerified2.Text.Trim() == "" || lblVerified2.Text.Trim() == "0" || lblVerified2.Text.Trim() == "-1")
                    {
                        errVerified.SetError(txtVerified2, "Please enter valid verification detail.");
                        txtVerified2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpVerified2.ShowAlways = true;
                        tpVerified2.Show("Please enter valid verification detail.", txtVerified2, 5000);
                        blnErrorFlag = true;
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
                MainForm.objCP_Purchase.pbVerifiedBy1 = Convert.ToInt32(lblVerified1.Text);
                MainForm.objCP_Purchase.pbVerifiedOn1 = Convert.ToString(dpVerified1.Text);
                MainForm.objCP_Purchase.pbVerifiedTime1 = Convert.ToString(mtbTime1.Text);
                MainForm.objCP_Purchase.pbVerifiedFormat1 = Convert.ToString(cmbFormat1.Text);
                MainForm.objCP_Purchase.pbVerifiedName1 = Convert.ToString(txtVerified1.Text);
                MainForm.objCP_Purchase.PbVerified1 = 1;
                MainForm.objCP_Purchase.lblPurchaseVerification.Text = Convert.ToString(txtVerified1.Text + " - " + dpVerified1.Text + " @ " + mtbTime1.Text + " " + cmbFormat1.Text);

                if (txtVerified2.Text.Trim() != "")
                {
                    MainForm.objCP_Purchase.pbVerifiedBy2 = Convert.ToInt32(lblVerified2.Text);
                    MainForm.objCP_Purchase.pbVerifiedOn2 = Convert.ToString(dpVerified2.Text);
                    MainForm.objCP_Purchase.pbVerifiedTime2 = Convert.ToString(mtbTime2.Text);
                    MainForm.objCP_Purchase.pbVerifiedFormat2 = Convert.ToString(cmbFormat2.Text);
                    MainForm.objCP_Purchase.pbVerifiedName2 = Convert.ToString(txtVerified2.Text);
                    MainForm.objCP_Purchase.PbVerified2 = 1;
                    MainForm.objCP_Purchase.lblPurchaseVerification2.Text = Convert.ToString(txtVerified2.Text + " - " + dpVerified2.Text + " @ " + mtbTime2.Text + " " + cmbFormat2.Text);
                }
                else
                {
                    MainForm.objCP_Purchase.pbVerifiedBy2 = 0;
                    MainForm.objCP_Purchase.pbVerifiedOn2 = "";
                    MainForm.objCP_Purchase.pbVerifiedTime2 = "";
                    MainForm.objCP_Purchase.pbVerifiedFormat2 = "";
                    MainForm.objCP_Purchase.pbVerifiedName2 = "";
                    MainForm.objCP_Purchase.PbVerified2 = 0;
                    MainForm.objCP_Purchase.lblPurchaseVerification2.Text = "-";
                }
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
                lblVerified1.Text =Convert.ToString(MainForm.objCP_Purchase.pbVerifiedBy1);
                dpVerified1.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedOn1);
                mtbTime1.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedTime1);
                cmbFormat1.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedFormat1);
                txtVerified1.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedName1);
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
                    mtbTime1.Focus();
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
                if (Convert.ToString(MainForm.objCP_Purchase.PbSTS) != "50")
                {
                    cmbFormat1.SelectedIndex = 0;
                    cmbFormat2.SelectedIndex = 0;
                    dpVerified1.MinDate = MainForm.pbFYStartDate;
                    dpVerified1.MaxDate = MainForm.pbCurrentDate;
                    dpVerified2.MinDate = MainForm.pbFYStartDate;
                    dpVerified2.MaxDate = MainForm.pbCurrentDate;
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 24;
                    objMR_Master.paraDate = varVoucherDate;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(objMR_Master);
                    if (objd.Tables[0].Rows.Count > 0)
                    {
                        DateTime varminDate = DateTime.ParseExact(objd.Tables[0].Rows[0]["MinDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime varmaxDate = DateTime.ParseExact(objd.Tables[0].Rows[0]["MaxDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        dpVerified1.MaxDate = varmaxDate;
                        dpVerified1.MinDate = varminDate;
                        dpVerified2.MaxDate = varmaxDate;
                        dpVerified2.MinDate = varminDate;
                    }
                    objDServ.CloseConnection();
                }
                if (MainForm.objCP_Purchase.pbVerifiedBy1 != 0)
                {
                    udfnEditload();
                }
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
                lblVerified1.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedBy1);
                txtVerified1.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedName1);
                if (MainForm.objCP_Purchase.pbVerifiedOn1 != "")
                {
                    DateTime varminDate = DateTime.ParseExact(Convert.ToString(MainForm.objCP_Purchase.pbVerifiedOn1), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpVerified1.MaxDate = varminDate;
                }
                //dpVerified.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedOn);
                mtbTime1.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedTime1);
                cmbFormat1.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedFormat1);
                varEditFlag = Convert.ToString(MainForm.objCP_Purchase.varPurVerifyFlag);
                lvVerified1.Visible = false;
                if(varEditFlag=="1")
                {
                    txtVerified1.Enabled = false;
                    mtbTime1.Enabled = false;
                    cmbFormat1.Enabled = false;
                    dpVerified1.Enabled = false;
                    lvVerified1.Visible = false;
                    btnAuthorise.Enabled = false;
                }

                lblVerified2.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedBy2);
                txtVerified2.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedName2);
                if (MainForm.objCP_Purchase.pbVerifiedOn2 != "")
                {
                    DateTime varminDate2 = DateTime.ParseExact(Convert.ToString(MainForm.objCP_Purchase.pbVerifiedOn2), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpVerified2.MaxDate = varminDate2;
                }
                //dpVerified.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedOn);
                mtbTime2.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedTime2);
                if (Convert.ToString(MainForm.objCP_Purchase.pbVerifiedFormat2) != "")
                {
                    cmbFormat2.Text = Convert.ToString(MainForm.objCP_Purchase.pbVerifiedFormat2);
                }
                varEditFlag2 = Convert.ToString(MainForm.objCP_Purchase.varPurVerifyFlag2);
                lvVerified2.Visible = false;

                if (txtVerified2.Text.Trim() != "")
                {
                    dpVerified2.Value = dpVerified1.Value;
                    dpVerified2.Enabled = false;
                    mtbTime2.Text = mtbTime1.Text;
                    mtbTime2.Enabled = false;
                    mtbTime2.ReadOnly = true;
                    cmbFormat2.SelectedValue = cmbFormat1.SelectedValue;
                    cmbFormat2.Enabled = false;
                }
                if (varEditFlag2 == "1")
                {
                    txtVerified2.Enabled = false;
                    mtbTime2.Enabled = false;
                    cmbFormat2.Enabled = false;
                    dpVerified2.Enabled = false;
                    lvVerified2.Visible = false;
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
                DateTime varmindate = DateTime.ParseExact(dpVerified1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpVerified2.MinDate = varmindate;
                if (txtVerified2.Text != "")
                {
                    //dpVerified2.Text = dpVerified1.Text;
                    dpVerified2.Value = dpVerified1.Value;
                    dpVerified2.Enabled = false;
                }
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
                txtVerified1.BackColor = Color.LemonChiffon;
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
                    if (lvVerified1.Items.Count == 0 || txtVerified1.Text == "")
                    {
                        lvVerified1.Visible = false;
                    }
                    else
                    {
                        lvVerified1.Focus();
                    }
                    if (lvVerified1.Items.Count > 0)
                    {
                        lvVerified1.Items[0].Selected = true;
                    }
                }
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
        private void TxtVerified1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtVerified1.BackColor = Color.White;
                udfnVerificationValidation(txtVerified1.Text.Trim(), 1);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtVerified2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtVerified2.BackColor = Color.White;
                if (txtVerified2.Text != "")
                {
                    dpVerified2.Value = dpVerified1.Value;
                    //dpVerified2.Text = dpVerified1.Text;
                    dpVerified2.Enabled = false;
                    mtbTime2.Text = mtbTime1.Text;
                    mtbTime2.Enabled = false;
                    mtbTime2.ReadOnly = true;
                    cmbFormat2.SelectedIndex = cmbFormat1.SelectedIndex;
                    cmbFormat2.Enabled = false;
                }
                else
                {
                    dpVerified2.Value = DateTime.Now.Date;
                    //dpVerified2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    dpVerified2.Enabled = true;
                    mtbTime2.Text = "";
                    mtbTime2.Enabled = true;
                    mtbTime2.ReadOnly = false;
                    cmbFormat2.SelectedValue = "AM";
                    cmbFormat2.Enabled = true;
                }
                udfnVerificationValidation(txtVerified2.Text.Trim(), 2);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnVerificationValidation(string varVerifierName,int VerifiedByFlag)
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objdserv.udfnEmployeeList(14, varVerifierName, 0, "", 1, 0, 0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            if (VerifiedByFlag == 1)
                            {
                                lblVerified1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["EMPID"]);
                            }
                            else
                            {
                                lblVerified2.Text = Convert.ToString(objDs.Tables[0].Rows[0]["EMPID"]);
                            }
                        }
                        else
                        {
                            if (VerifiedByFlag == 1)
                            {
                                lblVerified1.Text = "0";
                                errVerified.SetError(txtVerified1, "Please enter valid verification detail.");
                                txtVerified1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpVerified1.ShowAlways = true;
                                tpVerified1.Show("Please enter valid verification detail.", txtVerified1, 5000);
                            }
                            else
                            {
                                lblVerified2.Text = "0";
                                errVerified.SetError(txtVerified2, "Please enter valid verification detail.");
                                txtVerified2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpVerified2.ShowAlways = true;
                                tpVerified2.Show("Please enter valid verification detail.", txtVerified2, 5000);
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
        private void TxtVerified1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVerified1.Text.Length > 0)
                {
                    if(txtVerified2.Text.Trim()=="")
                    {
                        lblVerified2.Text = "0";
                    }
                    lvVerified1.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(14, txtVerified1.Text.Trim(), Convert.ToInt32(lblVerified2.Text), "", 1, 0, 0);
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
                                    lvVerified1.Columns[1].Width = 0;
                                    lvVerified1.Items.Add(objList);
                                }
                                lvVerified1.BringToFront();
                                lvVerified1.Visible = true;
                            }
                            else
                            {
                                lvVerified1.Visible = false;
                            }
                        }
                        else
                        {
                            lvVerified1.Visible = false;
                        }
                    }
                    else
                    {
                        lvVerified1.Visible = false;
                    }
                }
                else
                {
                    lvVerified1.Visible = false;
                    lvVerified1.Items.Clear();
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
                mtbTime1.BackColor = Color.LemonChiffon;
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
                    cmbFormat1.Focus();
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
                if (txtVerified1.Text.Trim() != "")
                {
                    string[] varTime = mtbTime1.Text.Split(':');
                    int Hour = varTime[0].Trim().Length;
                    int Min = varTime[1].Trim().Length;
                    if (varTime[0].Trim() == "" || Convert.ToInt32(varTime[0]) > 12 || Hour == 1 || varTime[0].Trim() == "0" || varTime[0].Trim() == "00")
                    {
                        errVerified.SetError(mtbTime1, "Please enter valid hour");
                        mtbTime1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                    if (varTime[1].Trim() == "" || Convert.ToInt32(varTime[1]) > 59 || Min == 1 || varTime[1].Trim() == "0")
                    {
                        errVerified.SetError(mtbTime1, "Please enter valid minute");
                        mtbTime1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 21;
                    objMR_Master.paraDate = dpVerified1.Text;
                    objMR_Master.paraTime = mtbTime1.Text;
                    objMR_Master.paraTimeFormat = cmbFormat1.Text;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(objMR_Master);
                    if (Convert.ToInt32(objd.Tables[0].Rows[0]["TimeFlag"]) == 0)
                    {
                        errVerified.SetError(mtbTime1, "Please enter valid Time");
                        mtbTime1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        errVerified.SetError(cmbFormat1, "Please enter valid Format");
                        cmbFormat1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                }
                if (txtVerified2.Text != "")
                {
                    mtbTime2.Text = mtbTime1.Text;
                    mtbTime2.Enabled = false;
                    mtbTime2.ReadOnly = true;
                }
                if (error == 0)
                {
                    errVerified.Clear();
                    mtbTime1.BackColor = Color.White;
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
                cmbFormat1.BackColor = Color.LemonChiffon;
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
                cmbFormat1.BackColor = Color.White;
                if (mtbTime1.Text != "")
                {
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 21;
                    objMR_Master.paraDate = dpVerified1.Text;
                    objMR_Master.paraTime = mtbTime1.Text;
                    objMR_Master.paraTimeFormat = cmbFormat1.Text;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(objMR_Master);
                    if (Convert.ToInt32(objd.Tables[0].Rows[0]["TimeFlag"]) == 0)
                    {
                        errVerified.SetError(mtbTime1, "Please enter valid Time");
                        mtbTime1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        errVerified.SetError(cmbFormat1, "Please enter valid Format");
                        cmbFormat1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
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
                    txtVerified2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtVerified2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtVerified2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtVerified2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvVerified2.Items.Count == 0 || txtVerified2.Text == "")
                    {
                        lvVerified2.Visible = false;
                    }
                    else
                    {
                        lvVerified2.Focus();
                    }
                    if (lvVerified2.Items.Count > 0)
                    {
                        lvVerified2.Items[0].Selected = true;
                    }
                }
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

        private void TxtVerified2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVerified2.Text.Length > 0)
                {
                    if(txtVerified1.Text.Trim()=="")
                    {
                        lblVerified1.Text = "0";
                    }
                    lvVerified2.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(14, txtVerified2.Text.Trim(), Convert.ToInt32(lblVerified1.Text), "", 1, 0, 0);
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
                                    lvVerified2.Columns[1].Width = 0;
                                    lvVerified2.Items.Add(objList);
                                }
                                lvVerified2.BringToFront();
                                lvVerified2.Visible = true;
                            }
                            else
                            {
                                lvVerified2.Visible = false;
                            }
                        }
                        else
                        {
                            lvVerified2.Visible = false;
                        }
                    }
                    else
                    {
                        lvVerified2.Visible = false;
                    }
                }
                else
                {
                    lvVerified2.Visible = false;
                    lvVerified2.Items.Clear();
                }
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
                    mtbTime2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpVerified2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpVerified2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void MtbTime2_Enter(object sender, EventArgs e)
        {
            try
            {
                mtbTime2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void MtbTime2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbFormat2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void MtbTime2_Leave(object sender, EventArgs e)
        {
            try
            {
                int error = 0;
                if (txtVerified2.Text.Trim() != "")
                {
                    string[] varTime = mtbTime2.Text.Split(':');
                    int Hour = varTime[0].Trim().Length;
                    int Min = varTime[1].Trim().Length;
                    if (varTime[0].Trim() == "" || Convert.ToInt32(varTime[0]) > 12 || Hour == 1 || varTime[0].Trim() == "0" || varTime[0].Trim() == "00")
                    {
                        errVerified.SetError(mtbTime2, "Please enter valid hour");
                        mtbTime2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                    if (varTime[1].Trim() == "" || Convert.ToInt32(varTime[1]) > 59 || Min == 1 || varTime[1].Trim() == "0")
                    {
                        errVerified.SetError(mtbTime2, "Please enter valid minute");
                        mtbTime2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 21;
                    objMR_Master.paraDate = dpVerified2.Text;
                    objMR_Master.paraTime = mtbTime2.Text;
                    objMR_Master.paraTimeFormat = cmbFormat2.Text;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(objMR_Master);
                    if (Convert.ToInt32(objd.Tables[0].Rows[0]["TimeFlag"]) == 0)
                    {
                        errVerified.SetError(mtbTime2, "Please enter valid Time");
                        mtbTime2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        errVerified.SetError(cmbFormat2, "Please enter valid Format");
                        cmbFormat2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                }
                if (error == 0)
                {
                    errVerified.Clear();
                    mtbTime2.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbFormat2_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbFormat2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbFormat2_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbFormat2.BackColor = Color.White;
                if (mtbTime2.Text != "")
                {
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 21;
                    objMR_Master.paraDate = dpVerified2.Text;
                    objMR_Master.paraTime = mtbTime2.Text;
                    objMR_Master.paraTimeFormat = cmbFormat2.Text;
                    SPDataService objDServ = new SPDataService();
                    DataSet objd = new DataSet();
                    objd = objDServ.udfnMaster(objMR_Master);
                    if (Convert.ToInt32(objd.Tables[0].Rows[0]["TimeFlag"]) == 0)
                    {
                        errVerified.SetError(mtbTime2, "Please enter valid Time");
                        mtbTime2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        errVerified.SetError(cmbFormat2, "Please enter valid Format");
                        cmbFormat2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbFormat2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void LvVerified2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnVerified2();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbFormat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtVerified2.Text!="")
                {
                    cmbFormat2.SelectedIndex = cmbFormat1.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnVerified2()
        {
            try
            {
                if (txtVerified2.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvVerified2.SelectedItems[0];
                    txtVerified2.Text = selectedItem.SubItems[0].Text;
                    lblVerified2.Text = selectedItem.SubItems[1].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvVerified2.Visible = false;
                if (dpVerified2.Enabled == true)
                { dpVerified2.Focus(); }
                else if (mtbTime2.Enabled == true)
                { mtbTime2.Focus(); }
                else if (cmbFormat2.Enabled == true)
                { cmbFormat2.Focus(); }
                else
                { btnAuthorise.Focus(); }
            }
        }

        private void LvVerified2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnVerified2();
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
                if (txtVerified1.Text != "")
                {
                    ListViewItem selectedItem = lvVerified1.SelectedItems[0];
                    txtVerified1.Text = selectedItem.SubItems[0].Text;
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
                lvVerified1.Visible = false;
                dpVerified1.Focus();
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
