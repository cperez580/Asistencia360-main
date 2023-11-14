using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternalServiceController: ControllerBase
    {
        private IInternalServiceDAL internalserviceDAL;

        #region Constructors
        public InternalServiceController()
        {
            internalserviceDAL = new InternalServiceDALImpl();
        }
        #endregion

        #region Parse
        InternalServiceModel Parse(InternalService interservice)
        {
            return new InternalServiceModel
            {
                InternalServiceId = interservice.InternalServiceId,
                Title = interservice.Title,
                Description = interservice.Description,
                Active = interservice.Active,
            };
        }

        InternalService Parse(InternalServiceModel interservice)
        {
            return new InternalService
            {
                InternalServiceId  = interservice.InternalServiceId,
                Title = interservice.Title,
                Description = interservice.Description,
                Active = interservice.Active,
            };
        }
        #endregion

        // GET: api/<]InternalServiceController>
        [HttpGet]
        public async Task<JsonResult> Get(string active)
        {
            

            IEnumerable<InternalService> internalServices = new List<InternalService>();
            if (active == "full")
                internalServices = await internalserviceDAL.GetAll();
            else
                internalServices = internalserviceDAL.Find(m => m.Active == Convert.ToBoolean(active));

            List<InternalServiceModel> internalServiceModel = new List<InternalServiceModel>();
            foreach (InternalService internalService in internalServices)
            {
                internalServiceModel.Add(Parse(internalService));
            }
            return new JsonResult(internalServiceModel);
        }

        // GET api/<InternalServiceController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            InternalService internalService = await internalserviceDAL.Get(id);
            return new JsonResult(internalService);
        }

        // POST api/<InternalServiceController>
        [HttpPost]
        public JsonResult Post([FromBody] InternalServiceModel internalservice)
        {
            internalserviceDAL.Add(Parse(internalservice));
            return new JsonResult(internalservice);
        }

        // PUT api/<InternalServiceController>/5
        [HttpPut]
        public JsonResult Put(int id, [FromBody] InternalServiceModel internalservice)
        {
            internalserviceDAL.Update(Parse(internalservice));
            return new JsonResult(internalservice);
        }

        // PUT api/<InternalServiceController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Deactivation(int id)
        {
            InternalService internalservice = await internalserviceDAL.Get(id);
            if (internalservice.Active) internalservice.Active = false;
            else internalservice.Active = true;
            internalserviceDAL.Update(internalservice);
            return new JsonResult(internalservice);
        }
    }
}
