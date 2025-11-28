using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMS.Model
{
    class MR_Sales
    {
        // -------------------- Common Parameters --------------------
        public int paraViewType { get; set; } = 0;
        public int paraStatusId { get; set; } = 0;
        public string paraOriginator { get; set; } = "";

        // -------------------- Customer Type --------------------
        public int paraCusTypeId { get; set; } = 0;
        public string paraCusTypeEName { get; set; } = "";
        public string paraCusTypeTName { get; set; } = "";

        // -------------------- Vehicle --------------------
        public int paraVehicleId { get; set; } = 0;
        public string paraVehicleName { get; set; } = "";
        public string paraShortName { get; set; } = "";
        public string paraRegisterNo { get; set; } = "";
        public string paraCapacity { get; set; } = "";

        // -------------------- Delivery Person --------------------
        public int paraDeliveryPersonId { get; set; } = 0;
        public string paraName { get; set; } = "";
        public string paraMobileNo { get; set; } = "";
        public string paraCode { get; set; } = "";

        // -------------------- Mobile --------------------
        public int paraMobileId { get; set; } = 0;
        public string paraMobileName { get; set; } = "";
        public int paraVendor { get; set; } = 0;
    }
}
