using System;
using System.IO;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Translator.Text;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Drawing;
using Microsoft.AspNetCore.Mvc;
using TextConverter.Models;
using System.Diagnostics;

namespace TextConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult TranslatePdf(IFormFile uploadedFile)
        {
            string targetLanguage = "fr";
            
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                
                string subscriptionKey = "6922e5d853084d0cb8c20f3ceaafa3aa";
                Uri endpoint = new Uri("https://api.cognitive.microsofttranslator.com");

                // Initialize the Azure Translator client
                var client = new TranslationDocumentClient(new Uri(endpoint), new AzureKeyCredential(subscriptionKey));

                // Load the PDF file you want to translate
                string pdfFilePath = "input.pdf";
                string translatedPdfFilePath = "translated.pdf";
                PdfDocument pdfDocument = PdfReader.Open(pdfFilePath);

                // Create a PDF document for the translated content
                PdfDocument translatedPdfDocument = new PdfDocument();
                foreach (PdfPage page in pdfDocument.Pages)
                {
                    PdfPage translatedPage = translatedPdfDocument.AddPage(page);
                    XGraphics gfx = XGraphics.FromPdfPage(translatedPage);
                    XFont font = new XFont("Arial", 12);

                    // Extract text from the original PDF page
                    string text = ExtractTextFromPdfPage(page);

                    // Translate the text
                    string translatedText = await TranslateTextAsync(client, text, "en"); // Translate to English

                    // Draw the translated text on the new PDF page
                    gfx.DrawString(translatedText, font, XBrushes.Black, new XRect(100, 100, translatedPage.Width - 200, translatedPage.Height - 200), XStringFormats.TopLeft);
                }

                // Save the translated PDF to a new file
                translatedPdfDocument.Save(translatedPdfFilePath);

            }

            return BadRequest("No file uploaded.");
        }
        static string ExtractTextFromPdfPage(PdfPage page)
        {
            // Implement your PDF text extraction logic here
            // You can use a library like PdfSharpCore.Pdf.ContentParser to extract text
            // This depends on your specific PDF structure and formatting.
            // Example: PdfTextExtractor.GetTextFromPage(page);
            return "Original text extracted from the PDF page";
        }

        static async Task<string> TranslateTextAsync(TextTranslationClient client, string text, string targetLanguage)
        {
            var options = new TextTranslationOptions(targetLanguage);
            TranslationResult result = await client.TranslateAsync(text, options);
            return result.Value;
        }

    }
}