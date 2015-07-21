using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
     static class Factory
    {
        static private List<iDS> ds;
        static iDS res, ress;

        static public iDS Get(string type)
        {          
            if (ds == null)
            {
                Init();
            }
            foreach (var dss in ds)
            {
                res = dss.Get(type);
                if (res != null)
                {
                    ress = res;
                }
            }
            return ress;

            //switch (type)
            //{
            //    case "pdf":
            //        return new DS_PDF();
            //    case "raw":
            //        return new DS_RAW();
            //    case "psd":
            //        return new DS_PSD();
            //    case "png":
            //    case "bmp":
            //    case "jpg":
            //    default:
            //        return new DS_Standard();
            //}
        }
        static private void Init()
        {
            ds = new List<iDS>();
            ds.Add(new DS_Standard());
            ds.Add(new DS_RAW());
            ds.Add(new DS_PSD());
            ds.Add(new DS_PDF());
        }
        static public string GetFilterForSave()
        {
            return "JPG (*.jpg)|*.jpg;|BMP (*.bmp)|*.bmp;|PNG (*.png)|*.png;|PDF (*.pdf)|*.pdf;|RAW (*.raw)|*.raw;|PSD(*.psd)|*.psd;";
        }
        static public string GetFilterForLoad()
        {
            return "JPG(*.jpg)|*.jpg;|BMP(*.bmp)|*.bmp;|PNG(*.png)|*.png; |RAW(*.raw)|*.raw;|PSD(*.psd)|*.psd;";
        }
    }
}
