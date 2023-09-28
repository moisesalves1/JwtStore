using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JwtStore.Core.AccountContext.ValueObjects.Exceptions
{
    public class InvalidVerificationException : Exception
    {
        private const string DefaultErrorMessage = "Código de verificação inválido";
        public InvalidVerificationException(string message = DefaultErrorMessage) 
            : base(message) 
        {
            
        }

        public static void ThrowIfInvalid(string code, string Code, DateTime? ExpiresAt, bool IsActive, string message = DefaultErrorMessage)
        {
            if (IsActive)
                throw new InvalidVerificationException("Este item já foi ativado");
            if (ExpiresAt < DateTime.UtcNow)
                throw new InvalidVerificationException("Este código já expirou");
            if (!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
                throw new InvalidVerificationException();
        }

    }
}
