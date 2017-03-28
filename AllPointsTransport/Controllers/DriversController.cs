using APT.BusinessObjects.Models;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPointsTransport.Controllers
{
    public class DriversController : BaseController
    {
        // GET: Drivers
        public ActionResult Index()
        {
            return View();
        }

        AllPointsTransportEntities db = new AllPointsTransportEntities();

        [ValidateInput(false)]
        public ActionResult DriversGridViewPartial()
        {
            var model = db.Drivers;
            return PartialView("_DriversGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DriversGridViewPartialAddNew(Driver item)
        {
            var model = db.Drivers;
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
            return PartialView("_DriversGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DriversGridViewPartialUpdate(Driver item)
        {
            var model = db.Drivers;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.DriverID == item.DriverID);
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
            return PartialView("_DriversGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DriversGridViewPartialDelete(System.Int32 DriverID)
        {
            var model = db.Drivers;
            if (DriverID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.DriverID == DriverID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_DriversGridViewPartial", model.ToList());
        }
    }
}