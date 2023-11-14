using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class HardDriveController: Controller
    {

        HardDriveHelper hdHelper;
        InventoryHelper inventoryHelper;

        public HardDriveController()
        {
            hdHelper = new HardDriveHelper();
            inventoryHelper = new InventoryHelper();
        }
        public void AssignViewBag()
        {

        }
        
        // GET: HardDriveController
        public ActionResult Index()
        {
            AssignViewBag();
            return View();
        }

        public ActionResult LoadIndex()
        {
            List<HardDriveViewModel> hardDrives = hdHelper.GetAll();

            foreach (HardDriveViewModel hardDrive in hardDrives)
            {

                List<InventoryViewModel> inventories = new List<InventoryViewModel>();
                inventories.Add(inventoryHelper.GetByID(hardDrive.InventoryId));
                hardDrive.Inventories = inventories;
            }
            var response = new DataTableResponseModel<HardDriveViewModel>
            {
                data = hardDrives.ToList(),
                RecordsFiltered = hardDrives.Count(),
                RecordsTotal = hardDrives.Count()
            };
            return Json(response);
        }

        // GET: HardDriveController/Details/5
        public ActionResult Details(int id)
        {
            HardDriveViewModel hardDrive = hdHelper.GetByID(id);
            hardDrive.Inventories = inventoryHelper.GetAll("Full");
            AssignViewBag();
            return View();
        }

        // GET: HardDriveController/Create
        public ActionResult Create()
        {
            HardDriveViewModel hdItem = new HardDriveViewModel();
            hdItem.Inventories = inventoryHelper.GetAll("true");
            AssignViewBag();
            return View(hdItem);
        }

        // POST: HardDriveController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HardDriveViewModel hardDrive)
        {
            try
            {
                ModelState.Remove("Inventories");
                if(ModelState.IsValid)
                { 
                    hardDrive = hdHelper.Add(hardDrive);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    hardDrive.Inventories = inventoryHelper.GetAll("true");
                    return View(hardDrive);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: HardDriveController/Edit/5
        public ActionResult Edit(int id)
        {
            HardDriveViewModel hardDrive = hdHelper.GetByID(id);
            hardDrive.Inventories = inventoryHelper.GetAll("full");
            AssignViewBag();
            return View(hardDrive);
        }

        // POST: HardDriveController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HardDriveViewModel hardDrive)
        {
            try
            {
                ModelState.Remove("Inventories");
                if (ModelState.IsValid)
                {
                    hardDrive = hdHelper.Edit(hardDrive);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }
                hardDrive.Inventories = inventoryHelper.GetAll("true");
                return View(hardDrive);
            }
            catch
            {
                AssignViewBag();
                return View();
            }
        }
    }
}
