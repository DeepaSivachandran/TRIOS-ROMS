using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;
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
    public partial class CP_Rate_Change : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;

        public int varproductcode=0;
        public string varcompanycode;
        public int pbFormStatus=0;
        public string varstatecode = "";
        public string varSubgroupId = "";
        public string vargroupId = "";
        public string varupdate = "0";
        public int varProductload = 0;
        //tool tip
        private ToolTip tpContactNo = new ToolTip();
        private ToolTip tpAltContactNo = new ToolTip();
        private ToolTip tpemail = new ToolTip();
        public CP_Rate_Change()
        {
            InitializeComponent();
        }
         
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                //if (txtReOrderQty.Text.Contains(".") && txtReOrderQty.Text.Length < 2)
                //{
                //    txtReOrderQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtReOrderQty, "Please enter valid reorder qty");
                //    return;
                //}
                //if (txtRMinSaleQty.Text.Contains(".") && txtRMinSaleQty.Text.Length < 2)
                //{
                //    txtRMinSaleQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtRMinSaleQty, "Please enter valid retail min sales stock");
                //    return;
                //}
                udfnSave(); 
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
            finally
            {
                btnSave.Enabled = true;
            }
        }

        public void udfnclear()
        {
            try
            {
                lblPICode.Text = "";
                lblProductName.Text = "";
                lblUnit.Text = "";
                lblGroup.Text = "";
                lblSubGroup.Text = "";
                txtRRateLast.Text = "";
                txtRRatePrev.Text = "";
                txtRRateLive.Text = "";
                txtWRateLast.Text = "";
                txtWRateLive.Text = "";
                txtWRatePrev.Text = "";
                txtTeller.Text = "";
                lvproduct.Visible = false;
                lvVerified1.Visible = false;
                lblProductcode.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        public void udfncolorchange()
        {
            try
            {
                errItems.Clear(); 
                txtRRateLast.BackColor = Color.White;
                txtWRateLast.BackColor = Color.White;
                txtRRatePrev.BackColor = Color.White;
                txtWRatePrev.BackColor = Color.White;
                txtRRateLive.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }



        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.LemonChiffon;
                udfnHideLists();
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
                MainForm.objCP_Itemlist.udfnList();
                MainForm.objCP_Itemlist.grdItemList.ClearSelection();
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
                            

        private void CP_Product_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave_Click(sender, e); 
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        private void CP_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MainForm.varCloseFlag == 0)
                {
                    if (varupdate == "0")
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProductName_Enter(object sender, EventArgs e)
        {
            try
            { 
                txtProductName.BackColor = Color.LemonChiffon;
                udfnHideLists();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvproduct.Items.Count == 0 || txtProductName.Text == "")
                    {
                        lvproduct.Visible = false;
                    }
                    else
                    {
                        lvproduct.Focus();
                    }
                    if (lvproduct.Items.Count > 0)
                    {
                        lvproduct.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtRRateLive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductName.Text.Length > 0)
                {

                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 49;
                    objMR_Product.paraGroup = 0;
                    objMR_Product.paraSubgroup = 0;
                    objMR_Product.paraProductName = txtProductName.Text;
                    objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["UNIT"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    objList.SubItems[0].Font = new Font("Oswald Regular", 11.25F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.BringToFront();

                                lvproduct.Columns[0].Width = 100;
                                lvproduct.Columns[1].Width = 0;
                                lvproduct.Columns[2].Width = 250;
                                lvproduct.Columns[3].Width = 0;
                                lvproduct.Columns[4].Width = 70;
                            }
                        }
                    }
                }
                else
                {
                    lvproduct.Visible = false;
                    lvproduct.Items.Clear();
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

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.White;
                txtRRatePrev.Focus();
              //  lvproduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListviewProduct();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvproduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListviewProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[1].Text;
                    lblProductcode.Text = selectedItem.SubItems[3].Text;
                    if (lblProductcode.Text != "" && lblProductcode.Text != "0") {

                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 1;
                        objMR_Product.paraGroup = 0;
                        objMR_Product.paraSubgroup = 0;
                        objMR_Product.ParaProductCode = Convert.ToInt32(lblProductcode.Text);
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    lblPICode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PICODE"]);
                                    lblSubGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Subgroup Name"]);
                                    lblGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Group Name"]);
                                    lblProductName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ENAME"]);
                                    lblUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["UT_Symbol"]);
                                    txtRRateLast.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RetailRate"]);
                                    txtRRatePrev.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RetailRate_Prev"]);
                                    txtWRateLast.Text = Convert.ToString(objDs.Tables[0].Rows[0]["WholeSaleRate"]);
                                    txtWRatePrev.Text = Convert.ToString(objDs.Tables[0].Rows[0]["WholeSaleRate_Prev"]);
                                }
                                else { udfnclear(); }
                            }
                            else { udfnclear(); }
                        }
                        else { udfnclear(); }
                    }
                    udfnclear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvproduct.Visible = false;
            }
        }

        private void txtRRateLive_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRRateLive.BackColor = Color.LemonChiffon;
                udfnHideLists();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtWRateLive_Enter(object sender, EventArgs e)
        {
            try
            {
                txtWRateLive.BackColor = Color.LemonChiffon;
                udfnHideLists();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.LemonChiffon;
                udfnHideLists();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRRateLive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWRateLive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtWRateLive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTeller.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRRateLive_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRRateLive.BackColor = Color.White;
                txtWRateLive.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtWRateLive_Leave(object sender, EventArgs e)
        {
            try
            {
                txtWRateLive.BackColor = Color.White;
                txtTeller.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvVerified1.Items.Count == 0 || txtTeller.Text == "")
                    {
                        lvVerified1.Visible = false;
                    }
                    else
                    {
                        lvVerified1.Focus();
                    }
                    if (lvVerified1.Items.Count > 0)
                    {
                        lvVerified1.Items[0].Selected = true;
                    }
                }
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

        private void txtTeller_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTeller.Text.Length > 0)
                {
                    lvVerified1.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(14, txtTeller.Text.Trim(), 0, "", 1, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["EMP_Name"].ToString(), objDs.Tables[0].Rows[i]["EMPID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvVerified1.Columns[1].Width = 0;
                                    lvVerified1.Items.Add(objList);
                                }
                                lvVerified1.BringToFront();
                                lvVerified1.Visible = true;
                            }
                            else
                            {
                                lvVerified1.Visible = false;
                            }
                        }
                        else
                        {
                            lvVerified1.Visible = false;
                        }
                    }
                    else
                    {
                        lvVerified1.Visible = false;
                    }
                }
                else
                {
                    lvVerified1.Visible = false;
                    lvVerified1.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvVerified1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnVerified1();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvVerified1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnVerified1();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnVerified1()
        {
            try
            {
                if (txtTeller.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvVerified1.SelectedItems[0];
                    txtTeller.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvVerified1.Visible = false;
                btnSave.Focus();
            }
        }

        private void txtTeller_Leave(object sender, EventArgs e)
        {
            try
            {
                txtWRateLive.BackColor = Color.White;
                btnSave.Focus();
               // lvVerified1.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnHideLists() {
            try
            {
                lvproduct.Visible = false;
                lvVerified1.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Rate_Change_Load(object sender, EventArgs e)
        {
            try
            {
                udfnclear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}


    