using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class MR_ChequeTransactionSettings
    {
        public int paraViewType { get; set; } = 0;
        public string paraUserID { get; set; } = "";
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int paraChequePrintSettingsID { get; set; } = 0;
        public string paraHostName { get; set; } = "";
        public DataTable paraMR_ChequePrintSettings { get; set; } = null; 
    }
}
