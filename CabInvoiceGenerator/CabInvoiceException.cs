using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class CabInvoiceException:Exception
    {
        public ExceptionType exception;
        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_TIME,INVALID_RIDE
        }
        public CabInvoiceException(ExceptionType exception, string message) : base(message)
        {
            this.exception = exception;
        }
    }
}

