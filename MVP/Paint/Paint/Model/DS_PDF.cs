using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MVP
{
    class DS_PDF : iDS
    {
        protected iDS Next;

        iDS iDS.Next
        {
            get
            {
                return Next;
            }
            set
            {
                Next = value;
            }
        }

        iDS iDS.Get(string fileName)
        {
            iDS res = null;
            if (fileName == ".pdf")
            {
                res = new DS_Standard();
            }
            else
            {
                res = null;
            }
            return res;
        }
        void iDS.Save(Bitmap b, string fileName)
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

        Bitmap iDS.Load(string fileName)
        {
            return new Bitmap(fileName);
        }

        public iDS IsReady(string extension)
        {
            iDS res = null;
            if (extension == ".pdf")
            {
                res = new DS_PDF();
            }
            else
            {
                res = this.Next.IsReady(extension);;
            }
            return res;
        }

        
    }
}
