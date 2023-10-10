using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangePassword
{
    public class Request : IRequest<Response>
    {
        public string ActualPassword { get; init; }
        public string NewPassword { get; init; }
        public string JwtUserEmail { get; set; }
    }
}
