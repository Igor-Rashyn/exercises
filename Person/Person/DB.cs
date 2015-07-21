using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Person
{
  public  class DB : iDS
    {

        private SqlCommand myCommand = null;
        private SqlConnection connect = null;
        string queryString = null;
        SqlDataReader dr = null;
        string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=master;Integrated Security=True; MultipleActiveResultSets=True";
        // Integrated Security  - Use "Windows authentication" to connect

        public void OpenConnection()
        {
            connect = new SqlConnection(connectionString);
            try
            {
                connect.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Create(List<Person> person)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                for (int i = 0; i < person.Count; i++)
                {

                    if (person[i] is Man)
                    {
                        queryString = string.Format("INSERT INTO [Table] (Id, Name, Strength, Age, Stamina) " +
                            "Values ({0}, '{1}', '{2}', {3}, '{4}')", person[i].Id, person[i].Name, ((Man)person[i]).Strength, ((Man)person[i]).Age, ((Man)person[i]).Stamina); 
                    }
                    else
                    {
                        queryString = string.Format("INSERT INTO [Table] (Id, Name, Beauty, EyeColor, Smile) " +
                            "Values ({0}, '{1}', {2}, '{3}', '{4}')", person[i].Id, person[i].Name, ((Woman)person[i]).Beauty, ((Woman)person[i]).EyeColor, ((Woman)person[i]).Smile);
                    }
                    SqlCommand command = new SqlCommand(queryString, connection);
                    if (i == 0)
                    {
                        try
                        {
                            command.Connection.Open();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                     try
                     {
                         command.ExecuteNonQuery();
                     }
                     catch (Exception e)
                     {
                         Console.WriteLine(e.ToString());
                     }
                    queryString = null;
                }              
            }

            //string sql = string.Format("Insert Into Inventory" +
            //"(CarID, Make, Color, PetName) Values('{0}','{1}','{2}','{3}')", id, make, color, petName);
            //using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            //{
            //    cmd.ExecuteNonQuery();
            //}
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = string.Format("Delete from [Table] where Id = {0}", id);
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Connection.Open();
                try
                    {
                        cmd.ExecuteNonQuery();
                    }
                catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                
            }
        }
        public void Update(int id, Person pr)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql="";
                if (Convert.ToString(pr.GetType()) == "Person.Man")
                {
                sql = string.Format("Update [Table] Set Strength = '{0}', Age= {1}, Stamina={2}  Where Id = '{3}'", ((Man)pr).Strength, ((Man)pr).Age, ((Man)pr).Stamina, id);
                }
                else if ((Convert.ToString(pr.GetType()) == "Person.Woman"))
                {
                    sql = string.Format("Update [Table] Set Beauty = {0}, EyeColor= '{1}', Smile='{2}'  Where Id = '{3}'", ((Woman)pr).Beauty, ((Woman)pr).EyeColor, ((Woman)pr).Smile, id);
                }
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

            }
       }
        public Person Read(int id)
        {
            //SqlDataReader dr = null;
            Person pr = new Person();
          using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Table] WHERE Id= "+id, connection))
                {
                    cmd.Connection.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr.GetInt32(3)==0)
                        {
                            Woman woman = new Woman();
                            woman.Id = dr.GetInt32(0);
                            woman.Name = (string)dr["Name"];
                            woman.Beauty = dr.GetInt32(5);
                            woman.EyeColor = dr.GetString(6);
                            woman.Smile = dr.GetString(7);
                            pr = woman;
                        }
                        else
                        {
                            Man man = new Man();
                            man.Id = dr.GetInt32(0);
                            man.Name = (string)dr["Name"];
                            man.Strength = dr.GetString(2);
                            man.Age = dr.GetInt32(3);
                            man.Stamina = dr.GetInt32(4);
                            pr = man;
                        }

                    }
                    dr.Close();
                }              
            }
            return pr;
        }
      public List<Person> ReadAll()
        {
            string queryString = "SELECT * FROM [Table]";
           List<Person> pr = new List<Person>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Table]", connection))
                //{
                    SqlCommand cmd = new SqlCommand(queryString, connection);
                    cmd.Connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    try
                    {
                        while (sdr.Read())
                        {
                            if (sdr.GetValue(3).ToString() == "")
                            {
                                Woman woman = new Woman();
                                woman.Id = sdr.GetInt32(0);
                                woman.Name = (string)sdr["Name"];
                                woman.Beauty = sdr.GetInt32(5);
                                woman.EyeColor = sdr.GetValue(6).ToString();
                                woman.Smile = sdr.GetValue(7).ToString();
                                pr.Add(woman);
                            }
                            else
                            {
                                Man man = new Man();
                                man.Id = sdr.GetInt32(0);
                                man.Name = (string)sdr["Name"];
                                man.Strength = sdr.GetValue(2).ToString();
                                man.Age = sdr.GetInt32(3);
                                man.Stamina = sdr.GetInt32(4);
                                pr.Add(man);
                            }
                        }
                        sdr.Close(); 
                        sdr.Dispose();
                    }
                catch (Exception ex)
                    {
                        var bb = ex.Message;
                    }

                }
            
            return pr;
        }



    }
}
