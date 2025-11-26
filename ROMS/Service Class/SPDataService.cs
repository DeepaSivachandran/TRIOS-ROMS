using ROMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
        // added by venkat on 13/10/2023 for PO.No. Load
        public string udfngetVoucherNo(string paraTransactionType, string paraDate, int paraCompanyCode)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand cmd = new SqlCommand("[MRG_VoucherNo]", tmpspcall.objConn);
                cmd.Parameters.AddWithValue("@paraTransactionType", paraTransactionType);
                cmd.Parameters.AddWithValue("@paraDate", paraDate);
                cmd.Parameters.AddWithValue("@paraCompanyCode", paraCompanyCode);
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
        // Sivabharathi    Create date: 20/09/2023    Description:	Master list Sp
        public DataSet udfnMaster(MR_Master objMR_Master)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Master]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objMR_Master.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraID", objMR_Master.paraID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraPOID", objMR_Master.paraPOID);
                varSqlCommand.Parameters.AddWithValue("@paraDate", objMR_Master.paraDate);
                varSqlCommand.Parameters.AddWithValue("@ParaExpiryDate", objMR_Master.ParaExpiryDate);
                varSqlCommand.Parameters.AddWithValue("@paraProductId", objMR_Master.paraProductId);
                varSqlCommand.Parameters.AddWithValue("@paraText", objMR_Master.paraText);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objMR_Master.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraTime", objMR_Master.paraTime);
                varSqlCommand.Parameters.AddWithValue("@paraTimeFormat", objMR_Master.paraTimeFormat);
                varSqlCommand.Parameters.AddWithValue("@ParaProduct_HSN", objMR_Master.ParaProduct_HSN);
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
        // Sivabharathi    Create date: 26/09/2023    Description: Voucher Settings
        public string udfnVoucherSettings(int ViewType, int paraConcernId, int paraTransactionId, string paraPrefix, string paraSufix, int ParaNoOfDigit, string paraStartingNo,
           string ParaSampleTransaction, int ParaResetOn, int paraVoucherSettingId, string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_VoucherSettings", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraConcernId", paraConcernId);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionId", paraTransactionId);
                varSqlCommand.Parameters.AddWithValue("@paraPrefix", paraPrefix);
                varSqlCommand.Parameters.AddWithValue("@paraSufix", paraSufix);
                varSqlCommand.Parameters.AddWithValue("@ParaNoOfDigit", ParaNoOfDigit);
                varSqlCommand.Parameters.AddWithValue("@ParaResetOn", ParaResetOn);
                varSqlCommand.Parameters.AddWithValue("@ParaSampleTransaction", ParaSampleTransaction);
                varSqlCommand.Parameters.AddWithValue("@paraVoucherSettingId", paraVoucherSettingId);
                varSqlCommand.Parameters.AddWithValue("@paraStartingNo", paraStartingNo);
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
        // Sivabharathi    Create date: 05/10/2023    Description: General Settings
        public string udfnGeneralSettings(int ViewType, int paraGeneralSettingsID, decimal paraGS_CPA, decimal paraGS_DVA, int paraGS_GRNQty, int paraGS_RAD, 
            int paraGS_IED, DataTable ParaMR_GeneralSettings_TAT, DataTable paraMR_GeneralSettings_RPTText, string paraOriginator, int paraStockenable, 
            string paraDBPath, int paraGRNPrint, int paraDCPrint, int paraLevel1, int paraLevel2,int paraVerificationDays,int paraAgingMonths,decimal paraLPRatePer,
            decimal paraRTGSMinLimit, int paraRCStockShow, decimal paraCashPaymentLimit,int paralogoffenable, int paralogofftime,int paraInactivedays, int
                paraMultiUserSameSystem, int paraSameUserSameSystem, int paraSameUserMultiSystem)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_GeneralSettings", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraGeneralSettingsID", @paraGeneralSettingsID);
                varSqlCommand.Parameters.AddWithValue("@paraGS_CPA", paraGS_CPA);
                varSqlCommand.Parameters.AddWithValue("@paraGS_DVA", paraGS_DVA);
                varSqlCommand.Parameters.AddWithValue("@paraGS_GRNQty", paraGS_GRNQty);
                varSqlCommand.Parameters.AddWithValue("@paraGS_RAD", paraGS_RAD);
                varSqlCommand.Parameters.AddWithValue("@paraGS_IED", paraGS_IED);
                varSqlCommand.Parameters.AddWithValue("@ParaMR_GeneralSettings_TAT", ParaMR_GeneralSettings_TAT);
                varSqlCommand.Parameters.AddWithValue("@paraMR_GeneralSettings_RPTText", paraMR_GeneralSettings_RPTText);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraStockenable", paraStockenable);
                varSqlCommand.Parameters.AddWithValue("@paraDBPath", paraDBPath);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraGRNPrint", paraGRNPrint);
                varSqlCommand.Parameters.AddWithValue("@paraDCPrint", paraDCPrint);
                varSqlCommand.Parameters.AddWithValue("@paraLevel1", paraLevel1);
                varSqlCommand.Parameters.AddWithValue("@paraLevel2", paraLevel2);
                varSqlCommand.Parameters.AddWithValue("@paraVerificationDays", paraVerificationDays);
                varSqlCommand.Parameters.AddWithValue("@paraAgingMonths", paraAgingMonths);
                varSqlCommand.Parameters.AddWithValue("@paraLPRatePer", paraLPRatePer);
                varSqlCommand.Parameters.AddWithValue("@paraRTGSMinLimit", paraRTGSMinLimit);
                varSqlCommand.Parameters.AddWithValue("@paraRCStockShow", paraRCStockShow);
                varSqlCommand.Parameters.AddWithValue("@paraCashPaymentLimit", paraCashPaymentLimit);

                varSqlCommand.Parameters.AddWithValue("@paralogoffenable", paralogoffenable);
                varSqlCommand.Parameters.AddWithValue("@paralogofftime", paralogofftime);
                varSqlCommand.Parameters.AddWithValue("@paraInactivedays", paraInactivedays);

                varSqlCommand.Parameters.AddWithValue("@paraMultiUserSameSystem", paraMultiUserSameSystem);
                varSqlCommand.Parameters.AddWithValue("@paraSameUserSameSystem", paraSameUserSameSystem);
                varSqlCommand.Parameters.AddWithValue("@paraSameUserMultiSystem", paraSameUserMultiSystem);


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
        // Sivabharathi    Create date: 05/10/2023    Description: General Settings list
        public DataSet udfnGeneralSettingList(int ViewType)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRG_GeneralSettings", tmpspcall.objConn);
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
        // Sivabharathi    Create date: 27/09/2023    Description: Voucher Settings list
        public DataSet udfnVoucherSettingList(int ViewType)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_VoucherSettings]", tmpspcall.objConn);
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
            string paraAddress2, int paraCityId, string paraPincode, string paraPhoneNumber, string paraAltPhoneNumber, string paraWhatsappNumber, string paraMobileNumber,
             string paraAltMobileNumber, string paraEmail, string paraWebsite, string paraGstin, string paraPan, string paraESI, string paraEPF,
              string paraFssai, string paraPlno, string paraStateId, string paraStatusId, string paraUserID, string paraIPAddress, string paraOriginator, DataTable ParaMR_Bank, DataTable ParaMR_Company_Contact, string paraLogoName, int paradefaultcompany)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_Company", tmpspcall.objConn);
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
                varSqlCommand.Parameters.AddWithValue("@paraLogoName", paraLogoName);
                varSqlCommand.Parameters.AddWithValue("@paradefaultcompany", paradefaultcompany);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnCompanyList(int ViewType, int paraCompanyId, string paraUserID, string paraIPAddress, int paraStatusCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRG_Company", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
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
        // Sivabharathi    Create date: 09/08/2023    Description:	HSN Sp
        public string udfnHsn(int ViewType, int paraHsnId, int paraGstId, string paraHsnName, string paraHsnCode, int paraStatusId, string paraOriginator, string pbUserID, int paraDeleteFlag, int paraVerify)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_HSN", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraHsnId", paraHsnId);
                varSqlCommand.Parameters.AddWithValue("@paraGstId", paraGstId);
                varSqlCommand.Parameters.AddWithValue("@paraHsnName", paraHsnName);
                varSqlCommand.Parameters.AddWithValue("@paraHsnCode", paraHsnCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraVerify", paraVerify);
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
        public DataSet udfnHsnList(int ViewType, int paraHSNID, int paraGstId, int paraStatusId, string paraHSN_Name, string paraHSN_Code)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_HSN]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraHSNID", paraHSNID);
                varSqlCommand.Parameters.AddWithValue("@paraGstId", paraGstId);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraHSN_Name", paraHSN_Name);
                varSqlCommand.Parameters.AddWithValue("@paraHSN_Code", paraHSN_Code);
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
        public string udfnUnit(int paraviewType, int paraUnitId, string paraUnitName, string paraUnitSymbol, int paraUnitDecimal, int paraUnitStatusId, string paraOriginator, string paraInvoiceUnit, string paraUserID, int paraBulkUnit, int paraDeleteFlag)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_Unit]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUnitId", paraUnitId);
                varSqlCommand.Parameters.AddWithValue("@paraUnitName", paraUnitName);
                varSqlCommand.Parameters.AddWithValue("@paraUnitSymbol", paraUnitSymbol);
                varSqlCommand.Parameters.AddWithValue("@paraUnitDecimal", paraUnitDecimal);
                varSqlCommand.Parameters.AddWithValue("@paraUnitStatusId", paraUnitStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraInvoiceUnit", paraInvoiceUnit);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraBulkUnit", paraBulkUnit);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnUnitList(int paraviewType, int paraUnitid, int paraProductID)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Unit]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUnitid", paraUnitid);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraProductID", paraProductID);
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
        public string udfnCity(int paraviewType, int paraCityId, string paraStateId, string paraCityName, int paraStatusId, string paraOriginator, string paraUserID, int paraDeleteFlag)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_City]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", paraCityId);
                varSqlCommand.Parameters.AddWithValue("@paraStateId", paraStateId);
                varSqlCommand.Parameters.AddWithValue("@paraCityName", paraCityName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Created By :-Sathish ; Created On :-11/08/2023 Modified by:- 28/09/2023 two places repeated use this Citylist so clear one
        public DataSet udfnCitylist(int ViewType, string paraCityName, int paraStateId, int paraStatus)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRG_City", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCityName", paraCityName);
                varSqlCommand.Parameters.AddWithValue("@paraStateId", paraStateId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", paraStatus);

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
        public string udfnStockTransfer(int ViewType, int paraStockTransferID, int ParaCompanycode, string paraTransferDate, int paraSLocationID, int paraDLocationID, string paraRemarks, int paraStatusId, string paraOriginator, DataTable paraStockTransfer, int paraDeleteFlag, int paraTransactionType, int paraFlag, int paraSRQID)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_StockTransfer]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraStockTransferID", paraStockTransferID);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraTransferDate", paraTransferDate);
                varSqlCommand.Parameters.AddWithValue("@paraSLocationID", paraSLocationID);
                varSqlCommand.Parameters.AddWithValue("@paraDLocationID", paraDLocationID);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraStockTransfer", paraStockTransfer);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionType", paraTransactionType);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraSRQID", paraSRQID);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnStockTransferList(int paraViewType, int paraStockTransferID, int paraConcern, int paraSLID, int paraDLID, int paraPRID, int paraStatus, string ParaSTFromDate, string ParaSTToDate, int paraSRQID, int paraFlag,string paraUserLocations)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_StockTransfer]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraStockTransferID", paraStockTransferID);
                varSqlCommand.Parameters.AddWithValue("@paraConcern", paraConcern);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraDLID", paraDLID);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", paraPRID);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", paraStatus);
                varSqlCommand.Parameters.AddWithValue("@ParaSTFromDate", ParaSTFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaSTToDate", ParaSTToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSRQID", paraSRQID);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", paraUserLocations);
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
        //Added By Sathish On:-09-11-2023
        public string udfnDamageEntry(TRN_Damage objTRN_Damage)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Damage]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_Damage.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraDamageEntryID", objTRN_Damage.paraDamageEntryID);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", objTRN_Damage.ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraTransferDate", objTRN_Damage.paraTransferDate);
                varSqlCommand.Parameters.AddWithValue("@paraLocationID", objTRN_Damage.paraLocationID);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_Damage.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRN_Damage.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_Damage.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDamageEntry", objTRN_Damage.paraDamageEntry);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_Damage.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraEmployeeId", objTRN_Damage.paraEmployeeId);
                varSqlCommand.Parameters.AddWithValue("@paraSHID", objTRN_Damage.paraSHID);
                varSqlCommand.Parameters.AddWithValue("@paraQrimg", objTRN_Damage.paraQrimg);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Added By Sathish On:-01-12-2023
        public string udfnStockRequest(TRN_StockRequest objTRNS_StockRequest)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_StockRequest]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNS_StockRequest.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraStockRequestID", objTRNS_StockRequest.paraStockRequestID);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", objTRNS_StockRequest.ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraRequestDate", objTRNS_StockRequest.paraRequestDate);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRNS_StockRequest.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRNS_StockRequest.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRNS_StockRequest.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRNS_StockRequest.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraStockRequest", objTRNS_StockRequest.paraStockRequest);
                varSqlCommand.Parameters.AddWithValue("@paraQrimg", objTRNS_StockRequest.paraQrimg);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnStockRequestList(TRN_StockRequest objTRNG_StockRequest)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_StockRequest]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTRNG_StockRequest.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraStockRequestID", objTRNG_StockRequest.paraStockRequestID);
                varSqlCommand.Parameters.AddWithValue("@paraConcern", objTRNG_StockRequest.ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRNG_StockRequest.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRNG_StockRequest.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", objTRNG_StockRequest.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@ParaSTFromDate", objTRNG_StockRequest.ParaSTFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaSTToDate", objTRNG_StockRequest.ParaSTToDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRNG_StockRequest.paraUserLocations);
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
        //Added By Sathish On:-28-11-2023
        public DataSet udfnStock(TRN_Stock objTRNG_Stock)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Stock]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNG_Stock.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRNG_Stock.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@paraCOMID", objTRNG_Stock.paraCOMID);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRNG_Stock.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraMonth", objTRNG_Stock.paraMonth);
                varSqlCommand.Parameters.AddWithValue("@paraPICode", objTRNG_Stock.paraPICode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupID", objTRNG_Stock.paraGroupID);
                varSqlCommand.Parameters.AddWithValue("@paraSubGroupID", objTRNG_Stock.paraSubGroupID);
                varSqlCommand.Parameters.AddWithValue("@paraBrandID", objTRNG_Stock.paraBrandID);
                varSqlCommand.Parameters.AddWithValue("@paraStockType", objTRNG_Stock.paraStockType);
                varSqlCommand.Parameters.AddWithValue("@paraDays", objTRNG_Stock.paraDays);
                varSqlCommand.Parameters.AddWithValue("@paraOrder", objTRNG_Stock.paraOrder);
                varSqlCommand.Parameters.AddWithValue("@paraFilterType", objTRNG_Stock.paraFilterType);
                varSqlCommand.Parameters.AddWithValue("@paraUserId", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIpAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRNG_Stock.paraUserLocations);
                varSqlCommand.Parameters.AddWithValue("@paraProductCategory", objTRNG_Stock.paraCategoryID); 
                varSqlCommand.Parameters.AddWithValue("@paraType", objTRNG_Stock.paraType);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRNG_Stock.paraSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraAlpha", objTRNG_Stock.paraAlpha);
                varSqlCommand.Parameters.AddWithValue("@paraBlockedFlag", objTRNG_Stock.paraBlockedFlag);
                varSqlCommand.Parameters.AddWithValue("@paraReportType", objTRNG_Stock.paraReportType);
                varSqlCommand.Parameters.AddWithValue("@paraNameType", objTRNG_Stock.paraNameType);
                varSqlCommand.Parameters.AddWithValue("@paraDate", objTRNG_Stock.paraDate);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objTRNG_Stock.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRNG_Stock.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRNG_Stock.paraToDate);


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
        //Added By Sivabharathi  on 11/04/2024
        public DataSet udfnItemMovementAnalysis(TRN_Item_Movement_Analysis objTRN_Item_Movement_Analysis)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Report_ItemMovementAnalaysis]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@Viewtype", objTRN_Item_Movement_Analysis.Viewtype);
                varSqlCommand.Parameters.AddWithValue("@paraProductId", objTRN_Item_Movement_Analysis.paraProductId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_Item_Movement_Analysis.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationId", objTRN_Item_Movement_Analysis.paraLocationId);
                varSqlCommand.Parameters.AddWithValue("@paraRackId", objTRN_Item_Movement_Analysis.paraRackId);
                varSqlCommand.Parameters.AddWithValue("@parafromdate", objTRN_Item_Movement_Analysis.parafromdate);
                varSqlCommand.Parameters.AddWithValue("@paratodate", objTRN_Item_Movement_Analysis.paratodate);
                varSqlCommand.Parameters.AddWithValue("@paraLocation", objTRN_Item_Movement_Analysis.paraLocation);
                varSqlCommand.Parameters.AddWithValue("@paraRack", objTRN_Item_Movement_Analysis.paraRack);
                varSqlCommand.Parameters.AddWithValue("@paraMRP", objTRN_Item_Movement_Analysis.paraMRP);
                varSqlCommand.Parameters.AddWithValue("@paraBatchNo", objTRN_Item_Movement_Analysis.paraBatchNo);
                varSqlCommand.Parameters.AddWithValue("@paraExpiryDate", objTRN_Item_Movement_Analysis.paraExpiryDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserId", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIpAddress", MainForm.pbIpAddress);
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
        // added by venkat on 16/10/2023 for purchase damage list
        public DataSet udfnproductDamage(int paraViewType, int paraDamageEntryID, int ParaSupplierId, int ParaScheduleId, int paraCompanyID, int paraStatus, string ParaDMFromDate, string ParaDMToDate, string paraSuppliername)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Damage]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraDamageEntryID", paraDamageEntryID);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@ParaScheduleId", ParaScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyID", paraCompanyID);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", paraStatus);
                varSqlCommand.Parameters.AddWithValue("@ParaDMFromDate", ParaDMFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaDMToDate", ParaDMToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSuppliername", paraSuppliername);
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
        public DataSet udfnSINO(int ViewType, int paraID)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNG_SINO", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraID", paraID);
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
        public DataSet udfnStatelist(int paraViewType, int paraStatus)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRG_State", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", paraStatus);

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
        //Created By :-Sathish ; Created On :-24/08/2023
        public string udfnBroker(int paraviewType, int paraBrokerId, int paraConcern, string paraBrokerConcern, string paraGstinNo, string paraBrokerName,
            string paraAddressLine1, string paraAddressLine2, int paraStateId, int paraCityId, string paraPincode, string paraWhatsappNumber,
            string paraMobileNumber, int paraStatusId, string paraOriginator, DataTable ParaMR_Broker_Bank, string paraUserID, int paraDeleteFlag)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_Broker]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerId", paraBrokerId);
                varSqlCommand.Parameters.AddWithValue("@paraConcernId", paraConcern);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerConcern", paraBrokerConcern);
                varSqlCommand.Parameters.AddWithValue("@paraGstinNo", paraGstinNo);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerName", paraBrokerName);
                varSqlCommand.Parameters.AddWithValue("@paraAddressLine1", paraAddressLine1);
                varSqlCommand.Parameters.AddWithValue("@paraAddressLine2", paraAddressLine2);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", paraCityId);
                varSqlCommand.Parameters.AddWithValue("@paraStateId", paraStateId);
                varSqlCommand.Parameters.AddWithValue("@paraPincode", paraPincode);
                varSqlCommand.Parameters.AddWithValue("@paraWhatsappNumber", paraWhatsappNumber);
                varSqlCommand.Parameters.AddWithValue("@paraMobileNumber", paraMobileNumber);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@ParaMR_Broker_Bank", ParaMR_Broker_Bank);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Created By :-Sathish ; Created On :-24/08/2023
        public DataSet udfnBrokerList(int paraviewType, int paraBrokerId, int paraStatusId, int paraCityId, string paraBrokerName)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Broker]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerId", paraBrokerId);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", paraCityId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerName", paraBrokerName);
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
        public string udfnStockLocation(int paraviewType, int paraStockId, int paraConcern, int paraLocationType, string paraLocationNameEnglish, string paraLocationNameTamil, string paraShortName, int paraGodownType, int paraStockApplicable, int paraStockStatusId, string paraOriginator, string paraUserID, int paraRKCreation, int paraRKGCreation, int paraDeleteFlag)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_StockLocation]", tmpspcall.objConn);
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
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraRKCreation", paraRKCreation);
                varSqlCommand.Parameters.AddWithValue("@paraRKGCreation", paraRKGCreation);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnStockLocationList(MR_Location objMR_Location)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_StockLocation]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;

                if (string.IsNullOrWhiteSpace(objMR_Location.paraUserLocations))
                {
                    objMR_Location.paraUserLocations = MainForm.pbUserMappedLocationIds;
                }

                varSqlCommand.Parameters.AddWithValue("@ViewType", objMR_Location.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraConcern", objMR_Location.ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraStockLocation", objMR_Location.paraLocationId);
                varSqlCommand.Parameters.AddWithValue("@paraId", objMR_Location.paraId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationName", objMR_Location.paraLocationName);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroupid", objMR_Location.paraSubgroup);
                varSqlCommand.Parameters.AddWithValue("@paraRackId", objMR_Location.paraRackId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationType", objMR_Location.paraLocationType);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objMR_Location.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@ParaFromDate", objMR_Location.ParaFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaToDate", objMR_Location.ParaToDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objMR_Location.paraUserLocations);
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
        public string udfnRack(int paraViewType, int paraRackId, int paraConcern, int paraStockLocation, string paraRackName, string paraShortName, string paraDescription, int paraStatusId, string paraOriginator, int paraDeleteFlag)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_Rack]", tmpspcall.objConn);
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
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnRackList(int paraviewType, int paraRackGroup, int paraConcernId, int paraStockLocationId, int paraRackId, string paraRackName, int paraSubGroupID, int paraStatusId)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Rack]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraRackGroup", paraRackGroup);
                varSqlCommand.Parameters.AddWithValue("@paraConcernId", paraConcernId);
                varSqlCommand.Parameters.AddWithValue("@paraStockLocationId", paraStockLocationId);
                varSqlCommand.Parameters.AddWithValue("@paraRackId", paraRackId);
                varSqlCommand.Parameters.AddWithValue("@paraRackName", paraRackName);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraSubGroupID", paraSubGroupID);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
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
        //Created BY:-Sathish  Created On:-02-09-2023
        public string udfnRackSettings(int paraviewType, int paraRKSID, int paraRKSSSLID, int paraRKSSRKID, string paraRKSPRID, int paraRKSDSLID, int paraRKSDRKID, string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_RackSettings]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraRKSID", paraRKSID);
                varSqlCommand.Parameters.AddWithValue("@paraRKSSSLID", paraRKSSSLID);
                varSqlCommand.Parameters.AddWithValue("@paraRKSSRKID", paraRKSSRKID);
                varSqlCommand.Parameters.AddWithValue("@paraRKSPRID", paraRKSPRID);
                varSqlCommand.Parameters.AddWithValue("@paraRKSDSLID", paraRKSDSLID);
                varSqlCommand.Parameters.AddWithValue("@paraRKSDRKID", paraRKSDRKID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Created By :-Sathish ; Created On :-02/09/2023
        public DataSet udfnRackSettingsList(int paraviewType, int paraRKSID, int paraRack, int paraLocationID, int paraRackID)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_RackSettings]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraRKSID", @paraRKSID);
                varSqlCommand.Parameters.AddWithValue("@paraRack", paraRack);
                varSqlCommand.Parameters.AddWithValue("@paraLocationID", @paraLocationID);
                varSqlCommand.Parameters.AddWithValue("@paraRackID", @paraRackID);
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
        public string udfnUserCategory(int paraviewType, int paraUserCategoryId, string paraUserCategoryName, int paraStatusId, int paraSINO, string paraOriginator, string paraUserID, int paraDeleteFlag, string paraModules)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_UserCategory]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserCategoryId", paraUserCategoryId);
                varSqlCommand.Parameters.AddWithValue("@paraUserCategoryName", paraUserCategoryName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraSINO", paraSINO);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraModules", paraModules);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnUserCategoryList(int paraviewType, int paraCategory, string paraCategoryName, int paraStatusId)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_UserCategory]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraCategory", paraCategory);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraCategoryName", paraCategoryName);
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
        public string udfnUser(int paraviewType, int paraUId, string paraNameoftheUser, string paraLoginId, int paraUserCategory, int paraUserRole, string paraPassword, int paraPassKey, int paraStatusId, string paraPasskeyValue, string paraOriginator, string paraUserID, int paraDeleteFlag,DataTable ParaUserLocation,int paraLogType)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_User]", tmpspcall.objConn);
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
                varSqlCommand.Parameters.AddWithValue("@paraPasskeyValue", @paraPasskeyValue);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@ParaUserLocation", ParaUserLocation);
                varSqlCommand.Parameters.AddWithValue("@paraLogType", paraLogType);
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
        public string udfnGroup(int ViewType, int paraPRGID, string paraPRG_EName, string paraPRG_TName, int paraStatusId, string paraOriginator, string paraUserID, int paraDeleteFlag)
        {

            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_ProductGroup", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraPRGID", paraPRGID);
                varSqlCommand.Parameters.AddWithValue("@paraPRG_EName", paraPRG_EName);
                varSqlCommand.Parameters.AddWithValue("@paraPRG_TName", paraPRG_TName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnGroupList(int ViewType, int paraPRGID, int paraID, string paraGroupName, int paraStatusCode)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_ProductGroup]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraPRGID", paraPRGID);
                varSqlCommand.Parameters.AddWithValue("@paraID", paraID);
                varSqlCommand.Parameters.AddWithValue("@paraGroupName", paraGroupName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusCode", paraStatusCode);
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
        public string udfnSubGroup(int ViewType, int paraPRSGID, int paraPRSG_PRGID, string paraPRSG_EName, string paraPRSG_TName, int paraStatusId, int paraSG_BatchNo, int paraPRSG_SLID, int paraPRSG_RKID, string paraOriginator, string varRackId, string paraUserID, int paraDeleteFlag,int paraSubgroupType)
        {

            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_ProductSubGroup", tmpspcall.objConn);
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
                varSqlCommand.Parameters.AddWithValue("@paraRKIds", varRackId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroupType", paraSubgroupType);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnSubGroupList(int ViewType, int paraPRSGID, string paraPRGIDs, int paraPRGID, int paraID, string paraPRSG_EName, int paraStatusID, int paraBatchNo, int paraSLId, int paraRKId,int paraSubgroupType)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_ProductSubGroup]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraPRSGID", paraPRSGID);
                varSqlCommand.Parameters.AddWithValue("@paraPRGID", paraPRGID);
                varSqlCommand.Parameters.AddWithValue("@paraID", paraID);
                varSqlCommand.Parameters.AddWithValue("@paraPRGIDs", paraPRGIDs);
                varSqlCommand.Parameters.AddWithValue("@paraPRSG_EName", paraPRSG_EName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@paraBatchNo", paraBatchNo);
                varSqlCommand.Parameters.AddWithValue("@paraSLId", paraSLId);
                varSqlCommand.Parameters.AddWithValue("@paraRKId", paraRKId);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroupType", paraSubgroupType);
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
        public DataSet udfnUserList(int paraviewType, string paraUserName, string paraLoginId, string paraPassword, int paraUser, int paraStatusId, string @paraPasskey)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_User]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserName", paraUserName);
                varSqlCommand.Parameters.AddWithValue("@paraLoginId", paraLoginId);
                varSqlCommand.Parameters.AddWithValue("@paraPassword", paraPassword);
                varSqlCommand.Parameters.AddWithValue("@paraPasskey", @paraPasskey);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUser", paraUser);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraSystemName", Dns.GetHostName());

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
              int paraBatchNoGeneration, int paraShelfLife, double paranetweight, double paraMaxstk, double paraGrossweight, double paraMinstk,
              double paraReorderQty, double paraRetailMinstk, double paraRetailrate, double paraWMinqty, double paraWsaleRate, string paraBarcode, int paraHSNCode
             , int paraRMPROD, int paraShelflifeValue, int paraShelflifeType, string paraStatusId, string paraUserID, string paraIPAddress, string paraOriginator,
              int paraNetQtyUnit, DataTable paraMR_Product_BulkUpdate, int paraDeleteflag, string paraIDs, int paraSupplierId, int paraScheduleId, int paraGRNId,
              int paraNewPRID, int paraMRPFlag,DataTable ParaProduct_HSN,string paraProductLabelNameEng,string paraProductLabelNameTam,string paraParentId,int paraSalesProduct,string paraInactiveTeller,string paraImageNames,int paraIntermediateUPP,int paraIntermediateUnit,int paraProductionMSQ)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_Product", tmpspcall.objConn);
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
                varSqlCommand.Parameters.AddWithValue("@paraNetQtyUnit", paraNetQtyUnit);
                varSqlCommand.Parameters.AddWithValue("@paraMR_Product_BulkUpdate", paraMR_Product_BulkUpdate);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteflag", paraDeleteflag);
                varSqlCommand.Parameters.AddWithValue("@paraIDs", paraIDs);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierId", paraSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleId", paraScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraGRNId", paraGRNId);
                varSqlCommand.Parameters.AddWithValue("@paraNewPRID", paraNewPRID);
                varSqlCommand.Parameters.AddWithValue("@paraMRPFlag", paraMRPFlag);
                varSqlCommand.Parameters.AddWithValue("@ParaProduct_HSN", ParaProduct_HSN);
                varSqlCommand.Parameters.AddWithValue("@paraProductLabelNameEng", paraProductLabelNameEng);
                varSqlCommand.Parameters.AddWithValue("@paraProductLabelNameTam", paraProductLabelNameTam);
                varSqlCommand.Parameters.AddWithValue("@paraParentId", paraParentId);
                varSqlCommand.Parameters.AddWithValue("@paraSalesProduct", paraSalesProduct);
                varSqlCommand.Parameters.AddWithValue("@paraInactiveTeller", paraInactiveTeller);
                varSqlCommand.Parameters.AddWithValue("@paraImageNames", paraImageNames);
                varSqlCommand.Parameters.AddWithValue("@paraIntermediateUPP", paraIntermediateUPP);
                varSqlCommand.Parameters.AddWithValue("@paraIntermediateUnit", paraIntermediateUnit);
                varSqlCommand.Parameters.AddWithValue("@paraProductionMSQ", paraProductionMSQ);

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
        public DataSet udfnproductmasterlist(MR_Product objMR_Product)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRG_Product", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objMR_Product.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaProductCode", objMR_Product.ParaProductCode);
                varSqlCommand.Parameters.AddWithValue("@paraProductCategory", objMR_Product.paraProductCategory);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", objMR_Product.paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroup", objMR_Product.paraSubgroup);
                varSqlCommand.Parameters.AddWithValue("@paraPicode", objMR_Product.paraPicode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", objMR_Product.ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@ParaScheduleid", objMR_Product.ParaScheduleid);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleDay", objMR_Product.paraScheduleDay);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objMR_Product.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraBrandID", objMR_Product.paraBrandID);
                varSqlCommand.Parameters.AddWithValue("@paraRackId", objMR_Product.paraRackId);
                varSqlCommand.Parameters.AddWithValue("@paraHsnId", objMR_Product.paraHsnId);
                varSqlCommand.Parameters.AddWithValue("@paraGstId", objMR_Product.paraGstId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationId", objMR_Product.paraLocationId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationType", objMR_Product.paraLocationType);
                varSqlCommand.Parameters.AddWithValue("@paraGodownType", objMR_Product.paraGodownType);
                varSqlCommand.Parameters.AddWithValue("@paraRKGId", objMR_Product.paraRKGId);
                varSqlCommand.Parameters.AddWithValue("@paraEMPId", objMR_Product.paraEMPId);
                varSqlCommand.Parameters.AddWithValue("@paraProductName", objMR_Product.paraProductName);
                varSqlCommand.Parameters.AddWithValue("@paraStockTransfer", objMR_Product.paraStockTransfer);
                varSqlCommand.Parameters.AddWithValue("@paraDamageEntry", objMR_Product.paraDamageEntry);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", objMR_Product.ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@ParaProductsCode", objMR_Product.ParaProductsCode);
                varSqlCommand.Parameters.AddWithValue("@paraHSNCode", objMR_Product.paraHSNCode);
                varSqlCommand.Parameters.AddWithValue("@paraId", objMR_Product.paraId);
                varSqlCommand.Parameters.AddWithValue("@ParaFromDate", objMR_Product.ParaFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaToDate", objMR_Product.ParaToDate);
                varSqlCommand.Parameters.AddWithValue("@ParaGRNID", objMR_Product.ParaGRNID);
                varSqlCommand.Parameters.AddWithValue("@ParaRMFlag", objMR_Product.ParaRMFlag);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objMR_Product.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@ParaPOID", objMR_Product.ParaPOID);
                varSqlCommand.Parameters.AddWithValue("@ParaDCID", objMR_Product.ParaDCID);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseAutoComplete", objMR_Product.paraPurchaseAutoComplete);
                varSqlCommand.Parameters.AddWithValue("@paraCreatedON", objMR_Product.paraCreatedON);
                varSqlCommand.Parameters.AddWithValue("@paraLabelCount", objMR_Product.paraLabelCount);
                varSqlCommand.Parameters.AddWithValue("@paraType", objMR_Product.paraType);
                varSqlCommand.Parameters.AddWithValue("@ParaMRP", objMR_Product.ParaMRP);
                varSqlCommand.Parameters.AddWithValue("@ParaRetail", objMR_Product.ParaRetail);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroupType", objMR_Product.paraSubgroupType);
                varSqlCommand.Parameters.AddWithValue("@paraFilterDate", objMR_Product.paraFilterDate);
                varSqlCommand.Parameters.AddWithValue("@paraTeller", objMR_Product.paraTeller);
                varSqlCommand.Parameters.AddWithValue("@paraUserCode", objMR_Product.paraUserCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objMR_Product.paraUserLocations);
                varSqlCommand.Parameters.AddWithValue("@paraProductType", objMR_Product.paraProductType);
                varSqlCommand.Parameters.AddWithValue("@paraRackStatusID", objMR_Product.paraRackStatusID);
                varSqlCommand.Parameters.AddWithValue("@paraStockAdjustment", objMR_Product.paraStockAdjustment);
                varSqlCommand.Parameters.AddWithValue("@ParaOrderby", objMR_Product.ParaOrderby);
                varSqlCommand.Parameters.AddWithValue("@ParaRate", objMR_Product.ParaRate);
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


        public string udfnBrand(int ViewType, int paraBDID, string paraBD_EName, string paraBD_TName, int paraStatusId, string paraPRSGID, string paraOriginator, string paraUserID, int paraDeleteflag)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_Brand", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraBDID", @paraBDID);
                varSqlCommand.Parameters.AddWithValue("@paraBD_EName", paraBD_EName);
                varSqlCommand.Parameters.AddWithValue("@paraBD_TName", paraBD_TName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraPRSGID", paraPRSGID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteflag", paraDeleteflag);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnBrandList(int ViewType, string paraBDID, int paraGroupId, int paraSubGroupId, int paraREPBRAND, string paraBrandName, int paraStatusId)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Brand]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraBDID", paraBDID);
                varSqlCommand.Parameters.AddWithValue("@paraGroupId", paraGroupId);
                varSqlCommand.Parameters.AddWithValue("@paraSubGroupId", @paraSubGroupId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraREPBRAND", paraREPBRAND);
                varSqlCommand.Parameters.AddWithValue("@paraBrandName", paraBrandName);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
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

        // Sivabharathi    Create date: 24/08/2023    Description:Rack Group SP
        public string udfnRackGroup(int ViewType, int paraRKGID, int paraRKG_COMID, string paraRKG_Name, string paraRKGR_RKID, string paraRKGU_UID, int paraStatusId, string paraOriginator, string paraUserID, int paraDeleteFlag,int paraRKGOrderNo)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_RackGroup]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraRKGID", paraRKGID);
                varSqlCommand.Parameters.AddWithValue("@paraRKG_COMID", paraRKG_COMID);
                varSqlCommand.Parameters.AddWithValue("@paraRKG_Name", paraRKG_Name);
                varSqlCommand.Parameters.AddWithValue("@paraRKGR_RKID", paraRKGR_RKID);
                varSqlCommand.Parameters.AddWithValue("@paraRKGU_UID", paraRKGU_UID);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraRKGOrderNo", paraRKGOrderNo);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        // Sivabharathi    Create date: 24/08/2023    Description:Rack Group List SP
        public DataSet udfnRackGroupList(int ViewType, int paraCompanyId, int paraLocationId, int paraRackGroupId, int paraStatusId, string paraRKGName,int paraProductStatusID)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_RackGroup]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationId", paraLocationId);
                varSqlCommand.Parameters.AddWithValue("@paraRackGroupId", paraRackGroupId);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraRKGName", paraRKGName);
                varSqlCommand.Parameters.AddWithValue("@paraProductStatusID", paraProductStatusID);
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
        // Sivabharathi    Create date: 24/08/2023    Description:Rack ProductDetails List SP
        public DataSet udfnProductDetailsList(int ViewType, int paraRackID)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_ProductDetails]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraRackID", paraRackID);
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
        // Created by Venkat
        //Create date: 21/08/2023 
        //Description:	repmaster
        public string udfnRepMaster(int ViewType, int paraRepId, string paraRepName, string paracompanyname, string paraphoneno, string parawhatsapp, string paraBrandID, int ParaStatus, string paraOriginator, string paraUserID, int paraDeleteFlag)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_Representative", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraRepId", paraRepId);
                varSqlCommand.Parameters.AddWithValue("@paraRepName", paraRepName);
                varSqlCommand.Parameters.AddWithValue("@paracompanyname", paracompanyname);
                varSqlCommand.Parameters.AddWithValue("@paraphoneno", paraphoneno);
                varSqlCommand.Parameters.AddWithValue("@parawhatsapp", parawhatsapp);
                varSqlCommand.Parameters.AddWithValue("@paraBrandID", paraBrandID);
                varSqlCommand.Parameters.AddWithValue("@ParaStatus", ParaStatus);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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


        // Created by Venkat
        //Create date: 21/08/2023 
        //Description:	repmasterList

        public DataSet udfnRepMasterList(int ViewType, int paraRepId, string paraUserID, string paraIPAddress, int paraStatusId)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRG_Representative", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraRepId", paraRepId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);

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

        //Supplier Master 
        //created by Venkat,Created on 22/08/2023
        //modified by venkat for product mapping in each schedule
        public string udfnSupplierMaster(int ViewType, int paraSupplierid, string paraSupplierName, string paraAddress1,
            string paraAddress2, int paraCityId, string paraPincode, string paraPhoneNumber, string paraWhatsappNumber, string paraMobileNumber,
              string paraEmail, string paraGstin, int paraPaymentterm, int paraReturnApplicable, int paraReturnCycle,
               int paraopeningType, double paraOpeningBal, int paraSupplierType, int parastateid, string paraStatusId, string paraUserID, string paraIPAddress, string paraOriginator
            , int paraDesignation, string paraDesignationName, double paraCreditLimit, int paraDayid, int paramonthid, int paraweekid, int paradaymonthid,
              string paraSalesmanName, string paraSchedulename, string paraSalesmanMobile, string paraSalesmanWhatsapp, int paraSaleOrderType, string ParaOrderDays,
              int ParaSupplierOrderid, int paraordertype, string ParaProductId,  string paraBranchName,
              string paraAccNo, string paraIFSC, string paraAccountName, string paraBrand, string ParaSupplierPayment, int paraDeleteFlag, string paraShortName, int paraTat, int paraFlag, int paraDiscApplicable, int paraDiscDays, int paraDiscPer, int paraScheduleId, int paraReason, string paraTallyName, string paraBankDate,int paraBankID,
              DataTable ParaMR_Supplier_OpeningBalance,int paraDrConcernID)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_Supplier", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierid", paraSupplierid);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierName", paraSupplierName);
                varSqlCommand.Parameters.AddWithValue("@paraAddress1", paraAddress1);
                varSqlCommand.Parameters.AddWithValue("@paraAddress2", paraAddress2);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", paraCityId);
                varSqlCommand.Parameters.AddWithValue("@paraPincode", paraPincode);
                varSqlCommand.Parameters.AddWithValue("@paraPhoneNumber", paraPhoneNumber);
                varSqlCommand.Parameters.AddWithValue("@paraWhatsappNumber", paraWhatsappNumber);
                varSqlCommand.Parameters.AddWithValue("@paraMobileNumber", paraMobileNumber);
                varSqlCommand.Parameters.AddWithValue("@paraEmail", paraEmail);
                varSqlCommand.Parameters.AddWithValue("@paraGSTIN", paraGstin);
                varSqlCommand.Parameters.AddWithValue("@paraPaymentterm", paraPaymentterm);
                varSqlCommand.Parameters.AddWithValue("@paraReturnApplicable", paraReturnApplicable);
                varSqlCommand.Parameters.AddWithValue("@paraReturnCycle", paraReturnCycle);
                varSqlCommand.Parameters.AddWithValue("@parastateid", parastateid);
                varSqlCommand.Parameters.AddWithValue("@paraopeningType", paraopeningType);
                varSqlCommand.Parameters.AddWithValue("@paraOpeningBal", paraOpeningBal);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierType", paraSupplierType);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDesignation", paraDesignation);
                varSqlCommand.Parameters.AddWithValue("@paraDesignationName", paraDesignationName);
                varSqlCommand.Parameters.AddWithValue("@paraCreditLimit", paraCreditLimit);
                varSqlCommand.Parameters.AddWithValue("@paraDayid", paraDayid);
                varSqlCommand.Parameters.AddWithValue("@paramonthid", paramonthid);
                varSqlCommand.Parameters.AddWithValue("@paraweekid", paraweekid);
                varSqlCommand.Parameters.AddWithValue("@paradaymonthid", paradaymonthid);

                varSqlCommand.Parameters.AddWithValue("@paraSalesmanName", paraSalesmanName);
                varSqlCommand.Parameters.AddWithValue("@paraSchedulename", paraSchedulename);
                varSqlCommand.Parameters.AddWithValue("@paraSalesmanMobile", paraSalesmanMobile);
                varSqlCommand.Parameters.AddWithValue("@paraSalesmanWhatsapp", paraSalesmanWhatsapp);
                varSqlCommand.Parameters.AddWithValue("@paraSaleOrderType", paraSaleOrderType);
                varSqlCommand.Parameters.AddWithValue("@ParaOrderDays", ParaOrderDays);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierOrderid", ParaSupplierOrderid);
                varSqlCommand.Parameters.AddWithValue("@paraordertype", paraordertype);
                varSqlCommand.Parameters.AddWithValue("@ParaProductId", ParaProductId);

                varSqlCommand.Parameters.AddWithValue("@paraDiscApplicable", paraDiscApplicable);
                varSqlCommand.Parameters.AddWithValue("@paraDiscDays", paraDiscDays);
                varSqlCommand.Parameters.AddWithValue("@paraDiscPer", paraDiscPer);
                 
                varSqlCommand.Parameters.AddWithValue("@paraBranchName", paraBranchName);
                varSqlCommand.Parameters.AddWithValue("@paraAccNo", paraAccNo);
                varSqlCommand.Parameters.AddWithValue("@paraIFSC", paraIFSC);
                varSqlCommand.Parameters.AddWithValue("@paraAccountName", paraAccountName);
                varSqlCommand.Parameters.AddWithValue("@paraBrand", paraBrand);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierPayment", ParaSupplierPayment);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraShortName", paraShortName);
                varSqlCommand.Parameters.AddWithValue("@paraTat", paraTat);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleId", paraScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraReason", paraReason);
                varSqlCommand.Parameters.AddWithValue("@paraTallyName", paraTallyName);
                varSqlCommand.Parameters.AddWithValue("@paraBankTransactionDate", paraBankDate);
                varSqlCommand.Parameters.AddWithValue("@paraBankID", paraBankID);
                varSqlCommand.Parameters.AddWithValue("@ParaMR_Supplier_OpeningBalance", ParaMR_Supplier_OpeningBalance);
                varSqlCommand.Parameters.AddWithValue("@paraDrConcernID", paraDrConcernID);
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
        public DataSet udfnSupplierList(MR_Supplier objMR_Supplier)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Supplier]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objMR_Supplier.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierid", objMR_Supplier.paraSupplierid);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierScheduleid", objMR_Supplier.paraSupplierScheduleid);
                varSqlCommand.Parameters.AddWithValue("@pardayid", objMR_Supplier.pardayid);
                varSqlCommand.Parameters.AddWithValue("@paraOrderId", objMR_Supplier.paraOrderId);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierName", objMR_Supplier.paraSupplierName);
                varSqlCommand.Parameters.AddWithValue("@paraordertype", objMR_Supplier.paraordertype);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objMR_Supplier.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanycode", objMR_Supplier.paraCompanycode);
                varSqlCommand.Parameters.AddWithValue("@ParaPOID", objMR_Supplier.ParaPOID);
                varSqlCommand.Parameters.AddWithValue("@paraProductType", objMR_Supplier.paraProductType);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", objMR_Supplier.paraCityId);
                varSqlCommand.Parameters.AddWithValue("@paraStateId", objMR_Supplier.paraStateId);
                varSqlCommand.Parameters.AddWithValue("@paraGstType", objMR_Supplier.paraGstType);
                varSqlCommand.Parameters.AddWithValue("@paraPaymentTerm", objMR_Supplier.paraPaymentTerm);
                varSqlCommand.Parameters.AddWithValue("@paraReturnPolicy", objMR_Supplier.paraReturnPolicy);
                varSqlCommand.Parameters.AddWithValue("@paraProducts", objMR_Supplier.paraProducts);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objMR_Supplier.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@ParaFromDate", objMR_Supplier.ParaFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaToDate", objMR_Supplier.ParaToDate);
                varSqlCommand.Parameters.AddWithValue("@ParaGSTIN", objMR_Supplier.ParaGSTIN);
                varSqlCommand.Parameters.AddWithValue("@paraProductCode", objMR_Supplier.paraProductCode);
                varSqlCommand.Parameters.AddWithValue("@paraGroupCode", objMR_Supplier.paraGroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroupCode", objMR_Supplier.paraSubgroupCode);
                varSqlCommand.Parameters.AddWithValue("@paraBrandCode", objMR_Supplier.paraBrandCode);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierIds", objMR_Supplier.paraSupplierIds);
                varSqlCommand.Parameters.AddWithValue("@paraStickerCount", objMR_Supplier.paraStickerCount);
                varSqlCommand.Parameters.AddWithValue("@paraPayID", objMR_Supplier.paraPayID);
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
        /* Added by deepa on 11-09-2023 */
        public string udfnGetMessages(int paraId)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Messages]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraId", paraId);
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

        /* Added by deepa on 15-09-2023 */
        public string udfnGetPath(int paraViewType)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_SharedFolderPath]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
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
        /*Added by deepa on 19-09-2023*/
        public string udfnEmployee(int paraViewType, int paraEMPID, string paraEMPCode, string paraEMPName, int paraCTID, int paraSTSID, string paraOriginator, string paraUserID, int paraDeleteFlag,string paraEMPTName)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_Employee]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraEMPID", paraEMPID);
                varSqlCommand.Parameters.AddWithValue("@paraEMPCode", paraEMPCode);
                varSqlCommand.Parameters.AddWithValue("@paraEMPName", paraEMPName);
                varSqlCommand.Parameters.AddWithValue("@paraCTID", paraCTID);
                varSqlCommand.Parameters.AddWithValue("@paraSTSID", paraSTSID);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName); 
                varSqlCommand.Parameters.AddWithValue("@paraEMPTName", paraEMPTName);
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
        /*Added by deepa on 19-09-2023*/
        public DataSet udfnEmployeeList(int paraViewType, string paraEmpName, int paraEmpID, string paraEmpCode, int paraStatusId, int paraRKGID, int paraEmpCategory)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Employee]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraEmpName", paraEmpName);
                varSqlCommand.Parameters.AddWithValue("@paraEmpID", paraEmpID);
                varSqlCommand.Parameters.AddWithValue("@paraEmpCode", paraEmpCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraRKGID", paraRKGID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraEmpCategory", paraEmpCategory);
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

        // added by venkat on 13/10/2023 for PO.No. Save
        public string udfnPurchaseEntry(int paraViewType, int ParaPOID, int paraCompanyId, string paraPONumber, int paraSupplierID, int paraScheduleID, string paraLastTrnsno
            , string paraOriginator, string paraRemarks, string paraTAT, DataTable objPurchaseOrder, string paraIssuedDate, string paraIssuedBy, string paraIssuedMode, string paraIssuedModeRemarks, int paraFinalStatus, string paraPODate, int ParaUnitId, double paraTotalKg, int paraDeleteFlag)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_PO]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaPOID", ParaPOID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraPONumber", paraPONumber);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraLastTrnsno", paraLastTrnsno);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraTAT", paraTAT);
                varSqlCommand.Parameters.AddWithValue("@ParaTRN_PO_Product", objPurchaseOrder);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraIssuedDate", paraIssuedDate);
                varSqlCommand.Parameters.AddWithValue("@paraIssuedBy", paraIssuedBy);
                varSqlCommand.Parameters.AddWithValue("@paraIssuedMode", paraIssuedMode);
                varSqlCommand.Parameters.AddWithValue("@paraIssuedModeRemarks", paraIssuedModeRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraFinalStatus", paraFinalStatus);
                varSqlCommand.Parameters.AddWithValue("@paraPODate", paraPODate);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@ParaUnitId", ParaUnitId);
                varSqlCommand.Parameters.AddWithValue("@paraTotalKg", paraTotalKg);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                //varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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

        // added by venkat on 16/10/2023 for purchase damage list
        public DataSet udfnproductDamage(int paraViewType, int ParaSupplierId, int ParaScheduleId, int paraCompanyID)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_DAMAGE]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@ParaScheduleId", ParaScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyID", paraCompanyID);
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
        // Sivabharathi on 10/11/2023 -- Purchase DC 
        public string udfnPurchaseDc(TRN_Purchase_DC objTRNS_Purchase_DC)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Purchase_DC]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNS_Purchase_DC.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRNS_Purchase_DC.@paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRNS_Purchase_DC.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRNS_Purchase_DC.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRNS_Purchase_DC.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDC_Date", objTRNS_Purchase_DC.paraDC_Date);
                varSqlCommand.Parameters.AddWithValue("@paraDC_NO", objTRNS_Purchase_DC.paraDC_NO);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRNS_Purchase_DC.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", objTRNS_Purchase_DC.paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraDC_Remarks", objTRNS_Purchase_DC.paraDC_Remarks);
                varSqlCommand.Parameters.AddWithValue("@paraDC_DCNo", objTRNS_Purchase_DC.paraDC_DCNo);
                varSqlCommand.Parameters.AddWithValue("@paraDC_PURID", objTRNS_Purchase_DC.paraDC_PURID);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRNS_Purchase_DC.paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@paraDCID", objTRNS_Purchase_DC.paraDCID);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRNS_Purchase_DC.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@ParaVerify", objTRNS_Purchase_DC.ParaVerify);
                varSqlCommand.Parameters.AddWithValue("@ParaVerifyDate", objTRNS_Purchase_DC.ParaVerifyDate);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedTime", objTRNS_Purchase_DC.paraVerifiedTime);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedFormat", objTRNS_Purchase_DC.paraVerifiedFormat);
                varSqlCommand.Parameters.AddWithValue("@ParaTRN_Purchase_DC", objTRNS_Purchase_DC.ParaTRN_Purchase_DC);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        // Sivabharathi    Create date: 14/11/2023    Description: Purchase DC
        public DataSet udfnPurchaseDCList(TRN_Purchase_DC objTRNG_Purchase_DC)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Purchase_DC]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNG_Purchase_DC.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraDCID", objTRNG_Purchase_DC.paraDCID);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRNG_Purchase_DC.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRNG_Purchase_DC.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRNG_Purchase_DC.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRNG_Purchase_DC.paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", objTRNG_Purchase_DC.paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRNG_Purchase_DC.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRNG_Purchase_DC.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRNG_Purchase_DC.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraDCIDS", objTRNG_Purchase_DC.paraDCIDS);
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
        // Sivabharathi on 20/12/2023 -- Purchase return DC 
        public string udfnPurchaseReturnDc(TRN_ReturnDC objTRN_PurchaseReturnDC)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Purchase_ReturnDC]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTRN_PurchaseReturnDC.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_PurchaseReturnDC.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_PurchaseReturnDC.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRN_PurchaseReturnDC.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_PurchaseReturnDC.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraReturnDC_Date", objTRN_PurchaseReturnDC.paraReturnDC_Date);
                varSqlCommand.Parameters.AddWithValue("@paraReasonId", objTRN_PurchaseReturnDC.paraReasonId);
                varSqlCommand.Parameters.AddWithValue("@paraClosingReasonId", objTRN_PurchaseReturnDC.paraClosingReasonId);
                varSqlCommand.Parameters.AddWithValue("@paraReturnDC_NO", objTRN_PurchaseReturnDC.paraReturnDC_NO);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", objTRN_PurchaseReturnDC.ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@ParaScheduleID", objTRN_PurchaseReturnDC.ParaScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraCreditNoteNo", objTRN_PurchaseReturnDC.paraCreditNoteNo);
                varSqlCommand.Parameters.AddWithValue("@paraReturnDC_Remarks", objTRN_PurchaseReturnDC.paraReturnDC_Remarks);
                varSqlCommand.Parameters.AddWithValue("@paraExchangeRemarks", objTRN_PurchaseReturnDC.paraExchangeRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRN_PurchaseReturnDC.paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@ParaSubtotal", objTRN_PurchaseReturnDC.ParaSubtotal);
                varSqlCommand.Parameters.AddWithValue("@paraReturnDCAmount", objTRN_PurchaseReturnDC.paraReturnDCAmount);
                varSqlCommand.Parameters.AddWithValue("@paraTax", objTRN_PurchaseReturnDC.paraTax);
                varSqlCommand.Parameters.AddWithValue("@paraReturnDCID", objTRN_PurchaseReturnDC.paraReturnDCID);
                varSqlCommand.Parameters.AddWithValue("@paraCreditNoteDate", objTRN_PurchaseReturnDC.paraCreditNoteDate);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_PurchaseReturnDC.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraTRN_Purchase_ReturnDC", objTRN_PurchaseReturnDC.paraTRN_Purchase_ReturnDC);
                varSqlCommand.Parameters.AddWithValue("@ParaTRN_ReturnDCProducts", objTRN_PurchaseReturnDC.ParaTRN_ReturnDCProducts);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseId", objTRN_PurchaseReturnDC.paraPurchaseId);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedBy", objTRN_PurchaseReturnDC.paraVerifiedBy);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objTRN_PurchaseReturnDC.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraUpdateflag", objTRN_PurchaseReturnDC.paraUpdateflag);
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
        // added by venkat on 17/10/2023 for purchase damage list
        // Sivabharathi    Modified date: 20/12/2023    Description: Purchase Return DC
        public DataSet udfnReturnDC(TRN_ReturnDC objTRN_PurchaseReturnDC)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_PurchaseReturn_DC]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTRN_PurchaseReturnDC.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", objTRN_PurchaseReturnDC.ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRN_PurchaseReturnDC.paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@ParaScheduleID", objTRN_PurchaseReturnDC.ParaScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_PurchaseReturnDC.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRN_PurchaseReturnDC.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRN_PurchaseReturnDC.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_PurchaseReturnDC.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRN_PurchaseReturnDC.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraDcID", objTRN_PurchaseReturnDC.paraDcID);
                varSqlCommand.Parameters.AddWithValue("@paraReturnDCID", objTRN_PurchaseReturnDC.paraReturnDCID);
                varSqlCommand.Parameters.AddWithValue("@paraReasonId", objTRN_PurchaseReturnDC.paraReasonId);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplier", objTRN_PurchaseReturnDC.ParaSupplier);
                varSqlCommand.Parameters.AddWithValue("@ParaPO", objTRN_PurchaseReturnDC.ParaPO);
                varSqlCommand.Parameters.AddWithValue("@ParaGroupID", objTRN_PurchaseReturnDC.ParaGroupID);
                varSqlCommand.Parameters.AddWithValue("@ParaSubGroupID", objTRN_PurchaseReturnDC.ParaSubGroupID);
                varSqlCommand.Parameters.AddWithValue("@paraDCIDs", objTRN_PurchaseReturnDC.paraDCIDs);
                varSqlCommand.Parameters.AddWithValue("@paraId", objTRN_PurchaseReturnDC.paraPurchaseId);
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
        // added by venkat on 17/10/2023 for purchase damage list
        //public DataSet udfnReturnDC(int paraViewType, int ParaSupplierId, int ParaScheduleId, int paraCompanyID, int paraDcID, int ParaSupplier, int ParaPO, int ParaGroupID, int ParaSubGroupID)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        tmpspcall = new SPCall();
        //        SqlCommand varSqlCommand = new SqlCommand("[TRNG_PurchaseReturn_DC]", tmpspcall.objConn);
        //        varSqlCommand.CommandType = CommandType.StoredProcedure;
        //        varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
        //        varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
        //        varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
        //        varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", ParaSupplierId);
        //        varSqlCommand.Parameters.AddWithValue("@ParaScheduleId", ParaScheduleId);
        //        varSqlCommand.Parameters.AddWithValue("@paraCompanyID", paraCompanyID);
        //        varSqlCommand.Parameters.AddWithValue("@paraDcID", paraDcID);
        //        varSqlCommand.Parameters.AddWithValue("@ParaSupplier", ParaSupplier);
        //        varSqlCommand.Parameters.AddWithValue("@ParaPO", ParaPO);
        //        varSqlCommand.Parameters.AddWithValue("@ParaGroupID", ParaGroupID);
        //        varSqlCommand.Parameters.AddWithValue("@ParaSubGroupID", ParaSubGroupID);
        //        varSqlCommand.CommandTimeout = 0;
        //        SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
        //        sa.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //    finally
        //    {
        //        tmpspcall.CloseConnection();
        //    }
        //    return ds;
        //}
        // added by venkat on 17/10/2023 for PO list
        public DataSet udfnPOEntry(int paraViewType, int ParaSupplierId, int ParaScheduleId, int paraCompanyID, int paraDcID, int ParaSupplier, int ParaPO, int ParaGroupID, int ParaSubGroupID, string ParaPOFromDate,
            string ParaPOToDate, int paraPOID, int paraStatus, string paraPendingPOIDs, int parafilter, int paraProductCode, int paraOrdertype, int paraCityid, int paraDTAT, int paraGRNstatus,int paraFlag)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_PO]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@ParaScheduleId", ParaScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyID", paraCompanyID);
                varSqlCommand.Parameters.AddWithValue("@paraDcID", paraDcID);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplier", ParaSupplier);
                varSqlCommand.Parameters.AddWithValue("@ParaPO", ParaPO);
                varSqlCommand.Parameters.AddWithValue("@ParaGroupID", ParaGroupID);
                varSqlCommand.Parameters.AddWithValue("@ParaSubGroupID", ParaSubGroupID);
                varSqlCommand.Parameters.AddWithValue("@ParaPOFromDate", ParaPOFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaPOToDate", ParaPOToDate);
                varSqlCommand.Parameters.AddWithValue("@paraPOID", paraPOID);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", paraStatus);
                varSqlCommand.Parameters.AddWithValue("@paraPendingPOIDs", paraPendingPOIDs);
                varSqlCommand.Parameters.AddWithValue("@parafilter", parafilter);
                varSqlCommand.Parameters.AddWithValue("@paraProductCode", paraProductCode);
                varSqlCommand.Parameters.AddWithValue("@paraOrdertype", paraOrdertype);
                varSqlCommand.Parameters.AddWithValue("@paraCityid", paraCityid);
                varSqlCommand.Parameters.AddWithValue("@paraDTAT", paraDTAT);
                varSqlCommand.Parameters.AddWithValue("@paraGRNstatus", paraGRNstatus);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", paraFlag);
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


        // added by venkat on 03/11/2023 for GRN Entry Save
        public string udfnGRNEntry(TRN_GRN objTRNS_GRN)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_GRN]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNS_GRN.ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaGRNID", objTRNS_GRN.ParaGRNID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRNS_GRN.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRNS_GRN.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", objTRNS_GRN.paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRNS_GRN.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRNS_GRN.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRNS_GRN.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@ParaTRN_GRN_PO", objTRNS_GRN.ParaTRN_GRN_PO);
                varSqlCommand.Parameters.AddWithValue("@paraGRNDate", objTRNS_GRN.paraGRNDate);
                varSqlCommand.Parameters.AddWithValue("@paraINVDate", objTRNS_GRN.paraINVDate);
                varSqlCommand.Parameters.AddWithValue("@paraINVNo", objTRNS_GRN.paraINVNo);
                varSqlCommand.Parameters.AddWithValue("@ParaInvAmt", objTRNS_GRN.ParaInvAmt);
                varSqlCommand.Parameters.AddWithValue("@ParaUnLoadingCharge", objTRNS_GRN.ParaUnLoadingCharge);
                varSqlCommand.Parameters.AddWithValue("@ParaFrightCharge", objTRNS_GRN.ParaFrightCharge);
                varSqlCommand.Parameters.AddWithValue("@paraOrderType", objTRNS_GRN.paraOrderType);
                varSqlCommand.Parameters.AddWithValue("@paraPAckage", objTRNS_GRN.paraPAckage);
                varSqlCommand.Parameters.AddWithValue("@ParaVerify1", objTRNS_GRN.ParaVerify1);
                varSqlCommand.Parameters.AddWithValue("@ParaVerify2", objTRNS_GRN.ParaVerify2);
                varSqlCommand.Parameters.AddWithValue("@ParaVerifyDate1", objTRNS_GRN.ParaVerifyDate1);
                varSqlCommand.Parameters.AddWithValue("@ParaVerifyDate2", objTRNS_GRN.ParaVerifyDate2);
                varSqlCommand.Parameters.AddWithValue("@paraflag", objTRNS_GRN.paraflag);
                varSqlCommand.Parameters.AddWithValue("@ParaPurchaseDC", objTRNS_GRN.ParaPurchaseDC);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", objTRNS_GRN.paraStatus);
                varSqlCommand.Parameters.AddWithValue("@paraGRNProd", objTRNS_GRN.paraGRNProd);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraSkipped", objTRNS_GRN.paraSkipped);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRNS_GRN.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@ParaEditFlag", objTRNS_GRN.ParaEditFlag);
                varSqlCommand.Parameters.AddWithValue("@paraQrimg", objTRNS_GRN.paraQrimg);
                varSqlCommand.Parameters.AddWithValue("@paraID", objTRNS_GRN.paraID);
                varSqlCommand.Parameters.AddWithValue("@paraSaveFlag", objTRNS_GRN.paraSaveFlag);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedTime1", objTRNS_GRN.paraVerifiedTime1);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedTime2", objTRNS_GRN.paraVerifiedTime2);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedFormat1", objTRNS_GRN.paraVerifiedFormat1);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedFormat2", objTRNS_GRN.paraVerifiedFormat2);
                varSqlCommand.Parameters.AddWithValue("@paraPayment", objTRNS_GRN.paraPayment);
                varSqlCommand.Parameters.AddWithValue("@paraCompletedIDs", objTRNS_GRN.paraCompletedIDs);
                varSqlCommand.Parameters.AddWithValue("@paraADID", objTRNS_GRN.paraADID);
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

        // added by venkat on 03/11/2023 for GRN list
        public DataSet udfnGrnListLoad(int paraViewType, int ParaSupplierId, int ParaScheduleId, int paraCompanyID, int paraDcID, string ParaGRNFromDate, string ParaGRNToDate,
            int paraGRNID, int paraStatus, int paraOrdertype, string ParaExpiryDate, string ParaGRNDate, int paraProductId, int paraLocationID, String paraGRNIds, string paraQRCode, string paraCompletedIDs, int paraQtyType, int paraGroupId, int paraSubgroupId, int paraDelayMin)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_GRN]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@ParaScheduleId", ParaScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyID", paraCompanyID);
                varSqlCommand.Parameters.AddWithValue("@paraDcID", paraDcID);
                varSqlCommand.Parameters.AddWithValue("@ParaGRNFromDate", ParaGRNFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaGRNToDate", ParaGRNToDate);
                varSqlCommand.Parameters.AddWithValue("@paraGRNID", paraGRNID);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", paraStatus);
                varSqlCommand.Parameters.AddWithValue("@paraOrdertype", paraOrdertype);
                varSqlCommand.Parameters.AddWithValue("@ParaGRNDate", ParaGRNDate);
                varSqlCommand.Parameters.AddWithValue("@ParaExpiryDate", ParaExpiryDate);
                varSqlCommand.Parameters.AddWithValue("@paraProductId", paraProductId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationID", paraLocationID);
                varSqlCommand.Parameters.AddWithValue("@paraGRNIds", paraGRNIds);
                varSqlCommand.Parameters.AddWithValue("@paraQRCode", paraQRCode);
                varSqlCommand.Parameters.AddWithValue("@paraCompletedIDs", paraCompletedIDs);
                varSqlCommand.Parameters.AddWithValue("@paraQtyType", paraQtyType);
                varSqlCommand.Parameters.AddWithValue("@paraGroupId", paraGroupId);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroupId", paraSubgroupId);
                varSqlCommand.Parameters.AddWithValue("@paraDelayMin", paraDelayMin);
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
        // added by kavitha on 08/11/2023 for Goods Outward Save
        public string udfnGoodsOutward(TRN_GoodsOutward objTRNS_GoodsOutward)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_GoodsOutward]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNS_GoodsOutward.ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaGOId", objTRNS_GoodsOutward.ParaGOId);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", objTRNS_GoodsOutward.ParaCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraOutwardDate", objTRNS_GoodsOutward.paraOutwardDate);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRNS_GoodsOutward.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraTransferType", objTRNS_GoodsOutward.paraTransferType);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRNS_GoodsOutward.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRNS_GoodsOutward.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraStockTransfer", objTRNS_GoodsOutward.paraStockTransfer);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRNS_GoodsOutward.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@ParaFlag", objTRNS_GoodsOutward.ParaFlag);
                varSqlCommand.Parameters.AddWithValue("@paraCompletedby", objTRNS_GoodsOutward.paraCompletedby);
                varSqlCommand.Parameters.AddWithValue("@paraTeller", objTRNS_GoodsOutward.paraTeller);
                varSqlCommand.Parameters.AddWithValue("@paraStockChild", objTRNS_GoodsOutward.paraStockChild);
                varSqlCommand.Parameters.AddWithValue("@paraStockConversion", objTRNS_GoodsOutward.paraStockConversion);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public string udfnGoodsInward(TRN_GoodsInward objTRNS_GoodsInward)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_GoodsInward]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNS_GoodsInward.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraGIID", objTRNS_GoodsInward.paraGIID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", objTRNS_GoodsInward.paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraInwardDate", objTRNS_GoodsInward.paraInwardDate);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRNS_GoodsInward.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraTransferType", objTRNS_GoodsInward.paraTransferType);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRNS_GoodsInward.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRNS_GoodsInward.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraGoodsInward", objTRNS_GoodsInward.paraGoodsInward);
                varSqlCommand.Parameters.AddWithValue("@paraSTRID", objTRNS_GoodsInward.paraSTRID);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRNS_GoodsInward.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objTRNS_GoodsInward.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRNS_GoodsInward.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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

        //Created By :-Kavitha ; Created On :-09/11/2023
        //public DataSet udfnGOList(int paraviewType, int paraGOID, int paraConcern, string paraFromDate, string paraToDate, int paraSLID, int paraPRID, int paraStatusId)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        tmpspcall = new SPCall();
        //        SqlCommand varSqlCommand = new SqlCommand("[TRNG_GoodsOutward]", tmpspcall.objConn);
        //        varSqlCommand.CommandType = CommandType.StoredProcedure;
        //        varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
        //        varSqlCommand.Parameters.AddWithValue("@paraGOID", paraGOID);
        //        varSqlCommand.Parameters.AddWithValue("@paraConcern", paraConcern);
        //        varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
        //        varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
        //        varSqlCommand.Parameters.AddWithValue("@paraSLID", paraSLID);
        //        varSqlCommand.Parameters.AddWithValue("@paraPRID", paraPRID);
        //        varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
        //        varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
        //        varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
        //        varSqlCommand.CommandTimeout = 0;
        //        SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
        //        sa.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //    finally
        //    {
        //        tmpspcall.CloseConnection();
        //    }
        //    return ds;
        //}
        public DataSet udfnGOList(TRN_GoodsOutward objTRNG_GoodsOutward)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_GoodsOutward]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNG_GoodsOutward.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraGOID", objTRNG_GoodsOutward.ParaGOId);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRNG_GoodsOutward.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRNG_GoodsOutward.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRNG_GoodsOutward.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRNG_GoodsOutward.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", objTRNG_GoodsOutward.ParaCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRNG_GoodsOutward.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRNG_GoodsOutward.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRNG_GoodsOutward.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRNG_GoodsOutward.paraUserLocations);
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
        //Added by Sivabharathi on 08/01/2024
        public DataSet udfnInwardPurchaseList(TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_GoodsInward_Purchase]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_GoodsInward_Purchase.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraGRNID", objTRN_GoodsInward_Purchase.paraGRNID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_GoodsInward_Purchase.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", objTRN_GoodsInward_Purchase.ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRN_GoodsInward_Purchase.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraProductId", objTRN_GoodsInward_Purchase.paraProductId);
                varSqlCommand.Parameters.AddWithValue("@paraInwardId", objTRN_GoodsInward_Purchase.paraInwardId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_GoodsInward_Purchase.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRN_GoodsInward_Purchase.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRN_GoodsInward_Purchase.paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@paraTypeID", objTRN_GoodsInward_Purchase.paraTypeID);
                varSqlCommand.Parameters.AddWithValue("@ParaFromDate", objTRN_GoodsInward_Purchase.ParaFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaToDate", objTRN_GoodsInward_Purchase.ParaToDate);
                varSqlCommand.Parameters.AddWithValue("@paraRemarkFlag", objTRN_GoodsInward_Purchase.paraRemarkFlag);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseID", objTRN_GoodsInward_Purchase.paraPurchaseID);
                varSqlCommand.Parameters.AddWithValue("@paraOrderBy", objTRN_GoodsInward_Purchase.paraOrderBy);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objTRN_GoodsInward_Purchase.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraID", objTRN_GoodsInward_Purchase.paraID);
                varSqlCommand.Parameters.AddWithValue("@ParaInwardDate", objTRN_GoodsInward_Purchase.ParaInwardDate);
                varSqlCommand.Parameters.AddWithValue("@ParaExpiryDate", objTRN_GoodsInward_Purchase.ParaExpiryDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRN_GoodsInward_Purchase.paraUserLocations);
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
        // Sivabharathi on 09/01/2024 -- Goods inward purchase 
        public string udfnGoodsInwardPurchase(TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_GoodsInward_Purchase]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_GoodsInward_Purchase.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_GoodsInward_Purchase.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_GoodsInward_Purchase.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRN_GoodsInward_Purchase.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_GoodsInward_Purchase.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraGIP_Date", objTRN_GoodsInward_Purchase.paraGIP_Date);
                varSqlCommand.Parameters.AddWithValue("@paraGIP_NO", objTRN_GoodsInward_Purchase.paraGIP_NO);
                varSqlCommand.Parameters.AddWithValue("@paraGRNID", objTRN_GoodsInward_Purchase.paraGRNID);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseID", objTRN_GoodsInward_Purchase.paraPurchaseID);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseDCID", objTRN_GoodsInward_Purchase.paraPurchaseDCID);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objTRN_GoodsInward_Purchase.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraInwardId", objTRN_GoodsInward_Purchase.paraInwardId);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRN_GoodsInward_Purchase.paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_GoodsInward_Purchase.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@ParaScheduleId", objTRN_GoodsInward_Purchase.ParaScheduleId);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", objTRN_GoodsInward_Purchase.ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationID", objTRN_GoodsInward_Purchase.paraLocationID);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_GoodsInward_Purchase.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraTypeID", objTRN_GoodsInward_Purchase.paraTypeID);
                varSqlCommand.Parameters.AddWithValue("@paraTRN_GoodsInward_Purchase_Products", objTRN_GoodsInward_Purchase.paraTRN_GoodsInward_Purchase_Products);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraEditFlag", objTRN_GoodsInward_Purchase.paraEditFlag);
                varSqlCommand.Parameters.AddWithValue("@paraGIP_TransDate", objTRN_GoodsInward_Purchase.paraGIP_TransDate);
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
        public DataSet udfnInwardList(TRN_GoodsInward objTRNG_GoodsInward)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_GoodsInward]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNG_GoodsInward.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraGIID", objTRNG_GoodsInward.paraGIID);
                varSqlCommand.Parameters.AddWithValue("@paraSTRID", objTRNG_GoodsInward.paraSTRID);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRNG_GoodsInward.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRNG_GoodsInward.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRNG_GoodsInward.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRNG_GoodsInward.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", objTRNG_GoodsInward.paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objTRNG_GoodsInward.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRNG_GoodsInward.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRNG_GoodsInward.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRNG_GoodsInward.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRNG_GoodsInward.paraUserLocations);
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

        public string udfnStockHold(TRN_StockHold objTRNS_StockHold)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_StockHold]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNS_StockHold.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraSHID", objTRNS_StockHold.paraSHID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanycode", objTRNS_StockHold.paraCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRNS_StockHold.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRNS_StockHold.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraRKID", objTRNS_StockHold.paraRKID);
                varSqlCommand.Parameters.AddWithValue("@paraMrp", objTRNS_StockHold.paraMrp);
                varSqlCommand.Parameters.AddWithValue("@paraExpiryDate", objTRNS_StockHold.paraExpiryDate);
                varSqlCommand.Parameters.AddWithValue("@paraBatchNo", objTRNS_StockHold.paraBatchNo);
                varSqlCommand.Parameters.AddWithValue("@paraUTID", objTRNS_StockHold.paraUTID);
                varSqlCommand.Parameters.AddWithValue("@paraQty", objTRNS_StockHold.paraQty);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRNS_StockHold.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRNS_StockHold.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objTRNS_StockHold.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRNS_StockHold.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRNS_StockHold.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", objTRNS_StockHold.paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", objTRNS_StockHold.paraStatus);
                varSqlCommand.Parameters.AddWithValue("@paraStockQty", objTRNS_StockHold.paraStockQty);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraReason", objTRNS_StockHold.paraReason);
                varSqlCommand.Parameters.AddWithValue("@paraSHIds", objTRNS_StockHold.paraSHIds);
                varSqlCommand.Parameters.AddWithValue("@paraParentSHID", objTRNS_StockHold.paraParentSHID);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRNS_StockHold.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraTeller", objTRNS_StockHold.paraTeller);
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
        public DataSet udfnStockHoldList(TRN_StockHold objTRNG_StockHold)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_StockHold]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNG_StockHold.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraSHID", objTRNG_StockHold.paraSHID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", objTRNG_StockHold.paraCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRNG_StockHold.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRNG_StockHold.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRNG_StockHold.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRNG_StockHold.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraAlpha", objTRNG_StockHold.paraAlpha);
                varSqlCommand.Parameters.AddWithValue("@paraReason", objTRNG_StockHold.paraReason);
                varSqlCommand.Parameters.AddWithValue("@paraType", objTRNG_StockHold.paraType);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objTRNG_StockHold.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRNG_StockHold.paraUserLocations);
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

        //public DataSet udfnStockHoldList(int ViewType, int paraSHID)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        tmpspcall = new SPCall();
        //        SqlCommand varSqlCommand = new SqlCommand("[TRNG_StockHold]", tmpspcall.objConn);
        //        varSqlCommand.CommandType = CommandType.StoredProcedure;
        //        varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
        //        varSqlCommand.Parameters.AddWithValue("@paraSHID", paraSHID);
        //        varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
        //        varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
        //        varSqlCommand.CommandTimeout = 0;
        //        SqlDataAdapter sa = new SqlDataAdapter(varSqlCommand);
        //        sa.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //    finally
        //    {
        //        tmpspcall.CloseConnection();
        //    }
        //    return ds;
        //}

        // added by kavitha on 30/11/2023 for Batch Conversion Save
        public string udfnBatchConversion(TRN_BatchConversion objTRN_BatchConversion)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_BatchConversion]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_BatchConversion.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraBTID", objTRN_BatchConversion.paraBTID);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", objTRN_BatchConversion.paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraConversionDate", objTRN_BatchConversion.paraConversionDate);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRN_BatchConversion.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRN_BatchConversion.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraRKID", objTRN_BatchConversion.paraRKID);
                varSqlCommand.Parameters.AddWithValue("@paraMrp", objTRN_BatchConversion.paraMrp);
                varSqlCommand.Parameters.AddWithValue("@paraExpiryDate", objTRN_BatchConversion.paraExpiryDate);
                varSqlCommand.Parameters.AddWithValue("@paraBatchNo", objTRN_BatchConversion.paraBatchNo);
                varSqlCommand.Parameters.AddWithValue("@paraQuantity", objTRN_BatchConversion.paraQuantity);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRN_BatchConversion.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraBatchConversion", objTRN_BatchConversion.paraBatchConversion);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_BatchConversion.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_BatchConversion.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnBatchConversionList(TRN_BatchConversion objTRNG_BatchConversion)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_BatchConversion]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNG_BatchConversion.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraBTID", objTRNG_BatchConversion.paraBTID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanycode", objTRNG_BatchConversion.paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRNG_BatchConversion.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRNG_BatchConversion.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRNG_BatchConversion.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRNG_BatchConversion.paraUserLocations);
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
        public DataSet udfnCreditNoteList(TRN_CreditNote objTRNG_CreditNote)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_CreditNote]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNG_CreditNote.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraDCID", objTRNG_CreditNote.paraDCID);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRNG_CreditNote.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRNG_CreditNote.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRNG_CreditNote.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", objTRNG_CreditNote.paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRNG_CreditNote.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraCreditID", objTRNG_CreditNote.paraCreditID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRNG_CreditNote.paraIPAddress);
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

        public string udfnSetCreditNote(TRN_CreditNote objTRN_CreditNote)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_CreditNote]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_CreditNote.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCreditID", objTRN_CreditNote.paraCreditID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", objTRN_CreditNote.paraCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraCredit_Date", objTRN_CreditNote.paraCredit_Date);
                varSqlCommand.Parameters.AddWithValue("@paraCredit_NO", objTRN_CreditNote.paraCredit_NO);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRN_CreditNote.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", objTRN_CreditNote.paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRN_CreditNote.paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@paraReasonId", objTRN_CreditNote.paraReasonId);
                varSqlCommand.Parameters.AddWithValue("@ParaSubtotal", objTRN_CreditNote.ParaSubtotal);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_CreditNote.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseId", objTRN_CreditNote.paraPurchaseId);
                varSqlCommand.Parameters.AddWithValue("@paraTax", objTRN_CreditNote.paraTax);
                varSqlCommand.Parameters.AddWithValue("@paraAmount", objTRN_CreditNote.paraAmount);
                varSqlCommand.Parameters.AddWithValue("@paraCredit_Remarks", objTRN_CreditNote.paraCredit_Remarks);
                varSqlCommand.Parameters.AddWithValue("@paraTRN_CreditNote", objTRN_CreditNote.paraTRN_CreditNote);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        // added by venkat on 08/01/2024 for Purchase entry
        public DataSet udfnGetPurchaseEntry(TRN_PurchaseEntry objTRN_PurchaseEntry)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Purchase_Entry]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTRN_PurchaseEntry.ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaIds", objTRN_PurchaseEntry.ParaIds);
                varSqlCommand.Parameters.AddWithValue("@ParaPEFromDate", objTRN_PurchaseEntry.ParaPEFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaPEToDate", objTRN_PurchaseEntry.ParaPEToDate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@ParaEditFlag", objTRN_PurchaseEntry.ParaEditFlag);
                varSqlCommand.Parameters.AddWithValue("@paraType", objTRN_PurchaseEntry.paraType);
                varSqlCommand.Parameters.AddWithValue("@paraEntryType", objTRN_PurchaseEntry.paraEntryType);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseId", objTRN_PurchaseEntry.paraPurchaseId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_PurchaseEntry.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", objTRN_PurchaseEntry.paraStatus);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", objTRN_PurchaseEntry.paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRN_PurchaseEntry.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRN_PurchaseEntry.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraDateFilter", objTRN_PurchaseEntry.paraDateFilter);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", objTRN_PurchaseEntry.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraProductID ", objTRN_PurchaseEntry.paraProductID);
                varSqlCommand.Parameters.AddWithValue("@ParaPurchaseRefresh", objTRN_PurchaseEntry.ParaPurchaseRefresh);
                varSqlCommand.Parameters.AddWithValue("@paraDate", objTRN_PurchaseEntry.paraDate);
                varSqlCommand.Parameters.AddWithValue("@paraFlag ", objTRN_PurchaseEntry.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraGRNID ", objTRN_PurchaseEntry.paraGRNID);
                varSqlCommand.Parameters.AddWithValue("@paraInwardId ", objTRN_PurchaseEntry.paraInwardId);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierType ", objTRN_PurchaseEntry.paraSupplierType);
                varSqlCommand.Parameters.AddWithValue("@paraConditionType ", objTRN_PurchaseEntry.paraConditionType);
                varSqlCommand.Parameters.AddWithValue("@paraMonth ", objTRN_PurchaseEntry.paraMonth);
                varSqlCommand.Parameters.AddWithValue("@paraFilterType ", objTRN_PurchaseEntry.paraFilterType);
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
        //Added by Sivabhaarthi on 02/04/2024 --Purchase entry approval 
        public string udfnSetPurchaseEntryApproval(TRN_PurchaseEntryApproval objTRN_PurchaseEntryApproval)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Purchase_Entry_Approval]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_PurchaseEntryApproval.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_PurchaseEntryApproval.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_PurchaseEntryApproval.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseId", objTRN_PurchaseEntryApproval.paraPurchaseId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_PurchaseEntryApproval.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRN_PurchaseEntryApproval.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", objTRN_PurchaseEntryApproval.paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseDate", objTRN_PurchaseEntryApproval.paraPurchaseDate);
                varSqlCommand.Parameters.AddWithValue("@paraINVDate", objTRN_PurchaseEntryApproval.paraINVDate);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerID", objTRN_PurchaseEntryApproval.paraBrokerID);
                varSqlCommand.Parameters.AddWithValue("@paraINVNo", objTRN_PurchaseEntryApproval.paraINVNo);
                varSqlCommand.Parameters.AddWithValue("@ParaInvAmt", objTRN_PurchaseEntryApproval.ParaInvAmt);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_PurchaseEntryApproval.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@ParaPurchaseDC", objTRN_PurchaseEntryApproval.ParaPurchaseDC);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", objTRN_PurchaseEntryApproval.paraStatus);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_PurchaseEntryApproval.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@ParaEditFlag", objTRN_PurchaseEntryApproval.ParaEditFlag);
                varSqlCommand.Parameters.AddWithValue("@paraQrimg", objTRN_PurchaseEntryApproval.paraQrimg);
                varSqlCommand.Parameters.AddWithValue("@paraEntryType", objTRN_PurchaseEntryApproval.paraEntryType);
                varSqlCommand.Parameters.AddWithValue("@paraGSTIN", objTRN_PurchaseEntryApproval.paraGSTIN);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionType", objTRN_PurchaseEntryApproval.paraTransactionType);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseType", objTRN_PurchaseEntryApproval.paraPurchaseType);
                varSqlCommand.Parameters.AddWithValue("@paraPaymentType", objTRN_PurchaseEntryApproval.paraPaymentType);
                varSqlCommand.Parameters.AddWithValue("@paraRateCalculation", objTRN_PurchaseEntryApproval.paraRateCalculation);
                varSqlCommand.Parameters.AddWithValue("@paraDiscCalculation", objTRN_PurchaseEntryApproval.paraDiscCalculation);
                varSqlCommand.Parameters.AddWithValue("@paraEinvoice", objTRN_PurchaseEntryApproval.paraEinvoice);
                //varSqlCommand.Parameters.AddWithValue("@ParaUnLoadingCharge", objTRN_PurchaseEntryApproval.paraUnloadingCharges);
                varSqlCommand.Parameters.AddWithValue("@paraUnloadingCharges", objTRN_PurchaseEntryApproval.paraUnloadingCharges);
                varSqlCommand.Parameters.AddWithValue("@paraCourierCharges", objTRN_PurchaseEntryApproval.paraCourierCharges);
                varSqlCommand.Parameters.AddWithValue("@paraOtherExpenses", objTRN_PurchaseEntryApproval.paraOtherExpenses);
                varSqlCommand.Parameters.AddWithValue("@paraDiscPer", objTRN_PurchaseEntryApproval.paraDiscPer);
                varSqlCommand.Parameters.AddWithValue("@paraDiscAmnt", objTRN_PurchaseEntryApproval.paraDiscAmnt);
                varSqlCommand.Parameters.AddWithValue("@paraTcsAmnt", objTRN_PurchaseEntryApproval.paraTcsAmnt);
                varSqlCommand.Parameters.AddWithValue("@paraDamageCost", objTRN_PurchaseEntryApproval.paraDamageCost);
                varSqlCommand.Parameters.AddWithValue("@paraOtherDisc", objTRN_PurchaseEntryApproval.paraOtherDisc);
                varSqlCommand.Parameters.AddWithValue("@paraSubTotal", objTRN_PurchaseEntryApproval.paraSubTotal);
                varSqlCommand.Parameters.AddWithValue("@paraTotal", objTRN_PurchaseEntryApproval.paraTotal);
                varSqlCommand.Parameters.AddWithValue("@paraGSTAmnt", objTRN_PurchaseEntryApproval.paraGSTAmnt);
                varSqlCommand.Parameters.AddWithValue("@paraRoundOff", objTRN_PurchaseEntryApproval.paraRoundOff);
                varSqlCommand.Parameters.AddWithValue("@paraGrandTotal", objTRN_PurchaseEntryApproval.paraGrandTotal);
                varSqlCommand.Parameters.AddWithValue("@paraUnLoadingChargesGRN", objTRN_PurchaseEntryApproval.paraUnLoadingChargesGRN);
                varSqlCommand.Parameters.AddWithValue("@paraFrightGRN", objTRN_PurchaseEntryApproval.paraFrightGRN);
                varSqlCommand.Parameters.AddWithValue("@paraGRNID", objTRN_PurchaseEntryApproval.paraGRNID);
                varSqlCommand.Parameters.AddWithValue("@paraSaveFlag", objTRN_PurchaseEntryApproval.paraSaveFlag);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierType", objTRN_PurchaseEntryApproval.paraSupplierType);
                varSqlCommand.Parameters.AddWithValue("@paraRefreshFlag", objTRN_PurchaseEntryApproval.paraRefreshFlag);
                varSqlCommand.Parameters.AddWithValue("@paraLoadingCharges", objTRN_PurchaseEntryApproval.paraLoadingCharges);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseEntryApprovalDate", objTRN_PurchaseEntryApproval.paraPurchaseEntryApprovalDate);
                varSqlCommand.Parameters.AddWithValue("@ParaTRN_Purchase_Products_Error", objTRN_PurchaseEntryApproval.ParaTRN_Purchase_Products_Error);
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

        public string udfnSetPurchaseEntry(TRN_PurchaseEntry objTRN_PurchaseEntry) 
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Purchase_Entry]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_PurchaseEntry.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_PurchaseEntry.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_PurchaseEntry.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseId", objTRN_PurchaseEntry.paraPurchaseId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_PurchaseEntry.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRN_PurchaseEntry.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", objTRN_PurchaseEntry.paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseDate", objTRN_PurchaseEntry.paraPurchaseDate);
                varSqlCommand.Parameters.AddWithValue("@paraINVDate", objTRN_PurchaseEntry.paraINVDate);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerID", objTRN_PurchaseEntry.paraBrokerID);
                varSqlCommand.Parameters.AddWithValue("@paraINVNo", objTRN_PurchaseEntry.paraINVNo);
                varSqlCommand.Parameters.AddWithValue("@ParaInvAmt", objTRN_PurchaseEntry.ParaInvAmt);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_PurchaseEntry.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@ParaPurchaseDC", objTRN_PurchaseEntry.ParaPurchaseDC);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", objTRN_PurchaseEntry.paraStatus);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_PurchaseEntry.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@ParaEditFlag", objTRN_PurchaseEntry.ParaEditFlag);
                varSqlCommand.Parameters.AddWithValue("@paraQrimg", objTRN_PurchaseEntry.paraQrimg);
                varSqlCommand.Parameters.AddWithValue("@paraEntryType", objTRN_PurchaseEntry.paraEntryType);
                varSqlCommand.Parameters.AddWithValue("@paraGSTIN", objTRN_PurchaseEntry.paraGSTIN);
                varSqlCommand.Parameters.AddWithValue("@paraTransactionType", objTRN_PurchaseEntry.paraTransactionType);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseType", objTRN_PurchaseEntry.paraPurchaseType);
                varSqlCommand.Parameters.AddWithValue("@paraPaymentType", objTRN_PurchaseEntry.paraPaymentType);
                varSqlCommand.Parameters.AddWithValue("@paraRateCalculation", objTRN_PurchaseEntry.paraRateCalculation);
                varSqlCommand.Parameters.AddWithValue("@paraDiscCalculation", objTRN_PurchaseEntry.paraDiscCalculation);
                varSqlCommand.Parameters.AddWithValue("@paraEinvoice", objTRN_PurchaseEntry.paraEinvoice);
                varSqlCommand.Parameters.AddWithValue("@paraLoadingCharges", objTRN_PurchaseEntry.paraLoadingCharges);
                varSqlCommand.Parameters.AddWithValue("@paraUnloadingCharges", objTRN_PurchaseEntry.paraUnloadingCharges);
                varSqlCommand.Parameters.AddWithValue("@paraCourierCharges", objTRN_PurchaseEntry.paraCourierCharges);
                varSqlCommand.Parameters.AddWithValue("@paraOtherExpenses", objTRN_PurchaseEntry.paraOtherExpenses);
                varSqlCommand.Parameters.AddWithValue("@paraDiscPer", objTRN_PurchaseEntry.paraDiscPer);
                varSqlCommand.Parameters.AddWithValue("@paraDiscAmnt", objTRN_PurchaseEntry.paraDiscAmnt);
                varSqlCommand.Parameters.AddWithValue("@paraTcsAmnt", objTRN_PurchaseEntry.paraTcsAmnt);
                varSqlCommand.Parameters.AddWithValue("@paraDamageCost", objTRN_PurchaseEntry.paraDamageCost);
                varSqlCommand.Parameters.AddWithValue("@paraOtherDisc", objTRN_PurchaseEntry.paraOtherDisc);
                varSqlCommand.Parameters.AddWithValue("@paraSubTotal", objTRN_PurchaseEntry.paraSubTotal);
                varSqlCommand.Parameters.AddWithValue("@paraGSTAmnt", objTRN_PurchaseEntry.paraGSTAmnt);
                varSqlCommand.Parameters.AddWithValue("@paraRoundOff", objTRN_PurchaseEntry.paraRoundOff);
                varSqlCommand.Parameters.AddWithValue("@paraGrandTotal", objTRN_PurchaseEntry.paraGrandTotal);
                varSqlCommand.Parameters.AddWithValue("@ParaTRN_Purchase_Products", objTRN_PurchaseEntry.ParaPurchase_Products);
                varSqlCommand.Parameters.AddWithValue("@paraLoadingChargesGRN", objTRN_PurchaseEntry.paraLoadingChargesGRN);
                varSqlCommand.Parameters.AddWithValue("@paraFrightGRN", objTRN_PurchaseEntry.paraFrightGRN);
                varSqlCommand.Parameters.AddWithValue("@paraGRNID", objTRN_PurchaseEntry.paraGRNID);
                varSqlCommand.Parameters.AddWithValue("@paraSaveFlag", objTRN_PurchaseEntry.paraSaveFlag);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierType", objTRN_PurchaseEntry.paraSupplierType);
                varSqlCommand.Parameters.AddWithValue("@paraRefreshFlag", objTRN_PurchaseEntry.paraRefreshFlag);
                varSqlCommand.Parameters.AddWithValue("@paraTinFlag", objTRN_PurchaseEntry.paraTinFlag);
                varSqlCommand.Parameters.AddWithValue("@paraPOID", objTRN_PurchaseEntry.paraPOID);
                varSqlCommand.Parameters.AddWithValue("@paraCompletedIDs", objTRN_PurchaseEntry.paraCompletedIDs);
                varSqlCommand.Parameters.AddWithValue("@paraUnapprovedby", objTRN_PurchaseEntry.paraUnapprovedby);
                varSqlCommand.Parameters.AddWithValue("@paraPUR_GSTREnteredBy", objTRN_PurchaseEntry.paraPUR_GSTREnteredBy);
                varSqlCommand.Parameters.AddWithValue("@paraTotal", objTRN_PurchaseEntry.paraTotal);
                // varSqlCommand.Parameters.AddWithValue("@paraCompletedBy", objTRN_PurchaseEntry.paraCompletedBy);
                varSqlCommand.Parameters.AddWithValue("@ParaTRN_Purchase_Products_Details", objTRN_PurchaseEntry.Purchase_Products_Details);
                varSqlCommand.Parameters.AddWithValue("@ParaTRN_GSTR", objTRN_PurchaseEntry.ParaTRN_GSTR);
                varSqlCommand.Parameters.AddWithValue("@ParaVerifyBy", objTRN_PurchaseEntry.ParaVerifyBy);
                varSqlCommand.Parameters.AddWithValue("@ParaVerifyDate", objTRN_PurchaseEntry.ParaVerifyDate);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedTime", objTRN_PurchaseEntry.paraVerifiedTime);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedFormat", objTRN_PurchaseEntry.paraVerifiedFormat);
                varSqlCommand.Parameters.AddWithValue("@ParaVerifyBy2", objTRN_PurchaseEntry.ParaVerifyBy2);
                varSqlCommand.Parameters.AddWithValue("@ParaVerifyDate2", objTRN_PurchaseEntry.ParaVerifyDate2);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedTime2", objTRN_PurchaseEntry.paraVerifiedTime2);
                varSqlCommand.Parameters.AddWithValue("@paraVerifiedFormat2", objTRN_PurchaseEntry.paraVerifiedFormat2);
                varSqlCommand.Parameters.AddWithValue("@paraGRNFrightCharges", objTRN_PurchaseEntry.paraGRNFrightCharges);
                varSqlCommand.Parameters.AddWithValue("@paraGRNUnloadingCharge", objTRN_PurchaseEntry.paraGRNUnloadingCharge);
                varSqlCommand.Parameters.AddWithValue("@paraMonth", objTRN_PurchaseEntry.paraMonth);
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
        public string udfnSetGRNApproval(TRN_GRNApproval objTRN_GRNApproval)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_GRNApproval]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_GRNApproval.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraPURID", objTRN_GRNApproval.paraPURID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", objTRN_GRNApproval.paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRN_GRNApproval.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_GRNApproval.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_GRNApproval.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_GRNApproval.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_GRNApproval.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", objTRN_GRNApproval.paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraReturnDC_Date", objTRN_GRNApproval.paraReturnDC_Date);
                varSqlCommand.Parameters.AddWithValue("@paraApprovalProduct", objTRN_GRNApproval.paraApprovalProduct);
                varSqlCommand.Parameters.AddWithValue("@paraTRN_Purchase_ReturnDC", objTRN_GRNApproval.paraTRN_Purchase_ReturnDC);
                varSqlCommand.Parameters.AddWithValue("@ParaGRNAID", objTRN_GRNApproval.ParaGRNAID);
                varSqlCommand.Parameters.AddWithValue("@ParaGRNAPRID", objTRN_GRNApproval.ParaGRNAPRID);
                varSqlCommand.Parameters.AddWithValue("@paraGRNID", objTRN_GRNApproval.paraGRNID);
                varSqlCommand.Parameters.AddWithValue("@paraInwardId", objTRN_GRNApproval.paraInwardId);
                varSqlCommand.Parameters.AddWithValue("@paraEditFlag", objTRN_GRNApproval.paraEditFlag);
                varSqlCommand.Parameters.AddWithValue("@paraTRN_CreditNote", objTRN_GRNApproval.paraTRN_CreditNote);
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
        //Added By Sathish ON : 01-04-2024 For Delete Transactions
        public string udfnDBClearTransaction(int ViewType, string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_DBClearTransactions]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Added By Sathish ON : 01-04-2024 For Delete Masters
        public string udfnDBClearMaster(int ViewType, string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_DBClearMasters]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Added By Sathish ON : 05-04-2024 For Save Release Version
        public DataSet udfnReleaseVersion(string paraVersionNo)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_RELEASEDETAILS]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraVersionNo", paraVersionNo);
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

        //Added By Sathish ON : 10-04-2024 For DB Backup
        public string udfnDbBackup(string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Database_Backup]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Added By Sathish ON : 10-04-2024 For DB Restore
        public string udfnDbRestore(string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Database_Restore]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Added By Sathish ON : 10-04-2024 For DB Restore
        public string udfnMoveStock(string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Opening_Stock]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Added By Sathish ON : 11-04-2024 For Financial Settings
        public string udfnFinalSettings(int ViewType, string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_FinalSettings]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Added By Sathish on: 22-04-2024
        public string udfnAdvance(TRN_Advance objTRN_Advance)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Advance]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_Advance.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraAdvanceId", objTRN_Advance.paraAdvanceId);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", objTRN_Advance.ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraAdvanceDate", objTRN_Advance.paraAdvanceDate);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierId", objTRN_Advance.paraSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleId", objTRN_Advance.paraScheduleId);
                varSqlCommand.Parameters.AddWithValue("@ParaAmt", objTRN_Advance.ParaAmt);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_Advance.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraPaymentMode", objTRN_Advance.paraPaymentMode);
                varSqlCommand.Parameters.AddWithValue("@paraPaymentType", objTRN_Advance.paraPaymentType);
                varSqlCommand.Parameters.AddWithValue("@paraChequeDate", objTRN_Advance.paraChequeDate);
                varSqlCommand.Parameters.AddWithValue("@paraChequeNo", objTRN_Advance.paraChequeNo);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_Advance.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraBankId", objTRN_Advance.paraBankId);
                varSqlCommand.Parameters.AddWithValue("@paraModeOfIssue", objTRN_Advance.paraModeOfIssue);
                varSqlCommand.Parameters.AddWithValue("@paraIssueDetails", objTRN_Advance.paraIssueDetails);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRN_Advance.paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_Advance.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_Advance.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraChequeLimitDays", objTRN_Advance.paraChequeLimitDays);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        public DataSet udfnGetSupplierPayment(TRN_Supplier_Payment objTRN_Supplier_Payment)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Supplier_Payment]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTRN_Supplier_Payment.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierid", objTRN_Supplier_Payment.paraSupplierid);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleId", objTRN_Supplier_Payment.paraScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_Supplier_Payment.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRN_Supplier_Payment.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@ParaToDate", objTRN_Supplier_Payment.ParaToDate);
                varSqlCommand.Parameters.AddWithValue("@paraPYID", objTRN_Supplier_Payment.paraPYID);
                varSqlCommand.Parameters.AddWithValue("@paraID", objTRN_Supplier_Payment.paraID);
                varSqlCommand.Parameters.AddWithValue("@paraSource", objTRN_Supplier_Payment.paraSource);
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
        //Added By Sathish On: 22-04-2024
        public DataSet udfnAdvanceList(TRN_Advance objTRN_Advance)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Advance]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_Advance.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraAdvanceId", objTRN_Advance.paraAdvanceId);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", objTRN_Advance.ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRN_Advance.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRN_Advance.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierId", objTRN_Advance.paraSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleId", objTRN_Advance.paraScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraPAYID", objTRN_Advance.paraPAYID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRN_Advance.paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@paraAmountType", objTRN_Advance.paraAmountType);
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
        //Added by Kavitha 23/04/2024
        public string udfnSetPayment(TRN_Supplier_Payment objTRN_Supplier_Payment)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Supplier_Payment]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_Supplier_Payment.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraPYID", objTRN_Supplier_Payment.paraPYID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_Supplier_Payment.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraPaymentDate", objTRN_Supplier_Payment.paraPaymentDate);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierid", objTRN_Supplier_Payment.paraSupplierid);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleId", objTRN_Supplier_Payment.paraScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_Supplier_Payment.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraPaymode", objTRN_Supplier_Payment.paraPaymode);
                varSqlCommand.Parameters.AddWithValue("@paraPayType", objTRN_Supplier_Payment.paraPayType);
                varSqlCommand.Parameters.AddWithValue("@paraChequeDate", objTRN_Supplier_Payment.paraChequeDate);
                varSqlCommand.Parameters.AddWithValue("@paraChequeNo", objTRN_Supplier_Payment.paraChequeNo);
                varSqlCommand.Parameters.AddWithValue("@paraTotalAmnt", objTRN_Supplier_Payment.paraTotalAmnt);
                varSqlCommand.Parameters.AddWithValue("@paraSTSID", objTRN_Supplier_Payment.paraSTSID);
                varSqlCommand.Parameters.AddWithValue("@paraAdvanceID", objTRN_Supplier_Payment.paraAdvanceID);
                varSqlCommand.Parameters.AddWithValue("@paraSubTotal", objTRN_Supplier_Payment.paraSubTotal);
                varSqlCommand.Parameters.AddWithValue("@paraAdvanceAmnt", objTRN_Supplier_Payment.paraAdvanceAmnt);
                varSqlCommand.Parameters.AddWithValue("@paraBankID", objTRN_Supplier_Payment.paraBankID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_Supplier_Payment.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_Supplier_Payment.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraPayment", objTRN_Supplier_Payment.paraPayment);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_Supplier_Payment.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseID", objTRN_Supplier_Payment.paraPurchaseID);
                varSqlCommand.Parameters.AddWithValue("@paradtparaAdvance", objTRN_Supplier_Payment.paradtparaAdvance);
                varSqlCommand.Parameters.AddWithValue("@paraComBank", objTRN_Supplier_Payment.paraComBank);
                varSqlCommand.Parameters.AddWithValue("@paraModeOfIssue", objTRN_Supplier_Payment.paraModeOfIssue);
                varSqlCommand.Parameters.AddWithValue("@paraChequeLimitDays", objTRN_Supplier_Payment.paraChequeLimitDays);
                varSqlCommand.Parameters.AddWithValue("@paraModeOfIssue_Details", objTRN_Supplier_Payment.paraModeOfIssue_Details);
                varSqlCommand.Parameters.AddWithValue("@paraBankTransactionDate", objTRN_Supplier_Payment.paraBankTransactionDate);
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
        public DataSet udfnGetStatus(MR_Status objMR_Status)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Status]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objMR_Status.ViewType);
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
        //Added By Sathish on: 22-07-2024
        public string udfnDiscountVoucher(TRN_DiscountVoucher objTRN_DiscountVoucher)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_DiscountVoucher]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_DiscountVoucher.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraDiscountId", objTRN_DiscountVoucher.paraDiscountId);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", objTRN_DiscountVoucher.ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraDiscountDate", objTRN_DiscountVoucher.paraDiscountDate);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierId", objTRN_DiscountVoucher.paraSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleId", objTRN_DiscountVoucher.paraScheduleId);
                varSqlCommand.Parameters.AddWithValue("@ParaDiscountAmt", objTRN_DiscountVoucher.ParaDiscountAmt);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_DiscountVoucher.paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_DiscountVoucher.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRN_DiscountVoucher.paraStatusID);
                varSqlCommand.Parameters.AddWithValue("@paraPURID", objTRN_DiscountVoucher.paraPURID);
                varSqlCommand.Parameters.AddWithValue("@paraGRNID", objTRN_DiscountVoucher.paraGRNID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_DiscountVoucher.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
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
        //Added By Sathish On: 22-07-2024
        public DataSet udfnDiscountVoucherList(TRN_DiscountVoucher objTRN_DiscountVoucher)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_DiscountVoucher]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_DiscountVoucher.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraDiscountId", objTRN_DiscountVoucher.paraDiscountId);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", objTRN_DiscountVoucher.ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRN_DiscountVoucher.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRN_DiscountVoucher.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierId", objTRN_DiscountVoucher.paraSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleId", objTRN_DiscountVoucher.paraScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStatusID", objTRN_DiscountVoucher.paraStatusID);
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
        /*Added by sivabharathi on 18/07/2025 for Purchase and grn product validation*/
        public DataSet udfnValidateProductsByCondition(TRN_Validate_Products_By_Condition objTRN_Validate_Products_By_Condition)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Validate_Products_By_Condition]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ProductList", objTRN_Validate_Products_By_Condition.ProductList); 
                varSqlCommand.Parameters.AddWithValue("@ParaEntryDate", objTRN_Validate_Products_By_Condition.ParaEntryDate);
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
        public DataSet udfnPurHsnReport(int paraViewType, int paraSupplierType, string paraHSNCode, int paraGST, string paraFromDate, string paraToDate,int paraProductId,int paraGroupId, int paraSubgroupId,int paraFlag,int paraBrandID,int paraCompanyId,int paraSupplierID,int paraScheduleID,int paraInvioceType,int paraPaymentType,int paraPurchaseType,int paraConditionType,int paraProductNameType,string paraAlpha,string paraMonth)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Purchase_Reports]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierType", paraSupplierType);
                varSqlCommand.Parameters.AddWithValue("@paraHSNCode", paraHSNCode);
                varSqlCommand.Parameters.AddWithValue("@paraGST", paraGST);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraProductId", paraProductId);
                varSqlCommand.Parameters.AddWithValue("@paraGroupId", paraGroupId);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroupId", paraSubgroupId);
                varSqlCommand.Parameters.AddWithValue("@paraBrandID", paraBrandID);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", paraFlag);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraInvioceType", paraInvioceType);
                varSqlCommand.Parameters.AddWithValue("@paraPaymentType", paraPaymentType);
                varSqlCommand.Parameters.AddWithValue("@paraPurchaseType", paraPurchaseType);
                varSqlCommand.Parameters.AddWithValue("@paraConditionType", paraConditionType);
                varSqlCommand.Parameters.AddWithValue("@paraProductNameType", paraProductNameType);
                varSqlCommand.Parameters.AddWithValue("@paraAlpha", paraAlpha);
                varSqlCommand.Parameters.AddWithValue("@paraMonth", paraMonth);
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
        public string udfnRateChange(TRN_RateChange objTrnRateChange)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Rate_Change]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTrnRateChange.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraProductID", objTrnRateChange.paraProductID);
                varSqlCommand.Parameters.AddWithValue("@paraRRate", objTrnRateChange.paraRRate);
                varSqlCommand.Parameters.AddWithValue("@paraWRate", objTrnRateChange.paraWRate);
                varSqlCommand.Parameters.AddWithValue("@paraTeller", objTrnRateChange.paraTeller);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTrnRateChange.paraOriginator);
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
        public DataSet udfnRateChangeList(TRN_RateChange objTrnRateChange)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_RateChange]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTrnRateChange.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraGroupID", objTrnRateChange.paraGroupID);
                varSqlCommand.Parameters.AddWithValue("@paraSubGroupID", objTrnRateChange.paraSubGroupID);
                varSqlCommand.Parameters.AddWithValue("@paraBrandID", objTrnRateChange.paraBrandID);
                varSqlCommand.Parameters.AddWithValue("@paraProductID", objTrnRateChange.paraProductID);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTrnRateChange.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTrnRateChange.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTrnRateChange.paraSupplierID);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleID", objTrnRateChange.paraScheduleID);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", objTrnRateChange.paraCompanyCode);

                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraType", objTrnRateChange.paraType); 
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
        public DataSet udfnPaymentReport(int paraViewType, int paraSupplierId, int paraScheduleId, string paraFromDate, string paraToDate,int paraFlag,int ParaCompanycode,int paraPayType,int paraCityId)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Payment_Reports]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierId", paraSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleId", paraScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraFlag", paraFlag);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraPayType", paraPayType);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", paraCityId);
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
        public DataSet udfnOutwardReports(TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_GoodsOutwardReports]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTRN_GoodsInward_Purchase.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", objTRN_GoodsInward_Purchase.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRN_GoodsInward_Purchase.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRN_GoodsInward_Purchase.paraProductId);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRN_GoodsInward_Purchase.ParaFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRN_GoodsInward_Purchase.ParaToDate);
                varSqlCommand.Parameters.AddWithValue("@paraPRGID", objTRN_GoodsInward_Purchase.paraGroupId);
                varSqlCommand.Parameters.AddWithValue("@paraPRSGID", objTRN_GoodsInward_Purchase.paraSubgroupId);
                varSqlCommand.Parameters.AddWithValue("@paraAlpha", objTRN_GoodsInward_Purchase.paraAlpha);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_GoodsInward_Purchase.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRN_GoodsInward_Purchase.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRN_GoodsInward_Purchase.paraUserLocations);
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
        public DataSet udfnInwardReports(TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_GoodsInwardReports]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTRN_GoodsInward_Purchase.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyCode", objTRN_GoodsInward_Purchase.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRN_GoodsInward_Purchase.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRN_GoodsInward_Purchase.paraProductId);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRN_GoodsInward_Purchase.ParaFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRN_GoodsInward_Purchase.ParaToDate);
                varSqlCommand.Parameters.AddWithValue("@paraPRGID", objTRN_GoodsInward_Purchase.paraGroupId);
                varSqlCommand.Parameters.AddWithValue("@paraPRSGID", objTRN_GoodsInward_Purchase.paraSubgroupId);
                varSqlCommand.Parameters.AddWithValue("@paraBrandID", objTRN_GoodsInward_Purchase.paraBrandID);
                varSqlCommand.Parameters.AddWithValue("@paraAlpha", objTRN_GoodsInward_Purchase.paraAlpha);
                varSqlCommand.Parameters.AddWithValue("@paraEntryTypeID", objTRN_GoodsInward_Purchase.paraEntryTypeID);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierId", objTRN_GoodsInward_Purchase.ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@ParaScheduleId", objTRN_GoodsInward_Purchase.ParaScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_GoodsInward_Purchase.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRN_GoodsInward_Purchase.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRN_GoodsInward_Purchase.paraUserLocations);
                varSqlCommand.Parameters.AddWithValue("@paraTrnID", objTRN_GoodsInward_Purchase.paraTrnID);
                varSqlCommand.Parameters.AddWithValue("@paraPrintName", objTRN_GoodsInward_Purchase.paraPrintName);
                varSqlCommand.Parameters.AddWithValue("@paraId", objTRN_GoodsInward_Purchase.paraId);
                varSqlCommand.Parameters.AddWithValue("@paraConverttype", objTRN_GoodsInward_Purchase.paraConverttype);
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

        //Added by sivabharathi on 14/08/2025 
        public string udfnBank(MR_Bank objMR_Bank)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_Bank]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objMR_Bank.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraBankId", objMR_Bank.paraBankId);
                varSqlCommand.Parameters.AddWithValue("@paraBankName", objMR_Bank.paraBankName);
                varSqlCommand.Parameters.AddWithValue("@paraShortName", objMR_Bank.paraShortName);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objMR_Bank.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objMR_Bank.paraDeleteFlag);  
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress); 
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
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
        //Sivabharathi on 14/08/2025
        public DataSet udfnBanklist(MR_Bank objMR_Bank)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRG_Bank", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objMR_Bank. paraViewType); 
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
        public DataSet udfnPayment_ChequeTransactionlist(TRN_Payment_ChequeTransaction objTRN_Payment_ChequeTransaction)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("TRNG_Payment_ChequeTransactionList", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure; 
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTRN_Payment_ChequeTransaction.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID); 
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress); 
                varSqlCommand.Parameters.AddWithValue("@paraSupplierId", objTRN_Payment_ChequeTransaction.paraSupplierId); 
                varSqlCommand.Parameters.AddWithValue("@paraScheduleId", objTRN_Payment_ChequeTransaction.paraScheduleId); 
                varSqlCommand.Parameters.AddWithValue("@paraCompanyId", objTRN_Payment_ChequeTransaction.paraCompanyId); 
                varSqlCommand.Parameters.AddWithValue("@paraID", objTRN_Payment_ChequeTransaction.paraID); 
                varSqlCommand.Parameters.AddWithValue("@ParaFromDate", objTRN_Payment_ChequeTransaction.ParaFromDate); 
                varSqlCommand.Parameters.AddWithValue("@ParaToDate", objTRN_Payment_ChequeTransaction.ParaToDate); 
                varSqlCommand.Parameters.AddWithValue("@paraPYID", objTRN_Payment_ChequeTransaction.paraPYID); 
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
        public string udfnPayment_ChequeTransaction(TRN_Payment_ChequeTransaction objTRN_Payment_ChequeTransaction)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Payment_ChequeTransaction]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTRN_Payment_ChequeTransaction.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraID", objTRN_Payment_ChequeTransaction.paraID); 
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_Payment_ChequeTransaction.paraOriginator); 
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_Payment_ChequeTransaction.paraUserID); 
                varSqlCommand.Parameters.AddWithValue("@paraPAYID", objTRN_Payment_ChequeTransaction.paraPAYID);
                varSqlCommand.Parameters.AddWithValue("@paraChequeDate", objTRN_Payment_ChequeTransaction.paraChequeDate);
                varSqlCommand.Parameters.AddWithValue("@paraChequeNo", objTRN_Payment_ChequeTransaction.paraChequeNo);
                varSqlCommand.Parameters.AddWithValue("@paraAmount", objTRN_Payment_ChequeTransaction.paraAmount);
                varSqlCommand.Parameters.AddWithValue("@paraPAYNo", objTRN_Payment_ChequeTransaction.paraPAYNo);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierID", objTRN_Payment_ChequeTransaction.paraSupplierID); 
                varSqlCommand.Parameters.AddWithValue("@paraBankID", objTRN_Payment_ChequeTransaction.paraBankID); 
                varSqlCommand.Parameters.AddWithValue("@paraChequeLimitDays", objTRN_Payment_ChequeTransaction.paraChequeLimitDays); 
                varSqlCommand.Parameters.AddWithValue("@paraReason", objTRN_Payment_ChequeTransaction.paraReason); 
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
        public DataSet udfnChequePrintSettingsList(MR_ChequeTransactionSettings objMR_ChequeTransactionSettings)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRG_ChequePrintSettings", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objMR_ChequeTransactionSettings.paraViewType);
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
        public string udfnChequePrintSettings(MR_ChequeTransactionSettings MR_ChequeTransactionSettings)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_ChequePrintSettings]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", MR_ChequeTransactionSettings.paraViewType); 
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID); 
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", MR_ChequeTransactionSettings.paraOriginator); 
                varSqlCommand.Parameters.AddWithValue("@paraChequePrintSettingsID", MR_ChequeTransactionSettings.paraChequePrintSettingsID); 
                varSqlCommand.Parameters.AddWithValue("@paraMR_ChequePrintSettings", MR_ChequeTransactionSettings.paraMR_ChequePrintSettings); 
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
        public DataSet udfnGetSlNo(string paraTableName, string paraProcess, string paraColumnName, string paraColumnValue,string paraSerialColumn)
        {
            DataSet ds = new DataSet();

            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_GETSLNO]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraTableName", paraTableName);
                varSqlCommand.Parameters.AddWithValue("@paraProcess", paraProcess);
                varSqlCommand.Parameters.AddWithValue("@paraColumnName", paraColumnName);
                varSqlCommand.Parameters.AddWithValue("@paraColumnValue", paraColumnValue);
                varSqlCommand.Parameters.AddWithValue("@paraSerialColumn", paraSerialColumn);
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
        //Added BY Sathish ON 12-09-2025
        public DataSet udfnZeroRateReport(TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_ZeroRateProducts_Report]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objTRN_GoodsInward_Purchase.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_GoodsInward_Purchase.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRN_GoodsInward_Purchase.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraCompanyID", objTRN_GoodsInward_Purchase.paraCompanyId);
                varSqlCommand.Parameters.AddWithValue("@paraSPID", objTRN_GoodsInward_Purchase.ParaSupplierId);
                varSqlCommand.Parameters.AddWithValue("@paraSPSCID", objTRN_GoodsInward_Purchase.ParaScheduleId);
                varSqlCommand.Parameters.AddWithValue("@paraGroupID", objTRN_GoodsInward_Purchase.paraGroupId);
                varSqlCommand.Parameters.AddWithValue("@paraSubGroupID", objTRN_GoodsInward_Purchase.paraSubgroupId);
                varSqlCommand.Parameters.AddWithValue("@paraRKGroupID", objTRN_GoodsInward_Purchase.paraRKGID);
                varSqlCommand.Parameters.AddWithValue("@paraBrandID", objTRN_GoodsInward_Purchase.paraBrandID);
                varSqlCommand.Parameters.AddWithValue("@paraProCategoryID", objTRN_GoodsInward_Purchase.paraTypeID);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRN_GoodsInward_Purchase.ParaFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRN_GoodsInward_Purchase.ParaToDate);
                varSqlCommand.Parameters.AddWithValue("@paraPICode", objTRN_GoodsInward_Purchase.paraAlpha);
                varSqlCommand.Parameters.AddWithValue("@paraRateType", objTRN_GoodsInward_Purchase.paraRateType);
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


        // added by venkat on 18/09/2025 for stock conciliation
        public string udfnStockConciliation(TRN_Stock_Reconciliation_Products objTRN_Stock_Reconciliation_Products)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Stock_Reconciliation]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_Stock_Reconciliation_Products.ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaTransactionId", objTRN_Stock_Reconciliation_Products.ParaTransactionId);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", objTRN_Stock_Reconciliation_Products.ParaCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraTransferDate", objTRN_Stock_Reconciliation_Products.paraOutwardDate);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRN_Stock_Reconciliation_Products.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraTransferType", objTRN_Stock_Reconciliation_Products.paraTransferType);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_Stock_Reconciliation_Products.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRN_Stock_Reconciliation_Products.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraStockReconciliation", objTRN_Stock_Reconciliation_Products.paraStockReconciliation);
                varSqlCommand.Parameters.AddWithValue("@paraStockTransfer", objTRN_Stock_Reconciliation_Products.paraStockTransfer); 
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_Stock_Reconciliation_Products.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@ParaFlag", objTRN_Stock_Reconciliation_Products.ParaFlag); 
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_Stock_Reconciliation_Products.paraDeleteflag);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);  

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

        public DataSet udfnStockConciliationList(TRN_Stock_Reconciliation_Products objTRNG_Stock_Reconciliation_Products)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Stock_Reconciliation]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRNG_Stock_Reconciliation_Products.ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaTransactionId", objTRNG_Stock_Reconciliation_Products.ParaTransactionId);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRNG_Stock_Reconciliation_Products.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRNG_Stock_Reconciliation_Products.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRNG_Stock_Reconciliation_Products.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRNG_Stock_Reconciliation_Products.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", objTRNG_Stock_Reconciliation_Products.ParaCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRNG_Stock_Reconciliation_Products.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRNG_Stock_Reconciliation_Products.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRNG_Stock_Reconciliation_Products.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraTransType", objTRNG_Stock_Reconciliation_Products.paraTransType);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRNG_Stock_Reconciliation_Products.paraUserLocations);
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

         


        // added by venkat on 22/09/2025 for stock conciliation
        public string udfnStockConvertion(TRN_Stock_Converstion objTRN_Stock_Converstion)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Stock_Conversion]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_Stock_Converstion.ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaTransactionId", objTRN_Stock_Converstion.ParaTransactionId);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", objTRN_Stock_Converstion.ParaCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraTransferDate", objTRN_Stock_Converstion.paraOutwardDate); 
                varSqlCommand.Parameters.AddWithValue("@paraTransferType", objTRN_Stock_Converstion.paraTransferType);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_Stock_Converstion.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRN_Stock_Converstion.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraStock_Conversion", objTRN_Stock_Converstion.paraStockConversion);
                varSqlCommand.Parameters.AddWithValue("@paraStockTransfer", objTRN_Stock_Converstion.paraStockTransfer);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_Stock_Converstion.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@ParaFlag", objTRN_Stock_Converstion.ParaFlag);
                varSqlCommand.Parameters.AddWithValue("@ParaPRID", objTRN_Stock_Converstion.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_Stock_Converstion.paraDeleteflag);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);

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


        public DataSet udfnStockConverstionList(TRN_Stock_Converstion objTRN_Stock_Converstion)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Stock_Conversion]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_Stock_Converstion.ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaTransactionId", objTRN_Stock_Converstion.ParaTransactionId);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRN_Stock_Converstion.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRN_Stock_Converstion.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRN_Stock_Converstion.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRN_Stock_Converstion.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", objTRN_Stock_Converstion.ParaCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRN_Stock_Converstion.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_Stock_Converstion.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRN_Stock_Converstion.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraTransType", objTRN_Stock_Converstion.paraTransType);
                varSqlCommand.Parameters.AddWithValue("@paraUserLocations", objTRN_Stock_Converstion.paraUserLocations);
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

        //Created By:- venkat Created On:-22/08/2023
        public string udfnUserRole(int paraviewType, int paraUserRoleID, string paraNameoftheUser , int paraStatusId, string paraOriginator, string paraUserID, int paraDeleteFlag,DataTable paraUserRoleDetails, DataTable paraUserRole_Menu_Access,DataTable paraUserRole_Menu_SPL_Access)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_User_Role]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserRoleID", paraUserRoleID);
                varSqlCommand.Parameters.AddWithValue("@paraNameoftheUser", paraNameoftheUser); 
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId); 
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", paraDeleteFlag);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);
                varSqlCommand.Parameters.AddWithValue("@paraUserRoleDetails", paraUserRoleDetails);
                varSqlCommand.Parameters.AddWithValue("@paraUserRole_Menu_Access", paraUserRole_Menu_Access);
                varSqlCommand.Parameters.AddWithValue("@paraUserRole_Menu_SPL_Access", paraUserRole_Menu_SPL_Access);



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

        // Created by : Venkat
        // Created on : 03/10/2025
        public DataSet udfnUserRoleList(int paraviewType , int paraUserRoleId, int paraStatusId,int paraMenuId,string paraUserroleName,int paraType,int paraUId)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_UserRole]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserRoleId", paraUserRoleId); 
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress); 
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraMenuId", paraMenuId);
                varSqlCommand.Parameters.AddWithValue("@paraUserroleName", paraUserroleName);
                varSqlCommand.Parameters.AddWithValue("@paraUId", paraUId);
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

        // Venkat    Create date: 06/10/2025 
        public DataSet udfnMenu(MR_Menu objMR_Menu)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Menu]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objMR_Menu.ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraID", objMR_Menu.paraID);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress); 
                varSqlCommand.Parameters.AddWithValue("@paraUserRoleId", objMR_Menu.paraUserRoleId); 
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



        // added by venkat on 11/10/2025 for stock journal
        public string udfnStockJournal(TRN_Stock_Journal objTRN_Stock_Journal)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNS_Stock_Journal]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_Stock_Journal.ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaTransactionId", objTRN_Stock_Journal.ParaTransactionId);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", objTRN_Stock_Journal.ParaCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraTransferDate", objTRN_Stock_Journal.paraOutwardDate);
                varSqlCommand.Parameters.AddWithValue("@paraTransferType", objTRN_Stock_Journal.paraTransferType);
                varSqlCommand.Parameters.AddWithValue("@paraRemarks", objTRN_Stock_Journal.paraRemarks);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRN_Stock_Journal.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraStock_Journal", objTRN_Stock_Journal.paraStock_Journal);
                varSqlCommand.Parameters.AddWithValue("@paraStockTransfer", objTRN_Stock_Journal.paraStockTransfer);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objTRN_Stock_Journal.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@ParaFlag", objTRN_Stock_Journal.ParaFlag);
                varSqlCommand.Parameters.AddWithValue("@ParaPRID", objTRN_Stock_Journal.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@paraDeleteFlag", objTRN_Stock_Journal.paraDeleteflag);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);

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


        // added by venkat on 11/10/2025 for stock journal
        public DataSet udfnStockJournalList(TRN_Stock_Journal objTRN_Stock_Journal)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[TRNG_Stock_Journal]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objTRN_Stock_Journal.ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaTransactionId", objTRN_Stock_Journal.ParaTransactionId);
                varSqlCommand.Parameters.AddWithValue("@paraFromDate", objTRN_Stock_Journal.paraFromDate);
                varSqlCommand.Parameters.AddWithValue("@paraToDate", objTRN_Stock_Journal.paraToDate);
                varSqlCommand.Parameters.AddWithValue("@paraSLID", objTRN_Stock_Journal.paraSLID);
                varSqlCommand.Parameters.AddWithValue("@paraPRID", objTRN_Stock_Journal.paraPRID);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanyCode", objTRN_Stock_Journal.ParaCompanyCode);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", objTRN_Stock_Journal.paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", objTRN_Stock_Journal.paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", objTRN_Stock_Journal.paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@paraTransType", objTRN_Stock_Journal.paraTransType);
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



        // added by venkat on 17/11/2025 for label print
        public string udfnLabelPrint(MR_Product objMR_Product)
        {
            string result = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRS_Label_Print]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", objMR_Product.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraId", objMR_Product.paraId);
                varSqlCommand.Parameters.AddWithValue("@paraLanguage", objMR_Product.paraLanguage);
                varSqlCommand.Parameters.AddWithValue("@paraLPMRP", objMR_Product.paraLPMRP);
                varSqlCommand.Parameters.AddWithValue("@parasales_rate", objMR_Product.parasales_rate);
                varSqlCommand.Parameters.AddWithValue("@paraCopies", objMR_Product.paraCopies);
                varSqlCommand.Parameters.AddWithValue("@paraPrintType", objMR_Product.paraPrintType);
                varSqlCommand.Parameters.AddWithValue("@paraLabelSize", objMR_Product.paraLabelSize);
                varSqlCommand.Parameters.AddWithValue("@paraLabelTemplate", objMR_Product.paraLabelTemplate);
                varSqlCommand.Parameters.AddWithValue("@paraOriginator", objMR_Product.paraOriginator);
                varSqlCommand.Parameters.AddWithValue("@paraLabelTitle", objMR_Product.paraLabelTitle); 
                varSqlCommand.Parameters.AddWithValue("@paraProductLabelNameEng", objMR_Product.paraProductLabelNameEng); 
                varSqlCommand.Parameters.AddWithValue("@paraRetail", objMR_Product.ParaRetail);
                varSqlCommand.Parameters.AddWithValue("@parawholesale_rate", objMR_Product.parawholesale_rate);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraHostName", MainForm.pbHostName);

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
        //Added BY Sathish ON 17-11-2025 For Direct Label Print List
        public DataSet udfnLabelPrintList(MR_Product objMR_Product)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRG_Label_Print", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", objMR_Product.paraViewType);
                varSqlCommand.Parameters.AddWithValue("@paraLPID", objMR_Product.ParaProductCode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraStatus", objMR_Product.paraStatusId);
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
