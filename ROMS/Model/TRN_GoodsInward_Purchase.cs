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
        public int paraGRNID { get; set; } = 0;
        public int paraCompanyId { get; set; } = 0;
        public int paraProductId { get; set; } = 0;
        public int paraDeleteFlag { get; set; } = 0;
        public int paraInwardId { get; set; } = 0;
        public string paraOriginator { get; set; } = "";
        public string paraGIP_Date { get; set; } = "";
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
        public string paraIPAddress { get; set; } = "";
        public DataTable paraTRN_GoodsInward_Purchase_Products { get; set; } = null;
    }
}
