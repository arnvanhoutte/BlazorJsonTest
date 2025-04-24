using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Refit;

namespace BlazorApp1.Client
{
    public class JsonContentSerializer : IHttpContentSerializer
    {
        private readonly JsonSerializerOptions serializerOptions;

        public JsonContentSerializer(JsonSerializerOptions? serializerOptions = null)
        {
            this.serializerOptions = serializerOptions ?? new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<T> DeserializeAsync<T>(HttpContent content)
        {
            await using var utf8Json = await content.ReadAsStreamAsync()
                .ConfigureAwait(false);

            var result = await JsonSerializer.DeserializeAsync<T>(utf8Json,
                serializerOptions).ConfigureAwait(false);

            return result is null ? throw new InvalidOperationException("Deserialization returned null.") : result;
        }

        public Task<T?> FromHttpContentAsync<T>(HttpContent content, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public string? GetFieldNameForProperty(PropertyInfo propertyInfo)
        {
            throw new NotImplementedException();
        }

        public Task<HttpContent> SerializeAsync<T>(T item)
        {
            var json = JsonSerializer.Serialize(item, serializerOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return Task.FromResult((HttpContent)content);
        }

        public HttpContent ToHttpContent<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}
