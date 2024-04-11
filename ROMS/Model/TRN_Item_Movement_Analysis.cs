using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_Item_Movement_Analysis
    {
        public int Viewtype { get; set; } = 0;
        public int paraProductId { get; set; } = 0;
        public int paraCompanyId { get; set; } = 0;
        public int paraRackId { get; set; } = 0;
        public string paratodate { get; set; } = "";
        public int paraLocationId { get; set; } = 0;
        public string parafromdate { get; set; } = "";
       
    }
}
