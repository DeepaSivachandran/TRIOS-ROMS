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
    public partial class CP_ProductHSNList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_ProductHSNList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_ProductHSN = new CP_ProductHSN();
                MainForm.objCP_ProductHSN.ShowDialog();
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
                MainForm.objCP_ProductHSN = new CP_ProductHSN();
                MainForm.objCP_ProductHSN.btnSave.Text = "Update";
                MainForm.objCP_ProductHSN.varHsnname = grdHSNList.SelectedRows[0].Cells["HSN Name"].Value.ToString();
                MainForm.objCP_ProductHSN.varHsnCode = grdHSNList.SelectedRows[0].Cells["HSN Code"].Value.ToString();
                MainForm.objCP_ProductHSN.varGst = grdHSNList.SelectedRows[0].Cells["GST%"].Value.ToString();
                MainForm.objCP_ProductHSN.ShowDialog();
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
                MessageBox.Show("Do you want to delete  ?", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        public void udfnHsnList()
        {
            try
            {
                picLoader.Visible = true;
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdHSNList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnHsnList(0);
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
                            grdHSNList.DataSource = objDs.Tables[0];
                            grdHSNList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdHSNList.Columns["S.No."].Width = 50;
                            grdHSNList.Columns["HSN Name"].Width = 200;
                            grdHSNList.Columns["HSN Code"].Width = 100;
                            grdHSNList.Columns["GST%"].Width = 75;
                            grdHSNList.Columns["Total Products"].Width = 100;
                            grdHSNList.Columns["Status"].Width = 100;
                            grdHSNList.Columns["ID"].Visible = false;
                            grdHSNList.Columns["GST ID"].Visible = false;
                            grdHSNList.Columns["Status ID"].Visible = false;
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
                ///udfnSearchGridHead();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdHSNList.ClearSelection();
                picLoader.Visible = false;
            }
        }
        private void CP_ProductHSNList_Load(object sender, EventArgs e)
        {
            try
            {
                udfnHsnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_ProductHSNList_KeyDown(object sender, KeyEventArgs e)
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
    }
}
