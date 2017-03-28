using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AllPointsTransport.Models;
using APT.BusinessObjects.Models;
using DevExpress.Web.Mvc;
using AllPointsTransport.Common;

namespace AllPointsTransport.Controllers
{
    public class EmployeesController : BaseController
    {
        private AllPointsTransportEntities db = new AllPointsTransportEntities();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        [ValidateInput(false)]
        public ActionResult EmployeesListPartial()
        {
            var model = db.Employees;
            var lst = model.ToList();
            return PartialView("EmployeesListPartial", lst);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();

            return View(employee);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult CreateEdit([Bind(Include = "EmployeeID,EmployeeNo,Disabled,Username,Password,First,Last,Address1,Address2,City,State,Zip,Phone,Fax,Email,SSNum,Salary,Hourly,Notes,Supervisor,scrContacts,scrDrivers,scrEmployees,scrTrucks,scrPayroll,scrWorkOrders,scrTakePayments,scrPaymentTypeReport,scrMaintenance,scrReminders,scrInvoiceReport,scrFuelReport,scrProfitLossReport,scrMonthlyProfitLossReport,scrProfitLossReportTruck,scrTrailers,scrTripLog,scrFuelExpenseLog,scrTripReport,scrPrePayrollReport,scrPayrollReport,DateCreated,CreatedBy,LastUpdated,UpdatedBy")] Employee employee)
        public ActionResult Create([ModelBinder(typeof(DevExpress.Web.Mvc.DevExpressEditorsBinder))]  Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Password = AESEncryption.Encrypt(employee.Password);
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }



        // GET: Employees/Edit/5
        public ActionResult Edit(int? EmployeeID)
        {
            if (EmployeeID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(EmployeeID);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,EmployeeNo,Disabled,Username,Password,First,Last,Address1,Address2,City,State,Zip,Phone,Fax,Email,SSNum,Salary,Hourly,Notes,Supervisor,scrContacts,scrDrivers,scrEmployees,scrTrucks,scrPayroll,scrWorkOrders,scrTakePayments,scrPaymentTypeReport,scrMaintenance,scrReminders,scrInvoiceReport,scrFuelReport,scrProfitLossReport,scrMonthlyProfitLossReport,scrProfitLossReportTruck,scrTrailers,scrTripLog,scrFuelExpenseLog,scrTripReport,scrPrePayrollReport,scrPayrollReport,DateCreated,CreatedBy,LastUpdated,UpdatedBy")] Employee employee)
        {

            if (ModelState.IsValid)
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? EmployeeID)
        {
            if (EmployeeID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(EmployeeID);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int EmployeeID)
        {
            Employee employee = db.Employees.Find(EmployeeID);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
