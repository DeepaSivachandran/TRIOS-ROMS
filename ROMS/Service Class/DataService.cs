using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ROMS
{
    class DataService
    {
        public System.Data.SqlClient.SqlConnection ObjConn;
        public System.Data.SqlClient.SqlCommand objCmd;
        public System.Data.SqlClient.SqlDataAdapter objDA;
        public System.Data.SqlClient.SqlCommandBuilder objCB;
        public DataSet objDS;
        public DataTable ObjDT;
        SPCall tmpspcall = new SPCall();
        string strQuery;
        DataError objError;
        DataBind objbind = new DataBind();
        public DataService()
        {
            try
            {
                string connectstring = tmpspcall.connectionstring();
                ObjConn = new System.Data.SqlClient.SqlConnection(connectstring);
                if (ObjConn.State == ConnectionState.Closed)
                    ObjConn.Open();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public bool blnFindRecord(string strTableName, string strCondition)
        {
            bool blnString = false;
            try
            {
                tmpspcall = new SPCall();
                strQuery = "SELECT COUNT(*) FROM " + strTableName + " WHERE " + strCondition;
                objCmd = new System.Data.SqlClient.SqlCommand(strQuery, tmpspcall.objConn);
                if (Convert.ToInt32(objCmd.ExecuteScalar()) != 0)
                {
                    blnString = true;
                }
                else
                {
                    blnString = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return blnString;
        }
        public string ReplaceQuotes(string strValue)
        {
            strValue = strValue.Replace("'", "''");
            return strValue;
        }
        public void CloseConnection()
        {
            if ((ObjConn == null) == true)
                return;
            if (ObjConn.State == ConnectionState.Open)
                ObjConn.Close();
            ObjConn = null;
            objCmd = null;
            objCB = null;
            objDS = null;
            ObjDT = null;
        }
        public string displaydata(string strQuery)
        {
            string functionReturnValue = null;
            try
            {
                objCmd = new SqlCommand(strQuery, ObjConn);
                objDA = new SqlDataAdapter(strQuery, ObjConn);
                objDS = new DataSet();
                objDA.Fill(objDS);
                ObjDT = objDS.Tables[0];
                if (objDS.Tables[0].Rows.Count > 0)
                {
                    functionReturnValue = objDS.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    functionReturnValue = "";
                }
                if (functionReturnValue == null)
                    functionReturnValue = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return functionReturnValue;
        }
        public DataSet GetDataset(string strSQL)
        {
            tmpspcall = new SPCall();
            DataSet functionReturnValue = default(DataSet);
            objCmd = new System.Data.SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " + strSQL + " SET TRANSACTION ISOLATION LEVEL READ COMMITTED", ObjConn);
            objCmd.CommandText = strSQL;
            dynamic objDS = new DataSet();
            dynamic objDA = new System.Data.SqlClient.SqlDataAdapter(strSQL, tmpspcall.objConn);
            objDA.Fill(objDS);
            functionReturnValue = null;
            functionReturnValue = objDS;
            return functionReturnValue;
        }
        public void ExecuteQueryConnected(string strQry)
        {
            try
            {
                objCmd = new System.Data.SqlClient.SqlCommand(strQry, ObjConn);
                objCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public void FillDataSetSelectedField(string strTableName, string strCondition, string strCondition2)
        {
            try
            {
                strQuery = "SELECT " + strCondition2 + " FROM " + strTableName + " WHERE " + strCondition;
                objCmd = new System.Data.SqlClient.SqlCommand(strQuery, ObjConn);
                    objDA = new System.Data.SqlClient.SqlDataAdapter(strQuery, ObjConn);
                objDS = new DataSet();
                objDA.Fill(objDS, strTableName);
                ObjDT = objDS.Tables[strTableName];
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void ExecuteQuery(string strSQL)
        {
            //Dim con As New SqlConnection("Data Source=192.168.1.52;Initial Catalog=ssinventory;Uid=sa;pwd=12345")
            if (ObjConn.State == ConnectionState.Closed)
                ObjConn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = ObjConn;
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
        }
        
        public BindingSource udfnGridSearchFilter(DataGridView DGV_SearchGrid,DataGridView grdOutwardList)
        {
            DataValidation objValidation = new DataValidation();
            int i = 0;
            BindingSource bs = new BindingSource();
            if (DGV_SearchGrid.ColumnCount > 0)
            {
                bs.DataSource = grdOutwardList.DataSource;
                string filter = "";
                for (int j = 1; j < DGV_SearchGrid.ColumnCount; j++)
                {
                    if (Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) != "" && DGV_SearchGrid.Rows[i].Cells[j].ValueType.Name != "Image" && DGV_SearchGrid.Rows[i].Cells[j].ValueType.Name != "CheckBox")
                    {
                        if (filter != "") filter += "And ";
                        if (objValidation.FormatNumeric(Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value)))
                            //filter += "Convert([" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + "=" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value);
                            filter += "Convert([" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + ", System.String) LIKE '%" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
                        else
                            filter += "[" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + " LIKE '%" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
                    }
                }
                bs.Filter = filter;
                grdOutwardList.DataSource = bs;

       
            }
            return bs;
        }
        public BindingSource udfnGridSearchFilterStartWith(DataGridView DGV_SearchGrid, DataGridView grdOutwardList)
        {
            DataValidation objValidation = new DataValidation();
            int i = 0;
            BindingSource bs = new BindingSource();
            if (DGV_SearchGrid.ColumnCount > 0)
            {
                bs.DataSource = grdOutwardList.DataSource;
                string filter = "";
                for (int j = 1; j < DGV_SearchGrid.ColumnCount; j++)
                {
                    if (Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) != "" && DGV_SearchGrid.Rows[i].Cells[j].ValueType.Name != "Image" && DGV_SearchGrid.Rows[i].Cells[j].ValueType.Name != "CheckBox")
                    {
                        if (filter != "") filter += "And ";
                        if (objValidation.FormatNumeric(Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value)))
                            filter += "Convert([" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + ", System.String) LIKE '" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
                        else
                            filter += "[" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + " LIKE '" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
                    }
                }
                bs.Filter = filter;
                grdOutwardList.DataSource = bs;


            }
            return bs;
        }
        public BindingSource udfnreportGridSearchFilter(DataGridView GrdRMFGHeader, DataGridView GrdRMFGReport)
        {
            DataValidation objValidation = new DataValidation();
            int i = 0;
            BindingSource bs = new BindingSource();
            if (GrdRMFGHeader.ColumnCount > 0)
            {
                bs.DataSource = GrdRMFGReport.DataSource;
                string filter = "";
                for (int j = 1; j < GrdRMFGHeader.ColumnCount; j++)
                {
                    if (Convert.ToString(GrdRMFGHeader.Rows[i].Cells[j].Value) != "")
                    {
                        if (filter != "") filter += "And ";
                        if (objValidation.FormatNumeric(Convert.ToString(GrdRMFGHeader.Rows[i].Cells[j].Value)))
                            //filter += "Convert([" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + "=" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value);
                            filter += "Convert([" + GrdRMFGHeader.Columns[j].HeaderText.ToString() + "]" + ", System.String) LIKE '%" + Convert.ToString(GrdRMFGHeader.Rows[i].Cells[j].Value) + "%'";
                        else
                            filter += "[" + GrdRMFGHeader.Columns[j].HeaderText.ToString() + "]" + " LIKE '%" + Convert.ToString(GrdRMFGHeader.Rows[i].Cells[j].Value) + "%'";
                    }
                }
                bs.Filter = filter;
                GrdRMFGReport.DataSource = bs;


            }
            return bs;
        }
         
    }
}
