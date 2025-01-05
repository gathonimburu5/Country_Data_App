using CountryData.Standard;
using Newtonsoft.Json;
using PhoneLibrary.Interfaces;

namespace PhoneBackend.Repository
{
    public class CountryService : ICountryInterface
    {
        private readonly CountryHelper countryHelper;
        public CountryService(CountryHelper countryHelper)
        {
            this.countryHelper = countryHelper;
        }
        public Task<string> GetCountryData(int offset = 1, int limit = 20, string? searchQuery = null)
        {
            var countries = countryHelper.GetCountryData();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower();
                countries = countries.Where(x => x.CountryName.ToLower().Contains(searchQuery)).ToList();
            }
            var pagination = countries.Skip((offset - 1) * limit).Take(limit).ToList();
            if (!pagination.Any())
            {
                return Task.FromResult("no data found");
            }
            return Task.FromResult(JsonConvert.SerializeObject(pagination, Formatting.Indented));
        }

        public Task<string> GetCountyByCode(string code)
        {
            var country = countryHelper.GetCountryByCode(code);
            if(country != null)
            {
                return Task.FromResult(JsonConvert.SerializeObject(country, Formatting.Indented));
            }
            return Task.FromResult("no data found");
        }

        public Task<string> GetCountyByPhoneCode(string phoneCode)
        {
            var country = countryHelper.GetCountryByPhoneCode(phoneCode);
            return Task.FromResult(JsonConvert.SerializeObject(country, Formatting.Indented));
        }

        public Task<string> GetCountyFlag(string code)
        {
            var flag = countryHelper.GetCountryEmojiFlag(code);
            return Task.FromResult(flag);
        }

        public Task<IEnumerable<Currency>> GetCurrencyByCountyCode(string code)
        {
            var currency = countryHelper.GetCurrencyCodesByCountryCode(code);
            return Task.FromResult(currency);
        }

        public Task<List<Regions>> GetRegionByCountyCode(string code)
        {
            var region = countryHelper.GetRegionByCountryCode(code);
            return Task.FromResult(region);
        }
    }
}
