using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using Microsoft.AspNetCore.Mvc;
using Xceed.Words.NET;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CurriculumViewer.ApplicationServices.Services
{
    public class DocxGeneratorService : IGeneratorService<DocX>
    {
        public DocxGeneratorService()
        {
            Setup();
        }

        public void Setup()
        {
            if (!Directory.Exists("temp"))
            {
                Directory.CreateDirectory("temp");
            }
        }

        public MemoryStream GenerateGuide(int id)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                //Create a new PDF document
                PdfDocument document = new PdfDocument();

                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for the page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //Draw the text
                graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

                //Saving the PDF to the MemoryStream

                document.Save(ms);

                //Set the position as '0'.
                ms.Position = 0;

                //Download the PDF document in the browser
                return ms;
            }
        }
    }
}
