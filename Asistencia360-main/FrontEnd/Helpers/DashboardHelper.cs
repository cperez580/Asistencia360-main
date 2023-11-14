using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers
{
    public class DashboardHelper
    {
        ServiceRepository repository;

        public DashboardHelper()
        {
            repository = new ServiceRepository();
        }

        public JsonResult GetData(string start, string end)
        {
            HttpResponseMessage response = repository.GetResponse("api/Dashboard?start=" + start + "&end=" + end);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return new JsonResult(content);
            }
            else
            {
                return new JsonResult(new { error = "Failed to retrieve data" }) { StatusCode = (int)response.StatusCode };
            }
        }
    }
}