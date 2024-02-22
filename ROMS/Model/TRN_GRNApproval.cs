using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_GRNApproval
    {
        public int ViewType { get; set; } = 0;
        public int paraPURID { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public int paraFlag { get; set; } = 0;
        public DataTable paraApprovalProduct { get; set; } = null;
    }
}
