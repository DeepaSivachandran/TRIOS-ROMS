using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    public class TRN_Damage
    {
        public int ViewType { get; set; } = 0;
        public int paraDamageEntryID { get; set; } = 0;
        public int ParaCompanycode { get; set; } = 0;
        public string paraTransferDate { get; set; } = "";
        public int paraLocationID { get; set; } = 0;
        public int paraDeleteFlag { get; set; } = 0;
        public string paraRemarks { get; set; } = "";
        public int paraStatusId { get; set; } = 0;
        public string paraOriginator { get; set; } = "";
        public string paraEmployeeId { get; set; } = "";
        public int paraSHID { get; set; } = 0;
        public int paraDMFromOtherLoc { get; set; } = 0;
        public DataTable paraDamageEntry { get; set; } = null;
        public byte[] paraQrimg { get; set; } = null;
    }
}
