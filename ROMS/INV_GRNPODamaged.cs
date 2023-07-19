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
    public partial class INV_GRNPODamaged : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public INV_GRNPODamaged()
        {
            InitializeComponent();
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

        private void GrdGRNPODamaged_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                MainForm.objPUR_PurchaseOrderDamage = new PUR_PurchaseOrderDamage();
                MainForm.objPUR_PurchaseOrderDamage.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
            /*
            this.grdGRNPODamaged.Rows.Add("five", "six", "seven", "eight");
            this.grdGRNPODamaged.Rows.Insert(1, "1234", "19/08/2023", "20", "View");
            DataGridViewRow row = (DataGridViewRow)grdGRNPODamaged.Rows[0].Clone();
            row.Cells[0].Value = 1;
            row.Cells[1].Value = 1234;
            row.Cells[2].Value = 19 / 07 / 2023;
            row.Cells[3].Value = 20;
            row.Cells[4].Value ="";
            grdGRNPODamaged.Rows.Add(row);
            */
        }
        private void BindDataGrid()
        {
            try
            {
                string[] item = new string[30];
                ListViewItem listitem = new ListViewItem(); DataTable dataTable = new DataTable();
                dataTable.Columns.Add("s.no", typeof(string));
                dataTable.Columns.Add("invoiceno", typeof(string));
                dataTable.Columns.Add("invoicedate", typeof(string));
                dataTable.Columns.Add("Totalproduct", typeof(string)); 
                dataTable.Rows.Add("1","1234","19/07/2023","20");
                //dataTable.Rows.Add("Tuesday");
                // dataTable.Rows.Add("Wednesday");
                //dataTable.Rows.Add("Thursday");
                //dataTable.Rows.Add("Friday");
                //dataTable.Rows.Add("Saturday");
                //dataTable.Rows.Add("Sunday");


                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string sno = dataTable.Rows[i]["s.no"].ToString();
                    string invoiceno = dataTable.Rows[i]["invoiceno"].ToString();
                    string invoicedate = dataTable.Rows[i]["invoicedate"].ToString();
                    string totalproduct = dataTable.Rows[i]["Totalproduct"].ToString();

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(grdGRNPODamaged);
                    row.Cells[1].Value = sno;
                    row.Cells[2].Value = invoiceno;
                    row.Cells[3].Value = invoicedate;
                    row.Cells[4].Value = totalproduct; 
                    grdGRNPODamaged.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }


            // grddays.DataSource = dataTable;
        }

        private void INV_GRNPODamaged_Load(object sender, EventArgs e)
        {
            BindDataGrid();
        }
    }
}
