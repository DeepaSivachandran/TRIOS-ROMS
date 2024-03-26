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
    public partial class GRN_GSTIN : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        private ToolTip tpgst = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public GRN_GSTIN()
        {
            InitializeComponent();
        }
        public void udfnGSTINSave()
        {
            try
            {
                if(Convert.ToInt32(MainForm.objPUR_GRNDetails.lblSupplierCode.Text)!=0)
                {
                    string GSTIN = txtGstin.Text.Trim().ToUpper();
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 34;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(MainForm.objPUR_GRNDetails.lblSupplierCode.Text);
                    objMR_Supplier.ParaGSTIN = GSTIN;
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        string value = "";
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                value = Convert.ToString(objDs.Tables[0].Rows[0]["Message"]);
                                string[] result = value.Split('~');

                                if (result[0] == "3")
                                {
                                    MessageBox.Show(result[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MainForm.objPUR_GRNDetails.varGSTIN = "1";
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show(result[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    MainForm.objPUR_GRNDetails.varGSTIN = "0";
                                    txtGstin.Focus();
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGstin.Text != "")
                {
                    if (txtGstin.Text.Length < 15)
                    {
                        txtGstin.Focus();
                        errGSTIN.SetError(txtGstin, "Please enter valid supplier GSTIN");
                        txtGstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpgst.ShowAlways = true;
                        tpgst.Show("Please enter valid supplier GSTIN.", txtGstin, 5000); 
                    }
                    else
                    {
                        errGSTIN.Clear();
                        udfnGSTINSave();
                    }
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

        private void PUR_GSTIN_Load(object sender, EventArgs e)
        {
            try
            {
                txtGstin.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGstin_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGstin.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGstin_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtGstin_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGstin.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGstin_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                objvalidation.udfnGSTIN(e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
