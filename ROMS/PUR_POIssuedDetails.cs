using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class PUR_POIssuedDetails : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpIssuemodeValues = new ToolTip();
        private ToolTip tpIssuemode = new ToolTip();
        private ToolTip tpIssueby = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public int varupdate = 0, varPOID = 0,varsts=0, Varordertype = 0;
        public PUR_POIssuedDetails()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfntooltiphide()
        {
            try
            {
                tpIssuemodeValues.Active = false;
                txtIssuedBY.BackColor = Color.White;
                tpIssueby.Active = false; 
                tpIssuemode.Active = false;
                cmbIssueMode.BackColor = Color.White;
                tpIssuemodeValues.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave()
        {

            try
            {
                bool varErrorFlag = true;
                if (Convert.ToInt32(cmbIssueMode.SelectedValue) == 139 || Convert.ToInt32(cmbIssueMode.SelectedValue) == 140)
                {
                    if (txtIssuemodeValues.Text == "")
                    {
                        errIssued.SetError(txtIssuemodeValues, "Please enter number");
                        txtIssuemodeValues.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpIssuemodeValues.ShowAlways = true;
                        tpIssuemodeValues.Show("Please enter number.", txtIssuemodeValues, 5000);
                        varErrorFlag = false;
                    }
                    else
                    {
                        if (txtIssuemodeValues.Text.Length != 10)
                        {
                            errIssued.SetError(txtIssuemodeValues, "Please enter valid number");
                            txtIssuemodeValues.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpIssuemodeValues.ShowAlways = true;
                            tpIssuemodeValues.Show("Please enter valid number.", txtIssuemodeValues, 5000);
                            varErrorFlag = false;
                        }
                    }
                } 
                if (Convert.ToInt32(cmbIssueMode.SelectedValue) == -1)
                {
                    errIssued.SetError(cmbIssueMode, "Please select mode of issue");
                    cmbIssueMode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIssuemode.ShowAlways = true;
                    tpIssuemode.Show("Please select mode of issue.", cmbIssueMode, 5000);
                    varErrorFlag = false;
                }
                if (txtIssuedBY.Text=="")
                {
                    errIssued.SetError(txtIssuedBY, "Please enter issuedby");
                    txtIssuedBY.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIssueby.ShowAlways = true;
                    tpIssueby.Show("Please enter issuedby.", txtIssuedBY, 5000);
                    varErrorFlag = false;
                }
                if (txtTAT.Text == "0")
                {
                    errIssued.SetError(txtTAT, "Invalid turn around time");
                    txtTAT.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIssueby.ShowAlways = true;
                    tpIssueby.Show("Invalid turn around time.", txtTAT, 5000);
                    varErrorFlag = false;
                }
                if (varErrorFlag == true)
                {
                    if (varPOID != 0)
                    {
                        udfntooltiphide();
                        string result = "", varorginator = "Issue Create";
                        int varviewtype = 3, POUpdate = varPOID;
                        SPDataService objspdservice = new SPDataService();
                        DataTable objPurchaseOrder = new DataTable();
                        objPurchaseOrder.TableName = "TRN_PO_Product";
                        objPurchaseOrder.Columns.Add("POPR_PRID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_MSQ", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_ReorderQty", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_OrderQty", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_Flag", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_SPSCID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_UTID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_EditFlag", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_UTOrderQty", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_TOTOrderQty", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_KGORDERQTY", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_BulkUTID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_QUTID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_UPP", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_NetWeight", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_Remarks", typeof(string));
                        result = objspdservice.udfnPurchaseEntry(varviewtype, POUpdate, 0, "", 0, 0
                        , "", varorginator, "", txtTAT.Text, objPurchaseOrder, dpissuedateandtime.Text, txtIssuedBY.Text, Convert.ToString(cmbIssueMode.SelectedValue), txtIssuemodeValues.Text,11,"",0,0,0);
                        objspdservice.CloseConnection();
                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ActiveControl = dpissuedateandtime;
                            MainForm.objPUR_PurchaseOrderList.udfnPOEntryLoad(); 
                            varupdate = 1;
                            udfnclose(); 
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

        private void PUR_POIssuedDetails_Load(object sender, EventArgs e)
        {

            try
            {
                this.ActiveControl = dpissuedateandtime;
                if (varsts == 11)
                {
                    dpissuedateandtime.Enabled = false;
                    txtTAT.Enabled = false;
                    this.ActiveControl = txtIssuedBY;
                }
                if (varsts == 14 || varsts == 33)
                { 
                    gpissued.Enabled = false;
                    gpissued.Enabled = false;
                    btnSave.Enabled = false; 
                }
                //DateTime varmindate = DateTime.ParseExact(txtPODate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //dpissuedateandtime.MinDate = varmindate;
                //dpissuedateandtime.MaxDate = DateTime.Today;

                DataBind objDataBind = new DataBind();
                DataService objdservice = new DataService();
                string varTAT = "" ;
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=44 AND MSTID NOT IN (135,136) OR MSTID=-1", "MST_DisplayText,MSTID", cmbIssueMode, "", "MST_DisplayText", "MSTID");
                objDataBind = null; 
                //varTAT = objdservice.displaydata("SELECT GSTAT_OrderDays FROM MR_GeneralSettings_TAT  WHERE GSTAT_OrderType='"+Varordertype+"'");
                txtTAT.Text = Convert.ToString(Varordertype);
                cmbIssueMode.SelectedIndex = 0;
                udfnEditLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEditLoad()
        {
            try
            {
                Application.DoEvents();
                //********** To display a data in a grid  ******************  
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnPOEntry(2, 0, 0, 0, 0, 0, 0, 0, 0, "", "", varPOID,0,"0",0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {  
                            txtPODate.Text = objDs.Tables[0].Rows[0]["PODATE"].ToString();
                            txtPONo.Text = objDs.Tables[0].Rows[0]["PONO"].ToString();
                            txtSupplier.Text = objDs.Tables[0].Rows[0]["SUPPLIER"].ToString();
                            txtIssuedBY.Text = objDs.Tables[0].Rows[0]["Issuedby"].ToString();
                            txtTAT.Text = objDs.Tables[0].Rows[0]["TAT"].ToString();
                            if (Convert.ToString(objDs.Tables[0].Rows[0]["IssueDate"])  != "")
                            {
                                dpissuedateandtime.Text = objDs.Tables[0].Rows[0]["IssueDate"].ToString();
                            }
                            else
                            {
                                dpissuedateandtime.Text = "";
                            }
                            if (objDs.Tables[0].Rows[0]["Issuemode"].ToString()  != "" && objDs.Tables[0].Rows[0]["Issuemode"].ToString()  != null)
                            {
                                cmbIssueMode.SelectedValue = objDs.Tables[0].Rows[0]["Issuemode"].ToString();
                            }
                            else
                            {
                                cmbIssueMode.SelectedValue = -1;
                            }
                            txtIssuemodeValues.Text = objDs.Tables[0].Rows[0]["Issueremark"].ToString();
                            SPDataService objDServ = new SPDataService();
                            DataSet objd = new DataSet();
                            objd = objDServ.udfnMaster(4, 6,varPOID,"","",0, "");
                            if (objd.Tables[0].Rows.Count != 0)
                            { 
                                DateTime varmindate = DateTime.ParseExact(objd.Tables[0].Rows[0]["MINDATE"].ToString(), "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                                DateTime varmaxdate = DateTime.ParseExact(objd.Tables[0].Rows[0]["MAXDATE"].ToString(), "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                                dpissuedateandtime.MinDate = varmindate;
                                dpissuedateandtime.MaxDate = varmaxdate;
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
        private void PUR_POIssuedDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varupdate == 0)
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

        private void Dpissuedateandtime_Enter(object sender, EventArgs e)
        {
            try
            {
                dpissuedateandtime.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpissuedateandtime_Leave(object sender, EventArgs e)
        {
            try
            {
                dpissuedateandtime.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpissuedateandtime_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtIssuedBY.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIssuedBY_Enter(object sender, EventArgs e)
        {
            try
            {
                txtIssuedBY.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIssuedBY_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtIssuedBY.Text == "")
                {
                    errIssued.SetError(txtIssuedBY, "Please enter issuedby");
                    txtIssuedBY.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIssueby.ShowAlways = true;
                    tpIssueby.Show("Please enter issuedby.", txtIssuedBY, 5000);
                }
                else
                {
                    txtIssuedBY.BackColor = Color.White;
                    errIssued.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIssuedBY_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbIssueMode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbIssueMode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbIssueMode.SelectedValue) == -1)
                {
                    errIssued.SetError(cmbIssueMode, "Please select mode of issue");
                    cmbIssueMode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIssuemode.ShowAlways = true;
                    tpIssuemode.Show("Please select mode of issue.", cmbIssueMode, 5000); 
                }
                else
                {
                    cmbIssueMode.BackColor = Color.White;
                    errIssued.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbIssueMode_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbIssueMode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbIssueMode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                        txtIssuemodeValues.Focus(); 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIssuemodeValues_Enter(object sender, EventArgs e)
        {
            try
            {
                txtIssuemodeValues.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIssuemodeValues_Leave(object sender, EventArgs e)
        {
            try
            {
                txtIssuemodeValues.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtIssuemodeValues_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtTAT.Enabled == true)
                    {
                        txtTAT.Focus();
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

        private void TxtTAT_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTAT.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void TxtTAT_KeyDown(object sender, KeyEventArgs e)
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

       

        private void TxtTAT_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTAT.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_POIssuedDetails_KeyDown(object sender, KeyEventArgs e)
        { 
            try
            {
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
        private void CmbIssueMode_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbIssueMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbIssueMode.SelectedValue) != -1)
                {
                    txtDmode.Text = cmbIssueMode.Text;
                    txtIssuemodeValues.Text = "";
                }
                else
                {
                    txtDmode.Text = "";
                }
                string selectedValue = cmbIssueMode.SelectedItem.ToString();
                 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
    }
}
