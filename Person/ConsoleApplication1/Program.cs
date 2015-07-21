using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    /// <summary>
    /// This TCP server which is connected to the database. 
    /// This server handles all requests from client and is a link between the database and client.
    /// </summary>
    class Program
    {
        static TcpListener tcpListener; 
        static Thread listenThread;
        static List<TcpClient> clients = new List<TcpClient>(); 
        static List<NetworkStream> netStreams = new List<NetworkStream>();
        static List<Person.Person> people;
        static string result;
        static Person.DB db;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Server Started...");
                tcpListener = new TcpListener(IPAddress.Any, 2000);
                listenThread = new Thread(new ThreadStart(ListenThread));
                listenThread.Start();
                db = new Person.DB();
                people = new List<Person.Person>();
                //people.Add(new Person.Man(1, "Igor", "Weak", 25, 20));
                //people.Add(new Person.Woman(2, "Margo", 10, "Gree", "Sha"));
                //people.Add(new Person.Man(3, "Seva", "Weak", 5, 2));
                //people.Add(new Person.Woman(4, "Rita", 10, "Grey", "Fa"));

                //people.Add(new Person.Man(5, "Igor", "Weak", 25, 20));
                //people.Add(new Person.Woman(6, "Margo", 10, "Gree", "Sha"));
                //people.Add(new Person.Man(7, "Seva", "Weak", 5, 2));
                //people.Add(new Person.Woman(8, "Rita", 10, "Grey", "Fa"));


                //people.Add(new Person.Man(10, "Igor", "Weak", 25, 20));
                //people.Add(new Person.Woman(11, "Margo", 10, "Gree", "Sha"));
                //people.Add(new Person.Man(12, "Seva", "Weak", 5, 2));
                //people.Add(new Person.Woman(13, "Rita", 10, "Grey", "Fa"));

                //crud.Create(people);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                Disconnect();
            }
        }
        /// <summary>
        /// Close the server
        /// </summary>
        static void Disconnect()
        {
            tcpListener.Stop(); 
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); 
                netStreams[i].Close();
            }
            Environment.Exit(0); 
        }
        /// <summary>
        /// Send data to a client
        /// </summary>
        /// <param name="id"></param>
        static void SendDataToClient(int id)
        {
            for (int i = 0; i < netStreams.Count; i++)
            {
                if (id == i)
                {
                    byte[] toSend = Encoding.ASCII.GetBytes(result);
                    netStreams[i].Write(toSend, 0, toSend.Length);
                    netStreams[i].Flush();
                }
            }

        }


        static void SendDataToHtml(int id)
        {
            int i = result.Length+6;
            StreamWriter sw = new StreamWriter(new BufferedStream(clients[id].GetStream()));
            sw.Write("HTTP/1.0 200 OK \r\n");
            sw.Write("Status: 200 OK \r\n");
            sw.Write("Content-Type: text/html; charset=utf-8 \r\n");
            sw.Write("Access-Control-Allow-Origin: *\r\n");
            sw.Write("Content-Length: " + i + "\r\n");
            sw.Write("Connection: close\r\n");

            //sw.Write("\n");
          //  sw.Write("Current Time: " + DateTime.Now.ToString() + System.Environment.NewLine);
            sw.Write("\r\n\r\n");
            sw.Write(result);
            sw.Write("\r\n\r\n");
            sw.Flush();


            //byte[] fileContent = Encoding.ASCII.GetBytes(result);
            //string statusLine = "HTTP/1.0 200 OK" + System.Environment.NewLine;
            //string contentType = "Content-type: text/HTML" + System.Environment.NewLine;
            //string contentLength = "Content-length: " + fileContent.Length + System.Environment.NewLine;
            //System.Text.UnicodeEncoding coding = new UnicodeEncoding();
            //byte[] headers = coding.GetBytes(statusLine + contentType + contentLength);
            //netStreams[id].Write(headers, 0, headers.Length);
            //netStreams[id].Write(fileContent, 0, fileContent.Length);
            //netStreams[id].Flush();


        }


        /// <summary>
        /// Prepare the data for a client
        /// </summary>
        /// <returns></returns>
        static string DataPreparation()
        {
            string str=null;

            for (int i = 0; i < people.Count; i++)
                {
                    str=str+people[i].WriteCSV(people[i])+",";
                }

                return str;
        }
        /// <summary>
        /// Method for obtaining and processing the client's request
        /// </summary>
        /// <param name="ID"></param>
        static void ClientRequest(object ID)
        {
            int thisID = (int)ID;
            byte[] requestB = new byte[2545];
            string request = null;       
            while (true)
            {
                try
                {
                    netStreams[thisID].Read(requestB, 0, 2545);
                }
                catch
                {
                    Console.WriteLine("Client with ID: " + thisID + " has Disconnected!");
                    break;
                }
                request = Encoding.ASCII.GetString(requestB);
                request=request.Replace("\0", string.Empty);
                string[] strArr;
                string strr="";
                string strr4="";
                if (request != "")
                {
                    strr = request.Substring(0, 3);
                    strr4 = request.Substring(0, 4);
                }
                if (strr.ToUpper()=="GET")
                {
                    strArr = request.Split(' ');
                }
                else if (strr4.ToUpper()=="POST")
                {
                    request = request.Replace("\r", string.Empty);
                    request = request.Replace("\n", string.Empty);
                    request = request.Replace(" ", string.Empty);
                    strArr = request.Split(new Char[] { '=', '&'});
                }
                else
                {

                    strArr = request.Split(',');

                }

               
                switch (strArr[0])
                {
                    case"<All data> ":
                        people = db.ReadAll();
                        result = DataPreparation();
                        SendDataToClient(thisID);
                        break;
                    case"<Delete>":
                        string str = strArr[1];
                        str = str.Replace(" ", string.Empty);
                        db.Delete(Convert.ToInt32(str));
                        break;
                    case"<Update> ":

                        if (strArr[9] == "True" || strArr[9] == "Man")
                        {
                            var per = new Person.Man(Convert.ToInt32(strArr[1]), strArr[2], strArr[3], Convert.ToInt32(strArr[4]), Convert.ToInt32(strArr[5]));
                            db.Update(Convert.ToInt32(strArr[1]), per);
                        }
                        else if (strArr[9] == "False" || strArr[9] == "Woman")
                        {
                            var per = new Person.Woman(Convert.ToInt32(strArr[1]), strArr[2], Convert.ToInt32(strArr[6]), strArr[7], strArr[8]);
                            db.Update(Convert.ToInt32(strArr[1]), per);
                        }                      
                        break;
                    case"<Add> ":
                        if (strArr[9] == "True" || strArr[9] == "Man")
                        {
                           var p = new List<Person.Person>();
                           p.Add(new Person.Man(Convert.ToInt32(strArr[1]), strArr[2], strArr[3], Convert.ToInt32(strArr[4]), Convert.ToInt32(strArr[5])));
                           db.Create(p);
                        }
                        else if (strArr[9] == "False" || strArr[9] == "" || strArr[9] == "Woman")
                        {
                            var p = new List<Person.Person>();
                            p.Add(new Person.Woman(Convert.ToInt32(strArr[1]), strArr[2], Convert.ToInt32(strArr[6]), strArr[7], strArr[8]));
                            db.Create(p);
                        }       
                        break;

                }

                switch (strArr[0].Substring(0,3))
                {
                    case "GET":
                        people = db.ReadAll();
                        result = TableForHTTP();
                        SendDataToHtml(thisID);
                        break;
                    case "POS":

                        switch (strArr[4])
                        {
                            case"<Add>":
                                 if (strArr[22] == "0" )
                                {
                                   var p = new List<Person.Person>();
                                   p.Add(new Person.Man(Convert.ToInt32(strArr[6]), strArr[8], strArr[10], Convert.ToInt32(strArr[12]), Convert.ToInt32(strArr[14])));
                                   db.Create(p);
                                }
                                else if (strArr[22] == "1")
                                {
                                    var p = new List<Person.Person>();
                                    p.Add(new Person.Woman(Convert.ToInt32(strArr[6]), strArr[8], Convert.ToInt32(strArr[16]), strArr[18], strArr[20]));
                                    db.Create(p);
                                }       
                             break;
                            case"<Update>":
                             if (strArr[22] == "0")
                             {
                                 var p = new Person.Man(Convert.ToInt32(strArr[6]), strArr[8], strArr[10], Convert.ToInt32(strArr[12]), Convert.ToInt32(strArr[14]));
                                 db.Update(Convert.ToInt32(strArr[6]),p);
                             }
                             else if (strArr[22] == "1")
                             {
                                 var p = new Person.Woman(Convert.ToInt32(strArr[6]), strArr[8], Convert.ToInt32(strArr[16]), strArr[18], strArr[20]);
                                 db.Update(Convert.ToInt32(strArr[6]), p);
                             }  
                             break;
                            case "<Delete>":
                             string str = strArr[6];
                             str = str.Replace(" ", string.Empty);
                             db.Delete(Convert.ToInt32(str));
                             break;

                        }
                        break;
                }






                for (int i = 0; i < 64; i++)
                {
                    requestB[i] = 0;
                }
            }
        }

        /// <summary>
        /// Method which is listening port 1000
        /// </summary>
        static void ListenThread()
        {
            tcpListener.Start(); 
            while (true)
            {
                clients.Add(tcpListener.AcceptTcpClient());
                netStreams.Add(clients[clients.Count - 1].GetStream());

                Thread clientThread = new Thread(new ParameterizedThreadStart(ClientRequest));
                clientThread.Start(clients.Count - 1);
            }
        }


        private static string TableForHTTP()
        {
            string str = null;
            for (int i = 0; i < people.Count; i++)
            {
                str = str + "<tr>" + people[i].WriteToHtml(people[i]) + "</tr>";
            }

            return str;

        }


    }
}
