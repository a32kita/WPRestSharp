using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WPRestSharp.InternalImpls
{
    public class JsonSeparatedLowerNamingPolicyImpl : JsonNamingPolicy
    {
        public char Separator
        {
            get;
            private set;
        }

        public JsonSeparatedLowerNamingPolicyImpl(char separator)
        {
            this.Separator = separator;
        }

        public override string ConvertName(string name)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < name.Length; i++)
            {
                var c = name[i];
                if (Char.IsUpper(c))
                {
                    sb.Append(Separator);
                    sb.Append(Char.ToLower(c));
                }
                else
                    sb.Append(c);
            }

            var pname = sb.ToString();
            if (pname[0] == '_')
                pname = pname.Substring(1);

            return pname;
        }
    }
}
