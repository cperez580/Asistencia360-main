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
    public class InventoryController: ControllerBase
    {
        private IInventoryDAL inventoryDAL;

        #region Constructors
        public InventoryController()
        {
            inventoryDAL = new InventoryDALImpl();
        }
        #endregion

        #region Parse
        InventoryModel Parse(Inventory inv)
        {
            return new InventoryModel
            {
                InventoryId = inv.InventoryId,
                Title = inv.Title,
                OperativeSystem = inv.OperativeSystem,
                Version = inv.Version,
                Type = inv.Type,
                Purpose = inv.Purpose,
                IpAddress = inv.IpAddress,
                AssetNumber = inv.AssetNumber,
                SerialNumber = inv.SerialNumber,
                Cpu = inv.Cpu,
                CpuCore = inv.CpuCore,
                Ram = inv.Ram,
                Active = inv.Active,
            };
        }

        Inventory Parse(InventoryModel inv)
        {
            return new Inventory
            {
                InventoryId = inv.InventoryId,
                Title = inv.Title,
                OperativeSystem = inv.OperativeSystem,
                Version = inv.Version,
                Type = inv.Type,
                Purpose = inv.Purpose,
                IpAddress = inv.IpAddress,
                AssetNumber = inv.AssetNumber,
                SerialNumber = inv.SerialNumber,
                Cpu = inv.Cpu,
                CpuCore = inv.CpuCore,
                Ram = inv.Ram,
                Active = inv.Active,
            };
        }
        #endregion

        // GET: api/<]InventoryController>
        [HttpGet]
        public async Task<JsonResult> Get(string active)
        {
            IEnumerable<Inventory> inventories = new List<Inventory>();
            if(active == "full")
                inventories = await inventoryDAL.GetAll();
            else
                inventories = inventoryDAL.Find(m => m.Active == Convert.ToBoolean(active));

            List<InventoryModel> invModel = new List<InventoryModel>();
            foreach (Inventory inventory in inventories)
            {
                invModel.Add(Parse(inventory));
            }
            return new JsonResult(invModel);
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Inventory inventory = await inventoryDAL.Get(id);
            return new JsonResult(inventory);
        }

        // POST api/<InventoryController>
        [HttpPost]
        public JsonResult Post([FromBody] InventoryModel inventory)
        {
            inventoryDAL.Add(Parse(inventory));
            return new JsonResult(inventory);
        }

        // PUT api/<InventoryController>/5
        [HttpPut]
        public JsonResult Put(int id, [FromBody] InventoryModel inventory)
        {
            inventoryDAL.Update(Parse(inventory));
            return new JsonResult(inventory);
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Deactivation(int id)
        {
            Inventory inventory = await inventoryDAL.Get(id);
            if (inventory.Active) inventory.Active = false;
            else inventory.Active = true;
            inventoryDAL.Update(inventory);
            return new JsonResult(inventory);
        }
    }
}
