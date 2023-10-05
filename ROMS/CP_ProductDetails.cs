using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_ProductDetails : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;


        public string varcompanycode;
        public string pbFormStatus;
        public string varstatecode = "";
        public int varRackId = 0;
        public string varDescription = "";
        public string varRackName = "";

        public void udfnList()
        {
            try
            {
                Application.DoEvents();
                grdProductDetails.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnproductmasterlist(15,0,0,0,0,"",MainForm.pbUserID,MainForm.pbIpAddress,0,0,0,0,0,varRackId,0,0,0,0,0,0,0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            txtRackName.Text = varRackName;
                            txtDescription.Text = varDescription;
                            grdProductDetails.DataSource = objDs.Tables[0];
                            grdProductDetails.Columns["PR_UTID"].Visible = false;
                            grdProductDetails.Columns["PR_PUR_RKID"].Visible = false;
                            grdProductDetails.Columns["Product Name in English"].Width = 250;
                            grdProductDetails.Columns["S.NO."].Width = 50;
                            grdProductDetails.Columns["R.Sales Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                lblTotalProducts.Text = Convert.ToString(grdProductDetails.Rows.Count);
            }
        }

        public CP_ProductDetails()
        {
            InitializeComponent();
        }

        private void CP_Company_Load(object sender, EventArgs e)
        {
            try
            {
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            
        }


        

        private void TxtRetailRate_KeyPress(object sender, KeyPressEventArgs e)
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
            finally
            {

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

        private void CP_ProductDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_ProductDetails_Leave(object sender, EventArgs e)
        {

        }

        private void CP_ProductDetails_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}



