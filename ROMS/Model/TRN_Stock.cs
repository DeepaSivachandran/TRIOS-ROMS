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
    }
}
