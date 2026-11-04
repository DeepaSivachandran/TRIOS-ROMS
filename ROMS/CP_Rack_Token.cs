using CrystalDecisions.Shared;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    //Author : Sathish
    //Created On : 20-02-2025
    public partial class CP_Rack_Token : Form
    {

        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public static string varFGCode;
        public int varStickerType;
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpType = new ToolTip();
        private ToolTip tpLabelSize = new ToolTip();
        private ToolTip tpLabelCount = new ToolTip();
        public string varProductCodes, varRMCodes, varFGCodes = "0";
        List<string> varPMGroupCodes = new List<string>();
        List<string> varRackcodes = new List<string>();
        public DataTable dtRack, dtProducts;
        public int varsno, varCloseflag = 0, varGroupSlipcode = 0 ;
        private ToolTip tpToken = new ToolTip();

        private void grdRack_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                try
                {

                    picloader2.Visible = true;
                    udfnProductBind();
                    picloader2.Visible = false;

                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public CP_Rack_Token()
        {
            InitializeComponent(); 
              
        }

        private void btnRackSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdRack.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdRack.Rows.Count; i++)
                    {
                        grdRack.Rows[i].Cells[0].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void btnRackUnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdRack.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdRack.Rows.Count; i++)
                    {
                        grdRack.Rows[i].Cells[0].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnProSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdProducts.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdProducts.Rows.Count; i++)
                    {
                        grdProducts.Rows[i].Cells[0].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnProUnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdProducts.Rows.Count) > 0)
                {
                    for (int i = 0; i < grdProducts.Rows.Count; i++)
                    {
                        grdProducts.Rows[i].Cells[0].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;

                if (Convert.ToString(txtTokenGroup.Text).Trim() == "")
                {
                    errRack.SetError(txtTokenGroup, "Please enter token slip group name");
                    txtTokenGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpToken.ShowAlways = true;
                    tpToken.Show("Please enter token slip group name", txtTokenGroup, 5000);
                    blnErrorFlag = true;
                }

                DataTable dtProducts = (DataTable)grdProducts.DataSource;

                var count = dtProducts.AsEnumerable()
                    .Count(row => row.Field<bool>("column1") == true);
                if (count == 0) 
                {
                    blnErrorFlag = true;
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(80);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            }
        }

        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                varCloseflag = 1;
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                DataTable dtProducts = (DataTable)grdProducts.DataSource;

                DataTable saveobjdtProducts = dtProducts.AsEnumerable()
                    .Where(row => row.Field<bool>("column1") == true)
                    .CopyToDataTable()
                    .DefaultView
                    .ToTable(false, "Rackcode", "ProductID");
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Rack token slip group creation";
                    varType = 3;
                }
                else
                {
                    varoriginator = "Rack token slip group updation";
                    varType = 4;
                }

                varResult = objspservice.udfnRack(varType, 0,0, 0, "", "", "", 1, varoriginator, 0, 0, varGroupSlipcode, saveobjdtProducts,txtTokenGroup.Text);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    varCloseflag = 1;

                    udfnclose();
                }
                else if (varResult.Split('~')[0] == "4")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Focus();    
                }

                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdRack.DataSource as DataTable).DefaultView.RowFilter = "([Rack Name]) LIKE '%" + txtRack.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProducts_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdProducts.DataSource as DataTable).DefaultView.RowFilter = "([PR_EName]) LIKE '%" + txtProducts.Text + "%' OR ([P.I Code]) LIKE '%" + txtProducts.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdRack_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdRack.CurrentCell is DataGridViewCheckBoxCell)
                {
                    grdRack.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Rack_Token_Load(object sender, EventArgs e)
        {
            try
            {
                dtRack = new DataTable();
                dtRack.Columns.Add("", typeof(Boolean));
                dtRack.Columns.Add("Rack Name", typeof(string));
                dtRack.Columns.Add("Rackcode", typeof(int));

                dtProducts = new DataTable();   
                dtProducts.Columns.Add("", typeof(Boolean));
                dtProducts.Columns.Add("P.I Code", typeof(string));
                dtProducts.Columns.Add("Product", typeof(string));
                dtProducts.Columns.Add("Unit", typeof(string));
                dtProducts.Columns.Add("Rackcode", typeof(int));
                dtProducts.Columns.Add("ProductID", typeof(int));
                dtProducts.Columns.Add("PR_EName", typeof(string));
                udfnRackLoad(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnRackLoad(object sender, EventArgs e)
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objspdservice = new SPDataService();
                int viewType = 18;
                
                objDs = objspdservice.udfnRackList(viewType, 0,0,0,0,"",0,0, varGroupSlipcode);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            dtRack.Rows.Add(false, objDs.Tables[0].Rows[i]["RackName"].ToString(), objDs.Tables[0].Rows[i]["RackCode"].ToString());
                        }
                        grdRack.DataSource = dtRack;
                        grdRack.Columns[0].HeaderText = "";
                        grdRack.Columns[0].Width = 50;
                        grdRack.Columns["Rack Name"].Width = 200;
                        grdRack.Columns["Rackcode"].Visible = false;
                    }
                    if (objDs.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                        {
                            dtProducts.Rows.Add(false, objDs.Tables[1].Rows[i]["P.I Code"].ToString(), objDs.Tables[1].Rows[i]["Product"].ToString(), objDs.Tables[1].Rows[i]["Unit"].ToString(),Convert.ToInt32(objDs.Tables[1].Rows[i]["Rackcode"].ToString()), Convert.ToInt32(objDs.Tables[1].Rows[i]["ProductID"].ToString()),
                                objDs.Tables[1].Rows[i]["PR_EName"].ToString());
                        }
                        //grdProducts.DataSource = dtProducts;
                        //grdProducts.Columns[0].Width = 50;
                        //grdProducts.Columns["P.I Code"].Width = 150;
                        //grdProducts.Columns["Product"].Width = 250;
                        //grdProducts.Columns["Rackcode"].Visible = false;
                        //grdProducts.Columns["ProductID"].Visible = false;
                    }
                }
                if (varGroupSlipcode != 0)
                {
                    objDs = objspdservice.udfnRackList(20, 0, 0, 0, 0, "", 0, 0, varGroupSlipcode);

                    objspdservice.CloseConnection();

                    if (objDs != null && objDs.Tables.Count >= 2)
                    {
                        DataTable dtRackCheck = objDs.Tables[0];
                        DataTable dtProductCheck = objDs.Tables[1];

                        txtTokenGroup.Text = dtRackCheck.Rows[0]["TSG_GroupName"].ToString();
                        // Check Product rows
                        foreach (DataRow productRow in dtProducts.Rows)
                        {
                            int productID = Convert.ToInt32(productRow["ProductID"]);

                            bool isChecked = dtProductCheck.AsEnumerable()
                                .Any(row => Convert.ToInt32(row["ProductID"]) == productID);

                            
                            productRow[0] = isChecked;
                        }
                        // Check Rack rows
                        foreach (DataRow rackRow in dtRack.Rows)
                        {
                            int rackCode = Convert.ToInt32(rackRow["Rackcode"]);

                            bool isChecked = dtRackCheck.AsEnumerable()
                                .Any(row => Convert.ToInt32(row["RackCode"]) == rackCode);

                            rackRow[0] = isChecked;
                            int rowIndex = dtRack.Rows.IndexOf(rackRow);

                            grdRack_CellValueChanged(grdRack, new DataGridViewCellEventArgs(0, rowIndex));
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

        public void udfnProductBind()
        {
            try
            {
                grdProducts.DataSource = null;
                List<string> varSelectedRackcodes = new List<string>();
                for (int i = 0; i < grdRack.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdRack.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        string varRackcode = grdRack.Rows[i].Cells["Rackcode"].Value.ToString();
                        varSelectedRackcodes.Add(varRackcode);
                    }
                }
                varRackcodes = varSelectedRackcodes;
                DataTable filteredRawMaterial = dtProducts.Clone();

                foreach (DataRow row in dtProducts.Rows)
                {
                    if (varSelectedRackcodes.Contains(row["Rackcode"].ToString()))
                    {
                        filteredRawMaterial.ImportRow(row);
                    }
                }
                grdProducts.DataSource = filteredRawMaterial;
                grdProducts.Columns[0].HeaderText = "";
                grdProducts.Columns[0].Width = 50;
                grdProducts.Columns["P.I Code"].Width = 120;
                grdProducts.Columns["Product"].Width = 300;
                grdProducts.Columns["Rackcode"].Visible = false;
                grdProducts.Columns["ProductID"].Visible = false;
                grdProducts.Columns["PR_EName"].Visible = false;
                grdProducts.Columns["Product"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Rack_Token_KeyDown(object sender, KeyEventArgs e)
        {
            try { if(e.KeyCode== Keys.Escape) udfnclose();
                if (e.KeyCode == Keys.F5) btnSave_Click(sender,e);
            
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try { udfnclose(); }
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
                MainForm.objCP_Rack_Token_List.udfnList();

                if (varCloseflag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
                //if (varQueueFlag == 1)
                //{
                //    MainForm.objPUR_PurchaseQueue.udfnDate();
                //    MainForm.objPUR_PurchaseQueue.udfnList();
                //}

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Common_Enter(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = sender as TextBox;
                Button btn = sender as Button;

                if (txt != null)
                {
                    string comboName = txt.Name;
                    if (comboName == "txtTokenGroup")
                    {
                        txtTokenGroup.BackColor = Color.LemonChiffon;
                    }
                    else if (comboName == "txtRack")
                    {
                        txtRack.BackColor = Color.LemonChiffon;
                    }
                    else if (comboName == "txtProducts")
                    {
                        txtProducts.BackColor = Color.LemonChiffon;
                    }
                }
                if (btn != null) {
                    string btnName = btn.Name;
                    if (btnName == "btnClose")
                    {
                        btnClose.BackColor = Color.LemonChiffon;
                    }
                    else if (btnName == "btnSave")
                    {
                        btnSave.BackColor = Color.LemonChiffon;
                    }
                    else if (btnName == "btnRackSelect")
                    {
                        btnRackSelect.BackColor = Color.LemonChiffon;
                    }
                    else if (btnName == "btnRackUnSelect")
                    {
                        btnRackUnSelect.BackColor = Color.LemonChiffon;
                    }
                    else if (btnName == "btnProUnSelect")
                    {
                        btnProUnSelect.BackColor = Color.LemonChiffon;
                    }
                    else if (btnName == "btnProSelect")
                    {
                        btnProSelect.BackColor = Color.LemonChiffon;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Common_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox txt = sender as TextBox;
                Button btn = sender as Button;

                if (txt != null)
                {
                    string comboName = txt.Name;
                    if (comboName == "txtTokenGroup")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            txtRack.Focus();
                        }
                    }
                    else if (comboName == "txtRack")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (txtProducts.Enabled == true)
                            {
                                txtProducts.Focus();
                            } 
                        }
                    }
                    else if (comboName == "txtProducts")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            btnSave.Focus();
                        }
                    }
                }

                //if (btn != null)
                //{
                //    string btnName = btn.Name;
                   

                //    if (btnName == "btnRackSelect")
                //    {
                //        if (e.KeyCode == Keys.Enter)
                //        {
                //            if (txtProducts.Enabled == true)
                //            {
                //                btnRackUnSelect.Focus();
                //            }
                //        }
                //    }
                //    else if (btnName == "btnRackUnSelect")
                //    {
                //        if (e.KeyCode == Keys.Enter)
                //        {
                //            btnProSelect.Focus();
                //        }
                //    }


                //    else if (btnName == "btnProSelect")
                //    {
                //        if (e.KeyCode == Keys.Enter)
                //        {
                //            btnProUnSelect.Focus();

                //        }
                //    }
                //    else if (btnName == "btnProUnSelect")
                //    {
                //        if (e.KeyCode == Keys.Enter)
                //        {
                //            btnSave.Focus();
                //        }
                //    }
                //    else if(btnName == "btnSave")
                //    {
                //        if (e.KeyCode == Keys.Enter)
                //        {
                //            btnClose.Focus();
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

        private void Common_Leave(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = sender as TextBox;
                Button btn = sender as Button;

                if (txt != null)
                {
                    string comboName = txt.Name;
                    if (comboName == "txtTokenGroup")
                    {
                        txtTokenGroup.BackColor = Color.White;
                    }
                    else if (comboName == "txtRack")
                    {
                        txtRack.BackColor = Color.White;
                    }
                    else if (comboName == "txtProducts")
                    {
                        txtProducts.BackColor = Color.White;
                    }
                }
                if (btn != null)
                {
                    string btnName = btn.Name;
                    if (btnName == "btnClose")
                    {
                        btnClose.BackColor = Color.White;
                    }
                    else if (btnName == "btnSave")
                    {
                        btnSave.BackColor = Color.White;
                    }
                    else if (btnName == "btnRackSelect")
                    {
                        btnRackSelect.BackColor = Color.White;
                    }
                    else if (btnName == "btnRackUnSelect")
                    {
                        btnRackUnSelect.BackColor = Color.White;
                    }
                    else if (btnName == "btnProUnSelect")
                    {
                        btnProUnSelect.BackColor = Color.White;
                    }
                    else if (btnName == "btnProSelect")
                    {
                        btnProSelect.BackColor = Color.White;
                    }
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
