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
    public partial class CP_Brand : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public CP_Brand()
        {
            InitializeComponent();
        }

        private void CP_Brand_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtEBrandNameInEnglish;
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtEBrandNameInEnglish.Text = objDS.Tables[0].Rows[0]["BEName"].ToString().Replace("''", "'");
                            btnSave.Text = "Update";
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

        private void txtEBrandName_Enter(object sender, EventArgs e)
        {

        }

        private void txtEBrandName_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtEBrandNameInEnglish.BackColor = Color.White;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                errBrand.Clear();
                if (txtEBrandNameInEnglish.Text.Trim() == "")
                {
                    errBrand.SetError(txtEBrandNameInEnglish, "Please enter brand name in english.");
                    txtEBrandNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpbrandname.ShowAlways = true;
                    tpbrandname.Show("Please enter brand name in english.", txtEBrandNameInEnglish, 5000);
                    txtEBrandNameInEnglish.Text = "";
                }
                if (txtEBrandNameInEnglish.Text.Trim() == "")
                {
                    txtEBrandNameInEnglish.Focus();
                    return;
                }
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
            try
            {
                txtEBrandNameInEnglish.Text = "";
                txtEBrandNameInEnglish.Focus();
                btnSave.Text = "Save";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose.Focus();
                }
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

        private void Grbform_Enter(object sender, EventArgs e)
        {

        }

        private void GrdGroupList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void CmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtDSlNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtEBrandEnglish_Enter(object sender, EventArgs e)
        {

        }

        private void txtBrandNameEnglish(object sender, KeyEventArgs e)
        {

        }

        private void TxtEBrandNameEnglish_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtDEBrandNameInTamil.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void txtEBrandNameTamil_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    txtDEBrandNameInEnglish.BackColor = Color.LemonChiffon;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void TxtEBrandNameTamil_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        cmbUserRole.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }


        private void TxtEBrandNameEnglish_KeyDown_1(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        txtEBrandNameInEnglish.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void CmbUserRole_Enter(object sender, EventArgs e)
        {

        }

        private void CmbUserRole_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbUserRole_Enter_1(object sender, EventArgs e)
        {

        }

        private void TxtEBrandNameEnglish_Leave(object sender, EventArgs e)
        {

        }

        private void txtEBrandNameTamil_Leave(object sender, EventArgs e)
        {

        }

        private void TxtEBrandNameInEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEBrandNameInEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEBrandNameInEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEBrandNameInTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEBrandNameInEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEBrandNameInEnglish.Text == "")
                {
                    txtEBrandNameInEnglish.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errBrand.SetError(txtEBrandNameInEnglish, "Please Enter Brand Name In English");
                }
                else
                {
                    txtEBrandNameInEnglish.BackColor = Color.White;
                    errBrand.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEBrandNameInTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEBrandNameInTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEBrandNameInTamil_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //cmbUserRole.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEBrandNameInTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEBrandNameInTamil.Text == "")
                {
                    txtEBrandNameInTamil.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errBrand.SetError(txtEBrandNameInTamil, "Please Enter Brand Name In Tamil");
                }
                else
                {
                    txtEBrandNameInTamil.BackColor = Color.White;
                    errBrand.Clear();
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
    
    

