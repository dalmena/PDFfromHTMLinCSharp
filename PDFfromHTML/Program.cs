using SelectPdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateOfLiabilityPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            var htmlContent = File.ReadAllText(folder + "\\template.html");

            htmlContent = htmlContent.Replace("{{PATH}}", $@"file:\\\{folder}\");
            //htmlContent = htmlContent.Replace("{{KAKE_YOUR_OWN_KEY_IN_THE_HTML}}", "YOUR_DATABASE_VALUE");

            var converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.Letter;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.WebPageWidth = 800;
            converter.Options.WebPageHeight = 792;
            converter.Options.MarginLeft = 20;
            converter.Options.MarginBottom = 20;
            converter.Options.MarginRight = 20;
            converter.Options.MarginTop = 20;
            var doc = converter.ConvertHtmlString(htmlContent);
            doc.Save($"{folder}\\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf");
        }
    }
}
