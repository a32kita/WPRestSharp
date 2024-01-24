using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace WPRestSharp
{
    public class WPRestConnectionInfo
    {
        public string BaseUrl
        {
            get;
            private set;
        }

        public string User
        {
            get;
            private set;
        }

        public string ApplicationPassword
        {
            get;
            private set;
        }

        public bool IsAnonymous
        {
            get;
            private set;
        }


        public WPRestConnectionInfo(string baseUrl, string user, string applicationPassword)
        {
            this.BaseUrl = baseUrl;
            this.User = user;
            this.ApplicationPassword = applicationPassword;
            this.IsAnonymous = false;
        }

        public WPRestConnectionInfo()
            : this(String.Empty, String.Empty, String.Empty)
        {
            // NOP
        }


        public bool IsValid()
        {
            if (this.IsAnonymous)
                return true;

            return
                !String.IsNullOrEmpty(this.BaseUrl) ||
                !String.IsNullOrEmpty(this.User) ||
                !String.IsNullOrEmpty(this.ApplicationPassword);
        }

        public WPRestConnectionInfo SetBaseUrl(string baseUrl)
        {
            if (baseUrl == null)
                throw new ArgumentNullException(nameof(baseUrl));

            if (baseUrl.Length > 2 && baseUrl.EndsWith("/"))
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);

            this.BaseUrl = baseUrl;
            return this;
        }

        public WPRestConnectionInfo SetAnonymoys()
        {
            this.IsAnonymous = true;
            return this;
        }

        public WPRestConnectionInfo SetUser(string user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (this.IsAnonymous)
                throw new InvalidOperationException();

            this.User = user;
            return this;
        }

        public WPRestConnectionInfo SetApplicationPassword(string applicationPassword)
        {
            if (applicationPassword == null)
                throw new ArgumentNullException(nameof(applicationPassword));

            if (this.IsAnonymous)
                throw new InvalidOperationException();

            this.ApplicationPassword = applicationPassword;
            return this;
        }
    }
}
