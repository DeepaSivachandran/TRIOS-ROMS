using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
     
namespace ROMS
{
    public partial class CP_Brand : Form
    {
        //DataValidation objValidation = new DataValidation();
        DataError objError;
        public int varbrandcode = 0;

        private ToolTip tpBrandNameInEnglish = new ToolTip();
        private ToolTip tpBrandNameInTamil = new ToolTip();

        public int varStatusid = 1; 
        public int varUpdate = 0;
        public int varFormFlag = 0;
        public int varId = 0;
        public int varModifiedFlag = 0;
        public string varBrandId = "";
        public string varGroupId = "";
        public string varSubGroupId = "";
        public int varmastertype = 0;
        public int varRefresh = 0;
        public int varmasterBrandtype = 0;
        public string varGroup = "";
        public string varGroupName = "";
        public string varSubGroupName = "";
        // Added by deepa on 01-09-2023
        public int varCheckAllFlag1 = 0;
        public int varCheckAllFlag2 = 0;
        public int varCheckAllFlag3 = 0;
        public DataTable dtSubGroup = new DataTable();
        public DataTable dtSubGroupAdd = new DataTable();
        public DataTable dtGroup = new DataTable();

        public CP_Brand()
        {
            InitializeComponent();
            dtGroup = new DataTable();
            dtGroup.Columns.Add("", typeof(Boolean));
            dtGroup.Columns.Add("Product Group Name in English", typeof(string));
            dtGroup.Columns.Add("T.S.Groups", typeof(string));
            dtGroup.Columns.Add("ID", typeof(int));

            dtSubGroup = new DataTable();
            dtSubGroup.Columns.Add("", typeof(Boolean));
            dtSubGroup.Columns.Add("Product Group", typeof(string));
            dtSubGroup.Columns.Add("Product Subgroup", typeof(string));
            dtSubGroup.Columns.Add("T.Pro", typeof(string));
            dtSubGroup.Columns.Add("Group Id", typeof(int));
            dtSubGroup.Columns.Add("Sub Group Id", typeof(int));

            // dtSubGroupAdd.Columns.Add("", typeof(Boolean));
            dtSubGroupAdd.Columns.Add("Selected Product Group", typeof(string));
            dtSubGroupAdd.Columns.Add("Selected Product Subgroup", typeof(string));
            dtSubGroupAdd.Columns.Add("T.Pro", typeof(string));
            dtSubGroupAdd.Columns.Add("Group Id", typeof(int));
            dtSubGroupAdd.Columns.Add("Sub Group Id", typeof(int));
            dtSubGroupAdd.Columns.Add("Products", typeof(string));
        }

