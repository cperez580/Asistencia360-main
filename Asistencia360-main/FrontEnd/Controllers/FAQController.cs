using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class FAQController : Controller
    {

        FAQHelper faqHelper;

        public FAQController()
        {
            faqHelper = new FAQHelper();

        }
        public void AssignViewBag()
        {

        }

        // GET: FAQController
        public ActionResult Index()
        {
            AssignViewBag();
            return View();
        }

        public ActionResult LoadIndex(string active)
        {
            List<FAQViewModel> models = faqHelper.GetAll(active);

            var response = new DataTableResponseModel<FAQViewModel>
            {
                data = models.ToList(),
                RecordsFiltered = models.Count(),
                RecordsTotal = models.Count()
            };
            return Json(response);
        }

        // GET: FAQController/Create
        public ActionResult Create()
        {
            AssignViewBag();
            return View();
        }

        // POST: FAQController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FAQViewModel faq)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    faq.Active = true;
                    faq = faqHelper.Add(faq);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }
                return View(faq);
            }
            catch
            {
                return View();
            }
        }

        // GET: FAQController/Edit/5
        public ActionResult Edit(int id)
        {
            FAQViewModel faq = faqHelper.GetByID(id);
            AssignViewBag();
            return View(faq);
        }

        // POST: FAQController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FAQViewModel faq)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    faq = faqHelper.Edit(faq);
                    AssignViewBag();
                    return RedirectToAction(nameof(Index));
                }
                return View(faq);
            }
            catch
            {
                return View();
            }
        }
        // POST: FAQController/Deactivate/5
        [HttpPost]
        public ActionResult Deactivate(int id)
        {
            faqHelper.Deactivation(id);
            AssignViewBag();
            return RedirectToAction(nameof(Index));

        }
    }
}
