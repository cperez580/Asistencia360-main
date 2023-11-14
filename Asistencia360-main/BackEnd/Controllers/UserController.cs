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
    public class UserController : ControllerBase
    {
        private IUserDAL userDAL;

        #region Constructors

        public UserController()
        {
            userDAL = new UserDALImpl();
        }

        #endregion

        #region Parse

        UserModel Parse(User entity)
        {
            return new UserModel
            {
                UserId = entity.UserId,
                Name = entity.Name,
                LastName = entity.LastName,
                IdNumber = entity.IdNumber,
                Email = entity.Email,
                Password = entity.Password,
                DepartmentId = entity.DepartmentId,
                RoleId = entity.RoleId,
                Active = entity.Active
            };
        }

        User Parse(UserModel entity)
        {
            return new User
            {
                UserId = entity.UserId,
                Name = entity.Name,
                LastName = entity.LastName,
                IdNumber = entity.IdNumber,
                Email = entity.Email,
                Password = entity.Password,
                DepartmentId = entity.DepartmentId,
                RoleId = entity.RoleId,
                Active = entity.Active
            };
        }
        #endregion

        // GET: api/<UserController>
        [HttpGet]
        public async Task<JsonResult> Get(string active)
        {
            IEnumerable<User> users = new List<User>();

            if (active == "full")
                users = await userDAL.GetAll();
            else
                users = userDAL.Find(m => m.Active == Convert.ToBoolean(active));

            List<UserModel> userModel = new List<UserModel>();

            foreach (User user in users)
            {
                userModel.Add(Parse(user));
            }

            return new JsonResult(userModel);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            User user = await userDAL.Get(id);

            return new JsonResult(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public JsonResult Post([FromBody] UserModel user)
        {
            userDAL.Add(Parse(user));

            return new JsonResult(user);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public JsonResult Put([FromBody] UserModel user)
        {
            userDAL.Update(Parse(user));

            return new JsonResult(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = new User
            {
                UserId = id
            };

            userDAL.Remove(user);
        }
    }
}