﻿using JwtStore.Core.SharedContext.ValueObjects;
using JwtStore.Core.SharedContext.Extensions;
using System.Text.RegularExpressions;
using JwtStore.Core.AccountContext.ValueObjects.Exceptions;

namespace JwtStore.Core.AccountContext.ValueObjects
{
    public partial class Email : ValueObject
    {

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