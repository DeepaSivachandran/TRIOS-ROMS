using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace ROMS
{  
    public partial class MainForm : Form
    {
        //------- Servic Class object declaration
        DataValidation objValidation = new DataValidation();
        public DataError objError = new DataError();

        //------- Variable Declaration
        public static int pbCloseForm = 0;
        public static int varCloseFlag = 0;
        public static string pbVersion="1.0.0";
        public static string pbUserID ="";
        public static string pbUserName="";
        public static string pbUserRoleId;
        public static string pbView;
        public static string pbSelectedMenu;
        public static string pbIpAddress= "";
        public static string pbHostName = "";
        public static string pbUserRoleName = "";
        public static string pbReleaseDt = "";
        public static string pbLablingSoftwareName = "";
        public static string pbRomsSoftwareName = "";
        public static bool isFormClosed = false;
        public static bool isClose = false;
        public static bool isFormClosedMenu = false;
        //------- Form object declaration
        public static MainForm objMainForm;
        public static DEF_Start objStart;
        public static CP_ChangePassword objCP_ChangePassword;
        public static CP_BrandList objCP_BrandList;
        public static CP_Brand objCP_Brand;
        public static CP_Company objCP_Company;
        public static CP_Supplier objCP_Supplier;
        public static CP_Supplierlist objCP_Supplierlist;
        public static CP_Companylist objCP_Companylist;
        public static  CP_ProductHSN objCP_ProductHSN;
        public static  CP_ProductHSNList objCP_ProductHSNlist;
        public static CP_Unitlist objCP_Unitlist;
        public static CP_Unit objCP_Unit;
        public static CP_City objCP_City;
        public static CP_Citylist objCP_Citylist;
        public static CP_GroupList objCP_GroupList;
        public static CP_Group objCP_Group;
        public static CP_SubGroupList objCP_SubGroupList;
        public static CP_SubGroup objCP_SubGroup; 
        public static CP_LocationList objCP_LocationList;
        public static CP_Location objCP_Location; 
        public static CP_Rack objCP_Rack;
        public static CP_UserList objCP_Userlist;
        public static CP_User objCP_User; 







        public static DataTable objDtMenuDetails;
        public static DataTable objDtMenuCloseDet;

        public MainForm()
        {
            try
            {
                InitializeComponent();
                objValidation.setFontAndFontSize(this);
                timer1.Start();
                //ms.Renderer = new CustomMenuStripRenderer();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    
    
        //Close Form
        public void  udfnCloseChildForms()
        {
            try
            {
                String Str_ChildForm = "";
                Boolean Bln_NoChildForm = true;
                foreach (Form child in MdiChildren)
                {
                    Bln_NoChildForm = false;
                    bool isFound = false;
                    isFound = IsFrmOpen(child);
                    if (child.Name == "DEF_Start" || Str_ChildForm != "")
                    {
                        child.Close();
                        isClose = true;
                        return;
                    }
                    bool exists = false;
                    exists = objDtMenuCloseDet.AsEnumerable().Where(c => c.Field<string>("MenuName").Equals(child.Text) && c.Field<int>("CloseFlag").Equals(0)).Count() > 0;
                    
                    if (isFound == true && exists == false )
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            child.Close();
                            isClose = true;
                        }
                        else { isClose = false; }
                        Str_ChildForm = child.Name;
                        //isFormClosedMenu = true ;
                    }
                    else { child.Close(); }
                    //isClose = false;
                }
                if (Bln_NoChildForm == true) { isClose = true; }
            }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
      
        public bool IsFrmOpen(Form nameForm)
        {
            bool isFound = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == nameForm.Name)
                {
                    isFound = true;
                }
            }
            return isFound;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {               
                GetLocalIPAddress();
                this.Text = "ROMS" + " - " +MainForm.pbVersion+" Release Dt : "+MainForm.pbReleaseDt+" [ "+MainForm.pbLablingSoftwareName+" ]";
                udfnCloseChildForms();
                lblTime.Text = "Welcome " + MainForm.pbUserName+" / "+MainForm.pbUserRoleName + " @ "+MainForm.pbHostName;
                //lblDb.Text = "ROMS DB : "+MainForm.pbRomsSoftwareName;
                objStart = new DEF_Start();
                objStart.MdiParent = this;
                objStart.Show();
            }
            catch (Exception ex)
            { objError = new DataError();objError.WriteFile(ex); }
        }
        //Close Application when click logout
        private void tsbLogout_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DialogResult objResponse = MessageBox.Show("Are you sure want to Logout?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //    if ((objResponse == DialogResult.Yes))
            //    {
            //        if ((System.Windows.Forms.Application.MessageLoop))
            //        {
            //            varCloseFlag = 1;
            //            System.Windows.Forms.Application.Exit();
            //        }
            //        else
            //        {
            //            System.Environment.Exit(1);
            //        }
            //        Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
            
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
                {
                    if (pbCloseForm == 0)
                    {
                        DialogResult objResponse = MessageBox.Show("Are you sure want to Logout?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if ((objResponse == DialogResult.Yes))
                        {
                            e.Cancel = false;
                            varCloseFlag = 1;
                            System.Windows.Forms.Application.Exit();
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        e.Cancel = false;
                        varCloseFlag = 1;
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }         
        }
     
        private void tsbBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog objSaveDialogu = new SaveFileDialog();

                if (objSaveDialogu.ShowDialog() == DialogResult.OK)
                {
                    string varFileName = objSaveDialogu.FileName;
                    SPDataService objSPService = new SPDataService();
                    objSPService.spdbbackup(varFileName);
                    MessageBox.Show("Successfully Downloaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
       
        private void MainForm_Resize(object sender, EventArgs e)
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
       
        private void ntfy_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Show();
                WindowState = FormWindowState.Maximized;
                ntfy.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        
        private void ntfy_Click(object sender, EventArgs e)
        {
            try
            {
                Show();
                WindowState = FormWindowState.Maximized;
                ntfy.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
           
        //Get IP address
        public void GetLocalIPAddress()
        {
            try
            {
                pbIpAddress = Dns.GetHostAddresses(Dns.GetHostName()).First(a => a.AddressFamily == AddressFamily.InterNetwork).ToString();
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        private void tsbSettings_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnClose() {
            try {
                if (pbCloseForm == 0)
                {
                    DialogResult objResponse = MessageBox.Show("Are you sure want to Logout?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if ((objResponse == DialogResult.Yes))
                    {
                        if ((System.Windows.Forms.Application.MessageLoop))
                        {
                            varCloseFlag = 1;
                            System.Windows.Forms.Application.Exit();
                        }
                        else
                        {
                            System.Environment.Exit(1);
                        }
                        Close();
                    }
                }
                else {
                    if ((System.Windows.Forms.Application.MessageLoop))
                    {
                        varCloseFlag = 1;
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        System.Environment.Exit(1);
                    }
                    Close();
                }
            }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmLogout_Click(object sender, EventArgs e)
        {
            try
            {
                udfnClose();
                //if (pbUserRoleId == "0")
                //{
                //    udfnClose();
                //}
                //else
                //{
                //    if (objDtMenuDetails != null)
                //    {
                //        var varValue = (from r in objDtMenuDetails.AsEnumerable() where r.Field<int>("MenuCode").Equals(Convert.ToInt32(602)) group r by r.Field<int>("PrivilegeCode") into g select g.Key).ToList();
                //        if (varValue.Count() > 0)
                //        {
                //            udfnClose();
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCloseChildForms(Boolean Bln)
        {
            try
            {
                MainForm.objMainForm = new MainForm ();
                MainForm.objMainForm.tsmControlPanel.Enabled = Bln;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_ChangePassword = new CP_ChangePassword();
                MainForm.objCP_ChangePassword.MdiParent = this;
                MainForm.objCP_ChangePassword.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmBrand_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BrandList = new CP_BrandList();
                MainForm.objCP_BrandList.MdiParent = this;
                MainForm.objCP_BrandList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmCompany_Click(object sender, EventArgs e)
        {

            udfnCloseChildForms();
            if (isClose == false) { return; }
            MainForm.objCP_Companylist = new CP_Companylist();
            MainForm.objCP_Companylist.MdiParent = this;
            MainForm.objCP_Companylist.Show();
        }

        private void TsmSuppliyer_Click(object sender, EventArgs e)
        {
            udfnCloseChildForms();
            if (isClose == false) { return; }
            MainForm.objCP_Supplierlist = new CP_Supplierlist();
            MainForm.objCP_Supplierlist.MdiParent = this;
            MainForm.objCP_Supplierlist.Show();
        }

        private void TsmUnit_Click(object sender, EventArgs e)
        {
            udfnCloseChildForms();
            if (isClose == false) { return; }
            MainForm.objCP_Unitlist = new CP_Unitlist();
            MainForm.objCP_Unitlist.MdiParent = this;
            MainForm.objCP_Unitlist.Show();
        }

        private void StateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            udfnCloseChildForms();
            if (isClose == false) { return; }
            MainForm.objCP_Citylist = new CP_Citylist();
            MainForm.objCP_Citylist.MdiParent = this;
            MainForm.objCP_Citylist.Show();
        }

        private void TsmGroup_Click(object sender, EventArgs e)
        {
            udfnCloseChildForms();
            if (isClose == false) { return; }
            MainForm.objCP_GroupList = new CP_GroupList();
            MainForm.objCP_GroupList.MdiParent = this;
            MainForm.objCP_GroupList.Show();
        }

        private void TsmSubGroup_Click(object sender, EventArgs e)
        {
            udfnCloseChildForms();
            if (isClose == false) { return; }
            MainForm.objCP_SubGroupList = new CP_SubGroupList();
            MainForm.objCP_SubGroupList.MdiParent = this;
            MainForm.objCP_SubGroupList.Show();
        }

        private void TsmUser_Click(object sender, EventArgs e)
        {
            udfnCloseChildForms();
            if (isClose == false) { return; }
            MainForm.objCP_Userlist = new CP_UserList();
            MainForm.objCP_Userlist.MdiParent = this;
            MainForm.objCP_Userlist.Show();

        }

        private void TsmLocation_Click(object sender, EventArgs e)
        {
            udfnCloseChildForms();
            if (isClose == false) { return; }
            MainForm.objCP_LocationList = new CP_LocationList();
            MainForm.objCP_LocationList.MdiParent = this;
            MainForm.objCP_LocationList.Show();

        }

        private void Tsmpurchase_Click(object sender, EventArgs e)
        {

        }
    }
   
}
