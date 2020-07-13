using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger_King_Courier.Models;
using Messenger_King_Courier.ViewModels;

namespace Messenger_King_Courier.Controllers
{
    public class ViewModelsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ViewModels
        public ActionResult Index()
        {
            List<InspectedVehicles> VehicleList = new List<InspectedVehicles>();
            var information = (from IC in db.InspectionCategories
                               join I in db.Inspections on IC.InspectCat_ID equals I.InspectCat_ID
                               join V in db.Vehicles on I.Vehicle_ID equals V.Vehicle_ID
                               select new { I.Inspection_Date, IC.InspectCat_Status, V.Vehicle_ID }).ToList();

            foreach (var item in information)
            {
                InspectedVehicles objIV = new InspectedVehicles();
                objIV.Vehicle_ID = item.Vehicle_ID;
                objIV.Inspection_Date = item.Inspection_Date;
                objIV.InspectCat_Status = item.InspectCat_Status;
                VehicleList.Add(objIV);
            }
            return View(VehicleList);
        }
    }
}