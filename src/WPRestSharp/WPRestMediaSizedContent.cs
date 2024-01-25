using System;
using System.Collections.Generic;
using System.Text;

namespace WPRestSharp
{
    public class WPRestMediaSizedContent
    {
        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public string File
        {
            get;
            set;
        }

        public uint Filesize
        {
            get;
            set;
        }

        public Uri SourceUrl
        {
            get;
            set;
        }
    }
}
