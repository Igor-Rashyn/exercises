using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tr = new Tree();
            tr.Add(12);
            tr.Add(45);
            tr.Add(10);
            tr.Add(25);
            tr.Add(75);
            tr.Add(39);
            tr.Add(11);
            tr.Add(2);
            tr.Add(5);
            tr.Add(1);// 11 штук
            tr.Add(22);
            tr.Add(42);
            tr.Add(40);
            tr.Add(43); // 15
            tr.Add(3);
            tr.Add(6);
            var tt = tr.Height();
            var v = tr.Size();
            tr.Delete(6);
            var vb = tr.Size();

         //  var bb = tr.Sort();
         //  var v = tr.Size();
            // подумать над тем что должно случиться если одиновый!!!!!!!!!!!!!!!!!!!!!!!

        //  var bb = tr.Find(10); // подумать как уменьшить количество возвращений. Подумать, что возвращать если такого нет значения
         //  var zz = tr.Size();
           //tr.Delete(12);
        //   var ss = tr.Height(); // разобраться!!!!!!!!!!!!
          // var vv = tr.NodeSize(tr.Left);
           //var vv1 = tr.Width();
          // var nn = tr.Sort();
        }
    }
}
