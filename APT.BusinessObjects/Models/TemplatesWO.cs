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
    
    public partial class TemplatesWO
    {
        public int ID { get; set; }
        public string TemplateName { get; set; }
        public string BillTo { get; set; }
        public string Broker { get; set; }
        public string TypeOfMove { get; set; }
        public string EquipmentProvider { get; set; }
        public string EquipmentSize { get; set; }
        public string ChassisProvider { get; set; }
        public string EquipmentPickup { get; set; }
        public string EquipmentReturn { get; set; }
        public string LocationHours { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}