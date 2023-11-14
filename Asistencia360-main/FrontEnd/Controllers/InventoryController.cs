using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class InventoryController: Controller
    {
        InventoryHelper inventoryHelper;
        HardDriveHelper hdHelper;

        public InventoryController()
        {
            inventoryHelper = new InventoryHelper();
            hdHelper = new HardDriveHelper();
        }
        public void AssignViewBag()
        {

        }

        // GET: InventoryController
        public ActionResult Index()
        {
            AssignViewBag();
            return View();
        }

        public ActionResult LoadIndex(string active)
        {
            List<InventoryViewModel> inventories = inventoryHelper.GetAll(active);

            var response = new DataTableResponseModel<InventoryViewModel>
            {
                data = inventories.ToList(),
                RecordsFiltered = inventories.Count(),
                RecordsTotal = inventories.Count()
            };
            return Json(response);
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            AssignViewBag();
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventoryViewModel inv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    inv.Active = true;
                    inv = inventoryHelper.Add(inv);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }
                return View(inv);
            }
            catch
            {
                return View();
            }
        }
        /*[HttpPost]
        public IActionResult AgregarDiscos()
        {
            var nuevoDisco = new HardDriveViewModel
            {
                HardDriveId = 1,
                InventoryId = 1,
                Title = "Nuevo Disco",
                Size = "100 GB",
            };
            var discos = ObtenerDiscos();
            discos.Add(nuevoDisco);
            ViewBag.Discos = discos;
            return RedirectToAction("Create");
        }
        private List<HardDriveViewModel> ObtenerDiscos()
        {
            return ViewBag.Discos as List<HardDriveViewModel> ?? new List<HardDriveViewModel>();
        }*/

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            InventoryViewModel faq = inventoryHelper.GetByID(id);
            AssignViewBag();
            return View(faq);
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InventoryViewModel inv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    inv = inventoryHelper.Edit(inv);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }
                return View(inv);
            }
            catch
            {
                return View();
            }
        }

        // POST: InventoryController/Deactivate/5
        [HttpPost]
        public ActionResult Deactivate(int id)
        {
            inventoryHelper.Deactivation(id);
            AssignViewBag();
            return RedirectToAction(nameof(Index));
        }
    }
}