        private void CP_Brand_Leave(object sender, EventArgs e)
        {
            try
            {
                tpBrandNameInEnglish.Active = false;
                tpBrandNameInTamil.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEdit()
        {
            try
            {
                string varSubgroupId = "";
                int varGroupId = 0;
                varBrandId = Convert.ToString(varId);
                if (varStatusid == 1)
                {
                    rbActive.Checked = true;
                }
                else
                {
                    rbInactive.Checked = true;
                }
                DataSet objDS = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDS = objdserv.udfnBrandList(1, varBrandId, 0, 0, 0, "", 0);
                objdserv.CloseConnection();
                if (objDS != null)
                {
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        txtEBrandNameInEnglish.Text = objDS.Tables[0].Rows[0]["BD_EName"].ToString().Replace("''", "'");
                        txtEBrandNameInTamil.Text = objDS.Tables[0].Rows[0]["BD_TName"].ToString().Replace("''", "'");
                    }
                    if (objDS.Tables[1].Rows.Count > 0)
                    {
                        if (varmastertype == 1)
                        {
                            dtSubGroupAdd.Rows.Clear();
                        }
                        for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                        {
                            //grdSubGroup.Rows.Add(Convert.ToString(objDS.Tables[1].Rows[i]["PRGID"]), Convert.ToString(objDS.Tables[1].Rows[i]["PRG_EName"]));
                            //dtSubGroupAdd.Rows.Add(false, grdSubGroup.Rows[i].Cells["Product Group"].Value, grdSubGroup.Rows[i].Cells["Product Subgroup"].Value, grdSubGroup.Rows[i].Cells["Group Id"].Value, grdSubGroup.Rows[i].Cells["Sub Group Id"].Value);

                            dtSubGroupAdd.Rows.Add(objDS.Tables[1].Rows[i]["Selected Product Group"],
                                objDS.Tables[1].Rows[i]["Selected Product Sub Group"], objDS.Tables[1].Rows[i]["T.Pro"], objDS.Tables[1].Rows[i]["PRGID"],
                                objDS.Tables[1].Rows[i]["PRSGID"], objDS.Tables[1].Rows[i]["T.Pro"]);
                        }
                        if (varmastertype == 1)
                        {
                            udfnLoadSubgrouplist_Selected();
                        }
                        for (int i = 0; i < grdSubGroupAdd.ColumnCount; i++)
                        {
                            if (grdSubGroupAdd.Columns[i].Name == "clmSelGroup") { grdSubGroupAdd.Columns.Remove("clmSelGroup"); }
                            if (grdSubGroupAdd.Columns[i].Name == "clmSelSubGroup") { grdSubGroupAdd.Columns.Remove("clmSelSubGroup"); }
                            if (grdSubGroupAdd.Columns[i].Name == "clmTotProductss") { grdSubGroupAdd.Columns.Remove("clmTotProductss"); }
                        }
                        //grdSubGroupAdd.Columns.Remove("clmSelGroup");
                        //grdSubGroupAdd.Columns.Remove("clmSelSubGroup");
                        //grdSubGroupAdd.Columns.Remove("clmTotProductss");
                        grdSubGroupAdd.DataSource = dtSubGroupAdd;
                        grdSubGroupAdd.Columns["clmRemove"].DisplayIndex = 4;
                        // grdSubGroupAdd.Columns[0].HeaderText = "";
                        //  grdSubGroupAdd.Columns[0].Width = 80;
                        grdSubGroupAdd.Columns["Selected Product Group"].Width = 150;
                        grdSubGroupAdd.Columns["Selected Product Subgroup"].Width = 200;
                        grdSubGroupAdd.Columns["clmRemove"].Width = 50;
                        grdSubGroupAdd.Columns["T.Pro"].Width = 40;
                        grdSubGroupAdd.Columns["T.Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdSubGroupAdd.Columns["Group Id"].Visible = false;
                        grdSubGroupAdd.Columns["Sub Group Id"].Visible = false;
                        grdSubGroupAdd.Columns["Products"].Visible = false;
                        grdSubGroupAdd.Columns["Selected Product Group"].ReadOnly = true;
                        grdSubGroupAdd.Columns["Selected Product Subgroup"].ReadOnly = true;
                        grdSubGroupAdd.Columns["Group Id"].ReadOnly = true;
                        grdSubGroupAdd.Columns["Sub Group Id"].ReadOnly = true;
                    }
                    //for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                    //{
                    //    for (int j = 0; j < dtGroup.Rows.Count; j++)
                    //    {
                    //        if (Convert.ToString(objDS.Tables[1].Rows[i]["PRGID"]) == Convert.ToString(dtGroup.Rows[j]["ID"]))
                    //        {
                    //            dtGroup.Rows[j][0] = true;
                    //            varGroup = Convert.ToString(dtGroup.Rows[j]["ID"]);
                    //            udfnSubGroupList();
                    //        }
                    //    }
                    //}

                    dtGroup.DefaultView.Sort = dtGroup.Columns[0].ColumnName + " DESC";
                    dtGroup = dtGroup.DefaultView.ToTable();
                    grdGroup.DataSource = null;
                    grdGroup.DataSource = dtGroup;
                    grdGroup.Columns[0].HeaderText = "";
                    grdGroup.Columns[0].Width = 30;
                    grdGroup.Columns["Product Group Name in English"].Width = 190;
                    grdGroup.Columns["T.S.Groups"].Width = 80;
                    grdGroup.Columns["ID"].Visible = false;
                    grdGroup.Columns["Product Group Name in English"].ReadOnly = true;
                    grdGroup.Columns["T.S.Groups"].ReadOnly = true;
                    grdGroup.Columns["T.S.Groups"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdGroup.Columns["ID"].ReadOnly = true;
                    //grdGroup.Sort(grdGroup.Columns[0], ListSortDirection.Descending);
                    //grdGroup.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    //for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                    //{
                    //    for (int j = 0; j < grdSubGroup.RowCount; j++)
                    //    {
                    //        if (Convert.ToString(objDS.Tables[1].Rows[i]["PRSGID"]) == Convert.ToString(grdSubGroup.Rows[j].Cells["Sub Group Id"].Value))
                    //        {
                    //            grdSubGroup.Rows[j].Cells[0].Value = true;
                    //        }
                    //    }
                    //}
                    dtSubGroup.Rows.Clear();
                    grdSubGroup.DataSource = null;
                    udfnRemoveGroup();
                }
                if(varStatusid==2)
                {
                    udfnDisable();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
              //  if (btnSave.Text == "Update") { this.grdGroup.Sort(this.grdGroup.Columns[0], ListSortDirection.Descending); }
                //this.grdSubGroup.Sort(this.grdSubGroup.Columns[2], ListSortDirection.Ascending);
            }
        }
        public void udfnDisable()
        {
            txtEBrandNameInEnglish.Enabled = false;
            txtEBrandNameInTamil.Enabled = false;
            txtProductGroup.Enabled = false;
            txtProductSubGroup.Enabled = false;
            txtSelectedProductSubGroup.Enabled = false;
            grdGroup.ReadOnly = true;
            grdSubGroup.ReadOnly = true;
            grdSubGroupAdd.ReadOnly = false;
            grdSubGroupAdd.Columns["clmRemove"].Visible = false;
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;
            btnSelectAll.Enabled = false;
            btnUnselectAll.Enabled = false;
            BtnSubGrupSelectAll.Enabled = false;
            btnSubGrupUnSelectAll.Enabled = false;
            this.ActiveControl = rbInactive;
        }
        public void udfnList()
        {
            try
            {
                int varviewtype = 5;
                if (btnSave.Text == "Update")
                {
                    varviewtype = 6;
                }
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdGroup.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnGroupList(varviewtype, 0, varId, "", 0);
                objdserv.CloseConnection();

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtGroup.Rows.Add(false, objDs.Tables[0].Rows[i]["Product Group Name in English"], objDs.Tables[0].Rows[i]["T.S.Groups"], objDs.Tables[0].Rows[i]["ID"]);
                    }
                    grdGroup.DataSource = dtGroup;
                    grdGroup.Columns[0].HeaderText = "";
                    grdGroup.Columns[0].Width = 30;
                    grdGroup.Columns["Product Group Name in English"].Width = 190;
                    grdGroup.Columns["T.S.Groups"].Width = 80;
                    grdGroup.Columns["ID"].Visible = false;
                    grdGroup.Columns["Product Group Name in English"].ReadOnly = true;
                    grdGroup.Columns["T.S.Groups"].ReadOnly = true;
                    grdGroup.Columns["T.S.Groups"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdGroup.Columns["ID"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdGroup.ClearSelection();
                udfnProductCount();
            }
        }

        public void udfnSubGroupAdd()
        {
            try
            {
                string varRemoveGroup = "", varAddGroup = ""; int varCount = 0;
                for (int i = 0; i < grdSubGroup.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSubGroup.Rows[i].Cells[0].Value) == true)
                    {
                        varCount++;
                    }
                }
                if (varCount > 0)
                {
                    for (int i = 0; i < grdSubGroup.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdSubGroup.Rows[i].Cells[0].Value) == false)
                        {
                            varRemoveGroup = Convert.ToString(grdSubGroup.Rows[i].Cells["Sub Group Id"].Value);
                            for (int j = 0; j < dtSubGroupAdd.Rows.Count; j++)
                            {
                                if (varRemoveGroup == Convert.ToString(dtSubGroupAdd.Rows[j]["Sub Group Id"]))
                                {
                                    dtSubGroupAdd.Rows[j].Delete();
                                    dtSubGroupAdd.AcceptChanges();
                                }
                            }
                        }
                        else
                        {
                            int varFlag = 0;
                            for (int j = 0; j < dtSubGroupAdd.Rows.Count; j++)
                            {
                                varAddGroup = Convert.ToString(grdSubGroup.Rows[i].Cells["Sub Group Id"].Value);
                                if (varAddGroup == Convert.ToString(dtSubGroupAdd.Rows[j]["Sub Group Id"]))
                                { varFlag = 1; }
                            }
                            if (varFlag == 0)
                            {
                                dtSubGroupAdd.Rows.Add(grdSubGroup.Rows[i].Cells["Product Group"].Value, grdSubGroup.Rows[i].Cells["Product Subgroup"].Value, "0", grdSubGroup.Rows[i].Cells["Group Id"].Value, grdSubGroup.Rows[i].Cells["Sub Group Id"].Value, grdSubGroup.Rows[i].Cells["T.Pro"].Value);
                                varModifiedFlag = 1;
                            }
                        }
                    }
                    for (int i = 0; i < grdSubGroupAdd.ColumnCount; i++)
                    {
                        if (grdSubGroupAdd.Columns[i].Name == "clmSelGroup") { grdSubGroupAdd.Columns.Remove("clmSelGroup"); }
                        if (grdSubGroupAdd.Columns[i].Name == "clmSelSubGroup") { grdSubGroupAdd.Columns.Remove("clmSelSubGroup"); }
                        if (grdSubGroupAdd.Columns[i].Name == "clmTotProductss") { grdSubGroupAdd.Columns.Remove("clmTotProductss"); }
                    }
                    grdSubGroupAdd.DataSource = null;
                    grdSubGroupAdd.DataSource = dtSubGroupAdd;
                    grdSubGroupAdd.Columns["clmRemove"].DisplayIndex = 5;
                    // grdSubGroupAdd.Columns[0].HeaderText = "";
                    // grdSubGroupAdd.Columns[0].Width = 80;
                    grdSubGroupAdd.Columns["clmRemove"].Width = 50;
                    grdSubGroupAdd.Columns["T.Pro"].Width = 40;
                    grdSubGroupAdd.Columns["Selected Product Group"].Width = 150;
                    grdSubGroupAdd.Columns["Selected Product Subgroup"].Width = 200;
                    grdSubGroupAdd.Columns["Group Id"].Visible = false;
                    grdSubGroupAdd.Columns["Sub Group Id"].Visible = false;
                    grdSubGroupAdd.Columns["Products"].Visible = false;
                    grdSubGroupAdd.Columns["T.Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdSubGroupAdd.Columns["Selected Product Group"].ReadOnly = true;
                    grdSubGroupAdd.Columns["Selected Product Subgroup"].ReadOnly = true;
                    grdSubGroupAdd.Columns["Group Id"].ReadOnly = true;
                    grdSubGroupAdd.Columns["Sub Group Id"].ReadOnly = true;
                    grdSubGroupAdd.Columns["T.Pro"].ReadOnly = true;
                    udfnRemoveGroup();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(44);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdSubGroupAdd.ClearSelection();
                txtSelectedProductSubGroup.Text = "";
                //this.grdSubGroupAdd.Sort(this.grdSubGroupAdd.Columns[2], ListSortDirection.Ascending);
            }
        }
        public void udfnRemoveGroup()
        {
            try
            {
                string varRemoveGroup = "";
                for (int j = 0; j < dtSubGroupAdd.Rows.Count; j++)
                {
                    varRemoveGroup = Convert.ToString(grdSubGroupAdd.Rows[j].Cells["Sub Group Id"].Value);
                    for (int i = 0; i < dtSubGroup.Rows.Count; i++)
                    {
                        if (varRemoveGroup == Convert.ToString(dtSubGroup.Rows[i]["Sub Group Id"]))
                        {
                            dtSubGroup.Rows[i].Delete();
                            dtSubGroup.AcceptChanges();
                        }
                    }
                }
                //grdSubGroup.DataSource = dtSubGroup;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSelectedSubGroupRemove()
        {
            try
            {
                string varRemoveSubGroup = "";

                if (chkSubGroupAdd.Checked == true) { dtSubGroupAdd.Rows.Clear(); dtSubGroupAdd.AcceptChanges(); chkSubGroupAdd.Checked = false; }
                else
                {
                L: for (int i = 0; i < grdSubGroupAdd.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdSubGroupAdd.Rows[i].Cells[0].EditedFormattedValue) == true)
                        {
                            varRemoveSubGroup = Convert.ToString(grdSubGroupAdd.Rows[i].Cells["Sub Group ID"].Value);
                            int varSubGroupCount = dtSubGroupAdd.Rows.Count;
                            for (int j = 0; j < varSubGroupCount; j++)
                            {
                                if (varRemoveSubGroup == Convert.ToString(dtSubGroupAdd.Rows[j]["Sub Group ID"]))
                                {
                                    dtSubGroupAdd.Rows[j].Delete();
                                    dtSubGroupAdd.AcceptChanges();
                                    goto L;
                                }
                                varModifiedFlag = 1;
                            }
                        }
                    }
                }
                grdSubGroupAdd.DataSource = dtSubGroupAdd;
                // grdSubGroupAdd.Columns[0].HeaderText = "";


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSubGroupList()
        {
            try
            {
                picLoader.Visible = true;
                Application.DoEvents();
                //grdGroup.SelectedRows[0].Cells[0].ReadOnly = true;
                int varviewtype = 6;
                if (btnSave.Text == "Update")
                {
                    varviewtype = 7;
                }
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                for (int i = 0; i < grdSubGroup.ColumnCount; i++)
                {
                    if (grdSubGroup.Columns[i].Name == "clmChk") { grdSubGroup.Columns.Remove("clmChk"); }
                    if (grdSubGroup.Columns[i].Name == "clmProductGroup") { grdSubGroup.Columns.Remove("clmProductGroup"); }
                    if (grdSubGroup.Columns[i].Name == "clmSubGroup") { grdSubGroup.Columns.Remove("clmSubGroup"); }
                    if (grdSubGroup.Columns[i].Name == "clmTotProducts") { grdSubGroup.Columns.Remove("clmTotProducts"); }
                }
                grdSubGroup.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                if (varGroup != "")
                {
                    //objDs = objdserv.udfnSubGroupList(varviewtype, 0, varGroup, 0, varId, "", 0, 0, 0, 0);
                    objDs = objdserv.udfnSubGroupList(varviewtype, 0, varGroup, 0, 0, "", 0, 0, 0, 0,0);
                }
                else if (varmasterBrandtype == 1)
                {
                    objDs = objdserv.udfnSubGroupList(varviewtype, 0, varGroupId, 0, 0, "", 0, 0, 0, 0,0);
                }
                objdserv.CloseConnection();
                // if (chkgroup.Checked) { dtSubGroup.Rows.Clear(); dtSubGroup.AcceptChanges(); }

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        int varFlag = 0;
                        for (int j = 0; j < dtSubGroup.Rows.Count; j++)
                        {
                            if (Convert.ToInt32(objDs.Tables[0].Rows[i]["Id"]) == Convert.ToInt32(dtSubGroup.Rows[j]["Sub Group Id"]))
                            {
                                varFlag = 1;
                            }
                        }
                        if (varFlag == 0)
                        {
                            dtSubGroup.Rows.Add(false, objDs.Tables[0].Rows[i]["Product Group Name"], objDs.Tables[0].Rows[i]["Product Sub Group Name in English"], objDs.Tables[0].Rows[i]["T.Pro"], objDs.Tables[0].Rows[i]["Product Group Id"], objDs.Tables[0].Rows[i]["Id"]);
                        }
                    }
                    udfnRemoveGroup();
                }
                grdSubGroup.DataSource = dtSubGroup;
                grdSubGroup.Columns[0].HeaderText = "";
                grdSubGroup.Columns[0].Width = 30;
                grdSubGroup.Columns["Product Group"].Width = 150;
                grdSubGroup.Columns["Product Subgroup"].Width = 200;
                grdSubGroup.Columns["T.Pro"].Width = 60;
                grdSubGroup.Columns["Group Id"].Visible = false;
                grdSubGroup.Columns["Sub Group Id"].Visible = false;
                grdSubGroup.Columns["Product Group"].ReadOnly = true;
                grdSubGroup.Columns["Product Subgroup"].ReadOnly = true;
                grdSubGroup.Columns["T.Pro"].ReadOnly = true;
                grdSubGroup.Columns["Group Id"].ReadOnly = true;
                grdSubGroup.Columns["Sub Group Id"].ReadOnly = true;
                grdSubGroup.Columns["T.Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (varmasterBrandtype == 1)
                {
                    for (int j = 0; j < grdSubGroup.RowCount; j++)
                    {
                        if (Convert.ToString(varSubGroupId) == Convert.ToString(grdSubGroup.Rows[j].Cells["Sub Group Id"].Value))
                        {
                            grdSubGroup.Rows[j].Cells[0].Value = true;
                            for (int i = 0; i < dtGroup.Rows.Count; i++)
                            {
                                if (varGroupId == Convert.ToString(dtGroup.Rows[i]["ID"]))
                                {
                                    dtGroup.Rows[i][0] = true;
                                    //varGroup = Convert.ToString(grdGroup.Rows[j].Cells["ID"].Value);
                                }
                            }
                            dtGroup.DefaultView.Sort = dtGroup.Columns[0].ColumnName + " DESC";
                            dtGroup = dtGroup.DefaultView.ToTable();
                            grdGroup.DataSource = null;
                            grdGroup.DataSource = dtGroup;
                            grdGroup.Columns[0].HeaderText = "";
                            grdGroup.Columns[0].Width = 30;
                            grdGroup.Columns["Product Group Name in English"].Width = 190;
                            grdGroup.Columns["T.S.Groups"].Width = 80;
                            grdGroup.Columns["ID"].Visible = false;
                            grdGroup.Columns["Product Group Name in English"].ReadOnly = true;
                            grdGroup.Columns["T.S.Groups"].ReadOnly = true;
                            grdGroup.Columns["T.S.Groups"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGroup.Columns["ID"].ReadOnly = true;
                            //udfnSubGroupList();
                            if (btnSave.Text == "Save")
                            {
                                udfnSubGroupAdd();
                            }
                            else
                            {
                                SPDataService objdservs = new SPDataService();
                                objDs = objdservs.udfnSubGroupList(14, Convert.ToInt32(varSubGroupId), "", 0, 0, "", 0, 0, 0, 0,0);
                                objdservs.CloseConnection();
                                string varProCount = "0";
                                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varProCount = Convert.ToString(objDs.Tables[0].Rows[0]["Count"]); } } }
                                //dtSubGroupAdd.Rows.Add(varGroupName,varSubGroupName, varProCount, varGroupId,varSubGroupId);
                                int varFlag = 0;
                                for (int i = 0; i < dtSubGroupAdd.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(varSubGroupId) == Convert.ToInt32(dtSubGroupAdd.Rows[i]["Sub Group Id"]))
                                    {
                                        varFlag = 1;
                                    }
                                }
                                if (varFlag == 0)
                                {
                                    dtSubGroupAdd.Rows.Add(varGroupName, varSubGroupName, varProCount, varGroupId, varSubGroupId);
                                }
                            }
                            //if (btnSave.Text == "Save") { udfnSubGroupAdd(); }
                        }
                    }
                    udfnRemoveGroup();
                    varmasterBrandtype = 0;
                }
                //udfnRefreshSubGroup();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdSubGroup.ClearSelection();
                this.grdSubGroup.Sort(this.grdSubGroup.Columns[1], ListSortDirection.Ascending);
                //this.grdSubGroup.Sort(this.grdSubGroup.Columns[2], ListSortDirection.Ascending);
                txtProductSubGroup.Text = ""; 
                grdGroup.SelectedRows[0].Cells[0].ReadOnly = false;
            }
        }

        public void udfnclose()
        {
            try
            {
                if (varModifiedFlag == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm.objCP_BrandList.Show();
                        MainForm.objCP_BrandList.udfnList();
                    }
                    else
                    { btnSave.Focus(); }
                }
                else
                {
                    if (varUpdate == 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
                            MainForm.objCP_BrandList.Show();
                            MainForm.objCP_BrandList.udfnList();
                        }
                    }
                    else { this.Close(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
                // MainForm.objCP_BrandList.udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefalutColumn()
        {
            try
            {
                grdSubGroup.Columns.Add("clmChk","");
                grdSubGroup.Columns.Add("clmProductGroup","Product Group");
                grdSubGroup.Columns.Add("clmSubGroup","Product Subgroup");
                grdSubGroup.Columns.Add("clmTotProducts","T.Pro");
                grdSubGroup.Columns["clmProductGroup"].Width = 150;
                grdSubGroup.Columns["clmSubGroup"].Width = 200;
                grdSubGroup.Columns["clmChk"].Width = 50;

                grdSubGroupAdd.Columns.Add("clmSelGroup","Selected Product Group");
                grdSubGroupAdd.Columns.Add("clmSelSubGroup","Selected Product Subgroup");
                grdSubGroupAdd.Columns.Add("clmTotProductss","T.Pro");
                // grdSubGroupAdd.Columns[0].HeaderText = "";
                // grdSubGroupAdd.Columns[0].Width = 80;
                grdSubGroupAdd.Columns["clmRemove"].Width = 50;
                grdSubGroupAdd.Columns["clmTotProductss"].Width = 40;
                grdSubGroupAdd.Columns["clmSelGroup"].Width = 150;
                grdSubGroupAdd.Columns["clmSelSubGroup"].Width = 200;
                grdSubGroupAdd.Columns["clmRemove"].DisplayIndex = 3;
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
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Brand_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    if (MainForm.varCloseFlag == 0)
            //    {
            //        if (varUpdate == 0)
            //        {
            //            DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //            if (dialogResult == DialogResult.Yes)
            //            {
            //                e.Cancel = false;
            //            }
            //            else
            //            {
            //                e.Cancel = true;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
        private void TxtEBrandNameInEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEBrandNameInEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtEBrandNameInEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (varmastertype == 1)
                {
                    string varId_Brand = "0";
                    DataSet objDsBrand = new DataSet();
                    SPDataService objDServ2 = new SPDataService();
                    objDsBrand = objDServ2.udfnBrandList(8, "", 0, 0, 0, txtEBrandNameInEnglish.Text.Trim(), 0);
                    objDServ2.CloseConnection();
                    if (objDsBrand != null)
                    {
                        if (objDsBrand.Tables.Count > 0)
                        {
                            if (objDsBrand.Tables[0].Rows.Count > 0)
                            {
                                varId_Brand = Convert.ToString(objDsBrand.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (varId_Brand != "0" && varId_Brand != "-1")
                    {
                        // grdSubGroup.DataSource = null;
                        //grdSubGroupAdd.DataSource = null;
                        btnSave.Text = "Update";
                        varmasterBrandtype = 0;
                        varId = Convert.ToInt32(varId_Brand);
                        udfnEdit();
                        udfnProductCount();
                        //varSubGroupId = MainForm.objCP_Items.varSubgroupId;
                        //varGroupId = MainForm.objCP_Items.vargroupId;
                        //if (varSubGroupId != "0" && varGroupId != "0")
                        //{
                        //    varmasterBrandtype = 1;
                        //    udfnSubGroupList();
                        //}   
                    }
                }
                if (txtEBrandNameInEnglish.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInEnglish, "Please enter brand name in english");
                    txtEBrandNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInEnglish.ShowAlways = true;
                    tpBrandNameInEnglish.Show("Please enter brand name in english", txtEBrandNameInEnglish, 5000);
                }
                else
                {
                    epBrand.Clear();
                    txtEBrandNameInEnglish.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { udfnLoadRefresh(); }
        }
        private void TxtEBrandNameInEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEBrandNameInTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtEBrandNameInTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEBrandNameInTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtEBrandNameInTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEBrandNameInTamil.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInTamil, "Please enter brand name in tamil");
                    txtEBrandNameInTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInTamil.ShowAlways = true;
                    tpBrandNameInTamil.Show("Please enter brand name in tamil", txtEBrandNameInTamil, 5000);
                }
                else
                {
                    epBrand.Clear();
                    txtEBrandNameInTamil.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelectedProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSelectedProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelectedProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSelectedProductSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClear()
        {
            try
            {
                txtEBrandNameInEnglish.Text = "";
                txtEBrandNameInTamil.Text = "";
                txtProductGroup.Text = "";
                txtProductSubGroup.Text = "";
                txtSelectedProductSubGroup.Text = "";
                foreach (DataGridViewRow row in grdGroup.Rows)
                {
                    row.Cells[0].Value = false;
                }
                grdSubGroup.DataSource = null;
                grdSubGroupAdd.DataSource = null;
                chkSubGroup.Checked = false;
                chkSubGroupAdd.Checked = false;
                txtEBrandNameInEnglish.Focus();
                lblGroupCount.Text = "0";
                lblSubgroupCount.Text = "0";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                txtSelectedProductSubGroup.Text = "";
                btnSave.Enabled = false;
                string varResult = ""; string varOriginator = "Brand Creation";
                int varViewType = 0;
                if (btnSave.Text == "Update")
                {
                    varOriginator = "Brand Updation";
                    varViewType = 1;
                }
                if (rbActive.Checked)
                {
                    varStatusid = 1;
                }
                else
                {
                    varStatusid = 2;
                }
                varSubGroupId = "";
                for (int i = 0; i < grdSubGroupAdd.RowCount; i++)
                {
                    if (varSubGroupId == "")
                    {
                        varSubGroupId = Convert.ToString(grdSubGroupAdd.Rows[i].Cells["Sub Group Id"].Value);
                    }
                    else
                    {
                        varSubGroupId = varSubGroupId + "," + Convert.ToString(grdSubGroupAdd.Rows[i].Cells["Sub Group Id"].Value);
                    }
                }
                SPDataService objDser = new SPDataService();
                varResult = objDser.udfnBrand(varViewType, varId, Convert.ToString(txtEBrandNameInEnglish.Text).Trim(), Convert.ToString(txtEBrandNameInTamil.Text).Trim(), varStatusid, varSubGroupId, varOriginator,MainForm.pbUserID,0);
                objDser.CloseConnection();
                btnSave.Enabled = true;
                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    varModifiedFlag = 0;
                    dtSubGroup.Rows.Clear();
                    dtSubGroupAdd.Rows.Clear();
                    if (btnSave.Text == "Save")
                    {
                        varbrandcode = Convert.ToInt16(varResult.Split('~')[2]);
                        if (varmastertype == 1)
                        {
                            varmastertype = 0;
                            MainForm.objCP_Items.varbrandcode = varbrandcode;
                            MainForm.objCP_Items.varBrandName = txtEBrandNameInEnglish.Text;
                            varUpdate = 1;
                            this.Close();
                        }
                        else
                        {
                            // udfnclose(); 
                            MainForm.objCP_BrandList.udfnList();
                            udfnClear();
                            udfnProductCount();
                            udfnDefalutColumn();
                        }
                    }
                    else
                    {
                        if (varmastertype == 1)
                        {
                            varmastertype = 0;
                            MainForm.objCP_Items.varbrandcode = varbrandcode;
                            MainForm.objCP_Items.varBrandName = txtEBrandNameInEnglish.Text;
                            varUpdate = 1;
                            this.Close();
                        }
                        else
                        {
                            varUpdate = 1;
                            varModifiedFlag = 0;
                            udfnclose();
                            MainForm.objCP_BrandList.udfnList();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                btnSave.Focus();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;

                if (txtEBrandNameInEnglish.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInEnglish, "Please enter brand name in english");
                    txtEBrandNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInEnglish.ShowAlways = true;
                    tpBrandNameInEnglish.Show("Please enter brand name in english", txtEBrandNameInEnglish, 5000);
                    blnErrorFlag = true;
                }

                if (txtEBrandNameInTamil.Text.Trim() == "")
                {
                    epBrand.SetError(txtEBrandNameInTamil, "Please enter brand name in tamil");
                    txtEBrandNameInTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBrandNameInTamil.ShowAlways = true;
                    tpBrandNameInTamil.Show("Please enter brand name in tamil", txtEBrandNameInTamil, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false && grdSubGroupAdd.Rows.Count <= 0)
                {
                    if (grdSubGroupAdd.Rows.Count <= 0)
                    {
                        blnErrorFlag = true;
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(52);
                        objDServ.CloseConnection();
                        DialogResult dialogResult = MessageBox.Show(varMessage, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                if (blnErrorFlag == false)
                {
                    udfnSave(sender, e);
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

        private void TxtEBrandNameInTamil_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSelectedProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelectedProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(pnlStatus.Enabled==true)
                    {
                        if(rbActive.Checked==true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInactive.Focus();
                        }
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnRemove_Enter(object sender, EventArgs e)
        {
            try
            {
                btnRemove.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnRemove_Leave(object sender, EventArgs e)
        {
            try
            {
                btnRemove.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSave_Enter(object sender, EventArgs e)
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

        private void BtnSave_Leave(object sender, EventArgs e)
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

        private void BtnClose_Enter(object sender, EventArgs e)
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

        private void BtnClose_Leave(object sender, EventArgs e)
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


        private void TxtProductGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //(grdGroup.DataSource as BindingSource).Filter = "([Product Group Name in English]) LIKE '%" + txtProductGroup.Text + "%'";
                (grdGroup.DataSource as DataTable).DefaultView.RowFilter = "([Product Group Name in English]) LIKE '%" + txtProductGroup.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { udfnProductCount(); }
        }
        public void udfnTotalProducts()
        {
            int varCount = 0; int varSubgroup = 0; int varGroup = 0; int varGroupid = 0;
            try
            {
                //if (grdSubGroupAdd.Rows.Count != 0)
                //{
                //    varSubgroup = Convert.ToInt32(grdSubGroupAdd.Rows.Count);
                //    for (int i = 0; i < grdSubGroupAdd.RowCount; i++)
                //    {
                //        if (Convert.ToInt32(grdSubGroupAdd.Rows[i].Cells["T.Pro"].Value) != 0)
                //        {
                //            varCount = varCount + Convert.ToInt32(grdSubGroupAdd.Rows[i].Cells["T.Pro"].Value);
                //        }
                //        varGroupid = Convert.ToInt32(grdSubGroupAdd.Rows[i].Cells["Group Id"].Value);
                //        if (varGroupid == Convert.ToInt32(grdSubGroupAdd.Rows[i].Cells["Group Id"].Value))
                //        {
                //            varGroup++;
                //        }
                //    }
                //}
                if (dtSubGroupAdd.Rows.Count > 0)
                {
                    varGroup = dtSubGroupAdd.DefaultView.ToTable(true, "Group Id").Rows.Count;
                    varSubgroup = Convert.ToInt32(grdSubGroupAdd.Rows.Count);
                    for (int i = 0; i < grdSubGroupAdd.RowCount; i++)
                    {
                        if (Convert.ToInt32(grdSubGroupAdd.Rows[i].Cells["T.Pro"].Value) != 0)
                        {
                            varCount = varCount + Convert.ToInt32(grdSubGroupAdd.Rows[i].Cells["T.Pro"].Value);
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
                lblTotalProduct.Text = Convert.ToString(varCount);
                lblNoofSubgroups.Text = Convert.ToString(varSubgroup);
                lblNoofGroup.Text = Convert.ToString(varGroup);
            }
        }
        private void CP_Brand_Load(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;
                Application.DoEvents();
                udfnList();
                //udfnSubGroupAdd();
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    udfnEdit();
                }
                udfnLoadSubgrouplist_Selected();
                udfnTotalProducts();
                udfnProductCount();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { udfnLoadRefresh(); picLoader.Visible = false; }
        }
        public void udfnLoadRefresh() {
            try { if (varmastertype == 1 && btnSave.Text == "Update") { btnRefresh.Visible = true; } else { btnRefresh.Visible = false; } }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLoadSubgrouplist_Selected()
        {
            try
            {
                if (varmastertype == 1)
                {
                    varSubGroupId = MainForm.objCP_Items.varSubgroupId;
                    varGroupId = MainForm.objCP_Items.vargroupId;
                    varGroupName = MainForm.objCP_Items.varGroupName;
                    varSubGroupName = MainForm.objCP_Items.varSubGroupName;
                    if (varSubGroupId != "0" && varGroupId != "0")
                    {
                        //if (btnSave.Text == "Save")
                        //{
                        //    varmasterBrandtype = 1;
                        //}
                        varmasterBrandtype = 1;
                        udfnSubGroupList();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtSubGroup.DefaultView.RowFilter = "([Product Subgroup]) LIKE '%" + txtProductSubGroup.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { udfnProductCount(); }
        }

        private void Chkgroup_CheckedChanged(object sender, EventArgs e)
        {
            ////try
            ////{
            ////    if (varCheckAllFlag1 != 1)
            ////    {
            ////        varGroup = "";
            ////        for (int i = 0; i < grdGroup.Rows.Count; i++)
            ////        {
            ////            grdGroup.Rows[i].Cells[0].Value = chkgroup.Checked;
            ////            if (varGroup == "")
            ////            {
            ////                varGroup = Convert.ToString(grdGroup.Rows[i].Cells["ID"].Value);
            ////            }
            ////            else
            ////            {
            ////                varGroup = varGroup + "," + Convert.ToString(grdGroup.Rows[i].Cells["ID"].Value);
            ////            }
            ////        }
            ////        udfnSubGroupList();
            ////        if (chkgroup.Checked == false)
            ////        {
            ////            foreach (DataGridViewRow row in grdGroup.Rows)
            ////            {
            ////                row.Cells[0].Value = false;
            ////            }
            ////            dtSubGroup.Rows.Clear();
            ////            dtSubGroup.AcceptChanges();
            ////            grdSubGroup.DataSource = dtSubGroup;
            ////        }
            ////    }
            ////    else
            ////    {
            ////        varCheckAllFlag1 = 0;
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    objError = new DataError();
            ////    objError.WriteFile(ex);
            ////}
        }

        private void ChkSubGroup_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (varCheckAllFlag2 != 1)
            //    {
            //        for (int i = 0; i < grdSubGroup.Rows.Count; i++)
            //        {
            //            grdSubGroup.Rows[i].Cells[0].Value = chkSubGroup.Checked;
            //           // grdSubGroup.Rows[i].Cells["clmchkProductSubGroup"].Value = chkSubGroup.Checked;
            //        }
            //        if(chkSubGroup.Checked==false)
            //        {
            //            foreach (DataGridViewRow row in grdSubGroup.Rows)
            //            {
            //                row.Cells[0].Value = false;
            //            }
            //            //dtSubGroupAdd.Rows.Clear();
            //            //dtSubGroupAdd.AcceptChanges();
            //            //grdSubGroupAdd.DataSource = dtSubGroupAdd;
            //        }
            //    }
            //    else
            //    {
            //        varCheckAllFlag2 = 0;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void GrdGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    udfnCaculateCheckedCount_Group();
                }
                varGroup = ""; string varRemoveGroup = ""; 
                
                if (Convert.ToBoolean(grdGroup.SelectedRows[0].Cells[0].EditedFormattedValue) == true)
                {
                    varGroup = Convert.ToString(grdGroup.SelectedRows[0].Cells["ID"].Value);
                    varmasterBrandtype = 0;
                    udfnSubGroupList();
                }
                else
                {
                    DataTable objDtNew = new DataTable();
                    int varRowCount = dtSubGroup.Rows.Count;
                    varRemoveGroup = Convert.ToString(grdGroup.SelectedRows[0].Cells["ID"].Value);
                // grdGroup.SelectedRows[0].Cells[0].ReadOnly = true;
                l: for (int i = 0; i < varRowCount; i++)
                    {
                        if (varRemoveGroup == Convert.ToString(dtSubGroup.Rows[i]["Group ID"]))
                        {
                            dtSubGroup.Rows[i].Delete();
                            dtSubGroup.AcceptChanges();
                            varRowCount = dtSubGroup.Rows.Count;
                            goto l;
                        }
                    }
                    grdSubGroup.DataSource = dtSubGroup;
                    grdSubGroup.Columns[0].HeaderText = "";

                }
                grdSubGroup.Columns["Product Group"].Width = 150;
                grdSubGroup.Columns["Product Subgroup"].Width = 200;
                grdSubGroup.Columns["Group Id"].Visible = false;
                grdSubGroup.Columns["Sub Group Id"].Visible = false;
                // grdGroup.SelectedRows[0].Cells[0].ReadOnly = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally {
                int milliseconds = 300;
                Thread.Sleep(milliseconds);
                picLoader.Visible = false;
                udfnProductCount();
            }
        }
        private void GrdGroup_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grdGroup.IsCurrentCellDirty)
            {
                grdGroup.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void TxtSelectedProductSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtSubGroupAdd.DefaultView.RowFilter = "([Selected Product Subgroup]) LIKE '%" + txtSelectedProductSubGroup.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSubGroupAdd();
                udfnTotalProducts();
                udfnProductCount();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        //Added by deepa on 01-09-2023
        private void GrdSubGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //varGroup = "";
                //for (int i = 0; i < grdSubGroup.Rows.Count; i++)
                //{
                //    // int flag = 0;
                //    if (Convert.ToBoolean(grdSubGroup.Rows[i].Cells["clmchkProductSubGroup"].Value) == true)
                //    {
                //        if (varGroup == "")
                //        {
                //            varGroup = Convert.ToString(grdSubGroup.Rows[i].Cells["ID"].Value);
                //        }
                //        else
                //        {
                //            varGroup = varGroup + "," + Convert.ToString(grdSubGroup.Rows[i].Cells["ID"].Value);
                //        }
                //    }
                //}
                if (e.ColumnIndex == 0)
                {
                    udfnCaculateCheckedCount_SubGroup();
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        //Added by deepa on 01-09-2023
        private void GrdSubGroupAdd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 0)
            //    { udfnCaculateCheckedCount_SubGroupAdd(); }
            //}
            //catch (Exception ex)
            //{
            //     objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            try
            {
                if (e.RowIndex != -1)
                {

                    switch (grdSubGroupAdd.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdSubGroup.DataSource = null;
                                dtSubGroup.Rows.Add(false, grdSubGroupAdd.SelectedRows[0].Cells["Selected Product Group"].Value, grdSubGroupAdd.SelectedRows[0].Cells["Selected Product Subgroup"].Value, grdSubGroupAdd.SelectedRows[0].Cells["Products"].Value, grdSubGroupAdd.SelectedRows[0].Cells["Group Id"].Value, grdSubGroupAdd.SelectedRows[0].Cells["Sub Group Id"].Value);
                                dtSubGroup.AcceptChanges();
                                for (int i = 0; i < grdSubGroup.ColumnCount; i++)
                                {
                                    if (grdSubGroup.Columns[i].Name == "clmChk") { grdSubGroup.Columns.Remove("clmChk"); }
                                    if (grdSubGroup.Columns[i].Name == "clmProductGroup") { grdSubGroup.Columns.Remove("clmProductGroup"); }
                                    if (grdSubGroup.Columns[i].Name == "clmSubGroup") { grdSubGroup.Columns.Remove("clmSubGroup"); }
                                    if (grdSubGroup.Columns[i].Name == "clmTotProducts") { grdSubGroup.Columns.Remove("clmTotProducts"); }
                                }
                                grdSubGroup.DataSource = dtSubGroup;
                                grdSubGroup.Columns[0].HeaderText = "";
                                grdSubGroup.Columns[0].Width = 30;
                                grdSubGroup.Columns["Product Group"].Width = 150;
                                grdSubGroup.Columns["Product Subgroup"].Width = 200;
                                grdSubGroup.Columns["T.Pro"].Width = 60;
                                grdSubGroup.Columns["Group Id"].Visible = false;
                                grdSubGroup.Columns["Sub Group Id"].Visible = false;
                                grdSubGroup.Columns["Product Group"].ReadOnly = true;
                                grdSubGroup.Columns["Product Subgroup"].ReadOnly = true;
                                grdSubGroup.Columns["T.Pro"].ReadOnly = true;
                                grdSubGroup.Columns["Group Id"].ReadOnly = true;
                                grdSubGroup.Columns["Sub Group Id"].ReadOnly = true;
                                grdSubGroup.Columns["T.Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSubGroupAdd.Rows.RemoveAt(this.grdSubGroupAdd.SelectedRows[0].Index);

                            }
                            varModifiedFlag = 1;
                            udfnTotalProducts();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { //this.grdSubGroup.Sort(this.grdSubGroup.Columns[2], ListSortDirection.Ascending); 
                udfnProductCount();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSelectedSubGroupRemove();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
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

        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnRemove_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSelectedSubGroupRemove();
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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

        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSubGroupList();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkSubGroupAdd_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (varCheckAllFlag3 != 1)
                {
                    for (int i = 0; i < grdSubGroupAdd.Rows.Count; i++)
                    {
                        grdSubGroupAdd.Rows[i].Cells[0].Value = chkSubGroupAdd.Checked;
                    }
                    if (chkSubGroupAdd.Checked == false)
                    {
                        foreach (DataGridViewRow row in grdSubGroupAdd.Rows)
                        {
                            row.Cells[0].Value = false;
                        }
                    }
                }
                else
                {
                    varCheckAllFlag3 = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        //Added by deepa on 01-09-2023
        public void udfnCaculateCheckedCount_Group()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdGroup.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdGroup.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        varCheckedCount++;
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
                if (grdGroup.Rows.Count == varCheckedCount)
                {
                    varCheckAllFlag1 = 1;
                    // chkgroup.Checked = true;
                }
                else
                {
                    varCheckAllFlag1 = 1;
                    //chkgroup.Checked = false;
                }
            }
        }

        //Added by deepa on 01-09-2023
        public void udfnCaculateCheckedCount_SubGroup()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdSubGroup.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSubGroup.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        varCheckedCount++;
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
                if (grdSubGroup.Rows.Count == varCheckedCount)
                {
                    varCheckAllFlag2 = 1;
                    chkSubGroup.Checked = true;
                }
                else
                {
                    varCheckAllFlag2 = 1;
                    chkSubGroup.Checked = false;
                }
            }
        }

        //Added by deepa on 01-09-2023
        public void udfnCaculateCheckedCount_SubGroupAdd()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdSubGroupAdd.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSubGroupAdd.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        varCheckedCount++;
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
                if (grdSubGroupAdd.Rows.Count == varCheckedCount)
                {
                    varCheckAllFlag3 = 1;
                    chkSubGroupAdd.Checked = true;
                }
                else
                {
                    varCheckAllFlag3 = 1;
                    chkSubGroupAdd.Checked = false;
                }
            }
        }

        private void GrdGroup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdGroup.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSubGroup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdSubGroup.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSubGroupAdd_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdSubGroupAdd.ClearSelection();
                for (int i = 0; i < grdSubGroupAdd.RowCount; i++)
                {
                    if (Convert.ToString(grdSubGroupAdd.Rows[i].Cells["T.Pro"].Value) != "0")
                    {
                        ((DataGridViewImageCell)grdSubGroupAdd.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1); ;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { udfnTotalProducts(); }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;
                varGroup = "";
                for (int i = 0; i < grdGroup.Rows.Count; i++)
                {
                    if (varGroup == "")
                    {
                        varGroup = Convert.ToString(grdGroup.Rows[i].Cells["ID"].Value);
                    }
                    else
                    {
                        varGroup = varGroup + "," + Convert.ToString(grdGroup.Rows[i].Cells["ID"].Value);
                    }

                    grdGroup.Rows[i].Cells[0].Value = true;
                }
                udfnSubGroupList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { udfnProductCount(); picLoader.Visible = false; }
        }

        private void BtnUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;
                for (int i = 0; i < dtGroup.Rows.Count; i++)
                {
                    dtGroup.Rows[i][0] = false;
                }
                grdGroup.DataSource = null;
                grdGroup.DataSource = dtGroup;
                grdGroup.Columns[0].HeaderText = "";
                grdGroup.Columns[0].Width = 30;
                grdGroup.Columns["Product Group Name in English"].Width = 190;
                grdGroup.Columns["T.S.Groups"].Width = 80;
                grdGroup.Columns["ID"].Visible = false;
                grdGroup.Columns["Product Group Name in English"].ReadOnly = true;
                grdGroup.Columns["T.S.Groups"].ReadOnly = true;
                grdGroup.Columns["T.S.Groups"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdGroup.Columns["ID"].ReadOnly = true;
                dtSubGroup.Rows.Clear();
                dtSubGroup.AcceptChanges();
                grdSubGroup.DataSource = dtSubGroup;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { udfnProductCount(); picLoader.Visible = false; }
        }

        private void BtnUnselectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                btnUnselectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnselectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                btnUnselectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSelectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSelectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSelectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSelectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnSelectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnselectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnUnselectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdSubGroup.Rows.Count; i++)
                {
                    grdSubGroup.Rows[i].Cells[0].Value = chkSubGroup.Checked;
                    // grdSubGroup.Rows[i].Cells["clmchkProductSubGroup"].Value = chkSubGroup.Checked;
                }

                foreach (DataGridViewRow row in grdSubGroup.Rows)
                {
                    row.Cells[0].Value = true;
                }
                //dtSubGroupAdd.Rows.Clear();
                //dtSubGroupAdd.AcceptChanges();
                //grdSubGroupAdd.DataSource = dtSubGroupAdd;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { udfnProductCount(); }
        }

        private void BtnSubGrupUnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in grdSubGroup.Rows)
                {
                    row.Cells[0].Value = false;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { udfnProductCount(); }
        }

        private void BtnSubGrupSelectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                BtnSubGrupSelectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupSelectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                BtnSubGrupSelectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupSelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnSelectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupUnSelectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSubGrupUnSelectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupUnSelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnUnselectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupUnSelectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSubGrupUnSelectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductCount() {
            try
            {
                lblGroupCount.Text = Convert.ToString(grdGroup.RowCount);
                lblSubgroupCount.Text = Convert.ToString(grdSubGroup.RowCount);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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

        private void RbInactive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                udfnClear();
                varId = 0;
                dtGroup.Clear();
                dtSubGroup.Clear();
                dtSubGroupAdd.Clear();
                udfnProductCount();
                btnSave.Text = "Save";
                varmastertype = 1;
                CP_Brand_Load(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGroup_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
