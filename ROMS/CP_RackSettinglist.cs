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
    public partial class CP_RackSettinglist : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_RackSettinglist()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_RackSettings = new CP_RackSettings();
                MainForm.objCP_RackSettings.MdiParent = ParentForm;
                MainForm.objCP_RackSettings.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                udfndelete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfndelete()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    SPDataService objDser = new SPDataService();

                    string varResult = objDser.udfnRackSettings(2, 0, 0 ,Convert.ToInt16(grdRackSettingList.SelectedRows[0].Cells["RKID"].Value.ToString()), "",0, 0, "RackSettings Delete");
                    objDser.CloseConnection();
                    if (varResult.Split('~')[0] == "3")
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnList();
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
        private void udfnEdit()
        {
            try
            {
                if (grdRackSettingList.SelectedRows.Count > 0)
                {
                    MainForm.objCP_RackSettings = new CP_RackSettings();
                    MainForm.objCP_RackSettings.MdiParent = ParentForm;
                    MainForm.objCP_RackSettings.btnSave.Text = "Update";
                    MainForm.objCP_RackSettings.varRacksettingID = Convert.ToInt32(grdRackSettingList.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_RackSettings.PbRKID = Convert.ToInt32(grdRackSettingList.SelectedRows[0].Cells["RKID"].Value);
                    MainForm.objCP_RackSettings.PbStockLocation = Convert.ToString(grdRackSettingList.SelectedRows[0].Cells["Stock Location"].Value);
                    MainForm.objCP_RackSettings.PbLocationCode = Convert.ToInt32(grdRackSettingList.SelectedRows[0].Cells["LocationID"].Value);
                    MainForm.objCP_RackSettings.PbRackName = Convert.ToString(grdRackSettingList.SelectedRows[0].Cells["Rack Name"].Value);
                    MainForm.objCP_RackSettings.PbPICode = Convert.ToString(grdRackSettingList.SelectedRows[0].Cells["P.I Code"].Value);
                    MainForm.objCP_RackSettings.PbProductName = Convert.ToString(grdRackSettingList.SelectedRows[0].Cells["Product Name"].Value);
                    MainForm.objCP_RackSettings.PbUnit = Convert.ToString(grdRackSettingList.SelectedRows[0].Cells["Unit"].Value);
                    MainForm.objCP_RackSettings.Show();
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
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdRackSettingList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                DataService objDServ = new DataService();
                int varRackId = 0;
                if (txtRack.Text != "")
                {
                    string varId_PurRack = "0";
                    DataSet objDsPurRack = new DataSet();
                    SPDataService objDServ4 = new SPDataService();
                    objDsPurRack = objDServ4.udfnRackList(9, 0, 0, 0, 0, txtRack.Text.Trim());
                    objDServ4.CloseConnection();
                    if (objDsPurRack != null)
                    {
                        if (objDsPurRack.Tables.Count > 0)
                        {
                            if (objDsPurRack.Tables[0].Rows.Count > 0)
                            {
                                varId_PurRack = Convert.ToString(objDsPurRack.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varRackId = Convert.ToInt32(varId_PurRack);
                }
                objDs = objspservice.udfnRackSettingsList(0,0,0, 0,varRackId);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdRackSettingList.DataSource = objDs.Tables[0];
                            grdRackSettingList.Columns["ID"].Visible = false;
                            grdRackSettingList.Columns["RKID"].Visible = false;
                            grdRackSettingList.Columns["LocationID"].Visible = false;
                            grdRackSettingList.Columns["sno"].Visible = false;
                            grdRackSettingList.Columns["S.No."].Width = 50;
                            grdRackSettingList.Columns["P.I Code"].Width = 100;
                            grdRackSettingList.Columns["Stock Location"].Width = 150;
                            grdRackSettingList.Columns["Rack ShortName"].Width = 150;
                            grdRackSettingList.Columns["Rack Name"].Width = 150;
                            grdRackSettingList.Columns["Product Name"].Width = 300;
                            grdRackSettingList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                picLoader.SendToBack();
            }
        }
        private void CP_RackSettinglist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    tsbEdit_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.D))
                {
                    tsbDelete_Click(sender, e);
                }
                if ((e.KeyCode == Keys.Delete))
                {
                    tsbDelete_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_RackSettinglist_Load(object sender, EventArgs e)
        {
            try
            {
                txtRack.Focus();
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdRackSettingList.ClearSelection();
            }
        }
        private void TxtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int varRackId = 0;
                if (txtRack.Text == "")
                {
                    varRackId = 0;
                    lvRack.Visible = false;
                }
                else
                {
                    lvRack.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtRack.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnRackList(8, 0, 0, 0, 0, txtRack.Text);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        lvRack.Columns[1].Width = 0;
                                        lvRack.Items.Add(objList);
                                    }
                                    lvRack.Visible = true;
                                }
                                else
                                {
                                    lvRack.Visible = false;
                                }
                            }
                            else
                            {
                                lvRack.Visible = false;
                            }
                        }
                        else
                        {
                            lvRack.Visible = false;
                        }
                    }
                    else
                    {
                        lvRack.Visible = false;
                        lvRack.Items.Clear();
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

            }
        }
        private void TxtRack_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode==Keys.Enter)
                {
                    if (lvRack.Items.Count == 0 || txtRack.Text == "")
                    {
                        txtRack.Focus();
                        lvRack.Visible = false;
                    }
                    else
                    {
                        lvRack.Focus();
                    }
                    if (lvRack.Items.Count > 0)
                    {
                        lvRack.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRack.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnRackEvent();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnRackEvent();
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRackEvent()
        {
            try
            {
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvRack.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                    lblRack.Text = selectedItem.SubItems[1].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvRack.Visible = false;
            }
        }
        private void BtnView_Click(object sender, EventArgs e)
        {
            udfnList();
        }
        private void GrdRackSettingList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdRackSettingList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEdit();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
                lvRack.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
