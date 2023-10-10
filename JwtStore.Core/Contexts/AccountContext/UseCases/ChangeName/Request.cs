using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangeName
{
   
    public class Request : IRequest<Response>
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string JwtUserEmail { get; set; }
    }
}
