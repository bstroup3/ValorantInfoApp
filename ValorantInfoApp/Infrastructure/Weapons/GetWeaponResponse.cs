using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ValorantInfoApp.Infrastructure.Weapons;

public partial class GetWeaponResponse
{
    [JsonProperty("status")]
    public long Status { get; set; }

    [JsonProperty("data")]
    public Weapon[] Data { get; set; } = null!;
}

public partial class Weapon
{
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = null!;

    [JsonProperty("category")]
    public string Category { get; set; } = null!;

    [JsonProperty("defaultSkinUuid")]
    public Guid DefaultSkinUuid { get; set; }

    [JsonProperty("displayIcon")]
    public Uri DisplayIcon { get; set; } = null!;

    [JsonProperty("killStreamIcon")]
    public Uri KillStreamIcon { get; set; } = null!;

    [JsonProperty("assetPath")]
    public string AssetPath { get; set; } = null!;

    [JsonProperty("weaponStats")]
    public WeaponStats WeaponStats { get; set; } = null!;

    [JsonProperty("shopData")]
    public ShopData ShopData { get; set; } = null!;

    [JsonProperty("skins")]
    public Skin[] Skins { get; set; } = null!;
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
    public GridPosition GridPosition { get; set; } = null!;

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

public partial class GridPosition
{
    [JsonProperty("row")]
    public long Row { get; set; }

    [JsonProperty("column")]
    public long Column { get; set; }
}

public partial class Skin
{
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = null!;

    [JsonProperty("themeUuid")]
    public Guid ThemeUuid { get; set; }

    [JsonProperty("contentTierUuid")]
    public Guid? ContentTierUuid { get; set; }

    [JsonProperty("displayIcon")]
    public Uri DisplayIcon { get; set; } = null!;

    [JsonProperty("wallpaper")]
    public Uri Wallpaper { get; set; } = null!;

    [JsonProperty("assetPath")]
    public string AssetPath { get; set; } = null!;

    [JsonProperty("chromas")]
    public Chroma[] Chromas { get; set; } = null!;

    [JsonProperty("levels")]
    public Level[] Levels { get; set; } = null!;
}

public partial class Chroma
{
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = null!;

    [JsonProperty("displayIcon")]
    public Uri DisplayIcon { get; set; } = null!;

    [JsonProperty("fullRender")]
    public Uri FullRender { get; set; } = null!;

    [JsonProperty("swatch")]
    public Uri Swatch { get; set; } = null!;

    [JsonProperty("streamedVideo")]
    public Uri StreamedVideo { get; set; } = null!;

    [JsonProperty("assetPath")]
    public string AssetPath { get; set; } = null!;
}

public partial class Level
{
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = null!;

    [JsonProperty("levelItem")]
    public LevelItem? LevelItem { get; set; }

    [JsonProperty("displayIcon")]
    public Uri DisplayIcon { get; set; } = null!;

    [JsonProperty("streamedVideo")]
    public Uri StreamedVideo { get; set; } = null!;

    [JsonProperty("assetPath")]
    public string AssetPath { get; set; } = null!;
}

public partial class WeaponStats
{
    [JsonProperty("fireRate")]
    public double FireRate { get; set; }

    [JsonProperty("magazineSize")]
    public long MagazineSize { get; set; }

    [JsonProperty("runSpeedMultiplier")]
    public double RunSpeedMultiplier { get; set; }

    [JsonProperty("equipTimeSeconds")]
    public double EquipTimeSeconds { get; set; }

    [JsonProperty("reloadTimeSeconds")]
    public double ReloadTimeSeconds { get; set; }

    [JsonProperty("firstBulletAccuracy")]
    public double FirstBulletAccuracy { get; set; }

    [JsonProperty("shotgunPelletCount")]
    public long ShotgunPelletCount { get; set; }

    [JsonProperty("wallPenetration")]
    public WallPenetration WallPenetration { get; set; }

    [JsonProperty("feature")]
    public string Feature { get; set; } = null!;

    [JsonProperty("fireMode")]
    public string FireMode { get; set; } = null!;

    [JsonProperty("altFireType")]
    public AltFireType? AltFireType { get; set; }

    [JsonProperty("adsStats")]
    public AdsStats AdsStats { get; set; } = null!;

    [JsonProperty("altShotgunStats")]
    public AltShotgunStats AltShotgunStats { get; set; } = null!;

    [JsonProperty("airBurstStats")]
    public AirBurstStats AirBurstStats { get; set; } = null!;

    [JsonProperty("damageRanges")]
    public DamageRange[] DamageRanges { get; set; } = null!;
}

public partial class AdsStats
{
    [JsonProperty("zoomMultiplier")]
    public double ZoomMultiplier { get; set; }

