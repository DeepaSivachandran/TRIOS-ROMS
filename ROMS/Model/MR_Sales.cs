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

        // -------------------- Card Payment Report --------------------
        public int paraConcernId { get; set; } = 0;
        public string paraFromDate { get; set; } = "";
        public string paraToDate { get; set; } = "";
        public int paraMachineId { get; set; } = 0;
        public int paraProviderId { get; set; } = 0;
        public int paraTypeId { get; set; } = 0;
        public string paraBillNo { get; set; } = "";
        public string paraBillAmt { get; set; } = "";
        public int paraFlag { get; set; } = 0;
        public string paraDays { get; set; } = "";
        public string paraMonths { get; set; } = "";

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
        public string paraLandlineNo { get; set; } = "";
        public int paraVehicleTypeId { get; set; } = 0;
        public int paraUnitId { get; set; } = 0;
        public string paraCode { get; set; } = "";

        // -------------------- Mobile --------------------
        public int paraMobileId { get; set; } = 0;
        public string paraMobileName { get; set; } = "";
        public int paraVendor { get; set; } = 0;

        // -------------------- Transport --------------------
        public int paraTransportId { get; set; } = 0;
        public string paraTransportEName { get; set; } = "";
        public string paraTransportTName { get; set; } = "";
        public string paraContactPersonName { get; set; } = "";

        // -------------------- Transport --------------------
        public int paraMHId { get; set; } = 0;
        public int paraAreaId { get; set; } = 0;
        public int paraRouteId { get; set; } = 0;
        public string paraMHEName { get; set; } = "";
        public string paraMHTName { get; set; } = "";
        public string paraDistance { get; set; } = "";
        public string paraTeller { get; set; } = "";
        public string paraReason { get; set; } = "";

        // -------------------- Customer --------------------
        public int paraCustomerId { get; set; } = 0;
        public string paraCUS_Name { get; set; } = "";
        public string paraCUS_ContactNo { get; set; } = "";
        public string paraCUS_WhatsappNo { get; set; } = "";
        public int paraCUS_CategoryTypeID { get; set; } = 0;
        public int paraCUS_TypeID { get; set; } = 0;
        public string paraCUS_GSTIN { get; set; } = "";
        public int paraCUS_Credit_Limit { get; set; } = 0;
        public string paraCUS_ReferenceName { get; set; } = "";
        public int paraCUS_CreditDays { get; set; } = 0;
        public int paraCUS_TotalInvoice { get; set; } = 0;
        public float paraCUS_OpeningBalance { get; set; } = 0;
        public int paraCUS_OpeningBalanceType { get; set; } = 0;

        public string para_Billing_Address1 { get; set; } = "";
        public string para_Billing_Address2 { get; set; } = "";
        public int para_Billing_AID { get; set; } = 0;
        public int para_Billing_CTYID { get; set; } = 0;
        public int para_Billing_STID { get; set; } = 0;
        public string para_Billing_Pincode { get; set; } = "";
        public string para_Billing_Landmark { get; set; } = "";

        public string para_Shipping_Address1 { get; set; } = "";
        public string para_Shipping_Address2 { get; set; } = "";
        public int para_Shipping_AID { get; set; } = 0;
        public int para_Shipping_CTYID { get; set; } = 0;
        public int para_Shipping_STID { get; set; } = 0;
        public string para_Shipping_Pincode { get; set; } = "";
        public string para_Shipping_Landmark { get; set; } = "";

        // -------------------- Transport --------------------
        public int paraABID { get; set; } = 0;
        public int paraType { get; set; } = 0;
        public int paraCTYID { get; set; } = 0;
        public int paraBillId { get; set; } = 0;

        // -------------------- Customer Group --------------------
        public int paraContactGroupId { get; set; } = 0;
        public int paraGSTTypeId { get; set; } = 0;
        public int paraPrintType { get; set; } = 0;
        public string paraCONGroupEName { get; set; } = "";
        public string paraCONGroupTName { get; set; } = "";
        public string paraBrandName { get; set; } = "";
    }

}
