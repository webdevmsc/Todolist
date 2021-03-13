using System;
using System.Collections.Generic;

namespace todolist.Exceptions
{
    public class BusinessException : Exception
    {
        public IEnumerable<string> Errors { get; private set; }
        public BusinessException(string message) : base(message)
        {

        }
        public BusinessException(IEnumerable<string> errors, string message) : base(message)
        {
            Errors = errors;
        }
    }
}