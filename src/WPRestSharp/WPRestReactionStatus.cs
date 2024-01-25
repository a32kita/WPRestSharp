using System;
using System.Collections.Generic;
using System.Text;

namespace WPRestSharp
{
    public enum WPRestReactionStatus
    {
        Unknown,

        Open,

        Closed,
    }

    public class WPRestReactionStatus_Converter : WPRestEnumConverterBase<WPRestReactionStatus>
    {
        public WPRestReactionStatus_Converter()
            : base(new Dictionary<WPRestReactionStatus, String>()
            {
                //{ WPRestReactionStatus.Unknown, "Unknown" },
                { WPRestReactionStatus.Open, "open" },
                { WPRestReactionStatus.Closed, "closed" },
            })
        {
            // NOP
        }
    }
}
