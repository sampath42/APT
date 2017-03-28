using APT.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AllPointsTransport.Models
{
    public static class DefaultLegs_RateQuote
    {
        public static List<Legs_RateQuote> DefaultAddresses { get; set; }

        static DefaultLegs_RateQuote()
        {
            AddDefaultAddresses();
        }

        public static void AddDefaultAddresses()
        {
            int i = 0;
            string[] fromAddresses = { "Union Pacific Dallas Intermodal Terminal, Fulghum Road, Hutchins, TX 75141", "BNSF Railway Company, Intermodal Parkway, Haslet, TX 76052", "Union Pacific, 4425 Forney Rd, Mesquite, TX 75149", "Kansas City Southern Railway, 2800 TX-78, Wylie, TX 75098", "La Porte, TX" };
            DefaultAddresses = new List<Legs_RateQuote>();
            foreach (string from in fromAddresses)
            {
                Legs_RateQuote leg = new Legs_RateQuote();
                leg.Id = ++i;
                leg.From = from;
                DefaultAddresses.Add(leg);
            }
        }

        public static void ResetDefaultAddresses()
        {
            AddDefaultAddresses();
        }
    }
}