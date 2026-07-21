using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    //Created By:Sathish ; Created On:-11/08/2023
    public partial class CP_Bulk_Image_Update : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();

        DataTable dtSubGroup;
        DataTable dtProducts;

        public CP_Bulk_Image_Update()
        {
            InitializeComponent();
            windowControl.Initialize(tsImageList, this);
        }
        private void CP_Bulk_Image_Updatelist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    windowControl?.TriggerClose();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Bulk_Image_Updatelist_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProducts();
                udfnList();
                LoadTreeView();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LoadProducts()
        {
            SPDataService objspdservice = new SPDataService();

            DataSet ds = objspdservice.udfnSubGroupList(
                            20,
                            0,
                            "",
                            0,
                            0,
                            "",
                            0,
                            0,
                            0,
                            0,
                            0);

            objspdservice.CloseConnection();

            dtProducts = ds.Tables[0];
        }
        public void udfnList()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objspdservice.udfnSubGroupList(19, 0, "", 0, 0, "", 0, 0, 0, 0, 0);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdSubgroups.Rows.Add(false, objDs.Tables[0].Rows[i]["SubGroup"].ToString(), objDs.Tables[0].Rows[i]["ProductCount"].ToString(), objDs.Tables[0].Rows[i]["ImageName"].ToString(), objDs.Tables[0].Rows[i]["SGID"].ToString());
                            }
                            grdSubgroups.ClearSelection();
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
        
        private void LoadTreeView()
        {
            try
            {
                tvSubgroupProducts.BeginUpdate();
                tvSubgroupProducts.Nodes.Clear();

                SPDataService objspdservice = new SPDataService();

                DataSet ds = objspdservice.udfnSubGroupList(20, 0, "", 0, 0, "", 0, 0, 0, 0, 0);

                objspdservice.CloseConnection();

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return;

                BindTree(ds.Tables[0]);

                tvSubgroupProducts.CollapseAll();
                if (tvSubgroupProducts.Nodes.Count > 0)
                {
                    tvSubgroupProducts.Nodes[0].EnsureVisible();
                    tvSubgroupProducts.TopNode = tvSubgroupProducts.Nodes[0];
                }
                tvSubgroupProducts.EndUpdate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BindTree(DataTable dt)
        {
            tvSubgroupProducts.Nodes.Clear();

            tvSubgroupProducts.ImageList = imageList1;

            Dictionary<int, TreeNode> groups = new Dictionary<int, TreeNode>();

            foreach (DataRow row in dt.Rows)
            {
                int subgroupID = Convert.ToInt32(row["PR_PRSGID"]);
                string subgroup = row["Subgroup"].ToString();
                string product = row["Product"].ToString();

                TreeNode parentNode;

                if (!groups.ContainsKey(subgroupID))
                {
                    parentNode = new TreeNode(subgroup);

                    parentNode.Tag = subgroupID;

                    parentNode.ImageKey = "Folder.png";
                    parentNode.SelectedImageKey = "Folder.png";

                    groups.Add(subgroupID, parentNode);

                    tvSubgroupProducts.Nodes.Add(parentNode);
                }
                else
                {
                    parentNode = groups[subgroupID];
                }

                TreeNode child = new TreeNode(product);

                child.Tag = subgroupID;

                child.ImageKey = "Product.png";
                child.SelectedImageKey = "Product.png";

                parentNode.Nodes.Add(child);
            }

            tvSubgroupProducts.CollapseAll();
        }
        private void grdSubgroups_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (grdSubgroups.Columns[e.ColumnIndex].Name == "clmProduct")
                {
                    e.Value = "▶ " + e.Value + " Products";
                    e.FormattingApplied = true;
                }
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
                // Save logic here
                udfnSave();
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
        public void udfnSave()
        {
            try
            {
                btnSave.Enabled = false;
                string varResult = ""; string varOriginator = "Product Sub Group Image Mapping";
                
                SPDataService objDser = new SPDataService();
                if (grdSubgroups.Rows.Count > 0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(60);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                }
                else
                {
                    varResult = objDser.udfnSubGroup(3, 0, 0, "", "", 0, 0, 0, 0, varOriginator, "", MainForm.pbUserID, 0, 0, 0, "", "",0,0);
                    objDser.CloseConnection();
                    btnSave.Enabled = true;
                    if (varResult.Split('~')[0] == "3")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnList();
                    }
                    else if (varResult.Split('~')[0] == "4")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Focus();
                    }
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
        }
    }
}
