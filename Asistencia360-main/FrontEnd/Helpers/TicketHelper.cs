using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TicketHelper
    {
        TicketRepository repository;

        public TicketHelper()
        {
            repository = new TicketRepository();
        }

        public List<TicketViewModel> GetAll(string active)
        {
            List<TicketViewModel> list = new List<TicketViewModel>();
            

            HttpResponseMessage response = repository.GetResponse("api/Ticket?active=" + active);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<TicketViewModel>>(content);
            }

            return list;
        }

        public TicketViewModel GetByID(int id)
        {
            TicketViewModel ticket = new TicketViewModel();

            HttpResponseMessage response = repository.GetResponse("api/Ticket/" + id);

            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                ticket = JsonConvert.DeserializeObject<TicketViewModel>(content);
            }

            return ticket;
        }

        public TicketViewModel Edit(TicketViewModel ticket)
        {
            TicketViewModel ticketAPI = new TicketViewModel();

            HttpResponseMessage response = repository.PutResponse("api/Ticket/", ticket);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                ticketAPI = JsonConvert.DeserializeObject<TicketViewModel>(content);
            }

            return ticketAPI;
        }

        public TicketViewModel Add(TicketViewModel ticket)
        {
            TicketViewModel ticketAPI = new TicketViewModel();

            HttpResponseMessage response = repository.PostResponse("api/Ticket/", ticket);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                ticketAPI = JsonConvert.DeserializeObject<TicketViewModel>(content);
            }

            return ticketAPI;
        }

        public TicketViewModel Deactivation(int id)
        {
            TicketViewModel ticket = new TicketViewModel();
            HttpResponseMessage response = repository.PutResponse("api/Ticket/" + id, null);
            return ticket;
        }
    }
}
