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
    public partial class DEF_Start : Form
    {
        // Author : DEEPA
        // Created Date: 12-02-2020

        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;      
        public DEF_Start()
        {
            InitializeComponent();
            objValidation.resolutionsettingsForm(this);
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
    }
}
