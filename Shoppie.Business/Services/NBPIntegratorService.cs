using Azure;
using Newtonsoft.Json;
using Shoppie.Business.Services.Interfaces;
using Shoppie.SupportModels;
using System.Net.Http;

namespace Shoppie.Business.Services
{
    public class NBPIntegratorService : INBPIntegratorService
    {
        public async Task<double> GetRate(string symbol)
        {
            HttpClient client = new HttpClient();
            var url = $@"http://api.nbp.pl/api/exchangerates/rates/A/{symbol}/";
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            NBPConvertModel nBPConvertModel = JsonConvert.DeserializeObject<NBPConvertModel>(json);
            return nBPConvertModel.rates[0].mid;
        }
    }
}
