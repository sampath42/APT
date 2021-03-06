﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APT.BusinessObjects.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AllPointsTransportEntities : DbContext
    {
        public AllPointsTransportEntities()
            : base("name=AllPointsTransportEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<APTAdditionalItems_Master> APTAdditionalItems_Master { get; set; }
        public virtual DbSet<APTAddress_Master> APTAddress_Master { get; set; }
        public virtual DbSet<APTUserRole> APTUserRoles { get; set; }
        public virtual DbSet<APTUser> APTUsers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<DriverPay> DriverPays { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Legs_RateQuote> Legs_RateQuote { get; set; }
        public virtual DbSet<Payroll> Payrolls { get; set; }
        public virtual DbSet<RateQuote> RateQuotes { get; set; }
        public virtual DbSet<RateTable> RateTables { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<RowColor> RowColors { get; set; }
        public virtual DbSet<RowColorsDriver> RowColorsDrivers { get; set; }
        public virtual DbSet<RQAdditionalItem> RQAdditionalItems { get; set; }
        public virtual DbSet<RQLeg> RQLegs { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScreenMaster> ScreenMasters { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<StopTable> StopTables { get; set; }
        public virtual DbSet<TaskManagement> TaskManagements { get; set; }
        public virtual DbSet<TemplatesDriverPay> TemplatesDriverPays { get; set; }
        public virtual DbSet<TemplatesWO> TemplatesWOes { get; set; }
        public virtual DbSet<TemplatesWOLineItem> TemplatesWOLineItems { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }
        public virtual DbSet<WOLineItem> WOLineItems { get; set; }
        public virtual DbSet<WOLineItems_RateQuote> WOLineItems_RateQuote { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<WOTemplate> WOTemplates { get; set; }
        public virtual DbSet<APTRate_Master> APTRate_Master { get; set; }
    
        public virtual ObjectResult<Nullable<int>> ConvertToWO(Nullable<int> rateQuoteId, string selectedRateQuoteFrom)
        {
            var rateQuoteIdParameter = rateQuoteId.HasValue ?
                new ObjectParameter("RateQuoteId", rateQuoteId) :
                new ObjectParameter("RateQuoteId", typeof(int));
    
            var selectedRateQuoteFromParameter = selectedRateQuoteFrom != null ?
                new ObjectParameter("SelectedRateQuoteFrom", selectedRateQuoteFrom) :
                new ObjectParameter("SelectedRateQuoteFrom", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ConvertToWO", rateQuoteIdParameter, selectedRateQuoteFromParameter);
        }
    
        public virtual int CreateRateQuote(string billTo, string to, string gUID)
        {
            var billToParameter = billTo != null ?
                new ObjectParameter("BillTo", billTo) :
                new ObjectParameter("BillTo", typeof(string));
    
            var toParameter = to != null ?
                new ObjectParameter("To", to) :
                new ObjectParameter("To", typeof(string));
    
            var gUIDParameter = gUID != null ?
                new ObjectParameter("GUID", gUID) :
                new ObjectParameter("GUID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateRateQuote", billToParameter, toParameter, gUIDParameter);
        }
    
        public virtual int CreateWorkOrdersSP(Nullable<int> invoicedDate, string billTo, string broker, string reference, string pO, Nullable<System.DateTime> apptTime, string chassisProvider, string container1, string chassis, Nullable<bool> streetTurn, string linkedProNum, string container2, string origin, string typeOfMove, string equipmentProvider, string equipmentSize, string equipmentPickup, string release, string booking, Nullable<bool> bOL, string seal, string weight, string pieceCount, string destination, string locationHours, Nullable<System.DateTime> eTA, Nullable<System.DateTime> storageLFD, Nullable<System.DateTime> perDiemLFD, Nullable<System.DateTime> cutoff, Nullable<System.DateTime> outgateReceipt, Nullable<System.DateTime> ingateReceipt, Nullable<System.DateTime> readyNotification, string notesPrivate, string notesInvoice, Nullable<int> duration, string commodity, Nullable<int> workOrderNo, string pro, string status, string apptNumber, Nullable<System.DateTime> datePaid, string equipmentReturn)
        {
            var invoicedDateParameter = invoicedDate.HasValue ?
                new ObjectParameter("InvoicedDate", invoicedDate) :
                new ObjectParameter("InvoicedDate", typeof(int));
    
            var billToParameter = billTo != null ?
                new ObjectParameter("BillTo", billTo) :
                new ObjectParameter("BillTo", typeof(string));
    
            var brokerParameter = broker != null ?
                new ObjectParameter("Broker", broker) :
                new ObjectParameter("Broker", typeof(string));
    
            var referenceParameter = reference != null ?
                new ObjectParameter("Reference", reference) :
                new ObjectParameter("Reference", typeof(string));
    
            var pOParameter = pO != null ?
                new ObjectParameter("PO", pO) :
                new ObjectParameter("PO", typeof(string));
    
            var apptTimeParameter = apptTime.HasValue ?
                new ObjectParameter("ApptTime", apptTime) :
                new ObjectParameter("ApptTime", typeof(System.DateTime));
    
            var chassisProviderParameter = chassisProvider != null ?
                new ObjectParameter("ChassisProvider", chassisProvider) :
                new ObjectParameter("ChassisProvider", typeof(string));
    
            var container1Parameter = container1 != null ?
                new ObjectParameter("Container1", container1) :
                new ObjectParameter("Container1", typeof(string));
    
            var chassisParameter = chassis != null ?
                new ObjectParameter("Chassis", chassis) :
                new ObjectParameter("Chassis", typeof(string));
    
            var streetTurnParameter = streetTurn.HasValue ?
                new ObjectParameter("StreetTurn", streetTurn) :
                new ObjectParameter("StreetTurn", typeof(bool));
    
            var linkedProNumParameter = linkedProNum != null ?
                new ObjectParameter("LinkedProNum", linkedProNum) :
                new ObjectParameter("LinkedProNum", typeof(string));
    
            var container2Parameter = container2 != null ?
                new ObjectParameter("Container2", container2) :
                new ObjectParameter("Container2", typeof(string));
    
            var originParameter = origin != null ?
                new ObjectParameter("Origin", origin) :
                new ObjectParameter("Origin", typeof(string));
    
            var typeOfMoveParameter = typeOfMove != null ?
                new ObjectParameter("TypeOfMove", typeOfMove) :
                new ObjectParameter("TypeOfMove", typeof(string));
    
            var equipmentProviderParameter = equipmentProvider != null ?
                new ObjectParameter("EquipmentProvider", equipmentProvider) :
                new ObjectParameter("EquipmentProvider", typeof(string));
    
            var equipmentSizeParameter = equipmentSize != null ?
                new ObjectParameter("EquipmentSize", equipmentSize) :
                new ObjectParameter("EquipmentSize", typeof(string));
    
            var equipmentPickupParameter = equipmentPickup != null ?
                new ObjectParameter("EquipmentPickup", equipmentPickup) :
                new ObjectParameter("EquipmentPickup", typeof(string));
    
            var releaseParameter = release != null ?
                new ObjectParameter("Release", release) :
                new ObjectParameter("Release", typeof(string));
    
            var bookingParameter = booking != null ?
                new ObjectParameter("Booking", booking) :
                new ObjectParameter("Booking", typeof(string));
    
            var bOLParameter = bOL.HasValue ?
                new ObjectParameter("BOL", bOL) :
                new ObjectParameter("BOL", typeof(bool));
    
            var sealParameter = seal != null ?
                new ObjectParameter("Seal", seal) :
                new ObjectParameter("Seal", typeof(string));
    
            var weightParameter = weight != null ?
                new ObjectParameter("Weight", weight) :
                new ObjectParameter("Weight", typeof(string));
    
            var pieceCountParameter = pieceCount != null ?
                new ObjectParameter("PieceCount", pieceCount) :
                new ObjectParameter("PieceCount", typeof(string));
    
            var destinationParameter = destination != null ?
                new ObjectParameter("Destination", destination) :
                new ObjectParameter("Destination", typeof(string));
    
            var locationHoursParameter = locationHours != null ?
                new ObjectParameter("LocationHours", locationHours) :
                new ObjectParameter("LocationHours", typeof(string));
    
            var eTAParameter = eTA.HasValue ?
                new ObjectParameter("ETA", eTA) :
                new ObjectParameter("ETA", typeof(System.DateTime));
    
            var storageLFDParameter = storageLFD.HasValue ?
                new ObjectParameter("StorageLFD", storageLFD) :
                new ObjectParameter("StorageLFD", typeof(System.DateTime));
    
            var perDiemLFDParameter = perDiemLFD.HasValue ?
                new ObjectParameter("PerDiemLFD", perDiemLFD) :
                new ObjectParameter("PerDiemLFD", typeof(System.DateTime));
    
            var cutoffParameter = cutoff.HasValue ?
                new ObjectParameter("Cutoff", cutoff) :
                new ObjectParameter("Cutoff", typeof(System.DateTime));
    
            var outgateReceiptParameter = outgateReceipt.HasValue ?
                new ObjectParameter("OutgateReceipt", outgateReceipt) :
                new ObjectParameter("OutgateReceipt", typeof(System.DateTime));
    
            var ingateReceiptParameter = ingateReceipt.HasValue ?
                new ObjectParameter("IngateReceipt", ingateReceipt) :
                new ObjectParameter("IngateReceipt", typeof(System.DateTime));
    
            var readyNotificationParameter = readyNotification.HasValue ?
                new ObjectParameter("ReadyNotification", readyNotification) :
                new ObjectParameter("ReadyNotification", typeof(System.DateTime));
    
            var notesPrivateParameter = notesPrivate != null ?
                new ObjectParameter("NotesPrivate", notesPrivate) :
                new ObjectParameter("NotesPrivate", typeof(string));
    
            var notesInvoiceParameter = notesInvoice != null ?
                new ObjectParameter("NotesInvoice", notesInvoice) :
                new ObjectParameter("NotesInvoice", typeof(string));
    
            var durationParameter = duration.HasValue ?
                new ObjectParameter("Duration", duration) :
                new ObjectParameter("Duration", typeof(int));
    
            var commodityParameter = commodity != null ?
                new ObjectParameter("Commodity", commodity) :
                new ObjectParameter("Commodity", typeof(string));
    
            var workOrderNoParameter = workOrderNo.HasValue ?
                new ObjectParameter("WorkOrderNo", workOrderNo) :
                new ObjectParameter("WorkOrderNo", typeof(int));
    
            var proParameter = pro != null ?
                new ObjectParameter("Pro", pro) :
                new ObjectParameter("Pro", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var apptNumberParameter = apptNumber != null ?
                new ObjectParameter("ApptNumber", apptNumber) :
                new ObjectParameter("ApptNumber", typeof(string));
    
            var datePaidParameter = datePaid.HasValue ?
                new ObjectParameter("DatePaid", datePaid) :
                new ObjectParameter("DatePaid", typeof(System.DateTime));
    
            var equipmentReturnParameter = equipmentReturn != null ?
                new ObjectParameter("EquipmentReturn", equipmentReturn) :
                new ObjectParameter("EquipmentReturn", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateWorkOrdersSP", invoicedDateParameter, billToParameter, brokerParameter, referenceParameter, pOParameter, apptTimeParameter, chassisProviderParameter, container1Parameter, chassisParameter, streetTurnParameter, linkedProNumParameter, container2Parameter, originParameter, typeOfMoveParameter, equipmentProviderParameter, equipmentSizeParameter, equipmentPickupParameter, releaseParameter, bookingParameter, bOLParameter, sealParameter, weightParameter, pieceCountParameter, destinationParameter, locationHoursParameter, eTAParameter, storageLFDParameter, perDiemLFDParameter, cutoffParameter, outgateReceiptParameter, ingateReceiptParameter, readyNotificationParameter, notesPrivateParameter, notesInvoiceParameter, durationParameter, commodityParameter, workOrderNoParameter, proParameter, statusParameter, apptNumberParameter, datePaidParameter, equipmentReturnParameter);
        }
    
        public virtual int UpdateWorkOrdersSP(Nullable<int> invoicedDate, string billTo, string broker, string reference, string pO, Nullable<System.DateTime> apptTime, string chassisProvider, string container1, string chassis, Nullable<bool> streetTurn, string linkedProNum, string container2, string origin, string typeOfMove, string equipmentProvider, string equipmentSize, string equipmentPickup, string release, string booking, Nullable<bool> bOL, string seal, string weight, string pieceCount, string destination, string locationHours, Nullable<System.DateTime> eTA, Nullable<System.DateTime> storageLFD, Nullable<System.DateTime> perDiemLFD, Nullable<System.DateTime> cutoff, Nullable<System.DateTime> outgateReceipt, Nullable<System.DateTime> ingateReceipt, Nullable<System.DateTime> readyNotification, string notesPrivate, string notesInvoice, Nullable<int> duration, string commodity, Nullable<int> workOrderNo, string pro, string status, string apptNumber, Nullable<System.DateTime> datePaid, string equipmentReturn)
        {
            var invoicedDateParameter = invoicedDate.HasValue ?
                new ObjectParameter("InvoicedDate", invoicedDate) :
                new ObjectParameter("InvoicedDate", typeof(int));
    
            var billToParameter = billTo != null ?
                new ObjectParameter("BillTo", billTo) :
                new ObjectParameter("BillTo", typeof(string));
    
            var brokerParameter = broker != null ?
                new ObjectParameter("Broker", broker) :
                new ObjectParameter("Broker", typeof(string));
    
            var referenceParameter = reference != null ?
                new ObjectParameter("Reference", reference) :
                new ObjectParameter("Reference", typeof(string));
    
            var pOParameter = pO != null ?
                new ObjectParameter("PO", pO) :
                new ObjectParameter("PO", typeof(string));
    
            var apptTimeParameter = apptTime.HasValue ?
                new ObjectParameter("ApptTime", apptTime) :
                new ObjectParameter("ApptTime", typeof(System.DateTime));
    
            var chassisProviderParameter = chassisProvider != null ?
                new ObjectParameter("ChassisProvider", chassisProvider) :
                new ObjectParameter("ChassisProvider", typeof(string));
    
            var container1Parameter = container1 != null ?
                new ObjectParameter("Container1", container1) :
                new ObjectParameter("Container1", typeof(string));
    
            var chassisParameter = chassis != null ?
                new ObjectParameter("Chassis", chassis) :
                new ObjectParameter("Chassis", typeof(string));
    
            var streetTurnParameter = streetTurn.HasValue ?
                new ObjectParameter("StreetTurn", streetTurn) :
                new ObjectParameter("StreetTurn", typeof(bool));
    
            var linkedProNumParameter = linkedProNum != null ?
                new ObjectParameter("LinkedProNum", linkedProNum) :
                new ObjectParameter("LinkedProNum", typeof(string));
    
            var container2Parameter = container2 != null ?
                new ObjectParameter("Container2", container2) :
                new ObjectParameter("Container2", typeof(string));
    
            var originParameter = origin != null ?
                new ObjectParameter("Origin", origin) :
                new ObjectParameter("Origin", typeof(string));
    
            var typeOfMoveParameter = typeOfMove != null ?
                new ObjectParameter("TypeOfMove", typeOfMove) :
                new ObjectParameter("TypeOfMove", typeof(string));
    
            var equipmentProviderParameter = equipmentProvider != null ?
                new ObjectParameter("EquipmentProvider", equipmentProvider) :
                new ObjectParameter("EquipmentProvider", typeof(string));
    
            var equipmentSizeParameter = equipmentSize != null ?
                new ObjectParameter("EquipmentSize", equipmentSize) :
                new ObjectParameter("EquipmentSize", typeof(string));
    
            var equipmentPickupParameter = equipmentPickup != null ?
                new ObjectParameter("EquipmentPickup", equipmentPickup) :
                new ObjectParameter("EquipmentPickup", typeof(string));
    
            var releaseParameter = release != null ?
                new ObjectParameter("Release", release) :
                new ObjectParameter("Release", typeof(string));
    
            var bookingParameter = booking != null ?
                new ObjectParameter("Booking", booking) :
                new ObjectParameter("Booking", typeof(string));
    
            var bOLParameter = bOL.HasValue ?
                new ObjectParameter("BOL", bOL) :
                new ObjectParameter("BOL", typeof(bool));
    
            var sealParameter = seal != null ?
                new ObjectParameter("Seal", seal) :
                new ObjectParameter("Seal", typeof(string));
    
            var weightParameter = weight != null ?
                new ObjectParameter("Weight", weight) :
                new ObjectParameter("Weight", typeof(string));
    
            var pieceCountParameter = pieceCount != null ?
                new ObjectParameter("PieceCount", pieceCount) :
                new ObjectParameter("PieceCount", typeof(string));
    
            var destinationParameter = destination != null ?
                new ObjectParameter("Destination", destination) :
                new ObjectParameter("Destination", typeof(string));
    
            var locationHoursParameter = locationHours != null ?
                new ObjectParameter("LocationHours", locationHours) :
                new ObjectParameter("LocationHours", typeof(string));
    
            var eTAParameter = eTA.HasValue ?
                new ObjectParameter("ETA", eTA) :
                new ObjectParameter("ETA", typeof(System.DateTime));
    
            var storageLFDParameter = storageLFD.HasValue ?
                new ObjectParameter("StorageLFD", storageLFD) :
                new ObjectParameter("StorageLFD", typeof(System.DateTime));
    
            var perDiemLFDParameter = perDiemLFD.HasValue ?
                new ObjectParameter("PerDiemLFD", perDiemLFD) :
                new ObjectParameter("PerDiemLFD", typeof(System.DateTime));
    
            var cutoffParameter = cutoff.HasValue ?
                new ObjectParameter("Cutoff", cutoff) :
                new ObjectParameter("Cutoff", typeof(System.DateTime));
    
            var outgateReceiptParameter = outgateReceipt.HasValue ?
                new ObjectParameter("OutgateReceipt", outgateReceipt) :
                new ObjectParameter("OutgateReceipt", typeof(System.DateTime));
    
            var ingateReceiptParameter = ingateReceipt.HasValue ?
                new ObjectParameter("IngateReceipt", ingateReceipt) :
                new ObjectParameter("IngateReceipt", typeof(System.DateTime));
    
            var readyNotificationParameter = readyNotification.HasValue ?
                new ObjectParameter("ReadyNotification", readyNotification) :
                new ObjectParameter("ReadyNotification", typeof(System.DateTime));
    
            var notesPrivateParameter = notesPrivate != null ?
                new ObjectParameter("NotesPrivate", notesPrivate) :
                new ObjectParameter("NotesPrivate", typeof(string));
    
            var notesInvoiceParameter = notesInvoice != null ?
                new ObjectParameter("NotesInvoice", notesInvoice) :
                new ObjectParameter("NotesInvoice", typeof(string));
    
            var durationParameter = duration.HasValue ?
                new ObjectParameter("Duration", duration) :
                new ObjectParameter("Duration", typeof(int));
    
            var commodityParameter = commodity != null ?
                new ObjectParameter("Commodity", commodity) :
                new ObjectParameter("Commodity", typeof(string));
    
            var workOrderNoParameter = workOrderNo.HasValue ?
                new ObjectParameter("WorkOrderNo", workOrderNo) :
                new ObjectParameter("WorkOrderNo", typeof(int));
    
            var proParameter = pro != null ?
                new ObjectParameter("Pro", pro) :
                new ObjectParameter("Pro", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var apptNumberParameter = apptNumber != null ?
                new ObjectParameter("ApptNumber", apptNumber) :
                new ObjectParameter("ApptNumber", typeof(string));
    
            var datePaidParameter = datePaid.HasValue ?
                new ObjectParameter("DatePaid", datePaid) :
                new ObjectParameter("DatePaid", typeof(System.DateTime));
    
            var equipmentReturnParameter = equipmentReturn != null ?
                new ObjectParameter("EquipmentReturn", equipmentReturn) :
                new ObjectParameter("EquipmentReturn", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateWorkOrdersSP", invoicedDateParameter, billToParameter, brokerParameter, referenceParameter, pOParameter, apptTimeParameter, chassisProviderParameter, container1Parameter, chassisParameter, streetTurnParameter, linkedProNumParameter, container2Parameter, originParameter, typeOfMoveParameter, equipmentProviderParameter, equipmentSizeParameter, equipmentPickupParameter, releaseParameter, bookingParameter, bOLParameter, sealParameter, weightParameter, pieceCountParameter, destinationParameter, locationHoursParameter, eTAParameter, storageLFDParameter, perDiemLFDParameter, cutoffParameter, outgateReceiptParameter, ingateReceiptParameter, readyNotificationParameter, notesPrivateParameter, notesInvoiceParameter, durationParameter, commodityParameter, workOrderNoParameter, proParameter, statusParameter, apptNumberParameter, datePaidParameter, equipmentReturnParameter);
        }
    }
}
