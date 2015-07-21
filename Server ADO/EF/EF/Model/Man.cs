using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model
{
    public class Man : Person
    {
        private string strength;
        private int age;
        private int stamina;
        [NotMapped] // не создавать в БД
        string line;

        [StringLength(50)]
        public string Strength { get; set; }
        public int Age { get; set; }
        public int Stamina { get; set; }

        public Man(int id, string name, string str, int age, int stam)
        {
            this.Id = id;
            this.Name = name;
            this.Strength = str;
            this.Age = age;
            this.Stamina = stam;
        }
        public Man()
        {
            this.Id = 0;
            this.Name = null;
            this.Strength = null;
            this.Age = 0;
            this.Stamina = 0;
        }
        public override string WriteCSV(Person per)
        {
            return line = Convert.ToString((per.GetType() + "," + per.Id + "," + per.Name + "," + ((Man)per).Strength + "," + ((Man)per).Age + "," + ((Man)per).Stamina));
        }
        public override string WriteToHtml(Person per)
        {
            string aa = "<td>" + "<img src=\"ok.png\" class=\"btn btn-success btn-xs\" onclick=\"editPerson(this)\" alt=\"" + per.Id + "\">" + "<img src=\"remove.png\" class=\"btn btn-danger btn-xs\" onclick=\"deletePerson(this)\" alt = \"" + per.Id + "\">" + "</td>";
            return line = aa + "<td>" + per.Id + "</td>" + "<td>" + per.Name + "</td>" + "<td>" + ((Man)per).Strength + "</td>" + "<td>" + ((Man)per).Age + "</td>" + "<td>" + ((Man)per).Stamina + "</td>" + "<td>" + "</td>" + "<td>" + "</td>" + "<td>" + "</td>" + "<td>M</td>";
        }

    }
}
