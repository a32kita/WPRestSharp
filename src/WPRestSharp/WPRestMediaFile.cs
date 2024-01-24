using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WPRestSharp
{
    public class WPRestMediaFile : IDisposable
    {
        private bool _leaveOpen;
        

        public Stream BaseStream
        {
            get;
            private set;
        }

        public string FileName
        {
            get;
            private set;
        }

        public string ContentType
        {
            get;
            private set;
        }


        public WPRestMediaFile(Stream baseStream, string fileName, string contentType, bool leaveOpen)
        {
            this.BaseStream = baseStream;
            this.FileName = fileName;
            this.ContentType = contentType;

            this._leaveOpen = leaveOpen;
        }

        public WPRestMediaFile(Stream baseStream, string fileName, string contentType)
            : this(baseStream, fileName, contentType, false)
        {
            // NOP
        }


        public void Dispose()
        {
            if (this._leaveOpen)
                return;

            this.BaseStream.Dispose();
        }
    }
}
