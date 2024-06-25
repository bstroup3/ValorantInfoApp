using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ValorantInfoApp.Infrastructure.Maps;

public partial class GetMapResponse
{
    [JsonProperty("status")]
    public long Status { get; set; }

    [JsonProperty("data")]
    public Map[] Data { get; set; } = null!;
}

public partial class Map
{
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = null!;

    [JsonProperty("narrativeDescription")]
    public object NarrativeDescription { get; set; } = null!;

    [JsonProperty("tacticalDescription")]
    public TacticalDescription? TacticalDescription { get; set; }

    [JsonProperty("coordinates")]
    public string Coordinates { get; set; } = null!;

    [JsonProperty("displayIcon")]
    public Uri DisplayIcon { get; set; } = null!;

    [JsonProperty("listViewIcon")]
    public Uri ListViewIcon { get; set; } = null!;

    [JsonProperty("listViewIconTall")]
    public Uri ListViewIconTall { get; set; } = null!;

    [JsonProperty("splash")]
    public Uri Splash { get; set; } = null!;

    [JsonProperty("stylizedBackgroundImage")]
    public Uri StylizedBackgroundImage { get; set; } = null!;

    [JsonProperty("premierBackgroundImage")]
    public Uri PremierBackgroundImage { get; set; } = null!;

    [JsonProperty("assetPath")]
    public string AssetPath { get; set; } = null!;

    [JsonProperty("mapUrl")]
    public string MapUrl { get; set; } = null!;

    [JsonProperty("xMultiplier")]
    public double XMultiplier { get; set; }

    [JsonProperty("yMultiplier")]
    public double YMultiplier { get; set; }

    [JsonProperty("xScalarToAdd")]
    public double XScalarToAdd { get; set; }

    [JsonProperty("yScalarToAdd")]
    public double YScalarToAdd { get; set; }

    [JsonProperty("callouts")]
    public Callout[] Callouts { get; set; } = null!;
}

public partial class Callout
{
    [JsonProperty("regionName")]
    public string RegionName { get; set; } = null!;

    [JsonProperty("superRegionName")]
    public SuperRegionName SuperRegionName { get; set; }

    [JsonProperty("location")]
    public Location Location { get; set; } = null!;
}

public partial class Location
{
    [JsonProperty("x")]
    public double X { get; set; }

    [JsonProperty("y")]
    public double Y { get; set; }
}

public enum SuperRegionName { A, AttackerSide, B, C, DefenderSide, Mid };

public enum TacticalDescription { ABCSites, ABSites };

public partial class GetMapResponse
{
    public static GetMapResponse FromJson(string json) => JsonConvert.DeserializeObject<GetMapResponse>(json, Converter.Settings)!;
}

public static class Serialize
{
    public static string ToJson(this GetMapResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                SuperRegionNameConverter.Singleton,
                TacticalDescriptionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}

internal class SuperRegionNameConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(SuperRegionName) || t == typeof(SuperRegionName?);

    public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null!;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "A":
                return SuperRegionName.A;
            case "Attacker Side":
                return SuperRegionName.AttackerSide;
            case "B":
                return SuperRegionName.B;
            case "C":
                return SuperRegionName.C;
            case "Defender Side":
                return SuperRegionName.DefenderSide;
            case "Mid":
                return SuperRegionName.Mid;
        }
        throw new Exception("Cannot unmarshal type SuperRegionName");
    }

    public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (SuperRegionName)untypedValue;
        switch (value)
        {
            case SuperRegionName.A:
                serializer.Serialize(writer, "A");
                return;
            case SuperRegionName.AttackerSide:
                serializer.Serialize(writer, "Attacker Side");
                return;
            case SuperRegionName.B:
                serializer.Serialize(writer, "B");
                return;
            case SuperRegionName.C:
                serializer.Serialize(writer, "C");
                return;
            case SuperRegionName.DefenderSide:
                serializer.Serialize(writer, "Defender Side");
                return;
            case SuperRegionName.Mid:
                serializer.Serialize(writer, "Mid");
                return;
        }
        throw new Exception("Cannot marshal type SuperRegionName");
    }

    public static readonly SuperRegionNameConverter Singleton = new SuperRegionNameConverter();
}

internal class TacticalDescriptionConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(TacticalDescription) || t == typeof(TacticalDescription?);

    public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null!;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "A/B Sites":
                return TacticalDescription.ABSites;
            case "A/B/C Sites":
                return TacticalDescription.ABCSites;
        }
        throw new Exception("Cannot unmarshal type TacticalDescription");
    }

    public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (TacticalDescription)untypedValue;
        switch (value)
        {
            case TacticalDescription.ABSites:
                serializer.Serialize(writer, "A/B Sites");
                return;
            case TacticalDescription.ABCSites:
                serializer.Serialize(writer, "A/B/C Sites");
                return;
        }
        throw new Exception("Cannot marshal type TacticalDescription");
    }

    public static readonly TacticalDescriptionConverter Singleton = new TacticalDescriptionConverter();
}