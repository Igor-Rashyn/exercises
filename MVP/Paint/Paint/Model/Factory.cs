using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Model
{
    public class Factory : iMVP
    {
        private List<iDS> ds;
        iDS res, ress;
        public View view;
        public Bitmap bitmapModel;


        public void Save(Bitmap b, string fileName, string type)
        {
            var f = Get(type);
            f.Save(b, fileName);
        }

        public Bitmap Load(string filePath, string type)
        {
            var f = Get(type);
            return f.Load(filePath);
        }

        public iDS Get(string type)
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
        }
        private void Init()
        {
            ds = new List<iDS>();
            ds.Add(new DS_Standard());
            ds.Add(new DS_RAW());
            ds.Add(new DS_PSD());
            ds.Add(new DS_PDF());
        }


    }
}
