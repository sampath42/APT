using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APT.BusinessObjects.Models;

namespace APT.WebApi.Controllers
{
    public class WorkOrdersController : ApiController
    {
        private AllPointsTransportEntities db = new AllPointsTransportEntities();
        
        [HttpGet]
        [ActionName("BillTo")]
        //GET: Company list for BillTo 
        public List<string> BillTo()
        {
            
            var bill = from list in db.Contacts
                       where list.BillTo == true
                       select list.Company+"   "+list.Phone1+"    " + list.Email1;
            return bill.ToList();
           // return new string[7] { "Sampath", "Sudheer", "Manideep", "Ashlin","Nagarjuna", "Jayshri", "Anusha" }.ToList();

        }

        //GET: Brokers List
        [HttpGet]
        [ActionName("Broker")]
        public List<string> Broker()
        {
            var broker = from list in db.Contacts
                         where list.Broker == true
                         select list.Company;
            return broker.ToList();

        }
        //GET: Types of Move
        [HttpGet]
        [ActionName("TypeOfMove")]
        public List<string> TypeOfMove()
        {
            return new string[4] { "Import", "Export", "Crosstown", "Non - Freight" }.ToList();

        }

        //GET: Equipment Providers List
        [HttpGet]
        [ActionName("EquipmentProvider")]
        public List<string> EquipmentProvider()
        {

            var Ep = from list in db.Contacts
                     where list.EquipmentProvider == true
                     select list.Company;
            return Ep.ToList();

        }

        //GET: Equipments sizes
        [HttpGet]
        [ActionName("EquipmentSize")]
        public List<string> EquipmentSize()
        {
            return new string[8] { "20 STD", " 20 REFR", "40 STD", "40 HC", "40 FLEX", "45 HC", "53 STD", "53 VAN" }.ToList();

        }

        //GET: ChassisProviders list
        [HttpGet]
        [ActionName("ChassisProvider")]
        public List<string> ChassisProvider()
        {

            var Cp = from list in db.Contacts
                     where list.ChassisProvider == true
                     select list.Company;
            return Cp.ToList();
        }

        //GET:Equipment Pickup
        [HttpGet]
        [ActionName("EquipmentPickup")]
        public List<string> EuipmentPickup()
        {

            var EP = from list in db.Contacts
                     where list.RailPort == true || list.CYDepot == true
                     select list.Company;
            return EP.ToList();
        }

        //GET:Equipment Return list
        [HttpGet]
        [ActionName("EquipmentReturn")]
        public List<string> EuipmentReturn()
        {

            var EP = from list in db.Contacts
                     where list.RailPort == true || list.CYDepot == true
                     select list.Company;
            return EP.ToList();
        }

        //GET:Origin Company list
        [HttpGet]
        [ActionName("Origin")]
        public List<string> Origin()
        {
            return new string[6] { "LV L", "LV UN", "PU L", "PU E", "DR L", "DR E" }.ToList();

            //var OD = from list in db.Contacts
            //         where list.RailPort == true || list.CYDepot == true || list.Location == true || list.DallasDY == true || list.FtWorthDY == true
            //         select list.Company;
            //return OD.ToList();
        }

        //GET:Destination Company List
        [HttpGet]
        [ActionName("Destination")]
        public List<string> Destination()
        {

            //var OD = from list in db.Contacts
            //         where list.RailPort == true || list.CYDepot == true || list.Location == true || list.DallasDY == true || list.FtWorthDY == true
            //         select list.Company;
            //return OD.ToList();
            return new string[6] { "LV L", "LV UN", "PU L", "PU E", "DR L", "DR E" }.ToList();
        }

        //GET:BillingItems List
        [HttpGet]

        [ActionName("BillingItems")]
        public List<string> BillingItems()

        {
            return new string[24] { "Chassis Rental (DCC)","Chassis Reposition (CC)","Credit","Damage","Detention (OT)","Drop Fee (BOB)"
                ,"Dry Run (BOB)","Fuel Surcharge (FSC)","Hazmat (HAZ)","Line Haul (FRT)","Lumper (STGE)","Out of Route Miles","Other",
                "Overweight (OVWT)","Per Diem","Rail Flip","Rail Storage (STGE)","Refund","Scale Ticket (STGE)","Stops","Tri-axle Chassis Rental (STGE)",
                "Yard Storage-Dallas (STGE)","Yard Storage-FtWorth (STGE)","Yard Pull (YARD)"}.ToList();

        }

        //GET:Type of Loads List
        [HttpGet]
        [ActionName("TypeOfLoad")]
        public List<string> TypeOfLoad()
        {
            return new string[6] { "LV L", "LV UN", "PU L", "PU E", "DR L", "DR E" }.ToList();

        }

        //GET:Type of Pay
        [HttpGet]
        [ActionName("PayType")]
        public List<string> PayType()
        {
            return new string[6] { "LV L", "LV UN", "PU L", "PU E", "DR L", "DR E" }.ToList();
            //var PT = from list in db.WOLineItems

            //         select list.BillingItem;
            //return PT.ToList();
        }

        // GET: api/WorkOrders
        [HttpGet]
        [ActionName("GetWorkOrders")]
        public IEnumerable<WorkOrder> GetWorkOrders()
        {
            return db.WorkOrders;
        }

        // GET: api/WorkOrders/5
        [ResponseType(typeof(WorkOrder))]
        public IHttpActionResult GetWorkOrder(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return Ok(workOrder);
        }

        // PUT: api/WorkOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkOrder(int id, WorkOrder workOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workOrder.WorkOrderID)
            {
                return BadRequest();
            }

            db.Entry(workOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WorkOrders
        [ResponseType(typeof(WorkOrder))]
        public IHttpActionResult PostWorkOrder(WorkOrder workOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkOrders.Add(workOrder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workOrder.WorkOrderID }, workOrder);
        }

        // DELETE: api/WorkOrders/5
        [ResponseType(typeof(WorkOrder))]
        public IHttpActionResult DeleteWorkOrder(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return NotFound();
            }

            db.WorkOrders.Remove(workOrder);
            db.SaveChanges();

            return Ok(workOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkOrderExists(int id)
        {
            return db.WorkOrders.Count(e => e.WorkOrderID == id) > 0;
        }
    }
}