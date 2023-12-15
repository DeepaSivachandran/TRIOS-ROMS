using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class MR_Product
    {
        public int paraViewType = 0;
        public int ParaProductCode = 0;
        public int paraUserID = 0;
        public string paraIPAddress = "";
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
        public int paraGstId AS INT =0, @paraLocationId AS INT =0, @paraLocationType AS INT =0, @paraGodownType AS INT =0, @paraRKGId AS INT = 0, @paraEMPId as INT =0,@paraProductName AS NVARCHAR(150)=NULL,@ParaSupplierId as int =0,@ParaFromDate AS NVARCHAR(100)='',@ParaToDate AS NVARCHAR(100)='',


        public string ParaProductsCode = "";
        public string paraHSNCode = "";
        public DataTable paraStockTransfer = null;
        public int paraId = 0;
        public DataTable paraDamageEntry = null;
    }
}
