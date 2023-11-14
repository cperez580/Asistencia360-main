using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class DepartmentHelper
    {
        ServiceRepository repository;

        public DepartmentHelper()
        {
            repository = new ServiceRepository();
        }

        public List<DepartmentViewModel> GetAll(string active)
        {

            List<DepartmentViewModel> list = new List<DepartmentViewModel>();
            HttpResponseMessage response = repository.GetResponse("api/Department?active=" + active);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(content);
            }

            return list;
        }

        public DepartmentViewModel GetByID(int id)
        {
            DepartmentViewModel department = new DepartmentViewModel();
            HttpResponseMessage response = repository.GetResponse("api/Department/" + id);
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                department = JsonConvert.DeserializeObject<DepartmentViewModel>(content);
            }
            return department;
        }

        public DepartmentViewModel Edit(DepartmentViewModel department)
        {
            DepartmentViewModel departmentAPI = new DepartmentViewModel();
            HttpResponseMessage response = repository.PutResponse("api/Department/", department);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                departmentAPI = JsonConvert.DeserializeObject<DepartmentViewModel>(content);
            }
            return departmentAPI;
        }

        public DepartmentViewModel Add(DepartmentViewModel department)
        {

            DepartmentViewModel departmentAPI = new DepartmentViewModel();
            HttpResponseMessage response = repository.PostResponse("api/Department/", department);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                departmentAPI = JsonConvert.DeserializeObject<DepartmentViewModel>(content);
            }
            return departmentAPI;
        }

        public DepartmentViewModel Deactivation(int id)
        {
            DepartmentViewModel department = new DepartmentViewModel();
            HttpResponseMessage response = repository.PutResponse("api/Department/" + id, null);
            return department;
        }
    }
}
