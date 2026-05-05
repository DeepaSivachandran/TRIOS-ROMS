using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Windows.Forms;

namespace ROMS
{
    //Created By:-Sathish ; Created On:-11-08-2023
    public partial class CP_Basket : Form
    {
        DataError objError;
        private ToolTip tpBasketNo = new ToolTip(); 
        private ToolTip tpBasketType= new ToolTip(); 
        public int pbBasketID = 0,varCloseFlag=0;
        public CP_Basket()
        {
            InitializeComponent();
        }
        private void CP_Basket_Leave(object sender, EventArgs e)
        {
            try
            {
                tpBasketNo.Active = false;  
                tpBasketType.Active = false;  
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_City_Load(object sender, EventArgs e)
        {
            try
            {  
                udfnDropDownLoad();
                udfnEdit();
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                MainForm.objCP_Basketlist.picLoader.Visible = false;
                MainForm.objCP_Basketlist.picLoader.SendToBack(); this.FormBorderStyle = FormBorderStyle.FixedDialog;
                MainForm.objCP_Basketlist.picLoader.Visible = false;
                MainForm.objCP_Basketlist.picLoader.SendToBack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }
        public void udfnEdit()
        {
            try
            {
                if (pbBasketID != 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService(); 
                    MR_Basket objMR_Basket = new MR_Basket();
                    objMR_Basket.paraViewType = 1;
                    objMR_Basket.paraBasketId = pbBasketID;
                    objDs = objspservice.udfnBasketList(objMR_Basket);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                txtBasketNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["BasketNo"]);
                                cmbBasketType.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["BasketTypeId"]);
                                btnSave.Text = "Update";
                                varCloseFlag = 1;
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
        private void udfnDropDownLoad()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID IN (0,175) AND MSTID<>0  ORDER BY MSTID ASC", "MST_DisplayText,MSTID", cmbBasketType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbBasketType.SelectedValue = -1;
                //Load next basket No
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                MR_Basket objMR_Basket = new MR_Basket();
                objMR_Basket.paraViewType =2; 
                objDs = objspservice.udfnBasketList(objMR_Basket);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            txtBasketNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["BasketNo"]); 
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
        public void udfnSave(object sender,EventArgs e)
        {
            try
            { 
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = "";int varViewType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Basket Creation";
                    varViewType = 0;
                }
                else
                {
                    varoriginator = "Basket Updation";
                    varViewType = 1;    
                } 
                objspservice.CloseConnection();
                SPDataService objspdservice = new SPDataService();
                MR_Basket objMR_Basket = new MR_Basket(); 
                objMR_Basket.paraViewType = varViewType;
                objMR_Basket.paraBasketId = pbBasketID;
                objMR_Basket.paraTypeId = Convert.ToInt16(cmbBasketType.SelectedValue);
                objMR_Basket.paraBasketNo = Convert.ToInt16(txtBasketNo.Text); 
                varResult = objspdservice.udfnBasket(objMR_Basket);
                string[] varvalue = varResult.Split('~'); 
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Basketlist.udfnList();
                    if (btnSave.Text == "Save")
                    { 
                        udfnclear();
                    }
                    else
                    {
                        udfnclose();
                    }
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Focus();
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
            finally
            {
                btnSave.Enabled = true;
                btnSave.Focus();
            }
        }
        private void udfnclear()
        {
            try
            {
                txtBasketNo.Text = "";
                cmbBasketType.SelectedValue = -1;
                this.ActiveControl = cmbBasketType;
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
                bool blnErrorFlag = false;
                if (Convert.ToString(txtBasketNo.Text).Trim() == "")
                {
                    epBasket.SetError(txtBasketNo, "Please enter basket no.");
                    txtBasketNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBasketNo.ShowAlways = true;
                    tpBasketNo.Show("Please enter basket no.", txtBasketNo, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbBasketType.SelectedValue).Trim() == "-1" || Convert.ToString(cmbBasketType.SelectedValue).Trim() == "0")
                {
                    epBasket.SetError(cmbBasketType, "Please select basket type.");
                    cmbBasketType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBasketType.ShowAlways = true;
                    tpBasketType.Show("Please select basket type.", cmbBasketType, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
                MainForm.objCP_Citylist.udfnList(); 
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
        private void cmbBasketType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBasketType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
           
        private void CP_City_KeyDown(object sender, KeyEventArgs e)
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
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
          
           
        private void CP_City_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        private void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbBasketType.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbBasketType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBasketNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbBasketType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbBasketType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbBasketType.SelectedValue).Trim() == "-1" || Convert.ToString(cmbBasketType.SelectedValue).Trim() == "0")
                {
                    epBasket.SetError(cmbBasketType, "Please select basket type.");
                    cmbBasketType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBasketType.ShowAlways = true;
                    tpBasketType.Show("Please select basket type.", cmbBasketType, 5000); 
                }
                else
                {
                    cmbBasketType.BackColor = Color.White;
                    epBasket.Clear();
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBasketNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBasketNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBasketNo_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBasketNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtBasketNo.Text.Trim()) == "")
                {
                    epBasket.SetError(txtBasketNo, "Please enter basket number.");
                    txtBasketNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBasketNo.ShowAlways = true;
                    tpBasketNo.Show("Please enter basket number.", txtBasketNo, 5000);
                }
                else
                {
                    txtBasketNo.BackColor = Color.White;
                    epBasket.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBasketNo_KeyPress(object sender, KeyPressEventArgs e)
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
