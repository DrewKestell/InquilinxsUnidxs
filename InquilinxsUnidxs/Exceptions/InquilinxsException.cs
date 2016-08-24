using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InquilinxsUnidxs.Exceptions
{
    public class InquilinxsException : Exception
    {
        public InquilinxsException(string message = "", Exception innerException = null) : base(message, innerException) { }
    }
}