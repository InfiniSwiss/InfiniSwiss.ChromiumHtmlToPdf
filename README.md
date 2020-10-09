
# InfiniSwiss.ChromiumHtmlToPdf
Convert HTML pages to PDF using a Chromium browser for WYSIWYG functionality.

Several libraries exist for converting HTML pages to PDF. However, the results are often not 1:1 (or WYSIWYG) as simply Print-ing from the browser.

This library aims to provide 1:1 fidelity with the browser print because it actually uses a Chromium browser. It starts a Chromium browser in headless mode and communicates with it over the [Chrome DevTools Protocol](https://chromedevtools.github.io/devtools-protocol/) using the [InfiniSwiss.CdpSharp](https://github.com/InfiniSwiss/InfiniSwiss.CdpSharp) library. 

## Getting started
To install InfiniSwiss.ChromiumHtmltoPdf, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console):

    PM> Install-Package InfiniSwiss.ChromiumHtmlToPdf

Then simply call it like so:
```
 var sourceUrl = "https://developer.mozilla.org/en-US/docs/Web/CSS/@media";
 var pdfFilePath = Path.Combine(Directory.GetCurrentDirectory(), "out.pdf");

 await new ChromiumPdfPrinter().PrintToPdfAsync(sourceUrl, pdfFilePath);
```

## Requirements
Because the library uses a real browser behind the scenes, some Chromium browser must be installed on the machine (Chrome, Edge etc). 

You can either pass in the path to the browser executable as a constructor options parameter or rely on the auto-discovery functionality of the underlying [InfiniSwiss.CdpSharp](https://github.com/InfiniSwiss/InfiniSwiss.CdpSharp) library (it will search for it in some known location as well as all of Program Files).

## Advanced usage options
The aim of this library is to make HTML to PDF printing a one-liner. If you need more control over the process (such as additional browser manipulation before printing) please consider using the [InfiniSwiss.CdpSharp](https://github.com/InfiniSwiss/InfiniSwiss.CdpSharp) library which offers an API on top of the Chrome DevTools Protocol so that you can issue commands and listen to events from the Chromium browser instance.

## License
MIT
[https://licenses.nuget.org/MIT](https://licenses.nuget.org/MIT)
