﻿namespace Uplay.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
           : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }
        public IDictionary<string, string[]> Errors { get; }
    }
}
