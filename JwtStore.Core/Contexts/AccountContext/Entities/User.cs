﻿using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.AccountContext.ValueObjects.Exceptions;
using JwtStore.Core.Contexts.AccountContext.Entities;
using JwtStore.Core.Contexts.SharedContext.Entities;

namespace JwtStore.Core.AccountContext.Entities
{
    public class User : Entity
    {
        protected User()
        {
        }
        public User(string name, Email email, Password password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        public User(string email, string? password = null)
        {
            Email = email;
            Password = new Password(password);
        }
        public string Name { get; private set; } = string.Empty;
        public Email Email { get; private set; } = null!;
        public Password Password { get; private set; } = null!;
        public string Image { get; set; } = string.Empty;
        public List<Role> Roles { get; set; } = new();

        public void UpdatePassword(string plainTextPassword)
        {

            var password = new Password(plainTextPassword);
            Password = password;
        }

        public void UpdateEmail(Email email)
        {
            Email = email;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void ChangePassword(string plainTextPassword)
        {
            var password = new Password(plainTextPassword);
            Password = password;
        }
    }
}
