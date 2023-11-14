using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private DashboardDAL dashboardDAL;

        #region Constructors

        public DashboardController()
        {
            dashboardDAL = new DashboardDAL();
        }

        #endregion

        // GET api/<DashboardController>
        [HttpGet]
        public JsonResult Get(string start, string end)
        {
            sp_TicketsStatus_Result tStatusR = dashboardDAL.Tickets_Status(start, end).First();
            List<sp_OpenTicketsByTechnician_Result> otByTechnicianR = dashboardDAL.OpenTickets_ByTechnician(start, end);
            List<sp_TicketsByCustomer_Result> tByCustomerR = dashboardDAL.Tickets_ByCustomer(start, end);
            List<sp_TicketsByCompany_Result> tByCompanyR = dashboardDAL.Tickets_ByCompany(start, end);
            List<sp_TicketsByService_Result> tByServiceR = dashboardDAL.Tickets_ByService(start, end);
            List<sp_ServicesByCompany_Result> sByCompanyR = dashboardDAL.Services_ByCompany(start, end);
            List<sp_TicketsByInternalService_Result> tByInternalServiceR = dashboardDAL.Tickets_ByInternalService(start, end);
            List<sp_TicketsByType_Result> tByTypeR = dashboardDAL.Tickets_ByType(start, end);

            List<string> labels = new List<string>();
            List<int> values = new List<int>();

            #region otByTechnician
            labels.Clear();
            values.Clear();

            foreach (sp_OpenTicketsByTechnician_Result i in otByTechnicianR)
            {
                labels.Add(i.Technician);
                values.Add(i.OpenTickets);
            }

            var otByTechnician = new
            {
                labels = labels.ToArray(),
                values = values.ToArray()
            };
            #endregion

            #region tByCustomer
            labels.Clear();
            values.Clear();

            foreach (sp_TicketsByCustomer_Result i in tByCustomerR)
            {
                labels.Add(i.Customer);
                values.Add(i.Tickets);
            }

            var tByCustomer = new
            {
                labels = labels.ToArray(),
                values = values.ToArray()
            };
            #endregion

            #region tByCompany
            labels.Clear();
            values.Clear();

            foreach (sp_TicketsByCompany_Result i in tByCompanyR) 
            {
                labels.Add(i.Company);
                values.Add(i.Tickets);
            }

            var tByCompany = new 
            { 
                labels = labels.ToArray(),
                values = values.ToArray()
            };
            #endregion

            #region tByService
            labels.Clear();
            values.Clear();

            foreach (sp_TicketsByService_Result i in tByServiceR)
            {
                labels.Add(i.Service);
                values.Add(i.Tickets);
            }

            var tByService = new
            {
                labels = labels.ToArray(),
                values = values.ToArray()
            };
            #endregion

            #region sByCompany
            labels.Clear();
            values.Clear();

            foreach (sp_ServicesByCompany_Result i in sByCompanyR)
            {
                labels.Add(i.Company);
                values.Add(i.Services);
            }

            var sByCompany = new
            {
                labels = labels.ToArray(),
                values = values.ToArray()
            };
            #endregion

            #region tByInternalService
            labels.Clear();
            values.Clear();

            foreach (sp_TicketsByInternalService_Result i in tByInternalServiceR)
            {
                labels.Add(i.InternalService);
                values.Add(i.Tickets);
            }

            var tByInternalService = new
            {
                labels = labels.ToArray(),
                values = values.ToArray()
            };
            #endregion

            #region tByType
            labels.Clear();
            values.Clear();

            foreach (sp_TicketsByType_Result i in tByTypeR)
            {
                labels.Add(i.Type);
                values.Add(i.Tickets);
            }

            var tByType = new
            {
                labels = labels.ToArray(),
                values = values.ToArray()
            };
            #endregion

            var data = new
            {
                tStatus = tStatusR,
                otByTechnician = otByTechnician,
                tByCustomer = tByCustomer,
                tByCompany = tByCompany,
                tByService = tByService,
                sByCompany = sByCompany,
                tByInternalService = tByInternalService,
                tByType = tByType,
            };

            JsonResult result = new JsonResult(data);

            return result;
        }
    }
}