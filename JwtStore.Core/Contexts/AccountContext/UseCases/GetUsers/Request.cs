using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.GetUsers
{
    public class Request : IRequest<Response>
    {
        public string JwtUserEmail { get; set; }
    }
}
