using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server_TTT
{
    class Program
    {
        static void Main(string[] args)
        {
            string prefixes = "http://127.0.0.1:2000/";
            Server server = new Server();
            try
            {
                server.Start(prefixes);
            }
            catch
            {
                server.Dispose();
            }
        }
    }
}
