using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AllPointsTransport.Models
{
    [Table("RateTable")]
    public class RateQuote
    {
        public string BillTo { get; set; }
    }
}