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
        public string varbrandcode;

        private ToolTip tpBrandNameInEnglish = new ToolTip();
        private ToolTip tpBrandNameInTamil = new ToolTip();

        public int varStatusid = 0;
        public int varCloseFlag = 0;
        public int varFormFlag = 0;
        public CP_Brand()
        {
            InitializeComponent();
        }

        private void CP_Brand_Leave(object sender, EventArgs e)
        {
            try
            {
                tpBrandNameInEnglish.Active = false;
                tpBrandNameInTamil.Active = false;
              
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnList()
        {
            try
            {
                //picLoader.Visible = true;
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdGroup.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnGroupList(0, 0);
                objdserv.CloseConnection();

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    grdGroup.DataSource = objDs.Tables[0];
                    grdGroup.Columns["S.No."].Visible = false;
                    grdGroup.Columns["Product Group Name in English"].Width = 200;
                    grdGroup.Columns["Product Group Name in English"].HeaderText = "Product Group";
                    grdGroup.Columns["Product Group Name in Tamil"].Visible = false;
                    grdGroup.Columns["Total Sub Groups"].Visible = false;
                    grdGroup.Columns["Total Products"].Visible = false;
                    grdGroup.Columns["Status"].Visible = false;
                    grdGroup.Columns["ID"].Visible = false;
                    grdGroup.Columns["Status ID"].Visible = false;

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnSubGroupList()
        {
            try
            {
                //picLoader.Visible = true;
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdSubGroup.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnSubGroupList(0, 16,0);
                objdserv.CloseConnection();
              
                if (objDs.Tables[0].Rows.Count != 0)
                {

                    grdSubGroup.DataSource = objDs.Tables[0];
                    grdSubGroup.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdSubGroup.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    grdSubGroup.Columns["S.No."].Visible = false;
                    grdSubGroup.Columns["Product Group Name"].Width = 200;
                    grdSubGroup.Columns["Product Sub Group Name in English"].Width = 250;
                    grdSubGroup.Columns["Product Sub Group Name in Tamil"].Visible = false;
                    grdSubGroup.Columns["Stock Location"].Visible = false;
                    grdSubGroup.Columns["Rack"].Visible = false;
                    grdSubGroup.Columns["Total Products"].Visible = false;
                    grdSubGroup.Columns["Status"].Visible = false;

                    grdSubGroup.Columns["ID"].Visible = false;
                    grdSubGroup.Columns["Status ID"].Visible = false;
                    grdSubGroup.Columns["Batch No"].Visible = false;
                    grdSubGroup.Columns["StockLocation ID"].Visible = false;
                    grdSubGroup.Columns["Rack ID"].Visible = false;
                    grdSubGroup.Columns["Product Group Id"].Visible = false;
                }    
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
                 this.Close();
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
                //  MainForm.objCP_BrandList.udfnList();
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
                    btnSave.Focus();
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Brand_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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

        private void TxtEBrandNameInEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEBrandNameInEnglish.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInEnglish, "Please enter brand name in english");
                    txtEBrandNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInEnglish.ShowAlways = true;
                    tpBrandNameInEnglish.Show("Please enter brand name in english", txtEBrandNameInEnglish, 5000);
                }
                else
                {
                    epBrand.Clear();
                    txtEBrandNameInEnglish.BackColor = Color.White;
                }
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

        private void TxtEBrandNameInTamil_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtEBrandNameInTamil.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInTamil, "Please enter brand name in tamil");
                    txtEBrandNameInTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInTamil.ShowAlways = true;
                    tpBrandNameInTamil.Show("Please enter brand name in tamil", txtEBrandNameInTamil, 5000);
                }
                else
                {
                    epBrand.Clear();
                    txtEBrandNameInTamil.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelectedProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSelectedProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelectedProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSelectedProductSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClear()
        {
            try
            {
                txtEBrandNameInEnglish.Text = "";
                txtEBrandNameInTamil.Text = "";
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
                if (rbActive.Checked)
                {
                    varStatusid = 1;
                }
                else
                {
                    varStatusid = 2;
                }
                if (btnSave.Text == "Save")
                {
                    SPDataService objDser = new SPDataService();
                    string varResult = objDser.udfnBrand(0,Convert.ToString(txtEBrandNameInEnglish.Text), Convert.ToString(txtEBrandNameInTamil.Text), varStatusid, "Creation");
                    objDser.CloseConnection();
                    if (varResult.Split('~')[0] == "3")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnClear();
                        MainForm.objCP_BrandList.udfnList();
                    }
                    else if (varResult.Split('~')[0] == "4")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                bool blnErrorFlag = false;

                if (txtEBrandNameInEnglish.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInEnglish, "Please enter brand name in english");
                    txtEBrandNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInEnglish.ShowAlways = true;
                    tpBrandNameInEnglish.Show("Please enter brand name in english", txtEBrandNameInEnglish, 5000);
                    blnErrorFlag = true;
                }

                if (txtEBrandNameInTamil.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInTamil, "Please enter brand name in tamil");
                    txtEBrandNameInTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInTamil.ShowAlways = true;
                    tpBrandNameInTamil.Show("Please enter brand name in tamil", txtEBrandNameInTamil, 5000);
                    blnErrorFlag = true;
                }
                //if (blnErrorFlag == false && grdSubGroupAdd.Rows.Count <= 0)
                //{
                //    if (grdSubGroupAdd.Rows.Count <= 0)
                //    {
                //        DialogResult dialogResult = MessageBox.Show("Please select atleast one product sub group", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }

                //}
                udfnSave(sender, e);
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
                    txtProductGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSelectedProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelectedProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnRemove.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnRemove_Enter(object sender, EventArgs e)
        {
            try
            {
                btnRemove.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnRemove_Leave(object sender, EventArgs e)
        {
            try
            {
                btnRemove.BackColor = Color.White;
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
                btnSave.BackColor = Color.White;
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
                btnClose.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void TxtEBrandNameInTamil_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtProductGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdGroup.DataSource as DataTable).DefaultView.RowFilter = "([Product Group Name in English]) LIKE '%" + txtProductGroup.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Brand_Load(object sender, EventArgs e)
        {
            try
            {
                udfnList();
                udfnSubGroupList();
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    //udfnEdit();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSubGroup.DataSource as DataTable).DefaultView.RowFilter = "([Product Sub Group Name in English]) LIKE '%" + txtProductSubGroup.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Chkgroup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdGroup.Rows.Count; i++)
                {
                    grdGroup.Rows[i].Cells["clmChkAllProductGroup"].Value = chkgroup.Checked;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
  
}
