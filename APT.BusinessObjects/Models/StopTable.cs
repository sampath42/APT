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
    
    public partial class StopTable
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> RowOrder { get; set; }
        public string Location { get; set; }
        public string FullLocation { get; set; }
        public Nullable<int> OneWayDistance { get; set; }
        public Nullable<int> RoundTripDistance { get; set; }
        public Nullable<int> BaseRate { get; set; }
        public Nullable<int> FuelSurcharge { get; set; }
        public Nullable<int> Total { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Nullable<int> RateQuoteId { get; set; }
    }
}
