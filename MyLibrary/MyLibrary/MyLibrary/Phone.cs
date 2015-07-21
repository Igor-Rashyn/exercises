using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyLibrary
{
    public class Phone:Diary
    {
       public int PhoneNumber;
       public string PhoneType;
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
                  "<" + "NameCard" + "/>" + "\n" +
                  "<" + "NumberCard" + "/>" + "\n" +
                  "<" + "PhoneType" + ">" + ((Phone)par).PhoneType + "</" + "PhoneType" + ">" + "\n" +
                  "<" + "PhoneNumber" + ">" + ((Phone)par).PhoneNumber + "</" + "PhoneNumber" + ">" + "\n" +
                  "</" + "Element" + ">");
       }
       public override Diary ReadXML(string line) 
       {
           strArr = line.Split(';');
           this.Id = Convert.ToInt32(strArr[7]);
           this.Name = strArr[10];
           this.PhoneType = strArr[15];
           this.PhoneNumber = Convert.ToInt32(strArr[18]);
           return this;
       }
       public override string WriteCSV(Diary par)
       {
          return line = Convert.ToString(par.GetType() + "," + par.Id + "," + par.Name + "," + ((Phone)par).PhoneType + "," + ((Phone)par).PhoneNumber);
       }
       public override Diary ReadCSV(string line)
       {
           strArr = line.Split(charArr);
           this.Id = Convert.ToInt32(strArr[1]);
           this.Name = strArr[2];
           this.PhoneType = strArr[3];
           this.PhoneNumber = Convert.ToInt32(strArr[4]);

           return this;
       }
       public override string WriteJSON(Diary par)
       {
           return line = Convert.ToString("\"Type\":" + "\"" + par.GetType() + "\"" + "," + "\n" +
                                   "\"Id\":"  + "\"" + par.Id + "\"" + "," + "\n" +
                                   "\"Name\":" + "\"" + par.Name + "\"" + "," + "\n" +
                                   "\"PhoneType\":" + "\"" + ((Phone)par).PhoneType + "\"" + "," + "\n" +
                                   "\"PhoneNumber\":" + "\"" + ((Phone)par).PhoneNumber + "\"" + ",");      
       }
       public override Diary ReadJSON(string line) {
           strArr = line.Split(';');
           this.Id = Convert.ToInt32(strArr[9]);
           this.Name = strArr[14];
           this.PhoneType = strArr[19];
           this.PhoneNumber = Convert.ToInt32(strArr[24]);
           return this;
       
       }
       public override string WriteYAML(Diary par, int i)
       {
           return line = Convert.ToString( "    " + "Type:"      +  par.GetType()          + "\n" +
                                           "    " + "Id:"        +  par.Id                 + "\n" +
                                           "    " + "Name:"      +  par.Name               + "\n" +
                                           "    " + "NameCard:"                            + "\n" +
                                           "    " + "NumberCard:"                          + "\n" +
                                           "    " + "PhoneType:" + ((Phone)par).PhoneType   + "\n" +
                                           "    " + "Phone:"     + ((Phone)par).PhoneNumber + "\n");
       }






       public override Diary ReadYAML(string line)
       {
           strArr = line.Split(';');
           this.Id = Convert.ToInt32(strArr[4]);
           this.Name = strArr[6];
           this.PhoneType = strArr[12];
           this.PhoneNumber = Convert.ToInt32(strArr[14]);
           return this;
       }



    }
}
