﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneLibrary.Interfaces;

namespace PhoneBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryInterface countryService;
        private readonly ILogger<CountryController> logger;

        public CountryController(ICountryInterface countryService, ILogger<CountryController> logger)
        {
            this.countryService = countryService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("GetAllCountryData")]
        public async Task<IActionResult> GetAllCountryData(int offset = 1, int limit = 20, string? searchQuery = null)
        {
            var county = await countryService.GetCountryData(offset, limit, searchQuery);
            logger.LogInformation("Controller: Country", county.ToString());
            return Ok(county);
        }

        [HttpGet]
        [Route("GetModifiedCountryRecord")]
        public async Task<IActionResult> GetModifiedCountryRecord(int offset = 1, int limit = 20, string? searchQuery = null)
        {
            var county = await countryService.getModifiedCountryRecordAsync(offset, limit, searchQuery);
            return Ok(county);
        }

        [HttpGet]
        [Route("GetModifiedCurrencyRecord")]
        public async Task<IActionResult> GetModifiedCurrencyRecord(string code)
        {
            var currency = await countryService.getModifiedCurrencyAsync(code);
            return Ok(currency);
        }

        [HttpGet]
        [Route("GetModifiedRegionRecords")]
        public async Task<IActionResult> GetModifiedRegionRecords(string code, int offset = 1, int limit = 20,
            string? seachQuery = null)
        {
            var region = await countryService.getMOdifiedRegionRecordsAsync(code, offset, limit, seachQuery);
            return Ok(region);
        }

        [HttpGet]
        [Route("GetCountryByCode")]
        public async Task<IActionResult> GetCountryByCode(string code)
        {
            var country = await countryService.GetCountyByCode(code);
            return Ok(country);
        }

        [HttpGet][Route("GetCountryByPHoneCode")]
        public async Task<IActionResult> GetCountryByPHoneCode(string phoneCode)
        {
            var country = await countryService.GetCountyByPhoneCode(phoneCode);
            return Ok(country);
        }

        [HttpGet][Route("GetCountryByFlag")]
        public async Task<IActionResult> GetCountryByFlag(string code)
        {
            var flag = await countryService.GetCountyFlag(code);
            return Ok(flag);
        }

        [HttpGet][Route("GetRegionByCountry")]
        public async Task<IActionResult> GetRegionByCountry(string code)
        {
            var region = await countryService.GetRegionByCountyCode(code);
            return Ok(region);
        }

        [HttpGet][Route("GetCurrencyPerCountry")]
        public async Task<IActionResult> GetCurrencyPerCountry(string code)
        {
            var currency = await countryService.GetCurrencyByCountyCode(code);
            return Ok(currency);
        }
    }
}
