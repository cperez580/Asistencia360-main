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
    public class ServiceController : ControllerBase
    {
        private IServiceDAL serviceDAL;

        #region Constructors

        public ServiceController()
        {
            serviceDAL = new ServiceDALImpl();
        }

        #endregion

        #region Parse

        ServiceModel Parse(Service entity)
        {
            return new ServiceModel
            {
                ServiceId = entity.ServiceId,
                Title = entity.Title,
                AdminId = entity.AdminId,
                Type = entity.Type,
                Priority = entity.Priority,
                ServiceSchedule = entity.ServiceSchedule,
                SupportSchedule = entity.SupportSchedule,
                SlaOpen = entity.SlaOpen,
                SlaClose = entity.SlaClose,
                OlaOpen = entity.OlaOpen,
                OlaClose = entity.OlaClose,
                Active = entity.Active
            };
        }

        Service Parse(ServiceModel entity)
        {
            return new Service
            {
                ServiceId = entity.ServiceId,
                Title = entity.Title,
                AdminId = entity.AdminId,
                Type = entity.Type,
                Priority = entity.Priority,
                ServiceSchedule = entity.ServiceSchedule,
                SupportSchedule = entity.SupportSchedule,
                SlaOpen = entity.SlaOpen,
                SlaClose = entity.SlaClose,
                OlaOpen = entity.OlaOpen,
                OlaClose = entity.OlaClose,
                Active = entity.Active
            };
        }

        #endregion

        // GET: api/<ServiceController>
        [HttpGet]
        public async Task<JsonResult> Get(string active)
        {
            IEnumerable<Service> services = new List<Service>();
            
            if (active == "full")
                services = await serviceDAL.GetAll();
            else
                services = serviceDAL.Find(m => m.Active == Convert.ToBoolean(active));

            List<ServiceModel> serviceModel = new List<ServiceModel>();
            
            foreach (Service service in services)
            {
                serviceModel.Add(Parse(service));
            }
            return new JsonResult(serviceModel);
        }

        // GET: api/<ServiceController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Service service = await serviceDAL.Get(id);

            return new JsonResult(service);
        }

        // POST: api/<ServiceController>
        [HttpPost]
        public JsonResult Post([FromBody] ServiceModel service) 
        {
            serviceDAL.Add(Parse(service));

            return new JsonResult(service);
        }

        // PUT: api/<ServiceController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ServiceModel service) 
        {
            serviceDAL.Update(Parse(service));

            return new JsonResult(service);
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Deactivation(int id)
        {
            Service service = await serviceDAL.Get(id);

            if(service.Active)
                service.Active = false;
            else
                service.Active = true;

            serviceDAL.Update(service);

            return new JsonResult(service);

        }

    }
}
