using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APT.BusinessObjects.Models;

namespace AllPointsTransport.Controllers
{
    public class SettingsController : Controller
    {
        private AllPointsTransportEntities db = new AllPointsTransportEntities();

        // GET: Settings
        public ActionResult Index()
        {
            return View(db.Settings.ToList());
        }

        [ValidateInput(false)]
        public ActionResult AdditionalItemsGridViewPartial()
        {
            var model = db.APTAdditionalItems_Master;
            return PartialView("_AdditionalItemsGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AdditionalItemsGridViewPartialUpdate(APT.BusinessObjects.Models.APTAdditionalItems_Master catergoryItem)
        {
            var model = db.APTAdditionalItems_Master;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Item == catergoryItem.Item);
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
            return PartialView("_AdditionalItemsGridViewPartial", model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult FuelSettingsGridViewPartial()
        {
            var model = db.Settings;
            return PartialView("_FuelSettingsGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult FuelSettingsGridViewPartialUpdate(APT.BusinessObjects.Models.Setting fuelSurchargeItem)
        {
            var model = db.Settings;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Item == fuelSurchargeItem.Item);
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
            return PartialView("_FuelSettingsGridViewPartial", model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult RateSettingsGridViewPartial()
        {
            var model = db.RateTables;
            return PartialView("_RateSettingsGridViewPartial", model.ToList());
        }
        
        [HttpPost, ValidateInput(false)]
        public ActionResult RateSettingsGridViewPartialUpdate(APT.BusinessObjects.Models.RateTable rateObj)
        {
            var model = db.RateTables;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == rateObj.ID);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
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
            return PartialView("_RateSettingsGridViewPartial", model.ToList());
        }
    }
}
