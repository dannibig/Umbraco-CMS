using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MessagePack;
using Newtonsoft.Json;
using Umbraco.Cms.Infrastructure.Serialization;

namespace Umbraco.Cms.Infrastructure.PublishedCache.DataSource;

/// <summary>
///     The content model stored in the content cache database table serialized as JSON
/// </summary>
[DataContract] // NOTE: Use DataContract annotations here to control how MessagePack serializes/deserializes the data to use INT keys
public class ContentCacheDataModel
{
    // TODO: We don't want to allocate empty arrays
    // dont serialize empty properties
    [DataMember(Order = 0)]
    [JsonProperty("pd")]
    [JsonPropertyName("pd")]
    [Newtonsoft.Json.JsonConverter(typeof(AutoInterningStringKeyCaseInsensitiveDictionaryConverter<PropertyData[]>))]
    [MessagePackFormatter(typeof(MessagePackAutoInterningStringKeyCaseInsensitiveDictionaryFormatter<PropertyData[]>))]
    public Dictionary<string, PropertyData[]>? PropertyData { get; set; }

    [DataMember(Order = 1)]
    [JsonProperty("cd")]
    [JsonPropertyName("cd")]
    [Newtonsoft.Json.JsonConverter(typeof(AutoInterningStringKeyCaseInsensitiveDictionaryConverter<CultureVariation>))]
    [MessagePackFormatter(
        typeof(MessagePackAutoInterningStringKeyCaseInsensitiveDictionaryFormatter<CultureVariation>))]
    public Dictionary<string, CultureVariation>? CultureData { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("us")]
    [JsonPropertyName("us")]
    public string? UrlSegment { get; set; }

    // Legacy properties used to deserialize existing nucache db entries
    [IgnoreDataMember]
    [JsonProperty("properties")]
    [JsonPropertyName("properties")]
    [Newtonsoft.Json.JsonConverter(typeof(CaseInsensitiveDictionaryConverter<PropertyData[]>))]
    private Dictionary<string, PropertyData[]> LegacyPropertyData { set => PropertyData = value; }

    [IgnoreDataMember]
    [JsonProperty("cultureData")]
    [JsonPropertyName("cultureData")]
    [Newtonsoft.Json.JsonConverter(typeof(CaseInsensitiveDictionaryConverter<CultureVariation>))]
    private Dictionary<string, CultureVariation> LegacyCultureData { set => CultureData = value; }

    [IgnoreDataMember]
    [JsonProperty("urlSegment")]
    [JsonPropertyName("urlSegment")]
    private string LegacyUrlSegment { set => UrlSegment = value; }
}
