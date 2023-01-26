using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.CodeAnalysis.Diagnostics;
using NuGet.Packaging;
using Shoppie.Interfaces;
using Shoppie.ViewModels;

namespace Shoppie.Generators
{
    public class PdfGenerator : IPdfGenerator
    {
        public FileResult GeneratePdf(IEnumerable<OfferVM> offers)
        {
            MemoryStream stream = new();

            var document = new Document();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);

            document.Add(new Paragraph("xd"));
            document.Close();
            
            byte[] byteInfo = stream.ToArray();
            stream.Write(byteInfo, 0, byteInfo.Length);
            stream.Position = 0;

            return new FileStreamResult(stream, "application/pdf");
        }
    }
}
