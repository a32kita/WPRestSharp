using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WPRestSharp
{
    public class WPRestException : Exception
    {
        public WPRestErrorMessage ErrorMessage
        {
            get;
            set;
        }

        public WPRestException(WPRestErrorMessage errorMessage)
            : base(errorMessage.Message)
        {
            ErrorMessage = errorMessage;
        }

        protected WPRestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
