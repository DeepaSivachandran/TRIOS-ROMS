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
        public string pbGRNDate = "";
        public int flag = 0, verified1 = 0, verified2 = 0; 
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
                bool blnErrorFlag = false; errVerified.Clear();
                //string CurrentTime = DateTime.Now.ToString("h:mm");
                //string[] varCurrentTime = CurrentTime.Split(':');
                //string CurrentTimeFormat = DateTime.Now.ToString("h:mm tt");
                //string[] CurrentTimeFormat1 = CurrentTimeFormat.Split(' ');
                if (Convert.ToString(txtVerified1.Text.Trim()) == "" && Convert.ToString(txtVerified2.Text.Trim())=="")
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
                    if (varTime[0].Trim()=="" || Convert.ToInt32(varTime[0]) > 12 || Hour == 1 || varTime[0].Trim()=="0" || varTime[0].Trim() == "00")
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
                    if (objd.Tables[0].Rows.Count>0)
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
                    if (lblVerified1.Text.Trim() == "" || lblVerified1.Text.Trim() == "0")
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
                    if (lblVerified2.Text.Trim() == "" || lblVerified2.Text.Trim() == "0")
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
                int V1_EMPID = 0, V2_EMPID = 0;
                V1_EMPID = Convert.ToInt32(lblVerified1.Text);
                if (Convert.ToString(txtVerified2.Text.Trim()) != "")
                {
                    V2_EMPID = Convert.ToInt32(lblVerified2.Text);
                }
                SPDataService objDser = new SPDataService();
                string result = "", Originator = "";
                if (Convert.ToString(txtVerified1.Text.Trim()) != "")
                {
                    Originator = "GRN Verifed1";
                }
                else
                {
                    Originator = "GRN Verifed2";
                }
                if(txtVerified2.Text.Trim()=="")
                {
                    mtbTime2.Text = "";
                }
                Model.TRN_GRN objTRNS_GRN = new Model.TRN_GRN();
                objTRNS_GRN.ViewType = 2;
                objTRNS_GRN.ParaGRNID = Convert.ToInt32(pbGRNId);
                objTRNS_GRN.ParaVerify1 = Convert.ToInt32(V1_EMPID);
                objTRNS_GRN.ParaVerify2 = Convert.ToInt32(V2_EMPID);
                objTRNS_GRN.ParaVerifyDate1 = dpVerified1.Text;
                objTRNS_GRN.ParaVerifyDate2 = dpVerified2.Text;
                objTRNS_GRN.paraVerifiedTime1 = mtbTime1.Text;
                objTRNS_GRN.paraVerifiedTime2 = mtbTime2.Text;
                objTRNS_GRN.paraVerifiedFormat1 = cmbFormat1.Text;
                objTRNS_GRN.paraVerifiedFormat2 = cmbFormat2.Text;
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
        private void DpVerified2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (mtbTime2.Enabled == true)
                    { mtbTime2.Focus(); }
                    else if (cmbFormat2.Enabled == true)
                    { cmbFormat2.Focus(); }
                    else
                    { btnAuthorise.Focus(); }
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
                udfnDateLoad();
                //dpVerified1.MinDate = MainForm.pbFYStartDate;
                //dpVerified1.MaxDate = MainForm.pbCurrentDate;
                //dpVerified2.MinDate = MainForm.pbFYStartDate;
                //dpVerified2.MaxDate = MainForm.pbCurrentDate;
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 24;
                objMR_Master.paraDate = pbGRNDate;
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(objMR_Master);
                if (objd.Tables[0].Rows.Count > 0)
                {
                    DateTime varminDate = DateTime.ParseExact(objd.Tables[0].Rows[0]["MinDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime varmaxDate = DateTime.ParseExact(objd.Tables[0].Rows[0]["MaxDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpVerified1.MaxDate = varmaxDate;
                    dpVerified2.MinDate = varminDate;
                    dpVerified1.MinDate = varminDate;
                    dpVerified2.MaxDate = varmaxDate;
                }
                objDServ.CloseConnection();
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
                objDs = objdserv.udfnGrnListLoad(9, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, "", "", 0, 0, "0", "","", 0, 0, 0, 0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    int Verified1 = 0,Verified2=0;
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            Verified1= Convert.ToInt32(objDs.Tables[0].Rows[0]["Verifiedby1"].ToString());
                            Verified2= Convert.ToInt32(objDs.Tables[0].Rows[0]["Verifiedby2"].ToString());
                            dpVerified1.Text = objDs.Tables[0].Rows[0]["GRN1_VerfiedOn"].ToString();
                            dpVerified2.Text = objDs.Tables[0].Rows[0]["GRN2_VerfiedOn"].ToString();
                            mtbTime1.Text = objDs.Tables[0].Rows[0]["GRN_Verified_Time1"].ToString();
                            mtbTime2.Text = objDs.Tables[0].Rows[0]["GRN_Verified_Time2"].ToString();
                            cmbFormat1.Text = objDs.Tables[0].Rows[0]["GRN_Verified_format1"].ToString();
                            cmbFormat2.Text = objDs.Tables[0].Rows[0]["GRN_Verified_format2"].ToString();
                            DateTime varmaxdate = DateTime.ParseExact(objDs.Tables[0].Rows[0]["MAXDATE"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            dpVerified1.MaxDate = varmaxdate;
                            dpVerified2.MaxDate = varmaxdate;
                            //if (Verified1 == -1)
                            //{
                            //    dpVerified1.Text = objDs.Tables[0].Rows[0]["MAXDATE"].ToString();
                            //}
                            //if (Verified2 == -1)
                            //{
                            //    dpVerified2.Text = objDs.Tables[0].Rows[0]["MAXDATE"].ToString();
                            //}
                        }
                    }
                    if (objDs.Tables[1].Rows.Count != 0)
                    {
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            lblVerified1.Text = Convert.ToString(objDs.Tables[1].Rows[0]["EMP1"].ToString());
                            txtVerified1.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Employee1"].ToString());
                            lblVerified2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["EMP2"].ToString());
                            txtVerified2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["Employee2"].ToString());
                        }
                        lvVerified1.Visible = false;
                        lvVerified2.Visible = false;
                    }
                }
                if(txtVerified1.Text.Trim()=="")
                {
                    cmbFormat1.SelectedIndex = 0;
                }
                if (txtVerified2.Text.Trim() == "")
                {
                    cmbFormat2.SelectedIndex = 0;
                }
                if(txtVerified2.Text!="")
                {
                    dpVerified2.Enabled = false;
                    mtbTime2.Enabled = false;
                    mtbTime2.ReadOnly = true;
                    cmbFormat2.Enabled = false;
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
                if(txtVerified2.Text!="")
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
                        txtVerified2.Focus();
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
                udfnVerificationValidation1();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnVerificationValidation1()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objdserv.udfnEmployeeList(12, txtVerified1.Text.Trim(), 0, "", 1, 0, 0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        { lblVerified1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["EMPID"]); }
                        else
                        {
                            lblVerified1.Text = "0";
                            errVerified.SetError(txtVerified1, "Please enter valid verification detail.");
                            txtVerified1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpVerified1.ShowAlways = true;
                            tpVerified1.Show("Please enter valid verification detail.", txtVerified1, 5000);
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
        public void udfnVerificationValidation2()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objdserv.udfnEmployeeList(12, txtVerified2.Text.Trim(), 0, "", 1, 0, 0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        { lblVerified2.Text = Convert.ToString(objDs.Tables[0].Rows[0]["EMPID"]); }
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
                    if (txtVerified2.Text == "")
                    {
                        lblVerified2.Text = "0";
                    }
                    lvVerified1.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(12, txtVerified1.Text.Trim(),Convert.ToInt32(lblVerified2.Text), "", 1, 0, 0);
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

        private void TxtVerified2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVerified2.Text.Length > 0)
                {
                    if(txtVerified1.Text=="")
                    {
                        lblVerified1.Text = "0";
                    }
                    lvVerified2.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(12, txtVerified2.Text.Trim(),Convert.ToInt32(lblVerified1.Text), "", 1, 0, 0);
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

        private void TxtVerified2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtVerified2.BackColor = Color.White;
                if (txtVerified2.Text != "")
                {
                    dpVerified2.Value = dpVerified1.Value; 
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
                    dpVerified2.Enabled = true;
                    mtbTime2.Text = "";
                    mtbTime2.Enabled = true;
                    mtbTime2.ReadOnly = false;
                    cmbFormat2.SelectedValue = "AM";
                    cmbFormat2.Enabled = true;
                }
                udfnVerificationValidation2();
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
                        btnAuthorise.Focus();
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
                    if (dpVerified2.Enabled == true)
                    { dpVerified2.Focus(); }
                    else if(mtbTime2.Enabled==true)
                    { mtbTime2.Focus(); }
                    else if(cmbFormat2.Enabled==true)
                    { cmbFormat2.Focus(); }
                    else
                    { btnAuthorise.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        private void LvVerified2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
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
        public void udfnVerified2()
        {
            try
            {
                if (txtVerified2.Text != "")
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
                    if(Convert.ToInt32(objd.Tables[0].Rows[0]["TimeFlag"])==0)
                    {
                        errVerified.SetError(mtbTime1, "Please enter valid Time");
                        mtbTime1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        errVerified.SetError(cmbFormat1, "Please enter valid Format");
                        cmbFormat1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                }
                if(txtVerified2.Text!="")
                {
                    mtbTime2.Text = mtbTime1.Text;
                    mtbTime2.Enabled = false;
                    mtbTime2.ReadOnly = true;
                }
                if (error==0)
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
                    if (cmbFormat2.Enabled == true)
                    { cmbFormat2.Focus(); }
                    else
                    { btnAuthorise.Focus(); }
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
                    if (varTime[0].Trim() == "" || Convert.ToInt32(varTime[0]) > 12 || Hour==1 || varTime[0].Trim() == "0" || varTime[0].Trim() == "00")
                    {
                        errVerified.SetError(mtbTime2, "Please enter valid hour");
                        mtbTime2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        error = 1;
                    }
                    if (varTime[1].Trim() == "" || Convert.ToInt32(varTime[1]) > 59 || Min==1 || varTime[1].Trim() == "0")
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
                if (mtbTime1.Text!="")
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
                if(e.KeyCode==Keys.Enter)
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
                    objMR_Master.paraDate = dpVerified1.Text;
                    objMR_Master.paraTime = mtbTime1.Text;
                    objMR_Master.paraTimeFormat = cmbFormat1.Text;
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

        private void CmbFormat2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
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

        private void CmbFormat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtVerified2.Text!="")
                {
                    cmbFormat2.Text = cmbFormat1.Text;
                    cmbFormat2.Enabled = false;
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
