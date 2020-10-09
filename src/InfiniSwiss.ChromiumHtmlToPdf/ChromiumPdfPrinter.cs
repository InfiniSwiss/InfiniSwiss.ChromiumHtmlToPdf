using System;
using System.IO;
using System.Threading.Tasks;
using InfiniSwiss.CdpSharp;

namespace InfiniSwiss.ChromiumHtmlToPdf
{
    public class ChromiumPdfPrinter
    {
        public async Task PrintToPdfAsync(string sourceUrl, string pdfFilePath)
        {
            await PrintToPdfAsync(sourceUrl, pdfFilePath, new ChromiumExecutionOptions() {RunHeadless = true});
        }

        public async Task PrintToPdfAsync(string sourceUrl, string pdfFilePath, ChromiumExecutionOptions chromiumExecutionOptions)
        {
            using var chromiumExecutionContext = new ChromiumExecutionContext(chromiumExecutionOptions);
            await chromiumExecutionContext.StartAsync();

            var pageNavigationCommand = chromiumExecutionContext.Page.CreateNavigationCommand();
            await pageNavigationCommand.ExecuteAsync(sourceUrl);

            var pagePrintToPdfCommand = chromiumExecutionContext.Page.CreatePrintPdfCommand();
            var base64Pdf = await pagePrintToPdfCommand.ExecuteAsync();

            File.WriteAllBytes(pdfFilePath, Convert.FromBase64String(base64Pdf));
        }
    }
}
