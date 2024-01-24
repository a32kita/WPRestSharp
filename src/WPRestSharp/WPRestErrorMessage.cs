using System;
using System.Collections.Generic;
using System.Text;

namespace WPRestSharp
{
    public class WPRestErrorMessage
    {
        public string Code
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public DataField Data
        {
            get;
            set;
        }


        public class DataField
        {
            public int Status
            {
                get;
                set;
            }
        }
    }
}
