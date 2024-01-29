using System;
using System.Collections.Generic;
using System.Text;

namespace WPRestSharp
{
    public class WPRestMediaQueryParameter : WPRestQueryParameter
    {


        protected override IDictionary<string, string> ToDictionary(IDictionary<string, string> dictionary)
        {
            base.ToDictionary(dictionary);

            return dictionary;
        }
    }
}
