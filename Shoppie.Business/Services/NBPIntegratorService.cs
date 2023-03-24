using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.SupportModels;
using System.Net.Http.Json;

namespace Shoppie.Business.Services
{
    public class NBPIntegratorService : INBPIntegratorService
    {
        private readonly HttpClient _httpClient;
        public NBPIntegratorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<NBPConvertModel?> GetRate(string symbol)
        {
            NBPConvertModel? rate = await _httpClient.GetFromJsonAsync<NBPConvertModel>($"{symbol}");

            Console.WriteLine("zs");

            return rate;
        }
    }
}
