using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.ResetPassword
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
            => new Contract<Notification>()
                .Requires()
                .IsLowerThan(request.NewPassword.Length, 40, "NewPassword", "A senha deve conter menos que 40 caracteres")
                .IsGreaterThan(request.NewPassword.Length, 8, "NewPassword", "A senha deve conter mais que 8 caracteres")
                .IsEmail(request.Email, "Email", "E-mail inválido");
    }
}
