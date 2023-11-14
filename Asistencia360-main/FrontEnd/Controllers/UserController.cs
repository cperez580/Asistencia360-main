using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Models.UserModels;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class UserController: Controller
    {
        private CompanyHelper companyHelper;
        private DepartmentHelper departmentHelper;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData()
        {
            List<UserViewModel> models = new List<UserViewModel>();

            for (int i = 0; i < 4; i++)
            {
                models.Add(new UserViewModel
                {
                    UserId = i,
                    Name = "Juan",
                    LastName = "Pérez",
                    IdNumber = i,
                    Email = "example@example.com",
                    Password = "abc",
                    CompanyId = i,
                    DepartmentId = i,
                    RoleId = i,
                    Active = true
                });

                models.Add(new UserViewModel
                {
                    UserId = i,
                    Name = "Juan",
                    LastName = "Pérez",
                    IdNumber = i,
                    Email = "example@example.com",
                    Password = "abc",
                    CompanyId = i,
                    DepartmentId = i,
                    RoleId = i,
                    Active = true
                });

                models.Add(new UserViewModel
                {
                    UserId = i,
                    Name = "Juan",
                    LastName = "Pérez",
                    IdNumber = i,
                    Email = "example@example.com",
                    Password = "abc",
                    CompanyId = i,
                    DepartmentId = i,
                    RoleId = i,
                    Active = true
                });
            }

            var response = new DataTableResponseModel<UserViewModel>
            {
                data = models.ToList(),
                RecordsFiltered = models.Count(),
                RecordsTotal = models.Count()
            };

            return Json(response);
        }

        public ActionResult Register()
        {
            //
            //
            //Sending Companies List
            //
            List<CompanyViewModel> companies = companyHelper.GetAll("true");
            List<DepartmentViewModel> departments = departmentHelper.GetAll("true");

            //
            //Sending Departments List
            //
            

            UserViewModel user = new UserViewModel();
            user.Companies = companies;
            user.Departments = departments;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel model)
        {
            try
            {
                return RedirectToAction("Index", "Dashboard");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                return RedirectToAction("Index", "Dashboard");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            return View("Login");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                TempData["ForgotPasswordSuccess"] = "Se ha enviado un correo a " + model.email + " con los pasos para restablecer la contraseña";
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }


    }
}
