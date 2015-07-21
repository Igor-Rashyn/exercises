using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyLibrary
{
    public class Card:Diary
    {
        public int NumberCard;
        public string NameCard;
        string line;
        Diary dr;
        string[] strArr;
        char charArr = ',';

        public override string WriteXML(Diary par, int i)
        {
            return line = Convert.ToString("<" + "Element id=\"" + i + "\"" + ">" + "\n" +
                  "<" + "type" + ">" + par.GetType() + "</" + "type" + ">" + "\n" +
                  "<" + "Id" + ">" + par.Id + "</" + "Id" + ">" + "\n" +
                  "<" + "Name" + ">" + par.Name + "</" + "Name" + ">" + "\n" +
                  "<" + "NameCard" + ">" + ((Card)par).NameCard + "</" + "NameCard" + ">" + "\n" +
                  "<" + "NumberCard" + ">" + ((Card)par).NumberCard + "</" + "NumberCard" + ">" + "\n" +
                  "<" + "PhoneType" + "/>" + "\n" +
                  "<" + "Phone" + "/>" + "\n" +
                  "</" + "Element" + ">");      
        }
        public override Diary ReadXML(string line) 
        {
            strArr = line.Split(';');
            this.Id = Convert.ToInt32(strArr[7]);
            this.Name = strArr[10];
            this.NameCard = strArr[13];
            this.NumberCard = Convert.ToInt32(strArr[16]);
            return this;
        
        }
        public override string WriteCSV(Diary par)
        {
        return line = Convert.ToString((par.GetType() + "," + par.Id + "," + par.Name + "," + ((Card)par).NameCard + "," + ((Card)par).NumberCard));
        }
        public override Diary ReadCSV(string line) 
        {
            strArr = line.Split(charArr);
            this.Id = Convert.ToInt32(strArr[1]);
            this.Name = strArr[2];
            this.NameCard = strArr[3];
            this.NumberCard = Convert.ToInt32(strArr[4]);
            return this;
        }
        public override string WriteJSON(Diary par)
        {
            return line = Convert.ToString("\"Type\":"  + "\"" + par.GetType() + "\"" + ","+ "\n" +
                                           "\"Id\":"  + "\"" + par.Id + "\"" + "," + "\n" +
                                           "\"Name\":"  + "\"" + par.Name + "\"" + "," + "\n" +
                                           "\"NameCard\":"  + "\"" + ((Card)par).NameCard + "\"" + "," + "\n" +
                                           "\"NumberCard\":"  + "\"" + ((Card)par).NumberCard + "\"" + ","); 
         }
        public override Diary ReadJSON(string line) 
        {
            strArr = line.Split(';');
            this.Id = Convert.ToInt32(strArr[9]);
            this.Name = strArr[14];
            this.NameCard = strArr[19];
            this.NumberCard = Convert.ToInt32(strArr[24]);
            return this;
        }
        public override string WriteYAML(Diary par, int i)
        {
            return line = Convert.ToString("    " + "Type:"       +  par.GetType()          + "\n" +
                                           "    " + "Id:"         +  par.Id                 + "\n" +
                                           "    " + "Name:"       +  par.Name               + "\n" +
                                           "    " + "NameCard:"   +  ((Card)par).NameCard   + "\n" +
                                           "    " + "NumberCard:" +  ((Card)par).NumberCard + "\n" +
                                           "    " + "PhoneType:"                            + "\n" +
                                           "    " + "Phone:"                                + "\n");
        }
        public override Diary ReadYAML(string line)
        {
            strArr = line.Split(';');
            this.Id = Convert.ToInt32(strArr[4]);
            this.Name = strArr[6];
            this.NameCard = strArr[8];
            this.NumberCard = Convert.ToInt32(strArr[10]);
            return this;

        }



    }
}
