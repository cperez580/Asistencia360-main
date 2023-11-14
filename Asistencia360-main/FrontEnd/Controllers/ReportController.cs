using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ReportController: Controller
    {
        // GET: ReportController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
