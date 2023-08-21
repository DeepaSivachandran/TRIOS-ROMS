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
        public int varbrandcode=0;

        private ToolTip tpBrandNameInEnglish = new ToolTip();
        private ToolTip tpBrandNameInTamil = new ToolTip();

        public int varStatusid = 0;
        public int varCloseFlag = 0;
        public int varFormFlag = 0;
        public int varId = 0;

        public string varGroupId = "";
        public string varSubGroupId = "";
        public int varmastertype = 0;
        public string varGroup = "";
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
                DataSet objDS = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDS = objdserv.udfnBrandList(1, varId,0,0);
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
                            grdSubGroupAdd.Rows.Add(false, objDS.Tables[1].Rows[i]["Selected Product Group"], 
                                objDS.Tables[1].Rows[i]["Selected Product Sub Group"], objDS.Tables[1].Rows[i]["PRGID"],
                                objDS.Tables[1].Rows[i]["PRSGID"]);
                        }
                    }
                }
                foreach (DataGridViewRow row in grdGroup.Rows)
                {

                    DataGridViewCheckBoxCell chkBox = (DataGridViewCheckBoxCell)row.Cells[0];
                    chkBox.Value = true;
                    if (chkBox.Value == chkBox.TrueValue)
                    {
                        chkBox.Value = chkBox.FalseValue;
                    }
                    else
                    {
                        chkBox.Value = chkBox.TrueValue;
                    }

                    chkBox.Value = true;


                }


                if (grdSubGroupAdd.Rows.Count > 0)
                 {
                    for (int i = 0; i< grdSubGroupAdd.Rows.Count; i++)
                    {
                        foreach (DataGridViewRow row in this.grdSubGroupAdd.Rows)
                        {
                            ((DataGridViewCheckBoxCell)row.Cells[0]).Value = true;
                        }

                        //for (int j = 0; j < grdGroup.Rows.Count; j++)
                        //{
                        //    if (Convert.ToInt32(grdSubGroupAdd.Rows[i].Cells["clmGroupIdAdd"].Value) == Convert.ToInt32( grdGroup.Rows[j].Cells["ID"].Value))
                        //    {
                        //        grdGroup.Rows[j].Cells["clmChkProductGroup"].Value = true; 
                        //    }
                        //}

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
                //picLoader.Visible = true;
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdGroup.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnGroupList(0, 0);
                objdserv.CloseConnection();

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    grdGroup.DataSource = objDs.Tables[0];
                    grdGroup.Columns["S.No."].Visible = false;
                    grdGroup.Columns["Product Group Name in English"].Width = 200;
                    grdGroup.Columns["Product Group Name in English"].HeaderText = "Product Group";
                    grdGroup.Columns["Product Group Name in Tamil"].Visible = false;
                    grdGroup.Columns["Total Sub Groups"].Visible = false;
                    grdGroup.Columns["Total Products"].Visible = false;
                    grdGroup.Columns["Status"].Visible = false;
                    grdGroup.Columns["ID"].Visible = false;
                    grdGroup.Columns["Status ID"].Visible = false;

                }

               // udfnRefreshSubGroup();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnSubGroupAdd()
        {
            try
            {
                grdSubGroupAdd.Rows.Clear();
                if (grdSubGroup.Rows.Count > 0)
                {
                    for (int i = 0; i < grdSubGroup.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdSubGroup.Rows[i].Cells["clmchkProductSubGroup"].Value) == true)
                        {
                            grdSubGroupAdd.Rows.Add(false, grdSubGroup.Rows[i].Cells["clmProductGroup"].Value, grdSubGroup.Rows[i].Cells["clmSubGroups"].Value, grdSubGroup.Rows[i].Cells["clmGroupId"].Value, grdSubGroup.Rows[i].Cells["clmSubGroupId"].Value);

                        }
                       
                        if (varSubGroupId == "")
                        {
                            varSubGroupId = Convert.ToString(grdSubGroup.Rows[i].Cells["clmSubGroupId"].Value);
                        }
                        else
                        {
                            varSubGroupId = varSubGroupId + "," + Convert.ToString(grdSubGroup.Rows[i].Cells["clmSubGroupId"].Value);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
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
                if (grdSubGroupAdd.Rows.Count > 0)
                {
                    for (int i = 0; i < grdSubGroupAdd.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdSubGroupAdd.Rows[i].Cells["chkSelectedSubGroup"].EditedFormattedValue) == true)
                        {
                            grdSubGroupAdd.Rows.RemoveAt(i);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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
                //grdSubGroup.Columns["clmGroupId"].Visible = false;
               // grdSubGroup.Columns["clmSubGroupId"].Visible = false;

                //picLoader.Visible = true;
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdSubGroup.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                if (varGroup != "")
                {
                    objDs = objdserv.udfnSubGroupList(0, 0, varGroup);
                }
                objdserv.CloseConnection();
                if(objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        grdSubGroup.Rows.Add(false, objDs.Tables[0].Rows[i]["Product Group Name"], objDs.Tables[0].Rows[i]["Product Sub Group Name in English"], objDs.Tables[0].Rows[i]["Product Group Id"], objDs.Tables[0].Rows[i]["Id"]);
                    }
                }
                //udfnRefreshSubGroup();
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
                //  MainForm.objCP_BrandList.udfnList();
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
                if (varCloseFlag == 0)
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
                if (rbActive.Checked)
                {
                    varStatusid = 1;
                }
                else
                {
                    varStatusid = 2;
                }
                if (btnSave.Text == "Save")
                {
                    SPDataService objDser = new SPDataService();
                    string varResult = objDser.udfnBrand(0,0,Convert.ToString(txtEBrandNameInEnglish.Text), Convert.ToString(txtEBrandNameInTamil.Text), varStatusid,varSubGroupId,"Creation");
                    objDser.CloseConnection();
                    if (varResult.Split('~')[0] == "3")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        varbrandcode = Convert.ToInt16(varResult.Split('~')[2]);
                        if (varmastertype == 1)
                        {
                            varmastertype = 0;
                            MainForm.objCP_Items.varbrandcode = varbrandcode;
                            varCloseFlag = 1;
                            udfnclose();
                        }
                        else
                        { 
                            MainForm.objCP_BrandList.udfnList();
                        }
                        udfnClear();
                    }
                    else if (varResult.Split('~')[0] == "4")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                    else if(btnSave.Text == "Update")
                    {
                        SPDataService objDser = new SPDataService();
                        string varResult = objDser.udfnBrand(1,varId, Convert.ToString(txtEBrandNameInEnglish.Text), Convert.ToString(txtEBrandNameInTamil.Text), varStatusid, varSubGroupId, "Updation");
                        objDser.CloseConnection();
                        if (varResult.Split('~')[0] == "3")
                        {
                            MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            varbrandcode = Convert.ToInt16(varResult.Split('~')[2]);
                            if (varmastertype == 1)
                            {
                                varmastertype = 0;
                                MainForm.objCP_Items.varbrandcode = varbrandcode;
                                varCloseFlag = 1;
                                udfnclose();
                            }
                            else
                            {
                                MainForm.objCP_BrandList.udfnList();
                            }
                            udfnClear();
                        }
                        else if (varResult.Split('~')[0] == "4")
                        {
                            MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                    btnRemove.Focus();
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
                btnRemove.BackColor = Color.White;
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
                btnSave.BackColor = Color.White;
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
                btnClose.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void TxtEBrandNameInTamil_TextChanged(object sender, EventArgs e)
        {

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
                udfnList();
                //udfnSubGroupList();
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
                (grdSubGroup.DataSource as DataTable).DefaultView.RowFilter = "([Product Subgroup]) LIKE '%" + txtProductSubGroup.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Chkgroup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                varGroup = "";

                for (int i = 0; i < grdGroup.Rows.Count; i++)
                {
                    grdGroup.Rows[i].Cells["clmChkProductGroup"].Value = chkgroup.Checked;
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

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkSubGroup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdGroup.Rows.Count; i++)
                {
                    grdGroup.Rows[i].Cells["clmchkProductSubGroup"].Value = chkSubGroup.Checked;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void GrdGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varGroup = ""; string varRemoveGroup = "";
               
                if (Convert.ToBoolean(grdGroup.SelectedRows[0].Cells["clmChkProductGroup"].EditedFormattedValue) == true)
                {
                    varGroup = Convert.ToString(grdGroup.SelectedRows[0].Cells["ID"].Value);
                    udfnSubGroupList();
                }
                else
                {
                    varRemoveGroup = Convert.ToString(grdGroup.SelectedRows[0].Cells["ID"].Value);
                    for (int i = 0; i < grdSubGroup.Rows.Count; i++)
                    {
                        if(varRemoveGroup == Convert.ToString(grdSubGroup.Rows[i].Cells["clmGroupId"].Value))
                        { 
                            grdSubGroup.Rows.RemoveAt(i);
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
                (grdSubGroup.DataSource as DataTable).DefaultView.RowFilter = "([Product Sub Group Name in English]) LIKE '%" + txtProductSubGroup.Text + "%'";
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
                if (grdSubGroup.SelectedRows.Count > 0)
                {
                    udfnSubGroupAdd();
                }
                else
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

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

               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void GrdSubGroupAdd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
  
}
