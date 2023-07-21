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
    public partial class PUR_GRNDetailsList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public PUR_GRNDetailsList()
        {
            InitializeComponent();
        }

        private void TsbNew_Click(object sender, EventArgs e)
        {

            MainForm.objPUR_GRNDetails = new PUR_GRNDetails(); 
            MainForm.objPUR_GRNDetails.MdiParent = this.ParentForm;
            MainForm.objPUR_GRNDetails.Show();
        }

        private void TsBrandList_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
