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
                .IsEmail(request.ActualEmail, "ActualEmail", "E=mail atual inválido");
    }
}
