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
    public partial class CP_Representative : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable objdatabrand = new DataTable();
        DataTable dtPaymentMode = new DataTable();
        private ToolTip tpGroupNameinTamil = new ToolTip();
        private ToolTip tpGroupNameinEnglish = new ToolTip();

        private ToolTip tpphone = new ToolTip();
        private ToolTip tpwhatsapp = new ToolTip();
        public string varupdate = "0", brandid=""; 
        public int varrepid = 0,varbrandselectflag=0,varbrandidflag=0;
        public string vargroupcode,VARBRANDLOADID = "";
        public String pbFormStatus;
        public int varCheckAllFlag = 0;
        public DataTable dtBrand = new DataTable();
        public CP_Representative()
        {
            InitializeComponent();
            MainForm.objCP_RepresentativeList.picLoader.Visible = false;
        }
        private void CP_Representative_Leave(object sender, EventArgs e)
        {
            try
            {
                tpGroupNameinTamil.Active = false;
                tpGroupNameinEnglish.Active = false;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnclose()
        {
            try
            {
                tpphone.Active = false; 
                tpwhatsapp.Active = false; 
                tpGroupNameinEnglish.Active = false; 
                tpGroupNameinTamil.Active = false; 
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                MainForm.objCP_RepresentativeList.grdreplist.ClearSelection();
            }
        }
     

        private void CP_Representative_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                { 
                        BtnSave_Click(sender, e); 
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

         
        private void CP_Representative_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MainForm.varCloseFlag == 0)
                {
                    if (varupdate == "0")
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                MainForm.objCP_RepresentativeList.grdreplist.ClearSelection();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                btnSave.Enabled = false;
                if ((Convert.ToString(txtRepName.Text).Trim() == ""))
                {
                    epGroup.SetError(txtRepName, "Please enter rep name");
                    txtRepName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinEnglish.ShowAlways = true;
                    tpGroupNameinEnglish.Show("Please enter rep name", txtRepName, 5000);
                    blnErrorFlag = true;
                }
                if (txtCompanyName.Text.Trim() == "")
                {
                    epGroup.SetError(txtCompanyName, "Please enter company name");
                    txtCompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinTamil.ShowAlways = true;
                    tpGroupNameinTamil.Show("Please enter company name", txtCompanyName, 5000);
                    blnErrorFlag = true;
                }
                //if (txtPhonenumber.Text.Trim() == "")
                //{
                //    epGroup.SetError(txtPhonenumber, "Please enter phone No.");
                //    txtPhonenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpphone.ShowAlways = true;
                //    tpphone.Show("Please enter phone No.", txtPhonenumber, 5000);
                //    blnErrorFlag = true;
                //}
                //if (txtPhonenumber.Text.Length != 10)
                //{
                //    epGroup.SetError(txtPhonenumber, "Please enter valid phone No.");
                //    txtPhonenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpphone.ShowAlways = true;
                //    tpphone.Show("Please enter valid phone No.", txtPhonenumber, 5000);
                //    blnErrorFlag = true;
                //}
                //if (txtWhatsappno.Text.Trim() == "")
                //{
                //    epGroup.SetError(txtWhatsappno, "Please enter whatsapp No.");
                //    txtWhatsappno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpwhatsapp.ShowAlways = true;
                //    tpwhatsapp.Show("Please enter phone No.", txtWhatsappno, 5000);
                //    blnErrorFlag = true;
                //}
                //if (txtWhatsappno.Text.Length != 10)
                //{
                //    epGroup.SetError(txtWhatsappno, "Please enter valid whatsapp No.");
                //    txtWhatsappno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpwhatsapp.ShowAlways = true;
                //    tpwhatsapp.Show("Please enter valid whatsapp No.", txtWhatsappno, 5000);
                //    blnErrorFlag = true;
                //}

                if (blnErrorFlag == false)
                {
                    tpphone.Active = false; 
                    tpwhatsapp.Active = false; 
                    tpGroupNameinEnglish.Active = false; 
                    tpGroupNameinTamil.Active = false; 
                    udfnSave(sender, e);
                }
                else
                {
                    btnSave.Enabled = true;
                    btnSave.Focus();
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

            finally
            { 
                grdRepBrand.ClearSelection();
            }
        }
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                string result = "";
                int varStatus = 0;
                epGroup.Clear();
                udfntextboxcolor();                 
                if (rbActive.Checked == true)
                {
                    varStatus = 1;
                }
                else
                {
                    varStatus =2;
                }
                string Varbrandid = ""; 
                for (int i = 0; i < grdRepBrand.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdRepBrand.Rows[i].Cells[0].Value) == true)
                    {
                        if (Varbrandid == "")
                        {
                            Varbrandid = Convert.ToString(grdRepBrand.Rows[i].Cells["ID"].Value);
                        }
                        else
                        {
                            Varbrandid = Varbrandid + ',' + Convert.ToString(grdRepBrand.Rows[i].Cells["ID"].Value);
                        }
                    }

                }
                if (Varbrandid != "")
                {
                    if (btnSave.Text == "Save")
                    {
                        result = objspdservice.udfnRepMaster(0, 0, Convert.ToString(txtRepName.Text).Trim(), txtCompanyName.Text, txtPhonenumber.Text, txtWhatsappno.Text, Varbrandid, varStatus, "representative Create", MainForm.pbUserID);
                    }
                    else
                    {
                        result = objspdservice.udfnRepMaster(1, Convert.ToInt32(varrepid), Convert.ToString(txtRepName.Text).Trim(), txtCompanyName.Text, txtPhonenumber.Text, txtWhatsappno.Text, Varbrandid, varStatus, "representative Create",MainForm.pbUserID);
                    }
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm.objCP_RepresentativeList.udfnlist();
                        objspdservice.CloseConnection();
                        txtCompanyName.Focus();
                        if (btnSave.Text == "Update")
                        {
                            varupdate = "1";
                            udfnclose();
                        }
                        udfnClear();
                    }
                    else
                    { MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(61);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                txtCompanyName.Focus();
            }

            finally
            {
                btnSave.Enabled = true;
                grdRepBrand.ClearSelection();
            }
        }

        public void udfntextboxcolor()
        {
            try
            { 
                txtRepName.BackColor = Color.White;
                txtPhonenumber.BackColor = Color.White;
                txtWhatsappno.BackColor = Color.White;
                txtCompanyName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
        objError.WriteFile(ex);
            }
        }

        public void udfnClear()
        {
            try
            {
                txtRepName.Text = "";
                txtPhonenumber.Text = "";
                txtWhatsappno.Text = "";
                txtCompanyName.Text = "";
                foreach (DataGridViewRow row in grdRepBrand.Rows)
                {
                    row.Cells[0].Value = false;
                }
                grdRepBrand.DataSource = null;
                udfnlist();
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

        private void BtnClose_Click(object sender, EventArgs e)
        {

            try
            {
                udfnclose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClose_Enter(object sender, EventArgs e)
        {

            try
            {
                btnClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Representative_Load(object sender, EventArgs e)
        {
            try
            {
                dtBrand = new DataTable();
                dtBrand.Columns.Add("", typeof(Boolean));
                dtBrand.Columns.Add("ID", typeof(int));
                dtBrand.Columns.Add("Brand Name", typeof(string));
                dtBrand.Columns.Add("Group", typeof(string));
                dtBrand.Columns.Add("Sub Group", typeof(string));
                udfnEditload();
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;

                }
                else
                {
                    pnlStatus.Enabled = true;
                } 
                udfnlist();
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
                if (varrepid != 0)
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objspservice.udfnRepMasterList(1, Convert.ToInt32(varrepid), MainForm.pbUserID, MainForm.pbIpAddress,0);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtCompanyName.Text = objDS.Tables[0].Rows[0]["Company Name"].ToString().Replace("''", "'");
                            txtRepName.Text = objDS.Tables[0].Rows[0]["Representative name"].ToString().Replace("''", "'");
                            txtPhonenumber.Text = objDS.Tables[0].Rows[0]["Phone No."].ToString().Replace("''", "'");
                            txtWhatsappno.Text = objDS.Tables[0].Rows[0]["WhatsApp No."].ToString().Replace("''", "'"); 
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "1") { rbActive.Checked = true; } else { rbInActive.Checked = true; }

                            btnSave.Text = "Update";  
                        }
                        if (objDS.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                            {
                                if (Convert.ToString(objDS.Tables[1].Rows[i]["ID"]) == "0" || Convert.ToString(objDS.Tables[1].Rows[i]["ID"]) == "-1")
                                {
                                    objDS.Tables[1].Rows[i].Delete();
                                    objDS.Tables[1].AcceptChanges();
                                }
                            }
                            objdatabrand = objDS.Tables[1]; 
                        } 


                    } 
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {

            }
        }
            public void udfnlist()
            {
            try
            {
                int varviewtype = 0, varloadrepid = 0; string varbrandid = "";
                if (btnSave.Text == "Update")
                {
                    varbrandid = Convert.ToString(VARBRANDLOADID);
                    varviewtype = 13;
                    varloadrepid = Convert.ToInt32(varrepid);
                }
                else
                {
                    varviewtype = 12;
                }

                SPDataService objspservice = new SPDataService();
                DataSet objDS;
                objDS = objspservice.udfnBrandList(varviewtype, varbrandid, 0, 0, varloadrepid,"",0);
                objspservice.CloseConnection();
                if (objDS != null)
                {
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDS.Tables[0].Rows.Count; i++) {
                            if (Convert.ToString(objDS.Tables[0].Rows[i]["ID"]) == "0" || Convert.ToString(objDS.Tables[0].Rows[i]["ID"]) == "-1") {
                                objDS.Tables[0].Rows[i].Delete();
                                objDS.Tables[0].AcceptChanges();
                            }
                            dtBrand.Rows.Add(false, Convert.ToInt32(objDS.Tables[0].Rows[i]["ID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Brand Name"]), Convert.ToString(objDS.Tables[0].Rows[i]["Group"]), Convert.ToString(objDS.Tables[0].Rows[i]["Sub Group"]));
                        }
                       // dtBrand = objDS.Tables[0];
                        grdRepBrand.DataSource = dtBrand;
                        grdRepBrand.Columns["Column1"].HeaderText = "";
                        grdRepBrand.Columns[0].Width = 30;
                        grdRepBrand.Columns["ID"].Visible = false;
                        grdRepBrand.Columns["Brand Name"].Width = 150;
                        grdRepBrand.Columns["Sub Group"].Width = 250;
                        grdRepBrand.Columns["Group"].Width = 250;
                        grdRepBrand.Columns["Brand Name"].ReadOnly = true;
                        grdRepBrand.Columns["Sub Group"].ReadOnly = true;
                        grdRepBrand.Columns["Group"].ReadOnly = true;
                        //grdRepBrand.Columns["sno"].Visible = false;
                        //grdRepBrand.Columns["BD_STSID"].Visible = false;
                        //foreach (DataGridViewRow row in grdRepBrand.Rows)
                        //{
                        //    if (row.Cells["ID"].Value.ToString() == "0" || row.Cells["ID"].Value.ToString() == "-1")
                        //    {
                        //        row.Clear();
                        //    }
                        //}
                        //int currentRowIndex = grdRepBrand.CurrentCell?.RowIndex ?? -1;

                        //foreach (DataGridViewRow row in grdRepBrand.Rows)
                        //{
                        //    if (row.Cells["ID"].Value.ToString() == "0" || row.Cells["ID"].Value.ToString() == "-1")
                        //    {
                        //        if (row.Index == currentRowIndex)
                        //        {
                        //            if (row.Index == grdRepBrand.Rows.Count - 1 && grdRepBrand.Rows.Count > 1) // If it's the last row and there are other rows
                        //            {
                        //                grdRepBrand.Rows.RemoveAt(row.Index);
                        //            }
                        //            else if (row.Index < grdRepBrand.Rows.Count - 1) // If there are rows below
                        //            {
                        //                grdRepBrand.Rows.RemoveAt(row.Index);
                        //            }
                        //            else // If it's the only row
                        //            {
                        //                grdRepBrand.CurrentCell = null;
                        //            }
                        //        }

                        //        row.Visible = false;
                        //    }
                        //} 

                        if (btnSave.Text == "Update")
                        {
                            for (int i = 0; i < dtBrand.Rows.Count; i++)
                            {
                                for (int k = 0; k < objdatabrand.Rows.Count; k++)
                                {
                                    if (Convert.ToInt32(dtBrand.Rows[i]["ID"]) == Convert.ToInt32(dtBrand .Rows[k]["ID"]))
                                    {
                                        dtBrand.Rows[i][0] = true;
                                    }
                                }
                            }
                            grdRepBrand.DataSource = dtBrand;
                            grdRepBrand.Columns["Column1"].HeaderText = "";
                            grdRepBrand.Columns[0].Width = 30;
                            grdRepBrand.Columns["ID"].Visible = false;
                            grdRepBrand.Columns["Brand Name"].Width = 150;
                            grdRepBrand.Columns["Sub Group"].Width = 250;
                            grdRepBrand.Columns["Group"].Width = 250;
                            grdRepBrand.Columns["Brand Name"].ReadOnly = true;
                            grdRepBrand.Columns["Sub Group"].ReadOnly = true;
                            grdRepBrand.Columns["Group"].ReadOnly = true;
                            if (grdRepBrand.RowCount == objdatabrand.Rows.Count)
                            {
                                varCheckAllFlag = 1;
                                chkBrandAll.Checked = true;
                            }
                            else { varCheckAllFlag = 0; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdRepBrand.ClearSelection();
                //this.grdRepBrand.Sort(this.grdRepBrand.Columns[0], ListSortDirection.Descending); 
            }
        }

        private void RbActive_Enter(object sender, EventArgs e)
        {

            try
            {
                rbActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_Leave(object sender, EventArgs e)
        {

            try
            {
                rbActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCompanyName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCompanyName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //if (pnlStatus.Enabled)
                    //{
                    //    rbActive.Focus();
                    //}
                    //else { btnSave.Focus(); }
                    txtRepName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCompanyName_Leave(object sender, EventArgs e)
        {  
            try
            {
                if (txtCompanyName.Text.Trim() == "")
                {
                    epGroup.SetError(txtCompanyName, "Please enter company name");
                    txtCompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinEnglish.ShowAlways = true;
                    tpGroupNameinEnglish.Show("Please enter company name", txtCompanyName, 5000);
                }
                else
                {
                    epGroup.Clear();
                    txtCompanyName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRepName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRepName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRepName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPhonenumber.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRepName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRepName.Text.Trim() == "")
                {
                    epGroup.SetError(txtRepName, "Please enter rep name");
                    txtRepName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinEnglish.ShowAlways = true;
                    tpGroupNameinEnglish.Show("Please enter rep name", txtRepName, 5000);
                }
                else
                {
                    epGroup.Clear();
                    txtRepName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPhonenumber_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPhonenumber.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPhonenumber_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWhatsappno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtPhonenumber_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtPhonenumber.Text.Trim() != "") 
                {
                    if (txtPhonenumber.Text.Length < 10)
                    {
                        epGroup.SetError(txtPhonenumber, "Please enter valid rep phone No.");
                        txtPhonenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpGroupNameinEnglish.ShowAlways = true;
                        tpGroupNameinEnglish.Show("Please enter valid rep phone No.", txtPhonenumber, 5000);
                    }
                    else
                    {
                        epGroup.Clear();
                        txtPhonenumber.BackColor = Color.White;
                    }
                }

               //else if (txtPhonenumber.Text.Trim() == "")
               // {
               //     epGroup.SetError(txtPhonenumber, "Please enter rep phone No.");
               //     txtPhonenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
               //     tpGroupNameinEnglish.ShowAlways = true;
               //     tpGroupNameinEnglish.Show("Please enter rep phone No.", txtPhonenumber, 5000);
               // }
               // else
               // {
               //     epGroup.Clear();
               //     txtPhonenumber.BackColor = Color.White;
               // }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWhatsappno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtWhatsappno.Text.Trim() != "")
                {
                    if (txtWhatsappno.Text.Length < 10)
                    {
                        epGroup.SetError(txtWhatsappno, "Please enter valid rep whatsapp No.");
                        txtWhatsappno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpGroupNameinEnglish.ShowAlways = true;
                        tpGroupNameinEnglish.Show("Please enter valid rep whatsapp No.", txtWhatsappno, 5000);
                    }
                    else
                    {
                        epGroup.Clear();
                        txtWhatsappno.BackColor = Color.White;
                    }
                }
                //else if (txtWhatsappno.Text.Trim() == "")
                //{
                //    epGroup.SetError(txtWhatsappno, "Please enter rep whatsapp No.");
                //    txtWhatsappno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpGroupNameinEnglish.ShowAlways = true;
                //    tpGroupNameinEnglish.Show("Please enter rep whatsapp No.", txtWhatsappno, 5000);
                //}
                //else
                //{
                //    epGroup.Clear();
                //    txtWhatsappno.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtWhatsappno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtWhatsappno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWhatsappno_KeyDown(object sender, KeyEventArgs e)
        { 
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled)
                    {
                        rbActive.Focus();
                    }
                    else { btnSave.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRepBrand_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdRepBrand.IsCurrentCellDirty)
                {
                    grdRepBrand.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
             catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPhonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void GrdRepBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.ColumnIndex == 0)
                {
                    checkallcheckboxvalue();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRepBrand_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            try
            {
                grdRepBrand.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdRepBrand.ClearSelection();
            }
        }

        private void TxtWhatsappno_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        private void checkallcheckboxvalue()
        {
            //try
            //{
            //    bool varallChecked = true; 
            //        for (int i = 0; i < grdRepBrand.Rows.Count; i++)
            //        {
            //            if (Convert.ToBoolean(grdRepBrand.Rows[i].Cells[0].EditedFormattedValue) == false)
            //            {
            //                varallChecked = false; 
            //            }
            //            varbrandidflag++;
            //        } 
            //    //if (varbrandselectflag == 0)
            //    //{
            //        chkBrandAll.Checked = varallChecked;
            //  //  }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            //finally
            //{
            //    varbrandselectflag = 0;
            //}
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdRepBrand.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdRepBrand.Rows[i].Cells[0].FormattedValue) == true)
                    {
                        varCheckedCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (grdRepBrand.Rows.Count == varCheckedCount)
                {
                    varCheckAllFlag = 1;
                    chkBrandAll.Checked = true;
                }
                else
                {
                    varCheckAllFlag = 1;
                    chkBrandAll.Checked = false;
                }
            }

        }

        private void ChkBrandAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (varCheckAllFlag != 1)
                {
                    for (int i = 0; i < grdRepBrand.Rows.Count; i++)
                    {
                        grdRepBrand.Rows[i].Cells[0].Value = chkBrandAll.Checked;
                    }
                }
                else
                {
                    varCheckAllFlag = 0;
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
