using ROMS;
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
    public partial class ReportLoad : Form
    {
        DataError objError;
        public ReportLoad()
        {
            InitializeComponent();
        }

        private void ReportLoad_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (this.cryptview != null)
                {
                    this.cryptview.ReportSource = null;
                    this.cryptview.Dispose();
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
