using System;
using ROMS.Model;
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
        private void CP_UserRole_Load(object sender, EventArgs e)
        {
            try
            {
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnList()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_UserRole objMR_UserRole = new MR_UserRole();
                objMR_UserRole.ViewType = 0;
                objDs = objspdservice.udfnUserRoleList(objMR_UserRole);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        // lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            //  lblNoRecordsFound.Visible = false;
                            //lblNoRecordsFound.SendToBack();
                            grdMenuList.DataSource = objDs.Tables[0];
                            //grdGodownList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            //grdGodownList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            //grdGodownList.Columns["Godown Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            //grdGodownList.Columns["No.of Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            //grdGodownList.Columns["Location Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                        }
                        else
                        {
                            //lblNoRecordsFound.Visible = true;
                            //lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        //lblNoRecordsFound.Visible = true;
                        //lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    //lblNoRecordsFound.Visible = true;
                    //lblNoRecordsFound.BringToFront();
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
