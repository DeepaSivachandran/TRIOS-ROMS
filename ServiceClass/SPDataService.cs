using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NCOLabeling
{
    class SPDataService
    {
        DataError objError;

        SPCall tmpspcall = new SPCall();
        public System.Data.SqlClient.SqlConnection objConn;
        DataBind objbind = new DataBind();

        public SPDataService()
        {
            try
            {
                string connectstring = tmpspcall.connectionstring();
                objConn = new System.Data.SqlClient.SqlConnection(connectstring);
                if (objConn.State == ConnectionState.Closed)
                    objConn.Open();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public string spdbbackup(string path)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("SpDBbackup", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@path", path);
                varSqlCommand.CommandTimeout = 0;
                varSqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return "success";
        }
        public void CloseConnection()
        {
            if ((objConn == null) == true)
                return;
            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }     
        public int udfnExecuteQuery(string paraConnectedQuery)
        {
            int udfn = 0;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_DEF_ExecuteQuery", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraConnectedQuery", paraConnectedQuery);
                varSqlCommand.CommandTimeout = 0;
                varSqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return udfn;
        }
        public int udfnExecuteQuery2Parameter(string paraConnectedQuery1, string paraConnectedQuery2)
        {
            int udfn = 0;

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("SpExecuteQuery2Parameter", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@connectedQuery1", paraConnectedQuery1);
                varSqlCommand.Parameters.AddWithValue("@connectedQuery2", paraConnectedQuery2);
                varSqlCommand.CommandTimeout = 0;
                varSqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return udfn;
        }
        public int udfnExecuteQuery3Parameter(string paraConnectedQuery1, string paraConnectedQuery2, string paraConnectedQuery3)
        {
            int udfn = 0;

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("SpExecuteQuery3Parameter", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@connectedQuery1", paraConnectedQuery1);
                varSqlCommand.Parameters.AddWithValue("@connectedQuery2", paraConnectedQuery2);
                varSqlCommand.Parameters.AddWithValue("@connectedQuery3", paraConnectedQuery3);
                varSqlCommand.CommandTimeout = 0;
                varSqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return udfn;
        }       
        public DataSet udfnsubmenu(string process)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("SPSubMenu", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@Process", process);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;

        }
        public DataSet udfnGetSlNo(string paraTableName,string paraProcess,string paraColumnName, string paraColumnValue )
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_GETSLNO]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraTableName", paraTableName);
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraColumnName", paraColumnName);
                varSqlCommand.Parameters.AddWithValue("@paraColumnValue", paraColumnValue);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //DEEPA
        // 25-02-2020
        public string udfnRateChange(string paraProcess, int paraTransactionNo, DataTable paraRCDetails, string paraEntryDate, string paraOriginator,string paraFormtype)
        {
            // DataSet ds = new DataSet();
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_RATE_CHANGE]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionNo", paraTransactionNo);
                varSqlCommand.Parameters.AddWithValue("@paraRCDetails", paraRCDetails);
                varSqlCommand.Parameters.AddWithValue("@paraEntryDate", paraEntryDate);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraFormType", paraFormtype);
                varSqlCommand.CommandTimeout = 0;
                varResult = varSqlCommand.ExecuteScalar().ToString();
                return varResult;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                tmpspcall.CloseConnection();
            }

        }
        // DEEPA
        // 25-02-2020
        public DataSet udfnRateChangeList(string paraProcess, int paraTransactionNo, string paraFromDate, string paraToDate)
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_RATE_CHANGE_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionNo", paraTransactionNo);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        // DEEPA
        // 15-02-2020
        public DataSet udfnBindMenuList(string paraProcess, int paraUserRoleCode)
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_USERMENU_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraUserRoleCode", paraUserRoleCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        // Company SP
        public string udfnSPCompanyMaster(string paraprocess, string paracompanycode, string paracompanyname, string parashortname, string paraarea, string paracity, string paracontactnumber, string paraaltcontactnumber, string paraemail, string paragstin, string parafssaino, string paraplno, string parauserid,string paraipaddress, string paraoriginator,int parastatecode,string parapincode)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_COMPANY", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paracompanycode", paracompanycode);
                varSqlCommand.Parameters.AddWithValue("@paracompanyname", paracompanyname);
                varSqlCommand.Parameters.AddWithValue("@parashortname", parashortname);
                varSqlCommand.Parameters.AddWithValue("@paraArea", paraarea);
                varSqlCommand.Parameters.AddWithValue("@paracity", paracity);
                varSqlCommand.Parameters.AddWithValue("@paracontactnumber", paracontactnumber);
                varSqlCommand.Parameters.AddWithValue("@paraaltcontactnumber", paraaltcontactnumber);
                varSqlCommand.Parameters.AddWithValue("@paraemail", paraemail);
                varSqlCommand.Parameters.AddWithValue("@paragstin", paragstin);
                varSqlCommand.Parameters.AddWithValue("@parafssaino", parafssaino);
                varSqlCommand.Parameters.AddWithValue("@paraplno", paraplno);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraoriginator);
                varSqlCommand.Parameters.AddWithValue("@paraState", parastatecode);
                varSqlCommand.Parameters.AddWithValue("@paraPincode", parapincode);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        
        // Unit SP
        public string udfnSPUnitMaster(string paraprocess, string paraUnitCode, string paraUnitName, string paraSymbol, string paraNoOfDecimals, string parauserid,string paraipaddress, string paraoriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_UNIT", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraUnitCode", paraUnitCode);
                varSqlCommand.Parameters.AddWithValue("@paraUnitName", paraUnitName);
                varSqlCommand.Parameters.AddWithValue("@paraSymbol", paraSymbol);
                varSqlCommand.Parameters.AddWithValue("@paraNoOfDecimals", paraNoOfDecimals);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;
                result = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        
        // Brand SP
        public string udfnSPBrandMaster(string paraprocess, string paraBrandCode, string paraBTName, string paraBEName, string paraBTLabelName, string paraBELabelName, string parauserid,string paraipaddress, string paraoriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_BRAND", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraBrandCode", paraBrandCode);
                varSqlCommand.Parameters.AddWithValue("@paraBTName", paraBTName);
                varSqlCommand.Parameters.AddWithValue("@paraBEName", paraBEName);
                varSqlCommand.Parameters.AddWithValue("@paraBTLabelName", paraBTLabelName);
                varSqlCommand.Parameters.AddWithValue("@paraBELabelName", paraBELabelName);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;
                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        // Weight SP
        public string udfnSPWeightMaster(string paraprocess, string paraWeightCode, string paraWeightName, string paraSINO, string paraUnitCode, string parauserid,string paraipaddress, string paraoriginator, string paraweightinkg)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_WEIGHT", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraWeightCode", paraWeightCode);
                varSqlCommand.Parameters.AddWithValue("@paraWeightName", paraWeightName);
                varSqlCommand.Parameters.AddWithValue("@paraSINO", paraSINO);
                varSqlCommand.Parameters.AddWithValue("@paraUnitCode", paraUnitCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.Parameters.AddWithValue("@paraweightinkg", paraweightinkg);
                varSqlCommand.CommandTimeout = 0;
                result = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        // User SP
        public string udfnSPUserMaster(string paraprocess, string paraUserAutonum, string paraLoginID, string paraUserName, string paraUserRoleCode, string paraUserPassword, string paraStatusCode,string parauserid, string paraipaddress, string paraoriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_USER", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraUserAutonum", paraUserAutonum);
                varSqlCommand.Parameters.AddWithValue("@paraLoginID", paraLoginID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraUserName", paraUserName);
                varSqlCommand.Parameters.AddWithValue("@paraUserRoleCode", paraUserRoleCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserPassword", paraUserPassword);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        
        // Location SP
        public string udfnSPLocationMaster(string paraprocess, string paraLocationCode, string paraLocationName, string paraSINO,string parauserid, string paraipaddress, string paraoriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_LOCATION", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraLocationCode", paraLocationCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocationName", paraLocationName);
                varSqlCommand.Parameters.AddWithValue("@paraSINO", paraSINO);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }


        // PrinterSetting SP
        public string udfnSPPrinterSetting(DataTable paraPrinterSetting, string paraprocess, string paraSettingCode, string paraSystemname,  string parauserid, string paraipaddress, string paraoriginator) //string paraPaperSize, string paraPrinterTypeCode, string paraPrinterName, string paraStatusCode,
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_Printer_Setting", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPrinterSetting", paraPrinterSetting);
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraSettingCode", paraSettingCode);
                varSqlCommand.Parameters.AddWithValue("@paraSystemname", paraSystemname);
                //varSqlCommand.Parameters.AddWithValue("@paraPaperSize", paraPaperSize);
                //varSqlCommand.Parameters.AddWithValue("@paraPrinterTypeCode", paraPrinterTypeCode);
                //varSqlCommand.Parameters.AddWithValue("@paraPrinterName", paraPrinterName);
                //varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }


        public string udfnSPGroupMaster(string paraprocess, string paraGroupCode, string paraGroupTypeCode, string paraGTName, string paraGEName, string paraGTLabelName,string paraGELabelName, string paraSINO, string parauserid, string paraipaddress, string paraoriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_GROUP]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupTypeCode", paraGroupTypeCode);
                varSqlCommand.Parameters.AddWithValue("@paraGTName", paraGTName);
                varSqlCommand.Parameters.AddWithValue("@paraGEName", paraGEName);
                varSqlCommand.Parameters.AddWithValue("@paraGTLabelName", paraGTLabelName);
                varSqlCommand.Parameters.AddWithValue("@paraGELabelName", paraGELabelName);
                varSqlCommand.Parameters.AddWithValue("@paraSINO", paraSINO);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        public string udfnSPDesignationMaster(string paraprocess, string paraDesignationCode, string paraDesignationName,string parauserid, string paraipaddress, string paraoriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_DESIGNATION", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraDesignationCode", paraDesignationCode);
                varSqlCommand.Parameters.AddWithValue("@paraDesignationName", paraDesignationName);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;
                result = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        public string udfnSPStaffMaster(string paraprocess, string paraStaffCode, string paraStaffName, string paraDesignationCode, string paraStatusCode,string parauserid, string paraipaddress, string paraoriginator,string paraCompanyCode)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_STAFF", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraStaffCode", paraStaffCode);
                varSqlCommand.Parameters.AddWithValue("@paraStaffName", paraStaffName);
                varSqlCommand.Parameters.AddWithValue("@paraDesignationCode", paraDesignationCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        // Section SP
        public string udfnSPSectionMaster(string paraprocess, string paraSectionCode, string paraSectionName,string paraShortName, string paraTotalCapacity,string parauserid, string paraipaddress, string paraoriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_SECTION", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraSectionCode", paraSectionCode);
                varSqlCommand.Parameters.AddWithValue("@paraSectionName", paraSectionName);
                varSqlCommand.Parameters.AddWithValue("@paraTotalCapacity", paraTotalCapacity);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.Parameters.AddWithValue("@paraShortname", paraShortName);
                varSqlCommand.CommandTimeout = 0;
                result = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        // Settings SP
        public string udfnSPSetting(DataTable paraprocess, string paraPeriodCode,string parauserid, string paraipaddress, string paraoriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_GENERAL_SETTINGS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraGeneralSettings", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraPeriodCode", paraPeriodCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        // Change Password SP
        public string udfnSPChangePwd(string paraUserID, string paraOldPassword, string paranewpassword,string paraipaddress, string paraoriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_CHANGE_PASSWORD", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paranewpassword", paranewpassword);
                varSqlCommand.Parameters.AddWithValue("@paraOldPassword", paraOldPassword);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;
                result = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        // GET Invoiceno SP
        public string udfngetVoucherno(string paraModuleCode, string paraDate,int paraCompanyCode)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand cmd = new SqlCommand("[PROC_GET_VOUCHERNO]", tmpspcall.objConn);
                cmd.Parameters.AddWithValue("@paraModuleCode", paraModuleCode);
                cmd.Parameters.AddWithValue("@paraDate", paraDate);
                cmd.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                cmd.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                cmd.Parameters.AddWithValue("@paraIpAddress", MainForm.pbIpAddress);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@paraVoucherNo", SqlDbType.NVarChar, 50);
                cmd.Parameters["@paraVoucherNo"].Direction = ParameterDirection.Output;
                cmd.ExecuteScalar();
                result = cmd.Parameters["@paraVoucherNo"].Value.ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;

        }
        // Stock Inward
        public string udfnSPStockInward(string paraGrptype , DataTable paraStockInward, string paraCompanyCode, string paraProcess, string paraTransactionno, string parainwardno, string parainwardDate, string paraserialno,string paragrouptypecode, string parareasoncode, string paraplantransactionno, string pararemarks, string paraUserID, string paraIPAddress, string paraOriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_STOCK_INWARD", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraGrptype", paraGrptype);
                varSqlCommand.Parameters.AddWithValue("@paraStockInward", paraStockInward);
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionno", paraTransactionno);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@parainwardno", parainwardno);
                varSqlCommand.Parameters.AddWithValue("@parainwardDate", parainwardDate);
                varSqlCommand.Parameters.AddWithValue("@paraserialno", paraserialno);
                varSqlCommand.Parameters.AddWithValue("@paragrouptypecode", paragrouptypecode);
                varSqlCommand.Parameters.AddWithValue("@parareasoncode", parareasoncode);
                varSqlCommand.Parameters.AddWithValue("@paraplantransactionno", paraplantransactionno);
                varSqlCommand.Parameters.AddWithValue("@pararemarks", pararemarks);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                result = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }

       
        public DataSet udfnSPStockTransfer(DataTable paraStockInward,string paraCompanyCode, string paraProcess, string paraTransactionno, string paraoutwardno, string paraoutwardDate, string paraserialno,string paragrouptypecode, string pararemarks, string paraUserID, string paraIPAddress, string paraOriginator)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_STOCK_Transfer", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraStockInward", paraStockInward);
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionno", paraTransactionno);
                varSqlCommand.Parameters.AddWithValue("@paraoutwardno", paraoutwardno);
                varSqlCommand.Parameters.AddWithValue("@paraoutwardDate", paraoutwardDate);
                varSqlCommand.Parameters.AddWithValue("@paraserialno", paraserialno);
                varSqlCommand.Parameters.AddWithValue("@paragrouptypecode", paragrouptypecode);
                varSqlCommand.Parameters.AddWithValue("@pararemarks", pararemarks);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        // Raw Material SP
        public string udfnSPRawMaterialMaster(string paraProcess, string paraRMCode, string paraGroupCode, string paraRMTName, string paraRMEName, string paraRMTLabelName, string paraRMELabelName, string paraRMType, string paraSINO, string paraUnitCode, string paraCompanyCode, string paraMRPOffsetPer, string paraValueCode, string paraStatusCode, string parauserid, string paraipaddress, string paraoriginator, int paraPremiumQltyCode, int paraPremiumRMCode, int paradefloc, int paraWgtPerCode, int paraUnitPerCode, int paraRMSQ, int paraFMSQ, int paraFG, double paraRatePerKg, string Purchaseincharge)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_RAWMATERIAL", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMTName", paraRMTName);
                varSqlCommand.Parameters.AddWithValue("@paraRMEName", paraRMEName);
                varSqlCommand.Parameters.AddWithValue("@paraRMTLabelName", paraRMTLabelName);
                varSqlCommand.Parameters.AddWithValue("@paraRMELabelName", paraRMELabelName);
                varSqlCommand.Parameters.AddWithValue("@paraSINO", paraSINO);
                varSqlCommand.Parameters.AddWithValue("@paraUnitCode", paraUnitCode);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraMRPOffsetPer", paraMRPOffsetPer);
                varSqlCommand.Parameters.AddWithValue("@paraValueCode", paraValueCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.Parameters.AddWithValue("@paraPremiumQltyCode", paraPremiumQltyCode);
                varSqlCommand.Parameters.AddWithValue("@paraPremiumRMCode", paraPremiumRMCode);
                varSqlCommand.Parameters.AddWithValue("@paradefloc", paradefloc);
                varSqlCommand.Parameters.AddWithValue("@paraWgtPerCode", paraWgtPerCode);
                varSqlCommand.Parameters.AddWithValue("@paraUnitPerCode", paraUnitPerCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMSQ", paraRMSQ);
                varSqlCommand.Parameters.AddWithValue("@paraFMSQ", paraFMSQ);
                varSqlCommand.Parameters.AddWithValue("@paraFG", paraFG);
                varSqlCommand.Parameters.AddWithValue("@paraRatePerKg", paraRatePerKg);
                varSqlCommand.Parameters.AddWithValue("@paraRMType", paraRMType);
                varSqlCommand.Parameters.AddWithValue("@Purchaseinchargecode", Purchaseincharge);
                varSqlCommand.CommandTimeout = 0;
                result = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        //Stock Inward list
        public DataSet udfnSPStockinwardList(string paraprocess, string paratransactionno, string parafromdate, string paratodate, string paraproductcode, string parauserid, string paraipaddress,string paraCompany,string paraGroupType,string paratype,string PARAREASONCODE)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_STOCKINWARD_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paratransactionno", paratransactionno);
                varSqlCommand.Parameters.AddWithValue("@parafromdate", parafromdate);
                varSqlCommand.Parameters.AddWithValue("@paratodate", paratodate);
                varSqlCommand.Parameters.AddWithValue("@paraproductcode", paraproductcode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupType", paraGroupType);
                varSqlCommand.Parameters.AddWithValue("@paratype", paratype);
                varSqlCommand.Parameters.AddWithValue("@PARAREASONCODE", PARAREASONCODE);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnSPStockOutward(DataTable paraStockInward, string paraCompanyCode, string paraProcess, string paraTransactionno, string paraoutwardno, string paraoutwardDate, string paraserialno, string paragrouptypecode, string pararemarks, string paraToSupply, string paraUserID, string paraIPAddress, string paraOriginator)
        {

            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_STOCK_OUTWARD", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraStockInward", paraStockInward);
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionno", paraTransactionno);
                varSqlCommand.Parameters.AddWithValue("@paraoutwardno", paraoutwardno);
                varSqlCommand.Parameters.AddWithValue("@paraoutwardDate", paraoutwardDate);
                varSqlCommand.Parameters.AddWithValue("@paraserialno", paraserialno);
                varSqlCommand.Parameters.AddWithValue("@paragrouptypecode", paragrouptypecode);
                varSqlCommand.Parameters.AddWithValue("@pararemarks", pararemarks);
                varSqlCommand.Parameters.AddWithValue("@paraToSupply", paraToSupply);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnSPStockoutwardList(string paraprocess, string paratransactionno, string parafromdate, string paratodate, string paraproductcode, string parauserid, string paraipaddress, string paraCompany, string paraGroupType,string paratype)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_STOCKOUTWARD_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paratransactionno", paratransactionno);
                varSqlCommand.Parameters.AddWithValue("@parafromdate", parafromdate);
                varSqlCommand.Parameters.AddWithValue("@paratodate", paratodate);
                varSqlCommand.Parameters.AddWithValue("@paraproductcode", paraproductcode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupType", paraGroupType);
                varSqlCommand.Parameters.AddWithValue("@paratype", paratype);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnSPStockTransferList(string paraprocess, string paratransactionno, string parafromdate, string paratodate, string paraproductcode, string parauserid, string paraipaddress, string paraCompany, string paraGroupType,string paratype)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_STOCKTransfer_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paratransactionno", paratransactionno);
                varSqlCommand.Parameters.AddWithValue("@parafromdate", parafromdate);
                varSqlCommand.Parameters.AddWithValue("@paratodate", paratodate);
                varSqlCommand.Parameters.AddWithValue("@paraproductcode", paraproductcode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupType", paraGroupType);
                varSqlCommand.Parameters.AddWithValue("@paratype", paratype);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //Raw Material list
        public DataSet udfnSPRawMaterialList(string paraPremQltyCode,string paraOffsetStatusCode, string paraprocess, string paraRMCode, string paraGroupCode, string paraCompanyCode,string paraStatusCode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_RAWMATERIAL_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraPremQltyCode", paraPremQltyCode);
                varSqlCommand.Parameters.AddWithValue("@paraOffsetStatusCode", paraOffsetStatusCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //Section list
        public DataSet udfnSPSectionList(string paraprocess, string paraSectionCode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_SECTION_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraSectionCode", paraSectionCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //Staff list
        public DataSet udfnSPStaffList(string paraprocess, string paraStaffCode, string parauserid, string paraipaddress,int paraCompanyCode,int parastatus)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_STAFF_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraStaffCode", paraStaffCode);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@parastatus", parastatus);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //Designation list
        public DataSet udfnSPDesignationList(string paraprocess, string paraDesignationCode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_DESIGNATION_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraDesignationCode", paraDesignationCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //company list
        public DataSet udfnSPCompanyList(string paraprocess, string paracompanycode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_COMPANY_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paracompanycode", paracompanycode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //unit list
        public DataSet udfnSPUnitList(string paraprocess, string paraunitcode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_UNIT_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraunitcode", paraunitcode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //brand list
        public DataSet udfnSPBrandList(string paraprocess, string paraBrandCode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_BRAND_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraBrandCode", paraBrandCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //Weight list
        public DataSet udfnSPWeightList(string paraprocess, string paraweightCode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_WEIGHT_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraweightCode", paraweightCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //User list
        public DataSet udfnSPUserList(string paraprocess, string paraEditUserID, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_USER_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraUserAutonum", paraEditUserID);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);              
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //Location list
        public DataSet udfnSPLocationList(string paraprocess, string paraLocationCode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_LOCATION_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraLocationCode", paraLocationCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //Group list
        public DataSet udfnSPGroupList(string paraprocess, string paraGroupCode, string paraGroupTypeCode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_GROUP_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupTypeCode", paraGroupTypeCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //Group list
        public DataSet udfnSPPrinterSettingList(string paraprocess, string paraSettingCode, string paraSystemname, string paraPaperSize, string paraPrinterTypeCode, string paraPrinterName, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PRINTER_SETTING_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraSettingCode", paraSettingCode);
                varSqlCommand.Parameters.AddWithValue("@paraSystemname", paraSystemname);
                varSqlCommand.Parameters.AddWithValue("@paraPaperSize", paraPaperSize);
                varSqlCommand.Parameters.AddWithValue("@paraPrinterTypeCode", paraPrinterTypeCode);
                varSqlCommand.Parameters.AddWithValue("@paraPrinterName", paraPrinterName);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //Setting list
        public DataSet udfnSPSettingList(string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_GENERALSETTING_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //DEEPA
        // 15-02-2020
        public string udfnFinishedGoods(string paraProcess, int paraFGCode, int paraAutoUpdate, int paraFGTypeCode, string paraPICode, int paraSINO, string paraPTName, string paraPEName, string paraPTLabelName, string paraPELabelName, int paraUnitCode, int paraGroupCode, int paraRMCode, int paraBrandCode, int paraCompanyCode, double paraMOQ, double paraShelfLife, int paraPeriodCode, double paraRetailsSalesRate, int paraMRPOffsetValueCode, double paraMRPOffsetPer, double paraMRPOffsetValue, double paraMRPRate, int paraBatchValueCode, int paraBCEnableValueCode, int paraBCGenerationValueCode, string paraManualBarcode, int paraStatusCode, string paraOriginator, string paraPLCode, string paraILCode, string paraOLCode, string paraTokenCode, int paraWeightCode, int paraBulkUnitCode, int paraUPP, int paraRetailFGCode, int paraILQty, int paraOLQty, int paraTokenQty, int paraDefLoc, int paraRMSQ, int paraLabelEnableCode)
        {
            // DataSet ds = new DataSet();
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_FINISHEDGOODS]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraAutoUpdate", paraAutoUpdate);
                varSqlCommand.Parameters.AddWithValue("@paraFGTypeCode", paraFGTypeCode);
                varSqlCommand.Parameters.AddWithValue("@paraPICode", paraPICode);
                varSqlCommand.Parameters.AddWithValue("@paraSINO", paraSINO);
                varSqlCommand.Parameters.AddWithValue("@paraPTName", paraPTName);
                varSqlCommand.Parameters.AddWithValue("@paraPEName", paraPEName);
                varSqlCommand.Parameters.AddWithValue("@paraPTLabelName", paraPTLabelName);
                varSqlCommand.Parameters.AddWithValue("@paraPELabelName", paraPELabelName);
                varSqlCommand.Parameters.AddWithValue("@paraUnitCode", paraUnitCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraBrandCode", paraBrandCode);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraMOQ", paraMOQ);
                varSqlCommand.Parameters.AddWithValue("@paraShelfLife", paraShelfLife);
                varSqlCommand.Parameters.AddWithValue("@paraPeriodCode", paraPeriodCode);
                varSqlCommand.Parameters.AddWithValue("@paraRetailsSalesRate", paraRetailsSalesRate);
                varSqlCommand.Parameters.AddWithValue("@paraMRPOffsetValueCode", paraMRPOffsetValueCode);
                varSqlCommand.Parameters.AddWithValue("@paraMRPOffsetPer", paraMRPOffsetPer);
                varSqlCommand.Parameters.AddWithValue("@paraMRPOffsetValue", paraMRPOffsetValue);
                varSqlCommand.Parameters.AddWithValue("@paraMRPRate", paraMRPRate);
                varSqlCommand.Parameters.AddWithValue("@paraBatchValueCode", paraBatchValueCode);
                varSqlCommand.Parameters.AddWithValue("@paraBCEnableValueCode", paraBCEnableValueCode);
                varSqlCommand.Parameters.AddWithValue("@paraBCGenerationValueCode", paraBCGenerationValueCode);
                varSqlCommand.Parameters.AddWithValue("@paraManualBarcode", paraManualBarcode);
                varSqlCommand.Parameters.AddWithValue("@paraAutoBarCode", paraManualBarcode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraPLCode", paraPLCode);
                varSqlCommand.Parameters.AddWithValue("@paraILCode", paraILCode);
                varSqlCommand.Parameters.AddWithValue("@paraOLCode", paraOLCode);
                varSqlCommand.Parameters.AddWithValue("@paraTokenCode", paraTokenCode);
                varSqlCommand.Parameters.AddWithValue("@paraWeightCode", paraWeightCode);
                varSqlCommand.Parameters.AddWithValue("@paraBulkUnitCode", paraBulkUnitCode);
                varSqlCommand.Parameters.AddWithValue("@paraUPP", paraUPP);
                varSqlCommand.Parameters.AddWithValue("@paraRetailFGCode", paraRetailFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraILQty", paraILQty);
                varSqlCommand.Parameters.AddWithValue("@paraOLQty", paraOLQty);
                varSqlCommand.Parameters.AddWithValue("@paraTokenQty", paraTokenQty);
                varSqlCommand.Parameters.AddWithValue("@paraDefLoc", paraDefLoc);
                varSqlCommand.Parameters.AddWithValue("@paraRMSQ", paraRMSQ);
                varSqlCommand.Parameters.AddWithValue("@paraLabelEnableCode", paraLabelEnableCode);

                varSqlCommand.CommandTimeout = 0;
                varResult = varSqlCommand.ExecuteScalar().ToString();
                return varResult;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                tmpspcall.CloseConnection();
            }

        }
        //Plan Print List
        public DataSet udfnPlanPrint(string paraPlanDate, string parauserid, string paraipaddress,int paracompanycode)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_PRINT]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paracompanycode", paracompanycode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        // DEEPA
        // 16-02-2020
        public DataSet udfnFinishedGoodsList(string paraProcess,int paraFGCode, int paraGroupCode, int paraBrandCode, int paraBatchTypeCode, string paraLabelSize, int paraRMCode, int paraBarcodeType, int paraStatusCode,int paraCompanyCode,int paraAutoUpdate,int paraUpdateStatus,int paraweightcode,int paralocationcode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_FINISHEDGOODS_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraBrandCode", paraBrandCode);
                varSqlCommand.Parameters.AddWithValue("@paraBatchTypeCode", paraBatchTypeCode);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraLabelSize", paraLabelSize);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraBarcodeType", paraBarcodeType);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraAutoUpdate", paraAutoUpdate);
                varSqlCommand.Parameters.AddWithValue("@paraUpdateStatus", paraUpdateStatus);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraweightcode", paraweightcode);
                varSqlCommand.Parameters.AddWithValue("@PARAlocationcode", paralocationcode);
                
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        // DEEPA
        // 16-02-2020
        public DataSet udfnGetStaffAllocationDetails(string paraPlanDate,string paraPlanNo)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_ALLOCATEDDETAILS]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfndashboard(string paraPlanDate)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_DASHBOARD]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfndashboardlabeldetails()
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_DASHBOARD_label_details]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }


        
        public DataSet udfndashboardReport(string paraPlanDate)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_DASHBOARD_Req_Pending]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                 
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        // DEEPA
        // 16-02-2020
        public DataSet udfnGetPlanRawDetails(string formmode,string paraCompanyCode,string paraPlanNo,string paraPlanDate)
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_RAWDETAILS]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraformmode", formmode);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        // DEEPA
        // 16-02-2020
        public DataSet udfnGetPlanStockDetails(string paraPlanDate,string paraRMName,string paraPlanNo,string paraCompanyCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_GETSTOCK]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraRMName", paraRMName);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }


        //DEEPA
        // 15-02-2020
        public string udfnProductionPlan(string paraProcess,DataTable paraFGDetails, DataTable paraRMDetails, int paraTransactionNo, string paraPlanNo, string paraPlanDate, int paraCompanyCode, string paraOriginator)

        {
            // DataSet ds = new DataSet();
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraFGDetails", paraFGDetails);
                varSqlCommand.Parameters.AddWithValue("@paraRMDetails", paraRMDetails);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionNo", paraTransactionNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraSystemName", MainForm.pbHostName);
                varSqlCommand.CommandTimeout = 0;
                varResult = varSqlCommand.ExecuteScalar().ToString();
                return varResult;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                tmpspcall.CloseConnection();
            }

        }

        // DEEPA
        // 18-02-2020
        public DataSet udfnPlanList(string paraProcess,int paraTransactionNo, string paraPlanNo, string paraFromDate, string paraToDate,int paraRMCode, int paraStatusCode,int paraComopanyCode,int pararequest)
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionNo", paraTransactionNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraComopanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@pararequest", pararequest);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //Staff Allocation in Loading
        public DataSet udfnBindStaffAllocationOnLoad(string paraPlanDate)
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_STAFFALLOCATION_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //Staff Allocation - Save
        public string udfnSaveStaffAllocation(DataTable paraStafffAllocation, string paraAllocationDate, string paraOriginator)
        {
            string varresult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_STAFFALLOCATION]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraStaffAllocation", paraStafffAllocation);
                varSqlCommand.Parameters.AddWithValue("@paraAllocationDate", paraAllocationDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.CommandTimeout = 0;
                varresult = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return varresult;
        }
        //Get Current DAte
        public string udfnGetCurrentDate()
        {
            string varResult = "";

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_GET_CURRENTDATE]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                varResult = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return varResult;
        }

        //Pending Plan List
        public DataSet udfnBindPlanNo(string paraPlanDate)
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PENDING_PLAN]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //Plan Approval in Loading
        public DataSet udfnBindPlanPackedDetails(string paraTransactionNo)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_PACKED_DETAILS]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraTransactionNo", paraTransactionNo);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //Plan Approval - Save
        public string udfnSavePlanApproval(string paraProcess, DataTable paraPADetails, DataTable paraPAFGDetails, DataTable paraPARMDetails, string paraPlanTransactionDate, int paraPlanTransactionNo, string paraPlanNo, string paraOriginator, DataTable paraApprovaltransferDetails)
        {
            string varresult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_APPROVAL]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraPADetails", paraPADetails);
                varSqlCommand.Parameters.AddWithValue("@paraPAFGDetails", paraPAFGDetails);
                varSqlCommand.Parameters.AddWithValue("@paraPARMDetails", paraPARMDetails);
                varSqlCommand.Parameters.AddWithValue("@paraPlanTransactionDate", paraPlanTransactionDate);
                varSqlCommand.Parameters.AddWithValue("@paraPlanTransactionNo", paraPlanTransactionNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraApprovaltransferDetails", paraApprovaltransferDetails);
                varSqlCommand.CommandTimeout = 0;
                varresult = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return varresult;
        }


        //Plan approval in Loading
        public DataSet udfnBindPlanApprovalList(string paraFromDate, string paraToDate, int paraCompanyCode, int paraStatusCode, int paraRMCode, int paraFGCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_APPROVAL_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //Plan approval in Loading
        public DataSet udfnBindPAAutoComplete(string paraMaster, string paraSearchText, string paraFromDate, string paraToDate, int paraCompanyCode, int paraRMCode)
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PA_AUTOCOMPLETE]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraMaster", paraMaster);
                varSqlCommand.Parameters.AddWithValue("@paraSearchText", paraSearchText);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        public DataSet udfnRateApprovalList(string paraDate,string paraProductType,string paraStatus)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_RATE_APPROVAL_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraDate", paraDate);
                varSqlCommand.Parameters.AddWithValue("@paraProductType", paraProductType);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", paraStatus);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }



        //Rate Approval - Save
        public string udfnSaveRateApproval(DataTable paraRADetails, string paraOriginator)
        {
            string varresult = "";

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_RATE_APPROVAL]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraRADetails", paraRADetails);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.CommandTimeout = 0;
                varresult = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return varresult;
        }


        public string udfn_ROMS()
        {
            string varresult = "";

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_GET_FGLIST_ROMS]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.CommandTimeout = 0;
                varresult = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                varresult = ex.ErrorCode.ToString();
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return varresult;
        }
        public string udfn_JOB()
        {
            string varresult = "";

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_RATE_APPROVAL_JOB]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.CommandTimeout = 0;
                varresult = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

                varresult = ex.ErrorCode.ToString();

                //varresult = ex.ErrorCode.ToString();
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return varresult;
        }

        //Bind Menu List
        public DataSet udfnBindUserMenuList(int paraUserRoleCode)
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_MENU_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserRoleCode", paraUserRoleCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //User Role - Save
        public string udfnSaveUserRole(string paraProcess, DataTable paraURDetails, string paraUserRole, int paraUserRoleCode, string paraOriginator)
        {
            string varresult = "";

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_USERROLE]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraURDetails", paraURDetails);
                varSqlCommand.Parameters.AddWithValue("@paraUserRole", paraUserRole);
                varSqlCommand.Parameters.AddWithValue("@paraUserRoleCode", paraUserRoleCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.CommandTimeout = 0;
                varresult = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return varresult;
        }
        public DataSet udfnPlanPrintList(string paraPlanDate, string paratransactionno, string parauserid, string paraipaddress,int paraSectioncode)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PLAN_PRINT_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paratransactionno", paratransactionno);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraSectioncode", paraSectioncode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public string udfnGETLPRPTName(int paraFGCode, int paraLabelTypeCode)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_GET_LABELPRINTNAME", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLabelTypeCode", paraLabelTypeCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        public string udfnPlanPrintCreate(string paraPlanTransactionno, string paraPlanNo, string paraplandate, string parafgcode,string paraBatchno, string paraBarcode, string paraPLStatuscode, string paraILStatuscode, string paraOLStatuscode, string paraTokenStatuscode, float paramrprate,   string parauserid, string paraipaddress, string paraoriginator,int paraQty,int paraprintedqty,int paralabeltype)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_LABELPRINTING_CREATE", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanTransactionno", paraPlanTransactionno);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraplandate", paraplandate);
                varSqlCommand.Parameters.AddWithValue("@parafgcode", parafgcode);
                varSqlCommand.Parameters.AddWithValue("@paraBatchno", paraBatchno);
                varSqlCommand.Parameters.AddWithValue("@paraBarcode", paraBarcode);
                varSqlCommand.Parameters.AddWithValue("@paraPLStatuscode", paraPLStatuscode);
                varSqlCommand.Parameters.AddWithValue("@paraILStatuscode", paraILStatuscode);
                varSqlCommand.Parameters.AddWithValue("@paraOLStatuscode", paraOLStatuscode);
                varSqlCommand.Parameters.AddWithValue("@paraTokenStatuscode", paraTokenStatuscode);
                varSqlCommand.Parameters.AddWithValue("@paramrprate", paramrprate);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.Parameters.AddWithValue("@paraQty", paraQty);
                varSqlCommand.Parameters.AddWithValue("@paraprintedqty", paraprintedqty);
                varSqlCommand.Parameters.AddWithValue("@paralabeltype", paralabeltype);
                varSqlCommand.CommandTimeout = 0;
                result = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        public DataSet udfnBindUserRoleList(string paraProcess, string paraUserRoleCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_USERROLE_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraUserRoleCode", paraUserRoleCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnStockRawMaterial(int paraCompCode, int paraGroupCode,int paraRMCode, int paraLocation, int paraType, int paraReportType,int paraIndividualPrint,int paraExport,string paraUserID,string paraIPAddress,int parainstk,int parazerostock,int paraNegativeStk,int paraWIPStk,int paraAllStk,int mainlocation)
        {
            DataSet ds = new DataSet();
            try
            {
               

                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RAWMATERIAL", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraIndividualPrint", paraIndividualPrint);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@parainstk", parainstk);
                varSqlCommand.Parameters.AddWithValue("@parazerostock", parazerostock);
                varSqlCommand.Parameters.AddWithValue("@paraNegativeStk", paraNegativeStk);
                varSqlCommand.Parameters.AddWithValue("@paraWIPStk", paraWIPStk);
                varSqlCommand.Parameters.AddWithValue("@paraAllStk", paraAllStk);
                varSqlCommand.Parameters.AddWithValue("@mainlocation", mainlocation); 
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
      

        public DataSet udfnStockRawMaterialnew(int paraCompCode, int paraGroupCode, int paraRMCode, int paraLocation, string paraUserID, string paraIPAddress, int parainstk, int parazerostock, int paraAllStk, int paraNegativeStk, int paraWIPStk,int mainlocation)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RAWMATERIAL_NEW", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@parainstk", parainstk);
                varSqlCommand.Parameters.AddWithValue("@parazerostock", parazerostock);
                varSqlCommand.Parameters.AddWithValue("@paraNegativeStk", paraNegativeStk);
                varSqlCommand.Parameters.AddWithValue("@paraAllStk", paraAllStk);
                varSqlCommand.Parameters.AddWithValue("@paraWIPStk", paraWIPStk);
                varSqlCommand.Parameters.AddWithValue("@mainlocation", mainlocation);
                varSqlCommand.CommandTimeout = 0; 
                 SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        public DataSet udfnStockRawMaterialshoratgestock(int paraCompCode, int paraGroupCode, int paraRMCode, int paraLocation, string paraUserID, string paraIPAddress, int parainstk, int parazerostock, int paraAllStk, int paraNegativeStk, int paraWIPStk,string paraExport,int mainlocation)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_SHORTAGE_STOCK_RAWMATERIAL", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@parainstk", parainstk);
                varSqlCommand.Parameters.AddWithValue("@parazerostock", parazerostock);
                varSqlCommand.Parameters.AddWithValue("@paraNegativeStk", paraNegativeStk);
                varSqlCommand.Parameters.AddWithValue("@paraAllStk", paraAllStk);
                varSqlCommand.Parameters.AddWithValue("@paraWIPStk", paraWIPStk); 
               varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
                varSqlCommand.Parameters.AddWithValue("@mainlocation", mainlocation); 
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }


        public DataSet udfnStockFG(int paraLocationCode, int paraGroupCode, int paraLocationGroup, int paraTransNoGroup, int paraCompanyGroup, int paraGroupGroup, int paraRMGroup, int paraBatchNoGroup, int paraMRPGroup,int parazerostock)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_REPORT_STOCK_FG]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraLocationCode", paraLocationCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocationGroup", paraLocationGroup);
                varSqlCommand.Parameters.AddWithValue("@paraTransNoGroup", paraTransNoGroup);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyGroup", paraCompanyGroup);
                varSqlCommand.Parameters.AddWithValue("@paraGroupGroup", paraGroupGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRMGroup", paraRMGroup);
                varSqlCommand.Parameters.AddWithValue("@paraBatchNoGroup", paraBatchNoGroup);
                varSqlCommand.Parameters.AddWithValue("@paraMRPGroup", paraMRPGroup);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@parazerostock", parazerostock);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public string udfnDirectPrint(int paraFGCode, string paraBatchNo,int paraSectionCode)
        {
            string result = "";

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_PLAN_DIRECTPRINT", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraBatchNo", paraBatchNo);
                varSqlCommand.Parameters.AddWithValue("@paraSectionCode", paraSectionCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }

        // VENGATESH P
        // 17-08-2020
        public DataSet udfnGetGoods_Outward_StockDetails(int paraGroupTypeCode, string paraCode, string paraDate, string paraCompanyCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_GOODSOUTWARD_GET_STOCK]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraGroupTypeCode", paraGroupTypeCode);
                varSqlCommand.Parameters.AddWithValue("@paraCode", paraCode);
                varSqlCommand.Parameters.AddWithValue("@paraDate", paraDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public string udfnGETLPRPTSize(int paraFGCode, int paraLabelTypeCode)
        {
            string result = "";

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_GET_LABELPRINTERSIZE", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLabelTypeCode", paraLabelTypeCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }


        public DataSet UdfnStockReportRM(string paraCompanyCode, int paraGroupCode, int paraRMCode, int paraLocationCode, int paraType, int paraReportType, int paraExport, int paraIndividualPrint, int parazerostock, int parainstk, int paraNegativeStk, int paraWIPStk, int paraAllStk,int mainlocationcode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RAWMATERIAL", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocationCode);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
                varSqlCommand.Parameters.AddWithValue("@paraIndividualPrint", paraIndividualPrint);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@parazerostock", parazerostock);
                varSqlCommand.Parameters.AddWithValue("@parainstk", parainstk);
                varSqlCommand.Parameters.AddWithValue("@paraNegativeStk", paraNegativeStk);
                varSqlCommand.Parameters.AddWithValue("@paraWIPStk", paraWIPStk);
                varSqlCommand.Parameters.AddWithValue("@paraAllStk", paraAllStk);
                varSqlCommand.Parameters.AddWithValue("@mainlocation", mainlocationcode); 
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
    


        public DataSet udfnstockrmtally(int paraCompCode, int paraGroupCode, int paraRMCode, int paraLocation, string paraUserID, string paraIPAddress, int parainstk, int parazerostock, int paraAllStk, int paraNegativeStk, int paraWIPStk,string paraExport)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RAWMATERIAL_TALLY", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@parainstk", parainstk);
                varSqlCommand.Parameters.AddWithValue("@parazerostock", parazerostock);
                varSqlCommand.Parameters.AddWithValue("@paraNegativeStk", paraNegativeStk);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
                varSqlCommand.Parameters.AddWithValue("@paraAllStk", paraAllStk);
                varSqlCommand.Parameters.AddWithValue("@paraWIPStk", paraWIPStk);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnreportrmtally(string paraCompanyCode, int paraGroupCode, int paraRMCode, int paraLocationCode, int paraExport, int parazerostock, int parainstk, int paraNegativeStk, int paraWIPStk, int paraAllStk)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RAWMATERIAL_TALLY", tmpspcall.objConn);  
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocationCode);
              //  varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
              //  varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
               // varSqlCommand.Parameters.AddWithValue("@paraIndividualPrint", paraIndividualPrint);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@parazerostock", parazerostock);
                varSqlCommand.Parameters.AddWithValue("@parainstk", parainstk);
                varSqlCommand.Parameters.AddWithValue("@paraNegativeStk", paraNegativeStk);
                varSqlCommand.Parameters.AddWithValue("@paraWIPStk", paraWIPStk);
                varSqlCommand.Parameters.AddWithValue("@paraAllStk", paraAllStk);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        public DataSet UdfnStockReportFG(string paraCompanyCode, int paraGroupCode, int paraRMCode, int paraFGCode, int paraLocationCode, int paraType, int paraReportType, int paraExport, int paraIndividualPrint,int paraAll,int paraINstk, int parazerostock,int paraNegative,string paraDOP)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_REPORT_STOCK_FG]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocationCode);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
                varSqlCommand.Parameters.AddWithValue("@paraIndividualPrint", paraIndividualPrint);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraAll", paraAll);
                varSqlCommand.Parameters.AddWithValue("@paraINstk", paraINstk);
                varSqlCommand.Parameters.AddWithValue("@parazerostock", parazerostock);
                varSqlCommand.Parameters.AddWithValue("@paraNegative", paraNegative); 

                varSqlCommand.Parameters.AddWithValue("@paraDOP", paraDOP);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }


        public DataSet UdfnStockReportFGTally(string paraCompanyCode, int paraGroupCode, int paraRMCode, int paraFGCode, int paraLocationCode, int paraType, int paraReportType, int paraExport, int paraIndividualPrint, int paraAll, int paraINstk, int parazerostock, int paraNegative)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_REPORT_STOCK_FG_STOCK_TALLY]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocationCode);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
                varSqlCommand.Parameters.AddWithValue("@paraIndividualPrint", paraIndividualPrint);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraAll", paraAll);
                varSqlCommand.Parameters.AddWithValue("@paraINstk", paraINstk);
                varSqlCommand.Parameters.AddWithValue("@parazerostock", parazerostock);
                varSqlCommand.Parameters.AddWithValue("@paraNegative", paraNegative);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }



        public DataSet  UdfnStockReportFG_Valuation(string paraCompanyCode, int paraGroupCode, int paraRMCode, int paraFGCode, int paraLocationCode, int paraType, int paraReportType, int paraExport, int paraIndividualPrint)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_REPORT_STOCK_FG_Valuation]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocationCode);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
                varSqlCommand.Parameters.AddWithValue("@paraIndividualPrint", paraIndividualPrint);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet UdfnStockReportRMFG_Valuation(string paraCompanyCode, int paraGroupCode, int paraRMCode, int paraFGCode, int paraLocationCode, int paraType, string paraReportType,string paraexport)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_REPORT_STOCK_RMFG_Valuation]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocationCode);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);

                varSqlCommand.Parameters.AddWithValue("@paraexport", paraexport);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet UdfnStockReportFG_Validity(string paraCompanyCode, int paraGroupCode, int paraRMCode, int paraFGCode, int paraLocation, int paraType, int paraReportType, int paraExport, int paraIndividualPrint,string paraNoofDay,int paraExpired)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_REPORT_STOCK_FG_Validity]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
                varSqlCommand.Parameters.AddWithValue("@paraIndividualPrint", paraIndividualPrint);
                varSqlCommand.Parameters.AddWithValue("@paraNoofDay", paraNoofDay);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraExpired", paraExpired);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public string udfnProductionPlanTransfer(string paraProcess, DataTable paraTranDetails, int paraTransactionNo, int paraProdTransactionNo, string paraPlanNo, string paraPlanDate, int paraCompanyCode, string paraOriginator)
        {
            // DataSet ds = new DataSet();
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PROD_PLAN_TRANSFER]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraTransDetails", paraTranDetails);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionNo", paraTransactionNo);
                varSqlCommand.Parameters.AddWithValue("@paraProdTransactionNo", paraProdTransactionNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.CommandTimeout = 0;
                varResult = varSqlCommand.ExecuteScalar().ToString();
                return varResult;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                tmpspcall.CloseConnection();
            }

        }
        public DataSet udfnGetPlanRawDetails_PlanTran(string paraCompanyCode, string paraPlanNo, string paraPlanDate)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_PRODPLANTRANSFER_RAWDETAILS]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //MainLocation Transfer
        public DataSet udfnMainLoactionTransfer(DataTable paraStockInward, string paraProcess, int paraTransactionno, string paraoutwardno, string paraoutwardDate, int paraserialno, int paragrouptypecode,string paraUserId,string paraIpAddress,string paraOriginator,int paraCompanyCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_MAINLOCATIONTRANSFER", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraStockInward", paraStockInward);
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionno", paraTransactionno);
                varSqlCommand.Parameters.AddWithValue("@paraoutwardno", paraoutwardno);
                varSqlCommand.Parameters.AddWithValue("@paraoutwardDate", paraoutwardDate);
                varSqlCommand.Parameters.AddWithValue("@paraserialno", paraserialno);
                varSqlCommand.Parameters.AddWithValue("@paragrouptypecode", paragrouptypecode);
                varSqlCommand.Parameters.AddWithValue("@paraUserId", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //MainLocation Transfer List
        public DataSet udfnmainlocationtransferlist(string paraProcess, string paratransactionno, string parafromdate,string paratodate,string paraproductcode,string paraUserID,string paraIPAddress,string paraCompany,string paraGroupType,string paratype)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_MAINLOCATIONTRANSFER_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paratransactionno", paratransactionno);
                varSqlCommand.Parameters.AddWithValue("@parafromdate", parafromdate);
                varSqlCommand.Parameters.AddWithValue("@paratodate", paratodate);
                varSqlCommand.Parameters.AddWithValue("@paraproductcode", paraproductcode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupType", paraGroupType);
                varSqlCommand.Parameters.AddWithValue("@paratype", paratype);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** RM INWARD EXCEL EXPORT *********************
        public DataSet udfnRMInwardExcel(int paraprocess, string paraFromdate, string paraTodate, int paraCompany, string paraReason,string paraPlanNo,string paraGroup, string paraRawmaterial, string paraLocation, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_RM_INWARD_Excel", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraReason", paraReason);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);                
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG INWARD EXCEL EXPORT *********************
        public DataSet udfnFGInwardExcel(int paraprocess, string paraFromdate, string paraTodate, int paraCompany, string paraGroup, string paraRawmaterial,string paraFG, string paraLocation,string paraDOP, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_INWARD_Excel", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);               
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraFG", paraFG);                
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraDOP", paraDOP);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** RM OUTWARD EXCEL EXPORT *********************
        public DataSet udfnRMOutwardExcel(int paraprocess, string paraFromdate, string paraTodate, int paraCompany, string paraGroup, string paraRawmaterial, string paraSupplyTo, string paraLocation, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_RM_OUTWARD_Excel", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraSupplyTo", paraSupplyTo);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);              
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG OUTWARD EXCEL EXPORT *********************
        public DataSet udfnFGOutwardExcel(int paraprocess, string paraFromdate, string paraTodate, int paraCompany, string paraGroup, string paraRawmaterial, string paraFG, string paraLocation, string paraDOP, string paraUserid,string paraSupplyTo, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_OUTWARD_Excel", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraFG", paraFG);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraDOP", paraDOP);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraSupplyTo",paraSupplyTo);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** RM TRANSFER EXCEL EXPORT *********************
        public DataSet udfnRMTransferExcel(int paraprocess, string paraFromdate, string paraTodate, int paraCompany, string paraGroup, string paraRawmaterial,string paraLocation,string paraUserid,string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_RM_TRANSFER_EXCEL", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);             
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);               
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);               
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG TRANSFER EXCEL EXPORT *********************
        public DataSet udfnFGTransferExcel(int paraprocess, string paraFromdate, string paraTodate, int paraCompany, string paraGroup, string paraRawmaterial,string paraFG, string paraLocation,string paraDOP, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_TRANSFER_Excel", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraFG", paraFG);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraDOP", paraDOP);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** RM INWARD LIST *********************
        public DataSet udfnRMInwardList(int paraprocess, string paraFromdate, string paraTodate, string paraCompany, string paraReason, string paraPlanNo, string paraGroup, string paraRawmaterial, string paraLocation, string paraUserid,string PARASHOWCODE)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_RM_INWARD", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraReason", paraReason);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid); 
               varSqlCommand.Parameters.AddWithValue("@PARASHOWCODE", PARASHOWCODE);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG INWARD LIST *********************
        public DataSet udfnFGInwardList(int paraprocess, string paraFromdate, string paraTodate, string paraCompany, string paraGroup, string paraRawmaterial,string paraFG, string paraLocation, string paraDOP,string paraUserid,string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_INWARD", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);             
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraFG", paraFG);              
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraDOP", paraDOP);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** RM OUTWARD LIST *********************
        public DataSet udfnRMOutardList(int paraprocess, string paraFromdate, string paraTodate, string paraCompany, string paraGroup, string paraRawmaterial,string paraSupplyTo, string paraLocation, string paraUserid,string PARASHOWCODE)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_RM_OUTWARD", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);                              
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraSupplyTo", paraSupplyTo);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@PARASHOWCODE", PARASHOWCODE); 
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** RM TRANSFER LIST *********************
        public DataSet udfnRMTransferList(int paraprocess, string paraFromdate, string paraTodate, string paraCompany, string paraGroup, string paraRawmaterial,string paraLocation, string paraUserid,string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_RM_TRANSFER", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);               
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG OUTWARD LIST *********************
        public DataSet udfnFGOutInwardList(int paraprocess, string paraFromdate, string paraTodate, string paraCompany, string paraGroup, string paraRawmaterial, string paraFG, string paraLocation, string paraDOP, string paraUserid,string paraSupplyTo, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_OUTWARD", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraFG", paraFG);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraDOP", paraDOP);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraSupplyTo", paraSupplyTo);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG TRANSFER LIST *********************
        public DataSet udfnFGTransferList(int paraprocess, string paraFromdate, string paraTodate, string paraCompany, string paraGroup, string paraRawmaterial,string paraFG, string paraLocation,string paraDOP, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_TRANSFER", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRawmaterial", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraFG", paraFG);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraDOP", paraDOP);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** GROUP LIST FOR PRINT *********************
        public DataSet udfngroupList(int paraGroupCode, int paraRawCode,string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_CP_GROUP", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);               
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** RM LIST FOR PRINT *********************
        public DataSet udfnRMList(int paraGroupCode, int paraRawCode,int paraCompanyCode,int paraStatusCode,int paraOffsetStatus, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_CP_RAWMATERIAL", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraOffsetStatus", paraOffsetStatus);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** UNIT LIST FOR PRINT *********************
        public DataSet udfnUnitList(string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_CP_UNIT", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;              
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** WEIGHT LIST FOR PRINT *********************
        public DataSet udfnWeightList(string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_CP_WEIGHT", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** BRAND LIST FOR PRINT *********************
        public DataSet udfnBrandList(string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_CP_BRAND", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //*********** LOCATION  LIST FOR PRINT *********************
        public DataSet udfnLocationList(string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_CP_LOCATION", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** SECTION LIST FOR PRINT *********************
        public DataSet udfnSectionList(string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_CP_SECTION", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** COMPANY LIST FOR PRINT *********************
        public DataSet udfnCompanyList(int paraCompCode, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_CP_Company", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** DESIGNATION LIST FOR PRINT *********************
        public DataSet udfnDesignationList(string paraUserid, string paraIPAddress,int paraStatusCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_CP_DESIGNATION", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** STAFF LIST FOR PRINT *********************
        public DataSet udfnStaffList(int paraCompCode,int paraDesCode, string paraUserid, string paraIPAddress,int parastatus)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_CP_STAFF", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraDesCode", paraDesCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@parastatus", parastatus);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG NAME DETAILS LIST FOR PRINT *********************
        public DataSet udfnFGNameDeatilsList(int paraCompanyCode, int paraGroupCode,int paraRawCode,int paraFGCode,int paraUnitCode,int paraStatusCode, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_NAMEDETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraUnitCode", paraUnitCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //*********** FG MRP DETAILS LIST FOR PRINT *********************
        public DataSet udfnFGMRPDeatilsList(int paraCompanyCode, int paraGroupCode, int paraRawCode, int paraFGCode,int paraOffsetMRP,int paraOffsetMRPAmt,int paraAutoUpdate, int paraUpdateStatus, int paraStatusCode, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_MRPDETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraOffsetMRP", paraOffsetMRP);
                varSqlCommand.Parameters.AddWithValue("@paraOffsetMRPAmt", paraOffsetMRPAmt);
                varSqlCommand.Parameters.AddWithValue("@paraAutoUpdate", paraAutoUpdate);
                varSqlCommand.Parameters.AddWithValue("@paraUpdateStatus", paraUpdateStatus);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //*********** FG MRP DETAILS LIST FOR PRINT *********************
        public DataSet udfnFGMBESTBEFOREList(int paraCompanyCode, int paraGroupCode, int paraRawCode, int paraFGCode, int paraBestBefore,string paraBestBeforePeriod, int paraBatch,string paraUserid, string paraIPAddress,int paraStatusCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_BESTBEFOREDETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraBestBefore", paraBestBefore);
                varSqlCommand.Parameters.AddWithValue("@paraBestBeforePeriod", paraBestBeforePeriod);
                varSqlCommand.Parameters.AddWithValue("@paraBatch", paraBatch);    
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** BARCODE DETAILS LIST FOR PRINT *********************
        public DataSet udfnBarcodeDetailsList(int paraCompanyCode, int paraGroupCode, int paraRawCode, int paraFGCode, int paraBarCodeAvailable, int paraBarcodeStatus,string paraUserid, string paraIPAddress,int paraStatusCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_BARCODEDETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraBarCodeAvailable", paraBarCodeAvailable);
                varSqlCommand.Parameters.AddWithValue("@paraBarcodeStatus", paraBarcodeStatus);             
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** LABEL DETAILS LIST FOR PRINT *********************
        public DataSet udfnLabelDetailsList(int paraCompanyCode, int paraGroupCode, int paraRawCode, int paraFGCode, int paraLabelType, int paraLabelStatus,int paraStatusCode, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_LABELDETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLabelType", paraLabelType);
                varSqlCommand.Parameters.AddWithValue("@paraLabelStatus", paraLabelStatus);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** LABEL SIZE DETAILS LIST FOR PRINT *********************
        public DataSet udfnLabelSizeDetailsList(int paraCompanyCode, int paraGroupCode, int paraRawCode, int paraFGCode, int paraLabelType,string paraLabelSize, int paraLabelStatus, int paraStatusCode, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_LABELSIZEDETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLabelType", paraLabelType);
                varSqlCommand.Parameters.AddWithValue("@paraLabelSize", paraLabelSize);
                varSqlCommand.Parameters.AddWithValue("@paraLabelStatus", paraLabelStatus);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** LABEL TEMPLATE  DETAILS LIST FOR PRINT *********************
        public DataSet udfnLabelTemplateDetailsList(int paraCompanyCode, int paraGroupCode, int paraRawCode, int paraFGCode, int paraLabelType, string paraLabelSize, int paraLabelStatus, int paraStatusCode, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_LABELTEMPLATEDETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", "List");
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLabelType", paraLabelType);
                varSqlCommand.Parameters.AddWithValue("@paraLabelSize", paraLabelSize);
                varSqlCommand.Parameters.AddWithValue("@paraLabelStatus", paraLabelStatus);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** MSQ DETAILS LIST FOR PRINT *********************
        public DataSet udfnFGMSQDetailsList(int paraCompanyCode, int paraGroupCode, int paraRawCode, int paraFGCode, int paraStatusCode, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_MSQDETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);             
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** WEIGHT DETAILS LIST FOR PRINT *********************
        public DataSet udfnFGWeightDetailsList(int paraCompanyCode, int paraGroupCode, int paraRawCode, int paraFGCode,int paraUnitCode, int paraStatusCode, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_WEIGHTDETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraUnitCode", paraUnitCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG GROUP RM DETAILS LIST FOR PRINT *********************
        public DataSet udfnFGGroupRMDetailsList(int paraCompanyCode, int paraGroupCode, int paraRawCode, int paraFGCode, int paraBrandCode, int paraStatusCode, string paraUserid, string paraIPAddress,string paraprocess)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_GROUP_RM_DETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRawCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraBrandCode", paraBrandCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);              
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG UPP MRP DETAILS LIST FOR PRINT *********************
        public DataSet udfnFGUPPMRPList(int paraCompCode, int paraGroupCode, int paraRMCode, int paraFGCode, int paraWgtCode, int paraLabelType, string paraUserid, string paraIPAddress,int parastatus,string paratype)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_UPP_MRP", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraWgtCode", paraWgtCode);
                varSqlCommand.Parameters.AddWithValue("@paraLabelType", paraLabelType);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@parastatus", parastatus);
                varSqlCommand.Parameters.AddWithValue("@paratype", paratype);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG LABLE & MRP RATE LIST FOR PRINT *********************
        public DataSet udfnFGMRPRateList(int paraCompCode, int paraGroupCode, int paraRMCode, int paraReportType,string paraUserid, string paraIPAddress,int paraLocation,int paraFGTypeCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_LABELRATE_MRPRATE", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType); 
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraFGTypeCode", paraFGTypeCode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG FG DETAILS LIST FOR PRINT *********************
        public DataSet udfnFGFGDetailsList(int paraCompCode, int paraGroupCode, int paraRMCode, int paraFGCode,int paraWgtCode,string paraShelfLife,int paraStatus, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_FG_FGDETAIL", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraWgtCode", paraWgtCode);
                varSqlCommand.Parameters.AddWithValue("@paraShelfLife", paraShelfLife);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", paraStatus);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
               // varSqlCommand.Parameters.AddWithValue("@paraperiodcode", paraperiodcode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FG Locationwise *********************************

        public DataSet udfnlocationwisefgstock(int paraCompCode, int paraGroupCode, int paraRMCode, int paraFGCode, int paraWgtCode, int paraLocationcode, int paraStatus, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_LOCATIONWISE_FG_STOCK", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraWgtCode", paraWgtCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocationcode", paraLocationcode);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", paraStatus);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                // varSqlCommand.Parameters.AddWithValue("@paraperiodcode", paraperiodcode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** PROD SUMMARY LIST FOR PRINT *********************
        public DataSet udfnProdsummaryList(string paraFromDate, string paraToDate, int paraCompanyCode, string paraPlanNo, int paraSrNo, int paraSectionCode, int paraStatusCode, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_PROD_SUMMARY", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraSrNo", paraSrNo);
                varSqlCommand.Parameters.AddWithValue("@paraSectionCode", paraSectionCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** PROD DETAILED FOR PRINT *********************
        public DataSet udfnProdDetails(string paraFromDate, string paraToDate, int paraCompanyCode, string paraPlanNo,string paraUserid, string paraIPAddress,int parastatuscode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_PROD_DETAILS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);              
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@parastatuscode", parastatuscode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** FGWISEPRODUCTION FOR PRINT *********************
        public DataSet udfnFGWISEPRODUCTION(string paraFromDate, string paraToDate, int paraCompanyCode, int paraGroupCode,int paraRMCode,int paraSectionCode,int paraFGCode, string paraUserid, string paraIPAddress,int parastatus)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_PROD_FGWISEPRODUCTION", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraSectionCode", paraSectionCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@parastatus", parastatus);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //*********** PRODUCTWISE PRODUCTION FOR PRINT *********************
        public DataSet udfnPRODUCTWISEPRODUCTION(string paraFromDate, string paraToDate, int paraCompanyCode, int paraGroupCode, int paraRMCode, int paraFGCode,int paraReportType, string paraUserid, string paraIPAddress,int parastatuscode,int paraweight)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_PROD_PRODUCTWISEPRODUCTION", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@parastatuscode", parastatuscode);
                varSqlCommand.Parameters.AddWithValue("@paraweight",paraweight);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** PRODUCTWISE PRODUCTION FOR PRINT *********************
        public DataSet udfnSectionWISEPRODUCTION(string paraFromDate, string paraToDate, int paraCompanyCode, int paraSectionCode, int paraReporType,string paraUserid, string paraIPAddress,int parastatuscode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_PROD_SECTIONWISEPRODUCTION", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraSectionCode", paraSectionCode);
                varSqlCommand.Parameters.AddWithValue("@paraReporType", paraReporType);              
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@parastatuscode", parastatuscode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //*************** Requested Stock Inward *******************
        public string udfnReqStockInward(DataTable paraStockInward, string paraProcess, int paraTransactionno, string paraReqno, string paraReqDate, int paraserialno, string paraUserId, string paraIpAddress, string paraOriginator, int paraCompanyCode)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REQSTOCKINW", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraStockInward", paraStockInward);
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionno", paraTransactionno);
                varSqlCommand.Parameters.AddWithValue("@paraReqno", paraReqno);
                varSqlCommand.Parameters.AddWithValue("@paraReqDate", paraReqDate);
                varSqlCommand.Parameters.AddWithValue("@paraserialno", paraserialno);              
                varSqlCommand.Parameters.AddWithValue("@paraUserId", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.CommandTimeout = 0;
                varResult = varSqlCommand.ExecuteScalar().ToString();
                return varResult;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
        }


        //*************** Requested Stock Inward List *******************
        public DataSet udfnReqStockInwardlist(string paraProcess, string paratransactionno, string parafromdate, string paratodate, string paraproductcode, string paraUserID, string paraIPAddress, string paraCompany)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REQSTOCKINW_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paratransactionno", paratransactionno);
                varSqlCommand.Parameters.AddWithValue("@parafromdate", parafromdate);
                varSqlCommand.Parameters.AddWithValue("@paratodate", paratodate);
                varSqlCommand.Parameters.AddWithValue("@paraproductcode", paraproductcode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraCompany", paraCompany);               
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }


        public DataSet UdfnGetLabelprint(int paraPlanTransactionNo, int paraFGCode, int paraLabelCode, int paraNoofCopies, int paraTemplateCode, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_GET_LABELPRINT]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanTransactionNo", paraPlanTransactionNo);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLabelCode", paraLabelCode);
                varSqlCommand.Parameters.AddWithValue("@paraNoofCopies", paraNoofCopies);
                varSqlCommand.Parameters.AddWithValue("@paraTemplateCode", paraTemplateCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);               
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        public string udfngeneralsettings(int paraRMSQ, int paraFMSQ, string parasystemName, string paraUserID, string paraIPAddress, string paraOriginator, DataTable paraBillsettings, int paraintervaltime, int paraintervalcode,int parastockslip)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_General_Setting]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraRMSQ", paraRMSQ);
                varSqlCommand.Parameters.AddWithValue("@paraFMSQ", paraFMSQ);
                varSqlCommand.Parameters.AddWithValue("@parasystemName", parasystemName);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraBillsettings", paraBillsettings);
                varSqlCommand.Parameters.AddWithValue("@paraintervalcode", paraintervalcode);
                varSqlCommand.Parameters.AddWithValue("@paraintervaltime", paraintervaltime);
                varSqlCommand.Parameters.AddWithValue("@parastockslip", parastockslip);
                
                varSqlCommand.CommandTimeout = 0;
                varResult = varSqlCommand.ExecuteScalar().ToString();
                return varResult;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                tmpspcall.CloseConnection();
            }

        }
        //************** RM & FG REPORT ************
        public DataSet udfnStockRMFG(int paraCompCode, int paraGroupCode, int paraRMCode, int paraLocation, int paraType, int paraReportType, int paraIndividualPrint, int paraExport, string paraUserID, string paraIPAddress, int paraFGCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RMFG", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraIndividualPrint", paraIndividualPrint);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }




        //************** RM & FG REPORT FOR TALLY ************
        public DataSet udfnStockRMFGFORTALLY(int paraCompCode, int paraGroupCode, int paraRMCode, int paraLocation, int paraType, int paraIndividualPrint, int paraExport, string paraUserID, string paraIPAddress, int paraFGCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RMFG_TALLY", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
                //varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraIndividualPrint", paraIndividualPrint);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        

        //************** FG INACTIVE CONDITION CHECKING **************
        public DataSet udfnFGinactive(int paraFGCode,string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();         
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_CP_FGInactive", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);               
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*************** As On Stock - RM Valuation  Report *****************
        public DataSet udfnStockRMValuation(int paraCompCode, int paraGroupCode, int paraRMCode, int paraLocation, int paraType, int paraReportType,int paraExport, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RM_Valuation", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraExport", paraExport);                
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);               
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //*************** RATE CHANGE ITEM COUNT *****************
        public DataSet udfnRateChangeCount(string paraDate, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_RATECHANGE_Count", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraDate", paraDate);              
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //********* GENERAL SETTINGS EDIT *************
        public DataSet udfnGeneralSettingsList(string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_General_Setting_List]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;              
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //********* RAW MATERIAL - STOCK SHEET EMPTY REPORT *************
        public DataSet udfnrmemptyprint(int paraCompCode,int paraGroupCode,int paraRMCode,int paraLocation,int paraRowcount,int paraZerostock, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_REPORT_STOCK_RM_EmptyPrint]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraRowcount", paraRowcount);
                varSqlCommand.Parameters.AddWithValue("@paraZerostock", paraZerostock);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //********* Finished Goods - STOCK SHEET EMPTY REPORT *************
        public DataSet udfFGemptyprint(int paraCompCode, int paraGroupCode, int paraRMCode,int paraFGCode,int paraLocation, int paraRowcount,int paraZerostock, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_REPORT_STOCK_FG_EmptyPrint]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraRowcount", paraRowcount);
                varSqlCommand.Parameters.AddWithValue("@paraZerostock", paraZerostock);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //********* Raw Material - MSQ Value Report *************
        public DataSet udfnRMMSQvalue(int paraCompCode, int paraGroupCode, int paraRMCode, int paraLocation, int paraReportType, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RM_ MSQValueReport", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        public DataSet UdfnStockFGvaluereport(int paraCompCode, int paraGroupCode, int paraRMCode, int paraFGCode, int paraLocation, int paraReportType, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_REPORT_STOCK_FG_MSQValueReport]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //********* Raw Material - MSQ Stock Report *************
        public DataSet udfnRMMSQstockreport(int paraCompCode, int paraGroupCode, int paraRMCode, int paraLocation, int paraReportType,int paraZerostock, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RM_MSQStockReport", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraZerostock", paraZerostock);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********  Finished Goods - MSQ Needed Stock Report *************
        public DataSet udfnFGMSQstockreport(int paraCompCode, int paraGroupCode, int paraRMCode, int paraFGCode, int paraLocation, int paraReportType, int paraZerostock, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_FG_MSQStockReport", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGCode", paraFGCode);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraZerostock", paraZerostock);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        //********* Raw Material - Rate List *************
        public DataSet udfnRMRateList(int paraCompCode, int paraGroupCode, int paraRMCode,string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RM_RateList", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);             
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //********* Raw Material - Value Report *************
        public DataSet udfnRMValueReport(int paraCompCode, int paraGroupCode, int paraRMCode, int paraFGLinked, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_STOCK_RM_ValueReport", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@paraFGLinked", paraFGLinked);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********************** LABEL PRINT LIST *******************
        public DataSet udfnLabelprintList(string paraplandate, int paraCompCode,int paraSection,string paraaLabelSize,string paraBatch,int paraRMCode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_LABELPRINTING_LISTDEATILS]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraplandate", paraplandate);
                varSqlCommand.Parameters.AddWithValue("@paraCompCode", paraCompCode);
                varSqlCommand.Parameters.AddWithValue("@paraSection", paraSection);
                varSqlCommand.Parameters.AddWithValue("@paraaLabelSize", paraaLabelSize);
                varSqlCommand.Parameters.AddWithValue("@paraBatch", paraBatch);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRMCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********** Production Consolidated Report *********************
        public DataSet udfnPRODUCTIONconsolidate(string paraFromDate, string paraToDate, int paraCompanyCode,int paraSectionCode, int paraPlanNo, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_PROD_CONSOLIDATEDREPORT", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraSectionCode", paraSectionCode);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);     
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********************** PERFORMANCE REPORT *******************
        public DataSet udfnPlanPerformancereport(string paraPlanDate,string paraUserID,string paraIPAddress,int paracompanycode,int parasectioncode)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_PLAN_PerformanceReport", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraPlanDate", paraPlanDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paracompanycode", paracompanycode);
                varSqlCommand.Parameters.AddWithValue("@parasectioncode", parasectioncode);     
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //*********************** PURCHASE INCHARGE *******************
        public string udfnCP_Purchaseincharge(string paraprocess, int paraInchargeCode, string paraName, string paraShortName, int paraStatus, string parauserid, string paraipaddress, string paraOriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_CP_PurchaseIncharge", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraInchargeCode", paraInchargeCode);
                varSqlCommand.Parameters.AddWithValue("@paraName", paraName);
                varSqlCommand.Parameters.AddWithValue("@paraShortName", paraShortName);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", paraStatus);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.CommandTimeout = 0;
                result = varSqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
        //******************** PURCHASE INCHARGE LIST ***********************
        public DataSet udfnCP_PurchaseinchargeList(string paraprocess, int paraInchargeCode, string parauserid, string paraipaddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_CP_PurchaseIncharge_LIST", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraInchargeCode", paraInchargeCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //******************** PURCHASE INCHARGE WISE RM REPORT *************
        public DataSet udfnREPORT_PurchaseInchargeWiseRM(int paraGroupCode, int paraRawCode, int paraCompanyCode, string paraProcess, string paraInchargeCode, string paraUserid, string paraIPAddress,int paraShow)
        {
            DataSet ds = new DataSet();
            try
            {   
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_PurchaseInchargeWiseRM", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ParaGroupCode", paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@ParaRMCode", paraRawCode);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraInchargeCode", paraInchargeCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraShow", paraShow);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //************** PURCHASE INCHARGE REPORT FILTER **************
        public DataSet udfnCP_PurchaseIncharge_Report(string paraprocess, string paraInchargeCode, string parauserid, string paraipaddress, string CompanyCode, string ParaGroupCode)
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_PI_FILTER", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paraInchargeCode", paraInchargeCode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", CompanyCode);
                varSqlCommand.Parameters.AddWithValue("@ParaGroupCode", ParaGroupCode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        //************** UNIT WISE PRODUTION GROUP REPORT *************

        public DataSet udfnUnitwisegroup(string paraFromDate, string paraToDate, int paraCompanyCode, int paraReportCode, string paraUserid, string paraIPAddress,string paraGroupcode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_PROD_UNITWISE", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraReportCode", paraReportCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraGroupcode", paraGroupcode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnshortage(string paraFromdate, string paraTodate, string paraCompany, string paraGroup, string paraRawmaterial, string paraUserid, string paraIPAddress, string paraPlanNo, string paraPlanNoDate)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_LOSS_PLANWISE", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNoDate", paraPlanNoDate);


                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnrmwiseloss(string paraFromdate, string paraTodate, string paraCompany, string paraGroup, string paraRawmaterial, string paraUserid, string paraIPAddress, string paraPlanNo, string paraPlanNoDate, string paraType)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_LOSS_RMWISE", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNoDate", paraPlanNoDate);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);


                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnrmwisestocklosstally(string paraFromdate, string paraTodate, string paraCompany, string paraGroup, string paraRawmaterial, string paraUserid, string paraIPAddress, string paraPlanNo, string paraPlanNoDate, string paraType)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_LOSS_RMWISE_STOCK_TALLY", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNo", paraPlanNo);
                varSqlCommand.Parameters.AddWithValue("@paraPlanNoDate", paraPlanNoDate);
                varSqlCommand.Parameters.AddWithValue("@paraType", paraType);


                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        
        public DataSet udfnfgtransferstk(string paraFromdate, string paraTodate, string paraCompany, string paraGroup, string paraRawmaterial, string paraUserid, string paraIPAddress, string paratype, string paraFgcode, string paraDOP,string paralocationcode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_MLTRANSFER_FG", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraFgcode", paraFgcode);
                varSqlCommand.Parameters.AddWithValue("@paraDOP", paraDOP);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraType", paratype);
                varSqlCommand.Parameters.AddWithValue("@paralocationcode", paralocationcode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnlabeltypes(DataTable paraTable, int labelcode, string parauserid, string paraipaddress, string Paralabeltype, string ParaProcess)
        {
            DataSet ds = new DataSet();
            //   SqlConnection con = null;
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[PROC_CP_LABELTYPE_LIST]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraTable", paraTable);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@PARASTICKERTYPE", labelcode);
                varSqlCommand.Parameters.AddWithValue("@Paralabeltype", Paralabeltype);
                varSqlCommand.Parameters.AddWithValue("@ParaProcess", ParaProcess);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnrmtransferstk(string paraFromdate, string paraTodate, string paraCompany, string paraGroup, string paraRawmaterial, string paraUserid, string paraIPAddress, string paratype)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_MLTRANSFER_RM", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraType", paratype);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        public DataSet udfnrmlocationwisestk( string paraCompany, string paraGroup, string paraRawmaterial, string paraUserid, string paraIPAddress, string paralocationcode,string parastatuscode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_LOCATIONWISE_RM", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paralocationcode", paralocationcode);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", parastatuscode);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }
        public DataSet udfnmonthwiseloss(string paraFromMonth, string paraToMonth, string paraFromyear, string paraToyear, string paraCompany, string paraGroup, string paraRawmaterial, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_LOSS_MONTHWISE", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromMonth", paraFromMonth);
                varSqlCommand.Parameters.AddWithValue("@paraToMonth", paraToMonth);
                varSqlCommand.Parameters.AddWithValue("@paraFromYear", paraFromyear);
                varSqlCommand.Parameters.AddWithValue("@paraToYear", paraToyear);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        public DataSet udfnmonthwisestocklossTally(string paraFromMonth, string paraToMonth, string paraFromyear, string paraToyear, string paraCompany, string paraGroup, string paraRawmaterial, string paraUserid, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_LOSS_MONTHWISE_STOCK_TALLY", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromMonth", paraFromMonth);
                varSqlCommand.Parameters.AddWithValue("@paraToMonth", paraToMonth);
                varSqlCommand.Parameters.AddWithValue("@paraFromYear", paraFromyear);
                varSqlCommand.Parameters.AddWithValue("@paraToYear", paraToyear);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        public DataSet udfnitemmovementanalysis(string paraFromdate, string paraTodate, string paraCompany, string paraRawmaterial, string paraUserid, string paraIPAddress, string paraFgcode, string paraProcess, string PARALOCATIONCODE,string paramrp,string paraBatchno,string paraDOP)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_REPORT_ITEM_MOVEMENT_ANALYSIS", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraFromdate", paraFromdate);
                varSqlCommand.Parameters.AddWithValue("@paraTodate", paraTodate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", paraCompany);
                varSqlCommand.Parameters.AddWithValue("@paraRMCode", paraRawmaterial);
                varSqlCommand.Parameters.AddWithValue("@paraFgcode", paraFgcode);
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraUserid", paraUserid);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@PARALOCATIONCODE", PARALOCATIONCODE);
                varSqlCommand.Parameters.AddWithValue("@paraDOP", paraDOP);
                varSqlCommand.Parameters.AddWithValue("@paraBatchno", paraBatchno);
                varSqlCommand.Parameters.AddWithValue("@paramrp", paramrp);
                varSqlCommand.CommandTimeout = 0;
                SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return ds;
        }

        public string udfnmrpchanges(string paraprocess, string paratransactionno, string paramrp, string PARAFGCODE, string parabatchno, string paraqrcode, string parauserid, string paraipaddress, string paraoriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("PROC_PROD_LABELPRINTING_MRP", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraprocess", paraprocess);
                varSqlCommand.Parameters.AddWithValue("@paratransactionno", paratransactionno);
                varSqlCommand.Parameters.AddWithValue("@paramrp", paramrp);
                varSqlCommand.Parameters.AddWithValue("@PARAFGCODE", PARAFGCODE);
                varSqlCommand.Parameters.AddWithValue("@parabatchno", parabatchno);
                varSqlCommand.Parameters.AddWithValue("@paraqrcode", paraqrcode);
                varSqlCommand.Parameters.AddWithValue("@parauserid", parauserid);
                varSqlCommand.Parameters.AddWithValue("@paraipaddress", paraipaddress);
                varSqlCommand.Parameters.AddWithValue("@paraoriginator", paraoriginator);
                varSqlCommand.CommandTimeout = 0;

                result = varSqlCommand.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                tmpspcall.CloseConnection();
            }
            return result;
        }
    }
}
