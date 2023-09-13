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
    public partial class PUR_PurchaseOrder : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public PUR_PurchaseOrder()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Supplier = new CP_Supplier();
                MainForm.objCP_Supplier.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
      
        private void PUR_PurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {
                cmbReturnPolicy.Items.Add("Yes");
                cmbReturnPolicy.Items.Add("No");
                cmbReturnPolicy.SelectedIndex = 0;
                cmbReturnType.Items.Add("Any Time");
                cmbReturnType.Items.Add("Weekly");
                cmbReturnType.Items.Add("Monthly");
                cmbReturnType.Items.Add("Quarterly");
                cmbReturnType.SelectedIndex = 0;
                txtReturnText.Visible = false;
                cmbPolicyContent.Visible = false;
                txtNextLevel.Visible = false;
                cmbSecondLevel.Visible = false;
                dpPlanDate.MinDate = DateTime.Today;
                dpPlanDate.MaxDate = DateTime.MaxValue;
                dpPlanDate.Value = DateTime.Today;
                udfnList();
                grdPendingorder.Rows.Add("1","PO0001", "30/07/2023", "20");
                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfndelete()
        {
            try
            {
                if (grdsupplieradd.SelectedRows.Count > 0)
                {
                    string result = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {

                        SPDataService objspdservice = new SPDataService();
                        result = "";
                    //    result = objspdservice.udfnSPBrandMaster("Delete", grdBrandList.SelectedRows[0].Cells["BrandCode"].Value.ToString(), "", "","", "", MainForm.pbUserID, MainForm.pbIpAddress, "Brand Delete");

                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            udfnList();

                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void udfnEdit()
        {
            try
            {

                if (grdsupplieradd.SelectedRows.Count > 0)
                {
                    MainForm.objCP_Brand = new CP_Brand();
                    //MainForm.objCP_Brand.MdiParent = this.ParentForm; 
                    MainForm.objCP_Brand.ShowDialog();
                }

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
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdsupplieradd.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                //objDs = objdserv.udfnSPBrandList("List", "0", MainForm.pbUserID, MainForm.pbIpAddress);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdsupplieradd.DataSource = objDs.Tables[0];
                            grdsupplieradd.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdsupplieradd.Columns["Total No. of FG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdsupplieradd.Columns["Brand Name in Tamil"].Width = 275;
                            grdsupplieradd.Columns["Brand Name in English"].Width = 275;
                            grdsupplieradd.Columns["Label Name in Tamil"].Width = 275;
                            grdsupplieradd.Columns["Label Name in English"].Width = 275;
                            grdsupplieradd.Columns["BrandCode"].Visible = false;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
                udfnSearchGridHead();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdsupplieradd.ClearSelection(); 
            }
        }

        private void PUR_PurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    tsbEdit_Click(sender, e);
                }
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

        public void grdBrandList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void grdBrandList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) { udfnEdit(); }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        
         
        private void udfnSearchGridHead()
        {
            
        }
       
        private void grdBrandList_Scroll(object sender, ScrollEventArgs e)
        {
           
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
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
      

        private void btnDC_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PODamagedView = new PUR_PODamagedView();
                MainForm.objPUR_PODamagedView.ShowDialog();
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
                DialogResult result = MessageBox.Show("There are pending purchase returns for this supplier. Do you want to save & continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
                else
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void BtnNewUnit_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_BulkUnit = new PUR_BulkUnit();
                MainForm.objPUR_BulkUnit.ShowDialog(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnViewedProduct_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_POMappedProducts = new PUR_POMappedProducts();
                MainForm.objPUR_POMappedProducts.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void CmbDPurchaseShop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Grdsupplieradd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAppprove_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                MainForm.objPUR_GRNApprovalVerify.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnSalesmanSave_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                MainForm.objPUR_GRNApprovalVerify.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdPendingorder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_POProducts = new PUR_POProducts();
                MainForm.objPUR_POProducts.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbReturnPolicy.Select(int.MaxValue, 0)));
                if (cmbReturnPolicy.Text == "Yes") { cmbReturnType.Enabled = true; }
                else { cmbReturnType.Enabled = false; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                BeginInvoke(new Action(() => cmbReturnType.Select(int.MaxValue, 0)));
                if (cmbReturnType.Text == "Any Time")
                {
                    cmbPolicyContent.Items.Clear();
                    txtReturnText.Visible = false;
                    cmbPolicyContent.Visible = false;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
                }
                else if (cmbReturnType.Text == "Weekly")
                {
                    txtReturnText.Text = "Day";
                    cmbPolicyContent.Enabled = true;
                    cmbPolicyContent.Items.Clear();
                    cmbPolicyContent.Items.Add("Monday");
                    cmbPolicyContent.Items.Add("Tuesday");
                    cmbPolicyContent.Items.Add("Wednesday");
                    cmbPolicyContent.Items.Add("Thursday");
                    cmbPolicyContent.Items.Add("Friday");
                    cmbPolicyContent.Items.Add("Saturday");
                    cmbPolicyContent.Items.Add("Sunday");
                    cmbPolicyContent.SelectedIndex = 0;
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
                }
                else if (cmbReturnType.Text == "Monthly")
                {
                    txtReturnText.Text = "Week No.";
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    cmbPolicyContent.Items.Clear();
                    cmbPolicyContent.Items.Add("1st Week");
                    cmbPolicyContent.Items.Add("2nd Week");
                    cmbPolicyContent.Items.Add("3rd Week");
                    cmbPolicyContent.Items.Add("4th Week");
                    cmbPolicyContent.Items.Add("5th Week");
                    cmbPolicyContent.SelectedIndex = 0;
                    txtNextLevel.Text = "Day";
                    cmbSecondLevel.Items.Clear();
                    cmbSecondLevel.Items.Add("Monday");
                    cmbSecondLevel.Items.Add("Tuesday");
                    cmbSecondLevel.Items.Add("Wednesday");
                    cmbSecondLevel.Items.Add("Thursday");
                    cmbSecondLevel.Items.Add("Friday");
                    cmbSecondLevel.Items.Add("Saturday");
                    cmbSecondLevel.Items.Add("Sunday");
                    txtNextLevel.Visible = true;
                    cmbSecondLevel.Visible = true;
                    cmbSecondLevel.SelectedIndex = 0;
                }
                else if (cmbReturnType.Text == "Quarterly")
                {
                    txtReturnText.Text = "Month";
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    cmbPolicyContent.Items.Clear();
                    cmbPolicyContent.Items.Add("January");
                    cmbPolicyContent.Items.Add("February");
                    cmbPolicyContent.Items.Add("March");
                    cmbPolicyContent.Items.Add("April");
                    cmbPolicyContent.Items.Add("May");
                    cmbPolicyContent.Items.Add("June");
                    cmbPolicyContent.Items.Add("July");
                    cmbPolicyContent.Items.Add("August");
                    cmbPolicyContent.Items.Add("September");
                    cmbPolicyContent.Items.Add("October");
                    cmbPolicyContent.Items.Add("November");
                    cmbPolicyContent.Items.Add("December");
                    cmbPolicyContent.SelectedIndex = 0;
                    txtNextLevel.Visible = true;
                    cmbSecondLevel.Visible = true;
                    txtNextLevel.Text = "Day of the month";
                    cmbSecondLevel.Items.Clear();
                    cmbSecondLevel.Items.Add("1");
                    cmbSecondLevel.Items.Add("2");
                    cmbSecondLevel.Items.Add("3");
                    cmbSecondLevel.Items.Add("4");
                    cmbSecondLevel.Items.Add("5");
                    cmbSecondLevel.Items.Add("6");
                    cmbSecondLevel.Items.Add("7");
                    cmbSecondLevel.Items.Add("8");
                    cmbSecondLevel.Items.Add("9");
                    cmbSecondLevel.Items.Add("10");
                    cmbSecondLevel.Items.Add("11");
                    cmbSecondLevel.Items.Add("12");
                    cmbSecondLevel.Items.Add("13");
                    cmbSecondLevel.Items.Add("14");
                    cmbSecondLevel.Items.Add("15");
                    cmbSecondLevel.Items.Add("16");
                    cmbSecondLevel.Items.Add("17");
                    cmbSecondLevel.Items.Add("18");
                    cmbSecondLevel.Items.Add("19");
                    cmbSecondLevel.Items.Add("20");
                    cmbSecondLevel.Items.Add("21");
                    cmbSecondLevel.Items.Add("22");
                    cmbSecondLevel.Items.Add("23");
                    cmbSecondLevel.Items.Add("24");
                    cmbSecondLevel.Items.Add("25");
                    cmbSecondLevel.Items.Add("26");
                    cmbSecondLevel.Items.Add("27");
                    cmbSecondLevel.Items.Add("28");
                    cmbSecondLevel.Items.Add("29");
                    cmbSecondLevel.Items.Add("30");
                    cmbSecondLevel.Items.Add("31");
                    cmbSecondLevel.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPolicyContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPolicyContent.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSecondLevel.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnDamage_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PODamaged = new PUR_PODamaged();
                MainForm.objPUR_PODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
    }
}
