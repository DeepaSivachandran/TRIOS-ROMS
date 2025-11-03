using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Drawing.Printing;
using System.Runtime.InteropServices;


namespace ROMS
{
    public partial class CP_Printer_Setting : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;

        DataSet objDs = new DataSet();

        private ToolTip tpSize = new ToolTip();
        private ToolTip tpType = new ToolTip();
        private ToolTip tpPrinter = new ToolTip();
        private ToolTip tpStatus = new ToolTip();

        public string varSettingcode ="0";
        public string pbFormStatus;
        public int varsno=0;
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();

        #region "Form Event"
        public CP_Printer_Setting()
        {
            InitializeComponent();
            windowControl.Initialize(tsPrinterSetting, this);
        }
        private void CP_Printer_Setting_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 603;
                UdfnList();
                CmbPaperSizeBind();
                PrinterList();
                udfnclear();
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    udfnFieldAccess();
                }

                //udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnFieldAccess()
        {
            try
            {
                var result = UserAccessHelper.LoadUserAccess(MenuCode);
                privilege = result.PrivilegeCode;
                SpecialPermissions = result.SpecialPermissions; 
                Btn_Save.Visible = privilege.Contains("3"); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Printer_Setting_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Escape)
                //{
                //    udfnclose();
                //}
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{tab}");
                }
                if (e.KeyCode == Keys.F5)
                {
                    Btn_Save_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    udfnLandingScreen();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        #endregion

        #region "Enter Event"
        private void Cmb_Printer_Name_Enter(object sender, EventArgs e)
        {
            try
            {
                Cmb_Printer_Name.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmb_PaperSize_Enter(object sender, EventArgs e)
        {
            try
            {
                Cmb_PaperSize.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmb_Printer_Type_Enter(object sender, EventArgs e)
        {
            try
            {
                Cmb_Printer_Type.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Btn_Save_Enter(object sender, EventArgs e)
        {
            try
            {
                Btn_Save.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Btn_Close_Enter(object sender, EventArgs e)
        {
            try
            {
                Btn_Close.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        #endregion

        #region "KeyDown Event"
        private void Cmb_PaperSize_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Cmb_Printer_Type.Focus();
                    Cmb_Printer_Name.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmb_Printer_Type_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Cmb_Printer_Name.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmb_Printer_Name_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Btn_Save.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        #endregion

        #region "Leave Event"
        private void Cmb_PaperSize_Leave(object sender, EventArgs e)
        {
            try
            {
                Cmb_PaperSize.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmb_Printer_Type_Leave(object sender, EventArgs e)
        {
            try
            {
                Cmb_Printer_Type.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmb_Printer_Name_Leave(object sender, EventArgs e)
        {
            try
            {
                Cmb_Printer_Name.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Btn_Save_Leave(object sender, EventArgs e)
        {
            try
            {
                Btn_Save.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Btn_Close_Leave(object sender, EventArgs e)
        {
            try
            {
                Btn_Close.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        #endregion

        #region "SelectedIndexChanged Event"
        private void Cmb_PaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //udfnPaperSizeCheck();
        }
        private void Cmb_Printer_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CmbPaperSizeBind();
                PrinterList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Cmb_Printer_Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void tsHeader_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        #region "Click Event"
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                bool SizeChecck = false;
                //SizeChecck = udfnPaperSizeCheck(Cmb_PaperSize.Text);
                SizeChecck = udfnPaperSizeCheck();
                if (SizeChecck == true) { return; }

                bool errorflag = false;
                err_PrinterSetting.Clear();
                if (Cmb_PaperSize.Text.Trim() == "" || Cmb_PaperSize.SelectedValue.ToString() == "-1")
                {
                    err_PrinterSetting.SetError(Cmb_PaperSize, "Select Paper Size ");
                    Cmb_PaperSize.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpSize.ShowAlways = true;
                    tpSize.Show("Select Paper Size", Cmb_PaperSize, 5000);
                    Cmb_PaperSize.Text = "";
                    Cmb_PaperSize.Focus();
                    errorflag = true;
                    return;
                }

                //if (Cmb_Printer_Type.Text.Trim() == "" || Cmb_Printer_Type.SelectedValue.ToString() == "-1")
                //{
                //    err_PrinterSetting.SetError(Cmb_Printer_Type, "Select Printer Type ");
                //    Cmb_Printer_Type.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                //    tpType.ShowAlways = true;
                //    tpType.Show("Select Printer Type", Cmb_Printer_Type, 5000);
                //    Cmb_Printer_Type.Text = "";
                //    Cmb_Printer_Type.Focus();
                //    errorflag = true;
                //    return;
                //}

                if (Cmb_Printer_Name.Text.Trim() == "")
                {
                    err_PrinterSetting.SetError(Cmb_Printer_Name, "Select Printer Name ");
                    Cmb_Printer_Name.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpPrinter.ShowAlways = true;
                    tpPrinter.Show("Select Printer Name", Cmb_Printer_Name, 5000);
                    Cmb_Printer_Name.Text = "";
                    Cmb_Printer_Name.Focus();
                    errorflag = true;
                    return;
                }
                if (errorflag == false)
                {
                    
                       String VarSize = Cmb_PaperSize.Text;
                    String VarTypeCode = "0";// Cmb_Printer_Type.SelectedValue.ToString();
                    String VarTypeName = "0";//Cmb_Printer_Type.Text .ToString ();
                    String VarPrinterName = Cmb_Printer_Name.Text; 
                    String VarSizeCode = Cmb_PaperSize.SelectedValue.ToString();
                    
                    varsno = grdLabelPrinting.RowCount;
                    varsno = varsno + 1;
                    grdLabelPrinting.Rows.Add(varsno, MainForm.pbUserID,MainForm.pbIpAddress , VarSize, VarTypeCode, VarTypeName, VarPrinterName,0, VarSizeCode);
                    CmbPaperSizeBind();
                    Cmb_PaperSize.Focus();
                    Cmb_PaperSize.SelectedIndex = 0;
                    Cmb_Printer_Type.SelectedIndex = 0;
                    Cmb_Printer_Name.SelectedIndex = 0;
                    grdLabelPrinting.Sort(this.grdLabelPrinting.Columns["matitemcode"], ListSortDirection.Ascending);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //Btn_Save.Enabled = false;
                if (grdLabelPrinting.Rows.Count > 0)
                {
                    //DataTable objTable = new DataTable();
                    //objTable.TableName = "TEMP_CP_Printer_Setting";
                    //objTable.Columns.Add("PaperSize", typeof(string));
                    //objTable.Columns.Add("PrinterTypeCode", typeof(int));
                    //objTable.Columns.Add("PrinterName", typeof(string));
                    //objTable.Columns.Add("StatusCode", typeof(int));

                    //for (int i = 0; i < grdLabelPrinting.Rows.Count; i++)
                    //{
                    //    objTable.Rows.Add(Convert.ToString(grdLabelPrinting.Rows[i].Cells[3].Value),
                    //        Convert.ToInt32(grdLabelPrinting.Rows[i].Cells[4].Value),
                    //        Convert.ToString(grdLabelPrinting.Rows[i].Cells[6].Value), 1);
                    //}

                    //SPDataService spservice = new SPDataService();

                    //string result = "";
                    //if (Btn_Save.Text == "Save")
                    //{
                    //    result = spservice.udfnSPPrinterSetting(objTable, "Create", "0", MainForm.pbHostName, MainForm.pbUserID, MainForm.pbIpAddress, "PrinterSetting Create");
                    //}
                    //else
                    //{
                    //    result = spservice.udfnSPPrinterSetting(objTable, "Update", varSettingcode, MainForm.pbHostName, MainForm.pbUserID, MainForm.pbIpAddress, "PrinterSetting Update");
                    //}

                    //string[] varvalue = result.Split('~');
                    //if (varvalue[0] == "3")
                    //{
                    //    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    Btn_Save.Enabled = true;
                    //    udfnclear();
                    //    UdfnList();
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                    //spservice.CloseConnection();

                    udfnFileWrite();
                    MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Btn_Save.Enabled = true;
                    udfnclear();
                    UdfnList();
                    udfnLandingScreen();


                    
                } 

            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void Btn_Close_Click(object sender, EventArgs e)
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
        #endregion

        #region "User Defined Function"
        private void udfncmbload()
        {
            try
            {
                this.ActiveControl = Cmb_PaperSize;
                DataBind objDataBind = new DataBind();
                //objDataBind.BindComboBoxListSelected("VIEW_LabelDetails", "ORDERVAL=1 And STICKERTYPE <> 0", "LabelSize", Cmb_Size, "", "LabelSize", "grouptypecode");
                //objDataBind.BindComboBoxListSelected("(SELECT DISTINCT LabelSize FROM VIEW_LabelDetails WHERE ORDERVAL=1 And STICKERTYPE <> 0) DERV", " 1=1", "LabelSize,LabelSize", Cmb_PaperSize, "", "LabelSize", "LabelSize");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,79,93) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", Cmb_PaperSize, "", "MST_DisplayText", "MSTID");
                objDataBind = null;

                Cmb_PaperSize.SelectedIndex = 0;

                //DataBind objDataBind1 = new DataBind();
                //objDataBind1.BindComboBoxListSelected("Def_printer_type", "1=1 And Not PrinterTypeCode = 0", "PrinterType,PrinterTypeCode", Cmb_Printer_Type, "", "PrinterType", "PrinterTypeCode");
                //objDataBind1 = null;
                //Cmb_Printer_Type.SelectedIndex = 0;

                //PrinterList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnLandingScreen() { 
            try
            {
                //MainForm.objStart = new DEF_Start();
                //MainForm.objStart.MdiParent = this.ParentForm;
                //MainForm.objStart.Show();
                //this.Close();
                windowControl?.TriggerClose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnclear()
        {
            try
            {
                Cmb_PaperSize.SelectedIndex = 0;
                Cmb_Printer_Type.SelectedIndex = 0;
                Cmb_Printer_Name.Text = "";
                if (varSettingcode == "0") { Btn_Save.Text = "Save"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnSerialNoGen()
        {
            try
            {
                if (grdLabelPrinting.Rows.Count > 0)
                {
                    int varsno = 0;
                    for (int i = 0; i <= grdLabelPrinting.Rows.Count; i++)
                    {
                        //clmsno
                        varsno = varsno + 1;
                        grdLabelPrinting.Rows[i].Cells["clmsno"].Value = varsno;
                    }
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
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
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
        public bool udfnPaperSizeCheck()
        {
            bool Bln_PaperSizeChk = false;
            try
            {
               // public bool Bln_PaperSizeChk = false;
                
                for (int i = 0; i < grdLabelPrinting.Rows.Count; ++i)
                {
                    if (grdLabelPrinting.ColumnCount > 0)
                    {
                        if (Convert.ToString(grdLabelPrinting.Rows[i].Cells[3].Value) == Cmb_PaperSize.Text )
                        {
                            MessageBox.Show("This Paper Size already added!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Bln_PaperSizeChk = true;
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return Bln_PaperSizeChk;
        }
        public void PrinterList()
        {
            // USING WMI. (WINDOWS MANAGEMENT INSTRUMENTATION)

            System.Management.ManagementScope objMS =
            new System.Management.ManagementScope(ManagementPath.DefaultPath);
            objMS.Connect();

            SelectQuery objQuery = new SelectQuery("SELECT * FROM Win32_Printer");
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher(objMS, objQuery);
            System.Management.ManagementObjectCollection objMOC = objMOS.Get();
            Cmb_Printer_Name.Items.Clear();
            Cmb_Printer_Name.Text = "";
            foreach (ManagementObject Printers in objMOC)
            {
                if (Convert.ToBoolean(Printers["Local"]))       // LOCAL PRINTERS.
                {
                    Cmb_Printer_Name.Items.Add(Printers["Name"]);
                }
                if (Convert.ToBoolean(Printers["Network"]))     // ALL NETWORK PRINTERS.
                {
                    Cmb_Printer_Name.Items.Add(Printers["Name"]);
                }
                //if (Cmb_Printer_Type.Text == "") { return; }
                //if (Cmb_Printer_Type.SelectedValue.ToString() == "1")
                //{
                //    if (Convert.ToBoolean(Printers["Local"]))       // LOCAL PRINTERS.
                //    {
                //        Cmb_Printer_Name.Items.Add(Printers["Name"]);
                //    }
                //}
                //if (Cmb_Printer_Type.SelectedValue.ToString() == "2")
                //{

                //    if (Convert.ToBoolean(Printers["Network"]))     // ALL NETWORK PRINTERS.
                //    {
                //        Cmb_Printer_Name.Items.Add(Printers["Name"]);
                //    }
                //}

                //Cmb_Printer_Name.Items.Add(Printers["Name"]);

                Cmb_Printer_Name.SelectedIndex = 0;
                //if (Cmb_Type.Text  != "" || Cmb_Type.Text  != null) { Cmb_Printer.SelectedValue = 1; }
            }
        }
        public void UdfnList()
        {
            try
            {
                picLoader.Visible = true;
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdLabelPrinting.DataSource = null;
                //**** To call the function from SP ***************


                //SPDataService objdserv = new SPDataService();
                //objDs = objdserv.udfnSPPrinterSettingList("List", "0",MainForm.pbHostName , "", "", "", MainForm.pbUserID, MainForm.pbIpAddress);
                //objdserv.CloseConnection();
                //if (objDs != null)
                //{
                //    if (objDs.Tables.Count > 0)
                //    {
                //        if (objDs.Tables[0].Rows.Count > 0)
                //        {
                //            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                //            {
                //                grdLabelPrinting.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["SI.No."]), Convert.ToString(objDs.Tables[0].Rows[i]["User Name"]),
                //                    Convert.ToString(objDs.Tables[0].Rows[i]["IPAddress"]), Convert.ToString(objDs.Tables[0].Rows[i]["Paper Size"]),
                //                    Convert.ToString(objDs.Tables[0].Rows[i]["Printer Type Code"]), Convert.ToString(objDs.Tables[0].Rows[i]["Printer Type"]),
                //                    Convert.ToString(objDs.Tables[0].Rows[i]["Printer Name"]), Convert.ToString(objDs.Tables[0].Rows[i]["Settingcode"]));
                //                    varsno = Convert.ToInt32 (objDs.Tables[0].Rows[i]["SI.No."]);
                //                    varSettingcode = Convert.ToString(objDs.Tables[0].Rows[i]["Settingcode"]);
                //            }
                //            grdLabelPrinting.Sort(this.grdLabelPrinting.Columns["SettingCode"], ListSortDirection.Ascending);
                //            Btn_Save.Text = "Update";
                //        }
                //    }
                //}

                udfnFileRead();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdLabelPrinting.ClearSelection();
                picLoader.Visible = false;
            }
        }
        #endregion
        public static class PrinterClass
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Printer);
        }
        private void grdLabelPrinting_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (grdLabelPrinting.Columns[e.ColumnIndex].Name)
                {
                    case "clmRemove":
                        DialogResult response = MessageBox.Show("Do you want to delete?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if ((response == DialogResult.Yes))
                        {
                            grdLabelPrinting.Rows.RemoveAt(e.RowIndex);
                            udfnSerialNoGen();
                            CmbPaperSizeBind();
                        }
                        break;
                    case "clmprint":
                        DialogResult response1 = MessageBox.Show("Do you want to print?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if ((response1 == DialogResult.Yes))
                        {
                            //PrinterClass.SetDefaultPrinter(Convert.ToString(grdLabelPrinting.SelectedRows[0].Cells["clmPrinterName"].Value));
                            // PrinterClass.SetDefaultPrinter("RP80 Printer");


                            object printerName = Convert.ToString(grdLabelPrinting.SelectedRows[0].Cells["clmPrinterName"].Value);
                            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
                            ManagementObjectCollection collection = searcher.Get();
                            foreach (ManagementObject currentObject in collection)
                            {
                                if (currentObject["name"].ToString() == printerName.ToString())
                                {
                                    currentObject.InvokeMethod("SetDefaultPrinter", new object[] { printerName });
                                }
                            }
                            printDocument1.Print();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    
    
        public void udfnFileWrite()
        {
            try
            {
                string Folderpath = Application.StartupPath + "\\Printer Settings";
                if (!Directory.Exists(Folderpath))
                {
                    Directory.CreateDirectory(Folderpath);
                }
                string paths = Application.StartupPath + "\\Printer Settings\\printersettings.txt";
                if (File.Exists(paths))
                {
                    File.Delete(paths);
                }
                else
                {
                    File.Create(paths).Close();
                }
                StreamWriter sw = new StreamWriter(paths);
                for (int i = 0; i < grdLabelPrinting.Rows.Count; i++)
                {
                    sw.WriteLine(grdLabelPrinting.Rows[i].Cells["clmPaperSize"].Value + "," + grdLabelPrinting.Rows[i].Cells["clmPrinterName"].Value);
                }
                sw.Close();
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnFileRead()
        {
            try
            {
                string paths = Application.StartupPath + "\\Printer Settings\\printersettings.txt";
                if (File.Exists(paths))
                {
                    varsno = 0;
                    string line;
                    StreamReader file = new StreamReader(paths);
                    while ((line = file.ReadLine()) != null)
                    {
                        varsno = varsno + 1;
                        if (line != null & line != "")
                        {
                            string[] words = line.Split(',');
                            grdLabelPrinting.Rows.Add(varsno, "","", words[0],"","", words[1]);
                        }
                    }
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaperSizeBind()
        {
            try
            {
                string Sizecode = "";
                for (int i = 0; i < grdLabelPrinting.Rows.Count; ++i)
                {
                    if (grdLabelPrinting.ColumnCount > 0)
                    {
                        if (Sizecode == "")
                        {
                            Sizecode = "'" + Convert.ToString(grdLabelPrinting.Rows[i].Cells["clmPaperSizecode"].Value) +  "'";
                        }
                        else { Sizecode += "," + "'" + Convert.ToString(grdLabelPrinting.Rows[i].Cells["clmPaperSizecode"].Value) + "'"; }
                    }
                }
                if(Sizecode=="")
                {
                    DataBind objDataBind = new DataBind(); 
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,79,93) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", Cmb_PaperSize, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                } 
                else
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,79,93) AND MSTID NOT IN (0," + Sizecode + ") ORDER BY MSTID", "MST_DisplayText,MSTID", Cmb_PaperSize, "", "MST_DisplayText", "MSTID");
                     
                     objDataBind = null;
                }              
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font sFont = new Font("Arial", 10);
            Brush sBrush = Brushes.White;
            e.Graphics.DrawString("\f", sFont, sBrush, 0, 0);            
        }
    }
}
