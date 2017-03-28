using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AllPointsTransport.Models
{
    [Table("Legs_RateQuote")]
    public class Legs_RateQuote
    {
        public string From { get; set; }
        public string To { get; set; }
    }
}