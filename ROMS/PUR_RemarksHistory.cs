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
    public partial class PUR_RemarksHistory : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public int varEditflag = 0, varSTRID = 0, varGIID = 0;
        public int varSRQID = 0,varLoadFlag=0;
        public PUR_RemarksHistory()
        {
            InitializeComponent();
        }

         

        private void TxtEUnitName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void PUR_RemarksHistory_Load(object sender, EventArgs e)
        {
            try
            {
                //MainForm.objINV_StockTransfer = new INV_StockTransfer();
                if (varLoadFlag==0)
                {
                    udfnRequestDialog();
                }
                else
                {
                    udfnShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public void udfnShowDialog()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objspdservice = new SPDataService();
                DataTable objGrnPO = new DataTable();
                TRN_GoodsInward objTRNG_GoodsInward = new TRN_GoodsInward();
                if (varEditflag == 1)
                {

                    objTRNG_GoodsInward.ViewType = 2;
                    objTRNG_GoodsInward.paraSTRID = varSTRID;
                    objTRNG_GoodsInward.paraFlag = varEditflag;
                    objTRNG_GoodsInward.paraIPAddress = MainForm.pbIpAddress;
                    objDs = objspdservice.udfnInwardList(objTRNG_GoodsInward);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                txtSTTable.Text = objDs.Tables[0].Rows[0]["flag"].ToString();
                                txtRemarks.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString();
                                txtCreatedby.Text = objDs.Tables[0].Rows[0]["Created By"].ToString();
                                txtCreatedOn.Text = objDs.Tables[0].Rows[0]["Created On"].ToString();
                                MainForm.objINV_Inward.varIDCOUNT = objDs.Tables[0].Rows[0]["STRID"].ToString();

                                if(objDs.Tables[0].Rows.Count > 1)
                                {
                                    txtGITable.Text = objDs.Tables[0].Rows[1]["flag"].ToString();
                                    txtGIRemarks.Text = objDs.Tables[0].Rows[1]["Remarks"].ToString();
                                    txtGICreatedby.Text = objDs.Tables[0].Rows[1]["Created By"].ToString();
                                    txtGICreatedOn.Text = objDs.Tables[0].Rows[1]["Created On"].ToString();
                                    MainForm.objINV_Inward.varIDCOUNT = objDs.Tables[0].Rows[1]["STRID"].ToString();
                                }
                                else
                                {
                                    pnlGoodsInward.Visible = false;
                                }
                                pnlStockRequest.Visible = false;
                            }
                            else
                            {
                                MainForm.objINV_Inward.btnRemarks.Enabled = false;
                                pnlGoodsInward.Visible = false;
                                pnlStockTransfer.Visible = false;
                            }
                        }
                    }
                }
                else
                {
                    objTRNG_GoodsInward.ViewType = 2;
                    objTRNG_GoodsInward.paraSTRID = varSTRID;
                    objTRNG_GoodsInward.paraGIID = varGIID;
                    objTRNG_GoodsInward.paraFlag = varEditflag;
                    objTRNG_GoodsInward.paraIPAddress = MainForm.pbIpAddress;
                    objDs = objspdservice.udfnInwardList(objTRNG_GoodsInward);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                txtSTTable.Text = objDs.Tables[0].Rows[0]["flag"].ToString();
                                txtRemarks.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString();
                                txtCreatedby.Text = objDs.Tables[0].Rows[0]["Created By"].ToString();
                                txtCreatedOn.Text = objDs.Tables[0].Rows[0]["Created On"].ToString();
                                MainForm.objINV_Inward.varIDCOUNT = objDs.Tables[0].Rows[0]["ID"].ToString();
                                if (objDs.Tables[0].Rows.Count > 1)
                                {
                                    txtGITable.Text = objDs.Tables[0].Rows[1]["flag"].ToString();
                                    txtGIRemarks.Text = objDs.Tables[0].Rows[1]["Remarks"].ToString();
                                    txtGICreatedby.Text = objDs.Tables[0].Rows[1]["Created By"].ToString();
                                    txtGICreatedOn.Text = objDs.Tables[0].Rows[1]["Created On"].ToString();
                                    MainForm.objINV_Inward.varIDCOUNT = objDs.Tables[0].Rows[1]["ID"].ToString();
                                }
                                else
                                {
                                    pnlGoodsInward.Visible = false;
                                }
                                if (objDs.Tables[0].Rows.Count > 2)
                                {
                                    lblStockRequest.Text = objDs.Tables[0].Rows[2]["flag"].ToString();
                                    lblSRRemarks.Text = objDs.Tables[0].Rows[2]["Remarks"].ToString();
                                    txtRequestCreated.Text = objDs.Tables[0].Rows[2]["Created By"].ToString();
                                    txtSRCreatedOn.Text = objDs.Tables[0].Rows[2]["Created On"].ToString();
                                    MainForm.objINV_Inward.varIDCOUNT = objDs.Tables[0].Rows[2]["ID"].ToString();
                                }
                                else
                                {
                                    pnlStockRequest.Visible = false;
                                }
                            }
                            else
                            {
                                pnlGoodsInward.Visible = false;
                                pnlStockTransfer.Visible = false;
                                pnlStockRequest.Visible = false;
                            }
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
        public void udfnRequestDialog()
        {
            try
            {
                pnlStockRequest.Visible = false;
                DataSet objDs = new DataSet();
                SPDataService objspdservice = new SPDataService();
                DataTable objGrnPO = new DataTable();
                if (varEditflag == 1)
                {

                    objDs = objspdservice.udfnStockTransferList(4, 0, 0, 0, 0, 0, 0, "", "", varSRQID, varEditflag, "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                txtSTTable.Text = objDs.Tables[0].Rows[0]["flag"].ToString();
                                txtRemarks.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString();
                                txtCreatedby.Text = objDs.Tables[0].Rows[0]["Created By"].ToString();
                                txtCreatedOn.Text = objDs.Tables[0].Rows[0]["Created On"].ToString();
                                MainForm.objINV_StockTransfer.varIDCOUNT = objDs.Tables[0].Rows[0]["SRQID"].ToString();
                                pnlGoodsInward.Visible = false;
                            }
                            else
                            {
                                MainForm.objINV_Inward.btnRemarks.Enabled = false;
                                pnlGoodsInward.Visible = false;
                                pnlStockTransfer.Visible = false;
                            }
                        }
                    }
                }
                else
                {
                    objDs = objspdservice.udfnStockTransferList(4, varSTRID, 0, 0, 0, 0, 0, "", "", varSRQID, varEditflag, "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                txtSTTable.Text = objDs.Tables[0].Rows[0]["flag"].ToString();
                                txtRemarks.Text = objDs.Tables[0].Rows[0]["SRQ_Remarks"].ToString();
                                txtCreatedby.Text = objDs.Tables[0].Rows[0]["SRQ Created By"].ToString();
                                txtCreatedOn.Text = objDs.Tables[0].Rows[0]["SRQ Created On"].ToString();
                                MainForm.objINV_StockTransfer.varIDCOUNT = objDs.Tables[0].Rows[0]["SRQID"].ToString();

                                if (objDs.Tables[0].Rows.Count > 1)
                                {
                                    txtGITable.Text = objDs.Tables[0].Rows[1]["flag"].ToString();
                                    txtGIRemarks.Text = objDs.Tables[0].Rows[1]["SRQ_Remarks"].ToString();
                                    txtGICreatedby.Text = objDs.Tables[0].Rows[1]["SRQ Created By"].ToString();
                                    txtGICreatedOn.Text = objDs.Tables[0].Rows[1]["SRQ Created On"].ToString();
                                    MainForm.objINV_StockTransfer.varIDCOUNT = objDs.Tables[0].Rows[0]["SRQID"].ToString();
                                }
                                else
                                {
                                    pnlGoodsInward.Visible = false;
                                }
                            }
                            else
                            {
                                pnlGoodsInward.Visible = false;
                                pnlStockTransfer.Visible = false;
                            }
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
        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void TxtCreated_Click(object sender, EventArgs e)
        {

        }
    }
}
