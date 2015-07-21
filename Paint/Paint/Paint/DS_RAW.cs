using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class DS_RAW : iDS
    {
        iDS res, ress;

        iDS iDS.Get(string fileName)
        {
            if (fileName == ".raw")
            {
                res = new DS_Standard();
            }
            else
            {
                res = null;
            }
            return null;
        }
        void iDS.Save(Bitmap bmp, string fileName) // в файл
        {
            using (var ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes);
                File.WriteAllText(fileName, base64string);
            }

             //using(MemoryStream ms = new MemoryStream())
             //{
             //       bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //      Byte[] data = new byte[ms.Length];
             //       data = ms.ToArray();
             //       File.WriteAllBytes(fileName, data);

             //}

        }
        Bitmap iDS.Load(string fileName)// из файла в пэйнт
        {
            byte[] imageBytes = Convert.FromBase64String(File.ReadAllText(fileName));
            MemoryStream ms = new MemoryStream(imageBytes, 0,imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            Bitmap b = (Bitmap)image;

            return b;
            
            //Image img = null;

            //byte[] imageData = null;
            //FileInfo fileInfo = new FileInfo(fileName);
            //FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(fs);
            //imageData = br.ReadBytes((int)fs.Length);


            //using (var mss = new MemoryStream(imageData))
            //{
            //    img = Image.FromStream(mss,true,true);
            //    bm = new Bitmap(img);

            //}
            
            //byte[] imageDate = null;
            //Image img = null;
            //Bitmap b = null;

            //using (var ms = new MemoryStream())
            //{

            //    using (var f = File.OpenRead(fileName))
            //    {
            //        byte[] buffer = new byte[f.Length];
            //        int read;
            //        while ((read = f.Read(buffer, 0, buffer.Length)) > 0)
            //        {
            //            ms.Write(buffer, 0, read);
            //        }
            //    }
            //    imageDate = ms.ToArray();
            //}

            //using (var mss = new MemoryStream(imageDate))
            //{
            //    img = Image.FromStream(mss);
            //    b = new Bitmap(img);

            //}
            //return b;
        }

    }
}











