using System.IO;
using System.Threading.Tasks;
using InfiniSwiss.ChromiumHtmlToPdf;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sourceUrl = "https://developer.mozilla.org/en-US/docs/Web/CSS/@media";
            var pdfFilePath = Path.Combine(Directory.GetCurrentDirectory(), "out.pdf");

            var printer = new ChromiumPdfPrinter();
            await printer.PrintToPdfAsync(sourceUrl, pdfFilePath);
        }
    }
}
