using System;

namespace SondaCapta.Domain.Abstractions
{
    public class ProbeCrashedException : Exception
    {
        public ProbeCrashedException() : base() { }
        public ProbeCrashedException(string message) : base(message) { }
        public ProbeCrashedException(string message, Exception innerException) : base (message, innerException) { }
    }
}
