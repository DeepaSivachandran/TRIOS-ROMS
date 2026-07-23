using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS.Service_Class
{
    public static class DataGridViewExtensions
    { 
       public static void ScrollToMatchingRow(this DataGridView dgv, string columnName, string searchText)
       {
            if (dgv == null || dgv.DataSource == null || searchText=="")
            {
                dgv.Visible = false;
                return;
            }

            if (!dgv.Columns.Contains(columnName))
                return;

            int columnIndex = dgv.Columns[columnName].Index;

            // If the search text is empty, reset to the first row
            if (string.IsNullOrWhiteSpace(searchText))
            {
                dgv.Visible = true;
                dgv.BringToFront();
                dgv.ClearSelection();
                dgv.CurrentCell = dgv.Rows[0].Cells[columnIndex];
                dgv.Rows[0].Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = 0;
                return;
            }
            // Otherwise, perform the search loop
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].IsNewRow)
                    continue;

                string value = Convert.ToString(dgv.Rows[i].Cells[columnIndex].Value);

                if (value.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    dgv.Visible = true;
                    dgv.BringToFront();
                    dgv.ClearSelection();
                    dgv.CurrentCell = dgv.Rows[i].Cells[columnIndex];
                    dgv.Rows[i].Selected = true;
                    dgv.FirstDisplayedScrollingRowIndex = i;
                    return;
                }
            }
            // No match found: Hide the grid automatically
            dgv.Visible = false;
            return;
        }
    }
}
