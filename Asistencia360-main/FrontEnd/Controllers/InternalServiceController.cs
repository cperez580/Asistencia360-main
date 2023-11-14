using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class InternalServiceController: Controller
    {
        private InternalServiceHelper serviceinternalHelper;


        public InternalServiceController ()
        {
            serviceinternalHelper = new InternalServiceHelper();
        }

        public void AssignViewBag()
        {

        }

        // GET: InternalServiceController
        public ActionResult Index()
        {
            AssignViewBag();
            return View();
        }

        public ActionResult LoadIndex(string active)
        {
            List<InternalServiceViewModel> models = serviceinternalHelper.GetAll(active);

            var response = new DataTableResponseModel<InternalServiceViewModel>
            {
                data = models.ToList(),
                RecordsFiltered = models.Count(),
                RecordsTotal = models.Count()
            };
            return Json(response);
        }

        // GET: InternalServiceController/Details/5
        // GET: InternalServiceController/Create
        public ActionResult Create()
        {
            AssignViewBag();
            return View();
        }

        // POST: InternalServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InternalServiceViewModel internalservice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    internalservice.Active = true;
                    internalservice = serviceinternalHelper.Add(internalservice);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }
                return View(internalservice);


            }
            catch
            {
                return View();
            }
        }

        // GET: InternalServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            InternalServiceViewModel internalservice = serviceinternalHelper.GetByID(id);
            AssignViewBag();
            return View(internalservice);
        }

        // POST: InternalServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InternalServiceViewModel internalservice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    internalservice = serviceinternalHelper.Edit(internalservice);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }

                return View(internalservice);
            }
            catch
            {
                return View();
            }
        }

        // POST: CompanyController/Deactivate/5
        [HttpPost]
        public ActionResult Deactivate(int id)
        {
            serviceinternalHelper.Deactivation(id);
            AssignViewBag();
            return RedirectToAction(nameof(Index));

        }
    }
}
