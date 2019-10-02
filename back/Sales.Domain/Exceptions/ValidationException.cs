using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sales.Domain.Exceptions
{
    [Serializable]
    public class CustomValidationException : Exception
    {
        public CustomValidationException()
        {
        }

        public CustomValidationException(string message) : base(message)
        {
        }

        public CustomValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            base.GetObjectData(info, context);
        }

    }
}
