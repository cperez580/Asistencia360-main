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
    public class DepartmentController: ControllerBase
    {
        private IDepartmentDAL departmentDAL;

        #region Constructors
        public DepartmentController()
        {
            departmentDAL = new DepartmentDALImpl();
        }
        #endregion

        #region Parse
        DepartmentModel Parse(Department depart)
        {
            return new DepartmentModel
            {
                DepartmentId = depart.DepartmentId,
                CompanyId = depart.CompanyId,
                Title = depart.Title,
                Description = depart.Description,
                Active = depart.Active,
            };
        }

        Department Parse(DepartmentModel depart)
        {
            return new Department
            {
                DepartmentId = depart.DepartmentId,
                CompanyId = depart.CompanyId,
                Title = depart.Title,
                Description = depart.Description,
                Active = depart.Active,
            };
        }
        #endregion

        // GET: api/<]DepartmentController>
        [HttpGet]
        public async Task<JsonResult> Get(string active)
        {
            IEnumerable<Department> departments = new List<Department>();
            if(active == "full")
                departments = await departmentDAL.GetAll();
            else
                departments = departmentDAL.Find(m => m.Active == Convert.ToBoolean(active));

            List<DepartmentModel> departModel = new List<DepartmentModel>();
            foreach (Department department in departments)
            {
                departModel.Add(Parse(department));
            }
            return new JsonResult(departModel);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Department department = await departmentDAL.Get(id);
            return new JsonResult(department);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public JsonResult Post([FromBody] DepartmentModel department)
        {
            departmentDAL.Add(Parse(department));
            return new JsonResult(department);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        public JsonResult Put(int id, [FromBody] DepartmentModel department)
        {
            departmentDAL.Update(Parse(department));
            return new JsonResult(department);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Deactivation(int id)
        {
            Department department = await departmentDAL.Get(id);
            if (department.Active) department.Active = false;
            else department.Active = true;
            departmentDAL.Update(department);
            return new JsonResult(department);
        }
    }
}
