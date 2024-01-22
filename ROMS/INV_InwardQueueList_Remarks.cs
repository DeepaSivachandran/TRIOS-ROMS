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
        public int varEditflag = 0, varSTRID = 0, varID = 0,varRemarkFlag=0,varFlag=0,varTableCount=0;
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
                    objTRN_GoodsInward_Purchase.paraInwardId = varID;
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
                                panel4.Visible = false;
                                panel3.Visible = false;
                                panel2.Visible = false;
                                if (objDs.Tables[0].Rows.Count > 0)
                                {
                                    if (objDs.Tables[1].Rows.Count != 0)
                                    {
                                        panel2.Visible = true;
                                        txtRemarks2.Text = objDs.Tables[1].Rows[0]["Remarks"].ToString();
                                        txtCreatedby2.Text = objDs.Tables[1].Rows[0]["Created By"].ToString();
                                        txtCreatedOn2.Text = objDs.Tables[1].Rows[0]["Created On"].ToString();
                                        txtTable2.Text = objDs.Tables[1].Rows[0]["Transaction"].ToString();
                                        panel4.Visible = false;
                                        panel3.Visible = false;
                                    }
                                }
                                if (objDs.Tables[0].Rows.Count > 1)
                                {
                                    if (objDs.Tables[2].Rows.Count != 0)
                                    {
                                        panel3.Visible = true;
                                        txtRemarks3.Text = objDs.Tables[2].Rows[0]["Remarks"].ToString();
                                        txtCreatedby3.Text = objDs.Tables[2].Rows[0]["Created By"].ToString();
                                        txtCreatedOn3.Text = objDs.Tables[2].Rows[0]["Created On"].ToString();
                                        txtTable3.Text = objDs.Tables[2].Rows[0]["Transaction"].ToString();
                                        panel4.Visible = false;
                                    }
                                }
                                if (objDs.Tables[0].Rows.Count > 2)
                                {
                                    if (objDs.Tables[3].Rows.Count != 0)
                                    {
                                        panel4.Visible = true;
                                        txtRemarks4.Text = objDs.Tables[3].Rows[0]["Remarks"].ToString();
                                        txtCreatedby4.Text = objDs.Tables[3].Rows[0]["Created By"].ToString();
                                        txtCreatedOn4.Text = objDs.Tables[3].Rows[0]["Created On"].ToString();
                                        txtTable4.Text = objDs.Tables[3].Rows[0]["Transaction"].ToString();
                                    }
                                }
                            }
                        }  
                    }
                }
                //else
                //{
                //    objTRNG_GoodsInward.ViewType = 2;
                //    objTRNG_GoodsInward.paraSTRID = varSTRID;
                //    objTRNG_GoodsInward.paraGIID = varGIID;
                //    objTRNG_GoodsInward.paraFlag = varEditflag;
                //    objTRNG_GoodsInward.paraIPAddress = MainForm.pbIpAddress;
                //    objDs = objspdservice.udfnInwardList(objTRNG_GoodsInward);
                //    objspdservice.CloseConnection();
                //    if (objDs != null)
                //    {
                //        if (objDs.Tables.Count != 0)
                //        {
                //            if (objDs.Tables[0].Rows.Count != 0)
                //            {
                //                txtGIPTable.Text = objDs.Tables[0].Rows[0]["flag"].ToString();
                //                txtGIPRemarks.Text = objDs.Tables[0].Rows[0]["STR_Remarks"].ToString();
                //                txtGIPCreatedby.Text = objDs.Tables[0].Rows[0]["STR Created By"].ToString();
                //                txtGIPCreatedOn.Text = objDs.Tables[0].Rows[0]["STR Created On"].ToString();
                //                if (objDs.Tables[0].Rows.Count > 1)
                //                {
                //                    txtGITable.Text = objDs.Tables[0].Rows[1]["flag"].ToString();
                //                    txtGIRemarks.Text = objDs.Tables[0].Rows[1]["STR_Remarks"].ToString();
                //                    txtGICreatedby.Text = objDs.Tables[0].Rows[1]["STR Created By"].ToString();
                //                    txtGICreatedOn.Text = objDs.Tables[0].Rows[1]["STR Created On"].ToString();
                //                }
                //            }
                //        }
                //    }
                //}
            //}
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
