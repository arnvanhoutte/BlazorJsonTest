using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApp1.Client
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(List<JsonFile>))]
    public partial class SourceGenerationContext : JsonSerializerContext
    {
    }

    public class JsonFile
    {
        public string id { get; set; }
        public string date { get; set; }
        public float la { get; set; }
        public float lo { get; set; }
        public string icon { get; set; }
        public bool? isApproved { get; set; }
    }


}
