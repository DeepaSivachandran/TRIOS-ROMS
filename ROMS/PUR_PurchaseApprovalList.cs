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
    public partial class PUR_PurchaseApprovalList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public PUR_PurchaseApprovalList()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                MainForm.objPUR_PurchaseApproval = new PUR_PurchaseApproval(); 
                MainForm.objPUR_PurchaseApproval.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseApproval.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void PUR_PurchaseApprovalList_Load(object sender, EventArgs e)
        {
            try
            {
                grdPurchaseApproval.Rows.Add("1","","24/07/2023","PR001", "24/07/2023", "PO001", "15200", "","10","Pending","User1 24/06/2023 10:00AM","User2","");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdPurchaseApproval_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PurchaseApproval = new PUR_PurchaseApproval();
                MainForm.objPUR_PurchaseApproval.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseApproval.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }

        }

        private void PUR_PurchaseApprovalList_KeyDown(object sender, KeyEventArgs e)
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
    }
}
