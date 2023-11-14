using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FrontEnd.Controllers
{
    public class CompanyController: Controller
    {
        private CompanyHelper companyHelper;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public CompanyController(IHttpContextAccessor httpContextAccessor)
        //{
        //    companyHelper = new CompanyHelper();
        //    _httpContextAccessor = httpContextAccessor;
        //}
        
        public CompanyController()
        {
            companyHelper = new CompanyHelper();
        }

        public void AssignViewBag()
        {

        }

        // GET: CompanyController
        public ActionResult Index()
        {
            AssignViewBag();
            return View();
        }

        public ActionResult LoadIndex(string active)
        {
            List<CompanyViewModel> models = companyHelper.GetAll(active);

            var response = new DataTableResponseModel<CompanyViewModel>
            {
                data = models.ToList(),
                RecordsFiltered = models.Count(),
                RecordsTotal = models.Count()
            };
            
            return Json(response);
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            AssignViewBag();
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyViewModel company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    company.Active = true;
                    company = companyHelper.Add(company);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }
                return View(company);
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)
        {
            CompanyViewModel company = companyHelper.GetByID(id);
            AssignViewBag();
            return View(company);
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyViewModel company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    company = companyHelper.Edit(company);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }

                return View(company);
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
            companyHelper.Deactivation(id);
            AssignViewBag();
            return RedirectToAction(nameof(Index));
            
        }
    }
}
