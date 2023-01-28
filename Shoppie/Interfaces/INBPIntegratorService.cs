namespace Shoppie.Interfaces
{
    public interface INBPIntegratorService
    {
        public Task<double> GetRate(string symbol);
    }
}
