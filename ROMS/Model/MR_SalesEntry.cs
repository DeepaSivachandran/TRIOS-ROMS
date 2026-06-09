using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    public class MR_SalesEntry
    {
        public int paraViewType = 0;
        public int paraUserID = 0;
        public string paraIPAddress = "";
        public int ParaCompanycode = 0;
        public int paraGroup = 0;
        public int paraSubgroup = 0;
        public int paraBrandID = 0;
        public string paraSupplier = "";
        public int paraSupplierID = 0;
        public int ParaScheduleid = 0;
        public string paraAlpha = "";
        public int paraProductCategory = 0;
        public int paraProductNameID = 0;
        public int paraType = 0;
        public string paraUnitId = "";
        public string paraFilterType = "";
        public string paraRateCategoryIDs = "";
        public DataTable ParaSalesEntry { get; set; } = null;
    }
}
