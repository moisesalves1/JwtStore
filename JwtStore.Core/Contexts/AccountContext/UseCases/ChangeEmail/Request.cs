using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangeEmail
{
    public record Request(
        string ActualEmail,
        string NewEmail
        ) : IRequest<Response>;
}
