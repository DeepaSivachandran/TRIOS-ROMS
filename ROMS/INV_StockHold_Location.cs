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
    public partial class INV_StockHold_Location : Form
    {

        //Created By Sathish on: 03-07-2024
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpQty = new ToolTip();
        private ToolTip tpLocation = new ToolTip();
        public int varCompanyCode = 0, varQty = 0, varSLID = 0, varSHID = 0, varStockQty = 0;
        private SecurityController _security;
        public string pbFormStatus;
        public INV_StockHold_Location()
        {
            InitializeComponent();
            _security = new SecurityController();
        }
        private void TxtStockLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0)
                {
                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 24;
                    objMR_Location.ParaCompanycode = varCompanyCode;
                    objMR_Location.paraLocationId = varSLID;
                    objMR_Location.paraLocationName = txtStockLocation.Text.Trim();
                    objDs = objspdservice.udfnStockLocationList(objMR_Location);
                    objspdservice.CloseConnection();
                    //objDs = objspdservice.udfnStockLocationList(24, varCompanyCode, varSLID, 0, txtStockLocation.Text, 0, 0, 0, "", "", 0);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SL_TName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvStockLocation.Items.Add(objList);
                                    objList.UseItemStyleForSubItems = false;
                                    //objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                }
                                lvStockLocation.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvStockLocation.Visible = false;
                    lvStockLocation.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtStockLocation.Focus();
            }
        }

        private void TxtStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtQty.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvStockLocation.Items.Count == 0 || txtStockLocation.Text == "")
                    {
                        txtStockLocation.Focus();
                        lvStockLocation.Visible = false;
                    }
                    else
                    {
                        lvStockLocation.Focus();
                    }
                    if (lvStockLocation.Items.Count > 0)
                    {
                        lvStockLocation.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnPurLocationAutocomplete();
                    txtQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurLocationAutocomplete()
        {
            try
            {
                if (txtStockLocation.Text != "")
                {
                    ListViewItem selectedItem = lvStockLocation.SelectedItems[0];
                    txtStockLocation.Text = selectedItem.SubItems[0].Text;
                    lblStockLocationCode.Text = selectedItem.SubItems[2].Text;
                    lvStockLocation.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvStockLocation.Visible = false;
            }
        }
        private void LvStockLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnPurLocationAutocomplete();
                txtQty.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void INV_StockHold_Location_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                int ViewType = 1;
                //objDs = objdserv.udfnStockHoldList(ViewType, SHID);
                TRN_StockHold objTRNG_StockHold = new TRN_StockHold();
                objTRNG_StockHold.ViewType = ViewType;
                objTRNG_StockHold.paraSHID = Convert.ToInt32(varSHID);
                objTRNG_StockHold.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRNG_StockHold.paraIPAddress = MainForm.pbIpAddress;
                objDs = objdserv.udfnStockHoldList(objTRNG_StockHold);
                objdserv.CloseConnection();
                //varStockQty = Convert.ToInt32(objDs.Tables[0].Rows[0]["Stock Qty"])- Convert.ToInt32(objDs.Tables[0].Rows[0]["Hold Qty"]);
                txtStockLocation.Focus();
                txtQty.Text = Convert.ToString(varQty);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text.Trim() != "")
                {
                    if(Convert.ToInt32(txtQty.Text)>varQty)
                    {
                        errLocation.SetError(txtQty, "Please enter valid qty.");
                        txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpQty.ShowAlways = true;
                        tpQty.Show("Please enter valid qty.", txtQty, 5000);
                    }
                    else
                    {
                        errLocation.Clear();
                        txtQty.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    btnMove.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMove_Enter(object sender, EventArgs e)
        {
            try
            {
                btnMove.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMove_Leave(object sender, EventArgs e)
        {
            try
            {
                btnMove.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (txtStockLocation.Text.Trim()=="")
                {
                    errLocation.SetError(txtStockLocation, "Please enter location.");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocation.ShowAlways = true;
                    tpLocation.Show("Please enter location.", txtStockLocation, 5000);
                    txtStockLocation.Focus();
                    blnErrorFlag = true;
                }
                if (txtQty.Text.Trim() != "")
                {
                    if (Convert.ToInt32(txtQty.Text) > varQty)
                    {
                        errLocation.SetError(txtQty, "Please enter valid qty.");
                        txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpQty.ShowAlways = true;
                        tpQty.Show("Please enter valid qty.", txtQty, 5000);
                        txtQty.Focus();
                        blnErrorFlag = true;
                    }
                }
                if (blnErrorFlag == false)
                {
                    udfnMove();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnMove()
        {
            try
            {
                int varDeleteFlag = 0;
                if (Convert.ToInt32(txtQty.Text) == varQty)
                {
                    varDeleteFlag = 1;
                }
                string varResult = "";
                DataTable objGrnPO = new DataTable();
                TRN_StockHold objTRNS_StockHold = new TRN_StockHold();
                SPDataService objspservice = new SPDataService();
                objTRNS_StockHold.ViewType = 0;
                objTRNS_StockHold.paraSHID = varSHID;
                objTRNS_StockHold.paraSLID = Convert.ToInt32(lblStockLocationCode.Text);
                objTRNS_StockHold.paraQty = Convert.ToDecimal(txtQty.Text);
                objTRNS_StockHold.paraStockQty = varStockQty;
                objTRNS_StockHold.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRNS_StockHold.paraFlag = 1;
                objTRNS_StockHold.paraStatus = 96;
                objTRNS_StockHold.paraParentSHID = varSHID;
                objTRNS_StockHold.paraDeleteFlag = varDeleteFlag;
                objTRNS_StockHold.paraOriginator = "Stock Hold Move Location";
                varResult = objspservice.udfnStockHold(objTRNS_StockHold);
                objspservice.CloseConnection();
                string[] varvalue1 = varResult.Split('~');
                if (varvalue1[0] == "3")
                {
                    MessageBox.Show(varvalue1[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
