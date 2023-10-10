using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ResendVerificationCode
{

    public class Request : IRequest<Response>
    {
        public string Email { get; init; }
    }
}
