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
    public partial class PUR_POScheduledaywise : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public PUR_POScheduledaywise()
        {
            InitializeComponent();
        }

        private void PUR_POScheduledaywise_Load(object sender, EventArgs e)
        {
            try
            {


                grdPOSchedule.Rows.Add(1, "Monday");
                grdPOSchedule.Rows.Add(2, "Tuesday");
                grdPOSchedule.Rows.Add(3, "Wednesday");
                grdPOSchedule.Rows.Add(4, "Thursday"); 
                grdPOSchedule.Rows.Add(5, "Friday");
                grdPOSchedule.Rows.Add(6, "Saturday");
                grdPOSchedule.Rows.Add(7, "Sunday");

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
    }
}
