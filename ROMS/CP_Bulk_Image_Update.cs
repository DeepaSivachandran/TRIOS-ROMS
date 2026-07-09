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

                tvSubgroupProducts.ExpandAll();
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
            TreeNode parentNode = null;

            int previousID = -1;

            foreach (DataRow row in dt.Rows)
            {
                int subgroupID = Convert.ToInt32(row["PR_PRSGID"]);

                if (previousID != subgroupID)
                {
                    parentNode = new TreeNode(row["Subgroup"].ToString());

                    parentNode.Name = subgroupID.ToString();

                    //Store subgroup id if required
                    parentNode.Tag = subgroupID;

                    tvSubgroupProducts.Nodes.Add(parentNode);

                    previousID = subgroupID;
                }

                TreeNode childNode = new TreeNode(row["Product"].ToString());

                childNode.Tag = subgroupID;

                parentNode.Nodes.Add(childNode);
            }
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
    }
}
