using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Presenter
{
    public class Presenter : iMVP
    {
        public Model.Factory model;
        public View view;
        private Bitmap b;

        public void Save(Bitmap b, string filePath, string type)
        {
            model.Save(b, filePath, type);
        }

        public void Load (string filePath, string type)
        {
            b = model.Load(filePath, type);
        }
        
        public void UpdateView ()
        {
            view.bitmapPresenter = b;

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
