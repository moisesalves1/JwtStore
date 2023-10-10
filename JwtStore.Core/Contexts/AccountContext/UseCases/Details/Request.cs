using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Details
{
    public class Request : IRequest<Response>
    {
        public string Email { get; init; }
        public string JwtUserEmail { get; set; }
    }
}
