using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangeName
{
    public record Request(
        string Name,
        string Email,
        string JwtUserEmail
        ) : IRequest<Response>;
}
