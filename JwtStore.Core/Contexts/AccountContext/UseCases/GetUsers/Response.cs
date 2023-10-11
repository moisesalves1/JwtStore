using Flunt.Notifications;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.GetUsers
{
    public class Response : SharedContext.UseCases.Response
    {
        protected Response()
        {
        }

        public Response(
            string message,
            int status,
            IEnumerable<Notification>? notifications = null)
        {
            Message = message;
            Status = status;
            Notifications = notifications;
        }

        public Response(string message, List<ResponseData> data)
        {
            Message = message;
            Status = 201;
            Notifications = null;
            Data = data;
        }

        public List<ResponseData> Data { get; set; }
    }

    public class ResponseData
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? VerifiedAt { get; set; } = null;
        public string Image { get; set; } = string.Empty;
        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}

