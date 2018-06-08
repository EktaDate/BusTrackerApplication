using BusTrackerApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusTrackerAplplication
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string id)
        {
            // for edit view
            if (!string.IsNullOrEmpty(id))
            {
                // Set the name of the table
                TableManager TableManagerObj = new TableManager("bus");

                // Retrieve the Bus object where RowKey eq value of id
                List<Bus> BusListObj = TableManagerObj.RetrieveEntity<Bus>("RowKey eq '" + id + "'");

                Bus BusObj = BusListObj.FirstOrDefault();
                return View(BusObj);
            }

            // new entry view
            return View(new Bus());
        }
       
        [HttpPost]
        public ActionResult Index(string id, FormCollection formData)
        {
            Bus BusObj = new Bus();
            BusObj.Name = formData["Name"] == "" ? null : formData["Name"];
            BusObj.Number = formData["Number"] == "" ? null : formData["Number"];
            //BusObj.Email = formData["Email"] == "" ? null : formData["Email"];

            // Insert
            if (string.IsNullOrEmpty(id))
            {
                BusObj.PartitionKey = BusObj.Name;
                BusObj.RowKey = BusObj.Number;

                TableManager TableManagerObj = new TableManager("bus");
                TableManagerObj.InsertEntity<Bus>(BusObj, true);
            }
            // Update
            else
            {
                BusObj.PartitionKey = BusObj.Name;
                BusObj.RowKey = BusObj.Number;

                TableManager TableManagerObj = new TableManager("bus");
                TableManagerObj.InsertEntity<Bus>(BusObj, false);
            }

            return RedirectToAction("Get");
        }

        public ActionResult Get()
        {
            TableManager TableManagerObj = new TableManager("bus");
            // Get all Bus object, pass null as query
            List<Bus> BusListObj = TableManagerObj.RetrieveEntity<Bus>(null);
            return View(BusListObj);
        }

        public ActionResult ChangeStatus(string id, bool Status)
        {
            TableManager TableManagerObj = new TableManager("bus");
            List<Bus> SutdentListObj = TableManagerObj.RetrieveEntity<Bus>("RowKey eq '" + id + "'");
            Bus BusObj = SutdentListObj.FirstOrDefault();
            //BusObj.IsActive = !Status;
            TableManagerObj.InsertEntity<Bus>(BusObj, false);

            return RedirectToAction("Get");
        }

        public ActionResult Delete(string id)
        {
            // Retrieve the object to Delete
            TableManager TableManagerObj = new TableManager("bus");
            List<Bus> SutdentListObj = TableManagerObj.RetrieveEntity<Bus>("RowKey eq '" + id + "'");
            Bus BusObj = SutdentListObj.FirstOrDefault();

            // Delete the object
            TableManagerObj.DeleteEntity<Bus>(BusObj);
            return RedirectToAction("Get");
        }
        public ActionResult GetLocation(string id)
        {
            return View("Map");
        }
        public ActionResult HomePage()
        {
            return View(new Bus());

        }

    }
}