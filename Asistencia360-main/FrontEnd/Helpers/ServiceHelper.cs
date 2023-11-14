using FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace FrontEnd.Helpers
{
    public class ServiceHelper
    {
        ServiceRepository repository;

        public ServiceHelper()
        {
            repository = new ServiceRepository();
        }

        public List<ServiceViewModel> GetAll(string active)
        {
            List<ServiceViewModel> list = new List<ServiceViewModel>();

            HttpResponseMessage response = repository.GetResponse("api/Service?active=" + active);

            if (response != null) 
            {
                var content = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<ServiceViewModel>>(content);
            }

            return list;
        }

        public ServiceViewModel GetByID(int id)
        {
            ServiceViewModel service = new ServiceViewModel();

            HttpResponseMessage response = repository.GetResponse("api/Service/" + id);

            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                service = JsonConvert.DeserializeObject<ServiceViewModel>(content);
            }

            return service;
        }

        public ServiceViewModel Edit(ServiceViewModel service)
        {
            ServiceViewModel serviceAPI = new ServiceViewModel();

            HttpResponseMessage response = repository.PutResponse("api/Service/", service);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                serviceAPI = JsonConvert.DeserializeObject<ServiceViewModel>(content);
            }

            return serviceAPI;
        }

        public ServiceViewModel Add(ServiceViewModel service)
        {
            ServiceViewModel serviceAPI = new ServiceViewModel();

            HttpResponseMessage response = repository.PostResponse("api/Service/", service);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                serviceAPI = JsonConvert.DeserializeObject<ServiceViewModel> (content);
            }

            return serviceAPI;
        }

        public ServiceViewModel Deactivation(int id)
        {
            ServiceViewModel service = new ServiceViewModel();
            HttpResponseMessage response = repository.PutResponse("api/Company/" + id, null);
            return service;
        }

        ///Agregado para tiquetes
        public List<ServiceViewModel> GetServiceInfoFromAll(string active)
        {
            List<ServiceViewModel> serviceInfoList = new List<ServiceViewModel>();

            HttpResponseMessage response = repository.GetResponse("api/Service?active=" + active);

            if (response != null && response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                serviceInfoList = JsonConvert.DeserializeObject<List<ServiceViewModel>>(content);

                // Modificar aquí si es necesario ajustar las propiedades en serviceInfoList
            }

            return serviceInfoList;
        }



    }
}
