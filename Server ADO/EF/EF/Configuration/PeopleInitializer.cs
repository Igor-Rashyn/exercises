using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Configuration
{
    /// <summary>
    /// Класс необходим, если мы хотим установить начальные значения и изменить логику создания таблицы. Например удалять базу если она уже есть.
    /// </summary>
    public class PeopleInitializer : IDatabaseInitializer<PeopleContext>
    {
        public void InitializeDatabase (PeopleContext context)
        {
            if (context.Database.Exists())
                context.Database.Delete();
            context.Database.Create();

            context.People.Add(new Model.Man { Id = 1, Name = "Igor", Age = 28, Stamina = 10, Strength = "Strong"});
            context.People.Add(new Model.Man { Id = 2, Name = "Yuri", Age = 25, Stamina = 8, Strength = "Week" });
            context.People.Add(new Model.Woman { Id = 3, Name = "Olga", Beauty=10, EyeColor="Green", Smile="Beautiful"});
            context.People.Add(new Model.Woman { Id = 4, Name = "Varvara", Beauty = 9, EyeColor = "Grey", Smile = "Beautiful" });


            context.SaveChanges();

        }


    }
}