    [JsonProperty("fireRate")]
    public double FireRate { get; set; }

    [JsonProperty("runSpeedMultiplier")]
    public double RunSpeedMultiplier { get; set; }

    [JsonProperty("burstCount")]
    public long BurstCount { get; set; }

    [JsonProperty("firstBulletAccuracy")]
    public double FirstBulletAccuracy { get; set; }
}

public partial class AirBurstStats
{
    [JsonProperty("shotgunPelletCount")]
    public long ShotgunPelletCount { get; set; }

    [JsonProperty("burstDistance")]
    public double BurstDistance { get; set; }
}

public partial class AltShotgunStats
{
    [JsonProperty("shotgunPelletCount")]
    public long ShotgunPelletCount { get; set; }

    [JsonProperty("burstRate")]
    public double BurstRate { get; set; }
}

public partial class DamageRange
{
    [JsonProperty("rangeStartMeters")]
    public long RangeStartMeters { get; set; }

    [JsonProperty("rangeEndMeters")]
    public long RangeEndMeters { get; set; }

    [JsonProperty("headDamage")]
    public double HeadDamage { get; set; }

    [JsonProperty("bodyDamage")]
    public long BodyDamage { get; set; }

    [JsonProperty("legDamage")]
    public double LegDamage { get; set; }
}

public enum LevelItem { EEquippableSkinLevelItemAnimation, EEquippableSkinLevelItemAttackerDefenderSwap, EEquippableSkinLevelItemFinisher, EEquippableSkinLevelItemFishAnimation, EEquippableSkinLevelItemHeartbeatAndMapSensor, EEquippableSkinLevelItemInspectAndKill, EEquippableSkinLevelItemKillBanner, EEquippableSkinLevelItemKillCounter, EEquippableSkinLevelItemKillEffect, EEquippableSkinLevelItemRandomizer, EEquippableSkinLevelItemSoundEffects, EEquippableSkinLevelItemTopFrag, EEquippableSkinLevelItemTransformation, EEquippableSkinLevelItemVfx, EEquippableSkinLevelItemVoiceover };

public enum AltFireType { EWeaponAltFireDisplayTypeAds, EWeaponAltFireDisplayTypeAirBurst, EWeaponAltFireDisplayTypeShotgun };

public enum WallPenetration { EWallPenetrationDisplayTypeHigh, EWallPenetrationDisplayTypeLow, EWallPenetrationDisplayTypeMedium };

public partial class GetWeaponResponse
{
    public static GetWeaponResponse? FromJson(string json) => JsonConvert.DeserializeObject<GetWeaponResponse>(json, Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this GetWeaponResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                LevelItemConverter.Singleton,
                AltFireTypeConverter.Singleton,
                WallPenetrationConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}

internal class LevelItemConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(LevelItem) || t == typeof(LevelItem?);

