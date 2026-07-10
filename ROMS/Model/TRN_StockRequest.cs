using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    public class TRN_StockRequest
    {
        public int ViewType { get; set; } = 0;
        public int paraStockRequestID { get; set; } = 0;
        public int ParaCompanycode { get; set; } = 0;
        public string paraRequestDate { get; set; } = "";
        public string paraRemarks { get; set; } = "";
        public string ParaSTFromDate { get; set; } = "";
        public string ParaSTToDate { get; set; } = "";
        public int paraPRID { get; set; } = 0;
        public int paraStatusId { get; set; } = 0;
        public int paraSLID { get; set; } = 0;
        public int paraDeleteFlag { get; set; } = 0;
        public string paraOriginator { get; set; } = "";
        public DataTable paraStockRequest { get; set; } = null;
        public byte[] paraQrimg { get; set; } = null;
        public string paraUserLocations { get; set; } = "";
        public int paraRackGroupID { get; set; } = 0;
        public int paraProTypeID { get; set; } = 0;
        public int paraRequestTypeID { get; set; } = 0;
        public string paraBillNo { get; set; } = "";
        public int paraLoadByRackGroup { get; set; } = 0;
        public int paraRKGID { get; set; } = 0;
        public int paraProductTypeID { get; set; } = 0; 
        public int paraTellerID { get; set; } = 0; 
        public int paraFlag { get; set; } = 0; 
        public string paraLocationIDs { get; set; } = ""; 
        public string paraProductIDs { get; set; } = ""; 
    }
}
