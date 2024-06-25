using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ValorantInfoApp.Infrastructure.Armor;
public partial class GetArmorResponse
{
    [JsonProperty("status")]
    public long Status { get; set; }

    [JsonProperty("data")]
    public Armor[] Data { get; set; } = null!;
}

public partial class Armor
{
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = null!;

    [JsonProperty("description")]
    public string Description { get; set; } = null!;

    [JsonProperty("displayIcon")]
    public Uri DisplayIcon { get; set; } = null!;

    [JsonProperty("assetPath")]
    public string AssetPath { get; set; } = null!;

    [JsonProperty("shopData")]
    public ShopData ShopData { get; set; } = null!;
}

public partial class ShopData
{
    [JsonProperty("cost")]
    public long Cost { get; set; }

    [JsonProperty("category")]
    public string Category { get; set; } = null!;

    [JsonProperty("shopOrderPriority")]
    public long ShopOrderPriority { get; set; }

    [JsonProperty("categoryText")]
    public string CategoryText { get; set; } = null!;

    [JsonProperty("gridPosition")]
    public object GridPosition { get; set; } = null!;

    [JsonProperty("canBeTrashed")]
    public bool CanBeTrashed { get; set; }

    [JsonProperty("image")]
    public object Image { get; set; } = null!;

    [JsonProperty("newImage")]
    public Uri NewImage { get; set; } = null!;

    [JsonProperty("newImage2")]
    public object NewImage2 { get; set; } = null!;

    [JsonProperty("assetPath")]
    public string AssetPath { get; set; } = null!;
}

public partial class GetArmorResponse
{
    public static GetArmorResponse? FromJson(string json) => JsonConvert.DeserializeObject<GetArmorResponse>(json, Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this GetArmorResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}