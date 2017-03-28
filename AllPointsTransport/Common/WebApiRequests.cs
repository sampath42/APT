using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APT.BusinessObjects.Models;
namespace AllPointsTransport.Common
{
    public class WebApiRequests
    {
        internal static readonly string AuthenticateUser = "Account/AuthenticateUser";
        internal static readonly string BillingItems = "WorkOrders/BillingItems";

        internal static readonly string BillTo = "WorkOrders/BillTo";
        internal static readonly string Destination="WorkOrders/Destination";
        internal static readonly string Origin = "WorkOrders/Origin";
        internal static readonly string TypeOfMove = "WorkOrders/TypeOfMove";

        internal static readonly string EquipmentPickup = "WorkOrders/EquipmentPickup";
        internal static readonly string EquipmentReturn = "WorkOrders/EquipmentReturn";
        internal static readonly string Broker = "WorkOrders/Broker";
        internal static readonly string EquipmentSize = "WorkOrders/EquipmentSize";
        internal static readonly string ChassisProvider = "WorkOrders/ChassisProvider";
        internal static readonly string EquipmentProvider = "WorkOrders/EquipmentProvider";

        internal static readonly string TypeOfLoad = "WorkOrders/TypeOfLoad";
        internal static readonly string PayType = "WorkOrders/PayType";

        internal static readonly string GetWorkOrders = "WorkOrders/GetWorkOrders";



    }
}