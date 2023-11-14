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
    public class HardDriveController: ControllerBase
    {
        private IHardDriveDAL harddriveDAL;

        #region Constructors
        public HardDriveController()
        {
            harddriveDAL = new HardDriveDALImpl();
        }
        #endregion

        #region Parse
        HardDriveModel Parse(HardDrive hd)
        {
            return new HardDriveModel
            {
                HardDriveId = hd.HardDriveId,
                InventoryId = hd.InventoryId,
                Title = hd.Title,
                Size = hd.Size,
            };
        }

        HardDrive Parse(HardDriveModel hd)
        {
            return new HardDrive
            {
                HardDriveId = hd.HardDriveId,
                InventoryId = hd.InventoryId,
                Title = hd.Title,
                Size = hd.Size,
            };
        }
        #endregion

        // GET: api/<]HardDriveController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            IEnumerable<HardDrive> hardDrives = await harddriveDAL.GetAll();
            List<HardDriveModel> hdModel = new List<HardDriveModel>();
            foreach (HardDrive hardDrive in hardDrives)
            {
                hdModel.Add(Parse(hardDrive));
            }
            return new JsonResult(hdModel);
        }

        // GET api/<HardDriveController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            HardDrive hardDrive = await harddriveDAL.Get(id);
            return new JsonResult(hardDrive);
        }

        // POST api/<HardDriveController>
        [HttpPost]
        public JsonResult Post([FromBody] HardDriveModel hardDrive)
        {
            harddriveDAL.Add(Parse(hardDrive));
            return new JsonResult(hardDrive);
        }

        // PUT api/<HardDriveController>/5
        [HttpPut]
        public JsonResult Put(int id, [FromBody] HardDriveModel hardDrive)
        {
            harddriveDAL.Update(Parse(hardDrive));
            return new JsonResult(hardDrive);
        }
    }
}
