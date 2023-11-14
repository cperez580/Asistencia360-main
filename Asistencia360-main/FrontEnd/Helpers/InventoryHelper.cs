using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class InventoryHelper
    {
        ServiceRepository repository;

        public InventoryHelper()
        {
            repository = new ServiceRepository();
        }

        public List<InventoryViewModel> GetAll(string active)
        {

            List<InventoryViewModel> list = new List<InventoryViewModel>();
            HttpResponseMessage response = repository.GetResponse("api/Inventory?active=" + active);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<InventoryViewModel>>(content);
            }

            return list;
        }

        public InventoryViewModel GetByID(int id)
        {
            InventoryViewModel inventory = new InventoryViewModel();
            HttpResponseMessage response = repository.GetResponse("api/Inventory/" + id);
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                inventory = JsonConvert.DeserializeObject<InventoryViewModel>(content);
            }
            return inventory;
        }

        public InventoryViewModel Edit(InventoryViewModel inventory)
        {
            InventoryViewModel inventoryAPI = new InventoryViewModel();
            HttpResponseMessage response = repository.PutResponse("api/Inventory/", inventory);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                inventoryAPI = JsonConvert.DeserializeObject<InventoryViewModel>(content);
            }
            return inventoryAPI;
        }

        public InventoryViewModel Add(InventoryViewModel inventory)
        {

            InventoryViewModel inventoryAPI = new InventoryViewModel();
            HttpResponseMessage response = repository.PostResponse("api/Inventory/", inventory);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                inventoryAPI = JsonConvert.DeserializeObject<InventoryViewModel>(content);
            }
            return inventoryAPI;
        }

        public InventoryViewModel Deactivation(int id)
        {
            InventoryViewModel inventory = new InventoryViewModel();
            HttpResponseMessage response = repository.PutResponse("api/Inventory/" + id, null);
            return inventory;
        }
    }
}
