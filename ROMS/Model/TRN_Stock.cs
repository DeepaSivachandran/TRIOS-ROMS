using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_Stock
    {
        public int ViewType { get; set; } = 0;
        public int paraPRID { get; set; } = 0;
        public int paraCOMID { get; set; } = 0;
        public int paraSLID { get; set; } = 0;
        public int paraMonth { get; set; } = 0;
        public string paraPICode { get; set; } = "";
        public int paraGroupID { get; set; } = 0;
        public int paraSubGroupID { get; set; } = 0;
        public int paraBrandID { get; set; } = 0;
        public int paraStockType { get; set; } = 0;
        public int paraDays { get; set; } = 0;
        public int paraOrder { get; set; } = 0;
        public int paraFilterType { get; set; } = 0;
    }
}
