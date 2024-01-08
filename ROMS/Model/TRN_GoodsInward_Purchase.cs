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
        public int ParaSupplierId { get; set; } = 0;
        public int paraSLID { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public DataTable paraGoodsInwardPurchase { get; set; } = null;
    }
}
