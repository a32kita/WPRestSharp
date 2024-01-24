using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WPRestSharp
{
    public class WPRenderableText
    {
        public string Raw
        {
            get;
            set;
        }

        public string Rendered
        {
            get;
            set;
        }

        public bool Protected
        {
            get;
            set;
        }

        //public class WPRenderableTextConverter : JsonConverter<WPRenderableText>
        //{
        //    public override WPRenderableText Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        //    {
        //        return JsonSerializer.Deserialize<WPRenderableText>(ref reader, options);
        //    }

        //    public override void Write(Utf8JsonWriter writer, WPRenderableText value, JsonSerializerOptions options)
        //    {
        //        var valueStr = String.IsNullOrEmpty(value.Rendered) ? value.Raw : value.Rendered;
        //        writer.WriteStringValue(valueStr);
        //    }
        //}
    }
}
