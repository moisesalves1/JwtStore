using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Details
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
            => new Contract<Notification>()
                .Requires()
                .IsEmail(request.Email, "Email", "E-mail inválido")
                .AreEquals(request.Email, request.JwtUserEmail, "Não autorizado", "Não é possível visualizar detalhes de outro usuário");
    }
}
