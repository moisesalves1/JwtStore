using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ResetPassword
{

    public class Request : IRequest<Response>
    {
        public string Email { get; init; }
        public string ResetPasswordCode { get; init; }
        public string NewPassword { get; init; }
    }
}
