using ROMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_Rate_Change : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;

        public int varUpDownKey = 0;
        public int varproductcode=0;
        public string varcompanycode;
        public int pbFormStatus=0;
        public string varstatecode = "";
        public string varSubgroupId = "";
        public string vargroupId = "";
        public string varupdate = "0";
        public int varProductload = 0, ratetype = 0;
        public decimal Rrate = 0,prevRrate = 0,Wrate = 0, prevWrate = 0 , rate = 0 , prevrate = 0;

         

        //tool tip
        private ToolTip tpRRate = new ToolTip();
        private ToolTip tpWRate = new ToolTip();
        private ToolTip tpVerifier = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        public CP_Rate_Change()
        {
            InitializeComponent();
        }
         
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean blnErrorFlag = false;
                if ((txtRRateLive.Text.Contains(".") && txtRRateLive.Text.Length < 2) || Convert.ToString(txtRRateLive.Text).Trim() == "")
                {
                    errItems.SetError(txtRRateLive, "Please enter valid rate");
                    txtRRateLive.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRRate.ShowAlways = true;
                    tpRRate.Show("Please enter valid rate", txtRRateLive, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtTeller.Text).Trim() == "")
                {
                    errItems.SetError(txtTeller, "Please enter valid name");
                    txtTeller.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerifier.ShowAlways = true;
                    tpVerifier.Show("Please enter valid name", txtTeller, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(lblProductcode.Text).Trim() == "" || Convert.ToString(lblProductcode.Text).Trim() == "0")
                {
                    errItems.SetError(txtProductName, "Please enter valid product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter valid product", txtProductName, 5000);
                    blnErrorFlag = true;
                }
                if (ratetype == 448)
                {

                    if ((txtWRateLive.Text.Contains(".") && txtWRateLive.Text.Length < 2) || Convert.ToString(txtWRateLive.Text).Trim() == "")
                    {
                        errItems.SetError(txtWRateLive, "Please enter valid rate");
                        txtWRateLive.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpWRate.ShowAlways = true;
                        tpWRate.Show("Please enter valid rate", txtWRateLive, 5000);
                        blnErrorFlag = true;
                    }

                    if (Convert.ToString(txtWRateLive.Text).Trim() != "" && Convert.ToString(txtRRateLive.Text).Trim() != "")
                    {
                        if (Convert.ToDecimal(txtRRateLive.Text) < Convert.ToDecimal(txtWRateLive.Text))
                        {
                            errItems.SetError(txtWRateLive, "Whole sale rate should be lesser than retail rate!");
                            txtWRateLive.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpWRate.ShowAlways = true;
                            tpWRate.Show("Whole sale rate should be lesser than retail rate!", txtWRateLive, 5000);
                            blnErrorFlag = true;
                        }
                    }
                    if (Convert.ToString(txtRRateLive.Text).Trim() != "" && Convert.ToString(txtWRateLive.Text).Trim() != "")
                    {
                        if (Convert.ToDecimal(txtRRateLive.Text) == 0 && Convert.ToDecimal(txtWRateLive.Text) > 0)
                        {
                            txtWRateLive.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            SPDataService objDataService = new SPDataService();
                            string varMessage = objDataService.udfnGetMessages(157);
                            objDataService.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            blnErrorFlag = true;
                        }
                    }
                }
                
                if (blnErrorFlag == false)
                {
                    udfnSave();
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
                double varwrate = 0;
                prevRrate = 0;
                prevWrate = 0;
                if (txtWRateLive.Text != "")
                {
                    varwrate = Convert.ToDouble(txtWRateLive.Text);

                }
                if (txtRRatePrev.Text != "")
                {
                    prevRrate = Convert.ToDecimal(txtRRatePrev.Text); 
                }
                if (txtWRatePrev.Text != "")
                {
                    prevWrate = Convert.ToDecimal(txtWRatePrev.Text);
                }
                



                TRN_RateChange objRateChange = new TRN_RateChange();
                objRateChange.paraViewType = 0;
                objRateChange.paraProductID = Convert.ToInt32(lblProductcode.Text);
                objRateChange.paraRRate = Convert.ToDouble(txtRRateLive.Text);
                objRateChange.paraWRate = varwrate;
                objRateChange.RRate_Prev = Convert.ToDouble(prevRrate);
                objRateChange.WRate_Prev = Convert.ToDouble(prevWrate);
                objRateChange.paraTeller = Convert.ToString(txtTeller.Text).Trim();
                objRateChange.paraType = ratetype;
                objRateChange.paraOriginator = "Rate Change";

                SPDataService objspservice = new SPDataService();
                string varResult  = objspservice.udfnRateChange(objRateChange);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    udfnclear();
                    varupdate = "1";
                    //udfnclose();
                    txtProductName.Focus();
                    MainForm.objCP_Rate_ChangeList.udfnList();
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
                txtProductName.Text = "";
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
                lvVerified1.Visible = false;
                lblProductcode.Text = ""; 
                lblPurLocation.Text = "";
                lblPurRack.Text = "";
                lblSalesLocation.Text = "";
                lblSalesRack.Text = "";
                lblShelflife.Text = "";
                lblWholesale.Text = "";
                lblBulk.Text = "";
                txtLastChanged.Text = "";
                txtLastTeller.Text = "";
                txtsystem.Text = "";
                lblStockQty.Text = ""; 
                lblCurrentStock.Visible = false;
                lblStockQty.Visible = false;

                Rrate = 0;
                prevRrate = 0;
                Wrate = 0;
                prevWrate = 0;
                ratetype = 0;
                rate = 0;
                prevrate = 0;
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
                MainForm.objCP_Rate_ChangeList.udfnList();
                MainForm.objCP_Rate_ChangeList.grdItemList.ClearSelection();
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
                    
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    txtRRateLive.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterProduct.Focus();
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }
                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnProductEvent();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtRRateLive.Focus();
                    }
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
                if (varUpDownKey == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 88;
                        objMR_Product.paraProductName = txtProductName.Text;
                        objMR_Product.paraFlag = 1;                         //Load Only Eligible for Sales Products
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Tamil Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "P.I Code";
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 350;
                                    DGV_FilterProduct.Columns["UNIT"].Width = 50;
                                    DGV_FilterProduct.Columns["R.Rate"].Width = 50;
                                    DGV_FilterProduct.Columns["W.Rate"].Width = 50;
                                    DGV_FilterProduct.Columns["UNIT"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 0;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["R.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["W.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);



                                    DGV_FilterProduct.Columns["PREV R.Rate"].Visible = false;
                                    DGV_FilterProduct.Columns["PREV W.Rate"].Visible = false;
                                    DGV_FilterProduct.Columns["PRPM_TYPE"].Visible = false;
                                    DGV_FilterProduct.Columns["PRPM_RATE"].Visible = false;
                                    DGV_FilterProduct.Columns["PRPR_RATE_PREV"].Visible = false;
                                    DGV_FilterProduct.Columns["R.Rate"].Visible = false;
                                    DGV_FilterProduct.Columns["W.Rate"].Visible = false;
                                     


                                    DGV_FilterProduct.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
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

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductName.Text == "")
                {
                    errItems.SetError(txtProductName, "Please enter valid product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter valid product", txtProductName, 5000);
                }
                else
                {
                    txtProductName.BackColor = Color.White;
                    errItems.Clear();
                }
                txtRRatePrev.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        

        private void txtRRateLive_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
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
                    if (txtWRateLive.Enabled ==true)
                    {
                        txtWRateLive.Focus();
                    }
                    else
                    {
                        txtTeller.Focus();
                    }
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
                if (txtRRateLive.Text == "")
                {
                    errItems.SetError(txtRRateLive, "Please enter valid rate");
                    txtRRateLive.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRRate.ShowAlways = true;
                    tpRRate.Show("Please enter valid rate", txtRRateLive, 5000);
                }
                else
                {
                    txtRRateLive.BackColor = Color.White;
                    errItems.Clear();
                }
                //}
                //txtWRateLive.Focus();
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
                if (txtWRateLive.Text == "")
                {
                    errItems.SetError(txtWRateLive, "Please enter valid rate");
                    txtWRateLive.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWRate.ShowAlways = true;
                    tpWRate.Show("Please enter valid rate", txtWRateLive, 5000);
                }
                else
                {
                    txtWRateLive.BackColor = Color.White;
                    errItems.Clear();
                } 
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
                if (txtTeller.Text.Trim() == "")
                {
                    errItems.SetError(txtTeller, "Please enter valid name");
                    txtTeller.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerifier.ShowAlways = true;
                    tpVerifier.Show("Please enter valid name", txtTeller, 5000);
                }
                else
                {
                    txtTeller.BackColor = Color.White;
                    errItems.Clear();
                }
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

        private void txtRRateLive_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtWRateLive_KeyPress(object sender, KeyPressEventArgs e)
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
        }
        public void udfnProductEvent()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    lblProductcode.Text =  DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                    Rrate = Convert.ToDecimal(DGV_FilterProduct.SelectedRows[0].Cells["R.Rate"].Value);
                    prevRrate = Convert.ToDecimal( DGV_FilterProduct.SelectedRows[0].Cells["PREV R.Rate"].Value); 
                    Wrate = Convert.ToDecimal(DGV_FilterProduct.SelectedRows[0].Cells["W.Rate"].Value);
                    prevWrate = Convert.ToDecimal(DGV_FilterProduct.SelectedRows[0].Cells["PREV W.Rate"].Value);
                    ratetype = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PRPM_TYPE"].Value);
                    rate = Convert.ToDecimal(DGV_FilterProduct.SelectedRows[0].Cells["PRPM_RATE"].Value);
                    prevrate = Convert.ToDecimal(DGV_FilterProduct.SelectedRows[0].Cells["PRPR_RATE_PREV"].Value);


                    lblPICode.Text = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value);

                    udfnListviewProduct();
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_FilterProduct.Visible = false;
            }
        }


        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                udfnProductEvent();
                txtRRateLive.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_FilterProduct.Visible = false;
            }
        }

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    udfnProductEvent();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
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

        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                { 
                    if (lblProductcode.Text != "" && lblProductcode.Text != "0")
                    {
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
                                    lblSubGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Subgroup Name"]);
                                    lblGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Group Name"]);
                                    lblProductName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ENAME"]);
                                    lblUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["UT_Symbol"]);
                                    txtRRatePrev.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RetailRate"]);
                                    txtRRateLast.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RetailRate_Prev"]);
                                    txtWRatePrev.Text = Convert.ToString(objDs.Tables[0].Rows[0]["WholeSaleRate"]);
                                    txtWRateLast.Text = Convert.ToString(objDs.Tables[0].Rows[0]["WholeSaleRate_Prev"]);

                                    lblPurLocation.Text = Convert.ToString(objDs.Tables[0].Rows[0]["LOCATION PURCHASE Name"]);
                                    lblPurRack.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RACK LOCATION Name"]);
                                    lblSalesLocation.Text = Convert.ToString(objDs.Tables[0].Rows[0]["LOCATION SALES Name"]);
                                    lblSalesRack.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RACK SALES Name"]);
                                    lblShelflife.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PRODUCT EXPIRY"]);
                                    lblWholesale.Text = Convert.ToString(objDs.Tables[0].Rows[0]["WMINSALE QTY"]);
                                    lblBulk.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit Per box"]);

                                    txtLastChanged.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Last Changed"]);
                                    txtLastTeller.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Last Teller"]);
                                    txtsystem.Text = Convert.ToString(objDs.Tables[0].Rows[0]["System"]);
                                    if (Convert.ToString(objDs.Tables[0].Rows[0]["CurrentStock"]).Trim() == "")
                                    {
                                        lblCurrentStock.Visible = false;
                                        lblStockQty.Visible = false;
                                    }
                                    else
                                    {
                                        lblCurrentStock.Visible = true;
                                        lblStockQty.Visible = true;
                                        lblStockQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["CurrentStock"]) + " " + Convert.ToString(objDs.Tables[0].Rows[0]["UT_Symbol"]);
                                    }


                                    txtWRatePrev.Enabled = false;
                                    txtWRateLast.Enabled = false;

                                    if (ratetype != 448)
                                    { 
                                        txtRRatePrev.Text = Convert.ToString(rate);
                                        txtRRateLast.Text = Convert.ToString(prevrate); 
                                        txtWRatePrev.Text = "0";
                                        txtWRateLast.Text = "0"; 
                                        txtWRateLive.Enabled = false;
                                        txtWRateLive.BackColor = System.Drawing.SystemColors.Control;
                                        txtDWSaleRate.Text = "Rate";
                                    }
                                    else
                                    { 
                                        txtWRateLive.Enabled = true;
                                        txtRRatePrev.Text = Convert.ToString(Rrate);
                                        txtRRateLast.Text = Convert.ToString(prevRrate);
                                        txtWRatePrev.Text = Convert.ToString(Wrate);
                                        txtWRateLast.Text = Convert.ToString(prevWrate);
                                        txtWRateLive.BackColor = Color.White;
                                        txtDWSaleRate.Text = "R.Rate";
                                    }


                                    lblProductName.Text = txtProductName.Text;
                                }
                                else { udfnclear(); }
                            }
                            else { udfnclear(); }
                        }
                        else { udfnclear(); }
                    }
                    else { udfnclear(); }
                }
                else { udfnclear(); }
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
    }
}


    