using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2
{
    public class calOperations
    {
            static double a;
            static double b;
            string sum;

        // Операции
            public string Action(double x, double y, string signIn)
            {
                a = x;
                b = y;
               switch (signIn)
                    {
                        case "+":
                            a = a + b;
                            break;
                        case "-":
                            a = a - b;
                            break;
                        case "*":
                            a = a * b;
                            break;
                        case "/":
                            if (b == 0)
                            {
                             break;
                            }
                            else
                            {
                                a = a / b;
                                break;
                            }
                        case "=":
                            a = b;
                            break;
                        default:
                            a = b;
                            break;

                    }
               if (signIn == "/" && b == 0)
               {
                   return sum = "Деление на ноль";
               }
               else
               {
                   return sum = Convert.ToString(a);
               }
            }

            //----------------------------

       

    }
}
