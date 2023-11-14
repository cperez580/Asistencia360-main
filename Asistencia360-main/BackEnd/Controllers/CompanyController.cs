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
    public class CompanyController: ControllerBase
    {
        private ICompanyDAL companyDAL;

        #region Constructors

        public CompanyController()
        {
            companyDAL = new CompanyDALImpl();
        }
        #endregion

        #region Parse
        CompanyModel Parse(Company entity)
        {
            return new CompanyModel
            {
                CompanyId = entity.CompanyId,
                Title = entity.Title,
                Description = entity.Description,
                Active = entity.Active
            };
        }

        Company Parse(CompanyModel entity)
        {
            return new Company
            {
                CompanyId = entity.CompanyId,
                Title = entity.Title,
                Description = entity.Description,
                Active = entity.Active
            };
        }
        #endregion

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<JsonResult> Get(string active)
        {
            IEnumerable<Company> companies = new List<Company>();
            if(active == "full")
                companies = await companyDAL.GetAll();
            else
                companies = companyDAL.Find(m => m.Active == Convert.ToBoolean(active));

            List<CompanyModel> companyModel = new List<CompanyModel>();
            foreach (Company company in companies)
            {
                companyModel.Add(Parse(company));
            }
            return new JsonResult(companyModel);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Company company = await companyDAL.Get(id);
            return new JsonResult(company);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public JsonResult Post([FromBody] CompanyModel company)
        {
            companyDAL.Add(Parse(company));
            return new JsonResult(company);
        }

        // PUT api/<CompanyController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CompanyModel company)
        {
            companyDAL.Update(Parse(company));
            return new JsonResult(company);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Deactivation(int id)
        {
            Company company = await companyDAL.Get(id);
            if(company.Active) company.Active = false;
            else company.Active = true;
            companyDAL.Update(company);
            return new JsonResult(company);
        }
    }
}