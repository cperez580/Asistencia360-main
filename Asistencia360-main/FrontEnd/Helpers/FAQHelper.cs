using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class FAQHelper
    {
        ServiceRepository repository;

        public FAQHelper()
        {
            repository = new ServiceRepository();
        }

        public List<FAQViewModel> GetAll(string active)
        {

            List<FAQViewModel> list = new List<FAQViewModel>();
            HttpResponseMessage response = repository.GetResponse("api/Faq?active=" + active);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<FAQViewModel>>(content);
            }

            return list;
        }

        public FAQViewModel GetByID(int id)
        {
            FAQViewModel faq = new FAQViewModel();
            HttpResponseMessage response = repository.GetResponse("api/Faq/" + id);
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                faq = JsonConvert.DeserializeObject<FAQViewModel>(content);
            }
            return faq;
        }

        public FAQViewModel Edit(FAQViewModel faq)
        {
            FAQViewModel faqAPI = new FAQViewModel();
            HttpResponseMessage response = repository.PutResponse("api/Faq/", faq);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                faqAPI = JsonConvert.DeserializeObject<FAQViewModel>(content);
            }
            return faqAPI;
        }

        public FAQViewModel Add(FAQViewModel faq)
        {

            FAQViewModel faqAPI = new FAQViewModel();
            HttpResponseMessage response = repository.PostResponse("api/Faq/", faq);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                faqAPI = JsonConvert.DeserializeObject<FAQViewModel>(content);
            }
            return faqAPI;
        }

        public FAQViewModel Deactivation(int id)
        {
            FAQViewModel faq = new FAQViewModel();
            HttpResponseMessage response = repository.PutResponse("api/FAQ/" + id, null);
            return faq;
        }
    }
}
