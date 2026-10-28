using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using ROMS.Model;

namespace ROMS
{
    public partial class CP_Product_Count : Form
    {

        private SecurityController _security;
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public CP_Product_Count()
        {
            InitializeComponent();
        }

        private void CP_Product_Count_Load(object sender, EventArgs e)
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
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdItemList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 110;
                objDs = objdserv.udfnproductmasterlist(objMR_Product);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdItemList.DataSource = objDs.Tables[0];

                            grdItemList.Columns["Particulars"].Width = 120;
                            grdItemList.Columns["Trading"].Width = 90;
                            grdItemList.Columns["Production RM"].Width = 90;
                            grdItemList.Columns["Production FG"].Width = 90;
                            grdItemList.Columns["Multi Rate Pro"].Width = 90;
                            grdItemList.Columns["Multi Rated Pro"].Width = 90;
                            grdItemList.Columns["Free"].Width = 80;
                            grdItemList.Columns["Trading"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Conversion Parent(Base)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Conversion Child(Bulk)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Production RM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Production FG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Multi Rate Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Multi Rated Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Free"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            // grdItemList.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdItemList.ClearSelection();
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
