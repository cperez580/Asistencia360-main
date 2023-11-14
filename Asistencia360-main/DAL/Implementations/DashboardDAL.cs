using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DashboardDAL
    {
        private asistencia360Context _context;

        public DashboardDAL()
        {
            _context = new asistencia360Context();
        }

        public List<sp_TicketsStatus_Result> Tickets_Status(string start, string end)
        {
            List<sp_TicketsStatus_Result> result  = _context.sp_TicketsStatus_Result.FromSqlRaw("CALL `asistencia360`.`sp_tickets_status`('" + start + "', '" + end + "');").ToList();
            return result;
        }
        public List<sp_OpenTicketsByTechnician_Result> OpenTickets_ByTechnician(string start, string end)
        {
            List<sp_OpenTicketsByTechnician_Result> result = _context.sp_OpenTicketsByTechnician_Result.FromSqlRaw("CALL `asistencia360`.`sp_opentickets_bytechnician`('" + start + "', '" + end + "');").ToList();
            return result;
        }
        public List<sp_TicketsByCustomer_Result> Tickets_ByCustomer(string start, string end)
        {
            List<sp_TicketsByCustomer_Result> result = _context.sp_TicketsByCustomer_Result.FromSqlRaw("CALL `asistencia360`.`sp_tickets_bycustomer`('" + start + "', '" + end + "');").ToList();
            return result;
        }
        public List<sp_TicketsByCompany_Result> Tickets_ByCompany(string start, string end)
        {
            List<sp_TicketsByCompany_Result> result = _context.sp_TicketsByCompany_Result.FromSqlRaw("CALL `asistencia360`.`sp_tickets_bycompany`('" + start + "', '" + end + "');").ToList();
            return result;
        }
        public List<sp_TicketsByService_Result> Tickets_ByService(string start, string end)
        {
            List<sp_TicketsByService_Result> result = _context.sp_TicketsByService_Result.FromSqlRaw("CALL `asistencia360`.`sp_tickets_byservice`('" + start + "', '" + end + "');").ToList();
            return result;
        }
        public List<sp_ServicesByCompany_Result> Services_ByCompany(string start, string end)
        {
            List<sp_ServicesByCompany_Result> result = _context.sp_ServicesByCompany_Result.FromSqlRaw("CALL `asistencia360`.`sp_services_bycompany`('" + start + "', '" + end + "');").ToList();
            return result;
        }
        public List<sp_TicketsByInternalService_Result> Tickets_ByInternalService(string start, string end)
        {
            List<sp_TicketsByInternalService_Result> result = _context.sp_TicketsByInternalService_Result.FromSqlRaw("CALL `asistencia360`.`sp_tickets_byinternalservice`('" + start + "', '" + end + "');").ToList();
            return result;
        }
        public List<sp_TicketsByType_Result> Tickets_ByType(string start, string end)
        {
            List<sp_TicketsByType_Result> result = _context.sp_TicketsByType_Result.FromSqlRaw("CALL `asistencia360`.`sp_tickets_bytype`('" + start + "', '" + end + "');").ToList();
            return result;
        }


    }
}