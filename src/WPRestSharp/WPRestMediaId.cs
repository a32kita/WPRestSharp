using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace WPRestSharp
{
    public struct WPRestMediaId
    {
        public ulong Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public static implicit operator WPRestMediaId(ulong value)
        {
            return new WPRestMediaId() { Value = value };
        }

        public class JsonConverter : JsonConverter<WPRestMediaId>
        {
            public override WPRestMediaId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = JsonSerializer.Deserialize<UInt32>(ref reader, options);
                return new WPRestMediaId() { Value = value };
            }

            public override void Write(Utf8JsonWriter writer, WPRestMediaId value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value.Value);
            }
        }
    }
}
