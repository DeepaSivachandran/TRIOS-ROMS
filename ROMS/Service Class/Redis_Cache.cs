using ROMS.Model;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ROMS
{   //Test
    class Redis_Cache
    {
        DataError objError;
        SPCall tmpspcall = new SPCall();
        public System.Data.SqlClient.SqlConnection objConn;
        DataBind objbind = new DataBind();
        public string varServerStatus = "", varDBOP = "";
        public Redis_Cache()
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
        public string RedisConnection()
        {
            string response = "";
            try
            {
                try
                {
                    varServerStatus = new System.Net.NetworkInformation.Ping().Send("172.16.1.201").Status == System.Net.NetworkInformation.IPStatus.Success ? $"Connected" : $"Ping failed: {new System.Net.NetworkInformation.Ping().Send("172.16.1.201").Status}";
                }
                catch (System.Net.NetworkInformation.PingException ex)
                {
                    varServerStatus = $"{ex.Message}";
                }
                if (varServerStatus == "Connected")
                {
                    try
                    {
                        var options = ConfigurationOptions.Parse("172.16.1.201:6379");
                        options.AbortOnConnectFail = true;                               //This is used when the connection is fail then this will call 
                        options.SyncTimeout = 5000;                                     //This is used when the command execute delay then this will call
                        options.ConnectTimeout = 100;                                  //This is used when the connection is delay then this will call
                        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(options);
                        IDatabase db = redis.GetDatabase();
                        response = db.Execute("PING").ToString();
                    }
                    catch (RedisConnectionException ex)
                    {
                        response = ex.Message;
                        response = "Failed";
                    }
                    catch (TimeoutException ex)
                    {
                        response = "Timeout: " + ex.Message;
                    }
                    catch (Exception ex)
                    {
                        response = "Unexpected error: " + ex.Message;
                    }
                    varDBOP = response.ToString();
                }
                else
                {
                    response = "Server Timeout";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return response;
        }
        public string RedisSet(string query, string varMaster)
        {
            string response = "";
            try
            {
                _ = udfnSetAsync(query, varMaster);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return response;
        }
        private async Task udfnSetAsync(string query,string varMaster)
        {
            try
            {
                string connectstring = tmpspcall.connectionstring();

                // Connect to Redis
                var options = ConfigurationOptions.Parse("172.16.1.201:6379");
                //options.Password = "Password";
                options.AbortOnConnectFail = false;
                ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(options);
                var db = redis.GetDatabase();
                //db.Execute("FLUSHALL").ToString();
                var hashEntries = new List<HashEntry>();
                // Connect to SQL Server
                using (var sqlConnection = new SqlConnection(connectstring))
                {
                    //sqlConnection.Open();
                    await sqlConnection.OpenAsync();

                    using (var sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (var reader = await sqlCommand.ExecuteReaderAsync())
                        {
                            var spid = ""; var supplier = "";

                            foreach (var values in reader)
                            {
                                spid = reader["SPID"].ToString();
                                supplier = Convert.ToString(reader["SupplierName"].ToString());
                                var schedule = Convert.ToString(reader["ScheduleName"].ToString());
                                var spscid = Convert.ToString(reader["SPSCID"].ToString());
                                var SP_Name = Convert.ToString(reader["SP_NAME"].ToString());
                                var Supplier = Convert.ToString(reader["Supplier"].ToString());
                                hashEntries.Add(new HashEntry(Supplier.ToString(), (SP_Name,spid, spscid, supplier, schedule).ToString()));
                            }

                            _ = db.HashSetAsync(varMaster, hashEntries.ToArray());
                        }
                    }
                }
                MainForm.objPUR_GRNDetailsList.varRedisConnect = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task<DataSet> udfnGetAsync(string vartext,string varType)
        {
            DataSet ds = new DataSet();
            try
            {
                DataTable dt = new DataTable();
                //dt.Rows.Clear();
                dt.Columns.Add("SP_NAME", typeof(string));
                dt.Columns.Add("SPID", typeof(string));
                dt.Columns.Add("SPSCID", typeof(string));
                dt.Columns.Add("SupplierName", typeof(string));
                dt.Columns.Add("ScheduleName", typeof(string));
                var options = ConfigurationOptions.Parse("172.16.1.201:6379");
                ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(options);
                IDatabase db = redis.GetDatabase();
                string varProName;
                var varProductMatching = "";
                // Retrieve all entries from Redis hash
                HashEntry[] entries = await db.HashGetAllAsync(varType);
                foreach (var entry in entries)
                {
                    varProName = entry.Name.ToString();
                    varProductMatching = varProName.ToString().StartsWith(vartext.ToUpper()).ToString();    //Start with Supplier Name
                    //varProductMatching = varProName.ToString().Contains(vartext.ToUpper()).ToString();    //Contains With Supplier Name
                    if (Convert.ToBoolean(varProductMatching) == true)
                    {
                        string SupplierName = "", ScheduleName = "";
                        string Value = entry.Value;
                        var fields = Value.ToString().Split(new[] { ", " }, StringSplitOptions.None);
                        int index = fields[0].IndexOf("(");
                        if (index != -1)
                        {
                            SupplierName = fields[0].Substring(index + 1);
                        }
                        if (fields[4].EndsWith(")"))
                        {
                            ScheduleName = fields[4].Substring(0, fields[4].Length - 1);
                        }
                        dt.Rows.Add(SupplierName,fields[1],fields[2],fields[3], ScheduleName);
                    }
                }
                ds.Tables.Add(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ds;
        }
    }
}
