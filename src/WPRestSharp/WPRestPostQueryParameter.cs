using System;
using System.Collections.Generic;
using System.Text;

namespace WPRestSharp
{
    public class WPRestPostQueryParameter : WPRestQueryParameter
    {
        public DateTimeOffset? ModifiedAfter
        {
            get;
            set;
        }

        protected override IDictionary<string, string> ToDictionary(IDictionary<string, string> dictionary)
        {
            base.ToDictionary(dictionary);

            if (this.ModifiedAfter != null)
                dictionary.Add("modified_after", this.ToIso8601String(this.ModifiedAfter.Value));

            return dictionary;
        }
    }
}
