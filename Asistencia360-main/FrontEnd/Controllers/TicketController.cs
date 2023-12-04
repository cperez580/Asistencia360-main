using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Models.UserModels;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using System.Collections.Generic;
using System.Net.Security;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace FrontEnd.Controllers
{
    public class TicketController: Controller
    {
        private TicketHelper ticketHelper;
        private ServiceHelper serviceHelper;
        private UserHelper userHelper;
        private InternalServiceHelper internalServiceHelper;
        private CommentHelper commentHelper;



        public TicketController()
        {
            ticketHelper = new TicketHelper (); 
            serviceHelper = new ServiceHelper ();
            userHelper = new UserHelper ();
            internalServiceHelper = new InternalServiceHelper ();
            commentHelper = new CommentHelper ();

        }

        public void AssignViewBag()
        {

        }

        // GET: TicketController
        public ActionResult Index()
        {
            AssignViewBag();
            return View();
        }

        public ActionResult LoadIndex(string active)
        {
            List<TicketViewModel> models = ticketHelper.GetAll(active);

            var response = new DataTableResponseModel<TicketViewModel>
            {
                data = models.ToList(),
                RecordsFiltered = models.Count(),
                RecordsTotal = models.Count()
            };

            return Json(response);
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {

            AssignViewBag();
            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketViewModel ticket)
        {
            try
            {
                ModelState.Remove("FAQlist");
                ModelState.Remove("Services");
                ModelState.Remove("Technicians");
                ModelState.Remove("InventoryList");
                ModelState.Remove("InternalServices");
                ModelState.Remove("status");
                ModelState.Remove("Customers");
                ModelState.Remove("Comments");




                if (ModelState.IsValid)
                {
                    ticket.StartDate = DateTime.Now;
                    ticket.customerId = 1;
                    ticket.status = "Nuevo";
                    ticket.Type = "Sin asignar";
                    ticket = ticketHelper.Add(ticket);
                    

                    AssignViewBag();

                    return RedirectToAction(nameof(Index));

                }
                
                return View(ticket);
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int id)
        {

            TicketViewModel ticket = ticketHelper.GetByID(id);
            // Obtener la lista de servicios para el desplegable

            List<ServiceViewModel> listaservicios = serviceHelper.GetServiceInfoFromAll("true");

            var combinedList = listaservicios.Select(s => new { CombinedValue = $"{s.Type}-{s.Priority}-{s.ServiceId}", s.NameType });

            ViewBag.ServiceInfoList = new SelectList(combinedList, "CombinedValue", "NameType");
           //            ViewBag.ServiceInfoList = new SelectList(listaservicios, "Type", "NameType", "Priority");
            // Cargar los comentarios asociados al ticket
            List<CommentViewModel> comentarios = ObtenerComentariosDelTicket(id);

            // Asignar los comentarios al modelo del ticket
            ticket.Comments = comentarios;

 


            AssignViewBag();
            return View(ticket);
        }

        //Metodo para tomar comentarios
        private List<CommentViewModel> ObtenerComentariosDelTicket(int ticketId)
        {
            // Usar la función definida en tu CommentHelper para obtener comentarios por ticketId
            return commentHelper.GetCommentsByTicketId(ticketId);
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TicketViewModel ticket)
        {
            try
            {             
                ticket.serviceId = ticket.serviceId.Split("-")[2];
                ticket.technicianId = 1;

                ticket = ticketHelper.Edit(ticket);

                //separar datos.

                
                AssignViewBag();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al editar el ticket: " + ex.Message);
                return View(ticket);
            }
        }

        // POST: TicketController/Deactivate/5
        [HttpPost]
       //[ValidateAntiForgeryToken]
        public ActionResult Deactivate(int id)
        {
            ticketHelper.Deactivation(id);         
            AssignViewBag();
            return RedirectToAction(nameof(Index));
        }


    }
}
