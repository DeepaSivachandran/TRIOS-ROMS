using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_BatchConversion
    {
        public int ViewType { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public string paraOriginator { get; set; } = "";
        public int paraBTID { get; set; } = 0;
        public int paraCompanyCode { get; set; } = 0;
        public string paraConversionDate { get; set; } = "";
        public int paraPRID { get; set; } = 0;
        public int paraSLID { get; set; } = 0;
        public int paraRKID { get; set; } = 0;
        public string paraMrp { get; set; } = "";
        public string paraExpiryDate { get; set; } = "";
        public string paraBatchNo { get; set; } = "";
        public decimal paraQuantity { get; set; } = 0;
        public int paraStatusId { get; set; } = 0;
        public int paraDeleteFlag { get; set; } = 0;
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public DataTable paraBatchConversion { get; set; } = null;
        public string paraUserLocations { get; set; } = "";
    }
}
