using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model
{
   public class Woman:Person
    {
        int beauty;
        string eyeColor;
        string smile;
        [NotMapped]
        string line;

        public int Beauty { get; set; }
        [StringLength(50)]
        public string EyeColor { get; set; }
        [StringLength(50)]
        public string Smile { get; set; }
        public Woman(int id, string name, int bt, string color, string sm)
        {
            this.Id = id;
            this.Name = name;
            this.Beauty = bt;
            this.EyeColor = color;
            this.Smile = sm;
        }
        public Woman()
        {
            this.Id = 0;
            this.Name = null;
            this.Beauty = 0;
            this.EyeColor = null;
            this.Smile = null;
        }
        public override string WriteCSV(Person per)
        {
            return line = Convert.ToString((per.GetType() + "," + per.Id + "," + per.Name + "," + ((Woman)per).Beauty + "," + ((Woman)per).EyeColor + "," + ((Woman)per).Smile));
        }

        public override string WriteToHtml(Person per)
        {
            string aa = "<td>" + "<img src=\"ok.png\" class=\"btn btn-success btn-xs\" onclick=\"editPerson(this)\" alt=\"" + per.Id + "\">" + "<img src=\"remove.png\" class=\"btn btn-danger btn-xs\" onclick=\"deletePerson(this)\" alt = \"" + per.Id + "\">" + "</td>";
            return line = aa + "<td>" + per.Id + "</td>" + "<td>" + per.Name + "</td>" + "</td>" + "<td>" + "</td>" + "<td>" + "</td>" + "<td>" + "</td>" + "<td>" + ((Woman)per).Beauty + "</td>" + "<td>" + ((Woman)per).EyeColor + "</td>" + "<td>" + ((Woman)per).Smile + "</td>" + "<td>W</td>";
        }


    }
}
