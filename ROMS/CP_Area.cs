using ROMS.Model;
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
    public partial class CP_Area : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpEAreaName = new ToolTip();
        private ToolTip tpTAreaName = new ToolTip();
        private ToolTip tpRouteName = new ToolTip();
        public string varSupplierIds;
        public int varUpDownKeyLocation = 0;
        public CP_Area()
        {
            InitializeComponent();
        }
        private void CP_Area_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Area_Leave(object sender, EventArgs e)
        {
            try
            {
                tpEAreaName.Active = false;
                tpTAreaName.Active = false;
                tpRouteName.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Area_Load(object sender, EventArgs e)
        {

        }
        public void udfnSave(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtAEName.Text).Trim() == "")
                {
                    errArea.SetError(txtAEName, "Please enter area english name.");
                    txtAEName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEAreaName.ShowAlways = true;
                    tpEAreaName.Show("Please enter area english name.", txtAEName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtATName.Text).Trim() == "")
                {
                    errArea.SetError(txtATName, "Please enter area tamil name.");
                    txtATName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTAreaName.ShowAlways = true;
                    tpTAreaName.Show("Please enter area tamil name.", txtATName, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    errArea.Clear();
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
                    btnSave.Enabled = true;
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
        private void btnSave_Leave(object sender, EventArgs e)
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

        private void txtAEName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAEName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAEName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtATName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAEName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAEName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtATName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtATName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtATName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtATName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtATName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInActive.Focus();
                        }
                    }
                    else
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

        private void txtRName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyLocation == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtRName.Text.Length > 0)
                    {
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 20;
                        objMR_Location.paraLocationName = txtRName.Text.Trim();
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();

                        //objDs = objspdservice.udfnStockLocationList(20, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtLocation.Text, 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterLocation.Visible = true;
                                    DGV_FilterLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterLocation.Columns["SL_EName"].Width = 220;
                                    DGV_FilterLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterLocation.DataSource = null;
                                    DGV_FilterLocation.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterLocation.DataSource = null;
                                DGV_FilterLocation.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterLocation.DataSource = null;
                            DGV_FilterLocation.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterLocation.DataSource = null;
                        DGV_FilterLocation.Visible = false;
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

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnClose_Leave(object sender, EventArgs e)
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
    }
}
