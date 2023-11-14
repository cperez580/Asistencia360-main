using FrontEnd.Helpers;
using FrontEnd.Models;
using FrontEnd.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace FrontEnd.Controllers
{
    public class CommentController : Controller
    {
        private CommentHelper commentHelper;


        public CommentController()
        {
            commentHelper = new CommentHelper();
        }

        public void AssignViewBag()
        {

        }

  
        // GET: CommentController/Create
        public ActionResult Create()
        {
            AssignViewBag();
            return View();
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel comment, int ticketId)
        {
            try
            {

                ModelState.Remove("Users");
                ModelState.Remove("Tickets");
                ModelState.Remove("message");
                ModelState.Remove("attachment");
                ModelState.Remove("creationDate");


                if (ModelState.IsValid)
                {

                    //ticket.StartDate = DateTime.Now;
                    comment.userId = 1;
                    comment.creationDate = DateTime.Now;
                    comment.ticketId = ticketId;
                    //comment.ticketId = 1;
                    comment = commentHelper.Add(comment);

                    AssignViewBag();
                    int ticket = comment.ticketId; // Ajusta esto según tu modelo
                    return RedirectToAction("Edit", "Ticket", new { id = ticket });
                }
                return View(comment);
            }
            catch
            {
                return View();
            }
        }


    }
}