    public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null!;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "EEquippableSkinLevelItem::Animation":
                return LevelItem.EEquippableSkinLevelItemAnimation;
            case "EEquippableSkinLevelItem::AttackerDefenderSwap":
                return LevelItem.EEquippableSkinLevelItemAttackerDefenderSwap;
            case "EEquippableSkinLevelItem::Finisher":
                return LevelItem.EEquippableSkinLevelItemFinisher;
            case "EEquippableSkinLevelItem::FishAnimation":
                return LevelItem.EEquippableSkinLevelItemFishAnimation;
            case "EEquippableSkinLevelItem::HeartbeatAndMapSensor":
                return LevelItem.EEquippableSkinLevelItemHeartbeatAndMapSensor;
            case "EEquippableSkinLevelItem::InspectAndKill":
                return LevelItem.EEquippableSkinLevelItemInspectAndKill;
            case "EEquippableSkinLevelItem::KillBanner":
                return LevelItem.EEquippableSkinLevelItemKillBanner;
            case "EEquippableSkinLevelItem::KillCounter":
                return LevelItem.EEquippableSkinLevelItemKillCounter;
            case "EEquippableSkinLevelItem::KillEffect":
                return LevelItem.EEquippableSkinLevelItemKillEffect;
            case "EEquippableSkinLevelItem::Randomizer":
                return LevelItem.EEquippableSkinLevelItemRandomizer;
            case "EEquippableSkinLevelItem::SoundEffects":
                return LevelItem.EEquippableSkinLevelItemSoundEffects;
            case "EEquippableSkinLevelItem::TopFrag":
                return LevelItem.EEquippableSkinLevelItemTopFrag;
            case "EEquippableSkinLevelItem::Transformation":
                return LevelItem.EEquippableSkinLevelItemTransformation;
            case "EEquippableSkinLevelItem::VFX":
                return LevelItem.EEquippableSkinLevelItemVfx;
            case "EEquippableSkinLevelItem::Voiceover":
                return LevelItem.EEquippableSkinLevelItemVoiceover;
        }
        throw new Exception("Cannot unmarshal type LevelItem");
    }

    public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (LevelItem)untypedValue;
        switch (value)
        {
            case LevelItem.EEquippableSkinLevelItemAnimation:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::Animation");
                return;
            case LevelItem.EEquippableSkinLevelItemAttackerDefenderSwap:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::AttackerDefenderSwap");
                return;
            case LevelItem.EEquippableSkinLevelItemFinisher:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::Finisher");
                return;
            case LevelItem.EEquippableSkinLevelItemFishAnimation:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::FishAnimation");
                return;
            case LevelItem.EEquippableSkinLevelItemHeartbeatAndMapSensor:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::HeartbeatAndMapSensor");
                return;
            case LevelItem.EEquippableSkinLevelItemInspectAndKill:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::InspectAndKill");
                return;
            case LevelItem.EEquippableSkinLevelItemKillBanner:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::KillBanner");
                return;
            case LevelItem.EEquippableSkinLevelItemKillCounter:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::KillCounter");
                return;
            case LevelItem.EEquippableSkinLevelItemKillEffect:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::KillEffect");
                return;
            case LevelItem.EEquippableSkinLevelItemRandomizer:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::Randomizer");
                return;
            case LevelItem.EEquippableSkinLevelItemSoundEffects:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::SoundEffects");
                return;
            case LevelItem.EEquippableSkinLevelItemTopFrag:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::TopFrag");
                return;
            case LevelItem.EEquippableSkinLevelItemTransformation:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::Transformation");
                return;
            case LevelItem.EEquippableSkinLevelItemVfx:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::VFX");
                return;
            case LevelItem.EEquippableSkinLevelItemVoiceover:
                serializer.Serialize(writer, "EEquippableSkinLevelItem::Voiceover");
                return;
        }
        throw new Exception("Cannot marshal type LevelItem");
    }

    public static readonly LevelItemConverter Singleton = new LevelItemConverter();
}

internal class AltFireTypeConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(AltFireType) || t == typeof(AltFireType?);

    public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null!;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "EWeaponAltFireDisplayType::ADS":
                return AltFireType.EWeaponAltFireDisplayTypeAds;
            case "EWeaponAltFireDisplayType::AirBurst":
                return AltFireType.EWeaponAltFireDisplayTypeAirBurst;
            case "EWeaponAltFireDisplayType::Shotgun":
                return AltFireType.EWeaponAltFireDisplayTypeShotgun;
        }
        throw new Exception("Cannot unmarshal type AltFireType");
    }

    public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (AltFireType)untypedValue;
        switch (value)
        {
            case AltFireType.EWeaponAltFireDisplayTypeAds:
                serializer.Serialize(writer, "EWeaponAltFireDisplayType::ADS");
                return;
            case AltFireType.EWeaponAltFireDisplayTypeAirBurst:
                serializer.Serialize(writer, "EWeaponAltFireDisplayType::AirBurst");
                return;
            case AltFireType.EWeaponAltFireDisplayTypeShotgun:
                serializer.Serialize(writer, "EWeaponAltFireDisplayType::Shotgun");
                return;
        }
        throw new Exception("Cannot marshal type AltFireType");
    }

    public static readonly AltFireTypeConverter Singleton = new AltFireTypeConverter();
}

internal class WallPenetrationConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(WallPenetration) || t == typeof(WallPenetration?);

    public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null!;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "EWallPenetrationDisplayType::High":
                return WallPenetration.EWallPenetrationDisplayTypeHigh;
            case "EWallPenetrationDisplayType::Low":
                return WallPenetration.EWallPenetrationDisplayTypeLow;
            case "EWallPenetrationDisplayType::Medium":
                return WallPenetration.EWallPenetrationDisplayTypeMedium;
        }
        throw new Exception("Cannot unmarshal type WallPenetration");
    }

    public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (WallPenetration)untypedValue;
        switch (value)
        {
            case WallPenetration.EWallPenetrationDisplayTypeHigh:
                serializer.Serialize(writer, "EWallPenetrationDisplayType::High");
                return;
            case WallPenetration.EWallPenetrationDisplayTypeLow:
                serializer.Serialize(writer, "EWallPenetrationDisplayType::Low");
                return;
            case WallPenetration.EWallPenetrationDisplayTypeMedium:
                serializer.Serialize(writer, "EWallPenetrationDisplayType::Medium");
                return;
        }
        throw new Exception("Cannot marshal type WallPenetration");
    }

    public static readonly WallPenetrationConverter Singleton = new WallPenetrationConverter();
}