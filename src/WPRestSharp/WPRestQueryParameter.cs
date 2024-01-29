using System;
using System.Collections.Generic;
using System.Text;

namespace WPRestSharp
{
    public abstract class WPRestQueryParameter
    {
        public uint? Page
        {
            get;
            set;
        }

        public uint? PerPage
        {
            get;
            set;
        }

        public WPRestQueryOrder? Order
        {
            get;
            set;
        }

        protected string ToIso8601String(DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        }

        protected virtual IDictionary<string, string> ToDictionary(IDictionary<string, string> dictionary)
        {
            if (this.Page != null)
                dictionary.Add("page", this.Page.ToString());
            if (this.PerPage != null)
                dictionary.Add("per_page", this.PerPage.ToString());
            if (this.Order != null)
                dictionary.Add("order", this.Order.ToString().ToLower());

            return dictionary;
        }

        public IReadOnlyDictionary<string, string> ToDictionary()
        {
            return (IReadOnlyDictionary<string, string>) this.ToDictionary(new Dictionary<string, string>());
        }
    }
}
