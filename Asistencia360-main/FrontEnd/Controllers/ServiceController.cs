using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Models.UserModels;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;

namespace FrontEnd.Controllers
{
    public class ServiceController: Controller
    {
        private ServiceHelper serviceHelper;
        private UserHelper userHelper;

        public ServiceController()
        {
            serviceHelper = new ServiceHelper();
            userHelper = new UserHelper();
        }

        public void AssignViewBag()
        {

        }


        // GET: ServiceController
        public ActionResult Index()
        {
            AssignViewBag();

            return View();
        }

        public ActionResult LoadIndex(string active)
        {
            List<ServiceViewModel> models = serviceHelper.GetAll(active);

            foreach (ServiceViewModel service in models)
            {
                List<UserViewModel> users = new List<UserViewModel>();
                users.Add(userHelper.GetByID(service.AdminId));
                service.Users = users;
            }
            var response = new DataTableResponseModel<ServiceViewModel>
            {
                data = models.ToList(),
                RecordsFiltered = models.Count(),
                RecordsTotal = models.Count()
            };
            return Json(response);
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            AssignViewBag();

            ServiceViewModel model = new ServiceViewModel();

            model.Users = userHelper.GetAll("true");

            return View(model);
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceViewModel service)
        {
            try
            {
                ModelState.Remove("Users");

                if(ModelState.IsValid)
                {
                    service.Active = true;

                    service = serviceHelper.Add(service);

                    AssignViewBag();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    service.Users = userHelper.GetAll("true");

                    return View(service);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceViewModel service = serviceHelper.GetByID(id);

            service.Users = userHelper.GetAll("true");

            AssignViewBag();

            return View(service);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceViewModel service)
        {
            try
            {
                ModelState.Remove("Users");

                if (ModelState.IsValid)
                {
                    service = serviceHelper.Edit(service);

                    AssignViewBag();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    service.Users = userHelper.GetAll("true");

                    return View(service);
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: ServiceController/Deactivate/5
        [HttpPost]
        public ActionResult Deactivate(int id)
        {
            serviceHelper.Deactivation(id);

            AssignViewBag();

            return RedirectToAction(nameof(Index));
        }
    }
}
