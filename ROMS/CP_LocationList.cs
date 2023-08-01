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
    public partial class CP_LocationList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_LocationList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Location = new CP_Location();
                MainForm.objCP_Location.ShowDialog();
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

        private void CP_LocationList_Load(object sender, EventArgs e)
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


        public void udfnList()
        {
            try
            {
                picLoader.Visible = true;
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdGodownList.DataSource = null;
                DataSet objDs =new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
               // objDs = objdserv.udfnSPLocationList("List", "0", MainForm.pbUserID, MainForm.pbIpAddress);
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
                            grdGodownList.DataSource = objDs.Tables[0];
                            grdGodownList.Columns["Location Name"].Width = 220;
                            grdGodownList.Columns["Location Order"].Width = 100;
                            grdGodownList.Columns["Location Order"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGodownList.Columns["SI.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGodownList.Columns["LocationCode"].Visible = false;
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
                grdGodownList.ClearSelection();
                picLoader.Visible = false;
            }
        }

        public void udfndelete()
        {
            try
            {
                if (grdGodownList.SelectedRows.Count > 0)
                {
                    string result = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {

                        SPDataService objspdservice = new SPDataService();
                     //   result = objspdservice.udfnSPLocationMaster("Delete", grdLocationList.SelectedRows[0].Cells["LocationCode"].Value.ToString(),"","", MainForm.pbUserID, MainForm.pbIpAddress, "Location Delete");

                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            udfnList();

                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MainForm.objCP_Location = new CP_Location();
                MainForm.objCP_Location.btnSave.Text = "Update";
                MainForm.objCP_Location.ShowDialog();
                //if (grdGodownList.SelectedRows.Count > 0)
                //{
                //    MainForm.objCP_Location = new CP_Location();
                //    //MainForm.objCP_Location.MdiParent = this.ParentForm;
                //    MainForm.objCP_Location.varlocationcode = grdGodownList.SelectedRows[0].Cells["LocationCode"].Value.ToString();
                //    MainForm.objCP_Location.ShowDialog();

                //}

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CP_LocationList_KeyDown(object sender, KeyEventArgs e)
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
        public void grdLocationList_DoubleClick(object sender, EventArgs e)
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
        public void grdLocationList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) {
                    udfnEdit();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void grdLocationList_SelectionChanged(object sender, EventArgs e)
        {
            try {
                if (Convert.ToString(grdGodownList.Rows[grdGodownList.CurrentCell.RowIndex].Cells["LocationCode"].Value) == "1") { tsbDelete.Visible = false; tsbEdit.Visible = false;tssNew.Visible = false; }
                else { tsbDelete.Visible = true; tsbEdit.Visible = true; tssNew.Visible = true; }
            }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGodownList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
