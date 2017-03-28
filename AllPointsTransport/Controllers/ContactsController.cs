using APT.BusinessObjects.Models;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPointsTransport.Controllers
{
    public class ContactsController : BaseController
    {
        // GET: Contacts
        public ActionResult Index()
        {
            return View();
        }

        AllPointsTransportEntities db = new AllPointsTransportEntities();

        [ValidateInput(false)]
        public ActionResult ContactsGridViewPartial()
        {
            var model = db.Contacts;
            return PartialView("_ContactsGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ContactsGridViewPartialAddNew(Contact item)
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
            return PartialView("_ContactsGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ContactsGridViewPartialUpdate(Contact item)
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
            return PartialView("_ContactsGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ContactsGridViewPartialDelete(System.Int32 ContactID)
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
            return PartialView("_ContactsGridViewPartial", model.ToList());
        }
    }
}