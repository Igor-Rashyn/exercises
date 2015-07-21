using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singltooon
{
    class Program
    {
        static void Main(string[] args)
        {
            var bb= Singleton.Instance;
            var aa = Singleton.Instance;

            var vv = new MySingleton() ;
            var dd = new MySingleton();

            
        }
    }

    public sealed class Singleton // не позволяет наследоваться от этого класса. Нельзя переопределить методы и т.д.
    {
        private static Singleton instance = null; // мы создаем поле с типом нашего класса и зануляем его
        //Ключевое слово private является модификатором доступа к члену.
        //Доступ к закрытым членам можно получить только внутри тела класса или структуры, в которой они объявлены
        // Static класс нужен, если тебе нужен класс создания объектов которого нецелесообразно
        //Например если в классе сделать static int - то это int не будет привязан к созданному объекту, т.е. его можно будет использовать скажем как глобальный счетчик количества созданных экземпляров.
        // Каждый раз когда создаются экземпляры класса, вызывается конструктор. 
       //Класс может иметь несколько конструкторов, принимающих различные аргументы. Позволяте устанавливать значения по умолчанию
        // Если конструктор не описан, то C# сам создат конструктор который будет publicи установит значения по умолчанию
        // Конструкторы имеют то же имя, что и класс или структура, и они обычно инициализируют элементы данных нового объекта.
        private Singleton()  
        {
        }
       
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }


    public sealed class MySingleton
    {

       private  MySingleton test;

       private MySingleton()
        {

        }
        
       
        public MySingleton GetMySingelton()
        {
            if (test == null)
            {
                test = new MySingleton();
            }
                return test;
        }

    }

    
}
