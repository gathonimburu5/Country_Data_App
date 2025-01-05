using System.Text;
using System.Text.Json;

namespace PhoneClient.Services
{
    public class IHttpHelperClass
    {
        private readonly JsonSerializerOptions jsonOptions;
        public IHttpHelperClass()
        {
            jsonOptions = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip
            };
        }

        public string SerializeObject<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, jsonOptions);
        }

        public StringContent GenarateStringContetnt<T>(T obj)
        {
            var json = SerializeObject(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public async Task<T> DeserializeJsonString<T>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, jsonOptions);
        }

        public async Task<List<T>> DeserializeJsonStringList<T>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<T>>(json, jsonOptions);
        }
    }
}
