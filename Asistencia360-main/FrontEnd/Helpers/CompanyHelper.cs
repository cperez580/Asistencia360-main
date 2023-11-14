using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers
{
    public class CompanyHelper
    {
        ServiceRepository repository;

        public CompanyHelper()
        {
            repository = new ServiceRepository();
        }

        public List<CompanyViewModel> GetAll(string active)
        {
            List<CompanyViewModel> list = new List<CompanyViewModel>();
            HttpResponseMessage response = repository.GetResponse("api/Company?active=" + active);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<CompanyViewModel>>(content);
            }
            return list;
        }

        public CompanyViewModel GetByID(int id)
        {
            CompanyViewModel company = new CompanyViewModel();
            HttpResponseMessage response = repository.GetResponse("api/Company/" + id);
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                company = JsonConvert.DeserializeObject<CompanyViewModel>(content);
            }
            return company;
        }

        public CompanyViewModel Edit(CompanyViewModel company)
        {
            CompanyViewModel companyAPI = new CompanyViewModel();
            HttpResponseMessage response = repository.PutResponse("api/Company/", company);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                companyAPI = JsonConvert.DeserializeObject<CompanyViewModel>(content);
            }
            return companyAPI;
        }

        public CompanyViewModel Add(CompanyViewModel company)
        {
            CompanyViewModel companyAPI = new CompanyViewModel();
            HttpResponseMessage response = repository.PostResponse("api/Company/", company);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                companyAPI = JsonConvert.DeserializeObject<CompanyViewModel>(content);
            }
            return companyAPI;
        }

        public CompanyViewModel Deactivation(int id)
        {
            CompanyViewModel company = new CompanyViewModel();
            HttpResponseMessage response = repository.PutResponse("api/Company/" + id, null);
            return company;
        }
    }
}