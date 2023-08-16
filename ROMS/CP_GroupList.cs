using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;
//using ClosedXML.Excel;
namespace ROMS
{
    public partial class CP_GroupList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        DataSet objDs = new DataSet();
        DataTable objDtExcel = new DataTable();
        public CP_GroupList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Group = new CP_Group();
                MainForm.objCP_Group.ShowDialog();
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
       
        public void udfnList()
        {
            try
            {
                //picLoader.Visible = true;
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdGroupList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
              //  objDs = objdserv.udfnGroupList(0, Convert.ToInt32(cmbProductGroup.SelectedValue));
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdGroupList.DataSource = objDs.Tables[0];
                            grdGroupList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGroupList.Columns["Total Sub Groups"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGroupList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                           
                            grdGroupList.Columns["S.No."].Width = 50;
                            grdGroupList.Columns["Product Group Name in English"].Width = 200;
                            grdGroupList.Columns["Product Group Name in Tamil"].Width = 200;
                            grdGroupList.Columns["Total Sub Groups"].Width = 200;
                            grdGroupList.Columns["Total Products"].Width = 100;
                            grdGroupList.Columns["Status"].Width = 80;
                            grdGroupList.Columns["ID"].Visible = false;
                            grdGroupList.Columns["Status ID"].Visible = false;
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
               // udfnSearchGridHead();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdGroupList.ClearSelection(); 
            }
        }

        public void udfndelete()
        {
            try
            {
                if (grdGroupList.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SPDataService objDser = new SPDataService();
                        string varResult = "";
                       // string varResult = objDser.udfnGroup(2, Convert.ToInt16(grdGroupList.SelectedRows[0].Cells["ID"].Value.ToString()),"", "", 0, "Deletion");
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
                if(grdGroupList.SelectedRows.Count != 0)
                {
                    MainForm.objCP_Group = new CP_Group();
                    MainForm.objCP_Group.btnSave.Text = "Update";
                    MainForm.objCP_Group.varId = Convert.ToInt32(grdGroupList.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_Group.varGroupNameinEnglish = Convert.ToString(grdGroupList.SelectedRows[0].Cells["Product Group Name in English"].Value);
                    MainForm.objCP_Group.varGroupNameinTamil = Convert.ToString(grdGroupList.SelectedRows[0].Cells["Product Group Name in Tamil"].Value);
                    MainForm.objCP_Group.ShowDialog();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExport_Enter(object sender, EventArgs e)
        {
            try
            {
                btnExport.BackColor = Color.LemonChiffon;
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
                btnView.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExport_Leave(object sender, EventArgs e)
        {
            try
            {
                btnExport.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnView_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_GroupList_KeyDown(object sender, KeyEventArgs e)
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
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm objMainForm = new MainForm();
                    objMainForm.udfnCloseChildForms();
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

        private void CP_GroupList_Load(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbProductGroup.Select(int.MaxValue, 0)));
                this.ActiveControl = cmbProductGroup;
                udfnLoadCmbProductGroup();
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGroupList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdGroupList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdGroupList.Rows[i].Cells["Status ID"].Value) == "1")
                    {
                        grdGroupList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdGroupList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdGroupList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdGroupList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGroupList_DoubleClick(object sender, EventArgs e)
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

        private void GrdGroupList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    udfndelete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProductGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void CmbProductGroup_Leave(object sender, EventArgs e)
        {
            if (Convert.ToString(cmbProductGroup.SelectedValue) == "0" || Convert.ToString(cmbProductGroup.SelectedValue) == "-1")
            {
                cmbProductGroup.BackColor = Color.White;
            }
        }

        private void CmbProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbProductGroup.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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

        public void udfnLoadCmbProductGroup()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_ProductGroup", " PRGID  not in (-1) ORDER BY PRG_EName", "PRG_EName,PRGID", cmbProductGroup, "", "PRG_EName", "PRGID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExport_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                BtnExport_Click(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
