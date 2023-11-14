using System.Net.Http;

namespace FrontEnd.Helpers
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }

        public ServiceRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7254");
            //Client.DefaultRequestHeaders.Add("api_key", "1a5ed2d0-a3a5-4ad6-a23c-6a5fcaa080bb");

        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        //public HttpResponseMessage PutResponse(string url)
        //{
        //    return Client.PutAsync(url).Result;
        //}
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        
    }
}
