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
        public PUR_RemarksHistory()
        {
            InitializeComponent();
        }
        private void PUR_RemarksHistory_Load(object sender, EventArgs e)
        {
            try
            {
                udfnShowDialog();
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
                                txtRemarks.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString();
                                txtCreatedby.Text = objDs.Tables[0].Rows[0]["Created By"].ToString();
                                txtCreatedOn.Text = objDs.Tables[0].Rows[0]["Created On"].ToString();
                                MainForm.objINV_Inward.varIDCOUNT = objDs.Tables[0].Rows[0]["STRID"].ToString();
                                panel4.Visible = false;
                            }
                            else
                            {
                                MainForm.objINV_Inward.btnRemarks.Enabled = false;
                                panel4.Visible = false;
                                panel2.Visible = false;
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
                                txtRemarks.Text = objDs.Tables[0].Rows[0]["STR_Remarks"].ToString();
                                txtCreatedby.Text = objDs.Tables[0].Rows[0]["STR Created By"].ToString();
                                txtCreatedOn.Text = objDs.Tables[0].Rows[0]["STR Created On"].ToString();
                                MainForm.objINV_Inward.varIDCOUNT = objDs.Tables[0].Rows[0]["STRID"].ToString();

                                if (objDs.Tables[0].Rows.Count > 1)
                                {
                                    txtGITable.Text = objDs.Tables[0].Rows[1]["flag"].ToString();
                                    txtGIRemarks.Text = objDs.Tables[0].Rows[1]["STR_Remarks"].ToString();
                                    txtGICreatedby.Text = objDs.Tables[0].Rows[1]["STR Created By"].ToString();
                                    txtGICreatedOn.Text = objDs.Tables[0].Rows[1]["STR Created On"].ToString();
                                    MainForm.objINV_Inward.varIDCOUNT = objDs.Tables[0].Rows[0]["STRID"].ToString();
                                }
                                else
                                {
                                    panel4.Visible = false;
                                }
                            }
                            else
                            {
                                panel4.Visible = false;
                                panel2.Visible = false;
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
    }
}
