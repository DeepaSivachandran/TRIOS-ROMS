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
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdGroupList.DataSource = null; 
                //**** To call the function from SP ***************

                if (cmbGroupType.Text == "")
                {
                    cmbGroupType.SelectedValue = 0;
                }

                SPDataService objdserv = new SPDataService();
            //    objDs = objdserv.udfnSPGroupList("List", "0",cmbGroupType.SelectedValue.ToString(), MainForm.pbUserID, MainForm.pbIpAddress);
                objdserv.CloseConnection();
                objDtExcel = objDs.Tables[0].Copy();
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
                            grdGroupList.Columns["SI.No."].Width = 60;
                            grdGroupList.Columns["Group Type"].Width = 200;
                            grdGroupList.Columns["Group Name in Tamil"].Width = 350;
                            grdGroupList.Columns["Group Name in English"].Width = 350;
                            grdGroupList.Columns["Total No.of RM"].Width = 100;
                            grdGroupList.Columns["Total No.of FG"].Width = 100; 
                            //grdGroupList.Columns["Label Name in English"].Width = 220;
                            //grdGroupList.Columns["Label Name in Tamil"].Width = 220;
                            grdGroupList.Columns["Group Order"].Width = 100;                           
                            grdGroupList.Columns["Group Order"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGroupList.Columns["SI.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGroupList.Columns["Total No.of RM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGroupList.Columns["Total No.of FG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGroupList.Columns["GroupCode"].Visible = false;
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
                grdGroupList.ClearSelection(); 
            }
        }

        public void udfndelete()
        { 

        }

        private void udfnEdit()
        {

            try
            {
                MainForm.objCP_Group = new CP_Group();
                MainForm.objCP_Group.btnSave.Text = "Update";
                MainForm.objCP_Group.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
           

        }
          

        private void CmbGroupType_KeyDown(object sender, KeyEventArgs e)
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
                    btnExport.Focus();
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

        private void TsGroupList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CP_GroupList_Load(object sender, EventArgs e)
        {

        }
    }
}
