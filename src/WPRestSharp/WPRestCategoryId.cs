using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace WPRestSharp
{
    public struct WPRestCategoryId
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

        public class JsonConverter : JsonConverter<WPRestCategoryId>
        {
            public override WPRestCategoryId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = JsonSerializer.Deserialize<UInt32>(ref reader, options);
                return new WPRestCategoryId() { Value = value };
            }

            public override void Write(Utf8JsonWriter writer, WPRestCategoryId value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value.Value);
            }
        }
    }
}
