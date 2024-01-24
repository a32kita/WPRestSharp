using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WPRestSharp
{
    public enum WPRestStatus
    {
        Unknown,

        Draft,

        Publish,

        Future,

        Pending,

        Private,

        Trash,

        AutoDraft,

        Inherit,
    }

    public class WPRestStatus_Converter : WPRestEnumConverterBase<WPRestStatus>
    {
        public WPRestStatus_Converter()
            : base(new Dictionary<WPRestStatus, String>()
            {
                //{ WPRestStatus.Unknown, "Unknown" },
                { WPRestStatus.Draft, "draft" },
                { WPRestStatus.Publish, "publish" },
                { WPRestStatus.Future, "future" },
                { WPRestStatus.Pending, "pending" },
                { WPRestStatus.Private, "private" },
                { WPRestStatus.Trash, "trash" },
                { WPRestStatus.AutoDraft, "auto-draft" },
                { WPRestStatus.Inherit, "inherit" },
            })
        {
            // NOP
        }
    }
}
