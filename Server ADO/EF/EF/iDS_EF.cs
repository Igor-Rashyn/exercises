using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Model;

namespace EF
{
    public class iDS_EF : iDS
    {
        private SqlCommand myCommand = null;
        private SqlConnection connect = null;
        string queryString = null;
        SqlDataReader dr = null;
        string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=master;Integrated Security=True; MultipleActiveResultSets=True";
        PeopleContext context;


        public string Connection()
        {
            //Database.SetInitializer(new Configuration.PeopleInitializer());   // если хотим изменить инициализацию БД

            context = new PeopleContext();
           // db.Database.Initialize(false); // запускаем инициализацию БД
            var people = context.People.ToList();
            var ss = people.Count();
            return Convert.ToString(ss);
            //// Database.SetInitializer(new System.Data.Entity.CreateDatabaseIfNotExists<CodeContext>);
            //using (var ctx = new CodeContext("Person"))
            //{
            //    var people = ctx.People.ToList();
            //    var ss = people.Count();
            //    return Convert.ToString(ss);
            //    //Console.WriteLine(people.Count);
            //}

        }

        public List<Person> ReadAll()
        {
            context = new PeopleContext();
            var people = context.People.ToList();
            return people;
        }

        public Person Read (int id)
        {
            context = new PeopleContext();
            var person = context.People.Find(id);

           // var customer = context.People.First(c => c.Id = 5);

            return person;
        }

        public void Insert (List<Person> people)
        {
            context = new PeopleContext();
            for (int i = 0; i<people.Count; i++)
            {
                if (people[i] is Man)
                {
                    context.People.Add(new Model.Man { Id = people[i].Id, Name = people[i].Name, Age = ((Man)people[i]).Age, Stamina = ((Man)people[i]).Stamina, Strength = ((Man)people[i]).Strength });
                } 
                else if (people[i] is Woman)
                {
                    context.People.Add(new Model.Woman { Id = people[i].Id, Name = people[i].Name, Beauty = ((Woman)people[i]).Beauty, EyeColor = ((Woman)people[i]).EyeColor, Smile = ((Woman)people[i]).Smile });
                }
                context.SaveChanges();
            }

        }

        public void Delete (int id)
        {
            context = new PeopleContext();
            var person = context.People.First(i => i.Id==id);
            //context.People.DeleteObject(person);
            context.People.Remove(person);
            context.SaveChanges();
        }

        public void Update (int id, Person pr)
        {
            context = new PeopleContext();
            var person = context.People.First(i => i.Id == id);
            if (person is Man)
            {
               ((Man)person).Stamina=((Man)pr).Stamina;
               ((Man)person).Strength = ((Man)pr).Strength;
               ((Man)person).Age = ((Man)pr).Age;
            }
            else if (person is Woman)
            {
               ((Woman)person).Smile=((Woman)pr).Smile;
               ((Woman)person).EyeColor = ((Woman)pr).EyeColor;
               ((Woman)person).Beauty = ((Woman)pr).Beauty;

            }
            context.SaveChanges();
        }


    }
}
