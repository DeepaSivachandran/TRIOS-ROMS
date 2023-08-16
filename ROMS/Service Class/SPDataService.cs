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
                varSqlCommand.Parameters.AddWithValue("@viewType", paraviewType);
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
                varSqlCommand.Parameters.AddWithValue("@viewType", paraviewType);
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
    }
}
