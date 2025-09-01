using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    static class Program
    {
        public static int varFormClose = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public static void Main()
        {
            try
            {
                SecurityController _security = new SecurityController();
                //  DataService objDser = new DataService();
                string VersionNo = System.Configuration.ConfigurationManager.AppSettings["versionno"];
              //  string path = Application.StartupPath + "\\Server Settings\\serversettings.txt";

                //////////////  Enter Version No Here   /////////////
                //SPDataService objspservice = new SPDataService();
                //objspservice.udfnReleaseVersion(VersionNo.Trim());
                //objspservice.CloseConnection();
                //  string path = Application.StartupPath + "\\Server Settings\\serversettings.txt";
                //if (File.Exists(pa th))
                //{
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //Application.Run(new Expandablegrd());
                    Application.Run(new Authentication());
                if (varFormClose == 1)
                {
                    varFormClose = 0;
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                }
            }
            catch (Exception ex)
            {
                DataError objerror = new DataError();
                objerror.WriteFile(ex);
            }
        }
    }
}
