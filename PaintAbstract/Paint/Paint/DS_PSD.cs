using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoshopFile;
using PaintDotNet;
//using Photoshop;
using PhotoshopFiles;
//using PhotoshopTypeLibrary;
using System.IO;
using Aspose.Imaging;




namespace Paint
{
    class DS_PSD:iDS
    {
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
            iDS res = null;
            if (fileName == ".psd")
            {
                res = new DS_Standard();
            }
            else
            {
                res = null;
            }
            return res;
        }
        public override void Save(Bitmap b, string fileName) 
        {

            string path = fileName.Substring(0,fileName.Length - 3);
            path = path + "tiff";


            b.Save( path, System.Drawing.Imaging.ImageFormat.Tiff);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(path))
                {
                    //Create an instance of PsdOptions and set it’s various properties
                    Aspose.Imaging.ImageOptions.PsdOptions psdOptions = new Aspose.Imaging.ImageOptions.PsdOptions();
                    psdOptions.ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.RGB;
                    psdOptions.CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE;
                    psdOptions.Version = 4;

                    //Save image to disk in PSD format
                    image.Save(fileName, psdOptions);
                 }

            File.Delete(path);
            
        }
        public override Bitmap Load(string fileName)
        {

            PhotoshopFiles.PsdFile psd = new PhotoshopFiles.PsdFile();
            psd.Load(fileName);
            System.Drawing.Image myPsdImage = PhotoshopFiles.ImageDecoder.DecodeImage(psd);
            return new Bitmap(myPsdImage);
        }

        public override iDS IsReady(string extension)
        {
            iDS res = null;
            if (extension == ".psd")
            {
                res = new DS_PSD();
            }
            else
            {
                res = this.Next.IsReady(extension); ;
            }
            return res;
        }
    }
}
