using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllPointsTransport.Models;
using APT.BusinessObjects.Models;
using System.Net;
using AllPointsTransport.Common;

namespace AllPointsTransport.Controllers
{
    public class WorkOrdersController : BaseController
    {
        APT.BusinessObjects.Models.AllPointsTransportEntities db = new APT.BusinessObjects.Models.AllPointsTransportEntities();
        
        // GET: WorkOrder
        
        
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost, ValidateInput(true)]
        public ActionResult SaveAsTemplate(WorkOrder item)
        {
            TemplatesWO item1 = new TemplatesWO();
            //  item1.WorkOrderID = item.WorkOrderID;
            // item1.WorkOrderNo = item.WorkOrderNo;
            // item1.AcceptedByDispatch = item.AcceptedByDispatch;
            // item1.ApptNumber = item.ApptNumber;
            //item1.ApptTime = item.ApptTime;
            //item1.BilledAmount = item.BilledAmount;
            item1.TemplateName = "A" + item.WorkOrderNo.ToString();
            item1.BillTo = item.BillTo;
            //item1.BOL = item.BOL;
           // item1.Booking = item.Booking;
           // item1.Broker = item.Broker;
            //item1.Chassis = item.Chassis;
            item1.ChassisProvider = item.ChassisProvider;
            //item1.Commodity = item.Commodity;
            //item1.Completed = item.Completed;
            //item1.Container1 = item.Container1;
            //item1.Container2 = item.Container2;
            item1.CreatedBy = item.CreatedBy;
            //item1.Cutoff = item.Cutoff;
         //   item1.DateCreated = DateTime.Now;
           // item1.DatePaid = item.DatePaid;
           // item1.DateUpdated =DateTime.Now;
            item1.Destination = item.Destination;
           // item1.Duration = item.Duration;
            item1.EquipmentPickup = item.EquipmentPickup;
            item1.EquipmentProvider = item.EquipmentProvider;
            item1.EquipmentReturn = item.EquipmentReturn;
            item1.EquipmentSize = item.EquipmentSize;
            //item1.ETA = item.ETA;
            //item1.InfoSymbol = item.InfoSymbol;
            //item1.IngateReceipt = item.IngateReceipt;
            //item1.InvoicedDate = item.InvoicedDate;
            //item1.LinkedProNum = item.LinkedProNum;

            item1.LocationHours = item.LocationHours;

            //item1.MasterBOL = item.MasterBOL;
            //item1.NotesInvoice = item.NotesInvoice;
            //item1.NotesPrivate = item.NotesPrivate;
            item1.Origin = item.Origin;
            //item1.OutgateReceipt = item.OutgateReceipt;
            //item1.PerDiemLFD = item.PerDiemLFD;
            //item1.PieceCount = item.PieceCount;
            //item1.PO = item.PO;
            //item1.POD1 = item.POD1;
            //item1.POD2 = item.POD2;
            //item1.Pro = item.Pro;
            //item1.RejectedByDispatch = item.RejectedByDispatch;
            //item1.Reference = item.Reference;
            //item1.ReadyNotification = item.ReadyNotification;
            //item1.Release = item.Release;
            //item1.Seal = item.Seal;
            //item1.Status = item.Status;
            //item1.StorageLFD = item.StorageLFD;
            //item1.StreetTurn = item.StreetTurn;
            item1.TypeOfMove = item.TypeOfMove;
            item1.UpdatedBy = item.UpdatedBy;
            //item1.Uploaded = item.Uploaded;
            //item1.Weight = item.Weight;
            


            var model = db.TemplatesWOes;


            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item1);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return View("Index","Templates");
            //return RedirectToAction ("WorkOrderExternalEditForm", item.WorkOrderID);

           
        }
       
        public ActionResult Create()
        {
            
            WorkOrder model = new WorkOrder();
           
            model.WorkOrderID = db.WorkOrders.Max(itm => itm.WorkOrderID);
            model.WorkOrderNo = model.WorkOrderID + 1;
            model.DateUpdated = DateTime.Now;
            model.DateCreated = DateTime.Now;


            var result1 = WebApiManager.GetRequest<List<string>>(WebApiRequests.BillTo);
            ViewBag.BillTo = result1;

            var result2 = WebApiManager.GetRequest<List<string>>(WebApiRequests.Origin);
            ViewBag.Origin = result2;

            var result3 = WebApiManager.GetRequest<List<string>>(WebApiRequests.Destination);
            ViewBag.Destination = result3;

            var result4 = WebApiManager.GetRequest<List<string>>(WebApiRequests.TypeOfMove);
            ViewBag.TypeOfMove = result4;

            var result5 = WebApiManager.GetRequest<List<string>>(WebApiRequests.EquipmentPickup);
            ViewBag.EquipmentPickup = result5;

            var result6 = WebApiManager.GetRequest<List<string>>(WebApiRequests.EquipmentProvider);
            ViewBag.EquipmentProvider = result6;

            var result7 = WebApiManager.GetRequest<List<string>>(WebApiRequests.EquipmentReturn);
            ViewBag.EquipmentReturn = result7;

            var result8 = WebApiManager.GetRequest<List<string>>(WebApiRequests.EquipmentSize);
            ViewBag.EquipmentSize = result8;

            var result9 = WebApiManager.GetRequest<List<string>>(WebApiRequests.ChassisProvider);
            ViewBag.ChassisProvider = result9;

            var result10 = WebApiManager.GetRequest<List<string>>(WebApiRequests.Broker);
            ViewBag.Broker = result10;

            return View(model);
        }
        [HttpPost, ValidateInput(true)]
        public ActionResult Create([ModelBinder(typeof(DevExpress.Web.Mvc.DevExpressEditorsBinder))]  WorkOrder item)
        {

             
            //item.StreetTurn = true;
            //item.BOL = true;
            var model = db.WorkOrders;

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
            return Redirect("Index");

        }

        [ValidateInput(false)]
        public ActionResult WorkOrderViewPartial()
        {            
            var lst = WebApiManager.GetRequest<IEnumerable<WorkOrder>>(WebApiRequests.GetWorkOrders);
            return PartialView("_WorkOrderViewPartial", lst);
        }

        //[HttpPost, ValidateInput(false)]
        //public ActionResult WorkOrderViewPartialAddNew(AllPointsTransport.Models.WorkOrder item)
        //{
        //    var model = db.WorkOrders;
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            model.Add(item);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_WorkOrderViewPartial", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult WorkOrderViewPartialUpdate(AllPointsTransport.Models.WorkOrder item)
        //{
        //    var model = db.WorkOrders;
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var modelItem = model.FirstOrDefault(it => it.WorkOrderID == item.WorkOrderID);
        //            if (modelItem != null)
        //            {
        //                this.UpdateModel(modelItem);
        //                db.SaveChanges();
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_WorkOrderViewPartial", model.ToList());
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult WorkOrderViewPartialDelete(System.Int32 ID)
        //{
        //    var model = db.WorkOrders;
        //    if (ID >= 0)
        //    {
        //        try
        //        {
        //            var item = model.FirstOrDefault(it => it.WorkOrderID == ID);
        //            if (item != null)
        //                model.Remove(item);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    return PartialView("_WorkOrderViewPartial", model.ToList());
        //}

        public ActionResult WorkOrderExternalEditForm(System.Int32 ID)
        {
            var result1 = WebApiManager.GetRequest<List<string>>(WebApiRequests.BillTo);
            ViewBag.BillTo = result1;

            var result2 = WebApiManager.GetRequest<List<string>>(WebApiRequests.Origin);
            ViewBag.Origin = result2;

            var result3 = WebApiManager.GetRequest<List<string>>(WebApiRequests.Destination);
            ViewBag.Destination = result3;

            var result4 = WebApiManager.GetRequest<List<string>>(WebApiRequests.TypeOfMove);
            ViewBag.TypeOfMove = result4;

            var result5 = WebApiManager.GetRequest<List<string>>(WebApiRequests.EquipmentPickup);
            ViewBag.EquipmentPickup = result5;

            var result6 = WebApiManager.GetRequest<List<string>>(WebApiRequests.EquipmentProvider);
            ViewBag.EquipmentProvider = result6;

            var result7 = WebApiManager.GetRequest<List<string>>(WebApiRequests.EquipmentReturn);
            ViewBag.EquipmentReturn = result7;

            var result8 = WebApiManager.GetRequest<List<string>>(WebApiRequests.EquipmentSize);
            ViewBag.EquipmentSize = result8;

            var result9 = WebApiManager.GetRequest<List<string>>(WebApiRequests.ChassisProvider);
            ViewBag.ChassisProvider = result9;

            var result10 = WebApiManager.GetRequest<List<string>>(WebApiRequests.Broker);
            ViewBag.Broker = result10;


            var model = db.WorkOrders;
            var item = model.FirstOrDefault(it => it.WorkOrderID == ID);

            return View("WorkOrderExternalEditFormView", item);      
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WorkOrderExternalEditForm(WorkOrder item)
        {
            var model = db.WorkOrders;
           // var selectedBillTo = item.BillTo.Split(',');
           // var bills = db.Contacts.Where(it => selectedBillTo.Contains(it.ContactID.ToString())).Select(it => it.Company).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    //foreach (var billTo in bills)
                    //{
                    //    item.BillTo = billTo;
                        var modelItem = model.FirstOrDefault(it => it.WorkOrderID == item.WorkOrderID);

                        if (modelItem != null)
                        {
                            this.UpdateModel(modelItem);
                        }
                   // }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return RedirectToAction("Index");
        }



        [ValidateInput(false)]
        public ActionResult WOLineItemsPartial(int WorkOrderNo=0)
        {
            //var model = db.WOLineItems;
            // WorkOrderNo = 3;
            var result1 = WebApiManager.GetRequest<List<string>>(WebApiRequests.BillingItems);
            ViewBag.BillingItem = result1;
            ViewBag.WorkOrder = WorkOrderNo;

            var model = from w in db.WOLineItems
                        where w.WorkOrder== WorkOrderNo orderby w.RowOrder
                        select w ;

            return PartialView("_WOLineItemsPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WOLineItemsPartialAddNew(WOLineItem item)
        {
            item.DateCreated = DateTime.Now;
            item.DateUpdated = DateTime.Now;
            var model = db.WOLineItems;


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

            var model1 = from w in db.WOLineItems
                        where w.WorkOrder == item.WorkOrder
                        orderby w.RowOrder
                        select w;
            return PartialView("_WOLineItemsPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WOLineItemsPartialUpdate(WOLineItem item)
        {
            // var model = db.WOLineItems;
           // item.DateUpdated = DateTime.Now;
            var model = from w in db.WOLineItems
                        where w.WorkOrder == item.WorkOrder
                        orderby w.RowOrder
                        select w;
            // int? n;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    modelItem.DateUpdated = DateTime.Now;
                    //n = Convert.ToInt32(modelItem.WorkOrder);
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

            //var model1 = from w in db.WOLineItems
            //             where w.WorkOrder == n
            //             orderby w.RowOrder
            //             select w;
            return PartialView("_WOLineItemsPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WOLineItemsPartialDelete(System.Int32 ID)
        {
            var model = db.WOLineItems;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_WOLineItemsPartial", model.ToList());
        }

      


        [ValidateInput(false)]
        public ActionResult DriverPayGridViewPartial(int WorkOrderNo=0)
        {
            ViewBag.WorkOrder = WorkOrderNo;
            var result1 = WebApiManager.GetRequest<List<string>>(WebApiRequests.TypeOfLoad);
            ViewBag.TypeOfLoad = result1;
            
            var result4 = WebApiManager.GetRequest<List<string>>(WebApiRequests.PayType);
            ViewBag.PayType = result4;

            var result2 = WebApiManager.GetRequest<List<string>>(WebApiRequests.Origin);
            ViewBag.Origin = result2;

            var result3 = WebApiManager.GetRequest<List<string>>(WebApiRequests.Destination);
            ViewBag.Destination = result3;

            var model = from w in db.DriverPays
                        where w.WorkOrder == WorkOrderNo
                        orderby w.RowOrder
                        select w;
            return PartialView("_DriverPayGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DriverPayGridViewPartialAddNew(DriverPay item)
        {

            var model = db.DriverPays;
            item.DateUpdated = DateTime.Now;
            item.DateUpdated = DateTime.Now;
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
            var model1 = from w in db.DriverPays
                         where w.WorkOrder == item.WorkOrder
                         orderby w.RowOrder
                         select w;
            return PartialView("_DriverPayGridViewPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DriverPayGridViewPartialUpdate(DriverPay item)
        {
          //  var model = db.DriverPays;
            var model = from w in db.DriverPays
                        where w.WorkOrder == item.WorkOrder
                        orderby w.RowOrder
                        select w;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    modelItem.DateUpdated = DateTime.Now;

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
            return PartialView("_DriverPayGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DriverPayGridViewPartialDelete(System.Int32 ID)
        {
            var model = db.DriverPays;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_DriverPayGridViewPartial", model.ToList());
        }
        public IQueryable<string> BillTo()
        {
            var bill = from list in db.Contacts
                       where list.BillTo == true
                       select list.Contact1;
            return bill;

        }

        public IQueryable<string> Broker()
        {
            var broker = from list in db.Contacts
                         where list.Broker == true
                         select list.Contact1;
            return broker;

        }
        public string[] TypeOfMove()
        {
            return new string[4] { "Import", "Export", "Crosstown", "Non - Freight" };

        }
        public IQueryable<string> EquipProvider()
        {

            var Ep = from list in db.Contacts
                     where list.EquipmentProvider == true
                     select list.Contact1;
            return Ep;
        }
        public string[] EquipSize()
        {
            return new string[8] { "20 STD", " 20 REFR", "40 STD", "40 HC", "40 FLEX", "45 HC", "53 STD", "53 VAN" };

        }
        public IQueryable<string> ChassisProvider()
        {

            var Cp = from list in db.Contacts
                     where list.ChassisProvider == true
                     select list.Contact1;
            return Cp;
        }
        public IQueryable<string> EuipPickupReturn()
        {

            var EPR = from list in db.Contacts
                      where list.RailPort == true || list.CYDepot == true
                      select list.Contact1;
            return EPR;
        }
        public IQueryable<string> Origin()
        {

            var OD = from list in db.Contacts
                     where list.RailPort == true || list.CYDepot == true || list.Location == true || list.DallasDY == true || list.FtWorthDY == true
                     select list.City;
            return OD;
        }
        public IQueryable<string> Destination()
        {

            var OD = from list in db.Contacts
                     where list.RailPort == true || list.CYDepot == true || list.Location == true || list.DallasDY == true || list.FtWorthDY == true
                     select list.City;
            return OD;
        }
        public string[] BillingItems()
        {
            return new string[24] { "Chassis Rental (DCC)","Chassis Reposition (CC)","Credit","Damage","Detention (OT)","Drop Fee (BOB)"
                ,"Dry Run (BOB)","Fuel Surcharge (FSC)","Hazmat (HAZ)","Line Haul (FRT)","Lumper (STGE)","Out of Route Miles","Other",
                "Overweight (OVWT)","Per Diem","Rail Flip","Rail Storage (STGE)","Refund","Scale Ticket (STGE)","Stops","Tri-axle Chassis Rental (STGE)",
                "Yard Storage-Dallas (STGE)","Yard Storage-FtWorth (STGE)","Yard Pull (YARD)"};


        }
        public string[] TypeOfLoad()
        {
            return new string[6] { "LV L", "LV UN", "PU L", "PU E", "DR L", "DR E" };

        }

        public IQueryable<string> PayType()
        {

            var PT = from list in db.WOLineItems

                     select list.BillingItem;
            return PT;
        }





      //  APT.BusinessObjects.Models.AllPointsTransportEntities db1 = new APT.BusinessObjects.Models.AllPointsTransportEntities();

        [ValidateInput(false)]
        public ActionResult GridLookupPartial()
        {
            var model = db.Contacts;
            return PartialView("_GridLookupPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridLookupPartialAddNew(APT.BusinessObjects.Models.Contact item)
        {
            var model = db.Contacts;
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
            return PartialView("_GridLookupPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridLookupPartialUpdate(APT.BusinessObjects.Models.Contact item)
        {
            var model = db.Contacts;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ContactID == item.ContactID);
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
            return PartialView("_GridLookupPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridLookupPartialDelete(System.Int32 ContactID)
        {
            var model = db.Contacts;
            if (ContactID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ContactID == ContactID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridLookupPartial", model.ToList());
        }



        public ActionResult BillToComboBoxPartial()
        {
            var model = db.Contacts;
            return PartialView("_BillToComboBoxPartial", model);
        }
    }



}