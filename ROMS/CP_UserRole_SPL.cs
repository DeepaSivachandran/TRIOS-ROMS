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
    //Created By:-Sathish ; Created On:-11-08-2023
    public partial class CP_UserRole_SPL : Form
    {
        DataError objError;
        private ToolTip tpCityName = new ToolTip();
        private ToolTip tpState = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public int varstatus;
        public string PbCityName="";
        public int varCityCode= 0;
        public string varCityName = "";
        public string PbStateName="";
        public int PbStateId=0;
        public int PbStatus=0;
        public int varUpdate = 0;
        public int varmastertype = 0;
        public int varflog = 0;
        public CP_UserRole_SPL()
        {
            InitializeComponent();
        }

        
    }
}
