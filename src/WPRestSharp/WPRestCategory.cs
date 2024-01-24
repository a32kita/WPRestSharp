using System;
using System.Collections.Generic;
using System.Text;

namespace WPRestSharp
{
    public class WPRestCategory
    {
        public WPRestCategoryId Id
        {
            get;
            set;
        }

        public uint Count
        {
            get;
            set;
        }

        public Uri Link
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Slug
        {
            get;
            set;
        }
    }
}
