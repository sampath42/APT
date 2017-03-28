using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using AllPointsTransport.Common;
using APT.BusinessObjects.Models;
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Xml;
using AllPointsTransport.Models;

namespace AllPointsTransport.Controllers
{
    public class RateQuotesController : BaseController
    {
        APT.BusinessObjects.Models.AllPointsTransportEntities db = new APT.BusinessObjects.Models.AllPointsTransportEntities();

        // GET: RateQuotes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {

            var model = new List<LocationPoints>();

            model.Add(new LocationPoints { Cities = "BSNF" });
            model.Add(new LocationPoints { Cities= "UP_DIT" });
            model.Add(new LocationPoints { Cities = "UP_Mesquite" });
            model.Add(new LocationPoints { Cities = "KC" });
            model.Add(new LocationPoints { Cities = "La Porte" });
            model.Add(new LocationPoints { Cities = "Other" });
            return View(model);
        }

        public ActionResult Create(int RateQuoteId = 0)
        {
            RateQuoteViewModel rq = new RateQuoteViewModel();
            rq.RoundTrip = true;
            if (RateQuoteId != 0)
            {
                rq.RateQuote = db.RateQuotes.Where(item => item.RateQuoteId == RateQuoteId).FirstOrDefault();
                var fromItems = rq.RateQuote.From.Split(';').ToList();
                var addItems = db.APTAddress_Master.Where(i => !Equals(i.Accronym.ToLower(), "others")).Select(i => i.Accronym).ToList();
                foreach (var item in fromItems)
                {
                    
                    if (!addItems.Contains(item))
                    {
                        rq.RateQuote.From = rq.RateQuote.From + ";Others";
                        break;
                    }
                }

                if(!addItems.Contains(rq.RateQuote.To))
                {
                    rq.RateQuote.To = "Others;" + rq.RateQuote.To;
                }

                rq.RqAdditionalItems = rq.RateQuote.RQAdditionalItems.ToList();
                rq.RqLegs = rq.RateQuote.RQLegs.ToList();
                rq.RoundTrip = Convert.ToBoolean(rq.RateQuote.RoundTrip);
            }
            return View(rq);
        }

        [HttpPost]                
        public ActionResult Create(RateQuoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fromList = model.RateQuote.From.Split(';');
                    foreach(var ft in fromList)
                    {
                        RQLeg legs = new RQLeg();
                        legs.From = ft;
                        legs.To = model.RateQuote.To;
                        model.RqLegs.Add(legs);
                    }
                    //var res = db.CreateRateQuote(model.BillTo, string.Empty, model.GUID);
                    //db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            //return RedirectToAction("Index");
            return View(model);
        }

        public ActionResult RateQuote(int RateQuoteId = 0)
        {
            var result1 = WebApiManager.GetRequest<List<string>>(WebApiRequests.BillTo);
            ViewBag.BillTo = result1;
            RateQuote ratequote = RateQuoteId == 0 ? new RateQuote() : db.RateQuotes.Where(item => item.RateQuoteId == RateQuoteId).FirstOrDefault();
            ratequote.RateQuoteId = RateQuoteId == 0 ? db.RateQuotes.Max(item => item.RateQuoteId) + 1 : ratequote.RateQuoteId;
            return PartialView("RateQuote", ratequote);
        }

        public ActionResult Legsratequote()
        {
            //var result2 = WebApiManager.GetRequest<List<string>>(WebApiRequests.Destination);
            //ViewBag.Destination = result2;
            //var result3= WebApiManager.GetRequest<List<string>>(WebApiRequests.Origin);
            //ViewBag.Origin = result3;
            List<RQLeg> legratequote = new List<RQLeg>();
            return PartialView("Legsratequote", legratequote);
        }

