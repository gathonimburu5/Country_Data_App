using CountryData.Standard;

namespace PhoneLibrary.Interfaces
{
    public interface ICountryInterface
    {
        Task<string> GetCountyByCode(string code);
        Task<string> GetCountyByPhoneCode(string phoneCode);
        Task<string> GetCountryData(int offset = 1, int limit = 20, string? searchQuery = null);
        Task<string> GetCountyFlag(string code);
        Task<List<Regions>> GetRegionByCountyCode(string code);
        Task<IEnumerable<Currency>> GetCurrencyByCountyCode(string code);
    }
}
