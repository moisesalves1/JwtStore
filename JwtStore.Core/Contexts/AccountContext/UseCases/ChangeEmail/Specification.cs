using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangeEmail
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
            => new Contract<Notification>()
                .Requires()
                .IsEmail(request.NewEmail, "NewEmail", "Novo e-mail inválido")
                .IsEmail(request.JwtUserEmail, "ActualEmail", "E-mail atual inválido")
                .AreNotEquals(request.NewEmail, request.JwtUserEmail, "E-mails iguais", "O novo e-mail deve ser diferente do atual");
    }
}
