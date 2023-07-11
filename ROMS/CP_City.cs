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
    public partial class CP_City : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public CP_City()
        {
            InitializeComponent();
        }

        private void CP_Brand_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    this.ActiveControl = txtEStatetName;
            //    udfnEdit();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }


        private void udfnEdit()
        {
            try
            {
                if (varbrandcode != "")
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS = new DataSet();
                 //   objDS = objspservice.udfnSPBrandList("EditLoad", varbrandcode, MainForm.pbUserID, MainForm.pbIpAddress);
                    objspservice.CloseConnection();

                    if (objDS != null)
                    {
                        //if (objDS.Tables[0].Rows.Count > 0)
                        //{
                        //    txtTEInvoiceUnitName.Text = objDS.Tables[0].Rows[0]["UName"].ToString().Replace("''","'");
                        //    txtDUnitName.Text = objDS.Tables[0].Rows[0]["EIName"].ToString().Replace("''", "'");
                        //    /*  txtDEIUnitName.Text = objDS.Tables[0].Rows[0]["BTLabelName"].ToString().Replace("''", "'");
                        //      txtELabelName.Text = objDS.Tables[0].Rows[0]["BELabelName"].ToString().Replace("''", "'"); */

                        //    btnSave.Text = "Update";
                        //}
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

        private void txtTBrandName_Enter(object sender, EventArgs e)
        {
            try
            {
                //txtTEInvoiceUnitName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTBrandName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtELabelName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTBrandName_Leave(object sender, EventArgs e)
        {
            try
            {
                //txtTEInvoiceUnitName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEBrandName_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtEStatetName.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtEBrandName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtTEInvoiceUnitName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEBrandName_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtEStatetName.BackColor = Color.White;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtTLabelName_Enter(object sender, EventArgs e)
        {
            try
            {
                //txtTLabelName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTLabelName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtTLabelName_Leave(object sender, EventArgs e)
        {
            try
            {
                //txtTLabelName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtELabelName_Enter(object sender, EventArgs e)
        {
            try
            {
                //txtELabelName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtELabelName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtTLabelName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtELabelName_Leave(object sender, EventArgs e)
        {
            try
            {
                //txtELabelName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }                              
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                errCity.Clear();
                //if (txtTEInvoiceUnitName.Text.Trim() == "")
                //{
                //    errBrand.SetError(txtTEInvoiceUnitName, "Please enter brand name in tamil.");
                //    txtTEInvoiceUnitName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                //    tpbrandtamilname.ShowAlways = true;
                //    tpbrandtamilname.Show("Please enter brand name in tamil.", txtTEInvoiceUnitName, 5000);
                //    txtTEInvoiceUnitName.Text = "";                    
                //}
                //if (txtEStatetName.Text.Trim() == "")
                //{
                //    errCity.SetError(txtEStatetName, "Please enter unit name.");
                //    txtEStatetName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpbrandname.ShowAlways = true;
                //    tpbrandname.Show("Please enter unit name.", txtEStatetName, 5000);
                //    txtEStatetName.Text = "";                    
                //}
                //if (txtTLabelName.Text.Trim() == "")
                //{
                //    errBrand.SetError(txtTLabelName, "Please enter label name in tamil.");
                //    txtTLabelName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpbltname.ShowAlways = true;
                //    tpbltname.Show("Please enter label name in tamil.", txtTLabelName, 5000);
                //    txtTLabelName.Text = "";
                //}
                //if (txtELabelName.Text.Trim() == "")
                //{
                //    errBrand.SetError(txtELabelName, "Please enter label name in english.");
                //    txtELabelName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpblename.ShowAlways = true;
                //    tpblename.Show("Please enter label name in english", txtELabelName, 5000);
                //    txtELabelName.Text = "";
                //}
                //if (txtEStatetName.Text.Trim() == "")
                //{
                //    txtEStatetName.Focus();
                //    return;
                //}
                //if (txtTEInvoiceUnitName.Text.Trim() == "")
                //{
                //    txtTEInvoiceUnitName.Focus();
                //    return;
                //}
                //if (txtELabelName.Text.Trim() == "")
                //{
                //    txtELabelName.Focus();
                //    return;
                //}
                //if (txtTLabelName.Text.Trim() == "")
                //{
                //    txtTLabelName.Focus();
                //    return;
                //}
                SPDataService objspdservice = new SPDataService();
                string result = "";
                if (btnSave.Text == "Save")
                {
                 //   result = objspdservice.udfnSPBrandMaster("Create", "0",txtTBrandName.Text,txtEBrandName.Text,txtTLabelName.Text,txtELabelName.Text, MainForm.pbUserID, MainForm.pbIpAddress, "Brand Create");
                }
                else
                {
                 //   result = objspdservice.udfnSPBrandMaster("Update", varbrandcode, txtTBrandName.Text, txtEBrandName.Text, txtTLabelName.Text, txtELabelName.Text, MainForm.pbUserID, MainForm.pbIpAddress, "Brand Update");
                }
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnSave.Text == "Update")
                    {
                        this.Close();
                    }
                    else
                    {
                        if (pbFormStatus == "Finished")
                        {
                            pbFormStatus = "";
                            //MainForm.objCP_Product.varBrandCode = varvalue[2];
                            //MainForm.objCP_Product.varBrandName = txtEBrandName.Text;
                            //MainForm.objCP_Product.udfnLoadBrand();
                            this.Close();
                        }
                        udfnclear();
                    }

                    MainForm.objCP_BrandList.udfnList();



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

        private void udfnclear()
        {
            //try
            //{
            //    //txtTEInvoiceUnitName.Text = "";
            //    txtEStatetName.Text = "";
            //    //txtTLabelName.Text = "";
            //    //txtELabelName.Text = "";
            //    txtEStatetName.Focus();
            //    btnSave.Text = "Save";
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

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
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
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
              //  MainForm.objCP_BrandList.udfnList();
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

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Brand_Leave(object sender, EventArgs e)
        {
            try
            {
                tpbrandname.Active = false;
                tpbrandtamilname.Active = false;
                tpbltname.Active = false;
                tpblename.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Brand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDEBrandName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rbactive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TxtTEInvoiceUnitName_TextChanged(object sender, EventArgs e)
        {

        }

        private void RbInActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Grbform_Enter(object sender, EventArgs e)
        {

        }

        private void TxtCityName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (pnlStatus.Enabled == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        rbActive.Focus();
                    }
                }
                else {
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnSave.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PnlStatus_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RbActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbInActive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCityName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCityName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCityName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCityName.Text == "")
                {
                    txtCityName.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errCity.SetError(txtCityName,"Please Enter City Name");
                }
                else
                {
                    txtCityName.BackColor = Color.White;
                    errCity.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCityName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInActive_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void PnlStatus_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    pnlStatus.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void PnlStatus_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    pnlStatus.BackColor = Color.White;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void RbInActive_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
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
    }
}
