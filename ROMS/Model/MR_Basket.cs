using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ROMS.Model
{
    public class MR_Basket
    {
        public int paraViewType { get; set; } = 0;
        public int paraBasketId { get; set; } = 0;
        public int paraTypeId { get; set; } = 0;
        public int paraBasketNo { get; set; } = 0; 
        public string paraOriginator { get; set; } = ""; 
    }
}
