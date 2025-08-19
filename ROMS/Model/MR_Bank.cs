using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class MR_Bank
    {
        public int paraViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraBankName { get; set; } = "";
        public string paraShortName { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public string paraHostName { get; set; } = "";
        public string paraDeleteFlag { get; set; } = "";
        public int paraBankId { get; set; } = 0;
    }
}
