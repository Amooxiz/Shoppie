namespace Shoppie.Business.ViewModels
{
    public class ErrorVM
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}