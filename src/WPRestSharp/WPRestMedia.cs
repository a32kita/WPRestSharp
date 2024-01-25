using System;
using System.Collections.Generic;
using System.Text;

namespace WPRestSharp
{
    public class WPRestMedia
    {
        public WPRestMediaId Id
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public DateTime DateGmt
        {
            get;
            set;
        }

        public WPRestRenderableText Guid
        {
            get;
            set;
        }

        public DateTime Modified
        {
            get;
            set;
        }

        public DateTime ModifiedGmt
        {
            get;
            set;
        }

        public string Slug
        {
            get;
            set;
        }

        public WPRestStatus? Status
        {
            get;
            set;
        }

        public WPRestMediaDetails MediaDetails
        {
            get;
            set;
        }
    }
}
