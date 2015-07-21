using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using EF;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
           // iDS_EF ef = new iDS_EF();
           //var ss = ef.Read(1);


           //Console.WriteLine(ss.Name);
           //Console.ReadKey();


           Console.Title = "SERVER";
            // Указание адреса, где ожидать входящие сообщения.
            // Uri address = new Uri("http://localhost:2000/IService"); // ADDRESS
            // Указание привязка, как обмениваться сообщениями
            // BasicHttpBinding binding = new BasicHttpBinding(); // BINDING

            // Указание контракта
            // Type contract = typeof(IService);
           
            // Создание провайдера Хостинга с указанием Сервиса
             ServiceHost host = new ServiceHost(typeof(Service));

            // Добавление "Конечной Точки"
            //  host.AddServiceEndpoint(contract,binding,address);
            
            // Начало ожидания прихода сообщений.
             host.Open();
            //var context = new EF.ModelFirst.Person();
            //foreach (var table in context.Tables)
            //{
            //    Console.WriteLine("{0}: {1} - {2}", table.Id, table.Name, table.Age);
            //}
             Console.WriteLine("Open");
             Console.ReadKey();
        }
    }
}
