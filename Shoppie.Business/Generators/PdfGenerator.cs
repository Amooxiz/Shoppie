using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using Shoppie.Business.Generators.Interfaces;
using Shoppie.Business.ViewModels;

namespace Shoppie.Business.Generators
{
    public class PdfGenerator : IPdfGenerator
    {
        public FileResult GeneratePdf(IEnumerable<OfferVM> offers, string currencyEmblem = "PLN")
        {
            MemoryStream stream = new();
            var category = offers.First().CategoryName;

            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            writer.SetCloseStream(false);

            document.SetMargins(30, 30, 30, 30);

            var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            string headerParagrahp = $"Price list for category: {category}";

            Paragraph par1 = new(headerParagrahp);

            var table = new Table(new float[] { 200, 200, 200, 200 });
            var headers = new string[] { "Id", "Nazwa", "Cena", "Rodzaj waluty" };

            foreach (var head in headers)
                table.AddHeaderCell(new Cell().Add(new Paragraph(head).SetFont(boldFont)));

            foreach (var offer in offers)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(offer.Id.ToString()).SetFont(boldFont)));
                table.AddHeaderCell(new Cell().Add(new Paragraph(offer.Title).SetFont(boldFont)));
                table.AddHeaderCell(new Cell().Add(new Paragraph(offer.Price.ToString()).SetFont(boldFont)));
                table.AddHeaderCell(new Cell().Add(new Paragraph(currencyEmblem).SetFont(boldFont)));
            }

            document.Add(par1);
            document.Add(table);
            document.Close();

            byte[] byteInfo = stream.ToArray();
            stream.Write(byteInfo, 0, byteInfo.Length);
            stream.Position = 0;

            return new FileStreamResult(stream, "application/pdf");
        }

    }
}
