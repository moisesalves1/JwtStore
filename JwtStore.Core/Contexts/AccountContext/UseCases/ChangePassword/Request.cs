using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangePassword
{
    public record Request(
        string ActualPassword,
        string NewPassword,
        string Email
        ) : IRequest<Response>;
}
