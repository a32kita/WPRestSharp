using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WPRestSharp
{
    public class WPRestEnumConverterBase<TEnum> : JsonConverter<TEnum> where TEnum : Enum
    {
        private Dictionary<TEnum, String> _valueDefinitions;

        internal WPRestEnumConverterBase(IDictionary<TEnum, String> valueDefinitions)
        {
            this._valueDefinitions = new Dictionary<TEnum, string>();
            foreach (var kvp in valueDefinitions)
                this._valueDefinitions.Add(kvp.Key, kvp.Value);
        }

        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var valueStr = JsonSerializer.Deserialize<String>(ref reader, options);
            
            foreach (var kvp in _valueDefinitions)
            {
                if (kvp.Value.Equals(valueStr))
                    return kvp.Key;
            }

            return default;
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            var valueStr = this._valueDefinitions[value];
            writer.WriteStringValue(valueStr);
        }
    }
}
