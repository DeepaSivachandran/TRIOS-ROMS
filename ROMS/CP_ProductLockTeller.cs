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
    public partial class CP_ProductLockTeller : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private SecurityController _security;
        private ToolTip tpVerifier = new ToolTip();
        public CP_ProductLockTeller()
        {
            InitializeComponent();
            _security = new SecurityController();
        }
        private void btnSubmit_Enter(object sender, EventArgs e)
        {
            try
            {
                lvVerified1.Visible = false;
                btnSubmit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvVerified1.Items.Count == 0 || txtTeller.Text == "")
                    {
                        lvVerified1.Visible = false;
                    }
                    else
                    {
                        lvVerified1.Focus();
                    }
                    if (lvVerified1.Items.Count > 0)
                    {
                        lvVerified1.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnSubmit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtTeller_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTeller.Text.Length > 0)
                {
                    lvVerified1.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(14, txtTeller.Text.Trim(), 0, "", 1, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["EMP_Name"].ToString(), objDs.Tables[0].Rows[i]["EMPID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvVerified1.Columns[1].Width = 0;
                                    lvVerified1.Items.Add(objList);
                                }
                                lvVerified1.BringToFront();
                                lvVerified1.Visible = true;
                            }
                            else
                            {
                                lvVerified1.Visible = false;
                            }
                        }
                        else
                        {
                            lvVerified1.Visible = false;
                        }
                    }
                    else
                    {
                        lvVerified1.Visible = false;
                    }
                }
                else
                {
                    lvVerified1.Visible = false;
                    lvVerified1.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvVerified1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnVerified1();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvVerified1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnVerified1();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_ProductLockTeller_Load(object sender, EventArgs e)
        {
            try
            {
                txtTeller.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txtTeller.Text).Trim() == "")
            {
                epTeller.SetError(txtTeller, "Please enter valid teller name");
                txtTeller.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpVerifier.ShowAlways = true;
                tpVerifier.Show("Please enter valid teller name", txtTeller, 5000);
                txtTeller.Focus();
                return;
            }
            else
            {
                MainForm.objCP_Rate_ChangeList.pbUnLockTellerName = txtTeller.Text.Trim();
                this.Close();
            }
        }

        public void udfnVerified1()
        {
            try
            {
                if (txtTeller.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvVerified1.SelectedItems[0];
                    txtTeller.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvVerified1.Visible = false;
                txtTeller.Focus();
            }
        }

        private void btnSubmit_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSubmit.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
