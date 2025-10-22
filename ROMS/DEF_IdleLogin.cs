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
    public partial class DEF_IdleLogin : Form
    {
        // Author : Venkat
        // Created Date: 17-10-2025
        MainForm objMainForm = new MainForm();
        public int varFormCloseFlag = 0;
        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpPassword = new ToolTip();
        public bool IsPasswordCorrect { get; private set; } = false;
        private SecurityController _security;

        private static DEF_IdleLogin instance = null;
        public DEF_IdleLogin()
        {
            InitializeComponent();
            objValidation.resolutionsettingsForm(this);
            _security = new SecurityController();
            lbluserName.Text = MainForm.pbUserName;
            timerClock.Start();
            this.StartPosition = FormStartPosition.Manual;

            objMainForm.pbForceLogoff = 0;
            // Get the size of the primary screen
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle screenArea = primaryScreen.WorkingArea; // WorkingArea excludes the taskbar

            int x = (screenArea.Width - this.Width) / 2;

            int y = (screenArea.Height - this.Height + 48) / 2;

            this.Location = new Point(x, y);
        }
        public static DEF_IdleLogin GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new DEF_IdleLogin();
            }
            return instance;
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {

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

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPassword.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPassword.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSignin_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet objDs = new DataSet();
                if (txtPassword.TextLength != 0)
                {
                    SPDataService objDser = new SPDataService();
                    int count = 0;
                    // objDs = objDser.udfnUserList(0,varUserName ,txtUserName.Text.Trim(), GenerateMD5(txtPassword.Text),0,"");
                    objDs = objDser.udfnUserList(0, "", MainForm.pbUserName, _security.Encrypt(MainForm.pbUserName.ToLower(), txtPassword.Text), 0, 0, "");
                    objDser.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count > 0)
                        {
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                count = Convert.ToInt32(objDs.Tables[0].Rows[0]["countvalue"]);
                                if (count != 0)
                                {
                                    IsPasswordCorrect = true;
                                    objMainForm.pbForceLogoff = 1;
                                    objMainForm.pbCloseForm = 1; 
                                    this.Close();
                                }
                                else if (count == 0)
                                {
                                    DialogResult response = MessageBox.Show(Convert.ToString(objDs.Tables[1].Rows[0]["MessageText"]), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                    txtPassword.Text = "";
                                    txtPassword.Focus();
                                }
                            }
                        }
                    }
                }
                else
                {

                    if (txtPassword.Text == "")
                    {
                        txtPassword.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpPassword.Show("Password is required", txtPassword, 5000);
                    }
                    else
                    {
                        tpPassword.Hide(txtPassword);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            try
            {

                // Get the current system time
                DateTime now = DateTime.Now;
                lblClock.Text = now.ToString("hh:mm tt");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DEF_IdleLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (objMainForm.pbForceLogoff == 0) 
                {
                    DialogResult objResponse = MessageBox.Show("Are you sure want to logout?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if ((objResponse == DialogResult.Yes))
                    {
                        objMainForm.pbForceLogoff = 1;
                        objMainForm.pbCloseForm = 1;
                        objMainForm.udfnClose();
                    }
                    else
                    {
                        objMainForm.pbForceLogoff = 0;
                        e.Cancel = true;
                    }
                }
                ////if (varFormCloseFlag == 0)
                ////{
                ////    varFormCloseFlag = 1;
                ////    e.Cancel = true;
                ////}
                ////else
                ////{
                ////}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
