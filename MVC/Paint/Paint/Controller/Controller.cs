using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controller
{
   public class Controller : iMVC
    {
        public Model.Factory model;
        public void Save(Bitmap b, string type)
        {
            model.Save(b,type);
        }

        public void Load (string type)
        {
            model.Load(type);
        }

        public string GetFilterForSave()
        {
            return "JPG (*.jpg)|*.jpg;| BMP (*.bmp)|*.bmp;| PNG (*.png)|*.png;| PDF (*.pdf)|*.pdf | RAW (*.raw)|*.raw | PSD(*.psd)|*.psd;";
        }

        public string GetFilterForLoad()
        {
            return "JPG(*.jpg)|*.jpg;| BMP(*.bmp)|*.bmp;| PNG(*.png)|*.png; | RAW(*.raw)|*.raw; | PSD(*.psd)|*.psd;";
        }


    }
}
