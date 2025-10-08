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
        DataTable objDtSplPermission = new DataTable();
        public CP_UserRole_SPL()
        {
            InitializeComponent();
        }

        private void CP_UserRole_SPL_Load(object sender, EventArgs e)
        {
            try
            {
                objDtSplPermission.Clear();
                objDtSplPermission = MainForm.objDtMenuSplPermission.Copy();

                udfnView();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnView() 
        {
            try {
                if (objDtSplPermission != null)
                { 
                    if (objDtSplPermission.Rows.Count != 0)
                    {
                        for (int i = 0; i < objDtSplPermission.Rows.Count; i++)
                        {
                            grdUserSPLPermission.Rows.Add(Convert.ToString(objDtSplPermission.Rows[i]["MU_NAME"]), 0, 0, Convert.ToString(objDtSplPermission.Rows[i]["MUP_MU_Code"]), Convert.ToString(objDtSplPermission.Rows[i]["MUP_Code"]));
                        }
                    } 
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
