using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Verify
{
    public record Request(
    string Email,
    string VerificationCode
    ) : IRequest<Response>;
}
