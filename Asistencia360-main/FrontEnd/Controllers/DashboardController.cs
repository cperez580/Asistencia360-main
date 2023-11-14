using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class DashboardController: Controller
    {
        private DashboardHelper dashboardHelper;
        public DashboardController()
        {
            dashboardHelper = new DashboardHelper();
        }

        // GET: DashboardController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadIndex(string start, string end)
        {
            JsonResult models = dashboardHelper.GetData(start, end);
            return models;
        }

    }
}
