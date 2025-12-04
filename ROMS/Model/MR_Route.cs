using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ROMS.Model
{
    public class MR_Route
    {
        public int ViewType = 0;
        public int paraRouteId = 0;
        public string paraRouteTName = "";
        public string paraRouteEName = ""; 
        public int paraStatusId = 0;
        public int paraUserID = 0;
        public string paraIPAddress = "";
        public string paraOriginator = "";
        public string paraHostName = "";
        public int paraOrderNo = 0; 
        public int paraUserRoleId = 0;   
        public DataTable paraAreaRoute = null;   
    }
}
