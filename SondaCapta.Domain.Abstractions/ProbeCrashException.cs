using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain.Abstractions
{
    public class ProbeCrashException : Exception
    {
        public ProbeCrashException() : base() { }
        public ProbeCrashException(string message) : base(message) { }
        public ProbeCrashException(string message, Exception innerException) : base (message, innerException) { }
    }
}
