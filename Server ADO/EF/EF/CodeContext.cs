using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Model;

namespace EF
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(string connectionString = "PeopleContext")
            : base(connectionString)
        {

        }

        public DbSet<Person> People { get; set; }

        /// <summary>
        /// определяем структуру БД, будет состоять из одной таблицы или с многих. По умолчанию производные класс объединяются в одну таблицу. Но если нужно изменить имя столбца или значений необходимо перегружать метод и определять как ты хочешь.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // Mapping the Table-Per-Hierarchy (TPH) Inheritance
            modelBuilder.Entity<Person>()
                .Map<Woman>(m => m.Requires("Gender").HasValue("Woman"))
                .Map<Man>(m => m.Requires("Gender").HasValue("Man"));

            //Mapping the Table-Per-Type (TPT) Inheritance
            //modelBuilder.Entity<Woman>().ToTable("Woman");  
            // modelBuilder.Entity<Man>().ToTable("Man");
            //modelBuilder.Entity<Person>().ToTable("Person");
        }

    }
}
