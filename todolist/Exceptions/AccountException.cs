﻿using System;

namespace todolist.Exceptions
{
    public class AccountException : Exception
    {
        public AccountException(string message) : base(message)
        {
        }
    }
}