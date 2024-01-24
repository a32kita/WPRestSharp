using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WPRestSharp
{
    public struct WPRestUserId
    {
        public uint Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public class JsonConverter : JsonConverter<WPRestUserId>
        {
            public override WPRestUserId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = JsonSerializer.Deserialize<UInt32>(ref reader, options);
                return new WPRestUserId() { Value = value };
            }

            public override void Write(Utf8JsonWriter writer, WPRestUserId value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value.Value);
            }
        }
    }
}
