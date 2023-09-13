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
    public partial class CP_Brand : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int varbrandcode = 0;

        private ToolTip tpBrandNameInEnglish = new ToolTip();
        private ToolTip tpBrandNameInTamil = new ToolTip();

        public int varStatusid = 1;
        public int varUpdate = 0;
        public int varFormFlag = 0;
        public int varId = 0;

        public string varBrandId = "";
        public string varGroupId = "";
        public string varSubGroupId = "";
        public int varmastertype = 0;
        public string varGroup = "";
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
                objDS = objdserv.udfnBrandList(1, varBrandId, 0, 0, 0, "");
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
                        for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                        {
                            //grdSubGroup.Rows.Add(Convert.ToString(objDS.Tables[1].Rows[i]["PRGID"]), Convert.ToString(objDS.Tables[1].Rows[i]["PRG_EName"]));
                            //dtSubGroupAdd.Rows.Add(false, grdSubGroup.Rows[i].Cells["Product Group"].Value, grdSubGroup.Rows[i].Cells["Product Subgroup"].Value, grdSubGroup.Rows[i].Cells["Group Id"].Value, grdSubGroup.Rows[i].Cells["Sub Group Id"].Value);

                            dtSubGroupAdd.Rows.Add(objDS.Tables[1].Rows[i]["Selected Product Group"],
                                objDS.Tables[1].Rows[i]["Selected Product Sub Group"], objDS.Tables[1].Rows[i]["PRGID"],
                                objDS.Tables[1].Rows[i]["PRSGID"]);
                        }
                        grdSubGroupAdd.DataSource = dtSubGroupAdd;
                        grdSubGroupAdd.Columns["clmRemove"].DisplayIndex = 4;
                        // grdSubGroupAdd.Columns[0].HeaderText = "";
                        //  grdSubGroupAdd.Columns[0].Width = 80;
                        grdSubGroupAdd.Columns["Selected Product Group"].Width = 150;
                        grdSubGroupAdd.Columns["Selected Product Subgroup"].Width = 200;
                        grdSubGroupAdd.Columns["Group Id"].Visible = false;
                        grdSubGroupAdd.Columns["Sub Group Id"].Visible = false;
                        grdSubGroupAdd.Columns["Selected Product Group"].ReadOnly = true;
                        grdSubGroupAdd.Columns["Selected Product Subgroup"].ReadOnly = true;
                        grdSubGroupAdd.Columns["Group Id"].ReadOnly = true;
                        grdSubGroupAdd.Columns["Sub Group Id"].ReadOnly = true;
                    }
                    for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                    {
                        for (int j = 0; j < grdGroup.RowCount; j++)
                        {
                            if (Convert.ToString(objDS.Tables[1].Rows[i]["PRGID"]) == Convert.ToString(grdGroup.Rows[j].Cells["ID"].Value))
                            {
                                grdGroup.Rows[j].Cells[0].Value = true;
                                varGroup = Convert.ToString(grdGroup.Rows[j].Cells["ID"].Value);
                                udfnSubGroupList();
                            }
                        }
                    }
                    for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                    {
                        for (int j = 0; j < grdSubGroup.RowCount; j++)
                        {
                            if (Convert.ToString(objDS.Tables[1].Rows[i]["PRSGID"]) == Convert.ToString(grdSubGroup.Rows[j].Cells["Sub Group Id"].Value))
                            {
                                grdSubGroup.Rows[j].Cells[0].Value = true;
                            }
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
                objDs = objdserv.udfnGroupList(varviewtype, 0, varId, "");
                objdserv.CloseConnection();

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtGroup.Rows.Add(false, objDs.Tables[0].Rows[i]["Product Group Name in English"], objDs.Tables[0].Rows[i]["ID"]);
                    }

                    grdGroup.DataSource = dtGroup;
                    grdGroup.Columns[0].HeaderText = "";
                    grdGroup.Columns[0].Width = 80;
                    grdGroup.Columns["Product Group Name in English"].Width = 200;
                    grdGroup.Columns["ID"].Visible = false;
                    grdGroup.Columns["Product Group Name in English"].ReadOnly = true;
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
                        if (Convert.ToBoolean(grdSubGroup.Rows[i].Cells[0].Value) == true)
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
                                dtSubGroupAdd.Rows.Add(grdSubGroup.Rows[i].Cells["Product Group"].Value, grdSubGroup.Rows[i].Cells["Product Subgroup"].Value, grdSubGroup.Rows[i].Cells["Group Id"].Value, grdSubGroup.Rows[i].Cells["Sub Group Id"].Value);
                            }
                        }
                        else
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
                    }
                    grdSubGroupAdd.DataSource = dtSubGroupAdd;
                    grdSubGroupAdd.Columns["clmRemove"].DisplayIndex = 4;
                    // grdSubGroupAdd.Columns[0].HeaderText = "";
                    // grdSubGroupAdd.Columns[0].Width = 80;
                    grdSubGroupAdd.Columns["clmRemove"].Width = 80;
                    grdSubGroupAdd.Columns["Selected Product Group"].Width = 150;
                    grdSubGroupAdd.Columns["Selected Product Subgroup"].Width = 200;
                    grdSubGroupAdd.Columns["Group Id"].Visible = false;
                    grdSubGroupAdd.Columns["Sub Group Id"].Visible = false;

                    grdSubGroupAdd.Columns["Selected Product Group"].ReadOnly = true;
                    grdSubGroupAdd.Columns["Selected Product Subgroup"].ReadOnly = true;
                    grdSubGroupAdd.Columns["Group Id"].ReadOnly = true;
                    grdSubGroupAdd.Columns["Sub Group Id"].ReadOnly = true;

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
                int varviewtype = 6;
                if (btnSave.Text == "Update")
                {
                    varviewtype = 7;
                }
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdSubGroup.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                if (varGroup != "")
                {
                    objDs = objdserv.udfnSubGroupList(varviewtype, 0, varGroup, 0, varId, "");
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
                            dtSubGroup.Rows.Add(false, objDs.Tables[0].Rows[i]["Product Group Name"], objDs.Tables[0].Rows[i]["Product Sub Group Name in English"], objDs.Tables[0].Rows[i]["Product Group Id"], objDs.Tables[0].Rows[i]["Id"]);
                        }

                    }
                }
                grdSubGroup.DataSource = dtSubGroup;
                grdSubGroup.Columns[0].HeaderText = "";
                grdSubGroup.Columns[0].Width = 80;
                grdSubGroup.Columns["Product Group"].Width = 150;
                grdSubGroup.Columns["Product Subgroup"].Width = 200;
                grdSubGroup.Columns["Group Id"].Visible = false;
                grdSubGroup.Columns["Sub Group Id"].Visible = false;
                grdSubGroup.Columns["Product Group"].ReadOnly = true;
                grdSubGroup.Columns["Product Subgroup"].ReadOnly = true;
                grdSubGroup.Columns["Group Id"].ReadOnly = true;
                grdSubGroup.Columns["Sub Group Id"].ReadOnly = true;
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
            }
        }

        public void udfnclose()
        {
            try
            {
                this.Close();
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
                MainForm.objCP_BrandList.udfnList();
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
            try
            {
                if (MainForm.varCloseFlag == 0)
                {
                    if (varUpdate == 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
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
                foreach (DataGridViewRow row in grdGroup.Rows)
                {
                    row.Cells[0].Value = false;
                }
                grdSubGroup.DataSource = null;
                grdSubGroupAdd.DataSource = null;
                chkSubGroup.Checked = false;
                chkSubGroupAdd.Checked = false;
                txtEBrandNameInEnglish.Focus();
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
                varResult = objDser.udfnBrand(varViewType, varId, Convert.ToString(txtEBrandNameInEnglish.Text).Trim(), Convert.ToString(txtEBrandNameInTamil.Text).Trim(), varStatusid, varSubGroupId, varOriginator);
                objDser.CloseConnection();
                btnSave.Enabled = true;
                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtSubGroup.Rows.Clear();
                    dtSubGroupAdd.Rows.Clear();
                    if (btnSave.Text == "Save")
                    {
                        varbrandcode = Convert.ToInt16(varResult.Split('~')[2]);
                        if (varmastertype == 1)
                        {
                            varmastertype = 0;
                            MainForm.objCP_Items.varbrandcode = varbrandcode;
                            varUpdate = 1;
                            udfnclose();
                        }
                        else
                        {
                            // udfnclose(); 
                            udfnClear();
                        }
                    }
                    else
                    {
                        varUpdate = 1;
                        udfnclose();
                    }
                    MainForm.objCP_BrandList.udfnList();
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
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); MessageBox.Show("Something went wrong,Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                //if (blnErrorFlag == false && grdSubGroupAdd.Rows.Count <= 0)
                //{
                //    if (grdSubGroupAdd.Rows.Count <= 0)
                //    {
                //        DialogResult dialogResult = MessageBox.Show("Please select atleast one product sub group", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }

                //}

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
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); MessageBox.Show("Something went wrong,Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    btnSave.Focus();
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
                (grdGroup.DataSource as DataTable).DefaultView.RowFilter = "([Product Group Name in English]) LIKE '%" + txtProductGroup.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Brand_Load(object sender, EventArgs e)
        {
            try
            {
                dtGroup = new DataTable();
                dtGroup.Columns.Add("", typeof(Boolean));
                dtGroup.Columns.Add("Product Group Name in English", typeof(string));
                dtGroup.Columns.Add("ID", typeof(int));

                dtSubGroup = new DataTable();
                dtSubGroup.Columns.Add("", typeof(Boolean));
                dtSubGroup.Columns.Add("Product Group", typeof(string));
                dtSubGroup.Columns.Add("Product Subgroup", typeof(string));
                dtSubGroup.Columns.Add("Group Id", typeof(int));
                dtSubGroup.Columns.Add("Sub Group Id", typeof(int));

                // dtSubGroupAdd.Columns.Add("", typeof(Boolean));
                dtSubGroupAdd.Columns.Add("Selected Product Group", typeof(string));
                dtSubGroupAdd.Columns.Add("Selected Product Subgroup", typeof(string));
                dtSubGroupAdd.Columns.Add("Group Id", typeof(int));
                dtSubGroupAdd.Columns.Add("Sub Group Id", typeof(int));
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
                    udfnSubGroupList();
                }
                else
                {
                    DataTable objDtNew = new DataTable();
                    int varRowCount = dtSubGroup.Rows.Count;
                    varRemoveGroup = Convert.ToString(grdGroup.SelectedRows[0].Cells["ID"].Value);
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

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                                grdSubGroupAdd.Rows.RemoveAt(this.grdSubGroupAdd.SelectedRows[0].Index);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                    udfnSubGroupAdd();
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
                    chkgroup.Checked = true;
                }
                else
                {
                    varCheckAllFlag1 = 1;
                    chkgroup.Checked = false;
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < grdGroup.Rows.Count; i++)
                {

                    grdGroup.Rows[i].Cells[0].Value = chkgroup.Checked;
                    if (varGroup == "")
                    {
                        varGroup = Convert.ToString(grdGroup.Rows[i].Cells["ID"].Value);
                    }
                    else
                    {
                        varGroup = varGroup + "," + Convert.ToString(grdGroup.Rows[i].Cells["ID"].Value);
                    }
                }
                udfnSubGroupList();
                foreach (DataGridViewRow row in grdGroup.Rows)
                {
                    row.Cells[0].Value = true;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkgroup.Checked == false)
                {
                    foreach (DataGridViewRow row in grdGroup.Rows)
                    {
                        row.Cells[0].Value = false;
                    }
                    dtSubGroup.Rows.Clear();
                    dtSubGroup.AcceptChanges();
                    grdSubGroup.DataSource = dtSubGroup;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
    }
  
}
