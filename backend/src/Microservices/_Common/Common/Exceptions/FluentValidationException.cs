using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class FluentValidationException : Exception
    {
        public Dictionary<string, string[]> Errors { get; set; }
        public FluentValidationException(Dictionary<string, string[]> errors)
        {
            Errors = errors;
        }

        public FluentValidationException() { }

        public FluentValidationException(string message) : base(message)
        {
        }

        public FluentValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
