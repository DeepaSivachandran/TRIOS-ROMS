using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    //Author : Sathish
    //Created On : 20-02-2025
    public partial class CP_Rack_Token : Form
    {

        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public static string varFGCode;
        public int varStickerType;
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpType = new ToolTip();
        private ToolTip tpLabelSize = new ToolTip();
        private ToolTip tpLabelCount = new ToolTip();
        public string varProductCodes, varRMCodes, varFGCodes = "0";
        List<string> varPMGroupCodes = new List<string>();
        List<string> varGroupCodes = new List<string>();
        public DataTable dtRack, dtProducts;
        private int varsno;

        private void grdRack_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    picloader2.Visible = true;
                    udfnProductBind();
                    picloader2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public CP_Rack_Token()
        {
            InitializeComponent();
            objValidation.resolutionsettingsForm(this);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.ControlBox = true;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.Manual;
        }

        private void CP_Rack_Token_Load(object sender, EventArgs e)
        {
            try
            {
                dtRack = new DataTable();
                dtRack.Columns.Add("", typeof(Boolean));
                dtRack.Columns.Add("Rack Name", typeof(string));
                dtRack.Columns.Add("Rackcode", typeof(int));

                dtProducts = new DataTable();
                dtProducts.Columns.Add("", typeof(Boolean));
                dtProducts.Columns.Add("P.I Code", typeof(string));
                dtProducts.Columns.Add("Product", typeof(int));
                dtProducts.Columns.Add("Unit", typeof(int));
                udfnRackLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnRackLoad()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objspdservice = new SPDataService();
                objDs = objspdservice.udfnRackList(10,0,0,0,0,"",0,0);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            dtRack.Rows.Add(false, objDs.Tables[0].Rows[i]["RackName"].ToString(), objDs.Tables[0].Rows[i]["RackCode"].ToString());
                        }
                        grdRack.DataSource = dtRack;
                        grdRack.Columns[0].Width = 50;
                        grdRack.Columns["Rack Name"].Width = 200;
                        grdRack.Columns["Rackcode"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnProductBind()
        {
            try
            {
                grdProducts.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objspdservice = new SPDataService();
                objDs = objspdservice.udfnRackList(10, 0, 0, 0, 0, "", 0, 0);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            dtRack.Rows.Add(false, objDs.Tables[0].Rows[i]["RackName"].ToString(), objDs.Tables[0].Rows[i]["RackCode"].ToString());
                        }
                        grdRack.DataSource = dtRack;
                        grdRack.Columns[0].Width = 50;
                        grdRack.Columns["Rack Name"].Width = 200;
                        grdRack.Columns["Rackcode"].Visible = false;
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
