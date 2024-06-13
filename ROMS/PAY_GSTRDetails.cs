using ROMS.Model;
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
    //Created By:- K
    //Created On:- 02-09-2023
    public partial class PAY_GSTRDetails : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpDestinationLocation = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tppRack = new ToolTip();
        private ToolTip tpProductGroup = new ToolTip();
        private ToolTip tppProductGroup = new ToolTip();
        private ToolTip tpProductSubGroup = new ToolTip();
        private ToolTip tppProductSubGroup = new ToolTip();

        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpSourceRack = new ToolTip();
        private ToolTip tpDestinationRack = new ToolTip();

        Boolean BlnSearchImageYN = false;
        public DataTable dtViewProduct = new DataTable();
        public DataTable dtMoveProduct = new DataTable();
        DataTable dtGSTR = new DataTable();


        public int varId = 0;
        public int varGroupId = 0;
        public int varSubGroupId = 0;
        public int varCheckAllFlag = 0;
        public int varCheckAll = 0;
        public string varPurchaseID = "";
        public string varSuppliervalue = "";
        public int varUpdate = 0;


        public PAY_GSTRDetails()
        {
            InitializeComponent();
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Supplier = new CP_Supplier();
                MainForm.objCP_Supplier.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridColumn()
        {
            try
            {
                DGV_SearchGrid.Columns.Add("clmInvDate", "Inv Date");
                DGV_SearchGrid.Columns.Add("clmInvNo", "Inv No.");
                DGV_SearchGrid.Columns.Add("clmInvAmnt", "Inv Amt");
                DGV_SearchGridMove.Columns.Add("clmDate", "Inv Date");
                DGV_SearchGridMove.Columns.Add("clmNo", "Inv No.");
                DGV_SearchGridMove.Columns.Add("clmAmount", "Inv Amt");
                DGV_SearchGridMove.Columns.Add("clmGSTRAmount", "GSTR Amt");
                DGV_SearchGridMove.Columns.Add("clmRemove", "Remove");
                //DGV_SearchGrid.Columns["clmInvDate"].Width = 250;
                //DGV_SearchGridMove.Columns["clmProductName"].Width = 250;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
                DGV_SearchGridMove.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        
        private void CP_BrandList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
               
                //if (e.KeyCode == Keys.Escape)
                //{
                //    MainForm.objStart = new DEF_Start();
                //    MainForm.objStart.MdiParent = this.ParentForm;
                //    MainForm.objStart.Show();
                //    this.Close();
                //}
                if (e.KeyCode == Keys.Escape)
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
        public void udfnclose()
        {
            try
            {
                if (varUpdate == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MainForm objMainForm = new MainForm();
                        objMainForm.udfnCloseChildForms();
                        MainForm.objStart = new DEF_Start();
                        MainForm.objStart.MdiParent = this.ParentForm;
                        MainForm.objStart.Show();
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnclear()
        {            
           
            grdViewProduct.DataSource = null;
            dtMoveProduct.Rows.Clear();
            dtMoveProduct.AcceptChanges();
            grdMoveProduct.DataSource = null;
            dtViewProduct.Rows.Clear();
            dtViewProduct.AcceptChanges();
            dtGSTR.Rows.Clear();
        } 
        
        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdViewProduct, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdViewProduct.Columns)
                {
                    DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_SearchGrid.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_SearchGrid.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_SearchGrid.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_SearchGrid.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnGridSearchHeadMove(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                DGV_SearchGridMove.ReadOnly = false;
                dgv2.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in dgv1.Columns)
                {
                    if (col.Visible)
                    {
                        dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                }
                int rowIndex = 0;
                int ColIndex = 0;
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                BlnSearchImageYN = false;
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                    if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                    {
                        //dgv2.Rows[rowIndex].Visible = false;
                        BlnSearchImageYN = true;
                        ColIndex = i;
                        dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                        dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                        ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                    }
                    else if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Boolean")
                    {
                        BlnSearchImageYN = true;
                        dgv2.Rows[rowIndex].Cells[i].Value = false;
                    }
                    else
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnSearchGridHeadMove()
        {
            try
            {
                udfnGridSearchHeadMove(grdMoveProduct, DGV_SearchGridMove);
                DGV_SearchGridMove.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdMoveProduct.Columns)
                {
                    DGV_SearchGridMove.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                int rowIndex = 0;
                DGV_SearchGridMove.Rows.Clear();
                DGV_SearchGridMove.Rows.Add();
                DGV_SearchGridMove.Columns[0].DefaultCellStyle.NullValue = null;
                DGV_SearchGridMove.Columns[1].DefaultCellStyle.NullValue = null;
                for (int i = 2; i < visibleColumns.Count; i++)
                {
                    DGV_SearchGridMove.Rows[rowIndex].Cells[i].Value = "";
                }
                DGV_SearchGridMove.Columns["S.No."].ReadOnly = true;
                DGV_SearchGridMove.Columns[0].ReadOnly = true;
                DGV_SearchGridMove.Columns[1].ReadOnly = true;
                DGV_SearchGridMove.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                DGV_SearchGridMove.Rows[0].Cells[1].Value = new Bitmap(1, 1);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                //dgv2.DataSource = null;
                dgv2.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in dgv1.Columns)
                {
                    if (col.Visible)
                    {
                        dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                }
                int rowIndex = 0;
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    dgv2.Rows[rowIndex].Cells[i].Value = "";
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnMoveList()
        {
            try
            {
                    dtViewProduct.Rows.Clear();
                    dtViewProduct.AcceptChanges();
                    grdViewProduct.DataSource = null;
                    int varViewType = 16;
                    Application.DoEvents();
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRN_PurchaseEntry.ViewType = varViewType;
                    objTRN_PurchaseEntry.paraSupplierID = Convert.ToInt32(lblSuppliercode.Text);
                    objTRN_PurchaseEntry.paraScheduleID = Convert.ToInt32(lblschedule.Text);                   
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    objDs = objdserv.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                dtViewProduct.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No"], objDs.Tables[0].Rows[i]["Inv.Date"], objDs.Tables[0].Rows[i]["Inv.No"], objDs.Tables[0].Rows[i]["Inv Amount"],
                                   objDs.Tables[0].Rows[i]["PURID"]);
                            }
                        }
                        grdViewProduct.DataSource = null;
                        grdViewProduct.DataSource = dtViewProduct;
                        grdViewProduct.Columns[0].HeaderText = "";
                        grdViewProduct.Columns[0].Width = 50;
                        grdViewProduct.Columns["S.No."].Width = 50;
                        grdViewProduct.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdViewProduct.Columns["Inv Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdViewProduct.Columns["Inv Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdViewProduct.Columns["PURID"].Visible = false;
                        udfnSearchGridHead();
                    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //lblViewProductCount.Text = Convert.ToString(grdViewProduct.Rows.Count);
                //lblMoveProCount.Text = Convert.ToString(grdMoveProduct.Rows.Count);
            }
        }
        private void BtnProductView_Click(object sender, EventArgs e)
        {
            try
            {
               
                udfnMoveList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnProductView_Enter(object sender, EventArgs e)
        {
            try
            {
                lvSupplier.Visible = false;
                //lvProductSubGroup.Visible = false;
                btnProductView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnProductView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnProductView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
     
        
        private void GrdViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    udfnCalCheckedCount();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnCalCheckedCount()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdViewProduct.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdViewProduct.Rows[i].Cells[0].EditedFormattedValue) == true)
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
                //if (grdViewProduct.Rows.Count == varCheckedCount)
                //{
                //    varCheckAll = 1;
                //    checkAll.Checked = true;
                //}
                //else
                //{
                //    varCheckAll = 1;
                //    checkAll.Checked = false;
                //}
            }
        }
        private void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void BtnAddgrid_Click(object sender, EventArgs e)
        {
            try
            {
                udfnMoveData();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void RemoveProduct()
        {
            try
            {
                string varRemove = "";
                for (int j = 0; j < dtMoveProduct.Rows.Count; j++)
                {
                    varRemove = Convert.ToString(grdMoveProduct.Rows[j].Cells["PURID"].Value);
                    for (int i = 0; i < dtViewProduct.Rows.Count; i++)
                    {
                        if (varRemove == Convert.ToString(dtViewProduct.Rows[i]["PURID"]))
                        {
                            dtViewProduct.Rows[i].Delete();
                            dtViewProduct.AcceptChanges();
                        }
                    }
                }
               // grdViewProduct.DataSource = dtViewProduct;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnMoveData()
        {
            try
            {
                //string varRemoveData = "", VarAddData = "";

                if (grdViewProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < grdViewProduct.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdViewProduct.Rows[i].Cells[0].Value) == true)
                        {
                            dtMoveProduct.Rows.Add(grdViewProduct.Rows[i].Cells["Inv Date"].Value,
                            grdViewProduct.Rows[i].Cells["Inv No."].Value, grdViewProduct.Rows[i].Cells["Inv Amt"].Value, 0, grdViewProduct.Rows[i].Cells["PURID"].Value);
                        }
                        
                    }
                    grdMoveProduct.DataSource = null;
                    grdMoveProduct.DataSource = dtMoveProduct;
                    grdMoveProduct.Columns["PURID"].Visible = false;
                    grdMoveProduct.Columns["PURID"].ReadOnly = true;
                    grdMoveProduct.Columns["Inv Date"].ReadOnly = true;
                    grdMoveProduct.Columns["Inv Amt"].ReadOnly = true;
                    grdMoveProduct.Columns["Inv No."].ReadOnly = true;
                    grdMoveProduct.Columns["GSTR Amt"].ReadOnly = false;
                    //grdMoveProduct.Columns["clmRemove"].DisplayIndex = 5;
                    RemoveProduct();
                    udfnSearchGridHeadMove();
                    
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //lblMoveProCount.Text = Convert.ToString(grdMoveProduct.Rows.Count);
                //lblViewProductCount.Text = Convert.ToString(grdViewProduct.Rows.Count);
            }
        }

        private void BtnMoveSave_Click(object sender, EventArgs e)
        {
            try
            {
                //bool blnErrorFlag = false;
                //if (grdMoveProduct.Rows.Count > 0)
                //{
                //    udfnSLocationValidation();
                //    udfnDLocationValidation();
                //   // if (Convert.ToString(cmbSourceRack.SelectedValue) == "" || Convert.ToString(cmbSourceRack.SelectedValue) == "-1")
                //    if ( Convert.ToString(cmbSourceRack.SelectedValue) == "-1")
                //    {
                //        epRackSettings.SetError(cmbSourceRack, "Please select source rack.");
                //        cmbSourceRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpSourceRack.ShowAlways = true;
                //        tpSourceRack.Show("Please select source rack.", cmbSourceRack, 5000);
                //        sourceFalg = 1;
                //    }
                //    //if (Convert.ToString(cmbDestinationRack.SelectedValue) == "" || Convert.ToString(cmbDestinationRack.SelectedValue) == "-1")
                //    if (Convert.ToString(cmbDestinationRack.SelectedValue) == "-1")
                //    {
                //        epRackSettings.SetError(cmbDestinationRack, "Please select destination rack.");
                //        cmbDestinationRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpDestinationRack.ShowAlways = true;
                //        tpDestinationRack.Show("Please select destination rack.", cmbDestinationRack, 5000);
                //        DestinationFlag = 1;
                //    }
                //    if (varSourceRackID!=-1 && varDestinationRackID!=-1 && sourceFalg==0 && DestinationFlag==0)
                //    {
                //        udfnMoveSave(sender, e);
                //    }
                //}
                //else
                //{
                //    SPDataService objDServ = new SPDataService();
                //    string varMessage = objDServ.udfnGetMessages(38);
                //    objDServ.CloseConnection();
                //    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    blnErrorFlag = true;
                //}
                //    //if(txtDRack.Text.Trim()==txtMoveRack.Text.Trim())
                //    //{
                //    //    txtMoveRack.Text = "";
                //    //    blnErrorFlag = true;
                //    //}
                //    //if (blnErrorFlag == false)
                //    //{
                //    //    btnMoveSave.Enabled = false;
                //    //    udfnMoveSave(sender, e);
                //    //}
                udfnMoveSave(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void udfnMoveSave(object sender, EventArgs e)
        {
            try
            {
                
                txtSupplier.Text = "";
                string varResult = "",
                result = ""; int varType = 7, varFlag = 0;
                dtGSTR.Rows.Clear();
                varPurchaseID = "";
                for (int i = 0; i < grdMoveProduct.RowCount; i++)
                {
                       
                    dtGSTR.Rows.Add(grdMoveProduct.Rows[i].Cells["PURID"].Value, grdMoveProduct.Rows[i].Cells["GSTR Amt"].Value);
                }
                SPDataService objspdservice = new SPDataService();
                DataTable objGrnPO = new DataTable();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = varType;
                objTRN_PurchaseEntry.ParaTRN_GSTR = dtGSTR;
                result = objspdservice.udfnSetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    udfnclear();
                    //txtSourceLocation.Focus();
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnMoveSave.Enabled = true;
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
                btnMoveSave.Focus();
            }
            finally
            {
                btnMoveSave.Enabled = true;
            }
        }
        private void BtnMoveSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnMoveSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnMoveSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnMoveSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnMoveClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
       
        private void GrdMoveProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdMoveProduct.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                dtViewProduct.Rows.Add(false,grdViewProduct.Rows.Count+1,grdMoveProduct.SelectedRows[0].Cells["Inv Date"].Value, grdMoveProduct.SelectedRows[0].Cells["Inv No."].Value,
                                   grdMoveProduct.SelectedRows[0].Cells["Inv Amt"].Value, grdMoveProduct.SelectedRows[0].Cells["PURID"].Value);
                                dtViewProduct.AcceptChanges();
                                grdMoveProduct.DataSource = null;
                                grdMoveProduct.DataSource = dtMoveProduct;
                                grdMoveProduct.Columns["PURID"].Visible = false;                    
                                grdMoveProduct.Columns[0].ReadOnly = false;
                                grdMoveProduct.Rows.RemoveAt(this.grdMoveProduct.SelectedRows[0].Index);
                                
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
        private void CP_RackSettings_Leave(object sender, EventArgs e)
        {
            try
            {
                tpStockLocation.Active = false;
                tpDestinationLocation.Active = false;
                tpRack.Active = false;
                tppRack.Active = false;
                tpProductGroup.Active = false;
                tppProductGroup.Active = false;
                tpProductSubGroup.Active = false;
                tppProductSubGroup.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnselectAll_Click(object sender, EventArgs e)
        {

        }
        

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
          
        }
           
        private void BtnSubGrupUnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdViewProduct.Rows)
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

        private void BtnProductSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdViewProduct.Rows.Count; i++)
                {
                    //grdViewProduct.Rows[i].Cells[0].Value = checkAll.Checked;
                }

                foreach (DataGridViewRow row in grdViewProduct.Rows)
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

        private void BtnProductSelectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                BtnProductSelectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnProductSelectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                BtnProductSelectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdViewProduct.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdViewProduct);
                objDser.CloseConnection();
                grdViewProduct.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            
        }
        private void DGV_SearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }
        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdViewProduct.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdViewProduct.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdViewProduct.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            // Sort a new column and remove the old SortGlyph.
                            direction = ListSortDirection.Ascending;
                            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                        }
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    grdViewProduct.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdViewProduct.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdViewProduct.ColumnCount > 0)
                {
                    grdViewProduct.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdViewProduct.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                //txtSearchProductName1.Text = "";
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdViewProduct.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdViewProduct);
                objDser.CloseConnection();
                grdViewProduct.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //lblViewProductCount.Text = grdViewProduct.Rows.Count.ToString();
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //for (int i = 0; i < grdViewProduct.RowCount; i++)
                //{
                //    if (Convert.ToString(grdViewProduct.Rows[i].Cells["MappedCount"].Value) != "0")
                //    {
                //        grdViewProduct.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdViewProduct.ClearSelection();
            }
        }
        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdViewProduct.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdViewProduct.Width > grdViewProduct.HorizontalScrollingOffset && grdViewProduct.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdViewProduct_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdViewProduct.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdViewProduct.Width > grdViewProduct.HorizontalScrollingOffset && grdViewProduct.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdViewProduct);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnscrollVisibleMOve(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdMoveProduct.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGridMove.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGridMove.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGridMove.Rows[rowIndex].Cells[i].Value = "";
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
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdViewProduct.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
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
        private void GrdViewProduct_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdViewProduct.IsCurrentCellDirty)
                {
                    grdViewProduct.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGridMove_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdMoveProduct.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridMove, grdMoveProduct);
                objDser.CloseConnection();
                grdMoveProduct.HorizontalScrollingOffset = DGV_SearchGridMove.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
           
        }

        private void DGV_SearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGV_SearchGridMove_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 || e.ColumnIndex == 0))   /*If not our desired columns*/
                                                                   //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGridMove.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridMove_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewColumn newColumn = grdMoveProduct.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdMoveProduct.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdMoveProduct.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
                grdMoveProduct.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_SearchGridMove.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_SearchGridMove.HorizontalScrollingOffset = grdMoveProduct.HorizontalScrollingOffset;
                DGV_SearchGridMove.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridMove_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdMoveProduct.ColumnCount > 0)
                {
                    grdMoveProduct.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGridMove.HorizontalScrollingOffset = grdMoveProduct.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGridMove_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGridMove.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGridMove.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdMoveProduct.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridMove, grdMoveProduct);
                objDser.CloseConnection();
                grdMoveProduct.HorizontalScrollingOffset = DGV_SearchGridMove.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //lblMoveProCount.Text = Convert.ToString(grdMoveProduct.Rows.Count);
            }
        }
        private void DGV_SearchGridMove_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdMoveProduct.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridMove, grdMoveProduct);
                objDser.CloseConnection();
                grdMoveProduct.HorizontalScrollingOffset = DGV_SearchGridMove.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridMove_Scroll(object sender, ScrollEventArgs e)
        {
           try
            {
                int totalWidth = 0;
                int offSetValue = grdMoveProduct.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridMove.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdMoveProduct.Width > grdMoveProduct.HorizontalScrollingOffset && grdMoveProduct.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridMove.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridMove.Invalidate();
                udfnscrollVisibleMOve(DGV_SearchGridMove, grdMoveProduct);

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnProductView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSupplier.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtSupplier.Focus();
                        lvSupplier.Visible = false;
                    }
                    else
                    {
                        lvSupplier.Focus();
                    }
                    if (lvSupplier.Items.Count > 0)
                    {
                        lvSupplier.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSupplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 36;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSupplier.Items.Add(objList);
                                }
                                lvSupplier.Visible = true;
                                lvSupplier.Columns[1].Width = 0;
                                lvSupplier.Columns[2].Width = 0;
                                lvSupplier.Columns[0].Width = 300;
                                lvSupplier.Columns[3].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    lvSupplier.Visible = false;
                    lvSupplier.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnListViewData()
        {
            try
            {
                if (txtSupplier.Text != "")
                {
                    ListViewItem selectedItem = lvSupplier.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSuppliercode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                    varSuppliervalue = selectedItem.SubItems[3].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSupplier.Visible = false;
            }
        }
        private void GrdMoveProduct_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdMoveProduct.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridMove.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdMoveProduct.Width > DGV_SearchGridMove.HorizontalScrollingOffset && grdMoveProduct.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridMove.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridMove.Invalidate();
                udfnscrollVisibleMOve(DGV_SearchGridMove, grdMoveProduct);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_RackSettings_Load(object sender, EventArgs e)
        {
            try
            {
                dtGSTR.TableName = "TRN_GSTR";
                dtGSTR.Columns.Add("PURID", typeof(int));
                dtGSTR.Columns.Add("PUR_GSTRAmnt", typeof(decimal));

                dtViewProduct = new DataTable();
                dtViewProduct.Columns.Add("", typeof(Boolean));
                dtViewProduct.Columns.Add("S.No.", typeof(int));
                dtViewProduct.Columns.Add("Inv Date", typeof(string));
                dtViewProduct.Columns.Add("Inv No.", typeof(string));
                dtViewProduct.Columns.Add("Inv Amt", typeof(decimal));
                dtViewProduct.Columns.Add("PURID", typeof(int));

                dtMoveProduct = new DataTable();
                dtMoveProduct.Columns.Add("Inv Date", typeof(string));
                dtMoveProduct.Columns.Add("Inv No.", typeof(string));
                dtMoveProduct.Columns.Add("Inv Amt", typeof(decimal));
                dtMoveProduct.Columns.Add("GSTR Amt", typeof(decimal));
                dtMoveProduct.Columns.Add("PURID", typeof(int));

                udfnGridColumn();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
       
        private void DGV_SearchGridMove_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGridMove.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }
       
       
        private void GrdViewProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdViewProduct.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                    btnProductView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSupplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                btnProductView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
