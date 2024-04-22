using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class TRN_Supplier_Payment
    {
        public int ViewType { get; set; } = 0;
        public int paraSupplierid { get; set; } = 0;
        public int paraScheduleId { get; set; } = 0;
        public int paraCompanyId { get; set; } = 0;
        public int paraUserID { get; set; } = 0;
        public string paraIPAddress { get; set; } = "";
        public int paraID { get; set; } = 0;
    }
}
