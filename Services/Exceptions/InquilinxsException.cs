using System;

namespace Services.Exceptions
{
    public class InquilinxsException : Exception
    {
        public InquilinxsException(string message = "", Exception innerException = null) : base(message, innerException) { }
    }
}