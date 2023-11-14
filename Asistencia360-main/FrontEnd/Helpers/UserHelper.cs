using FrontEnd.Models;
using FrontEnd.Models.UserModels;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class UserHelper
    {
        ServiceRepository repository;

        public UserHelper()
        {
            repository = new ServiceRepository();
        }

        public List<UserViewModel> GetAll(string active)
        {
            List<UserViewModel> list = new List<UserViewModel>();

            HttpResponseMessage response = repository.GetResponse("api/User?active=" + active);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<UserViewModel>>(content);
            }   

            return list;
        }

        public UserViewModel GetByID(int id)
        {
            UserViewModel user = new UserViewModel();

            HttpResponseMessage response = repository.GetResponse("api/User/" + id);

            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserViewModel>(content);
            }

            return user;
        }

        public UserViewModel Edit(UserViewModel user)
        {
            UserViewModel userAPI = new UserViewModel();

            HttpResponseMessage response = repository.PutResponse("api/User/", user);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                userAPI = JsonConvert.DeserializeObject<UserViewModel>(content);
            }

            return userAPI;
        }

        public UserViewModel Add(UserViewModel user)
        {
            UserViewModel userAPI = new UserViewModel();

            HttpResponseMessage response = repository.PostResponse("api/User/", user);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                userAPI = JsonConvert.DeserializeObject<UserViewModel>(content);
            }

            return userAPI;
        }

        public UserViewModel Delete(int id)
        {
            UserViewModel user = new UserViewModel();

            //HttpResponseMessage response = repository.DeleteResponse("api/User/" + id);

            return user;
        }
    }
}