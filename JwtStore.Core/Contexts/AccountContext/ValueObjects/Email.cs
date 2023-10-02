using System.Text.RegularExpressions;
using JwtStore.Core.AccountContext.ValueObjects.Exceptions;
using JwtStore.Core.Contexts.SharedContext.Extensions;
using JwtStore.Core.Contexts.SharedContext.ValueObjects;

namespace JwtStore.Core.AccountContext.ValueObjects
{
    public partial class Email : ValueObject
    {
        protected Email() { }
        public Email(string address)
        {
            InvalidEmailException.ThrowIfNull(address);

            Address = address.Trim().ToLower();

            InvalidEmailException.ThrowIfInvalid(address);

        }

        public void ResendVerification()
            => Verification = new Verification();

        #region Parameters
        public string Address { get; }
        public string Hash => Address.ToBase64();

        public Verification Verification { get; private set; } = new();

        #endregion

        #region Operators

        public static implicit operator string(Email email)
            => email.ToString();

        public static implicit operator Email(string address)
            => new Email(address);

        public override string ToString()
            => Address;
        #endregion


    }
}
