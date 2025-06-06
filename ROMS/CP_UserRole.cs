using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;

namespace ROMS
{
    public partial class CP_UserRole : Form
    {
        // Author : DEEPA
        //Sivabharathi on 10-10-2023

        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private SecurityController _security = new SecurityController();
        public int varPassKeyId=0;
        public int varUserId = 0;
        public int varPasswordFlag = 0;
        public int varPasskeyFlag = 0,flag=0;
        public string varPassword = "",varPasskeyValue="";
        private ToolTip tpOldPassword = new ToolTip();
        private ToolTip tpNewPassword = new ToolTip();
        private ToolTip tpConfirmPassword = new ToolTip();
        public CP_UserRole()
        {
            InitializeComponent();
            objValidation.resolutionsettingsForm(this);
        }  
        private void CP_ChangePassword_Load(object sender, EventArgs e)
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
