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
using ROMS.Model;

namespace ROMS
{
    public partial class PUR_PurchaseRemarksHistory : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public int varID = 0, varRemarkFlag = 0, varGIID = 0, varPurchaseID=0;
        public string count1="", count2="", count3="";
        public PUR_PurchaseRemarksHistory()
        {
            InitializeComponent();
        }
        private void PUR_RemarksHistory_Load(object sender, EventArgs e)
        {
            try
            {
                udfnRemarkList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRemarkList()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 9;
                objTRN_PurchaseEntry.ParaIds =Convert.ToString(varID);
                objTRN_PurchaseEntry.paraEntryType = varRemarkFlag;
                objTRN_PurchaseEntry.paraPurchaseId = varPurchaseID;
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                if (objDs != null)
                {
                   // varTableCount = Convert.ToInt32(objDs.Tables.Count);
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            txtTable1.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString();
                            txtCreatedby1.Text = objDs.Tables[0].Rows[0]["Created By"].ToString();
                            txtCreatedOn1.Text = objDs.Tables[0].Rows[0]["Created On"].ToString();
                            txtTable1.Text = objDs.Tables[0].Rows[0]["Transaction"].ToString();
                            count1 = objDs.Tables[0].Rows[0]["Count"].ToString();
                        }
                        if (objDs.Tables[0].Rows.Count > 1)
                        {
                            txtTable2.Text = objDs.Tables[0].Rows[1]["Remarks"].ToString();
                            txtCreatedby2.Text = objDs.Tables[0].Rows[1]["Created By"].ToString();
                            txtCreatedOn2.Text = objDs.Tables[0].Rows[1]["Created On"].ToString();
                            txtTable2.Text = objDs.Tables[0].Rows[1]["Transaction"].ToString();
                            count2 = objDs.Tables[0].Rows[0]["Count"].ToString();
                        }
                        if (objDs.Tables[0].Rows.Count > 2)
                        {
                            txtRemarks3.Text = objDs.Tables[0].Rows[2]["Remarks"].ToString();
                            txtCreatedby3.Text = objDs.Tables[0].Rows[2]["Created By"].ToString();
                            txtCreatedOn3.Text = objDs.Tables[0].Rows[2]["Created On"].ToString();
                            txtTable3.Text = objDs.Tables[0].Rows[2]["Transaction"].ToString();
                            count3 = objDs.Tables[0].Rows[2]["Count"].ToString();
                        }
                    }
                }
                if (count1 == "")
                { panel1.Visible = false; }
                if (count2 == "")
                { panel2.Visible = false; }
                if (count3 == "")
                { panel3.Visible = false; }
               
                if (count1 != "" || count2 != "" || count3 != "" )
                {
                    MainForm.objCP_Purchase.varRemarkCount = 1;
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
