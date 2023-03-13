namespace Shoppie.Business.Services.Interfaces
{
    public interface INBPIntegratorService
    {
        public Task<double> GetRate(string symbol);
    }
}
