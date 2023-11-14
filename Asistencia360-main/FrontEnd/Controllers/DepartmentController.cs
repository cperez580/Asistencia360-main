using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class DepartmentController: Controller
    {
        DepartmentHelper departmentHelper;
        CompanyHelper companyHelper;

        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public DepartmentController(IHttpContextAccessor httpContextAccessor)
        //{
        //    departmentHelper = new DepartmentHelper();
        //    companyHelper = new CompanyHelper();

        //    _httpContextAccessor = httpContextAccessor;
        //}
        public DepartmentController()
        {
            departmentHelper = new DepartmentHelper();
            companyHelper = new CompanyHelper();

        }
        public void AssignViewBag()
        {

        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            AssignViewBag();
            return View();
        }

        public ActionResult LoadIndex(string active)
        {

            List<DepartmentViewModel> departments = departmentHelper.GetAll(active);

            foreach (DepartmentViewModel department in departments)
            {
                List<CompanyViewModel> companies = new List<CompanyViewModel>();
                companies.Add(companyHelper.GetByID(department.CompanyId));
                department.Companies = companies;
            }
            var response = new DataTableResponseModel<DepartmentViewModel>
            {
                data = departments.ToList(),
                RecordsFiltered = departments.Count(),
                RecordsTotal = departments.Count()
            };
            return Json(response);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            DepartmentViewModel depaItem = new DepartmentViewModel();
            depaItem.Companies = companyHelper.GetAll("true");
            AssignViewBag();
            return View(depaItem);
        }


        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel department)
        {

            try
            {

                ModelState.Remove("Companies");

                if (ModelState.IsValid)
                {
                    department.Active = true;
                    department = departmentHelper.Add(department);

                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    department.Companies = companyHelper.GetAll("true");
                    return View(department);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            DepartmentViewModel department = departmentHelper.GetByID(id);
            department.Companies = companyHelper.GetAll("full");
            AssignViewBag();
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel department)
        {
            try
            {
                ModelState.Remove("Companies");

                if (ModelState.IsValid)
                {
                    department = departmentHelper.Edit(department);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }
                department.Companies = companyHelper.GetAll("true");
                return View(department);
            }
            catch
            {
                return View();
            }
        }

        // POST: DepartmentController/Deactivate/5
        [HttpPost]
        public ActionResult Deactivate(int id)
        {
            departmentHelper.Deactivation(id);
            AssignViewBag();
            return RedirectToAction(nameof(Index));
        }
    }
}
