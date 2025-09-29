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
    public partial class Form1 : Form
    {
        private DataGridView dgv;  // single grid (right side)
        private TreeView tvMenu;   // accordion (left side)

        public Form1()
        {
            InitializeComponent();
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            // === Split Container (Left = Accordion, Right = Grid) ===
            SplitContainer split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 50
            };
            this.Controls.Add(split);

            // === Left: Accordion as TreeView ===
            tvMenu = new TreeView
            {
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Segoe UI", 10),
                ShowLines = false,
                ShowPlusMinus = true
            };

            // Root nodes
            TreeNode accounts = new TreeNode("Accounts");
            accounts.Nodes.Add("Purchase Entry");
            accounts.Nodes.Add("Purchase Approval");

            TreeNode masters = new TreeNode("Masters");
            masters.Nodes.Add("City");
            masters.Nodes.Add("Item Group");
            masters.Nodes.Add("Item Sub Group");
            masters.Nodes.Add("Product");

            TreeNode reports = new TreeNode("Reports");
            TreeNode rptMasters = new TreeNode("Masters");
            rptMasters.Nodes.Add("City");
            rptMasters.Nodes.Add("Item Group");
            rptMasters.Nodes.Add("Item Sub Group");
            rptMasters.Nodes.Add("Product");
            reports.Nodes.Add(rptMasters);

            tvMenu.Nodes.Add(accounts);
            tvMenu.Nodes.Add(masters);
            tvMenu.Nodes.Add(reports);

            tvMenu.ExpandAll();
            tvMenu.AfterSelect += TvMenu_AfterSelect;

            split.Panel1.Controls.Add(tvMenu);

            // === Right: Single DataGridView ===
            dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            split.Panel2.Controls.Add(dgv);
        }

        // Handle accordion selection
        private void TvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            if (e.Node.Text == "Accounts")
            {
                SetupAccountOrMasterColumns();
                dgv.Rows.Add("Purchase Entry");
                dgv.Rows.Add("Purchase Approval");
            }
            else if (e.Node.Text == "Masters")
            {
                SetupAccountOrMasterColumns();
                dgv.Rows.Add("City");
                dgv.Rows.Add("Item Group");
                dgv.Rows.Add("Item Sub Group");
                dgv.Rows.Add("Product");
            }
            else if (e.Node.Text == "Reports")
            {
                SetupReportColumns();
                dgv.Rows.Add("City");
                dgv.Rows.Add("Item Group");
                dgv.Rows.Add("Item Sub Group");
                dgv.Rows.Add("Product");
            }
            else if (e.Node.Parent != null) // Child clicked
            {
                if (IsReportNode(e.Node))
                {
                    SetupReportColumns();
                }
                else
                {
                    SetupAccountOrMasterColumns();
                }

                dgv.Rows.Add(e.Node.Text);
            }
        }

        // === Full column set (Accounts / Masters) ===
        private void SetupAccountOrMasterColumns()
        {
            dgv.Columns.Add("Module", "Module");
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "FullAccess", HeaderText = "Full Access" });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "View", HeaderText = "View" });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Create", HeaderText = "Create" });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Update", HeaderText = "Update" });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Delete", HeaderText = "Delete" });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Print", HeaderText = "Print" });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Excel", HeaderText = "Excel" });

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn
            {
                Name = "SplFields",
                HeaderText = "Spl Fields",
                Image = SystemIcons.Information.ToBitmap(),
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dgv.Columns.Add(imgCol);
        }

        // === Limited column set (Reports) ===
        private void SetupReportColumns()
        {
            dgv.Columns.Add("Module", "Module");
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "View", HeaderText = "View" });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Print", HeaderText = "Print" });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Excel", HeaderText = "Excel" });

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn
            {
                Name = "SplFields",
                HeaderText = "Spl Fields",
                Image = SystemIcons.Information.ToBitmap(),
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dgv.Columns.Add(imgCol);
        }

        // Helper: check if node belongs to Reports
        private bool IsReportNode(TreeNode node)
        {
            if (node.Parent == null) return false;
            if (node.Parent.Text == "Reports") return true;
            if (node.Parent.Parent != null && node.Parent.Parent.Text == "Reports") return true;
            return false;
        }
    }
}
