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
    public partial class INV_InwardQueueList_Remarks : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public int varEditflag = 0, varSTRID = 0, varID = 0, varRemarkFlag = 0, varFlag = 0, varTableCount = 0;
        string count1="", count2 = "", count3 = "", count4 = "";
        public INV_InwardQueueList_Remarks()
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
                DataSet objDs = new DataSet();
                SPDataService objspdservice = new SPDataService();
                DataTable objDT = new DataTable();
                TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                //if (varEditflag == 1)
                //{
                objTRN_GoodsInward_Purchase.ViewType = 5;
                objTRN_GoodsInward_Purchase.paraFlag = varFlag;
                objTRN_GoodsInward_Purchase.paraRemarkFlag = varRemarkFlag;
                objTRN_GoodsInward_Purchase.paraID = varID;
                objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                objDs = objspdservice.udfnInwardPurchaseList(objTRN_GoodsInward_Purchase);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    varTableCount = Convert.ToInt32(objDs.Tables.Count);
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            txtRemarks1.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString();
                            txtCreatedby1.Text = objDs.Tables[0].Rows[0]["Created By"].ToString();
                            txtCreatedOn1.Text = objDs.Tables[0].Rows[0]["Created On"].ToString();
                            txtTable1.Text = objDs.Tables[0].Rows[0]["Transaction"].ToString();
                            count1 = objDs.Tables[0].Rows[0]["Count"].ToString();
                        }
                        if (objDs.Tables[0].Rows.Count > 1)
                        {
                            txtRemarks2.Text = objDs.Tables[0].Rows[1]["Remarks"].ToString();
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
                        if (objDs.Tables[0].Rows.Count > 3)
                        {
                            txtRemarks4.Text = objDs.Tables[0].Rows[3]["Remarks"].ToString();
                            txtCreatedby4.Text = objDs.Tables[0].Rows[3]["Created By"].ToString();
                            txtCreatedOn4.Text = objDs.Tables[0].Rows[3]["Created On"].ToString();
                            txtTable4.Text = objDs.Tables[0].Rows[3]["Transaction"].ToString();
                            count4 = objDs.Tables[0].Rows[3]["Count"].ToString();
                        }
                    }
                }
                if (count1 == "")
                { panel1.Visible = false; }
                if (count2 == "")
                { panel2.Visible = false; }
                if (count3 == "")
                { panel3.Visible = false; }
                if (count4 == "")
                { panel4.Visible = false; }
                if(count1!="" || count2!="" || count3!="" || count4!="")
                {
                    MainForm.objINV_InwardPurchase.varRemarkCount = 1;
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
                  
