using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace todolist.Exceptions
{
    public class AccountException : Exception
    {
        public IEnumerable<IdentityError> Errors { get; private set; }
        public AccountException(string message) : base(message)
        {

        }
        public AccountException(IEnumerable<IdentityError> errors, string message) : base(message)
        {
            Errors = errors;
        }
    }
}