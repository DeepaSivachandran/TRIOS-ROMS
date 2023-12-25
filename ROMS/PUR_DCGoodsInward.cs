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

    public partial class PUR_DCGoodsInward : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpMRP = new ToolTip();
        private ToolTip tpMonth = new ToolTip();
        private ToolTip tpDate = new ToolTip();
        private ToolTip tpYear = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpQty = new ToolTip();
        DataTable dtPurchaseDC = new DataTable();

        public bool VarSearchFlag = true;
        public int expirydateFlag = 0, pbDateflag=0, varShelflife=0;
        public string varBatchNo = "0";
        public string varBatchNoGeneration = "0", varPrcategory = "0", varRMProduction = "0", varExpiryDate = "";

        public PUR_DCGoodsInward()
        {
            InitializeComponent();
        }

        
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        errLocation.Clear();

        //        if (txtLocationName.Text.Trim() == "")
        //        {
        //            errLocation.SetError(txtLocationName, "Please enter location name ");
        //            txtLocationName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
        //            tplocationname.ShowAlways = true;
        //            tplocationname.Show("Please enter location name", txtLocationName, 5000);
        //            txtLocationName.Text = "";
        //        }
        //        if (txtLocationName.Text.Trim() == "")
        //        {
        //            txtLocationName.Focus();
        //            return;
        //        }
        //        SPDataService objspdservice = new SPDataService();

        //        string result = "";
        //        if (btnSave.Text == "Save")
        //        {
        //          //  result = objspdservice.udfnSPLocationMaster("Create", "0",txtLocationName.Text,cmbSlNo.SelectedValue.ToString() , MainForm.pbUserID, MainForm.pbIpAddress, "Location Create");

        //        }
        //        else
        //        {
        //          //  result = objspdservice.udfnSPLocationMaster("Update", varlocationcode, txtLocationName.Text, cmbSlNo.SelectedValue.ToString(), MainForm.pbUserID, MainForm.pbIpAddress, "Location Update");
        //        }
        //        string[] varvalue = result.Split('~');
        //        if (varvalue[0] == "3")
        //        {
        //            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            if (btnSave.Text == "Update")
        //            {
        //                this.Close();
        //            }
        //            else
        //            {
        //                udfnclear();
        //            }

        //            MainForm.objPUR_DCGoodsInwardList.udfnList();
        //        }
        //        else
        //        {
        //            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            if (varvalue[1].Contains("Order number")) {// udfnSINO();
        //            }
        //        }
        //        objspdservice.CloseConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}


        private void udfnclear()
        {


            //try
            //{
            //    txtLocationName.Text = "";
            //    btnSave.Text = "Save";
            //    txtLocationName.Focus();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}

        }

        private void btnSave_Enter(object sender, EventArgs e)
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

        private void btnSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
              //  MainForm.objPUR_DCGoodsInwardList.udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Enter(object sender, EventArgs e)
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

      
        private void btnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PUR_DCGoodsInward_Load(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void udfnEdit()
        {
            //try
            //{
            //    if (varlocationcode != "")
            //    {
            //        SPDataService objspservice = new SPDataService();
            //        DataSet objDS = new DataSet();
            //      //  objDS = objspservice.udfnSPLocationList("EditLoad", varlocationcode, MainForm.pbUserID, MainForm.pbIpAddress);
            //        objspservice.CloseConnection();
            //        if (objDS != null)
            //        {
            //            if (objDS.Tables[0].Rows.Count > 0)
            //            {
            //                txtLocationName.Text = objDS.Tables[0].Rows[0]["LocationName"].ToString().Replace("''", "'");
            //             //   cmbSlNo.SelectedValue = objDS.Tables[0].Rows[0]["SINO"].ToString();                          
            //                btnSave.Text = "Update";
            //            }
            //        }
            //        if (varlocationcode == "1") { btnSave.Visible = false; } else { btnSave.Visible = true; }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            //finally
            //{

            //}
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
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
        }
        private void PUR_DCGoodsInward_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbLocation_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //grbLocation.BringToFront();
                //grbrack.SendToBack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rbrack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               // grbrack.BringToFront();
                //grbLocation.SendToBack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rboutside_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //rbActive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_KeyDown(object sender, KeyEventArgs e)
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

        private void RbInactive_KeyDown(object sender, KeyEventArgs e)
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


        private void PUR_DCGoodsInward_Leave(object sender, EventArgs e)
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

        private void PUR_DCGoodsInward_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductName_Enter(object sender, EventArgs e)
        {
            try
            { 
                 txtProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductName.Text.Trim() == "")
                {
                    epProductExchange.SetError(txtProductName, "Please enter product.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                }
                else
                {
                    epProductExchange.Clear();
                    txtProductName.BackColor = Color.White;
                    tpProduct.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMrp.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvproduct.Items.Count == 0 || txtProductName.Text == "")
                    {
                        txtProductName.Focus();
                        lvproduct.Visible = false;
                    }
                    else
                    {
                        lvproduct.Focus();
                    }
                    if (lvproduct.Items.Count > 0)
                    {
                        lvproduct.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMrp_Enter(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Visible = false;
                txtMrp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMrp.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDay.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
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
        private void TxtDay_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
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
        private void TxtDay_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDay.Text.Length == 2)
                {
                    txtMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMonth.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtYear.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
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
        private void TxtMonth_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epProductExchange.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if (txtMonth.Text != "")
                {
                    if (Convert.ToInt32(txtMonth.Text.Trim()) > 12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epProductExchange.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMonth.Text.Length == 2)
                {
                    txtYear.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_Enter(object sender, EventArgs e)
        {
            try
            {
                txtYear.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtBatchNo.Enabled == true)
                    {
                        txtBatchNo.Focus();
                    }
                    else
                    {
                        txtActualQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epProductExchange.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Trim() == "00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epProductExchange.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text.Length == 2)
                {
                    if (txtBatchNo.Enabled == false)
                    { txtActualQty.Focus(); }
                    else
                    {
                        txtBatchNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtActualQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtActualQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtActualQty.Text.Trim() == "")
                {
                    txtActualQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductExchange.SetError(txtActualQty, "Please enter quantity.");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter quantity.", txtActualQty, 5000);
                }
                else
                {
                    txtActualQty.BackColor = Color.White;
                    epProductExchange.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
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
        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Visible = false;
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnExpiryDate()
        {
            try
            {
                string varDay = "", varMonth = "", varYear = "", varDate = ""; string varDcDay = "", varDcMonth = "", varDcYear = "", varExpiry = "";
                int varExpiryDays = 0; int error = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (txtDay.Text.Trim() == "")
                {
                    varDay = "01";
                }
                else
                {
                    if (Convert.ToInt64(txtDay.Text) > 31 || Convert.ToInt64(txtDay.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(95);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtDay.Text.Length == 1)
                        { txtDay.Text = 0 + txtDay.Text.Trim(); }
                        varDay = txtDay.Text.Trim();
                    }
                }
                if (txtMonth.Text.Trim() != "")
                {
                    if (Convert.ToInt64(txtMonth.Text) > 12 || Convert.ToInt64(txtMonth.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(90);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtMonth.Text.Length == 1)
                        { txtMonth.Text = 0 + txtMonth.Text.Trim(); }
                    }
                }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Length < 2)
                    {
                        pbDateflag = 1;
                        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(92);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (pbDateflag == 0)
                {
                    varMonth = Convert.ToString(txtMonth.Text.Trim());
                    varYear = 20 + Convert.ToString(txtYear.Text.Trim());
                    if (txtDay.Text.Trim() == "")
                    {
                        varDate = varDay + "/" + varMonth + "/" + varYear;
                        objDS = objDServ.udfnMaster(5, 0, 0, varDate, "", 0, "", 0);
                        objDServ.CloseConnection();
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varExpiryDate = objDS.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();
                        }
                    }
                    else
                    {
                        varExpiryDate = varDay + "/" + varMonth + "/" + varYear;
                    }
                    objDS = objDServ.udfnMaster(10, 0, 0, "", varExpiryDate, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0);
                    objDServ.CloseConnection();
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        if (objDS.Tables[0].Rows[0]["Date"].ToString() == "0")
                        {
                            pbDateflag = 1; error = 1;
                        }
                        else
                        {
                            if (objDS.Tables.Count != 0)
                            {
                                if (objDS.Tables[1].Rows.Count > 0)
                                {
                                    varExpiryDays = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                }
                            }
                            if (varExpiryDays < 0)
                            {
                                pbDateflag = 1; error = 1;
                            }
                            else
                            {
                                if (varShelflife == 1)
                                {
                                    if (objDS.Tables.Count > 1)
                                    {
                                        if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                        {
                                            pbDateflag = 1;
                                            txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            string varMessage = objDServ.udfnGetMessages(98);
                                            objDServ.CloseConnection();
                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        pbDateflag = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                if (error == 1)
                {
                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    string varMessage = objDServ.udfnGetMessages(94);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUddtTable()
        {
            dtPurchaseDC.TableName = "TRN_ReturnDc_ExchangeProducts";
            //objPurchaseDC.Columns.Add("PR_PICode", typeof(string));
            // objPurchaseDC.Columns.Add("PR_EName", typeof(string));
            //objPurchaseDC.Columns.Add("DCPR_DCID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_PRID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_MRP", typeof(decimal));
            dtPurchaseDC.Columns.Add("DCPR_ExpiryDate", typeof(string));
            dtPurchaseDC.Columns.Add("DCPR_BatchNo", typeof(string));
            dtPurchaseDC.Columns.Add("DCPR_Qty", typeof(decimal));
            dtPurchaseDC.Columns.Add("DCPR_UTID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_SLID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_RKID", typeof(int));
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false; pbDateflag = 0;
                if (Convert.ToString(txtProductName.Text).Trim() == "")
                {
                    epProductExchange.SetError(txtProductName, "Please enter product.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    blnErrorFlag = true;
                }
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtMonth, "Please enter month.");
                        blnErrorFlag = true;
                    }
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtYear, "Please enter year.");
                        blnErrorFlag = true;
                    }
                }
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchNo.Text.Trim() == "")
                    {
                        txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtBatchNo, "Please enter BatchNo.");
                        tpBatchNo.ShowAlways = true;
                        tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (txtActualQty.Text.Trim() == "")
                {
                    txtActualQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductExchange.SetError(txtActualQty, "Please enter quantity.");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter quantity.", txtActualQty, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtProductName.Text) != "")
                {
                    string varproductID = "0";
                    DataSet objDsproductId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    //objDsproductId = objDserv.udfnproductmasterlist(39, 0, 0, 0, 0, "", "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, txtProductName.Text, Convert.ToInt32(lblSupplierCode.Text), "", "", null, 0, null, "", "");
                    objDserv.CloseConnection();
                    if (objDsproductId != null)
                    {
                        if (objDsproductId.Tables.Count > 0)
                        {
                            if (objDsproductId.Tables[0].Rows.Count > 0)
                            {
                                varproductID = Convert.ToString(objDsproductId.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (varproductID == "-1")
                    {
                        lblProductcode.Text = "0";
                        SPDataService objDser = new SPDataService();
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDser.udfnGetMessages(91);
                        objDser.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        lblProductcode.Text = varproductID;
                        epProductExchange.Clear();
                        txtProductName.BackColor = Color.White;
                    }
                }
                if (Convert.ToString(txtProductName.Text.Trim()) != "")
                {
                    if (expirydateFlag == 1 || txtDay.Text != "" || txtMonth.Text != "" || txtYear.Text != "")
                    {
                        udfnExpiryDate();
                    }
                    SPDataService objDServ = new SPDataService();
                    DataSet objDS = new DataSet();
                    DataSet objDSExpiry = new DataSet();
                    int flag = 0;
                }
                if (blnErrorFlag == false && pbDateflag == 0)
                {
                    udfnAdd();
                }
                //varDiscardFlag = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtProductName.Text != "" || txtProductName.Text == "")
                {
                    //udfnAddClear();
                    //udfnTooltipHide();
                    //txtStockLocation.Text = "";
                    //lblStockLocationCode.Text = "0";
                    //lvStockLocation.Visible = false;
                }
                string varProductsCodes = "0";
                lvproduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductName.Text.Length > 0)
                {
                    if (VarSearchFlag == true)
                    {
                        objDs = objspdservice.udfnproductmasterlist(29, 0, 0, 0, 0, txtProductName.Text, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, varProductsCodes, "", null, 0, null, "", "");
                    }
                    else
                    {
                        objDs = objspdservice.udfnproductmasterlist(29, 0, 0, 0, 0, "", "", "", 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, txtProductName.Text,0, varProductsCodes, "", null, 0, null, "", "");
                    }
                    // lvproduct.BeginUpdate();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(),objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(),
                                        objDs.Tables[0].Rows[i]["PR_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["PR_BatchNoGeneration"].ToString(),objDs.Tables[0].Rows[i]["PR_RMForProduction"].ToString(),objDs.Tables[0].Rows[i]["PR_PRCTID"].ToString(),objDs.Tables[0].Rows[i]["PR_ShelfLife"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.Columns[0].Width = 130;
                                lvproduct.Columns[1].Width = 500;
                                lvproduct.Columns[2].Width = 50;
                            }
                        }
                    }
                }
                else
                {
                    lvproduct.Visible = false;
                    lvproduct.Items.Clear();
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

        private void Lvproduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListviewProduct();
                txtMrp.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    varBatchNo = "0"; varBatchNoGeneration = "0"; varShelflife = 0; expirydateFlag = 0;
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[3].Text;
                    lblProductcode.Text = selectedItem.SubItems[4].Text;
                    varBatchNo = selectedItem.SubItems[5].Text;
                    varBatchNoGeneration = selectedItem.SubItems[6].Text;
                    varRMProduction = selectedItem.SubItems[7].Text;
                    varPrcategory = selectedItem.SubItems[8].Text;
                    varShelflife = Convert.ToInt32(selectedItem.SubItems[9].Text);
                    if (varShelflife == 1)
                    { expirydateFlag = 1; }
                    if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                    {
                        txtBatchNo.Text = "";
                        txtBatchNo.Enabled = false;
                        //  txtBatchNo.ReadOnly = true;
                    }
                    else if (Convert.ToInt32(varBatchNo) == 72) //enabled
                    {
                        if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                        {
                            txtBatchNo.Enabled = true;
                            //txtBatchNo.ReadOnly = false;
                        }
                        else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(14, 0, 0, "", "", 0, "", 0);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtBatchNo.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                    txtBatchNo.Enabled = false;
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(varPrcategory) == 16)
                    {
                        if (Convert.ToInt32(varRMProduction) == 1)
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            //objDs = objspdservice.udfnMaster(15, 0, 0, dpDCDate.Text, "", Convert.ToInt32(lblProductcode.Text), "", 0);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtDay.Text = objDs.Tables[0].Rows[0][0].ToString();
                                    txtMonth.Text = objDs.Tables[0].Rows[1][0].ToString();
                                    txtYear.Text = objDs.Tables[0].Rows[2][0].ToString();
                                }
                            }
                        }
                    }
                }

                txtMrp.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvproduct.Visible = false;
            }
        }
        private void Lvproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListviewProduct();
                    txtMrp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnAdd()
        {
            try
            {
                if (txtActualQty.Text.Trim() == "0")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(77);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    udfnExpiryDate();
                    if (pbDateflag == 0)
                    {
                        if (txtMrp.Text == "")
                        { txtMrp.Text = "0"; }
                        decimal varMRP = Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                        string mrp = string.Format("{0:0.00}", varMRP);
                        string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                        //grdProductExchage.Rows.Add(grdProductExchage.Rows.Count + 1, Convert.ToDecimal(mrp), varExpiryDate, txtBatchNo.Text.Trim(), txtActualQty.Text.Trim(), lblUnit.Text, txtStockLocation.Text.Trim(), txtRack.Text.Trim(), addproductid, lblStockLocationCode.Text, lblRackCode.Text, varunitid);
                        //dtPurchaseDC.Rows.Add(Convert.ToInt32(addproductid), Convert.ToDecimal(mrp1), varExpiryDate, txtBatchNo.Text.Trim(), Convert.ToDecimal(txtActualQty.Text.Trim()), Convert.ToInt32(varunitid), Convert.ToInt32(lblStockLocationCode.Text), Convert.ToInt32(lblRackCode.Text));
                        //((DataGridViewTextBoxColumn)grdPurchaseDC.Columns["clmQuantity"]).MaxInputLength = 8;
                        //grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.BackColor = Color.PaleGreen;
                        ////grdPurchaseDC.Columns["clmQuantity"].ReadOnly = false;
                        //grdPurchaseDC.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //grdPurchaseDC.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        //grdPurchaseDC.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //grdPurchaseDC.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                       // udfnAddClear();
                        txtProductName.Text = "";
                        lblProductcode.Text = "0";
                        //  txtProductName.BackColor = Color.White;
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
                grdProductExchage.ClearSelection();
            }
        }
        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnAdd_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchNo.Text.Trim() == "")
                    {
                        txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtBatchNo, "Please enter BatchNo.");
                        tpBatchNo.ShowAlways = true;
                        tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                    }
                    else
                    {
                        txtBatchNo.BackColor = Color.White;
                        epProductExchange.Clear();
                    }
                }
                else
                {
                    txtBatchNo.BackColor = Color.White;
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
