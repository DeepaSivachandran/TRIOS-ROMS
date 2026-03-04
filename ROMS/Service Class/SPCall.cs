using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    class SPCall
    {
        public System.Data.SqlClient.SqlConnection objConn;
        DataError objError;
        private SecurityController _security;
        public SPCall()
        {
            try
            {
                _security = new SecurityController();
                objConn = new System.Data.SqlClient.SqlConnection(connectionstring());
                //objConn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnStr"]);
                if (objConn.State == ConnectionState.Closed)
                    objConn.Open();
            }
            catch (Exception ex)
            {
            }
        }
        public string connectionstring()
        {
            string connectstring = "";
            try
            {
                string path = Application.StartupPath + "\\Server Settings\\serversettings.txt";
                if (File.Exists(path))
                {
                    string lines = File.ReadAllText(path);
                    if (lines != null & lines != "")
                    {
                        string[] words = lines.Split(',');
                        // string pwd = Decrypt(words[3], "sblw-3hn8-sqoy19");
                        string pwd = _security.Decrypt(words[2], words[3]);
                        connectstring = "Data Source=" + words[0] + ";Initial Catalog=" + words[1] + ";User ID=" + words[2] + "; pwd=" + pwd + ";pooling=false" +
                        ";Encrypt=False;" + "Pooling=False;";
                        }
                }
                //  connectstring = System.Configuration.ConfigurationManager.AppSettings["ConnStr"];
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            return connectstring;
        }
        public string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public void CloseConnection()
        {
            if ((objConn == null) == true)
                return;
            if (objConn.State == ConnectionState.Open)
                objConn.Close();

            objConn = null;

        }
    }
}
