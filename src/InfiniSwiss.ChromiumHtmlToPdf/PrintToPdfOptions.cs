namespace InfiniSwiss.ChromiumHtmlToPdf
{
    public class PrintToPdfOptions
    {
        public bool DisplayHeaderFooter { get; set; }

        public string HeaderTemplate { get; set; }
        
        public string FooterTemplate { get; set; }

        public bool UseDefaultFooterTemplate { get; set; }
    }
}
