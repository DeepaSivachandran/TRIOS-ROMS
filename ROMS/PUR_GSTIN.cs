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
    public partial class PUR_GSTIN : Form
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
        bool varErrorFlag = false;
        string varfirstValue = "", varsecValue = "", varTINNo = "0";
        private const int closebtnhide = 0x200;
        public int pbPurchaseQueueFlag = 0;
        public PUR_GSTIN()
        {
            InitializeComponent();
        }
        private void TxtEUnitName_Leave(object sender, EventArgs e)
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

        private void TxtEUnitName_Enter(object sender, EventArgs e)
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

        private void TxtEUnitName_KeyDown(object sender, KeyEventArgs e)
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
        public void udfnGSTINSave()
        {
            try
            {
                if (varErrorFlag == false)
                {
                    if (Convert.ToInt32(MainForm.objCP_Purchase.lblSupplierCode.Text) != 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        string result = "";
                        result = objspdservice.udfnSupplierMaster(12, Convert.ToInt32(MainForm.objCP_Purchase.lblSupplierCode.Text), "", "", "", 0, "", "", "", "", "", txtGstin.Text.Trim(), 0,
                        0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Salesman Details Update PO", 0, "", 0, 0, 0, 0, 0, "",
                        "", "", "", 0, "", 0, 0, "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, "","");

                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            // MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainForm.objCP_Purchase.txtGstin.Text = txtGstin.Text;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtGstin.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            txtGstin.Focus();
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
                varErrorFlag = false;
                if (txtGstin.Text != "")
                {
                    if (txtGstin.Text.Length < 15)
                    {
                        txtGstin.Focus();
                        errGSTIN.SetError(txtGstin, "Please enter valid supplier GSTIN");
                        txtGstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpgst.ShowAlways = true;
                        tpgst.Show("Please enter valid supplier GSTIN.", txtGstin, 5000);
                        varErrorFlag = true;
                    }
                    else
                    {
                        errGSTIN.Clear();
                        //MainForm.objCP_Purchase.txtGstin.Text = txtGstin.Text;
                        //this.Close();
                    }
                    string varGSTIN = txtGstin.Text;
                    varTINNo = Convert.ToString(MainForm.objCP_Purchase.pbSupplierTin);
                    varfirstValue = Convert.ToString(varGSTIN[0]);
                    varsecValue = Convert.ToString(varGSTIN[1]);
                    if (varfirstValue != Convert.ToString(varTINNo[0]) || varsecValue != Convert.ToString(varTINNo[1]))
                    {
                        errGSTIN.SetError(txtGstin, "Invalid GSTIN");
                        txtGstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpgst.ShowAlways = true;
                        tpgst.Show("Invalid GSTIN", txtGstin, 5000);
                        varErrorFlag = true;
                    }
                    else
                    {
                        errGSTIN.Clear();
                        //MainForm.objCP_Purchase.txtGstin.Text = txtGstin.Text;
                        //this.Close();
                    }
                    udfnGSTINSave();
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | closebtnhide;
                return myCp;
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                MainForm.objCP_Purchase.varCloseflag = 1;
                MainForm.objCP_Purchase.udfnclose();
                //this.Hide();
                //MainForm.objCP_PurchaseList = new CP_PurchaseList();
                //MainForm.objCP_PurchaseList.Closed += (s, args) => this.Close();
                //MainForm.objCP_PurchaseList.MdiParent = this.ParentForm;
                //MainForm.objCP_PurchaseList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
