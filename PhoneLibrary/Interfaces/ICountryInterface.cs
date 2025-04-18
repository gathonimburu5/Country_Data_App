using CountryData.Standard;
using PhoneLibrary.Models;

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
        Task<List<ModifiedCountry>> getModifiedCountryRecordAsync(int offset = 1, int limit = 20, string? searchQuery = null);
        Task<List<ModifiedRegion>> getMOdifiedRegionRecordsAsync(string code, int offset = 1, int limit = 20, string? searchQuery = null);
        Task<List<ModifiedCurrency>> getModifiedCurrencyAsync(string code);
    }
}
