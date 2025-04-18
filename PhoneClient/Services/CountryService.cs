using CountryData.Standard;
using PhoneLibrary.Interfaces;
using PhoneLibrary.Models;

namespace PhoneClient.Services
{
    public class CountryService(HttpClient client, IHttpHelperClass helperClass) : ICountryInterface
    {
        public async Task<string> GetCountryData(int offset = 1, int limit = 20, string? searchQuery = null)
        {
            var url = $"api/Country/GetAllCountryData?offset={offset}&limit={limit}&searchQuery={searchQuery}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await helperClass.DeserializeJsonString<string>(response);
            }
            return null;
        }

        public async Task<string> GetCountyByCode(string code)
        {
            var url = $"api/Country/GetCountryByCode?code={code}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await helperClass.DeserializeJsonString<string>(response);
            }
            return null;
        }

        public Task<string> GetCountyByPhoneCode(string phoneCode)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetCountyFlag(string code)
        {
            var url = $"api/Country/GetCountryByFlag?code={code}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await helperClass.DeserializeJsonString<string>(response);
            }
            return null;
        }

        public async Task<IEnumerable<CountryData.Standard.Currency>> GetCurrencyByCountyCode(string code)
        {
            var url = $"api/Country/GetRegionByCountry?code={code}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await helperClass.DeserializeJsonStringList<CountryData.Standard.Currency>(response);
            }
            return null;
        }

        public async Task<List<ModifiedCountry>> getModifiedCountryRecordAsync(int offset = 1, int limit = 20, string? searchQuery = null)
        {
            var url = $"api/Country/GetModifiedCountryRecord?offset={offset}&limit={limit}&searchQuery={searchQuery}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await helperClass.DeserializeJsonStringList<ModifiedCountry>(response);
            }
            return null;
        }

        public Task<List<ModifiedCurrency>> getModifiedCurrencyAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<List<ModifiedRegion>> getMOdifiedRegionRecordsAsync(string code, int offset = 1, int limit = 20, string? searchQuery = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Regions>> GetRegionByCountyCode(string code)
        {
            var url = $"api/Country/GetCurrencyPerCountry?code={code}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await helperClass.DeserializeJsonStringList<Regions>(response);
            }
            return null;
        }
    }
}
