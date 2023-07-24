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
                MainForm.objPUR_PurchaseApproval.ShowDialog();
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
                grdPurchaseApproval.Rows.Add("1","24/07/2023","PR001","PO001", "Supplier 1","15200","10","Pending","User1","User2");
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
                MainForm.objPUR_PurchaseApproval.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }

        }
    }
}
