using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
           // //mList listt = new mList();
           
           // //listt.Add(11);
           // //listt.Add(12);
           // //listt.Add(13);
           // //listt.Reverse();
           // //listt.AddToStart(11111);

           // //Console.WriteLine(listt[0]);

           // mListiEndiStart list = new mListiEndiStart();

           // list.Add(3);
           // list.Add(2);
           // list.Add(1);
           // list.Add(4);//идет на следующий

           // //list[0] = 15;
           // list.Insert(1,11111);

           //// list.Clear();
           //// list.Insert(4,10);
           //// list.DelFirst();
           // Console.WriteLine(list[0]);
           // Console.WriteLine(list[1]);
           // Console.WriteLine(list[2]);
           // Console.WriteLine(list[3]);
           // Console.WriteLine(list[4]);
            Random random = new Random();
            int r = random.Next(1, 3);
            int value = (int)Math.Pow(-1, r);

           Console.WriteLine(value);
           r = random.Next(1, 3);
           value = (int)Math.Pow(-1, r);
           Console.WriteLine(value);
           r = random.Next(1, 3);
           value = (int)Math.Pow(-1, r);
           Console.WriteLine(value);
           r = random.Next(1, 3);
           value = (int)Math.Pow(-1, r);
           Console.WriteLine(value);
           r = random.Next(1, 3);
           value = (int)Math.Pow(-1, r);
           Console.WriteLine(value);
           r = random.Next(1, 3);
           value = (int)Math.Pow(-1, r);
           Console.WriteLine(value);
           r = random.Next(1, 3);
           value = (int)Math.Pow(-1, r);
           Console.WriteLine(value);
        }
    }
}
