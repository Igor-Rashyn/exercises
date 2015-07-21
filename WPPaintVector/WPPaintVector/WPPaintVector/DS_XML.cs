using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Xml;
using System.IO.IsolatedStorage;
using System.IO;

namespace WPPaintVector
{
    public class DS_XML
    {
        string line;
        List<myFigure> fg = new List<myFigure>();
        string[] strArr;
        Point startPoint;
        Point endPoint;

        Color color;
        int height;
        int width;
        int thickness;
        string tp;



        // char charArr = ',';


        public void Save(List<myFigure> fg)
        {
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

            //create new file
            using (StreamWriter sw = new StreamWriter(new IsolatedStorageFileStream("myFile.xml", FileMode.Create, FileAccess.Write, myIsolatedStorage)))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine("<Figures>");
                for (int i = 0; i < fg.Count; i++)
                {
                    sw.WriteLine(
                 Convert.ToString("<" + "Figure" + ">" + "\n" +
                 "<" + "type" + ">" + fg[i].ShapeF + "</" + "type" + ">" + "\n" +
                 "<" + "Color" + ">" + fg[i].ColorF + "</" + "Color" + ">" + "\n" +
                 "<" + "Height" + ">" + fg[i].Height + "</" + "Height" + ">" + "\n" +
                 "<" + "Width" + ">" + fg[i].Width + "</" + "Width" + ">" + "\n" +
//"<" + "Thickness" + ">" + fg[i].thickness + "</" + "Thickness" + ">" + "\n" +
                 "<" + "StartPosition" + ">" + fg[i].StartPoint + "</" + "Position" + ">" + "\n" +
                 "<" + "EndPosition" + ">" + fg[i].EndPoint + "</" + "Position" + ">" + "\n" +
                 "</" + "Figure" + ">"));
                }
                sw.WriteLine("</Figures>");
                sw.Close();
            }
        }



        public List<myFigure> Load()
        {
            string line;
            string[] strArr;
            char[] charArr = { '<', '>', '/', '"' };
            var dr = new List<myFigure>();
            string str = "", type = "";


            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile("myFile.xml", FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fileStream))
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
                            if (line != "<Figures>" && line != "</Figures>" && line != "</Figure>" && line != "<Figure>")
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
                        string[] cl = strArr2[5].Split('[', ']');
                        color = this.ConvertStringToColor(strArr2[5]);
                        string[] position = strArr2[14].Split('=', ',', '}');
                        startPoint.X = Convert.ToInt32(position[0]);
                        startPoint.Y = Convert.ToInt32(position[1]);
                        height = Convert.ToInt32(strArr2[8]);
                        width = Convert.ToInt32(strArr2[11]);
                        string[] endPosition = strArr2[17].Split('=', ',', '}');
                        endPoint.X = Convert.ToInt32(endPosition[0]);
                        endPoint.Y = Convert.ToInt32(endPosition[1]);
                        //thickness = Convert.ToInt32(strArr2[14]);
                        tp = strArr2[2];
                        str = "";
                    }
                    fg.Add(new myFigure(color, tp, width, height, startPoint, endPoint));
                }
            }
            return fg;
        }


        public Color ConvertStringToColor(String hex)
        {
            //remove the # at the front
            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;

            //handle ARGB strings (8 characters long)
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            //convert RGB characters to bytes
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }


    }
}
