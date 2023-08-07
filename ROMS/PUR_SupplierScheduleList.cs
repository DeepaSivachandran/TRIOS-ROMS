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
    public partial class PUR_SupplierScheduleList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public PUR_SupplierScheduleList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_SupplierMapping = new CP_SupplierMapping();
                //MainForm.objCP_SupplierMapping.StartPosition = FormStartPosition.Manual;  
                //int dialogX = this.Location.X + (this.Width - MainForm.objCP_SupplierMapping.Width ) / 2;
                //int dialogY = this.Location.Y + (this.Height - MainForm.objCP_SupplierMapping.Height + 100) / 2; 
                //MainForm.objCP_SupplierMapping.Location = new Point(dialogX, dialogY); 

                MainForm.objCP_SupplierMapping.MdiParent = this.ParentForm;
                MainForm.objCP_SupplierMapping.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
      
        private void BtnSchedulePopup_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_POScheduledaywise = new PUR_POScheduledaywise();   
                MainForm.objPUR_POScheduledaywise.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void PUR_SupplierScheduleList_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                   // tsbEdit_Click(sender, e);
                }
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
    }
}
