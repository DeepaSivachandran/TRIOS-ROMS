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
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                SecurityController _security = new SecurityController();
                //  DataService objDser = new DataService();
                string version = "v1.3.1";
              //  string path = Application.StartupPath + "\\Server Settings\\serversettings.txt";
                //if (File.Exists(pa th))
                //{
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //Application.Run(new Expandablegrd());
                    Application.Run(new Authentication());
                    //DataService objDser = new DataService();
                    ////DataSet getrelease = objDser.GetDataset("select * from TRANS_RELEASEDETAILS where VersionNumber='" + version + "'");
                    ////if (getrelease.Tables[0].Rows.Count == 0)
                    ////{
                    ////    string releaseno = objDser.displaydata("select isnull(max(ReleaseCode),0)+1 from TRANS_RELEASEDETAILS");
                    ////    objDser.ExecuteQuery("Insert into TRANS_RELEASEDETAILS(ReleaseDate,ReleaseCode,VersionNumber) values (GETDATE(),'" + releaseno + "','" + version + "') ");
                    ////}
                    //objDser.CloseConnection();
                    //string varSerialNumber = "";
                    //DataValidation obj = new DataValidation();
                    //varSerialNumber = obj.baseId();
                    //string regkey = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(varSerialNumber)).Select(s => s.ToString("x2"))); //GenerateMD5(processid + uniqueid);
                    //string foldername = obj.Encrypt("Activation");
                    //string path2 = Application.StartupPath + "\\" + foldername;
                    //if (Directory.Exists(path2))
                    //{
                    //    string encriptedtext = _security.Encrypt("Activation", regkey.ToUpper());
                    //    string[] files = Directory.GetFiles(path2);
                    //    string filename = "";
                    //    foreach (string file in files)
                    //        filename = (Path.GetFileName(file));
                    //    string decryptedfile = obj.Decrypt(filename.Replace(".sss", ""));
                    //    if (decryptedfile == "Activation")
                    //    {
                    //        path2 = path2 + "\\" + filename;
                    //        FileInfo info = new FileInfo(path2);
                    //        if (info.Exists)
                    //        {
                    //            var fileContents = System.IO.File.ReadAllText(path2);
                    //            string[] values = fileContents.Replace("\r", "").Split('\n');
                    //            if (values.Length > 1)
                    //            {
                    //                ActivationService.ActivationService activser = new ActivationService.ActivationService();
                    //                string rs = ""; string st = "";
                    //                if (encriptedtext == values[0])
                    //                {
                    //                    rs = "Success";
                    //                }
                    //                if (rs == "Success" || rs == "Activated")
                    //                {
                    //                    st = "success";
                    //                }
                    //                else if (rs == "Blocked")
                    //                {
                    //                    st = "error";
                    //                }
                    //                else { st = ""; rs = ""; }
                    //                if (st == "error" || st == "")
                    //                {
                    //                    Application.EnableVisualStyles();
                    //                    Application.SetCompatibleTextRenderingDefault(false);
                    //                    Application.Run(new Activation());
                    //                }
                    //                else
                    //                {
                    //                    Application.EnableVisualStyles();
                    //                    Application.SetCompatibleTextRenderingDefault(false);
                    //                    //Application.Run(new Expandablegrd());


                    //                    Application.Run(new Authentication());
                    //                }
                    //            }
                    //            else
                    //            {
                    //                Application.EnableVisualStyles();
                    //                Application.SetCompatibleTextRenderingDefault(false);
                    //                Application.Run(new Activation());
                    //            }
                    //        }
                    //        else
                    //        {
                    //            Application.EnableVisualStyles();
                    //            Application.SetCompatibleTextRenderingDefault(false);
                    //            Application.Run(new Activation());
                    //        }
                    //    }
                    //    else
                    //    {
                    //        Application.EnableVisualStyles();
                    //        Application.SetCompatibleTextRenderingDefault(false);
                    //        Application.Run(new Activation());
                    //    }
                    //}
                    //else
                    //{
                    //    Application.EnableVisualStyles();
                    //    Application.SetCompatibleTextRenderingDefault(false);
                    //    Application.Run(new Activation());
                    //}

                //}
                //else { Application.Run(new ServerSettings()); }
            }
            catch (Exception ex)
            {
                DataError objerror = new DataError();
                objerror.WriteFile(ex);
            }
        }
    }
}
