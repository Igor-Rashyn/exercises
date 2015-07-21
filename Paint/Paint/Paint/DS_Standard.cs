using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class DS_Standard: iDS
    {
        string[] arrType = new string[] { ".bmp", ".jpg", ".jepg", ".png", ".gif", ".tiff" };
        iDS res, ress;

        iDS iDS.Get(string fileName)
        {
            for (int i = 0; i < arrType.Length; i++)
            {
                if (fileName == arrType[i])
                {
                    ress = new DS_Standard();
                }
                else
                    res = null;
            }
            res = ress;
            return ress;
        }
        void iDS.Save(Bitmap b, string fileName) // в файл
        {
            var formatFile = fileName;
            formatFile = formatFile.Substring(formatFile.Length - 3);

            switch (formatFile)
            {
                case "bmp":
                    b.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case "jepg":
                case "jpg":
                    b.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case "png":
                    b.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case "gif":
                    b.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
                case "tiff":
                    b.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                    break;
            }           
        }
        Bitmap iDS.Load(string fileName)// из файла в пэйнт
        {
          return new Bitmap(fileName);
        }
       


    }
}
