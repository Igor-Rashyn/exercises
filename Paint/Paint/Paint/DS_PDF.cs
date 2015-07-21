using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Paint
{
    class DS_PDF : iDS
    {
        iDS res, ress;

        iDS iDS.Get(string fileName)
        {
            if (fileName == ".pdf")
            {
                res = new DS_Standard();
            }
            else
            {
                res = null;
            }
            return null;
        }
        void iDS.Save(Bitmap b, string fileName) // в файл
        {
            var doc = new Document(PageSize.A4);
            try
            {
                System.Drawing.Image image = b;
                PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
                doc.Open();
                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                doc.Add(pic);
                doc.Close();
            }
            catch (Exception ex)
            {

            }

        }
        Bitmap iDS.Load(string fileName)// из файла в пэйнт
        {
            return new Bitmap(fileName);
        }


    }
}