        [ValidateInput(false)]
        public ActionResult RQLineItemsPartial(int rateQuoteId = 0)
        {
            var billingItems = WebApiManager.GetRequest<List<string>>(WebApiRequests.BillingItems);
            ViewBag.BillingItem = billingItems;
            List<WOLineItems_RateQuote> model = db.WOLineItems_RateQuote.Where(item => item.RateQuoteId == rateQuoteId).ToList();
            return PartialView("_RQLineItemsPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RQLineItemsPartialAddNew(APT.BusinessObjects.Models.WOLineItems_RateQuote item)
        {
            var model = db.WOLineItems_RateQuote;         
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RQLineItemsPartial", model.Where(wolirq => wolirq.GUID == item.GUID).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RQLineItemsPartialUpdate(APT.BusinessObjects.Models.WOLineItems_RateQuote item)
        {
            var model = db.WOLineItems_RateQuote;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RQLineItemsPartial", model.Where(wolirq => wolirq.GUID == item.GUID).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RQLineItemsPartialDelete(System.Int32 ID)
        {
            var model = db.WOLineItems_RateQuote;
            string guid = string.Empty;       
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    guid = item.GUID;
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_RQLineItemsPartial", model.Where(wolirq => wolirq.GUID == guid).ToList());
        }

        private List<RQLeg> AddDefaultAddresses(List<RQLeg> model, string to = "")
        {
            //int i = 0;
            //string[] fromAddresses = { "Union Pacific Dallas Intermodal Terminal, Fulghum Road, Hutchins, TX 75141", "BNSF Railway Company, Intermodal Parkway, Haslet, TX 76052", "Union Pacific, 4425 Forney Rd, Mesquite, TX 75149", "Kansas City Southern Railway, 2800 TX-78, Wylie, TX 75098", "La Porte, TX" };
            //foreach(string from in fromAddresses)
            //{
            //    Legs_RateQuote leg = new Legs_RateQuote();
            //    leg.Id = ++i;
            //    leg.From = from;
            //    leg.To = to;
            //    if (!string.IsNullOrWhiteSpace(to))
            //    {
            //        var distanceAndTime = GetDistance(from, to);
            //        leg.OneWayMiles = distanceAndTime[0];
            //        leg.TravelTime = distanceAndTime[1];

            //        leg = CalculateFares(leg);
            //    }
            //    model.Add(leg);
            //}
           
            //foreach(var leg in model)
            //{
            //    leg.To = to;
            //    if (!string.IsNullOrWhiteSpace(to))
            //    {
            //        var distanceAndTime = GetDistance(leg.From, to);
            //        leg.OneWayMiles = distanceAndTime[0];
            //        leg.TravelTime = distanceAndTime[1];

            //        CalculateFares(leg);
            //    }
            //}

            return model;
        }        

        private dynamic CalculateFares(string oneWay)
        {
            var miles = oneWay.ToLower().Replace("mi", string.Empty).Replace("ft", string.Empty).Replace("km", string.Empty).Trim();
            var milesDecimal = Convert.ToDecimal(miles);
            decimal res = 0;
            if (milesDecimal <= 23)
            {
                res = db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_0_23, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else if (milesDecimal <= 29)
            {
                res =  milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_24_29, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else if (milesDecimal <= 39)
            {
                res = milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_30_39, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else if (milesDecimal <= 47)
            {
                res = milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_40_47, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else if (milesDecimal <= 57)
            {
                res = milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_48_57, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else if (milesDecimal <= 65)
            {
                res = milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_58_65, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else if (milesDecimal <= 75)
            {
                res = milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_66_75, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else if (milesDecimal <= 99)
            {
                res = milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_76_99, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else if (milesDecimal <= 149)
            {
                res = milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_100_149, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else if (milesDecimal <= 199)
            {
                res = milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_150_199, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else if (milesDecimal <= 299)
            {
                res = milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_200_299, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            else 
            {
                res = milesDecimal * db.RateTables.Where(item => item.RATE_TYPE.Equals(Constants.RATE_300_More, StringComparison.OrdinalIgnoreCase)).Select(item => item.RATE_VALUE).FirstOrDefault();
            }
            
            return res;
        }

        private RQLeg CalculateFaresAndFS(RQLeg legs)
        {
            var fs = db.Settings.Where(item => item.Item.Equals("Fuel Surcharge", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Value;

            var from = GetFullAddress(legs.From);
            var to = GetFullAddress(legs.To);
            var distanceAndTime = GetDistance(from, to);
            legs.OneWayMiles = distanceAndTime[0];
            legs.TravelTime = distanceAndTime[1];
            legs.LineHaul = CalculateFares(legs.OneWayMiles);

            legs.FuelSurcharge = (legs.LineHaul * Convert.ToDecimal(fs)) / 100;
            legs.TotalAmount = legs.LineHaul + legs.FuelSurcharge;

            return legs;
        }

        public ActionResult EditRQLegs(int rateQuoteId)
        {
            RateQuoteViewModel model = new RateQuoteViewModel();
            if (rateQuoteId != 0)
            {
                var rqList = db.RateQuotes.Where(item => item.RateQuoteId == rateQuoteId);
                var frmLst = rqList.Select(item => item.From).ToList();
                model.RateQuote = rqList.FirstOrDefault();
                //model.RateQuote.From = string.Join(",", frmLst);
                model.RqAdditionalItems = model.RateQuote.RQAdditionalItems.ToList();
                model.RqLegs = model.RateQuote.RQLegs.ToList();


                //model.RateQuote.RoundTrip = model.RoundTrip;

                //var fromList = model.RateQuote.From.Split(',');

                //foreach (var ft in frmLst)
                //{
                //    RQLeg legs = new RQLeg();
                //    legs.RQFrom = ft;
                //    legs.From = ft;
                //    legs.To = model.RateQuote.To;

                //    legs = CalculateFaresAndFS(legs);

                //    model.RqLegs.Add(legs);

                //    if (model.RateQuote.RoundTrip != null && Convert.ToBoolean(model.RateQuote.RoundTrip))
                //    {
                //        RQLeg rtlegs = new RQLeg();
                //        rtlegs.RQFrom = ft;
                //        rtlegs.From = model.RateQuote.To;
                //        rtlegs.To = ft;

                //        rtlegs = CalculateFaresAndFS(rtlegs);

                //        model.RqLegs.Add(rtlegs);
                //    }
                //}
            }
            return PartialView("RQLegs", model);
        }

        public ActionResult RQLegs(RateQuoteViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    model.RateQuote.RoundTrip = model.RoundTrip;

                    var fromList = model.RateQuote.From.Split(';');
                    
                    foreach (var ft in fromList)
                    {
                        if (!string.IsNullOrWhiteSpace(ft))
                        {
                            RQLeg legs = new RQLeg();
                            legs.RQFrom = ft;
                            legs.From = ft;
                            legs.To = model.RateQuote.To;
                            legs.ToDispatch = true; // Need to test on edit or ratequote
                            legs = CalculateFaresAndFS(legs);

                            model.RqLegs.Add(legs);

                            if (model.RateQuote.RoundTrip != null && Convert.ToBoolean(model.RateQuote.RoundTrip))
                            {
                                RQLeg rtlegs = new RQLeg();
                                rtlegs.RQFrom = ft;
                                rtlegs.From = model.RateQuote.To;
                                rtlegs.To = ft;
                                rtlegs.ToDispatch = true; // Need to test on edit or ratequote
                                rtlegs = CalculateFaresAndFS(rtlegs);

                                model.RqLegs.Add(rtlegs);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("RQLegs",model);
        }

        public ActionResult NewRQLegs(RateQuoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fs = db.Settings.Where(item => item.Item.Equals("Fuel Surcharge", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Value;

                    RQLeg legs = new RQLeg();
                    legs.RQFrom = model.RQTriggerLegFrom;
                    legs.From = model.RQNewFrom;
                    legs.To = model.RQNewTo;

                    legs = CalculateFaresAndFS(legs);

                    legs.ToDispatch = true;

                    model.RqLegs.Add(legs);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("RQLegs", model);
        }

        public ActionResult NewRQAdditionalItems(RateQuoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach(var item in model.RqAdditionalItems)
                    {
                        var billingItem = db.APTAdditionalItems_Master.Where(ai => ai.Id == item.Id).FirstOrDefault();
                        item.BillingItem = billingItem.Item;
                        item.Total = item.Quantity * billingItem.Fare;
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("RQLegs", model);
        }

        [HttpPost]
        public ActionResult SaveRateQuote(RateQuoteViewModel model)
        {
            var rateQuoteIds = new List<int>();
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.RateQuote.RateQuoteId > 0)
                    {
                        model.RateQuote.UppdatedDate = DateTime.Now;
                        db.Entry(model.RateQuote).State = System.Data.Entity.EntityState.Modified;                        
                    }
                    else
                    {
                        model.RateQuote.RoundTrip = model.RoundTrip;
                        model.RateQuote.CreatedDate = DateTime.Now;
                        db.RateQuotes.Add(model.RateQuote);
                    }
                    
                    db.SaveChanges();                
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return Json(new { RateQuoteIds = model.RateQuote.RateQuoteId });
        }

        [HttpPost]
        public ActionResult SaveLegsAndAddItem(RateQuoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rqIds = model.RQStatus.Split(',');
                    foreach (var id in rqIds)
                    {
                        var rqid = Convert.ToInt32(id);
                        var rq = db.RateQuotes.Where(item => item.RateQuoteId == rqid).FirstOrDefault();
                        foreach (var item in model.RqLegs)
                        {
                            RQLeg rqLegs = item;
                            rqLegs.RateQuoteId = Convert.ToInt32(id);
                            if (rqLegs.RQLegId > 0)
                            {
                                db.RQLegs.Attach(rqLegs);
                                db.Entry(rqLegs).State = System.Data.Entity.EntityState.Modified;
                                //this.UpdateModel(rqLegs);                                
                            }
                            else
                            {                                
                                db.RQLegs.Add(rqLegs);
                            }
                        }
                        db.SaveChanges();
                    }

                    foreach (var id in rqIds)
                    {
                        foreach (var item in model.RqAdditionalItems)
                        {
                            RQAdditionalItem rqAI = item;
                            rqAI.RateQuoteId = Convert.ToInt32(id);
                            db.RQAdditionalItems.Add(rqAI);
                            //if (rqAI.Id > 0)
                            //{
                            //    db.Entry(rqAI).State = System.Data.Entity.EntityState.Modified;
                            //    //this.UpdateModel(rqAI);
                            //}
                            //else
                            //{
                                db.RQAdditionalItems.Add(rqAI);
                            //}
                        }
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return Json(true);
        }

        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult RQLegs(Tuple<ICollection<RQLeg>, ICollection<RQAdditionalItem>,RateQuote> model)
        //{

        //    //List<RQLeg> legs = model.RQLegs.ToList();
        //    //List<RQAdditionalItem> additionalItems = model.RQAdditionalItems.ToList();
        //    //var tuple = new Tuple<List<RQLeg>, List<RQAdditionalItem>>(legs, additionalItems);
        //    return PartialView("_RQLegs", model);
        //}       

        [HttpPost, ValidateInput(false)]
        public ActionResult RQLegsAddNew(APT.BusinessObjects.Models.RQLeg item)
        {
            var model = db.RQLegs;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RQLegs", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RQLegsUpdate(APT.BusinessObjects.Models.RQLeg item)
        {
            var model = db.RQLegs;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.RQLegId == item.RQLegId);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RQLegs", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RQLegsDelete(System.Int32 Id)
        {
            var model = db.RQLegs;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.RQLegId == Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_RQLegs", model.ToList());
        }

        public string[] GetDistance(string origin, string destination)
        {
            string[] distanceAndTime = new string[2];
            distanceAndTime[0] = "0";
            if (!string.IsNullOrWhiteSpace(destination))
            {
                string url = @"http://maps.googleapis.com/maps/api/distancematrix/xml?units=imperial&origins=" + origin + "&destinations=" + destination + "&sensor=false";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                DataSet ds = new DataSet();
                ds.ReadXml(new XmlTextReader(new StringReader(responsereader)));
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["element"].Rows[0]["status"].ToString() == "OK")
                    {
                        distanceAndTime[0] = ds.Tables["distance"].Rows[0]["text"].ToString();
                        distanceAndTime[1] = ds.Tables["duration"].Rows[0]["text"].ToString();
                    }
                }
            }
            return distanceAndTime;
        }

        [ValidateInput(false)]
        public ActionResult RateQuotesListPartial()
        {
            var model = db.RateQuotes;
            var lst = model.ToList();
            return PartialView("_RateQuotesListPartial", lst);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RateQuotesListPartialAddNew(APT.BusinessObjects.Models.RateQuote item)
        {
            var model = db.RateQuotes;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RateQuotesListPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RateQuotesListPartialUpdate(APT.BusinessObjects.Models.RateQuote item)
        {
            var model = db.RateQuotes;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.RateQuoteId == item.RateQuoteId);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RateQuotesListPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RateQuotesListPartialDelete(System.Int32 RateQuoteId)
        {
            var model = db.RateQuotes;
            if (RateQuoteId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.RateQuoteId == RateQuoteId);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_RateQuotesListPartial", model.ToList());
        }

        public JsonResult ConvertToWO(string rateQuoteId, string selectedFrom)
        {
            var workOrderId = db.ConvertToWO(Convert.ToInt32(rateQuoteId),selectedFrom);
            return Json(new { WorkOrderID = workOrderId }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FromAddrComboBoxPartial()
        {
            return PartialView("_FromAddrComboBoxPartial");
        }
        private string GetFullAddress(string accr)
        {
            var add = db.APTAddress_Master.Where(item => item.Accronym.Equals(accr, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            var res = add != null ? add.FullAddress : accr;
            return res;
        }

        APT.BusinessObjects.Models.AllPointsTransportEntities db1 = new APT.BusinessObjects.Models.AllPointsTransportEntities();

        [ValidateInput(false)]
        public ActionResult GridLookupPartial()
        {
            var model = db1.Contacts;
            return PartialView("_GridLookupPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridLookupPartialAddNew(APT.BusinessObjects.Models.Contact item)
        {
            var model = db1.Contacts;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridLookupPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridLookupPartialUpdate(APT.BusinessObjects.Models.Contact item)
        {
            var model = db1.Contacts;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Company == item.Company);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db1.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridLookupPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridLookupPartialDelete(System.String Company)
        {
            var model = db1.Contacts;
            if (Company != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Company == Company);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridLookupPartial", model.ToList());
        }
    }
}