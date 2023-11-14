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
    public class CommentController: ControllerBase
    {
        private ICommentDAL commentDAL;

        #region Constructors
        public CommentController()
        {
            commentDAL = new CommentDALImpl();
        }
        #endregion

        #region Parse
        CommentModel Parse(Comment comment)
        {
            return new CommentModel
            {
                CommentId = comment.CommentId,
                TicketId = comment.TicketId,
                UserId = comment.UserId,
                Message = comment.Message,
                CreationDate = comment.CreationDate,
                Attachment = comment.Attachment
                
            };
        }

        Comment Parse(CommentModel comment)
        {
            return new Comment
            {
                CommentId = comment.CommentId,
                TicketId = comment.TicketId,
                UserId = comment.UserId,
                Message = comment.Message,
                CreationDate = comment.CreationDate,
                Attachment = comment.Attachment
            };
        }
        #endregion

        // GET: api/<]CommentController>
        [HttpGet]
        public async Task<JsonResult> Get(string active)
        {           
            IEnumerable<Comment> comments = new List<Comment>();
            if (active == "full")
                comments = await commentDAL.GetAll();
            else
                comments = commentDAL.Find(m => m.Message == "null");

            List<CommentModel> commentModel = new List<CommentModel>();
            foreach (Comment comment in comments)
            {
                commentModel.Add(Parse(comment));
            }
            return new JsonResult(commentModel);
        }

        // GET api/<CommentServiceController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Comment comment = await commentDAL.Get(id);
            return new JsonResult(comment);
        }

        // POST api/<CommentServiceController>
        [HttpPost]
        public JsonResult Post([FromBody] CommentModel comment)
        {
            commentDAL.Add(Parse(comment));
            return new JsonResult(comment);
        }

        // PUT api/<InternalServiceController>/5
        [HttpPut]
        public JsonResult Put(int id, [FromBody] CommentModel comment)
        {
            commentDAL.Update(Parse(comment));
            return new JsonResult(comment);
        }

    }
}
