using Flunt.Notifications;
using Flunt.Validations;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.DeleteUser
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
            => new Contract<Notification>()
                .Requires()
                .AreEquals(request.Id.Length, 36, "Id", "O Id deve conter 36 caracteres");
    }
}
