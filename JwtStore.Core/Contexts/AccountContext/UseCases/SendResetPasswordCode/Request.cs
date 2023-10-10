using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.SendResetPasswordCode
{

    public class Request : IRequest<Response>
    {
        public string Email { get; init; }
    }
}
