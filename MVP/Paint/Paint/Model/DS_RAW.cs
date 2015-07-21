using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{
    class DS_RAW : iDS
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
            iDS res=null;
            if (fileName == ".raw")
            {
                res = new DS_Standard();
            }
            else
            {
                res = null;
            }
            return res;
        }
        void iDS.Save(Bitmap bmp, string fileName)
        {
            using (var ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes);
                File.WriteAllText(fileName, base64string);
            }
        }
        Bitmap iDS.Load(string fileName)
        {
            byte[] imageBytes = Convert.FromBase64String(File.ReadAllText(fileName));
            MemoryStream ms = new MemoryStream(imageBytes, 0,imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            Bitmap b = (Bitmap)image;
            return b;        
        }
        public iDS IsReady(string extension)
        {
            iDS res = null;
            if (extension == ".raw")
            {
                res = new DS_RAW();
            }
            else
            {
                res = this.Next.IsReady(extension); ;
            }
            return res;
        }
    }
}











