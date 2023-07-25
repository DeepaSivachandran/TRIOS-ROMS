using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Drawing.Drawing2D;

namespace ROMS
{
    public partial class PUR_RemarksHistory : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public PUR_RemarksHistory()
        {
            InitializeComponent();
        }

         

        private void TxtEUnitName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void PUR_RemarksHistory_Load(object sender, EventArgs e)
        {

           
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
        
        }
    }
}
