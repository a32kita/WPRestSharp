using System;
using System.Collections.Generic;
using System.Text;

namespace WPRestSharp
{
    public class WPRestMediaDetails : WPRestMediaSizedContent
    {
        public WPRestMediaSizedPatterns Sizes
        {
            get;
            set;
        }
    }
}
