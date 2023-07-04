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
                this.ActiveControl = txtEBrandName;
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
                            txtTBrandName.Text = objDS.Tables[0].Rows[0]["BTName"].ToString().Replace("''","'");
                            txtEBrandName.Text = objDS.Tables[0].Rows[0]["BEName"].ToString().Replace("''", "'");
                            txtTLabelName.Text = objDS.Tables[0].Rows[0]["BTLabelName"].ToString().Replace("''", "'");
                            txtELabelName.Text = objDS.Tables[0].Rows[0]["BELabelName"].ToString().Replace("''", "'");
                          
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

        private void txtTBrandName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTBrandName.BackColor = Color.LemonChiffon;
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
                    txtELabelName.Focus();
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
                txtTBrandName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEBrandName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEBrandName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEBrandName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTBrandName.Focus();
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
            try
            {
                txtEBrandName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTLabelName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTLabelName.BackColor = Color.LemonChiffon;
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
                txtTLabelName.BackColor = Color.White;
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
                txtELabelName.BackColor = Color.LemonChiffon;
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
                    txtTLabelName.Focus();
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
                txtELabelName.BackColor = Color.White;
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

                errBrand.Clear();
                if (txtTBrandName.Text.Trim() == "")
                {
                    errBrand.SetError(txtTBrandName, "Please enter brand name in tamil.");
                    txtTBrandName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpbrandtamilname.ShowAlways = true;
                    tpbrandtamilname.Show("Please enter brand name in tamil.", txtTBrandName, 5000);
                    txtTBrandName.Text = "";                    
                }
                if (txtEBrandName.Text.Trim() == "")
                {
                    errBrand.SetError(txtEBrandName, "Please enter brand name in english.");
                    txtEBrandName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpbrandname.ShowAlways = true;
                    tpbrandname.Show("Please enter brand name in english.", txtEBrandName, 5000);
                    txtEBrandName.Text = "";                    
                }
                if (txtTLabelName.Text.Trim() == "")
                {
                    errBrand.SetError(txtTLabelName, "Please enter label name in tamil.");
                    txtTLabelName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpbltname.ShowAlways = true;
                    tpbltname.Show("Please enter label name in tamil.", txtTLabelName, 5000);
                    txtTLabelName.Text = "";
                }
                if (txtELabelName.Text.Trim() == "")
                {
                    errBrand.SetError(txtELabelName, "Please enter label name in english.");
                    txtELabelName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpblename.ShowAlways = true;
                    tpblename.Show("Please enter label name in english", txtELabelName, 5000);
                    txtELabelName.Text = "";
                }
                if (txtEBrandName.Text.Trim() == "")
                {
                    txtEBrandName.Focus();
                    return;
                }
                if (txtTBrandName.Text.Trim() == "")
                {
                    txtTBrandName.Focus();
                    return;
                }
                if (txtELabelName.Text.Trim() == "")
                {
                    txtELabelName.Focus();
                    return;
                }
                if (txtTLabelName.Text.Trim() == "")
                {
                    txtTLabelName.Focus();
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
                txtTBrandName.Text = "";
                txtEBrandName.Text = "";
                txtTLabelName.Text = "";
                txtELabelName.Text = "";
                txtEBrandName.Focus();
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
    }
}
