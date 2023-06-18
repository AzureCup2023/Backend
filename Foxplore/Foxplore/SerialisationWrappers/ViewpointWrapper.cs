﻿// <auto-generated />
// app.quicktype.io with modifications
#nullable enable
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8603

namespace Foxplore.SerialisationWrappers.ViewpointWrapper
{
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public partial class ViewpointWrapper
    {
        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("crs")] public Crs Crs { get; set; }

        [JsonPropertyName("features")] public Feature[] Features { get; set; }
    }

    public partial class Crs
    {
        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("properties")] public CrsProperties Properties { get; set; }
    }

    public partial class CrsProperties
    {
        [JsonPropertyName("name")] public string Name { get; set; }
    }

    public partial class Feature
    {
        [JsonPropertyName("type")] public FeatureType Type { get; set; }

        [JsonPropertyName("geometry")] public Geometry Geometry { get; set; }

        [JsonPropertyName("properties")] public FeatureProperties Properties { get; set; }
    }

    public partial class Geometry
    {
        [JsonPropertyName("type")] public GeometryType Type { get; set; }

        [JsonPropertyName("coordinates")] public double[] Coordinates { get; set; }
    }

    public partial class FeatureProperties
    {
        [JsonPropertyName("OBJECTID")] public long Objectid { get; set; }

        [JsonPropertyName("VYHBOD_ID")] public long VyhbodId { get; set; }

        [JsonPropertyName("MC")] public string Mc { get; set; }

        [JsonPropertyName("KU")] public string Ku { get; set; }

        [JsonPropertyName("NAZEVSTANOVISTE")] public string Nazevstanoviste { get; set; }
    }

    public enum GeometryType
    {
        Point
    };

    public enum FeatureType
    {
        Feature
    };

    public partial class ViewpointWrapper
    {
        public static ViewpointWrapper FromJson(string json) =>
            JsonSerializer.Deserialize<ViewpointWrapper>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ViewpointWrapper self) =>
            JsonSerializer.Serialize(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
        {
            Converters =
            {
                GeometryTypeConverter.Singleton,
                FeatureTypeConverter.Singleton,
                new DateOnlyConverter(),
                new TimeOnlyConverter(),
                IsoDateTimeOffsetConverter.Singleton
            },
        };
    }

    internal class GeometryTypeConverter : JsonConverter<GeometryType>
    {
        public override bool CanConvert(Type t) => t == typeof(GeometryType);

        public override GeometryType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == "Point")
            {
                return GeometryType.Point;
            }

            throw new Exception("Cannot unmarshal type GeometryType");
        }

        public override void Write(Utf8JsonWriter writer, GeometryType value, JsonSerializerOptions options)
        {
            if (value == GeometryType.Point)
            {
                JsonSerializer.Serialize(writer, "Point", options);
                return;
            }

            throw new Exception("Cannot marshal type GeometryType");
        }

        public static readonly GeometryTypeConverter Singleton = new GeometryTypeConverter();
    }

    internal class FeatureTypeConverter : JsonConverter<FeatureType>
    {
        public override bool CanConvert(Type t) => t == typeof(FeatureType);

        public override FeatureType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == "Feature")
            {
                return FeatureType.Feature;
            }

            throw new Exception("Cannot unmarshal type FeatureType");
        }

        public override void Write(Utf8JsonWriter writer, FeatureType value, JsonSerializerOptions options)
        {
            if (value == FeatureType.Feature)
            {
                JsonSerializer.Serialize(writer, "Feature", options);
                return;
            }

            throw new Exception("Cannot marshal type FeatureType");
        }

        public static readonly FeatureTypeConverter Singleton = new FeatureTypeConverter();
    }

    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string serializationFormat;

        public DateOnlyConverter() : this(null)
        {
        }

        public DateOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
        }

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private readonly string serializationFormat;

        public TimeOnlyConverter() : this(null)
        {
        }

        public TimeOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
        }

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    internal class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override bool CanConvert(Type t) => t == typeof(DateTimeOffset);

        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
        private string? _dateTimeFormat;
        private CultureInfo? _culture;

        public DateTimeStyles DateTimeStyles
        {
            get => _dateTimeStyles;
            set => _dateTimeStyles = value;
        }

        public string? DateTimeFormat
        {
            get => _dateTimeFormat ?? string.Empty;
            set => _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
        }

        public CultureInfo Culture
        {
            get => _culture ?? CultureInfo.CurrentCulture;
            set => _culture = value;
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            string text;


            if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
            {
                value = value.ToUniversalTime();
            }

            text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

            writer.WriteStringValue(text);
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            string? dateText = reader.GetString();

            if (string.IsNullOrEmpty(dateText) == false)
            {
                if (!string.IsNullOrEmpty(_dateTimeFormat))
                {
                    return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                }
                else
                {
                    return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
                }
            }
            else
            {
                return default(DateTimeOffset);
            }
        }


        public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
    }
}
#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8603