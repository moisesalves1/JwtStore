using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ChangePassword
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
            => new Contract<Notification>()
                .Requires()
                .IsLowerThan(request.ActualPassword.Length, 40, "Senha atual", "A senha atual deve conter menos que 40 caracteres")
                .IsGreaterThan(request.ActualPassword.Length, 8, "Senha atual", "A senha atual conter mais que 8 caracteres")
                .IsLowerThan(request.NewPassword.Length, 40, "Nova Senha", "A nova senha deve conter menos que 40 caracteres")
                .IsGreaterThan(request.NewPassword.Length, 8, "Nova Senha", "A nova senha deve conter mais que 8 caracteres")
                .AreNotEquals(request.NewPassword, request.ActualPassword, "Senhas iguais", "A nova senha deve ser diferente da atual")
                .IsEmail(request.JwtUserEmail, "Email", "E-mail inválido");
    }
}
