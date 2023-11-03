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
    public partial class INV_DamageEntry : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpplno = new ToolTip();
        private ToolTip tpMRP = new ToolTip();
        private ToolTip tpMonth = new ToolTip();
        private ToolTip tpYear = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpQuantity = new ToolTip();
        private ToolTip tpSupplierName = new ToolTip();
        private ToolTip tpcompanyname = new ToolTip();

        public INV_DamageEntry()
        {
            InitializeComponent();
        }
        public void udfnAdd()
        {
            try
            {
                string varExpiryDate = "",varUnit="";
                //varExpiryDate = txtDay.Text.Trim() + txtMonth.Text.Trim() + txtYear.Text.Trim();
                //grdDamageEntry.Rows.Add(grdDamageEntry.Rows.Count + 1, txtProductName.Text.Trim(), txtProductName.Text.Trim(),txtMrp.Text.Trim(),varExpiryDate,txtBatchNo.Text.Trim(),txtQuantity.Text.Trim(), varUnit,txtsuppliername.Text.Trim(),txtDay.Text.Trim(),txtMonth.Text.Trim(),txtYear.Text.Trim());
                udfnClear();
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClear()
        {
            try
            {
                txtProductName.Text = "";
                txtMrp.Text = "";
                //txtDay.Text = "";
                //txtMonth.Text = "";
                //txtYear.Text = "";
                txtBatchNo.Text = "";
                txtQuantity.Text = "";
                txtsuppliername.Text = "";
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbConcernLoad()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varViewType = 3, varConcernId = 0;
                objDT = objdserv.udfnCompanyList(varViewType, varConcernId, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                objdserv.CloseConnection();
                cmbConcern.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDT.Tables[0];
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
        private void INV_DamageEntry_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = cmbConcern;
                if (btnSave.Text == "Save")
                {
                    grpproductname.Visible = true;
                    txtsuppliername.Enabled = true;
                }
                else
                {
                    grpproductname.Visible = false;
                    txtsuppliername.Enabled = false;
                    //cmbvoucherno.Enabled = false;
                    //cmbPoNo.Enabled = false;
                    //cmbinwardtype.Enabled = false;
                }
                udfnCmbConcernLoad();
            }
            catch(Exception ex)
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
        private void INV_Inward_Load(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                grpproductname.Visible = true;
                txtsuppliername.Enabled = true;
            }
            else
            {
                grpproductname.Visible = false;
                txtsuppliername.Enabled = false;
                //cmbvoucherno.Enabled = false;
                //cmbPoNo.Enabled = false;
                //cmbinwardtype.Enabled = false;
            }
        }
        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epDamageEntry.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    epDamageEntry.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpEntryDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtProductName.Text == "")
                {
                    epDamageEntry.SetError(txtProductName, "Please enter product name or P.I Code");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter product name or P.I Code", txtProductName, 5000);
                }
                else
                {
                    txtProductName.BackColor = Color.White;
                    epDamageEntry.Clear();
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
                if (txtMrp.Text == "")
                {
                    epDamageEntry.SetError(txtMrp, "Please enter MRP.");
                    txtMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMRP.ShowAlways = true;
                    tpMRP.Show("Please enter MRP.", txtMrp, 5000);
                }
                else
                {
                    txtMrp.BackColor = Color.White;
                    epDamageEntry.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpEntryDate_Enter(object sender, EventArgs e)
        {

        }
        private void DpEntryDate_Leave(object sender, EventArgs e)
        {

        }
        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMrp.Focus();
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
                //txtDay.BackColor = Color.LemonChiffon;
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
                //txtDay.BackColor = Color.White;
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
                //txtMonth.BackColor = Color.White;
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
                //if (txtMonth.Text == "")
                //{
                //    //epDamageEntry.SetError(txtMonth, "Please enter Month.");
                //    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpMonth.ShowAlways = true;
                //    tpMonth.Show("Please enter Month.", txtMonth, 5000);
                //}
                //else
                //{
                //    txtMonth.BackColor = Color.White;
                //    epDamageEntry.Clear();
                //}
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
                    //txtMonth.Focus();
                }
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
                    //txtDay.Focus();
                }
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
                    //txtYear.Focus();
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
                //txtYear.BackColor = Color.LemonChiffon;
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
                    txtBatchNo.Focus();
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
                //if (txtYear.Text == "")
                //{
                //    //epDamageEntry.SetError(txtYear, "Please enter Year.");
                //    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpYear.ShowAlways = true;
                //    tpYear.Show("Please enter Year.", txtYear, 5000);
                //}
                //else
                //{
                //    txtYear.BackColor = Color.White;
                //    epDamageEntry.Clear();
                //}
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
        private void TxtBatchNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBatchNo.Text == "")
                {
                    epDamageEntry.SetError(txtBatchNo, "Please enter batch No.");
                    txtBatchNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBatchNo.ShowAlways = true;
                    tpBatchNo.Show("Please enter batch No.", txtBatchNo, 5000);
                }
                else
                {
                    txtBatchNo.BackColor = Color.White;
                    epDamageEntry.Clear();
                }
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
                    txtQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtQuantity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantity.Text == "")
                {
                    epDamageEntry.SetError(txtQuantity, "Please enter quantity.");
                    txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quantity.", txtQuantity, 5000);
                }
                else
                {
                    txtQuantity.BackColor = Color.White;
                    epDamageEntry.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtsuppliername.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtsuppliername_Enter(object sender, EventArgs e)
        {
            try
            {
                txtsuppliername.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtsuppliername_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtsuppliername.Text == "")
                {
                    epDamageEntry.SetError(txtsuppliername, "Please enter supplier name.");
                    txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSupplierName.ShowAlways = true;
                    tpSupplierName.Show("Please enter supplier name.", txtsuppliername, 5000);
                }
                else
                {
                    txtsuppliername.BackColor = Color.White;
                    epDamageEntry.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtsuppliername_KeyDown(object sender, KeyEventArgs e)
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
        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.LemonChiffon;
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
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (txtProductName.Text == "")
                {
                    epDamageEntry.SetError(txtProductName, "Please enter product name or P.I Code.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter product name or P.I Code.", txtProductName, 5000);
                    blnErrorFlag = true;
                }
                if (txtMrp.Text == "")
                {
                    epDamageEntry.SetError(txtMrp, "Please enter MRP.");
                    txtMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMRP.ShowAlways = true;
                    tpMRP.Show("Please enter MRP.", txtMrp, 5000);
                    blnErrorFlag = true;
                }
                //if (txtMonth.Text == "")
                //{
                //    //epDamageEntry.SetError(txtMonth, "Please enter Month.");
                //    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpMonth.ShowAlways = true;
                //    tpMonth.Show("Please enter Month.", txtMonth, 5000);
                //    blnErrorFlag = true;
                //}
                //if (txtYear.Text == "")
                //{
                //    //epDamageEntry.SetError(txtYear, "Please enter Year.");
                //    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpYear.ShowAlways = true;
                //    tpYear.Show("Please enter Year.", txtYear, 5000);
                //    blnErrorFlag = true;
                //}
                if (txtBatchNo.Text == "")
                {
                    epDamageEntry.SetError(txtBatchNo, "Please enter batch No.");
                    txtBatchNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBatchNo.ShowAlways = true;
                    tpBatchNo.Show("Please enter batch No.", txtBatchNo, 5000);
                    blnErrorFlag = true;
                }
                if (txtQuantity.Text == "")
                {
                    epDamageEntry.SetError(txtQuantity, "Please enter quantity.");
                    txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quantity.", txtQuantity, 5000);
                    blnErrorFlag = true;
                }
                if (txtsuppliername.Text == "")
                {
                    epDamageEntry.SetError(txtsuppliername, "Please enter supplier name.");
                    txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSupplierName.ShowAlways = true;
                    tpSupplierName.Show("Please enter supplier name.", txtsuppliername, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    udfnAdd();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Focus();
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

        private void GrdDamageEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.RowIndex != -1)
                //{
                //    switch (grdDamageEntry.Columns[e.ColumnIndex].Name)
                //    {
                //        case "clmremove":
                //            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //            if (dialogResult == DialogResult.Yes)
                //            {
                //                grdDamageEntry.Rows.RemoveAt(this.grdDamageEntry.SelectedRows[0].Index);
                //                for (int i = 0; i < grdDamageEntry.RowCount; i++)
                //                {
                //                    grdDamageEntry.Rows[i].Cells["clmdsno"].Value = i + 1;
                //                }
                //            }
                //            break;
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRemark_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRemark.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRemark_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRemark.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRemark_KeyDown(object sender, KeyEventArgs e)
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
        private void BtnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
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
        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
        private void BtnClose_Enter(object sender, EventArgs e)
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
        private void BtnClose_Leave(object sender, EventArgs e)
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
        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_DamageEntry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Escape)
                {
                    btnClose.Focus();
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    BtnSave_Click(sender, e);
                }
            }
            catch(Exception ex)
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
        private void TxtYear_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
