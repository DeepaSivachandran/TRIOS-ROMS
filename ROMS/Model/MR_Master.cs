using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ROMS.Model
{
    public class MR_Master
    {
        public int ViewType = 0;
        public int paraID = 0;
        public int paraPOID = 0;
        public string paraDate = "";
        public string ParaExpiryDate = "";
        public int paraProductId = 0;
        public string paraText = "";
        public int paraFlag = 0;
        public string paraTime = "";
        public string paraTimeFormat = "";
        public DataTable ParaProduct_HSN = null;
    }
}
