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


namespace ROMS
{
    public partial class Financial_Year_Process : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        public int varBackupProcess = 0;
        public int varTimer = 0;
        public Financial_Year_Process()
        {
            InitializeComponent();
        }
        private void Fy_Process_Load(object sender, EventArgs e)
        {
            try
            {
                tmrProcess.Enabled = true;
                tmrProcess.Start();
                tmrProcess.Interval = 1500;

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
                //tmrProcess.Tick += new EventHandler(timer1_Tick);
                this.PbBackup.Maximum = 100;
                this.PbBackup.Minimum = 1;
                this.PbBackup.Step = 1;
                varBackupProcess = 1;
                tmrProcess.Tick += new EventHandler(udfnDbBackup);
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
        public void udfnDbBackup(object sender, EventArgs e)
        {
            try
            {
                if (varBackupProcess == 1)
                {
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varoriginator = "";
                    varoriginator = "Database Backup";
                    varResult = objspservice.udfnDbBackup(varoriginator);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
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
                    if (PbBackup.Value != 25)
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
                    }
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
                    if (PbBackup.Value != 50)
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
                    }
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
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varoriginator = "";
                    varoriginator = "Clear Transactions";
                    varResult = objspservice.udfnDBClearTransaction(1, varoriginator);
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
                    if (PbBackup.Value != 75)
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
                    }
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
                    if (PbBackup.Value != 75)
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
