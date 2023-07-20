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
    public partial class CP_ChangePasswordConfirmation : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public CP_ChangePasswordConfirmation()
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
                   // btnConfirm.Focus();
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


       
    }
}
