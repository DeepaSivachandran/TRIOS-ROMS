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
    public partial class PUR_BulkUnit : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public int varCloseFlag = 0;
        public string pbFormStatus;
        public PUR_BulkUnit()
        {
            InitializeComponent();
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
        public void udfnclose()
        {
            try
            {
                if (varCloseFlag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else { this.Close(); }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbUnit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbUnit.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUpp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbUnit.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUpp_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUpp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUpp_Leave(object sender, EventArgs e)
        {
            try
            {
                txtUpp.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUpp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnUpdate.Focus();
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
                btnUpdate.BackColor = Color.LemonChiffon;
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
                btnUpdate.BackColor = Color.Transparent;
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

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblProductcode.Text) != 0)
                {
                    bool blnErrorFlag = true;
                    if (Convert.ToString(cmbUnit.SelectedValue) == "-1")
                    {
                        errNewProduct.SetError(cmbUnit, "Please select unit.");
                        cmbUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpblename.ShowAlways = true;
                        tpblename.Show("Please select unit.", cmbUnit, 5000);
                        blnErrorFlag = false;
                    }
                    if (blnErrorFlag == true)
                    {
                        udfnSave();
                    }
                }
                else
                {
                    MessageBox.Show("Product Not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave()
        {
            try
            {
                errNewProduct.Clear();
                cmbUnit.BackColor = Color.White;
                  SPDataService objspdservice = new SPDataService();
                string result = "", varorignator, varupdate;
                int varviewtype;
                varviewtype = 12;
                varorignator = "Product Update"; 
                result = objspdservice.udfnProductMaster(varviewtype, Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblProductcode.Text), "", "", "", 0, 0, 0, 0, 0, 0,Convert.ToInt32(cmbUnit.SelectedValue),txtUpp.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "",MainForm.pbUserID, MainForm.pbIpAddress, varorignator, 0, null,0,"",0,0,0,0,0, null, "", "","",0,"", "", 0, 0, 0, null, 0, 0, 0, 0, null,0,"","", "", "");
                objspdservice.CloseConnection();
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    varCloseFlag = 1;
                    MainForm.objPUR_PurchaseOrder.varcmbunitid = Convert.ToInt32(varvalue[2]);

                    if (MainForm.objPUR_PurchaseOrder.varcmbunitid != 0)
                    {
                        MainForm.objPUR_PurchaseOrder.varUPP =Convert.ToInt32(txtUpp.Text);
                    }
                    udfnclose();
                    //MainForm.objCP_Itemlist.udfnDropdownbind();
                    //MainForm.objCP_Itemlist.udfnList();
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_BulkUnit_Load(object sender, EventArgs e)
        {
            try
            {
                txtDProductName.Text = MainForm.objPUR_PurchaseOrder.txtProductName.Text;
                if (MainForm.objPUR_PurchaseOrder.pbunitname == "")
                {
                    txtUnittype.Text = "";
                }
                else
                {
                    txtUnittype.Text = MainForm.objPUR_PurchaseOrder.pbunitname;
                }
                this.ActiveControl= cmbUnit;
                int varViewType = 5; 
                DataSet objDT = new DataSet();
                DataSet objDTBulkUnit = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDT = objdserv.udfnUnitList(varViewType, 0,Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblProductcode.Text));
                objdserv.CloseConnection();
                cmbUnit.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbUnit.ValueMember = "UTID";
                            cmbUnit.DisplayMember = "UT_Symbol";
                            cmbUnit.DataSource = objDT.Tables[0];
                        }
                        if (objDT.Tables[1].Rows.Count > 0)
                        {
                            cmbUnit.SelectedValue = objDT.Tables[1].Rows[0]["PR_Bulk_UTID"].ToString();
                            txtUpp.Text = objDT.Tables[1].Rows[0]["PR_UPP"].ToString();
                            txtUnittype.Text =Convert.ToString(objDT.Tables[1].Rows[0]["UT_Name"]);
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

        private void PUR_BulkUnit_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{ 
            //    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        e.Cancel = false;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    } 
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void PUR_BulkUnit_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtUpp_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
