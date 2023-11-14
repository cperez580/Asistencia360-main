using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController: ControllerBase
    {
        private IFAQDAL faqDAL;

        #region Constructors
        public FAQController()
        {
            faqDAL = new FAQDALImpl();
        }
        #endregion

        #region Parse
        FAQModel Parse(Faq faq)
        {
            return new FAQModel
            {
                FaqId = faq.FaqId,
                Title = faq.Title,
                Symptom = faq.Symptom,
                Problem = faq.Problem,
                Solution = faq.Solution,
                Notes = faq.Notes,
                Active = faq.Active,
            };
        }

        Faq Parse(FAQModel faq)
        {
            return new Faq
            {
                FaqId = faq.FaqId,
                Title = faq.Title,
                Symptom = faq.Symptom,
                Problem = faq.Problem,
                Solution = faq.Solution,
                Notes = faq.Notes,
                Active = faq.Active,
            };
        }
        #endregion

        // GET: api/<]FAQController>
        [HttpGet]
        public async Task<JsonResult> Get(string active)
        {
            IEnumerable<Faq> faqs = new List<Faq>();
            if(active == "full")
                faqs = await faqDAL.GetAll();
            else
                faqs = faqDAL.Find(m => m.Active == Convert.ToBoolean(active));

            List<FAQModel> faqModel = new List<FAQModel>();
            foreach (Faq faq in faqs)
            {
                faqModel.Add(Parse(faq));
            }
            return new JsonResult(faqModel);
        }

        // GET api/<FAQController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Faq faq = await faqDAL.Get(id);
            return new JsonResult(faq);
        }

        // POST api/<FAQController>
        [HttpPost]
        public JsonResult Post([FromBody] FAQModel faq)
        {
            faqDAL.Add(Parse(faq));
            return new JsonResult(faq);
        }

        // PUT api/<FAQController>/5
        [HttpPut]
        public JsonResult Put(int id, [FromBody] FAQModel faq)
        {
            faqDAL.Update(Parse(faq));
            return new JsonResult(faq);
        }

        // PUT api/<FAQController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Deactivation(int id)
        {
            Faq faq = await faqDAL.Get(id);
            if (faq.Active) faq.Active = false;
            else faq.Active = true;
            faqDAL.Update(faq);
            return new JsonResult(faq);
        }
    }
}
