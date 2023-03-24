using Shoppie.Business.SupportModels;

namespace Shoppie.Business.Services.Interfaces
{
    public interface INBPIntegratorService
    {
        public Task<NBPConvertModel?> GetRate(string symbol);
    }
}
