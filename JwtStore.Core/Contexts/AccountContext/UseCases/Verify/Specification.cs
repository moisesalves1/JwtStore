using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Verify
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
            => new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(request.VerificationCode, "VerificationCode", "O código de verificação não pode ser vazio")
                .IsEmail(request.Email, "Email", "E-mail inválido");
    }
}
