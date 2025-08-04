using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_GoodsInward_Purchase
    {
        public int ViewType { get; set; } = 0;

        //@ParaFromDate AS NVARCHAR(100)='',@ParaToDate AS NVARCHAR(100)='',@paraGRNCompanyID AS INT=0,@paraPURCompanyID AS INT=0,@ParaGRNSupplierId AS INT=0,
        //    @ParaPURSupplierId AS INT=0,@paraGRNSLID AS INT=0,@paraPURSLID AS INT=0
        public string ParaFromDate { get; set; } = "";
        public string ParaToDate { get; set; } = "";
        public int paraPurchaseID { get; set; } = 0;
        public int paraPurchaseDCID { get; set; } = 0;
        public int paraID { get; set; } = 0;
        public int paraRemarkFlag { get; set; } = 0;
        public int paraFlag { get; set; } = 0;
        public int paraGRNID { get; set; } = 0;
        public int paraTypeID { get; set; } = 0;
        public int paraCompanyId { get; set; } = 0;
        public int paraProductId { get; set; } = 0;
        public int paraDeleteFlag { get; set; } = 0;
        public int paraInwardId { get; set; } = 0;
        public string paraOriginator { get; set; } = "";
        public string paraGIP_Date { get; set; } = "";
        public string paraGIP_TransDate { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public string paraGIP_NO { get; set; } = "";
        public string paraHostName { get; set; } = "";
        public int paraLocationID { get; set; } = 0;
        public int ParaSupplierId { get; set; } = 0;
        public int paraRackID { get; set; } = 0;
        public int paraSLID { get; set; } = 0;
        public int paraStatusID { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public int paraInwardPurchaseID { get; set; } = 0;
        public int ParaScheduleId { get; set; } = 0;
        public int paraOrderBy { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string ParaInwardDate { get; set; } = "";
        public string ParaExpiryDate { get; set; } = "";
        public int paraEditFlag { get; set; } = 0;
        public DataTable paraTRN_GoodsInward_Purchase_Products { get; set; } = null;
        public string paraAlpha { get; set; } = "";
        public int paraGroupId { get; set; } = 0;
        public int paraSubgroupId { get; set; } = 0;
        public int paraEntryTypeID { get; set; } = 0;
    }
}
