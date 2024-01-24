using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WPRestSharp
{
    public class WPRestUser
    {
        public WPRestUserId Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public string Description
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
