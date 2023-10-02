using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JwtStore.Core.AccountContext.ValueObjects.Exceptions
{
    public partial class InvalidEmailException : Exception
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        private const string DefaultErrorMessage = "E-mail inválido";
        public InvalidEmailException(string message = DefaultErrorMessage) 
            : base(message) 
        {
            
        }

        public static void ThrowIfInvalid(string address, string message = DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(address))
                throw new InvalidEmailException(message);
            if (!EmailRegex().IsMatch(address))
                throw new InvalidEmailException();
        }

        public static void ThrowIfNull(string? item, string message = DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(item))
                throw new InvalidEmailException(message);

        }

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}
