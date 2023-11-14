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
    public class TicketController : ControllerBase
    {
        private ITicketDAL ticketDAL;

        #region Constructors

        public TicketController()
        {
            ticketDAL = new TicketDALImpl();
        }

        #endregion

        #region Parse

        TicketModel Parse(Ticket entity)
        {
            return new TicketModel
            {
                TicketId = entity.TicketId,
                CustomerId = entity.CustomerId,
                TechnicianId = entity.TechnicianId,
                Title = entity.Title,
                Description = entity.Description,
                Type = entity.Type,
                Priority = entity.Priority,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                SolutionTime = entity.SolutionTime,
                Status = entity.Status,
                Attachment = entity.Attachment,
                ServiceId = entity.ServiceId,
                InternalServiceId = entity.InternalServiceId,
                InventoryId = entity.InventoryId,
                FaqId = entity.FaqId
            };
        }

        Ticket Parse(TicketModel entity)
        {
            return new Ticket
            {
                TicketId = entity.TicketId,
                CustomerId = entity.CustomerId,
                TechnicianId = entity.TechnicianId,
                Title = entity.Title,
                Description = entity.Description,
                Type = entity.Type,
                Priority = entity.Priority,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                SolutionTime = entity.SolutionTime,
                Status = entity.Status,
                Attachment = entity.Attachment,
                ServiceId = entity.ServiceId,
                InternalServiceId = entity.InternalServiceId,
                InventoryId = entity.InventoryId,
                FaqId = entity.FaqId
            };
        }

        #endregion

        // GET: api/<TicketController>
        [HttpGet]
        public async Task<JsonResult> Get(string active)
        {
            IEnumerable<Ticket> tickets = new List<Ticket>();

            if (active == "full")
                tickets = ticketDAL.Find(m => m.Status != "Cerrado");
            //tickets = await ticketDAL.GetAll();
            else
                tickets = ticketDAL.Find(m => m.Status == "Cerrado");

            List<TicketModel> ticketModel = new List<TicketModel>();

            foreach (Ticket ticket in tickets)
            {
                ticketModel.Add(Parse(ticket));
            }
            return new JsonResult(ticketModel);
        }

        // GET: api/<TicketController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Ticket ticket = await ticketDAL.Get(id);

            return new JsonResult(ticket);
        }

        // POST: api/<TicketController>
        [HttpPost]
        public JsonResult Post([FromBody] TicketModel ticket)
        {
            ticketDAL.Add(Parse(ticket));

            return new JsonResult(ticket);
        }

        // PUT: api/<TicketController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TicketModel ticket)
        {
            ticketDAL.Update(Parse(ticket));

            return new JsonResult(ticket);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Deactivation(int id)
        {
            Ticket ticket = await ticketDAL.Get(id);

            if (ticket.Status != "Cerrado")
                ticket.Status = "Cerrado";
            else
                ticket.Status = "Reaperturado";

            ticketDAL.Update(ticket);

            return new JsonResult(ticket);

        }
    }
}