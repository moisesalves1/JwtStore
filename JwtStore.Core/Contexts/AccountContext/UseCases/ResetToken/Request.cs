using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ResetToken
{
    public class Request : IRequest<Response>
    {
        public string? JwtUserEmail { get; set; }
    }
}
