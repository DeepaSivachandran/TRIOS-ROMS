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
        // added by venkat on 13/10/2023 for PO.No. Load
        public string udfngetPONO(string paraTransactionType, string paraDate, int paraCompanyCode)
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
        public DataSet udfnMaster(int ViewType, int paraID)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Master]", tmpspcall.objConn);
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
        // Sivabharathi    Create date: 26/09/2023    Description: Voucher Settings
        public string udfnVoucherSettings(int ViewType, DataTable ParaMRS_VoucherSettings, string paraOriginator)
        {
            string varResult = "";
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRS_VoucherSettings", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaMRS_VoucherSettings", ParaMRS_VoucherSettings);
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
        public string udfnGeneralSettings(int ViewType,int paraGeneralSettingsID, decimal paraGS_CPA, decimal paraGS_DVA,int paraGS_GRNQty,int paraGS_RAD,int paraGS_IED,DataTable ParaMR_GeneralSettings_TAT, string paraOriginator)
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
        public string udfnHsn(int ViewType, int paraHsnId, int paraGstId, string paraHsnName, string paraHsnCode, int paraStatusId, string paraOriginator,string pbUserID)
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
                varSqlCommand.Parameters.AddWithValue("@paraUserID", pbUserID);
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
        public DataSet udfnHsnList(int ViewType, int paraHSNID, int paraGstId, int paraStatusId, string paraHSN_Name,string paraHSN_Code)
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
        public string udfnUnit(int paraviewType, int paraUnitId, string paraUnitName, string paraUnitSymbol, int paraUnitDecimal, int paraUnitStatusId, string paraOriginator, string paraInvoiceUnit,string paraUserID)
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
        public DataSet udfnUnitList(int paraviewType, int paraUnitid)
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
        public string udfnCity(int paraviewType, int paraCityId, string paraStateId, string paraCityName, int paraStatusId, string paraOriginator,string paraUserID)
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
        public string udfnStockTransfer(int ViewType, int paraStockTransferID, int ParaCompanycode,string paraTransferDate, int paraSLocationID,int paraDLocationID,string paraRemarks, int paraStatusId,string paraOriginator,DataTable paraStockTransfer)
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
        public DataSet udfnStockTransferList(int paraViewType,int paraStockTransferID, int paraConcern,int paraSLID,int paraDLID,int paraPRID,int paraStatus)
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
        public string udfnBroker(int paraviewType, int paraBrokerId, int paraConcern, string paraGstinNo, string paraBrokerName,
            string paraAddressLine1, string paraAddressLine2, int paraCityId, string paraPincode, string paraWhatsappNumber,
            string paraMobileNumber, int paraStatusId, string paraOriginator, DataTable ParaMR_Broker_Bank,string paraUserID)
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
                varSqlCommand.Parameters.AddWithValue("@paraGstinNo", paraGstinNo);
                varSqlCommand.Parameters.AddWithValue("@paraBrokerName", paraBrokerName);
                varSqlCommand.Parameters.AddWithValue("@paraAddressLine1", paraAddressLine1);
                varSqlCommand.Parameters.AddWithValue("@paraAddressLine2", paraAddressLine2);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", paraCityId);
                varSqlCommand.Parameters.AddWithValue("@paraPincode", paraPincode);
                varSqlCommand.Parameters.AddWithValue("@paraWhatsappNumber", paraWhatsappNumber);
                varSqlCommand.Parameters.AddWithValue("@paraMobileNumber", paraMobileNumber);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
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
        //Created By :-Sathish ; Created On :-24/08/2023
        public DataSet udfnBrokerList(int paraviewType, int paraBrokerId, int paraStatusId, int paraCityId)
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
        public string udfnStockLocation(int paraviewType, int paraStockId, int paraConcern, int paraLocationType, string paraLocationNameEnglish, string paraLocationNameTamil, string paraShortName, int paraGodownType, int paraStockApplicable, int paraStockStatusId, string paraOriginator, string paraUserID,int paraRKCreation)
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
        public DataSet udfnStockLocationList(int paraviewType, int paraConcern,int paraStockLocation,int paraId, string paraLocationName,int paraSubgroupid,int paraLocationType,int paraStatusId)
         {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_StockLocation]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", paraviewType);
                varSqlCommand.Parameters.AddWithValue("@paraConcern", paraConcern);
                varSqlCommand.Parameters.AddWithValue("@paraStockLocation", paraStockLocation);
                varSqlCommand.Parameters.AddWithValue("@paraId", paraId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationName", paraLocationName);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroupid", paraSubgroupid);
                varSqlCommand.Parameters.AddWithValue("@paraLocationType", paraLocationType);
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
        //Created By:-Sathish Created On:-18-08-2023
        public string udfnRack(int paraViewType, int paraRackId, int paraConcern, int paraStockLocation, string paraRackName, string paraShortName, string paraDescription, int paraStatusId, string paraOriginator)
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
          public DataSet udfnRackList(int paraviewType, int paraRackGroup, int paraConcernId,int paraStockLocationId,int paraRackId,string paraRackName,int paraSubGroupID,int paraStatusId)
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
        public string udfnUserCategory(int paraviewType, int paraUserCategoryId, string paraUserCategoryName, int paraStatusId, string paraOriginator,string paraUserID)
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
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
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
        public string udfnUser(int paraviewType, int paraUId, string paraNameoftheUser, string paraLoginId, int paraUserCategory, int paraUserRole, string paraPassword, int paraPassKey, int paraStatusId,string paraPasskeyValue,string paraOriginator,string paraUserID)
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
        public string udfnGroup(int ViewType, int paraPRGID, string paraPRG_EName, string paraPRG_TName, int paraStatusId, string paraOriginator,string paraUserID)
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
        public string udfnSubGroup(int ViewType, int paraPRSGID, int paraPRSG_PRGID, string paraPRSG_EName, string paraPRSG_TName, int paraStatusId, int paraSG_BatchNo, int paraPRSG_SLID, int paraPRSG_RKID, string paraOriginator, string varRackId,string paraUserID)
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
        public DataSet udfnSubGroupList(int ViewType, int paraPRSGID, string paraPRGIDs, int paraPRGID, int paraID, string paraPRSG_EName, int paraStatusID, int paraBatchNo, int paraSLId, int paraRKId)
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
        public DataSet udfnUserList(int paraviewType, string paraUserName, string paraLoginId, string paraPassword, int paraUser,int paraStatusId,string @paraPasskey)
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
             , int paraRMPROD, int paraShelflifeValue, int paraShelflifeType, string paraStatusId, string paraUserID, string paraIPAddress, string paraOriginator, int paraNetQtyUnit, DataTable paraMR_Product_BulkUpdate)
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
        public DataSet udfnproductmasterlist(int ViewType, int ParaProductCode, int paraProductCategory, int paraGroup, int paraSubgroup, string paraPicode, string paraUserID, string paraIPAddress, int ParaCompanycode, int paraStatusId, int paraBrandID, int ParaScheduleid, int paraScheduleDay, int paraRackId, int paraHsnId, int paraGstId, int paraLocationId, int paraLocationType, int paraGodownType, int paraRKGId, string paraProductName, int paraEMPId,DataTable paraStockTransfer)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("MRG_Product", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@paraViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@ParaProductCode", ParaProductCode);
                varSqlCommand.Parameters.AddWithValue("@paraProductCategory", paraProductCategory);
                varSqlCommand.Parameters.AddWithValue("@paraGroup", paraGroup);
                varSqlCommand.Parameters.AddWithValue("@paraSubgroup", paraSubgroup);
                varSqlCommand.Parameters.AddWithValue("@paraPicode", paraPicode);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", paraUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", paraIPAddress);
                varSqlCommand.Parameters.AddWithValue("@ParaCompanycode", ParaCompanycode);
                varSqlCommand.Parameters.AddWithValue("@ParaScheduleid", ParaScheduleid);
                varSqlCommand.Parameters.AddWithValue("@paraScheduleDay", paraScheduleDay);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraBrandID", paraBrandID);
                varSqlCommand.Parameters.AddWithValue("@paraRackId", paraRackId);
                varSqlCommand.Parameters.AddWithValue("@paraHsnId", paraHsnId);
                varSqlCommand.Parameters.AddWithValue("@paraGstId", paraGstId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationId", paraLocationId);
                varSqlCommand.Parameters.AddWithValue("@paraLocationType", paraLocationType);
                varSqlCommand.Parameters.AddWithValue("@paraGodownType", paraGodownType);
                varSqlCommand.Parameters.AddWithValue("@paraRKGId", paraRKGId);
                varSqlCommand.Parameters.AddWithValue("@paraEMPId", paraEMPId);
                varSqlCommand.Parameters.AddWithValue("@paraProductName", paraProductName);
                varSqlCommand.Parameters.AddWithValue("@paraStockTransfer", paraStockTransfer);
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


        public string udfnBrand(int ViewType, int paraBDID, string paraBD_EName, string paraBD_TName, int paraStatusId, string paraPRSGID, string paraOriginator,string paraUserID)
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
        public string udfnRackGroup(int ViewType, int paraRKGID, int paraRKG_COMID, string paraRKG_Name, string paraRKGR_RKID, string paraRKGU_UID, int paraStatusId, string paraOriginator,string paraUserID)
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
        public DataSet udfnRackGroupList(int ViewType, int paraCompanyId, int paraLocationId,int paraRackGroupId,int paraStatusId,string paraRKGName)
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
        public string udfnRepMaster(int ViewType, int paraRepId, string paraRepName, string paracompanyname, string paraphoneno, string parawhatsapp, string paraBrandID, int ParaStatus, string paraOriginator,string paraUserID)
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

        public DataSet udfnRepMasterList(int ViewType, int paraRepId, string paraUserID, string paraIPAddress,int paraStatusId)
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
              int ParaSupplierOrderid, int paraordertype, string ParaProductId, string parabankname, string paraBankShortName, string paraBranchName,
              string paraAccNo, string paraIFSC, string paraAccountName, string paraBrand, string ParaSupplierPayment)
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

                varSqlCommand.Parameters.AddWithValue("@parabankname", parabankname);
                varSqlCommand.Parameters.AddWithValue("@paraBankShortName", paraBankShortName);
                varSqlCommand.Parameters.AddWithValue("@paraBranchName", paraBranchName);
                varSqlCommand.Parameters.AddWithValue("@paraAccNo", paraAccNo);
                varSqlCommand.Parameters.AddWithValue("@paraIFSC", paraIFSC);
                varSqlCommand.Parameters.AddWithValue("@paraAccountName", paraAccountName);
                varSqlCommand.Parameters.AddWithValue("@paraBrand", paraBrand);
                varSqlCommand.Parameters.AddWithValue("@ParaSupplierPayment", ParaSupplierPayment);
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
        public DataSet udfnSupplierList(int ViewType,int paraSupplierid,int paraSupplierScheduleid,int pardayid,int paraOrderId,string @paraSupplierName,int paraordertype,int paraStatusId,int paraCompanycode,string paraProductType,int paraCityId,int paraStateId,int paraGstType,int paraPaymentTerm,int paraReturnPolicy)
        {
            DataSet ds = new DataSet();
            try
            {
                tmpspcall = new SPCall();
                SqlCommand varSqlCommand = new SqlCommand("[MRG_Supplier]", tmpspcall.objConn);
                varSqlCommand.CommandType = CommandType.StoredProcedure;
                varSqlCommand.Parameters.AddWithValue("@ViewType", ViewType);
                varSqlCommand.Parameters.AddWithValue("@paraUserID", MainForm.pbUserID);
                varSqlCommand.Parameters.AddWithValue("@paraIPAddress", MainForm.pbIpAddress);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierid", paraSupplierid);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierScheduleid", paraSupplierScheduleid);
                varSqlCommand.Parameters.AddWithValue("@pardayid", pardayid);
                varSqlCommand.Parameters.AddWithValue("@paraOrderId", paraOrderId);
                varSqlCommand.Parameters.AddWithValue("@paraSupplierName", paraSupplierName);
                varSqlCommand.Parameters.AddWithValue("@paraordertype", paraordertype);
                varSqlCommand.Parameters.AddWithValue("@paraStatusId", paraStatusId);
                varSqlCommand.Parameters.AddWithValue("@paraCompanycode", paraCompanycode);
                varSqlCommand.Parameters.AddWithValue("@paraProductType", paraProductType);
                varSqlCommand.Parameters.AddWithValue("@paraCityId", paraCityId);
                varSqlCommand.Parameters.AddWithValue("@paraStateId", paraStateId);
                varSqlCommand.Parameters.AddWithValue("@paraGstType", paraGstType);
                varSqlCommand.Parameters.AddWithValue("@paraPaymentTerm", paraPaymentTerm);
                varSqlCommand.Parameters.AddWithValue("@paraReturnPolicy", paraReturnPolicy);
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
        public string udfnEmployee(int paraViewType, int paraEMPID, string paraEMPCode, string paraEMPName, int paraCTID, int paraSTSID, string paraOriginator,string paraUserID)
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
    }

}
