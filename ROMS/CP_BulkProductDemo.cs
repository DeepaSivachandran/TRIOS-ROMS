using Gma.QrCodeNet.Encoding.DataEncodation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ROMS
{
    public partial class CP_BulkProductDemo : Form
    {
        private SecurityController _security;
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varPasskey = "";
        public string varbrandcode;
        public string pbFormStatus;
        public string varUserId = "";
        public int flag = 0;
        public CP_BulkProductDemo(DataTable objDataBulk)
        {
            InitializeComponent();
            if (objDataBulk.Rows.Count > 0)
            {
                udfnLoad(objDataBulk);
                lblNoRecordsFound.Visible = false;
            }
            else {
                lblNoRecordsFound.Visible = true;
            }
        }
        public void udfnLoad(DataTable objDataBulk) {
            try
            { // Fixed columns that should always remain
                string[] fixedColumns =
                {
                    "S.No.",
                    "PRODUCTID",
                    "P.I Code",
                    "PRG_TName",
                    "Unit"
                };
                // Find dynamic columns containing only -1
                foreach (DataColumn column in objDataBulk.Columns
                             .Cast<DataColumn>().ToList())
                {
                    if (fixedColumns.Contains(column.ColumnName))
                        continue;
                    bool allMinusOne = objDataBulk.AsEnumerable().All(row =>
                        !row.IsNull(column) &&
                        Convert.ToString(row[column]) == "-1");
                    if (allMinusOne)
                    {
                        objDataBulk.Columns.Remove(column);
                    }
                }
                // Bind filtered data
                grdProducts.DataSource = objDataBulk;
                // Hide required columns
                if (grdProducts.Columns.Contains("PRODUCTID"))
                    grdProducts.Columns["PRODUCTID"].Visible = false;               
                grdProducts.Columns["P.I Code"].Width = 120;
                grdProducts.Columns["S.No."].Width = 50;
                grdProducts.Columns["Product Name in Tamil"].Width = 350;
                grdProducts.Columns["UNIT"].Width = 50; 
                grdProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                grdProducts.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                grdProducts.Columns["Product Name in Tamil"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdProducts.Columns["P.I Code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdProducts.Columns["UNIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void grdProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                var col = grdProducts.Columns[e.ColumnIndex];
                // Only for Live / New columns
                if (e.Value != null && e.Value.ToString() == "-1")
                {
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.LightGray;
                    e.Value = "";
                }
                if (col.HeaderText.Contains("New") == true)
                {

                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
