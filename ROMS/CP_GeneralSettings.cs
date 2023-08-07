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
    public partial class CP_GeneralSettings : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_GeneralSettings()
        {
            InitializeComponent();
        } 
         
        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
        }
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
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

        private void CP_GeneralSettings_Load(object sender, EventArgs e)
        {

            try
            {

                grdOrderType.Rows.Add("Phone", "");
                grdOrderType.Rows.Add("Visit", "");
                grdOrderType.Rows.Add("Mobile App", "");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CP_GeneralSettings_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                   
                    if (e.KeyCode == Keys.Escape)
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
