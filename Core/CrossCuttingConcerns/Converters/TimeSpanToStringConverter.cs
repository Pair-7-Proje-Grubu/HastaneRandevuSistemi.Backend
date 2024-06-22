using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Converters
{
    public class TimeSpanToStringConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected StartObject token");
            }

            string timeString = null;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();

                    if (propertyName == "ticks")
                    {
                        timeString = reader.GetString();
                    }
                }
            }

            if (timeString == null)
            {
                throw new JsonException("Missing ticks property");
            }

            if (TimeSpan.TryParse(timeString, out TimeSpan timeSpan))
            {
                return timeSpan;
            }
            else
            {
                throw new JsonException("Invalid time format");
            }
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("ticks", value.ToString("c"));
            writer.WriteEndObject();
        }
    }
}
