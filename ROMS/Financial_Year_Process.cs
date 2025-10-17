using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;   // Check Directory default Function
using System.Xml;


namespace ROMS
{
    public partial class Financial_Year_Process : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private SecurityController _security;
        public int varBackupProcess = 0;
        public int varTimer = 0;
        public Financial_Year_Process()
        {
            InitializeComponent();
            windowControl.Initialize(tsFy_Process, this);
        }
        private void Fy_Process_Load(object sender, EventArgs e)
        {
            try
            {
                tmrProcess.Enabled = true;
                tmrProcess.Start();
                tmrProcess.Interval = 1500;
                lblProcess.Visible = false;
                varBackupProcess = 1;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (PbBackup.Value != 10)
                {
                    PbBackup.Value++;
                    picLoader.Visible = true;
                    PicloadComplete.Visible = false;
                    lblProcess.Visible = true;
                    lblProcess.BringToFront();
                    picLoader.BringToFront();
                    PicloadComplete.SendToBack();
                }
                else
                {
                    tmrProcess.Stop();
                    PicloadComplete.Visible = true;
                    picLoader.Visible = false;
                    PicloadComplete.BringToFront();
                    picLoader.SendToBack();
                    lblProcess.Text = "Completed";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Fy_Process_Keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                BtnStart_Click(sender,e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                MainForm.objStart = new DEF_Start();
                MainForm.objStart.MdiParent = this.ParentForm;
                MainForm.objStart.Show();
                this.Close();
            }
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                lblProcess.Visible = true;
                //tmrProcess.Tick += new EventHandler(timer1_Tick);
                this.PbBackup.Maximum = 100;
                this.PbBackup.Minimum = 1;
                this.PbBackup.Step = 1;
                MainForm.varFormDisable = 1;
                //varBackupProcess=0;
                udfnDbBackup();
                udfnDbRestore();
                udfnClearTransactions();
                udfnMoveStock();
                udfnFinalSettings();
                if (varBackupProcess == 6)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(126);
                    objDServ.CloseConnection();
                    DialogResult Response = MessageBox.Show(varMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Response == DialogResult.OK)
                    {
                        string name = System.Diagnostics.Process.GetCurrentProcess().ProcessName.Replace(".vshost", "");
                        MainForm.varCloseFlag = 1;
                        MainForm.varFormDisable = 0;
                        System.Windows.Forms.Application.Exit();

                        // Read config file
                        XmlDocument appSettingsDoc = new XmlDocument();
                        appSettingsDoc.Load(Application.StartupPath + "\\" + name + ".exe.config");

                        //Authentication au = new Authentication();
                        //au.Show();
                        //Program.Main();
                        Program.varFormClose = 1;
                    }
                }
                //tmrProcess.Tick += new EventHandler(udfnDbBackup);
                //tmrProcess.Tick += new EventHandler(udfnDbRestore);
                //tmrProcess.Tick += new EventHandler(udfnClearTransactions);
                //tmrProcess.Tick += new EventHandler(udfnMoveStock);
                //udfnDbBackup();
                //ProgressLoad.Style = ProgressBarStyle.Marquee;
                //ProgressLoad.MarqueeAnimationSpeed = 6;


                //ProgressLoad.ForeColor = Color.FromArgb(255, 0, 0);
                //ProgressLoad.BackColor = Color.FromArgb(150, 0, 0);
                //ProgressLoad.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
                //ProgressLoad.ForeColor = Color.Red;
                //ProgressLoad.Style = ProgressBarStyle.Marquee;
                //ProgressLoad.MarqueeAnimationSpeed = 30;
                /*
                DataService objDser = new DataService();
                DataSet GetPath = objDser.GetDataset("SELECT GS_DBPath FROM MR_GeneralSettings");
                if (GetPath.Tables[0].Rows.Count != 0)
                {
                    string Path =Convert.ToString(GetPath.Tables[0].Rows[0]["GS_DBPath"].ToString());
                    if (Directory.Exists(Path))
                    {
                        varBackup = 1;
                    }
                    else
                    {
                        varBackup = 0;
                        Directory.CreateDirectory(Path);
                        if(Directory.Exists(Path))
                        {
                            varBackup = 1;
                        }
                    }
                }
                if(varBackup==0)
                {
                    //this.PbBackup.Location = new System.Drawing.Point(88, 232);
                    //this.PbBackup.Name = "progressBar1";
                    this.PbBackup.TabIndex = 0;
                    this.PbBackup.Maximum = 1000000;
                    this.PbBackup.Minimum = 1;
                    this.PbBackup.Step = 1;
                    for (int i = PbBackup.Minimum; i <= PbBackup.Maximum; i++)
                    {
                        PbBackup.PerformStep();
                    }
                }*/
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDbBackup()
        {
            try
            {
                if (varBackupProcess == 1)
                {
                    varTimer = 0;
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varoriginator = "";
                    varoriginator = "Database Backup";
                    varResult = objspservice.udfnDbBackup(varoriginator);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        lblProcess.Visible = true;
                        varBackupProcess = 2;
                        varTimer = 1;
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varBackupProcess = 0;
                    }
                }
                if (varTimer == 1)
                {
                    varTimer = 0;
                    PbBackup.Value = 14;
                    Pic_Backup.Image = ROMS.Properties.Resources.Db_backup_Color;
                    /*
                    if (PbBackup.Value != 9)
                    {
                        PbBackup.Value++;
                        picLoader.Visible = true;
                        PicloadComplete.Visible = false;
                        lblProcess.BringToFront();
                        picLoader.BringToFront();
                    }
                    else
                    {
                        tmrProcess.Stop();
                        Pic_Backup.Image = ROMS.Properties.Resources.Db_backup_Color;
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDbRestore()
        {
            try
            {
                if (varBackupProcess == 2)
                {
                    varTimer = 0;
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varoriginator = "";
                    varoriginator = "Database Restore";
                    varResult = objspservice.udfnDbRestore(varoriginator);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        varBackupProcess = 3;
                        varTimer = 1;
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varBackupProcess = 0;
                    }
                }
                if (varTimer == 1)
                {
                    varTimer = 0;
                    PbBackup.Value = 33;
                    Pic_Restore.Image = ROMS.Properties.Resources.Db_Restore_Color;
                    /*
                    if (PbBackup.Value != 32)
                    {
                        PbBackup.Value++;
                    }
                    else
                    {
                        tmrProcess.Stop();
                        Pic_Restore.Image = ROMS.Properties.Resources.Db_Restore_Color;
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClearTransactions()
        {
            try
            {
                if (varBackupProcess == 3)
                {
                    varTimer = 0;
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varoriginator = "";
                    varoriginator = "Clear Transactions";
                    varResult = objspservice.udfnDBClearTransaction(0, varoriginator);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        varBackupProcess = 4;
                        varTimer = 1;
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varBackupProcess = 0;
                    }
                }
                if (varTimer == 1)
                {
                    varTimer = 0;
                    PbBackup.Value = 56;
                    Pic_Clear.Image = ROMS.Properties.Resources.Clear_Transaction_Color;
                    /*
                    if (PbBackup.Value != 55)
                    {
                        PbBackup.Value++;
                    }
                    else
                    {
                        tmrProcess.Stop();
                        Pic_Clear.Image = ROMS.Properties.Resources.Clear_Transaction_Color;
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnMoveStock()
        {
            try
            {
                if (varBackupProcess == 4)
                {
                    varTimer = 0;
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varoriginator = "";
                    varoriginator = "Move Stock";
                    varResult = objspservice.udfnMoveStock(varoriginator);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        varBackupProcess = 5;
                        varTimer = 1;
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varBackupProcess = 0;
                    }
                }
                if (varTimer == 1)
                {
                    varTimer = 0;
                    PbBackup.Value = 81;
                    Pic_Move.Image = ROMS.Properties.Resources.Move_Color;
                    /*
                    if (PbBackup.Value != 80)
                    {
                        PbBackup.Value++;
                    }
                    else
                    {
                        tmrProcess.Stop();
                        Pic_Move.Image = ROMS.Properties.Resources.Move_Color;
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnFinalSettings()
        {
            try
            {
                if (varBackupProcess == 5)
                {
                    varTimer = 0;
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varoriginator = "";
                    varoriginator = "Final Settings";
                    varResult = objspservice.udfnFinalSettings(0,varoriginator);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        varBackupProcess = 6;
                        varTimer = 1;
                        if (varTimer == 1)
                        {
                            PbBackup.Value = 100;
                            Pic_Settings.Image = ROMS.Properties.Resources.Settings_Color;
                            picLoader.Visible = false;
                            PicloadComplete.Visible = true;
                            lblProcess.Text = "Completed";
                            PicloadComplete.BringToFront();
                            picLoader.SendToBack();
                        }
                        string path = Application.StartupPath + "\\Server Settings\\serversettings.txt";
                        string ServerName = "", DataBaseName = "", UserName = "", Password = "", WebService = "";
                        DataBaseName = varvalue[2];
                        if (File.Exists(path))
                        {
                            string lines = File.ReadAllText(path);
                            if (lines != null & lines != "")
                            {
                                string[] words = lines.Split(',');
                                ServerName = words[0]; UserName = words[2]; Password = words[3]; WebService = words[4];
                            }
                        }
                        // Check server settings file exists
                        if (File.Exists(path))
                        { File.Delete(path); }
                        File.Create(path).Close();

                        using (var tw = new StreamWriter(path, true))
                        {
                            tw.WriteLine(ServerName + "," + DataBaseName + "," + UserName + "," + Password + "," + WebService.Trim().Replace("\n", "").Replace("\r", "").Replace("http://", "").Replace("http:/", "").Replace("https://", "").Replace("https:/", ""));
                        }
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varBackupProcess = 0;
                    }
                }
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
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
