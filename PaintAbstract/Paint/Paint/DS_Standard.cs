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
        //protected iDS Next;

        //iDS iDS.Next
        //{
        //    get
        //    {
        //        return Next;
        //    }
        //    set
        //    {
        //        Next = value;
        //    }
        //}


        public override iDS Get(string fileName)
        {
            iDS res, ress = null;

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
        public override void Save(Bitmap b, string fileName)
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
        public override Bitmap Load(string fileName)
        {
          return new Bitmap(fileName);
        }

        public override iDS IsReady(string extension)
        {
            iDS res =null;
            for (int i = 0; i < arrType.Length; i++)
            {
                if (extension == arrType[i])
                {
                    res = new DS_Standard();
                }
            }
            if (res == null)
            {
                res = this.Next.IsReady(extension);
            }
            return res;
        }

    }
}
