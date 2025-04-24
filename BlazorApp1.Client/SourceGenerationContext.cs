using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApp1.Client
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(List<JsonFile>))]
    public partial class SourceGenerationContext : JsonSerializerContext
    {
    }

    public readonly struct JsonFile
    {
        public string id { get; init; }
        public string date { get; init; }
        public float la { get; init; }
        public float lo { get; init; }
        public string icon { get; init; }
        public bool? isApproved { get; init; }
    }
}
