using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    public class MR_Product
    {
        public int paraViewType = 0;
        public int paraFlag = 0;
        public int ParaProductCode = 0;
        public int paraUserID = 0;
        public string paraIPAddress = "";
        public string ParaPOID = "";
        public string ParaDCID = "";
        public int ParaCompanycode = 0;
        public int paraProductCategory = 0;
        public int paraGroup = 0;
        public int paraSubgroup = 0;
        public string paraPicode = "";
        public int paraStatusId = 0;
        public int paraBrandID = 0;
        public string ParaScheduleid = "";
        public string paraScheduleDay = "";
        public int paraRackId = 0;
        public int paraHsnId = 0;
        public int paraGstId = 0;
        public int paraLocationId = 0;
        public int paraLocationType = 0;
        public int paraGodownType = 0;
        public int paraRKGId = 0;
        public int paraEMPId = 0;
        public int ParaRMFlag = 0;
        public string paraProductName = "";
        public int ParaSupplierId = 0;
        public string ParaFromDate = "";
        public string ParaToDate = "";
        public string ParaProductsCode = "";
        public string paraHSNCode = "";
        public DataTable paraStockTransfer = null;
        public DataTable paraPurchaseAutoComplete = null;
        public int paraId = 0;
        public int ParaGRNID = 0;
        public DataTable paraDamageEntry = null;
        public string paraCreatedON = "";
        public int paraLabelCount = 0;
        public int paraType = 0;
        public double ParaMRP = 0;
        public double ParaRetail = 0;
        public int paraSubgroupType = 0;
        public int paraFilterDate = 0;
    }
}
