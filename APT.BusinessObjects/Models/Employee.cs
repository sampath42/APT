//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeNo { get; set; }
        public Nullable<bool> Disabled { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string SSNum { get; set; }
        public string Salary { get; set; }
        public string Hourly { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> Supervisor { get; set; }
        public Nullable<bool> scrContacts { get; set; }
        public Nullable<bool> scrDrivers { get; set; }
        public Nullable<bool> scrEmployees { get; set; }
        public Nullable<bool> scrTrucks { get; set; }
        public Nullable<bool> scrPayroll { get; set; }
        public Nullable<bool> scrWorkOrders { get; set; }
        public Nullable<bool> scrTakePayments { get; set; }
        public Nullable<bool> scrPaymentTypeReport { get; set; }
        public Nullable<bool> scrMaintenance { get; set; }
        public Nullable<bool> scrReminders { get; set; }
        public Nullable<bool> scrInvoiceReport { get; set; }
        public Nullable<bool> scrFuelReport { get; set; }
        public Nullable<bool> scrProfitLossReport { get; set; }
        public Nullable<bool> scrMonthlyProfitLossReport { get; set; }
        public Nullable<bool> scrProfitLossReportTruck { get; set; }
        public Nullable<bool> scrTrailers { get; set; }
        public Nullable<bool> scrTripLog { get; set; }
        public Nullable<bool> scrFuelExpenseLog { get; set; }
        public Nullable<bool> scrTripReport { get; set; }
        public Nullable<bool> scrPrePayrollReport { get; set; }
        public Nullable<bool> scrPayrollReport { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
