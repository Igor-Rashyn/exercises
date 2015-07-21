using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintVector
{
    class DS_XML
    {
        string line;
        List<Figure> fg = new List<Figure>();
        string[] strArr;
        Point point;

        Color color;
        int height;
        int width;
        int thickness;
        string tp;  



       // char charArr = ',';


    public  void Save(string path, List<Figure> fg)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine("<Figures>");
                for (int i = 0; i < fg.Count; i++)
                {
                    sw.WriteLine(
                 Convert.ToString("<" + "Figure" + ">" + "\n" +
                 "<" + "type" + ">" + fg[i].type + "</" + "type" + ">" + "\n" +
                 "<" + "Color" + ">" + fg[i].color + "</" + "Color" + ">" + "\n" +
                 "<" + "Height" + ">" + fg[i].height + "</" + "Height" + ">" + "\n" +
                 "<" + "Width" + ">" + fg[i].width + "</" + "Width" + ">" + "\n" +
                 "<" + "Thickness" + ">" + fg[i].thickness + "</" + "Thickness" + ">" + "\n" +
                 "<" + "Position" + ">" + fg[i].position + "</" + "Position" + ">" + "\n" +
                 "</" + "Figure" + ">"));
                }
                sw.WriteLine("</Figures>");
            }

        }



    public List<Figure> Load(string path)
    {
        string line;
        string[] strArr;
        char[] charArr = { '<', '>', '/', '"' };
        var dr = new List<Figure>();
        string str = "", type = "";

        using (StreamReader sr = new StreamReader(path))
        {
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                strArr = line.Split(charArr);
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (strArr[i] == "type")
                    {
                        type = strArr[2];
                    }
                    if (strArr[i] != "" && line != "<?xml version=\"1.0\" encoding=\"utf-8\"?>")
                        if (line != "<Figures>" && line != "</Figures>" && line != "</Figure>"&& line!="<Figure>")
                        {
                            str = str + ";" + strArr[i];
                        }                          
                }

                if (type == "")
                {
                    str = "";
                }

                if (line == "</Figure>" && type != "")
                {
                    string[] strArr2 = str.Split(';');
                            string [] cl = strArr2[5].Split('[',']');
                            color = Color.FromName(cl[1]);
                            string[] position = strArr2[17].Split('=',',','}');
                            point.X= Convert.ToInt32(position[1]);
                            point.Y = Convert.ToInt32(position[3]);
                            height = Convert.ToInt32(strArr2[8]);
                            width = Convert.ToInt32(strArr2[11]);
                            thickness = Convert.ToInt32(strArr2[14]);
                            tp = strArr2[2];                         
                            str = "";
                }
                fg.Add(new Figure(color, point, thickness, width, height, tp));
            }
        }
        return fg;
    }

    }
}
