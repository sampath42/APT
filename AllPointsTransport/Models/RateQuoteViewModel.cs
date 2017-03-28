using APT.BusinessObjects.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AllPointsTransport.Models
{
    public class RateQuoteViewModel
    {
        //private int fsPercentage = 17;
        //public string From { get; set; }
        //public string To { get; set; }
        //public double LineHaul { get; set; }
        //public double FuelSurcharge { get { return (LineHaul * FSPercentage) / 100; } }
        //public string Additional { get; set; }
        //public double AdditionalTotal { get; set; }
        //public double Total { get { return LineHaul + FuelSurcharge; } }

        //public int FSPercentage
        //{
        //    get
        //    {
        //        return fsPercentage;
        //    }

        //    set
        //    {
        //        fsPercentage = value;
        //    }
        //}

        private RateQuote rateQuote = new RateQuote();

        public string RQNewFrom { get; set; }
        public string RQNewTo { get; set; }
        public string RQTriggerLegFrom { get; set; }
        public string RQStatus { get; set; }
        public bool RoundTrip { get; set; }
        public RateQuote RateQuote
        {
            get
            {
                return rateQuote;
            }

            set
            {
                rateQuote = value;
            }
        }

        public List<RQLeg> RqLegs
        {
            get
            {
                return rqLegs;
            }

            set
            {
                rqLegs = value;
            }
        }

        public List<RQAdditionalItem> RqAdditionalItems
        {
            get
            {
                return rqAdditionalItems;
            }

            set
            {
                rqAdditionalItems = value;
            }
        }

        private List<RQLeg> rqLegs = new List<RQLeg>();

        private List<RQAdditionalItem> rqAdditionalItems = new List<RQAdditionalItem>();

        public List<APTAddress_Master> DefaultAddresses
        {
            get
            {
                var db = new APT.BusinessObjects.Models.AllPointsTransportEntities();
                return db.APTAddress_Master.ToList();
            }
        }

        public List<RQAdditionalItem> DefaultAdditionalItems
        {
            get
            {
                var db = new APT.BusinessObjects.Models.AllPointsTransportEntities();
                var source = db.APTAdditionalItems_Master.ToList();
                List<RQAdditionalItem> ret = new List<RQAdditionalItem>();
                foreach(var item in source)
                {
                    ret.Add(new RQAdditionalItem() { Id = item.Id, BillingItem = item.Item });
                }

                return ret;
            }
        }
    }
}