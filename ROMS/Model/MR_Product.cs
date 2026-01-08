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
        public DataTable paraStockAdjustment = null;
        public string paraCreatedON = "";
        public int paraLabelCount = 0;
        public int paraType = 0;
        public double ParaMRP = 0;
        public double ParaRetail = 0;
        public int paraSubgroupType = 0;
        public int paraFilterDate = 0;
        public int paraUserCode = 0;
        public string paraTeller = "";
        public string paraUserLocations = "";
        public int paraProductType = 0;
        public int paraRackStatusID = 0;
        public int paraLanguage = 0;
        public float paraLPMRP = 0;
        public float parasales_rate = 0;
        public float parawholesale_rate = 0;
        public int paraCopies = 0;
        public int paraPrintType = 0;
        public int paraLabelSize = 0;
        public string paraLabelTemplate ="";
        public int paraLabelTitle = 0; 
        public string paraProductLabelNameEng = "";
        public string paraOriginator = "";
        public int ParaOrderby = 0;
        public int ParaRate = 0;
        public int ParaStockType = 0;
        public int paraImageType = 0;
        public int paraUnitId = 0;

        public DataTable paraSplFieldMapped = null;


        // Params for rate category  
        public string paraprefixcode = "";
        public string paraprefixtname = "";
        public string paraprefixename = "";
        public string parasuffixtname = "";
        public string parasuffixename = "";
        public string paradescription = "";
        public int paraRateId = 0;
        public int paraRateSno = 0;
        public DataTable paraBulkStatus = null;
        public DataTable paraBulkMinqty = null;
        

        public int paraRateCategory = 0;        
        public string paraRateCategorys = "0";
    }
}
