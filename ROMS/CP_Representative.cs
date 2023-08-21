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
        private ToolTip tpGroupNameinTamil = new ToolTip();
        private ToolTip tpGroupNameinEnglish = new ToolTip();
        public string varupdate = "0", brandid=""; 
        public int varrepid = 0;
        public string vargroupcode;
        public String pbFormStatus;
        public CP_Representative()
        {
            InitializeComponent();
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
                    this.Close(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                bool blnErrorFlag = false;
                if (txtRepName.Text.Trim() == "")
                {
                    epGroup.SetError(txtRepName, "Please enter product rep name");
                    txtRepName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinEnglish.ShowAlways = true;
                    tpGroupNameinEnglish.Show("Please enter product rep name", txtRepName, 5000);
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
                if (txtPhonenumber.Text.Trim() == "")
                {
                    epGroup.SetError(txtPhonenumber, "Please enter phone No.");
                    txtPhonenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinTamil.ShowAlways = true;
                    tpGroupNameinTamil.Show("Please enter phone No.", txtPhonenumber, 5000);
                    blnErrorFlag = true;
                }
                if (txtWhatsappno.Text.Trim() == "")
                {
                    epGroup.SetError(txtWhatsappno, "Please enter whatsapp No.");
                    txtWhatsappno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinTamil.ShowAlways = true;
                    tpGroupNameinTamil.Show("Please enter phone No.", txtWhatsappno, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    udfnSave(sender, e);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                    if (Convert.ToBoolean(grdRepBrand.Rows[i].Cells["clmcheckbrand"].Value) == true)
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


                if (btnSave.Text == "Save")
                    {
                    result = objspdservice.udfnRepMaster(0,0,txtRepName.Text,txtCompanyName.Text,txtPhonenumber.Text,txtWhatsappno.Text,Varbrandid,varStatus, "representative Create");
                    }
                    else
                    {
                    result = objspdservice.udfnRepMaster(1, Convert.ToInt32(varrepid), txtRepName.Text, txtCompanyName.Text, txtPhonenumber.Text, txtWhatsappno.Text, Varbrandid, varStatus, "representative Create");

                    }
                string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MainForm.objCP_RepresentativeList.udfnlist(); 
                    txtCompanyName.Focus();
                        if (btnSave.Text == "Update")
                        {
                            varupdate = "1";
                            udfnclose();
                        }

                    udfnClear();
                }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } 
               

                objspdservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                    objDS = objspservice.udfnRepMasterList(1, Convert.ToInt32(varrepid), MainForm.pbUserID, MainForm.pbIpAddress);
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
                            objdatabrand= objDS.Tables[1]; 
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
                DataSet objdataset = new DataSet();
                DataService objdservice = new DataService();
                objdataset = objdservice.GetDataset("select BDID AS ID, BD_EName AS[Brand Name] from MR_Brand WHERE BDID NOT IN(-1, 0) AND BD_STSID = 1");
                objdservice.CloseConnection();
                if (objdataset != null)
                {
                    if (objdataset.Tables.Count != 0)
                    {
                        if (objdataset.Tables[0].Rows.Count != 0)
                        {
                            grdRepBrand.DataSource = objdataset.Tables[0];
                            grdRepBrand.Columns["ID"].Visible = false;
                            grdRepBrand.Columns["Brand Name"].Width = 230;

                            if (btnSave.Text=="Update")
                            { 
                                for (int i = 0; i < grdRepBrand.Rows.Count; i++)
                                {
                                    for (int k = 0; k < objdatabrand.Rows.Count; k++)
                                    { 
                                        if (Convert.ToInt32(grdRepBrand.Rows[i].Cells["ID"].Value) == Convert.ToInt32(objdatabrand.Rows[k]["ID"]))
                                        {
                                            grdRepBrand.Rows[i].Cells["clmcheckbrand"].Value = true;
                                             
                                        }
                                    }
                                }
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

               else if (txtPhonenumber.Text.Trim() == "")
                {
                    epGroup.SetError(txtPhonenumber, "Please enter rep phone No.");
                    txtPhonenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinEnglish.ShowAlways = true;
                    tpGroupNameinEnglish.Show("Please enter rep phone No.", txtPhonenumber, 5000);
                }
                else
                {
                    epGroup.Clear();
                    txtPhonenumber.BackColor = Color.White;
                }
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
                else if (txtWhatsappno.Text.Trim() == "")
                {
                    epGroup.SetError(txtWhatsappno, "Please enter rep whatsapp No.");
                    txtWhatsappno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGroupNameinEnglish.ShowAlways = true;
                    tpGroupNameinEnglish.Show("Please enter rep whatsapp No.", txtWhatsappno, 5000);
                }
                else
                {
                    epGroup.Clear();
                    txtWhatsappno.BackColor = Color.White;
                }
                 

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

        private void ChkBrandAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdRepBrand.Rows.Count; i++)
                {
                    grdRepBrand.Rows[i].Cells["clmcheckbrand"].Value = chkBrandAll.Checked;
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
