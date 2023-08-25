using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ROMS
{   //Test
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

        //Company Master 
        //created by Venkat,Created on 09/08/2023
        public string udfnCompanyMaster(int ViewType, int paraCompanyId, string paraCompanyName, string paraShortName, string paraAddress1,
            string paraAddress2, int paraCityId, string paraPincode, string paraPhoneNumber,string paraAltPhoneNumber, string paraWhatsappNumber, string paraMobileNumber,
             string paraAltMobileNumber, string paraEmail, string paraWebsite, string paraGstin, string paraPan, string paraESI, string paraEPF,
              string paraFssai, string paraPlno, string paraStateId, string paraStatusId,string paraUserID, string paraIPAddress, string paraOriginator,DataTable ParaMR_Bank,DataTable ParaMR_Company_Contact)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNS_Company", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyName", paraCompanyName);
                varSqlCommand.Parameters.AddWithValue("@paraShortName", paraShortName);
                varSqlCommand.Parameters.AddWithValue("@paraAddress1", paraAddress1);
                varSqlCommand.Parameters.AddWithValue("@paraAddress2", paraAddress2);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", paraCityId);
                varSqlCommand.Parameters.AddWithValue("@paraPincode", paraPincode);
                varSqlCommand.Parameters.AddWithValue("@paraPhoneNumber", paraPhoneNumber);
                varSqlCommand.Parameters.AddWithValue("@paraAltPhoneNumber", paraAltPhoneNumber);
                varSqlCommand.Parameters.AddWithValue("@paraWhatsappNumber", paraWhatsappNumber);
                varSqlCommand.Parameters.AddWithValue("@paraMobileNumber", paraMobileNumber);
                varSqlCommand.Parameters.AddWithValue("@paraAltMobileNumber", paraAltMobileNumber);
                varSqlCommand.Parameters.AddWithValue("@paraEmail", paraEmail);
                varSqlCommand.Parameters.AddWithValue("@paraWebsite", paraWebsite);
                varSqlCommand.Parameters.AddWithValue("@paraGstin", paraGstin);
                varSqlCommand.Parameters.AddWithValue("@paraPan", paraPan);
                varSqlCommand.Parameters.AddWithValue("@paraESI", paraESI);
                varSqlCommand.Parameters.AddWithValue("@paraEPF", paraEPF);
                varSqlCommand.Parameters.AddWithValue("@paraFssai", paraFssai);
                varSqlCommand.Parameters.AddWithValue("@paraPlno", paraPlno);
                varSqlCommand.Parameters.AddWithValue("@paraStateId", paraStateId);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@ParaMR_Bank", ParaMR_Bank);
                varSqlCommand.Parameters.AddWithValue("@ParaMR_Company_Contact", ParaMR_Company_Contact);
                


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

        //Company Master List
        //created by Venkat,Created on 09/08/2023
        public DataSet udfnCompanyList(int ViewType, int paraCompanyId, string paraUserID, string paraIPAddress)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNG_Company", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", paraCompanyId);
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
        //City Master List
        //created by Venkat,Created on 09/08/2023
        public DataSet udfncitylist(int ViewType, string paraCityName, string paraUserID, string paraIPAddress, string paraStateId)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNG_City", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCityName", paraCityName);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStateId", paraStateId);
                
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

        // Sivabharathi    Create date: 09/08/2023    Description:	HSN Sp
        public string udfnHsn(int ViewType,int paraHsnId,int paraGstId,string paraHsnName,string paraHsnCode,int paraStatusId,string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNS_HSN", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraHsnId", paraHsnId);
                varSqlCommand.Parameters.AddWithValue("@paraGstId", paraGstId);
                varSqlCommand.Parameters.AddWithValue("@paraHsnName", paraHsnName);
                varSqlCommand.Parameters.AddWithValue("@paraHsnCode", paraHsnCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
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
        // Sivabharathi    Create date: 09/08/2023    Description:	HSN list Sp
        public DataSet udfnHsnList(int ViewType)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_HSN]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
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
        //Created By:-Sathish
        public string udfnUnit(int paraviewType, int paraUnitId, string paraUnitName, string paraUnitSymbol, int paraUnitDecimal,int paraUnitStatusId,string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Unit]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUnitId", paraUnitId);
                varSqlCommand.Parameters.AddWithValue("@paraUnitName", paraUnitName);
                varSqlCommand.Parameters.AddWithValue("@paraUnitSymbol", paraUnitSymbol);
                varSqlCommand.Parameters.AddWithValue("@paraUnitDecimal", paraUnitDecimal);
                varSqlCommand.Parameters.AddWithValue("@paraUnitStatusId", paraUnitStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
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
        //Created By:-Sathish
        public DataSet udfnUnitList(int paraviewType)
        {
             DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Unit]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
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
        //Created By :-Sathish ; Created On :-11/08/2023
        public string udfnCity(int paraviewType, int paraCityId, string paraStateId, string paraCityName, int paraStatusId,string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_City]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", paraCityId);
                varSqlCommand.Parameters.AddWithValue("@paraStateId", paraStateId);
                varSqlCommand.Parameters.AddWithValue("@paraCityName", paraCityName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
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
        //Created By :-Sathish ; Created On :-11/08/2023
        public DataSet udfnCityList(int paraviewType,string paraCityName,int paraStateId)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_City]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraCityName", paraCityName);
                varSqlCommand.Parameters.AddWithValue("@paraStateId", paraStateId);
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
        //Created By :-Sathish ; Created On :-11/08/2023
        public string udfnBroker(int paraviewType, int paraBrokerId,int paraConcern,string paraGstinNo, string paraBrokerName,
            string paraAddressLine1,string paraAddressLine2,int paraCityId,string paraPincode,string paraWhatsappNumber,
            string paraMobileNumber,int paraStatusId, string paraOriginator, DataTable ParaMR_Broker_Bank)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Broker]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerId", paraBrokerId);
                varSqlCommand.Parameters.AddWithValue("@paraConcernId", paraConcern);
                varSqlCommand.Parameters.AddWithValue("@paraGstinNo", paraGstinNo);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerName", paraBrokerName);
                varSqlCommand.Parameters.AddWithValue("@paraAddressLine1", paraAddressLine1);
                varSqlCommand.Parameters.AddWithValue("@paraAddressLine2", paraAddressLine2);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", paraCityId);
                varSqlCommand.Parameters.AddWithValue("@paraPincode", paraPincode);
                varSqlCommand.Parameters.AddWithValue("@paraWhatsappNumber", paraWhatsappNumber);
                varSqlCommand.Parameters.AddWithValue("@paraMobileNumber", paraMobileNumber);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@ParaMR_Broker_Bank", ParaMR_Broker_Bank);
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
        //Created By :-Sathish ; Created On :-11/08/2023
        public DataSet udfnBrokerList(int paraviewType,int paraBrokerId)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Broker]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerId", paraBrokerId);
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
        //Created BY:-Sathish
        public string udfnStockLocation(int paraviewType, int paraStockId, int paraConcern, int paraLocationType, string paraLocationNameEnglish, string paraLocationNameTamil, string paraShortName, int paraGodownType, int paraStockApplicable, int paraStockStatusId, string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_StockLocation]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@viewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraStockId", paraStockId);
                varSqlCommand.Parameters.AddWithValue("@paraConcern", paraConcern);
                varSqlCommand.Parameters.AddWithValue("@paraLocationType", paraLocationType);
                varSqlCommand.Parameters.AddWithValue("@paraLocationNameEnglish", paraLocationNameEnglish);
                varSqlCommand.Parameters.AddWithValue("@paraLocationNameTamil", paraLocationNameTamil);
                varSqlCommand.Parameters.AddWithValue("@paraShortName", paraShortName);
                varSqlCommand.Parameters.AddWithValue("@paraGodownType", paraGodownType);
                varSqlCommand.Parameters.AddWithValue("@paraStockApplicable", paraStockApplicable);
                varSqlCommand.Parameters.AddWithValue("@paraStockStatusId", paraStockStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
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
        //Created By :-Sathish ; Created On :-17/08/2023
        public DataSet udfnStockLocationList(int paraviewType, int paraConcern)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_StockLocation]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraConcern", paraConcern);
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
        //Created By:-Sathish Created On:-18-08-2023
        public string udfnRack(int paraViewType,int paraRackId,int paraConcern,int paraStockLocation, string paraRackName, string paraShortName, string paraDescription,  int paraStatusId, string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Rack]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraRackId", paraRackId);
                varSqlCommand.Parameters.AddWithValue("@paraConcern", paraConcern);
                varSqlCommand.Parameters.AddWithValue("@paraStockLocation", paraStockLocation);
                varSqlCommand.Parameters.AddWithValue("@paraRackName", paraRackName);
                varSqlCommand.Parameters.AddWithValue("@paraShortName", paraShortName);
                varSqlCommand.Parameters.AddWithValue("@paraDescription", paraDescription);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
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
        //Created By :-Sathish ; Created On :-18/08/2023
        public DataSet udfnRackList(int paraviewType, int paraRackGroup)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Rack]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraRackGroup", paraRackGroup);
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
        //Created By:-Sathish Created On:-21/08/2023
        public string udfnUserCategory(int paraviewType, int paraUserCategoryId, string paraUserCategoryName, int paraStatusId, string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_UserCategory]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserCategoryId", paraUserCategoryId);
                varSqlCommand.Parameters.AddWithValue("@paraUserCategoryName", paraUserCategoryName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
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
        //Created By:-Sathish Created On:-21/08/2023
        public DataSet udfnUserCategoryList(int paraviewType)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_UserCategory]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
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
        //Created By:-Sathish Created On:-22/08/2023
        public string udfnUser(int paraviewType, int paraUId, string paraNameoftheUser,string paraLoginId,int paraUserCategory,int paraUserRole,string paraPassword,int paraPassKey, int paraStatusId, string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_User]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUId", paraUId);
                varSqlCommand.Parameters.AddWithValue("@paraNameoftheUser", paraNameoftheUser);
                varSqlCommand.Parameters.AddWithValue("@paraLoginId", paraLoginId);
                varSqlCommand.Parameters.AddWithValue("@paraUserCategory", paraUserCategory);
                varSqlCommand.Parameters.AddWithValue("@paraUserRole", paraUserRole);
                varSqlCommand.Parameters.AddWithValue("@paraPassword", paraPassword);
                varSqlCommand.Parameters.AddWithValue("@paraPassKey", paraPassKey);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
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
        // Sivabharathi    Create date: 10/08/2023    Description:	Group Sp
        public string udfnGroup(int ViewType, int paraPRGID, string paraPRG_EName, string paraPRG_TName, int paraStatusId, string paraOriginator)
        {
           
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNS_ProductGroup", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraPRGID", paraPRGID);
                varSqlCommand.Parameters.AddWithValue("@paraPRG_EName", paraPRG_EName);
                varSqlCommand.Parameters.AddWithValue("@paraPRG_TName", paraPRG_TName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
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
        // Sivabharathi    Create date: 11/08/2023    Description:	Group list Sp
        public DataSet udfnGroupList(int ViewType, int paraPRGID)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_ProductGroup]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraPRGID", paraPRGID);
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
        // Sivabharathi    Create date: 14/08/2023    Description:Sub Group  Sp
        public string udfnSubGroup(int ViewType, int paraPRSGID,int paraPRSG_PRGID, string paraPRSG_EName, string paraPRSG_TName, int paraStatusId,int paraSG_BatchNo,int paraPRSG_SLID, int paraPRSG_RKID,string paraOriginator)
        {

            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNS_ProductSubGroup", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraPRSGID", paraPRSGID);
                varSqlCommand.Parameters.AddWithValue("@paraPRSG_PRGID", paraPRSG_PRGID);
                varSqlCommand.Parameters.AddWithValue("@paraPRSG_EName", paraPRSG_EName);
                varSqlCommand.Parameters.AddWithValue("@paraPRSG_TName", paraPRSG_TName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraSG_BatchNo", paraSG_BatchNo);
                varSqlCommand.Parameters.AddWithValue("@paraPRSG_SLID", paraPRSG_SLID);
                varSqlCommand.Parameters.AddWithValue("@paraPRSG_RKID", paraPRSG_RKID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
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
        // Sivabharathi    Create date: 14/08/2023    Description:Sub Group list Sp
        public DataSet udfnSubGroupList(int ViewType, int paraPRSGID,string paraPRGID)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_ProductSubGroup]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraPRSGID", paraPRSGID);
                varSqlCommand.Parameters.AddWithValue("@paraPRGIDs", paraPRGID);
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

        // Created by : Deepa    Modified by: Sathish
        // Created on : 16-08-2023 Modified on: 22-08-2023
        public DataSet udfnUserList(int paraviewType,string paraUserName, string paraLoginId, string paraPassword,int paraUser)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_User]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserName", paraUserName);
                varSqlCommand.Parameters.AddWithValue("@paraLoginId", paraLoginId);
                varSqlCommand.Parameters.AddWithValue("@paraPassword", paraPassword);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUser", paraUser);
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
        //Product Master 
        //created by Venkat,Created on 14/08/2023
        public string udfnProductMaster(int ViewType, int paraProductid, string paraProductNameEng, string paraProductNameTam, string paraPIcode,
            int ParaCompanycode, int paraProductCategory, int paraGroup, int paraSubgroup, int paraBrand, int paraUnit, int paraBulkunit,
             string paraUpp, int paraPurStklocation, int paraSaleStklocation, int paraPurRack, int parasaleRack, int paraRkMOQ, int paraBatchNo,
              int paraBatchNoGeneration, int paraShelfLife, double paranetweight,double paraMaxstk,double paraGrossweight,double paraMinstk,
              double paraReorderQty,double paraRetailMinstk,double paraRetailrate,double paraWMinqty,double paraWsaleRate,string paraBarcode,int paraHSNCode
             ,int paraRMPROD,int paraShelflifeValue,int paraShelflifeType


            , string paraStatusId, string paraUserID, string paraIPAddress, string paraOriginator)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNS_Product", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraProductid", paraProductid);
                varSqlCommand.Parameters.AddWithValue("@paraProductNameEng", paraProductNameEng);
                varSqlCommand.Parameters.AddWithValue("@paraProductNameTam", paraProductNameTam);
                varSqlCommand.Parameters.AddWithValue("@paraPIcode", paraPIcode);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraProductCategory", paraProductCategory);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroup", paraSubgroup);
                varSqlCommand.Parameters.AddWithValue("@paraBrand", paraBrand);
                varSqlCommand.Parameters.AddWithValue("@paraUnit", paraUnit);
                varSqlCommand.Parameters.AddWithValue("@paraBulkunit", paraBulkunit);
                varSqlCommand.Parameters.AddWithValue("@paraUpp", paraUpp);
                varSqlCommand.Parameters.AddWithValue("@paraPurStklocation", paraPurStklocation);
                varSqlCommand.Parameters.AddWithValue("@paraSaleStklocation", paraSaleStklocation);
                varSqlCommand.Parameters.AddWithValue("@paraPurRack", paraPurRack);
                varSqlCommand.Parameters.AddWithValue("@parasaleRack", parasaleRack);
                varSqlCommand.Parameters.AddWithValue("@paraRkMOQ", paraRkMOQ);
                varSqlCommand.Parameters.AddWithValue("@paraBatchNo", paraBatchNo);
                varSqlCommand.Parameters.AddWithValue("@paraBatchNoGeneration", paraBatchNoGeneration);
                varSqlCommand.Parameters.AddWithValue("@paraShelfLife", paraShelfLife);
                varSqlCommand.Parameters.AddWithValue("@paranetweight", paranetweight);
                varSqlCommand.Parameters.AddWithValue("@paraMaxstk", paraMaxstk);
                varSqlCommand.Parameters.AddWithValue("@paraGrossweight", paraGrossweight);
                varSqlCommand.Parameters.AddWithValue("@paraMinstk", paraMinstk); 
                varSqlCommand.Parameters.AddWithValue("@paraReorderQty", paraReorderQty);
                varSqlCommand.Parameters.AddWithValue("@paraRetailMinstk", paraRetailMinstk);
                varSqlCommand.Parameters.AddWithValue("@paraRetailrate", paraRetailrate);
                varSqlCommand.Parameters.AddWithValue("@paraWMinqty", paraWMinqty);
                varSqlCommand.Parameters.AddWithValue("@paraWsaleRate", paraWsaleRate);
                varSqlCommand.Parameters.AddWithValue("@paraBarcode", paraBarcode);  
                varSqlCommand.Parameters.AddWithValue("@paraHSNCode", paraHSNCode); 
                varSqlCommand.Parameters.AddWithValue("@paraRMPROD", paraRMPROD);
                varSqlCommand.Parameters.AddWithValue("@paraShelflifeValue", paraShelflifeValue);
                varSqlCommand.Parameters.AddWithValue("@paraShelflifeType", paraShelflifeType); 
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
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

        //Product Master List
        //created by Venkat,Created on 16/08/2023
        public DataSet udfnproductmasterlist(int ViewType, int ParaProductCode, int paraProductCategory, int paraGroup, int paraSubgroup, string paraUserID, string paraIPAddress, int ParaCompanycode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNG_Product", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaProductCode", ParaProductCode);
                varSqlCommand.Parameters.AddWithValue("@paraProductCategory", paraProductCategory);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroup", paraSubgroup); 
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", ParaCompanycode);

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


       public string udfnBrand(int ViewType,string paraBD_EName, string paraBD_TName, int paraStatusId,  string paraOriginator)
       {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNS_Brand", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraBD_EName", paraBD_EName);
                varSqlCommand.Parameters.AddWithValue("@paraBD_TName", paraBD_TName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
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
    }
}
