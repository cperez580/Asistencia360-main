using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers
{
    public class CommentHelper
    {
        CommentRepository repository;

        public CommentHelper()
        {
            repository = new CommentRepository();
        }

        public List<CommentViewModel> GetAll(string active)
        {
            List<CommentViewModel> list = new List<CommentViewModel>();
            HttpResponseMessage response = repository.GetResponse("api/Comment?active=" + active);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<CommentViewModel>>(content);
            }
            return list;
        }

        public CommentViewModel GetByID(int id)
        {
            CommentViewModel comment = new CommentViewModel();
            HttpResponseMessage response = repository.GetResponse("api/InternalService/" + id);
            if (response != null)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                comment = JsonConvert.DeserializeObject<CommentViewModel>(content);
            }
            return comment;
        }

        public CommentViewModel Edit(CommentViewModel comment)
        {
            CommentViewModel commentAPI = new CommentViewModel();
            HttpResponseMessage response = repository.PutResponse("api/Comment/", comment);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                commentAPI = JsonConvert.DeserializeObject<CommentViewModel>(content);
            }
            return commentAPI;
        }

        public CommentViewModel Add(CommentViewModel comment)
        {
            CommentViewModel commentAPI = new CommentViewModel();
            HttpResponseMessage response = repository.PostResponse("api/Comment/", comment);
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                commentAPI = JsonConvert.DeserializeObject<CommentViewModel>(content);
            }
            return commentAPI;
        }

        public List<CommentViewModel> GetCommentsByTicketId(int ticketId)
        {
            List<CommentViewModel> comments = GetAll("full");  // Obtener todos los comentarios (puedes ajustar según tu lógica)

            // Filtrar los comentarios por ticketId
            List<CommentViewModel> commentsForTicket = comments.Where(c => c.ticketId == ticketId).ToList();

            return commentsForTicket;
        }

    }
}