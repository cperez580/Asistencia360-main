using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers
{
    public class InternalServiceHelper
    {
        ServiceRepository repository;

        public InternalServiceHelper()
        {
            repository = new ServiceRepository();
        }

        public List<InternalServiceViewModel> GetAll(string active)
        {
            List<InternalServiceViewModel> list = new List<InternalServiceViewModel>();
            HttpResponseMessage response = repository.GetResponse("api/InternalService?active=" + active);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<InternalServiceViewModel>>(content);
            }
            return list;
        }

        public InternalServiceViewModel GetByID(int id)
        {
            InternalServiceViewModel internalservice = new InternalServiceViewModel();
            HttpResponseMessage response = repository.GetResponse("api/InternalService/" + id);
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                internalservice = JsonConvert.DeserializeObject<InternalServiceViewModel>(content);
            }
            return internalservice;
        }

        public InternalServiceViewModel Edit(InternalServiceViewModel internalservice)
        {
            InternalServiceViewModel internalserviceAPI = new InternalServiceViewModel();
            HttpResponseMessage response = repository.PutResponse("api/InternalService/", internalservice);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                internalserviceAPI = JsonConvert.DeserializeObject<InternalServiceViewModel>(content);
            }
            return internalserviceAPI;
        }

        public InternalServiceViewModel Add(InternalServiceViewModel internalservice)
        {
            InternalServiceViewModel internalserviceAPI = new InternalServiceViewModel();
            HttpResponseMessage response = repository.PostResponse("api/InternalService/", internalservice);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                internalserviceAPI = JsonConvert.DeserializeObject<InternalServiceViewModel>(content);
            }
            return internalserviceAPI;
        }

        public InternalServiceViewModel Deactivation(int id)
        {
            InternalServiceViewModel company = new InternalServiceViewModel();
            HttpResponseMessage response = repository.PutResponse("api/InternalService/" + id, null);
            return company;
        }
    }
}