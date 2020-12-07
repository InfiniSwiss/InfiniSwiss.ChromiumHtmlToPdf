using System;
using System.IO;
using System.Threading.Tasks;
using InfiniSwiss.CdpSharp;
using InfiniSwiss.CdpSharp.Commands.Page.Printing;

namespace InfiniSwiss.ChromiumHtmlToPdf
{
    public class ChromiumPdfPrinter
    {
        public async Task PrintToPdfAsync(string sourceUrl, string pdfFilePath)
        {
            await PrintToPdfAsync(sourceUrl, pdfFilePath, new ChromiumExecutionOptions() {RunHeadless = true});
        }

        public async Task PrintToPdfAsync(string sourceUrl, string pdfFilePath, ChromiumExecutionOptions chromiumExecutionOptions, PrintToPdfOptions options = null)
        {
            using var chromiumExecutionContext = new ChromiumExecutionContext(chromiumExecutionOptions);
            await chromiumExecutionContext.StartAsync();

            var pageNavigationCommand = chromiumExecutionContext.Page.CreateNavigationCommand();
            await pageNavigationCommand.ExecuteAsync(sourceUrl);

            var pagePrintToPdfCommand = chromiumExecutionContext.Page.CreatePrintPdfCommand();

            if (options != null)
            {
                pagePrintToPdfCommand.DisplayHeaderFooter = options.DisplayHeaderFooter;

                if (!string.IsNullOrEmpty(options.HeaderTemplate))
                {
                    pagePrintToPdfCommand.HeaderTemplate = options.HeaderTemplate;
                }

                if (options.UseDefaultFooterTemplate || !string.IsNullOrEmpty(options.FooterTemplate))
                {
                    pagePrintToPdfCommand.FooterTemplate = options.UseDefaultFooterTemplate ? CdpPagePrintPdfCommand.DefaultFooterTemplate : options.FooterTemplate;
                }
            }
            
            var base64Pdf = await pagePrintToPdfCommand.ExecuteAsync();

            File.WriteAllBytes(pdfFilePath, Convert.FromBase64String(base64Pdf));
        }
    }
}
