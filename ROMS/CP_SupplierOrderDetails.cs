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
    public partial class CP_SupplierOrderDetails : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public CP_SupplierOrderDetails()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSave_Leave(object sender, EventArgs e)
        {

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
                udfnclose();
                // MainForm.objCP_CompanyList.udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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


            // grddays.DataSource = dataTable;
        }
        private void btnClose_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnClose_Leave(object sender, EventArgs e)
        {

        }
       

        private void CP_SupplierOrderDetails_Load(object sender, EventArgs e)
        {
            try
            {
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
