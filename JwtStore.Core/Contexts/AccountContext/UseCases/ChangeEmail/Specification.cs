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
                .IsEmail(request.ActualEmail, "ActualEmail", "E=mail atual inválido")
                .AreEquals(request.ActualEmail, request.JwtUserEmail, "Não autorizado", "Não é possível alterar o e-mail de outro usuário");
    }
}
