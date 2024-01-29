using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace WPRestSharp
{
    public struct WPRestPostId
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

        public static implicit operator WPRestPostId(ulong value)
        {
            return new WPRestPostId() { Value = value };
        }

        public class JsonConverter : JsonConverter<WPRestPostId>
        {
            public override WPRestPostId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = JsonSerializer.Deserialize<UInt32>(ref reader, options);
                return new WPRestPostId() { Value = value };
            }

            public override void Write(Utf8JsonWriter writer, WPRestPostId value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value.Value);
            }
        }
    }
}
