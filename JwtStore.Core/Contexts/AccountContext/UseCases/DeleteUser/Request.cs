using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.DeleteUser
{
    public class Request : IRequest<Response>
    {
        public string Id { get; set; }
    }
}
