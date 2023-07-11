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
namespace ROMS
{
    public partial class PUR_PurchaseApproval : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpusername = new ToolTip();
        private ToolTip tpuserid = new ToolTip();
        private ToolTip tppassword = new ToolTip();
        private ToolTip tpconfirmpassword = new ToolTip();
        private ToolTip tpUserRole  = new ToolTip();
        public string oldpassword,varpassword;
        public string varusercode="";
        public string varUserRoleCode = "";

        public PUR_PurchaseApproval()
        {
            InitializeComponent();
        }
       
    }
}
