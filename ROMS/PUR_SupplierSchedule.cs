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
    public partial class PUR_SupplierSchedule : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public PUR_SupplierSchedule()
        {
            InitializeComponent();
        }


        private void udfnEdit()
        {
            try
            {
                if (varbrandcode != "")
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS = new DataSet();
                    //   objDS = objspservice.udfnSPBrandList("EditLoad", varbrandcode, MainForm.pbUserID, MainForm.pbIpAddress);
                    objspservice.CloseConnection();

                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                           
                        }
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

        private void txtEBrandName_Enter(object sender, EventArgs e)
        {

        }

        private void txtEBrandName_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtEBrandNameInEnglish.BackColor = Color.White;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                errBrand.Clear();
                
                SPDataService objspdservice = new SPDataService();
                string result = "";
                if (btnSave.Text == "Save")
                {
                    //   result = objspdservice.udfnSPBrandMaster("Create", "0",txtTBrandName.Text,txtEBrandName.Text,txtTLabelName.Text,txtELabelName.Text, MainForm.pbUserID, MainForm.pbIpAddress, "Brand Create");
                }
                else
                {
                    //   result = objspdservice.udfnSPBrandMaster("Update", varbrandcode, txtTBrandName.Text, txtEBrandName.Text, txtTLabelName.Text, txtELabelName.Text, MainForm.pbUserID, MainForm.pbIpAddress, "Brand Update");
                }
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnSave.Text == "Update")
                    {
                        this.Close();
                    }
                    else
                    {
                        if (pbFormStatus == "Finished")
                        {
                            pbFormStatus = "";
                            //MainForm.objCP_Product.varBrandCode = varvalue[2];
                            //MainForm.objCP_Product.varBrandName = txtEBrandName.Text;
                            //MainForm.objCP_Product.udfnLoadBrand();
                            this.Close();
                        }
                        udfnclear();
                    }

                    MainForm.objCP_BrandList.udfnList();



                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                objspdservice.CloseConnection();




            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnclear()
        {
           
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

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose.Focus();
                }
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
                btnSave.BackColor = Color.White;
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
              //  udfnclose();
                //  MainForm.objCP_BrandList.udfnList();
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

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

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
                btnClose.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Brand_Leave(object sender, EventArgs e)
        {
            try
            {
                tpbrandname.Active = false;
                tpbrandtamilname.Active = false;
                tpbltname.Active = false;
                tpblename.Active = false;
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
               //     udfnclose();
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

        private void Grbform_Enter(object sender, EventArgs e)
        {

        }

        private void GrdGroupList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
     
        private void BindDataGrid()
        {
            try
            {
                string[] item = new string[30];
                ListViewItem listitem = new ListViewItem(); DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Day", typeof(string)); 

                dataTable.Rows.Add("Monday");
                dataTable.Rows.Add("Tuesday");
                dataTable.Rows.Add("Wednesday");
                dataTable.Rows.Add("Thursday");
                dataTable.Rows.Add("Friday");
                dataTable.Rows.Add("Saturday");
                dataTable.Rows.Add("Sunday");


                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string day = dataTable.Rows[i]["Day"].ToString();
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(grddays);
                    row.Cells[1].Value = day;
                    grddays.Rows.Add(row);

                    //item[0] = "";
                    //item[1] = dataTable.Rows[i]["Day"].ToString();
                    //listitem = new ListViewItem(item);
                    //grddays.Rows.Add(item[0],item[1]);
                } 
                // Assign the DataTable as the data source for the DataGridView 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

             
        }

        private void PUR_SupplierSchedule_Load(object sender, EventArgs e)
        {
            try
            { 
                udfnEdit();
                BindDataGrid();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Grddays_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            try
            {
                if (grddays.Columns[e.ColumnIndex].Name == "chkdays" && e.RowIndex >= 0)
                {
                    DataGridViewCheckBoxCell checkBoxCell = grddays.Rows[e.RowIndex].Cells["chkdays"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {
                        checkBoxCell.Value = !(bool)(checkBoxCell.Value ?? false);
                        grddays.EndEdit(); // Commit the change
                    }
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
    
    

