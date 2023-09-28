using JwtStore.Core.SharedContext.ValueObjects;
using JwtStore.Core.SharedContext.Extensions;

namespace JwtStore.Core.AccountContext.ValueObjects
{
    public class Email : ValueObject
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public string Address { get; }
        public string Hash => Address.ToBase64()
    }
}
