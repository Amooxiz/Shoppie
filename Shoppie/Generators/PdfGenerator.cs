using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.CodeAnalysis.Diagnostics;
using NuGet.Packaging;
using Shoppie.Interfaces;
using Shoppie.ViewModels;
using System.Drawing;

namespace Shoppie.Generators
{
    public class PdfGenerator : IPdfGenerator
    {
        public FileResult GeneratePdf(IEnumerable<OfferVM> offers)
        {
            MemoryStream stream = new();

            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            writer.SetCloseStream(false);

            document.SetMargins(20, 20, 20, 20);
            
            var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);


            document.Add(new Paragraph("xd"));
            document.Close();
            
            byte[] byteInfo = stream.ToArray();
            stream.Write(byteInfo, 0, byteInfo.Length);
            stream.Position = 0;

            return new FileStreamResult(stream, "application/pdf");
        }
    }
}
