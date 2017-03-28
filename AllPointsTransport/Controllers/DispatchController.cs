using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPointsTransport.Controllers
{
    public class DispatchController : BaseController
    {
        // GET: Dispatch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult DriverPayGridViewPartial()
        {
            var model = new object[0];
            return PartialView("_DriverPayGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DriverPayGridViewPartialAddNew(APT.BusinessObjects.Models.DriverPay item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_DriverPayGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DriverPayGridViewPartialUpdate(APT.BusinessObjects.Models.DriverPay item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_DriverPayGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DriverPayGridViewPartialDelete(System.Int32 ID)
        {
            var model = new object[0];
            if (ID >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_DriverPayGridViewPartial", model);
        }

        APT.BusinessObjects.Models.AllPointsTransportEntities db = new APT.BusinessObjects.Models.AllPointsTransportEntities();

        [ValidateInput(false)]
        public ActionResult ScheduleGridViewPartial()
        {
            var model = db.Schedules;
            return PartialView("_ScheduleGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ScheduleGridViewPartialAddNew(APT.BusinessObjects.Models.Schedule item)
        {
            var model = db.Schedules;
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
            return PartialView("_ScheduleGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ScheduleGridViewPartialUpdate(APT.BusinessObjects.Models.Schedule item)
        {
            var model = db.Schedules;
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
            return PartialView("_ScheduleGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ScheduleGridViewPartialDelete(System.Int32 ID)
        {
            var model = db.Schedules;
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
            return PartialView("_ScheduleGridViewPartial", model.ToList());
        }
    }
}