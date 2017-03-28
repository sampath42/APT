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
    public class TemplatesController : BaseController
    {
        // GET: Templates
        public ActionResult Index()
        {
            return View();
        }

        APT.BusinessObjects.Models.AllPointsTransportEntities db = new APT.BusinessObjects.Models.AllPointsTransportEntities();

        [ValidateInput(false)]
        public ActionResult TemplateGridViewPartial()
        {
            var model = db.TemplatesWOes;
            return PartialView("_TemplateGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TemplateGridViewPartialAddNew(APT.BusinessObjects.Models.TemplatesWO item)
        {
            var model = db.TemplatesWOes;
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
            return PartialView("_TemplateGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TemplateGridViewPartialUpdate(APT.BusinessObjects.Models.TemplatesWO item)
        {
            var model = db.TemplatesWOes;
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
            return PartialView("_TemplateGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TemplateGridViewPartialDelete(System.Int32 ID)
        {
            var model = db.TemplatesWOes;
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
            return PartialView("_TemplateGridViewPartial", model.ToList());
        }

        APT.BusinessObjects.Models.AllPointsTransportEntities db1 = new APT.BusinessObjects.Models.AllPointsTransportEntities();

        [ValidateInput(false)]
        public ActionResult TemplateDriverPayGridViewPartial()
        {
            var model = db1.TemplatesDriverPays;
            return PartialView("_TemplateDriverPayGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TemplateDriverPayGridViewPartialAddNew(APT.BusinessObjects.Models.TemplatesDriverPay item)
        {
            var model = db1.TemplatesDriverPays;
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
            return PartialView("_TemplateDriverPayGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TemplateDriverPayGridViewPartialUpdate(APT.BusinessObjects.Models.TemplatesDriverPay item)
        {
            var model = db1.TemplatesDriverPays;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
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
            return PartialView("_TemplateDriverPayGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TemplateDriverPayGridViewPartialDelete(System.Int32 ID)
        {
            var model = db1.TemplatesDriverPays;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_TemplateDriverPayGridViewPartial", model.ToList());
        }

        public ActionResult Create()
        {

            TemplatesWO model = new TemplatesWO();

            model.ID = db.TemplatesWOes.Max(itm => itm.ID);
            model.ID = model.ID + 1;
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
        public ActionResult Create([ModelBinder(typeof(DevExpress.Web.Mvc.DevExpressEditorsBinder))]  TemplatesWO item)
        {


            //item.StreetTurn = true;
            //item.BOL = true;
            var model = db.TemplatesWOes;

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


        public ActionResult TemplateExternalEditForm(System.Int32 ID)
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


            var model = db.TemplatesWOes;
            var item = model.FirstOrDefault(it => it.ID == ID);

            return View("TemplateExternalEditFormView", item);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TemplateExternalEditForm(TemplatesWO item)
        {
            var model = db.TemplatesWOes;
            // var selectedBillTo = item.BillTo.Split(',');
            // var bills = db.Contacts.Where(it => selectedBillTo.Contains(it.ContactID.ToString())).Select(it => it.Company).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    //foreach (var billTo in bills)
                    //{
                    //    item.BillTo = billTo;
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);

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


        APT.BusinessObjects.Models.AllPointsTransportEntities db2 = new APT.BusinessObjects.Models.AllPointsTransportEntities();

        [ValidateInput(false)]
        public ActionResult TemplateWOLineItemsGridViewPartial()
        {
            var model = db2.TemplatesWOLineItems;
            return PartialView("_TemplateWOLineItemsGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TemplateWOLineItemsGridViewPartialAddNew(APT.BusinessObjects.Models.TemplatesWOLineItem item)
        {
            var model = db2.TemplatesWOLineItems;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db2.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TemplateWOLineItemsGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TemplateWOLineItemsGridViewPartialUpdate(APT.BusinessObjects.Models.TemplatesWOLineItem item)
        {
            var model = db2.TemplatesWOLineItems;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db2.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TemplateWOLineItemsGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TemplateWOLineItemsGridViewPartialDelete(System.Int32 ID)
        {
            var model = db2.TemplatesWOLineItems;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db2.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_TemplateWOLineItemsGridViewPartial", model.ToList());
        }
    }
}