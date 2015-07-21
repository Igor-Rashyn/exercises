using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model
{
    public class Person
    {
        private int id;
        private string name;
        string line;

        [Key] // ключ
        public int Id { set; get; }
        [Required] // требуемый
        [StringLength(50, ErrorMessage = "Firsr name cannot be longer than 50 characters")]
        [Display(Name = "First Name")]
        [Column("FirstName")]
        public string Name { set; get; }
        public virtual string WriteCSV(Person per) { return line; }
        public virtual string WriteToHtml(Person per) { return line; }
    }
}
