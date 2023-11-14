using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class HardDriveHelper
    {
        ServiceRepository repository;

        public HardDriveHelper()
        {
            repository = new ServiceRepository();
        }

        public List<HardDriveViewModel> GetAll()
        {

            List<HardDriveViewModel> list = new List<HardDriveViewModel>();
            HttpResponseMessage response = repository.GetResponse("api/HardDrive");
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<HardDriveViewModel>>(content);
            }

            return list;
        }

        public HardDriveViewModel GetByID(int id)
        {
            HardDriveViewModel hardDrive = new HardDriveViewModel();
            HttpResponseMessage response = repository.GetResponse("api/HardDrive/" + id);
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                hardDrive = JsonConvert.DeserializeObject<HardDriveViewModel>(content);
            }
            return hardDrive;
        }

        public HardDriveViewModel Edit(HardDriveViewModel hardDrive)
        {
            HardDriveViewModel hardDriveAPI = new HardDriveViewModel();
            HttpResponseMessage response = repository.PutResponse("api/HardDrive/", hardDrive);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                hardDriveAPI = JsonConvert.DeserializeObject<HardDriveViewModel>(content);
            }
            return hardDriveAPI;
        }

        public HardDriveViewModel Add(HardDriveViewModel hardDrive)
        {

            HardDriveViewModel hardDriveAPI = new HardDriveViewModel();
            HttpResponseMessage response = repository.PostResponse("api/HardDrive/", hardDrive);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                hardDriveAPI = JsonConvert.DeserializeObject<HardDriveViewModel>(content);
            }
            return hardDriveAPI;
        }
    }
}
