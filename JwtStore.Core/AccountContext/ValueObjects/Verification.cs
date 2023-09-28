using JwtStore.Core.AccountContext.ValueObjects.Exceptions;
using JwtStore.Core.SharedContext.ValueObjects;

namespace JwtStore.Core.AccountContext.ValueObjects
{
    public class Verification : ValueObject
    {
        public Verification() { }
        public string Code { get; } = Guid.NewGuid().ToString("N")[..6].ToUpper();
        public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
        public DateTime? VerifiedAt { get; private set; } = null;
        public bool IsActive => VerifiedAt != null && ExpiresAt == null;

        public void Verify(string code)
        {
            InvalidVerificationException.ThrowIfInvalid(code, Code, ExpiresAt, IsActive);

            ExpiresAt = null;
            VerifiedAt = DateTime.UtcNow;
        }

    }
}
